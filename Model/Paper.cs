using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Paper
    {
        public User Uploader { get; set; }
        public string Abstract { get; set; }
        public string FullPaper { get; set; }
        public string Presentation { get; set; }
        public Dictionary<Participant, string> Bids { get; set; }
        public List<Participant> Reviewers { get; set; }
        public List<Review> Reviews { get; set; }
        public Status Status { get; set; }
        public List<Author> AdditionalAuthors { get; set; }
        public string Domain { get; set; }
        public string Subdomain { get; set; }
        public string Resume { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }

        public Paper(int id, User uploader, string Title, string abs, string domain, string subdomain, string resume)
        {
            Uploader = uploader;
            Abstract = abs;
            Bids = new Dictionary<Participant, string>();
            Reviewers = new List<Participant>();
            Reviews = new List<Review>();
            AdditionalAuthors = new List<Author>();
            Domain = domain;
            Subdomain = subdomain;
            Resume = resume;
            Title = Title;
            Id = id;
        }

        public Paper()
        {
            Uploader = new User(0,"a","a","a", "a", "a", true,0, "a");
            Abstract = "";
            Bids = new Dictionary<Participant, string>();
            Reviewers = new List<Participant>();
            Reviews = new List<Review>();
            AdditionalAuthors = new List<Author>();
            Domain = "";
            Subdomain = "";
            Resume = "";
            Title = "";
            Id = 0;
        }

        public void DetermineStatus()
        {
            /*
            tbd

            int rejects = 0;
            int accepts = 0;
            foreach(Review r in Reviews)
            {

            }
            */
        }

        public void AddBid(Participant p, string b)
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
