using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD2.Models;

[Table("Characters_Titless")]
[PrimaryKey("CharacterId", "TitleId")]
public class CharacterTitle
{
    [ForeignKey("Character")]
    [Column("FK_charact")]
    public int CharacterId { get; set; }
    [ForeignKey("Title")]
    [Column("FK_title")]
    public int TitleId { get; set; }
    [Column("aquire_at")]
    public DateTime AcquiredAt { get; set; }

    public Character Character { get; set; }
    public Title Title { get; set; }
}