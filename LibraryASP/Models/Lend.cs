using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryASP.Models
{
    public class Lend
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LendID { get; set; }

      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }
      //  [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
      //  [StringLength(150, MinimumLength = 3)]
        public string Fname { get; set; }


        public virtual Book Book { get; set; }
        public virtual User User { get; set; }






    }
}