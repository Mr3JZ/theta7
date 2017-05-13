using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Conference
    {

        public List<Participant> Participants { get; set; }
        public List<Session> Sessions{get;set;}
        public List<Paper> Papers{get;set;}
        public string Name { get; set; }
        public string Edition { get; set; } 
        public List<string> Topics { get; set; }
        public DateTime DeadlineAbstract { get; set; }
        public DateTime DeadlineComplet { get; set; }
        public DateTime DeadlineBidding { get; set; }
        public DateTime DeadlineEvaluation { get; set; }
        public DateTime DeadlineParticipation { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public float AdmissionPrice { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Id { get; set; }

        
        public Conference(int id,string name, string edition, List<string> topics, DateTime deadlineAbstract, DateTime deadlineComplet, DateTime deadlineBidding, DateTime deadlineEvaluation, DateTime deadlineParticipation, string city, string country, string website, float admissionPrice, DateTime beginDate, DateTime endDate)
        {
            Name = name;
            Edition = edition;
            Topics = topics;
            DeadlineAbstract = deadlineAbstract;
            DeadlineComplet = deadlineComplet;
            DeadlineBidding = deadlineBidding;
            DeadlineEvaluation = deadlineEvaluation;
            DeadlineParticipation = deadlineParticipation;
            City = city;
            Country = country;
            Website = website;
            AdmissionPrice = admissionPrice;
            BeginDate = beginDate;
            EndDate = endDate;
            Id = id;
            Papers = new List<Paper>();
            Sessions = new List<Session>();
            Participants = new List<Participant>();
        }

        public Conference()
        {
            Name = "";
            Edition = "";
            Topics = new List<String>();
            DeadlineAbstract = new DateTime(2000,1,1);
            DeadlineComplet = new DateTime(2000, 1, 1);
            DeadlineBidding = new DateTime(2000, 1, 1);
            DeadlineEvaluation = new DateTime(2000, 1, 1);
            DeadlineParticipation = new DateTime(2000, 1, 1);
            City = "";
            Country = "";
            Website = "";
            AdmissionPrice = 0;
            BeginDate = new DateTime(2000, 1, 1);
            EndDate = new DateTime(2000, 1, 1);
            Id = 0;
            Papers = new List<Paper>();
            Sessions = new List<Session>();
            Participants = new List<Participant>();
        }

        
        public List<Paper> GetPapersByUploader(User u)
        {
            List<Paper> result=new List<Paper>();
            foreach(Paper p in Papers)
                if(p.Uploader==u)
                    result.Add(p);
            return result;
        }
        
        public void AddPaper(Paper p){
            Papers.Add(p);
        }

        public void AddParticipant(Participant p){
            Participants.Add(p);
        }

        public void AddSession(Session s){
            Sessions.Add(s);
        }
        
        public void RemoveRejectedPapers(){
            Papers.RemoveAll( p=>p.Status== Status.REJECTED);
        }
        
        
    }
}
