using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace baza.Models
{
    public partial class Usr
    {
        public Usr()
        {
            Wastes = new HashSet<Waste>();
            Categories = new HashSet<Category>();
        }
        [Key]
        public long IdUsr { get; set; }
        public string LoginUsr { get; set; } = null!;
        public string PasswordUsr { get; set; } = null!;

        public virtual ICollection<Waste> Wastes { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
