using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD2.Models;

[Table("Characterss")]
public class Character
{
    [Key]
    [Column("PK")]
    public int CharacterId { get; set; }
    [Column("first_name")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Column("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Column("current_weig")]
    public int CurrentWeight { get; set; }
    [Column("max_weight")]
    public int MaxWeight { get; set; }
    [Column("money")]
    public int Money { get; set; }

    public IEnumerable<BackPackSlot> BackPackSlots { get; set; }
    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}