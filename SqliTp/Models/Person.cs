using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Column("FirstName", TypeName = "nvarchar(100)")]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
