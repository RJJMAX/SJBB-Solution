using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SJBB.Models;
[Index("Username", IsUnique = true)]
public class Employee {
    public int Id { get; set; }
    [StringLength(30)]
    public string Username { get; set; } = string.Empty;
    [StringLength(30)]
    public string Password { get; set; } = string.Empty;
    [StringLength(30)]
    public string Firstname { get; set; } = string.Empty;
    [StringLength(30)]
    public string Lastname { get; set; } = string.Empty;
    [StringLength(20)]
    public string Phone { get; set;} = string.Empty;
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
}
