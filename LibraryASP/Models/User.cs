using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryASP.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

     

        [StringLength(50, MinimumLength = 3)]
        public string Fname { get; set; }
        

        [StringLength(50, MinimumLength = 3)]
        public string Lname { get; set; }
       

        [ForeignKey("Book")]
        //grne
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? B_borrowed { get; set; }

        public virtual Book Book { get; set; }






    }
}