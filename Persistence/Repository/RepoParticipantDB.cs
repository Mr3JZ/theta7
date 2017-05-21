using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoParticipantDB
    {
        public List<Model.Participant> GetByConference(int confId)
        {
            List<Model.Participant> all = new List<Participant>();

            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach (ConferenceParticipant p in context.ConferenceParticipants)
                    if (p.ConferenceId == confId)
                    {
                        User us = context.Users.Find(p.UserId);
                        Model.User user = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);

                        Participant part = new Participant(user, confId, false, false, false, true);
                        all.Add(part);
                    }

                foreach (PCMember p in context.PCMembers)
                {
                    if (p.ConferenceId == confId)
                    {
                        User us = context.Users.Find(p.UserId);
                        Model.User user = new Model.User(us.UserId, us.Username, us.Password, us.Name, us.Affilliation, us.Email, us.canBePCMember, us.WebPage);

                        Participant part = new Participant(user, confId, p.isChair, p.isCoChair, true, false);
                        all.Add(part);
                    }
                }
            }

            return all;
        }

        public void Add(Participant p)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                if (p.IsNormalUser == true)
                {
                    ConferenceParticipant participant = new ConferenceParticipant();
                    participant.UserId = p.User.IdUser;
                    participant.ConferenceId = p.ConferenceId;
                    participant.PaymentId = -1;

                    context.ConferenceParticipants.Add(participant);
                    context.SaveChanges();
                }
                else
                {
                    PCMember pcm = new PCMember();
                    pcm.UserId = p.User.IdUser;
                    pcm.ConferenceId = p.ConferenceId;
                    pcm.isChair = p.IsChair;
                    pcm.isCoChair = p.IsCochair;

                    context.PCMembers.Add(pcm);
                    context.SaveChanges();
                }
            }
        }
    }
}
