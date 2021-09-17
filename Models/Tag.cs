using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskAndTell.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Questions = new HashSet<Question>();
        }
        public int Id { get; set; }
        public string TagName{ get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}