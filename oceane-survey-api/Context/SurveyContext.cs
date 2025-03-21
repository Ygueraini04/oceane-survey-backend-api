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
    public DbSet<Recipient> Recipients { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<SurveyRecipient> SurveyRecipients { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SurveyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Survey>()
            .Property(s => s.Id)
            .UseIdentityColumn();

        // Configuration de la relation n:m entre Survey et Recipient
        modelBuilder.Entity<SurveyRecipient>()
            .HasKey(sr => new { sr.SurveyId, sr.RecipientId });

        modelBuilder.Entity<SurveyRecipient>()
            .HasOne(sr => sr.Survey)
            .WithMany(s => s.SurveyRecipients)
            .HasForeignKey(sr => sr.SurveyId);

        modelBuilder.Entity<SurveyRecipient>()
            .HasOne(sr => sr.Recipient)
            .WithMany(r => r.SurveyRecipients)
            .HasForeignKey(sr => sr.RecipientId);

        // Configuration de la relation 1:n entre Survey et Question
        modelBuilder.Entity<Question>()
            .HasOne(q => q.Survey)
            .WithMany(s => s.Questions)
            .HasForeignKey(q => q.SurveyId);

        // Configuration de la relation 1:n entre Question et QuestionOption
        modelBuilder.Entity<QuestionOption>()
            .HasOne(qo => qo.Question)
            .WithMany(q => q.QuestionOptions)
            .HasForeignKey(qo => qo.QuestionId);
    }
}

