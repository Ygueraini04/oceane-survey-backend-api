using Microsoft.EntityFrameworkCore;
using oceane_survey_api.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

public class SurveyContext : DbContext
{
    public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
    {
    }

    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<Recipient> Recipients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //// Relation Survey → Questions (OneToMany)
        //modelBuilder.Entity<Question>()
        //    .HasOne(q => q.Survey)
        //    .WithMany(s => s.Questions)
        //    .HasForeignKey(q => q.SurveyId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //// Relation Question → Options (OneToMany)
        //modelBuilder.Entity<QuestionOption>()
        //    .HasOne(o => o.Question)
        //    .WithMany(q => q.QuestionOptions)
        //    .HasForeignKey(o => o.QuestionId)
        //    .OnDelete(DeleteBehavior.Cascade);

        // Enumérations sont stockées sous forme de string (optionnel)
        modelBuilder.Entity<Survey>().Property(s => s.Status).HasConversion<string>();
        modelBuilder.Entity<Question>().Property(q => q.Type).HasConversion<string>();
        modelBuilder.Entity<Recipient>().Property(r => r.Type).HasConversion<string>();
    }
}

