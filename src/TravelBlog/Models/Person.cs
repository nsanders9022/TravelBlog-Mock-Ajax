using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public List<PersonExperience> PeopleExperiences { get; set; }

        public Person(string name, int id = 0)
        {
            Name = name;
            PersonId = id;
        }
        public Person() { }
    }
}
