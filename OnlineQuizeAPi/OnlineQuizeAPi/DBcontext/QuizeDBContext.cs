
using Microsoft.EntityFrameworkCore;
namespace OnlineQuizeAPi.DBcontext
{
    public partial class QuizeDBContext : DbContext
    {
      
        public QuizeDBContext()
        {
           
        }
        public QuizeDBContext(DbContextOptions<QuizeDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Answertext)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("answertext");

                entity.Property(e => e.Questionid).HasColumnName("questionid");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("categoryname");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Optionid)
                    .HasColumnName("optionid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Optionname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("optionname");

                entity.Property(e => e.Questionid).HasColumnName("questionid");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Questionid)
                    .HasColumnName("questionid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Questionname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("questionname");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
