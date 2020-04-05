using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maddelavedu_Exam02.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Played> Played { get; set; }
    }
}