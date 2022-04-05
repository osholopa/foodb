using FoodbWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodbWebAPI.Data
{
  public class FooDBContext : DbContext
  {
    public FooDBContext(DbContextOptions<FooDBContext> opt) : base(opt) 
    {

    }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<User> Users { get; set; }

    

  }
}