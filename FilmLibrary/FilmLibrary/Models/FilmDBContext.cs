using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FilmLibrary.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Film> Films { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FilmDatabase;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasKey(f => f.Id);
        modelBuilder.Entity<Film>().HasKey(f => f.Id);
    }
}