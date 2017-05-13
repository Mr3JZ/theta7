using System;

namespace Model
{
    public class Review
    {
        public Review(int id, Participant reviewer, Verdict verdict, string comments, Paper paper)
        {
            Id = id;
            Reviewer = reviewer;
            Verdict = verdict;
            Comments = comments;
            Paper = paper;
        }

        public int Id { get; set; }
        public Participant Reviewer { get; set; }

        public Verdict Verdict { get; set; }

        public string Comments { get; set; }

        public Paper Paper { get; set; }
    }
}
