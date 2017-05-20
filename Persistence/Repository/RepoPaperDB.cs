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
                        if (b.PaperId == paperId && b.PCMemberUserId == bid.Key.Id)
                        {
                            exists = true;
                            break;
                        }
                    if (!exists)
                    {
                        Bid b = new Bid();
                        b.BiddingEvaluation = bid.Value;
                        b.PCMemberUserId = bid.Key.Id;
                        b.PaperId = paperId;
                        b.PCMemberConferenceId = newP.ConferenceId;

                        context.Bids.Add(b);
                    }
                }

                foreach(Model.Review review in newP.Reviews)
                {
                    if (context.Reviews.Find(review.Id) == null)
                    {
                        Review rev = new Review();
                        rev.PCMemberUserId = review.Reviewer.Id;
                        rev.PCMemberConferenceId = review.Reviewer.Conference.Id;
                        rev.PaperId = paperId;
                        rev.Evaluation= Enum.GetName(review.Verdict.GetType(), review.Verdict);
                        rev.Recommandations = review.Comments;

                        context.Reviews.Add(rev);
                    }

                }

                context.SaveChanges();
            }
        }
    }
}
