namespace SJBB.Models;
public class Orderline {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public int? BookId { get; set; }
    public virtual Book? Book { get; set; }
    public int? StatueId { get; set; }
    public virtual Statue? Statue { get; set; }
    public int? PictureId { get; set; }
    public virtual Picture? Picture { get; set; }
    public int? MiscellaneousId { get; set; }
    public virtual Miscellaneous? Miscellaneous { get; set; }
}
