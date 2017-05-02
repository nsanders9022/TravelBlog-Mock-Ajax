using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("Locations")]
    public class Location
    {
        public Location()
        {
            this.Experiences = new HashSet<Experience>();
        }
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

        public override bool Equals(System.Object otherItem)
        {
            if (!(otherItem is Location))
            {
                return false;
            }
            else
            {
                Location newItem = (Location)otherItem;
                return this.LocationId.Equals(newItem.LocationId);
            }
        }

        public override int GetHashCode()
        {
            return this.LocationId.GetHashCode();
        }
    }
}
