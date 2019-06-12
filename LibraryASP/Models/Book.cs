using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryASP.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title{ get; set; }
        [StringLength(50, MinimumLength = 3)]

        public string Author { get; set; }
       

        public Boolean Available { get; set; }
        
}
}