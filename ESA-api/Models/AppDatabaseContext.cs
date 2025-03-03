﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESA_api.Models
{
    public partial class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext()
        {
        }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlgorithmCategory> AlgorithmCategory { get; set; }
        public virtual DbSet<AlgorithmTask> AlgorithmTask { get; set; }
        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<BadgeAssignment> BadgeAssignment { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CloudAsset> CloudAsset { get; set; }
        public virtual DbSet<Complexity> Complexity { get; set; }
        public virtual DbSet<CopiedSolution> CopiedSolution { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignment { get; set; }
        public virtual DbSet<CourseEnrolment> CourseEnrolment { get; set; }
        public virtual DbSet<CourseRating> CourseRating { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamResult> ExamResult { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Flashcard> Flashcard { get; set; }
        public virtual DbSet<FlashcardSet> FlashcardSet { get; set; }
        public virtual DbSet<FlashcardSkill> FlashcardSkill { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupAssignment> GroupAssignment { get; set; }
        public virtual DbSet<HomeworkDone> HomeworkDone { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Metrics> Metrics { get; set; }
        public virtual DbSet<MultiSelectQuestion> MultiSelectQuestion { get; set; }
        public virtual DbSet<OrderedBlock> OrderedBlock { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<ServerAsset> ServerAsset { get; set; }
        public virtual DbSet<TaskAssignment> TaskAssignment { get; set; }
        public virtual DbSet<TaskToGroupAssignment> TaskToGroupAssignment { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Verdict> Verdict { get; set; }
        public virtual DbSet<VerificationData> VerificationData { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AlgorithmCategory>(entity =>
            {
                entity.Property(e => e.AlgorithmCategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlgorithmTask>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_ALGORITHMTASK")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.AlgorithmTaskName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TimeLimit).HasColumnType("decimal(18, 9)");

                entity.HasOne(d => d.AlgorithmCategory)
                    .WithMany(p => p.AlgorithmTask)
                    .HasForeignKey(d => d.AlgorithmCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALGORITH_REFERENCE_ALGORITH");

                entity.HasOne(d => d.Complexity)
                    .WithMany(p => p.AlgorithmTask)
                    .HasForeignKey(d => d.ComplexityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALGORITH_REFERENCE_COMPLEXI");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.AlgorithmTask)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALGORITH_REFERENCE_LEVEL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AlgorithmTask)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALGORITH_REFERENCE_USER");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.Property(e => e.BadgeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Badge)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADGE_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<BadgeAssignment>(entity =>
            {
                entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.BadgeAssignment)
                    .HasForeignKey(d => d.BadgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADGEASS_REFERENCE_BADGE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BadgeAssignment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADGEASS_REFERENCE_USER");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CloudAsset>(entity =>
            {
                entity.Property(e => e.AssetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublicId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.CloudAsset)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_CLOUDASS_REFERENCE_LESSON");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CloudAsset)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLOUDASS_REFERENCE_USER");
            });

            modelBuilder.Entity<Complexity>(entity =>
            {
                entity.Property(e => e.ComplexityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CopiedSolution>(entity =>
            {
                

                entity.HasOne(d => d.Verdict)
                    .WithMany(p => p.CopiedSolution)
                    .HasForeignKey(d => d.VerdictId)
                    .HasConstraintName("FK_COPIEDSO_REFERENCE_VERDICT");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseIconUrl)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSE_REFERENCE_CATEGORY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSE_REFERENCE_USER");
            });

            modelBuilder.Entity<CourseAssignment>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseAssignment)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_COURSEAS_REFERENCE_COURSE");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.CourseAssignment)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_COURSEAS_REFERENCE_GROUP");
            });

            modelBuilder.Entity<CourseEnrolment>(entity =>
            {
                entity.Property(e => e.EnrolmentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseEnrolment)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSEEN_REFERENCE_COURSE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseEnrolment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSEEN_REFERENCE_USER");
            });

            modelBuilder.Entity<CourseRating>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseRating)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSERA_REFERENCE_COURSE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseRating)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSERA_REFERENCE_USER");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExamType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_EXAM_REFERENCE_COURSE");
            });

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.Property(e => e.ExamName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mark)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamResult)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAMRESU_REFERENCE_EXAM");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamResult)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAMRESU_REFERENCE_USER");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXPERIEN_REFERENCE_CATEGORY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Experience)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXPERIEN_REFERENCE_USER");
            });

            modelBuilder.Entity<Flashcard>(entity =>
            {
                entity.Property(e => e.Backside)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Frontside)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Hint)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.FlashcardSet)
                    .WithMany(p => p.Flashcard)
                    .HasForeignKey(d => d.FlashcardSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLASHCAR_REFERENCE_FLASHCAR2");
            });

            modelBuilder.Entity<FlashcardSet>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FlashcardSetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.FlashcardSet)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLASHCAR_REFERENCE_COURSE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FlashcardSet)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLASHCAR_USER HAS _USER2");
            });

            modelBuilder.Entity<FlashcardSkill>(entity =>
            {
                entity.HasOne(d => d.Flashcard)
                    .WithMany(p => p.FlashcardSkill)
                    .HasForeignKey(d => d.FlashcardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLASHCAR_FLASHCARD_FLASHCAR");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_GROUP_REFERENCE_USER");
            });

            modelBuilder.Entity<GroupAssignment>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupAssignment)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_GROUPASS_REFERENCE_GROUP");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupAssignment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_GROUPASS_REFERENCE_USER");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.LessonTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LESSON_REFERENCE_COURSE");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.Property(e => e.LevelName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Metrics>(entity =>
            {
                entity.Property(e => e.HalsteadProgramLenght).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HalsteadVocabulary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InteligenceContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LanguageLevel).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProgramDifficulty).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProgramLevel).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProgramVolume).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProgrammingEffort).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProgrammingTime).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Verdict)
                    .WithMany(p => p.Metrics)
                    .HasForeignKey(d => d.VerdictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_METRICS_REFERENCE_VERDICT");
            });

            modelBuilder.Entity<MultiSelectQuestion>(entity =>
            {
                entity.Property(e => e.CorrectAnswer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OptionFour)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OptionOne)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OptionThree)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OptionTwo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.MultiSelectQuestion)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MULTISEL_REFERENCE_EXAM");
            });

            modelBuilder.Entity<OrderedBlock>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                //entity.Property(e => e.Definition)
                //    .IsRequired()
                //    .HasColumnType("text");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.OrderedBlock)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDEREDB_REFERENCE_EXAM");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionContent)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUESTION_REFERENCE_EXAM");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasOne(d => d.AlgorithmTask)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.AlgorithmTaskId)
                    .HasConstraintName("FK_RATING_REFERENCE_ALGORITH");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_RATING_REFERENCE_USER");
            });

            modelBuilder.Entity<ServerAsset>(entity =>
            {
                entity.Property(e => e.ServerAssetName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.ServerAsset)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_SERVERAS_REFERENCE_LESSON");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServerAsset)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVERAS_REFERENCE_USER");
            });

            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TimeToSolveTask).HasColumnType("datetime");

                entity.HasOne(d => d.AlgorithmTask)
                    .WithMany(p => p.TaskAssignment)
                    .HasForeignKey(d => d.AlgorithmTaskId)
                    .HasConstraintName("FK_TASKASSI_REFERENCE_ALGORITH");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TaskAssignment)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_TASKASSI_REFERENCE_USER");
            });

            modelBuilder.Entity<TaskToGroupAssignment>(entity =>
            {
                entity.HasOne(d => d.AlgorithmTask)
                    .WithMany(p => p.TaskToGroupAssignment)
                    .HasForeignKey(d => d.AlgorithmTaskId)
                    .HasConstraintName("FK_TASKTOGR_REFERENCE_ALGORITH");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TaskToGroupAssignment)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_TASKTOGR_REFERENCE_GROUP");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AccountCreationDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Verdict>(entity =>
            {
                entity.Property(e => e.Memory).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Solution).HasColumnType("text");

                entity.Property(e => e.Time).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.VerdictName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlgorithmTask)
                    .WithMany(p => p.Verdict)
                    .HasForeignKey(d => d.AlgorithmTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VERDICT_REFERENCE_ALGORITH");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Verdict)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VERDICT_REFERENCE_USER");
            });

            modelBuilder.Entity<VerificationData>(entity =>
            {
                entity.Property(e => e.InputData)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.OutputData)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.AlgorithmTask)
                    .WithMany(p => p.VerificationData)
                    .HasForeignKey(d => d.AlgorithmTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VERIFICA_REFERENCE_ALGORITH");
            });
        }
    }
}
