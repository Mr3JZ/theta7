using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoSessionDB
    {
        public List<Model.Session> GetByConference(int confId)
        {
            List<Model.Session> all = new List<Model.Session>();


            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach(var s in context.getSessionsForConference(confId))
                {
                    List<Model.Reservation> reservations = new List<Model.Reservation>();
                    
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
                            User use = context.Users.Find(b.PCMemberUserId);
                            PCMember pcm = context.PCMembers.Find(b.PCMemberUserId,confId);
                            Model.User userr = new Model.User(use.UserId, use.Username, use.Password, use.Name, use.Affilliation, use.Email, use.canBePCMember, use.WebPage);
                            Participant participant = new Participant(userr, confId, pcm.isChair, pcm.isCoChair, true, false);

                            paper.AddBid(participant, b.BiddingEvaluation);
                        }

                        foreach(var r in context.getReviewsPaper(p.PaperId))
                        {
                            User use = context.Users.Find(r.PCMemberUserId);
                            PCMember pcm = context.PCMembers.Find(r.PCMemberUserId,confId);
                            Model.User userr = new Model.User(use.UserId, use.Username, use.Password, use.Name, use.Affilliation, use.Email, use.canBePCMember, use.WebPage);
                            Participant participant = new Participant(userr, confId, pcm.isChair, pcm.isCoChair, true, false);

                            Model.Review rev = new Model.Review(0, participant, (Verdict)r.Evaluation, r.Recommandations);
                            paper.AddReview(rev);
                            paper.AddReviewer(participant);
                        }

                        foreach(var res in context.getReservationPaper(paper.Id))
                        {
                            string room = "Room: " + res.RoomName + ", Street: " + res.Street + ", City: " + res.City;

                            Reservation rv = new Reservation(0, paper, room, DateTime.Parse(res.Timp.ToString()), res.Duration,DateTime.Parse(res.Data.ToString()));
                            reservations.Add(rv);
                        }

                    }

                    User us = context.Users.Find(s.SessionChairId);
                    PCMember pc = context.PCMembers.Find(s.SessionChairId,confId);
                    Model.User user2 = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);
                    Participant sesChair = new Participant(user2, confId, pc.isChair, pc.isCoChair, true, false);

                    Model.Session se = new Model.Session(s.SessionId, reservations,sesChair);

                    all.Add(se);

                }
            }

            return all;
        }
    }
}
