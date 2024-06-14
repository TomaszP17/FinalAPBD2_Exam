using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD2.Models;

[Table("Itemss")]
public class Item
{
    [Key]
    [Column("PK")]
    public int ItemId { get; set; }
    [Column("name")]
    [MaxLength(50)]
    public string Name { get; set; }
    [Column("weig")]
    public int Weight { get; set; }

    public IEnumerable<BackPackSlot> BackPackSlots { get; set; }
}