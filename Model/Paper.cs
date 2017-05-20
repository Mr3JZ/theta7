using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Paper
    {
        public User Uploader { get; set; }
        public string Filepath { get; set; }
        public Dictionary<Participant, int> Bids { get; set; }
        public List<Participant> Reviewers { get; set; }
        public List<Review> Reviews { get; set; }
        public Status Status { get; set; }
        public List<Author> AdditionalAuthors { get; set; }
        public string Domain { get; set; }
        public string Subdomain { get; set; }
        public string Resume { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public int Id { get; set; }
        public int ConferenceId { get; set; }

        public Paper(int id, int confId,User uploader, string title, string abs, string domain, string subdomain, string resume,string topic)
        {
            Topic = topic;
            Uploader = uploader;
            Filepath = abs;
            Bids = new Dictionary<Participant, int>();
            Reviewers = new List<Participant>();
            Reviews = new List<Review>();
            AdditionalAuthors = new List<Author>();
            Domain = domain;
            Subdomain = subdomain;
            Resume = resume;
            Title = title;
            Id = id;
            Status = Status.PENDING;
            ConferenceId = confId;
        }

        public Paper()
        {
            Uploader = new Model.User(0,"a","a","a", "a", "a", true, "a");
            Bids = new Dictionary<Participant, int>();
            Reviewers = new List<Participant>();
            Reviews = new List<Review>();
            AdditionalAuthors = new List<Author>();
            Domain = "";
            Subdomain = "";
            Resume = "";
            Title = "";
            Id = 0;
            Status = Status.PENDING;
        }

        public void DetermineStatus()
        {

            int rejects = 0;
            int accepts = 0;
            foreach(Review r in Reviews)
            {
                if (r.Verdict == Verdict.WEAK_ACCEPT || r.Verdict == Verdict.STRONG_ACCEPT || r.Verdict == Verdict.ACCEPT)
                    accepts++;
                if (r.Verdict == Verdict.WEAK_REJECT || r.Verdict == Verdict.STRONG_REJECT || r.Verdict == Verdict.REJECT)
                    rejects++;
            }
            if (rejects == 0)
                Status = Status.ACCEPTED;
            else if (accepts == 0)
                Status = Status.REJECTED;
            else
                Status = Status.CONFLICTING;
            
        }

        public void AddBid(Participant p, int b)
        {
            Bids.Add(p, b);
        }

        public void AddReviewer(Participant p)
        {
            Reviewers.Add(p);
        }

        public void AddReview(Review r)
        {
            Reviews.Add(r);
        }

    }
}
