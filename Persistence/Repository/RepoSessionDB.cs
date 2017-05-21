using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class RepoSessionDB
    {
        public List<Model.Session> getByConference(int confId)
        {
            List<Model.Session> all = new List<Model.Session>();
            Console.WriteLine("plm");
            return all;


            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach(var s in context.getSessionsForConference(confId))
                {
                    List<Model.Paper> papers = new List<Model.Paper>();
                    
                    foreach(var p in context.getPapersSession(s.SessionId))
                    {
                        User u = context.Users.Find(p.UserId);
                        Model.User user = new Model.User(u.UserId, u.Username, u.Password, u.Name, u.Affilliation, u.Email, u.canBePCMember, u.WebPage);
                        Model.Paper paper = new Model.Paper(p.PaperId, confId, user, p.Name, p.Filepath, p.Domain, p.Subdomain, p.Resume, p.TopicName);

                        List<Author> authors = new List<Author>();

                        foreach(var a in context.getAdditionalAuthors(p.PaperId))
                        {
                            Author au = new Author(0, a.Name, a.Affiliation);
                            authors.Add(au);
                        }
                        paper.AdditionalAuthors = authors;

                        foreach(var b in context.getBidsResult(p.PaperId))
                        {
                            User use = context.Users.Find(b.PCMemberUserId,confId);
                            PCMember pcm = context.PCMembers.Find(b.PCMemberUserId);
                            Model.User userr = new Model.User(use.UserId, use.Username, use.Password, use.Name, use.Affilliation, use.Email, use.canBePCMember, use.WebPage);
                            Participant participant = new Participant(userr, confId, pcm.isChair, pcm.isCoChair, true, false);

                            paper.AddBid(participant, b.BiddingEvaluation);
                        }

                        foreach(var r in context.getReviewsPaper(p.PaperId))
                        {
                            User use = context.Users.Find(r.PCMemberUserId, confId);
                            PCMember pcm = context.PCMembers.Find(r.PCMemberUserId);
                            Model.User userr = new Model.User(use.UserId, use.Username, use.Password, use.Name, use.Affilliation, use.Email, use.canBePCMember, use.WebPage);
                            Participant participant = new Participant(userr, confId, pcm.isChair, pcm.isCoChair, true, false);

                            Model.Review rev = new Model.Review(0, participant, (Verdict)r.Evaluation, r.Recommandations);
                            paper.AddReview(rev);
                            paper.AddReviewer(participant);
                        }

                    }

                }
            }

            return all;
        }
    }
}
