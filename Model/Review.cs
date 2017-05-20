using System;

namespace Model
{
    [Serializable]
    public class Review
    {
        public Review(int id, Participant reviewer, Verdict verdict, string comments)
        {
            Id = id;
            Reviewer = reviewer;
            Verdict = verdict;
            Comments = comments;
        }

        public int Id { get; set; }
        public Participant Reviewer { get; set; }

        public Verdict Verdict { get; set; }

        public string Comments { get; set; }
    }
}
