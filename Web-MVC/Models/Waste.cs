using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace baza.Models {
  public partial class Waste {
    [Key]
    public long IdWaste { get; set; }
    public long IdUser { get; set; }
    public long IdCategory { get; set; }
    public double Value { get; set; }
    public string? Comment { get; set; } = null!;
    public DateOnly DayDate { get; set; }
    public virtual Category IdCategoryNavigation { get; set; } = null!;
    public virtual Usr IdUserNavigation { get; set; } = null!;
  }
}
