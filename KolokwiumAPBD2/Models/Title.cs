using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD2.Models;

[Table("Titless")]
public class Title
{
    [Key]
    [Column("PK")]
    public int TitleId { get; set; }
    [Column("nam")]
    [MaxLength(100)]
    public string Name { get; set; }

    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}