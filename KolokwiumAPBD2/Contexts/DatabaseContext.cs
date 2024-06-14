using KolokwiumAPBD2.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD2.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<BackPackSlot> BackPackSlots { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 1,
            Name = "Miecz połksiezyca",
            Weight = 2
        });
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 2,
            Name = "Sierp drwala",
            Weight = 1
        });
        
        modelBuilder.Entity<Title>().HasData(new Title
        {
            TitleId = 1,
            Name = "Rycerz"
        });
        
        modelBuilder.Entity<Title>().HasData(new Title
        {
            TitleId = 2,
            Name = "Mag"
        });
        
        
        modelBuilder.Entity<Character>().HasData(new Character
        {
            CharacterId = 1,
            FirstName = "Gerald",
            LastName = "Z Rivii",
            CurrentWeight = 10,
            MaxWeight = 300,
            Money = 100
        });
        
        modelBuilder.Entity<Character>().HasData(new Character
        {
            CharacterId = 2,
            FirstName = "Szczur",
            LastName = "Mysiur",
            CurrentWeight = 69,
            MaxWeight = 250,
            Money = 200
        });
        
        
        modelBuilder.Entity<BackPackSlot>().HasData(new BackPackSlot
        {
            BackPackSlotId = 1,
            ItemId = 1,
            CharacterId = 1
        });
        
        modelBuilder.Entity<BackPackSlot>().HasData(new BackPackSlot
        {
            BackPackSlotId = 2,
            ItemId = 2,
            CharacterId = 2
        });
        
        
        modelBuilder.Entity<CharacterTitle>().HasData(new CharacterTitle
        {
            CharacterId = 1,
            TitleId = 1,
            AcquiredAt = DateTime.Now
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new CharacterTitle
        {
            CharacterId = 2,
            TitleId = 2,
            AcquiredAt = DateTime.Now
        });
    }
}