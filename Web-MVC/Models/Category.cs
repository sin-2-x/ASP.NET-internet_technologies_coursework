using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace baza.Models
{
    public partial class Category
    {
        public Category()
        {
            Wastes = new HashSet<Waste>();
        }
        [Key]
        public long IdCategory { get; set; }
        public long IdUser { get; set; }

        public string NameCategory { get; set; } = null!;
        public long UsedCountCategory { get; set; }

        public virtual ICollection<Waste> Wastes { get; set; }

        public virtual Usr IdUserNavigation { get; set; } = null!;
    }
}
