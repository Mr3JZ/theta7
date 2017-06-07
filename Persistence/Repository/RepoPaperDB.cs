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
        private readonly ISSEntities2 _context;
        public RepoPaperDB(ISSEntities2 context)
        {
            _context = context;
        }
        public List<Model.Paper> GetByConference(int confId)
        {
            List<Model.Paper> all = new List<Model.Paper>();
            
                foreach (Paper paper in _context.Papers)
                {
                    if (paper.ConferenceId == confId)
                    {
                        User u = _context.Users.Find(paper.UserId);
                        Model.User user = new Model.User(u.UserId, u.Username, u.Password, u.Name, u.Affilliation, u.Email, u.canBePCMember, u.WebPage);

                        Topic t = _context.Topics.Find(paper.TopicId);

                        Model.Paper p = new Model.Paper(paper.PaperId, paper.ConferenceId, user, paper.Name, paper.Filepath, paper.Domain, paper.Subdomain, paper.Resume, t.TopicName);

                        List<Author> authors = new List<Author>();
                        foreach (AdditionalAuthor a in _context.AdditionalAuthors)
                        {
                            if (a.PaperId == paper.PaperId)
                            {
                                Author au = new Author(a.AdditionalAuthorId, a.Name, a.Affiliation);
                                authors.Add(au);
                            }
                        }

                        p.AdditionalAuthors = authors;

                        foreach (Bid b in _context.Bids)
                        {
                            if (b.PaperId == paper.PaperId)
                            {
                                User us = _context.Users.Find(b.PCMemberUserId);
                                PCMember pcm = _context.PCMembers.Find(b.PCMemberUserId, b.PCMemberConferenceId);
                                Model.User bidder = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);
                                Model.Participant participant = new Model.Participant(bidder, b.PCMemberConferenceId, pcm.isChair, pcm.isCoChair, true, false);

                                p.AddBid(participant, b.BiddingEvaluation);

                            }
                        }

                        foreach (var r in _context.getReviewsPaper(paper.PaperId))
                        {
                            User us = _context.Users.Find(r.PCMemberUserId);
                            PCMember pcm = _context.PCMembers.Find(r.PCMemberUserId, paper.ConferenceId);
                            Model.User reviewer = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);
                            Model.Participant participant = new Model.Participant(reviewer, paper.ConferenceId, pcm.isChair, pcm.isCoChair, true, false);

                            Model.Review review;

                            if (r.Evaluation != null)
                            {
                                Verdict v = (Verdict)r.Evaluation;
                                review = new Model.Review(0, participant, v, r.Recommandations);
                                p.AddReview(review);
                            }

                            p.AddReviewer(participant);


                        }

                        all.Add(p);
                    }
                }

            return all;
        }


        public void Add(Model.Paper p)
        {
            
                Paper paper = new Paper();
                paper.Name = p.Title;
                paper.Resume = p.Resume;
                paper.Domain = p.Domain;
                paper.Subdomain = p.Subdomain;
                paper.Filepath = p.Filepath;
                paper.EvaluationResult = Enum.GetName(p.Status.GetType(), p.Status);
                paper.IsEmailSent = false;
                paper.ConferenceId = p.ConferenceId;
                paper.UserId = p.Uploader.IdUser;
                //paper.TopicId get topic by name and conf
                foreach (Topic topic in _context.Topics)
                    if (topic.TopicName == p.Topic && topic.ConferenceId == p.ConferenceId)
                    {
                        paper.TopicId = topic.TopicId;
                        break;
                    }

            _context.Papers.Add(paper);
            _context.SaveChanges();

                foreach (Author author in p.AdditionalAuthors)
                    if (_context.AdditionalAuthors.Find(author.IdAuthor) == null)
                    {
                        AdditionalAuthor aa = new AdditionalAuthor();
                        aa.Affiliation = author.Affiliation;
                        aa.Name = author.Name;
                        aa.PaperId = paper.PaperId;
                    _context.AdditionalAuthors.Add(aa);
                    }

            _context.SaveChanges();
            
        }

        public void Remove(int id)
        {
                var u = _context.Papers.Find(id);
            _context.Papers.Remove(u);
            _context.SaveChanges();
            
        }

        public void Modify(int paperId, Model.Paper newP)
        {
                Paper paper = _context.Papers.Find(paperId);
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
                    if (_context.AdditionalAuthors.Find(author.IdAuthor) == null)
                    {
                        AdditionalAuthor aa = new AdditionalAuthor();
                        aa.Affiliation = author.Affiliation;
                        aa.Name = author.Name;
                        aa.PaperId = paperId;
                    _context.AdditionalAuthors.Add(aa);
                    }

                foreach (KeyValuePair<Participant, int> bid in newP.Bids)
                {
                    //get bid by lucrare, participant add daca nu exista, modify daca exista
                    bool exists = false;
                    foreach (Bid b in _context.Bids)
                        if (b.PaperId == paperId && b.PCMemberUserId == bid.Key.User.IdUser)
                        {
                            b.BiddingEvaluation = bid.Value;
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

                    _context.Bids.Add(b);
                    }

                }

                foreach (Model.Review review in newP.Reviews)
                {
                    //daca nu exista review adauga nou, altfel modifica
                    Review r = _context.Reviews.Find(review.Reviewer.User.IdUser, newP.ConferenceId, newP.Id);
                    if ( r== null)
                    {
                        Review rev = new Review();
                        rev.PCMemberUserId = review.Reviewer.User.IdUser;
                        rev.PCMemberConferenceId = review.Reviewer.ConferenceId;
                        rev.PaperId = paperId;
                        rev.Evaluation = (int)review.Verdict;
                        rev.Recommandations = review.Comments;

                    _context.Reviews.Add(rev);
                    }
                    else
                    {
                        r.Evaluation = (int)review.Verdict;
                        r.Recommandations = review.Comments;
                    }

                }

            _context.SaveChanges();
            
        }

        public List<Model.Review> GetReviewsByPaper(int paperId)
        {
            List<Model.Review> all = new List<Model.Review>();
            
                var paper = _context.Papers.Find(paperId);
                foreach (var r in _context.getReviewsPaper(paperId))
                {
                    User us = _context.Users.Find(r.PCMemberUserId);
                    PCMember pcm = _context.PCMembers.Find(r.PCMemberUserId, paper.ConferenceId);
                    Model.User reviewer = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);
                    Model.Participant participant = new Model.Participant(reviewer, paper.ConferenceId, pcm.isChair, pcm.isCoChair, true, false);

                    Verdict v = (Verdict)r.Evaluation;

                    Model.Review review = new Model.Review(0, participant, v, r.Recommandations);
                    all.Add(review);
                }
            

            return all;
        }

        public void AddReview(int paperId, Model.Review review)
        {
            
                Review rev = _context.Reviews.Find(review.Reviewer.User.IdUser,review.Reviewer.ConferenceId,paperId);

                rev.Evaluation = (int)review.Verdict;
                rev.Recommandations = review.Comments;

            _context.SaveChanges();
            
        }
    }
}
