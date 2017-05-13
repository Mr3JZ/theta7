using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Paper
    {
        //public User Uploader {get;set;}
        public string Abstract { get; set; }
        public string FullPaper { get; set; }
        public string Presentation { get; set; }
        //public Dictionary<Participant,string>  {get;set;}
        //public List<Participant> Reviewers {get;set;}
        //public List<Review> Reviews {get;set;}
        //public Status Status {get;set;}
        //public List<Author> AdditionalAuthors {get;set;}
        public string Domain { get; set; }
        public string Subdomain { get; set; }
        public string Resume { get; set; }
        public string Title { get; set; }
    }
}
