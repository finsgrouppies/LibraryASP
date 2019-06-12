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
     
        
            public int ID { get; set; }

            [StringLength(50, MinimumLength = 3)]
            public string FName { get; set; }

            [StringLength(50, MinimumLength = 3)]
            public string LName { get; set; }


        [ForeignKey("Book")]
        public int B_borrowed { get; set; }

        public virtual Book Book { get; set; }

        
            
        }
    }
