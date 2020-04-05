using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Maddelavedu_Exam02.Models
{
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatchID { get; set; }
        public string Stadium { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Played> Played { get; set; }
    }
}