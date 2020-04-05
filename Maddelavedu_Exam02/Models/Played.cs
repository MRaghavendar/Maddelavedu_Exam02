using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maddelavedu_Exam02.Models
{
   

    public class Played
    {
        public int MatchID { get; set; }
        public int PlayedID { get; set; }
        public int PlayerID { get; set; }
        public int Score { get; set; }
        

        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}