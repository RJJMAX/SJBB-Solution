using System.ComponentModel.DataAnnotations.Schema;

namespace SJBB.Models; 
public class Order {
    public int Id { get; set; }
    [Column(TypeName = "decimal(11,2)")]
    public decimal Total { get; set; }
    DateOnly DateOnly { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Orderline>? Orderlines { get; set; }
}
