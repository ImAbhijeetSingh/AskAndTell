using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskAndTell.Models
{
    public class Answer
    {
        public Answer()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Body { get; set; }
        public bool IsAccepted { get; set; }
        public int Votes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
    }
}