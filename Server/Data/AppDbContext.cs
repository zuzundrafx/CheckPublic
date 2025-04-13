using Microsoft.EntityFrameworkCore; // Эта строка должна быть в начале
using Server.Models;

namespace Server.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=ufc_fantasy.db");
}