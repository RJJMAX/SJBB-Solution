using System.ComponentModel.DataAnnotations;

namespace SJBB.Models; 
public class Vendor {
    public int Id { get; set; }
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;
    [StringLength(30)]
    public string? Address { get; set; } = string.Empty;
    [StringLength(30)]
    public string? City { get; set; } = string.Empty;
    [StringLength(2)]
    public string? StateCode { get; set; } = string.Empty;
    [StringLength(30)]
    public string? Region { get; set; } = string.Empty;
    [StringLength(30)]
    public string? PostalCode { get; set; } = string.Empty;
    [StringLength(30)]
    public string? Country { get; set; } = string.Empty;
    [StringLength(5000)]
    public string? Description { get; set; } = string.Empty;
    [StringLength(20)]
    public string? Phone { get; set; } = string.Empty;
    [StringLength(50)]
    public string? Email { get; set; } = string.Empty;

}
