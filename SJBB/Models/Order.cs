using System.ComponentModel.DataAnnotations.Schema;

namespace SJBB.Models; 
public class Order {
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public int ProductId { get; set; }
    [Column(TypeName = "decimal(11,2)")]
    public decimal Total { get; set; }
}
