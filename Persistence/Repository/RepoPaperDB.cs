using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoPaperDB
    {
        public List<Model.Paper> GetByConference(int confId)
        {
            List<Model.Paper> all = new List<Model.Paper>();

            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach(Paper paper in context.Papers)
                {
                    if (paper.ConferenceId == confId)
                    {
                        User u = context.Users.Find(paper.UserId);
                        Model.User user = new Model.User(u.UserId, u.Username, u.Password, u.Name, u.Affilliation, u.Email, u.canBePCMember, u.WebPage);

                        Topic t = context.Topics.Find(paper.TopicId);

                        Model.Paper p = new Model.Paper(paper.PaperId, paper.ConferenceId, user, paper.Name, paper.Filepath, paper.Domain, paper.Subdomain, paper.Resume, t.TopicName);

                        List<Author> authors = new List<Author>();
                        foreach(AdditionalAuthor a in context.AdditionalAuthors)
                        {
                            if (a.PaperId == paper.PaperId)
                            {
                                Author au = new Author(a.AdditionalAuthorId, a.Name, a.Affiliation);
                                authors.Add(au);
                            }
                        }

                        p.AdditionalAuthors = authors;

                        foreach(Bid b in context.Bids)
                        {
                            if (b.PaperId == paper.PaperId)
                            {
                                User us = context.Users.Find(b.PCMemberUserId);
                                PCMember pcm = context.PCMembers.Find(b.PCMemberUserId, b.PCMemberConferenceId);
                                Model.User bidder = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);
                                Model.Participant participant = new Model.Participant(bidder, b.PCMemberConferenceId, pcm.isChair, pcm.isCoChair, true, false);

                                p.AddBid(participant, b.BiddingEvaluation);
                                
                            }
                        }

                        foreach(Review r in context.Reviews)
                        {
                            if (r.PaperId == paper.PaperId)
                            {
                                User us = context.Users.Find(r.PCMemberUserId);
                                PCMember pcm = context.PCMembers.Find(r.PCMemberUserId, r.PCMemberConferenceId);
                                Model.User reviewer = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);
                                Model.Participant participant = new Model.Participant(reviewer, r.PCMemberConferenceId, pcm.isChair, pcm.isCoChair, true, false);

                                Verdict v = (Verdict)r.Evaluation;

                                Model.Review review = new Model.Review(0, participant, v, r.Recommandations);

                                p.AddReviewer(participant);
                                p.AddReview(review);

                            }
                        }

                        all.Add(p);
                    }
                }

            }

            return all;
        }


        public void Add(Model.Paper p)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                Paper paper= new Paper();
                paper.Name = p.Title;
                paper.Resume = p.Resume;
                paper.Domain = p.Domain;
                paper.Subdomain = p.Subdomain;
                paper.Filepath = p.Filepath;
                paper.EvaluationResult = Enum.GetName(p.Status.GetType(),p.Status);
                paper.IsEmailSent = false;
                paper.ConferenceId = p.ConferenceId;
                paper.UserId = p.Uploader.IdUser;
                //paper.TopicId get topic by name and conf
                foreach(Topic topic in context.Topics)
                    if(topic.TopicName==p.Topic && topic.ConferenceId == p.ConferenceId)
                    {
                        paper.TopicId = topic.TopicId;
                        break;
                    }

                context.Papers.Add(paper);
                context.SaveChanges();

                foreach (Author author in p.AdditionalAuthors)
                    if (context.AdditionalAuthors.Find(author.IdAuthor) == null)
                    {
                        AdditionalAuthor aa = new AdditionalAuthor();
                        aa.Affiliation = author.Affiliation;
                        aa.Name = author.Name;
                        aa.PaperId = paper.PaperId;
                        context.AdditionalAuthors.Add(aa);
                    }

                context.SaveChanges();


                
            }
        }

        public void Modify(int paperId,Model.Paper newP)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                Paper paper = context.Papers.Find(paperId);
                if (paper == null)
                    return;
                paper.Name = newP.Title;
                paper.Resume = newP.Resume;
                paper.Domain = newP.Domain;
                paper.Subdomain = newP.Subdomain;
                paper.Filepath = newP.Filepath;
                paper.EvaluationResult = Enum.GetName(newP.Status.GetType(), newP.Status);
                paper.IsEmailSent = false;
                paper.ConferenceId = newP.ConferenceId;
                paper.UserId = newP.Uploader.IdUser;

                foreach (Author author in newP.AdditionalAuthors)
                    if (context.AdditionalAuthors.Find(author.IdAuthor) == null)
                    {
                        AdditionalAuthor aa = new AdditionalAuthor();
                        aa.Affiliation = author.Affiliation;
                        aa.Name = author.Name;
                        aa.PaperId = paperId;
                        context.AdditionalAuthors.Add(aa);
                    }

                foreach(KeyValuePair<Participant,int> bid in newP.Bids)
                {
                    //get bid by lucrare, participant add daca nu exista
                    bool exists = false;
                    foreach (Bid b in context.Bids)
                        if (b.PaperId == paperId && b.PCMemberUserId == bid.Key.User.IdUser)
                        {
                            exists = true;
                            break;
                        }
                    if (!exists)
                    {
                        Bid b = new Bid();
                        b.BiddingEvaluation = bid.Value;
                        b.PCMemberUserId = bid.Key.User.IdUser;
                        b.PaperId = paperId;
                        b.PCMemberConferenceId = newP.ConferenceId;

                        context.Bids.Add(b);
                    }
                }

                foreach(Model.Review review in newP.Reviews)
                {
                    if (context.Reviews.Find(review.Reviewer.User.IdUser,newP.ConferenceId,newP.Id) == null)
                    {
                        Review rev = new Review();
                        rev.PCMemberUserId = review.Reviewer.User.IdUser;
                        rev.PCMemberConferenceId = review.Reviewer.ConferenceId;
                        rev.PaperId = paperId;
                        rev.Evaluation= (int)review.Verdict;
                        rev.Recommandations = review.Comments;

                        context.Reviews.Add(rev);
                    }

                }

                context.SaveChanges();
            }
        }
    }
}
