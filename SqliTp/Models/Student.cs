using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string StudentNumber { get; set; }
        public int PersonId { get; set; }
        public Person Personal { get; set; }
    }
}
