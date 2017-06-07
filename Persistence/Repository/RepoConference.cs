using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoConference
    {
        List<Model.Conference> conferences = new List<Model.Conference>();
        /*Function which adds a new conference.
        * In:Conference details
        * Out: returneaza id-u conferintei
            new conference in the list
        * Conditions which are checked in repository:
        * DeadlineAbstract < DeadlineComplet < DeadlineParticipation < DeadlineBidding < DeadlineEvaluation < BeginDate < EndDate
        * AdmissionPrice>0
        * Id-unique
        */
        public int addConference(Model.Conference c)
        {
            if (c.AdmissionPrice < 1)
            {
                throw new Exception("Conference admission price must be >=1!");
            }
            if ((DateTime.Compare(c.DeadlineAbstract, c.DeadlineComplet) < 0) && (DateTime.Compare(c.DeadlineComplet, c.DeadlineParticipation) < 0) && (DateTime.Compare(c.DeadlineParticipation, c.DeadlineBidding) < 0))
            {
                if ((DateTime.Compare(c.DeadlineBidding, c.DeadlineEvaluation) < 0) && (DateTime.Compare(c.DeadlineEvaluation, c.BeginDate) < 0) && (DateTime.Compare(c.BeginDate, c.EndDate) < 0))
                {
                    foreach (Model.Conference conf in getConferences())
                    {
                        if (conf.Id == c.Id)
                        {
                            throw new Exception("Conference already exist!");
                        }
                    }

                    using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
                    {
                        Conference conference = new Conference();
                        conference.ConferenceId = c.Id;
                        conference.Name = c.Name;
                        conference.Edition = c.Edition;
                        conference.DeadlineAbstractPaper = c.DeadlineAbstract;
                        conference.DeadlineBiddingPaper = c.DeadlineBidding;
                        conference.DeadlineCompletePaper = c.DeadlineComplet;
                        conference.DeadlineEvaluation = c.DeadlineEvaluation;
                        conference.DeadlineParticipation = c.DeadlineParticipation;
                        conference.EndDate = c.EndDate;
                        conference.BeginDate = c.BeginDate;
                        conference.City = c.City;
                        conference.Country = c.Country;
                        conference.Website = c.Website;
                        conference.Price = c.AdmissionPrice;

                        if (Find(conference.ConferenceId) == false)
                        {
                            context.Conferences.Add(conference);
                            context.SaveChanges();
                            return conference.ConferenceId;
                        }
                        else throw new Exception("Conference already exists!");
                    }

                    //TO DO->ADD PC MEMBERS.Astept functia
                }
                else
                {
                    throw new Exception("Dates must be in chronological order!");
                }
            }
            else
            {
                throw new Exception("Dates must be in chronological order!");
            }
        }


        public bool Find(int id)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                var u = context.Conferences.Find(id);
                if (u != null)
                {
                    return true;
                }
                return false;
                // return new Model.Conference(u.ConferenceId,u.Name,u.Edition,u.Topics,u.DeadlineAbstractPaper,u.DeadlineCompletePaper,u.DeadlineBiddingPaper,u.DeadlineEvaluation,u.DeadlineParticipation,u.City,u.Country,u.Website,u.Price,u.BeginDate,u.EndDate);
            }
        }

        public Model.Conference getConference(int id)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                Conference u = context.Conferences.Find(id);
                if (u != null)
                {
                    throw new Exception("No conference with given id!");
                }
                List<string> topics = new List<string>();
                foreach (var t in context.getTopicsFor1Conference(id))
                {
                    topics.Add(t.TopicName);
                }
                return new Model.Conference(id, u.Name, u.Edition, topics, u.DeadlineAbstractPaper, u.DeadlineCompletePaper, u.DeadlineBiddingPaper, u.DeadlineEvaluation, u.DeadlineParticipation, u.City, u.Country, u.Website, u.Price, u.BeginDate, u.EndDate);
            }
        }


        public List<Model.Conference> getConferences()
        {
            List<Model.Conference> all = new List<Model.Conference>();
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach (var c in context.getConferences)
                {
                    List<string> topics = new List<string>();
                    foreach (var t in context.getTopicsFor1Conference(c.ConferenceId))
                    {
                        topics.Add(t.TopicName);
                    }

                    Model.Conference conf = new Model.Conference(c.ConferenceId, c.Name, c.Edition, topics, c.DeadlineAbstractPaper, c.DeadlineCompletePaper, c.DeadlineBiddingPaper, c.DeadlineEvaluation, c.DeadlineParticipation, c.City, c.Country, c.Website, c.Price, c.BeginDate, c.EndDate);
                    all.Add(conf);
                }
            }
            return all;
        }

        public void updateConference(Model.Conference c)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                Conference conference = context.Conferences.Find(c.Id);
                if (conference == null)
                    return;
                conference.DeadlineAbstractPaper = c.DeadlineAbstract;
                conference.DeadlineBiddingPaper = c.DeadlineBidding;
                conference.DeadlineCompletePaper = c.DeadlineComplet;
                conference.DeadlineEvaluation = c.DeadlineEvaluation;
                conference.DeadlineParticipation = c.DeadlineParticipation;
                conference.BeginDate = c.BeginDate;
                conference.EndDate = c.EndDate;

                context.SaveChanges();

            }
        }

        public void addTopic(string topicName, int confId)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                Topic topic = new Topic();
                topic.ConferenceId = confId;
                topic.TopicName = topicName;
                context.Topics.Add(topic);
                context.SaveChanges();
            }
        }
    }

}

