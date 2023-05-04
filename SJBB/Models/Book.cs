using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SJBB.Models; 
public class Book {
    public int Id { get; set; }
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;
    [StringLength(30)]
    public string? Author { get; set; } = string.Empty;
    public  int? PrintYear { get; set; }
    [Column(TypeName = "decimal(11,2)")]
    public decimal Price { get; set; }
    public int VendorId { get; set; }
    public virtual Vendor? Vendor { get; set; }
}
