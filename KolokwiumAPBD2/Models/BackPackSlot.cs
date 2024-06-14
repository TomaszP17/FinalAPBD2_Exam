using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD2.Models;

[Table("Backpack_Slotss")]
public class BackPackSlot
{
    [Key]
    [Column("PK")]
    public int BackPackSlotId { get; set; }
    [Column("FK_item")]
    [ForeignKey("Item")]
    public int ItemId { get; set; }
    [Column("FK_character")]
    [ForeignKey("Character")]
    public int CharacterId { get; set; }

    public Item Item { get; set; }
    public Character Character { get; set; }
}