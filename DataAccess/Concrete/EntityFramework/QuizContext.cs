using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAccess.Concrete.EntityFramework
{
  public class QuizContext : DbContext
  {


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // var copyPath = @$"{Directory.GetCurrentDirectory()}\DB\QuizDb.db";
      var path = Path.Combine(Path.GetFullPath(@"..\DataAccess\"), "DB");

      path = (path + @"\QuizDB.db;");

      optionsBuilder.UseSqlite($@"Filename={path}");

    }

    public DbSet<User> User { get; set; }
    public DbSet<Content> Content { get; set; }
    public DbSet<Quiz> Quiz { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Option> Option { get; set; }
    public DbSet<UserAnswer> UserAnswer { get; set; }
  }
}
