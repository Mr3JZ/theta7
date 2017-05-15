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
        List<Conference> conferences=new List<Conference>();
        /*Function which adds a new conference.
        * In:Conference details
        * Out:new conference in the list
        * Conditions which are checked in repository:
        * DeadlineAbstract < DeadlineComplet < DeadlineParticipation < DeadlineBidding < DeadlineEvaluation < BeginDate < EndDate
        * AdmissionPrice>0
        * Id-unique
        */
        public void addConference(Conference c)
        {
            if (c.AdmissionPrice < 1)
            {
                throw new RepositoryException("Conference admission price must be >=1!");
            }
            if ((DateTime.Compare(c.DeadlineAbstract, c.DeadlineComplet) < 0) && (DateTime.Compare(c.DeadlineComplet, c.DeadlineParticipation) < 0) && (DateTime.Compare(c.DeadlineParticipation, c.DeadlineBidding) < 0))
            {
                if ((DateTime.Compare(c.DeadlineBidding, c.DeadlineEvaluation) < 0) && (DateTime.Compare(c.DeadlineEvaluation, c.BeginDate) < 0) && (DateTime.Compare(c.BeginDate, c.EndDate) < 0))
                {
                    foreach (Conference conf in getConferences())
                    {
                        if (conf.Id == c.Id)
                        {
                            throw new RepositoryException("Conference already exist!");
                        }
                    }

                    conferences.Add(c);
                    //TO DO->ADD PC MEMBERS.Astept functia
                }
                else
                {
                    throw new RepositoryException("Dates must be in chronological order!");
                }
            }
            else
            {
                throw new RepositoryException("Dates must be in chronological order!");
            }
        }

        public List<Conference> getConferences()
        {
            return conferences;
        }
    }
}

