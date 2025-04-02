using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public int PersonId { get; set; }
        public Person Personal { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
