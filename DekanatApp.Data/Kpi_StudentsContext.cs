using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DekanatApp.Data
{
    public partial class Kpi_StudentsContext : DbContext
    {
        public virtual DbSet<Cafedra> Cafedras { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Scitizen> Scitizens { get; set; }
        public virtual DbSet<ScontractKind> ScontractKinds { get; set; }
        public virtual DbSet<Sdiploma> Sdiplomas { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Sfinance> Sfinances { get; set; }
        public virtual DbSet<SlessonKind> SlessonKinds { get; set; }
        public virtual DbSet<Smark> Smarks { get; set; }
        public virtual DbSet<Snation> Snations { get; set; }
        public virtual DbSet<SorderKind> SorderKinds { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Sprivilege> Sprivileges { get; set; }
        public virtual DbSet<SpunishKind> SpunishKinds { get; set; }
        public virtual DbSet<Ssocial> Ssocials { get; set; }
        public virtual DbSet<Sspecializ> Sspecializs { get; set; }
        public virtual DbSet<Sstatu> Sstatus { get; set; }
        public virtual DbSet<StestKind> StestKinds { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SviolationKind> SviolationKinds { get; set; }
        public virtual DbSet<TeachPlan> TeachPlans { get; set; }
        public virtual DbSet<Violation> Violations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=scp.realhost.com.ua;Initial Catalog=kpi_students;Persist Security Info=True;User ID=fedirpetrenko;Password=wtkcunifm1ghrdpyqzxe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "fedirpetrenko");

            modelBuilder.Entity<Cafedra>(entity =>
            {
                entity.ToTable("CAFEDRA");

                entity.Property(e => e.CafedraId).HasColumnName("Cafedra_ID");

                entity.Property(e => e.CafedraName)
                    .IsRequired()
                    .HasColumnName("Cafedra_name")
                    .HasMaxLength(200);

                entity.Property(e => e.CafedraShifr)
                    .IsRequired()
                    .HasColumnName("Cafedra_shifr")
                    .HasMaxLength(50);

                entity.Property(e => e.FacultyId).HasColumnName("Faculty_ID");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Cafedras)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CAFEDRA__Faculty__1FCDBCEB");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("CONTRACT");

                entity.Property(e => e.ContractId).HasColumnName("Contract_ID");

                entity.Property(e => e.ContractDate)
                    .HasColumnName("Contract_date")
                    .HasColumnType("date");

                entity.Property(e => e.ContractKindId).HasColumnName("Contract_kind_ID");

                entity.Property(e => e.ContractNo).HasColumnName("Contract_no");

                entity.Property(e => e.ContractSum).HasColumnName("Contract_sum");

                entity.Property(e => e.PayerKind)
                    .IsRequired()
                    .HasColumnName("Payer_kind")
                    .HasMaxLength(100);

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONTRACT__Studen__440B1D61");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("FACULTY");

                entity.Property(e => e.FacultyId).HasColumnName("Faculty_ID");

                entity.Property(e => e.FacultyName)
                    .IsRequired()
                    .HasColumnName("Faculty_name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("GROUPS");

                entity.Property(e => e.GroupId).HasColumnName("Group_ID");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasColumnName("Group_code")
                    .HasMaxLength(50);

                entity.Property(e => e.GroupCreatDate)
                    .HasColumnName("Group_creat_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.SpecialityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GROUPS__Speciali__25869641");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderKindId).HasColumnName("Order_kind_ID");

                entity.Property(e => e.OrderNo).HasColumnName("Order_no");

                entity.Property(e => e.OrderText).HasColumnName("Order_text");

                entity.HasOne(d => d.OrderKind)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderKindId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDERS__Order_ki__35BCFE0A");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENT");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");

                entity.Property(e => e.ContractId).HasColumnName("Contract_ID");

                entity.Property(e => e.DocumentNo).HasColumnName("Document_no");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("Payment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentSum).HasColumnName("Payment_sum");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PAYMENT__Contrac__46E78A0C");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("PERSON");

                entity.HasIndex(e => e.StudentId)
                    .HasName("UQ__PERSON__A2F4E9ADE94FE9A2")
                    .IsUnique();

                entity.Property(e => e.PersonId).HasColumnName("Person_ID");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.BirthPlace).HasColumnName("Birth_place");

                entity.Property(e => e.CitizenId).HasColumnName("Citizen_ID");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.NationId).HasColumnName("Nation_ID");

                entity.Property(e => e.Patronymic).HasMaxLength(200);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SocialId).HasColumnName("Social_ID");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.Property(e => e.Surname).HasMaxLength(200);

                entity.Property(e => e.Telephon).HasMaxLength(50);

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.CitizenId)
                    .HasConstraintName("FK__PERSON__Citizen___4F7CD00D");

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.NationId)
                    .HasConstraintName("FK__PERSON__Nation_I__4E88ABD4");

                entity.HasOne(d => d.Social)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.SocialId)
                    .HasConstraintName("FK__PERSON__Social_I__5070F446");

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.StudentId)
                    .HasConstraintName("FK__PERSON__Student___4D94879B");
            });

            modelBuilder.Entity<Scitizen>(entity =>
            {
                entity.HasKey(e => e.CitizenId);

                entity.ToTable("SCITIZEN");

                entity.Property(e => e.CitizenId).HasColumnName("Citizen_ID");

                entity.Property(e => e.CitizenName)
                    .IsRequired()
                    .HasColumnName("Citizen_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ScontractKind>(entity =>
            {
                entity.HasKey(e => e.ContractKindId);

                entity.ToTable("SCONTRACT_KIND");

                entity.Property(e => e.ContractKindId).HasColumnName("Contract_kind_ID");

                entity.Property(e => e.ContractKindName)
                    .IsRequired()
                    .HasColumnName("Contract_kind_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sdiploma>(entity =>
            {
                entity.HasKey(e => e.DiplomaId);

                entity.ToTable("SDIPLOMA");

                entity.Property(e => e.DiplomaId).HasColumnName("Diploma_ID");

                entity.Property(e => e.DiplomaName)
                    .IsRequired()
                    .HasColumnName("Diploma_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("SEMESTER");

                entity.Property(e => e.SemesterId).HasColumnName("Semester_ID");

                entity.Property(e => e.Attest1Date)
                    .HasColumnName("Attest1_date")
                    .HasColumnType("date");

                entity.Property(e => e.Attest2Date)
                    .HasColumnName("Attest2_date")
                    .HasColumnType("date");

                entity.Property(e => e.SessionBeginDate)
                    .HasColumnName("Session_begin_date")
                    .HasColumnType("date");

                entity.Property(e => e.SessionEndDate)
                    .HasColumnName("Session_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.TeachBeginDate)
                    .HasColumnName("Teach_begin_date")
                    .HasColumnType("date");

                entity.Property(e => e.TeachEndDate)
                    .HasColumnName("Teach_end_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Sfinance>(entity =>
            {
                entity.HasKey(e => e.FinanceId);

                entity.ToTable("SFINANCE");

                entity.Property(e => e.FinanceId).HasColumnName("Finance_ID");

                entity.Property(e => e.FinanceName)
                    .IsRequired()
                    .HasColumnName("Finance_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SlessonKind>(entity =>
            {
                entity.HasKey(e => e.LessonKindId);

                entity.ToTable("SLESSON_KIND");

                entity.Property(e => e.LessonKindId).HasColumnName("Lesson_kind_ID");

                entity.Property(e => e.LessonKindName)
                    .IsRequired()
                    .HasColumnName("Lesson_kind_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Smark>(entity =>
            {
                entity.HasKey(e => e.MarkId);

                entity.ToTable("SMARK");

                entity.Property(e => e.MarkId).HasColumnName("Mark_ID");

                entity.Property(e => e.MarkName)
                    .HasColumnName("Mark_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Snation>(entity =>
            {
                entity.HasKey(e => e.NationId);

                entity.ToTable("SNATION");

                entity.Property(e => e.NationId).HasColumnName("Nation_ID");

                entity.Property(e => e.NationName)
                    .IsRequired()
                    .HasColumnName("Nation_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SorderKind>(entity =>
            {
                entity.HasKey(e => e.OrderKindId);

                entity.ToTable("SORDER_KIND");

                entity.Property(e => e.OrderKindId).HasColumnName("Order_kind_ID");

                entity.Property(e => e.OrderKindName)
                    .IsRequired()
                    .HasColumnName("Order_kind_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("SPECIALITY");

                entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");

                entity.Property(e => e.CafedraId).HasColumnName("Cafedra_ID");

                entity.Property(e => e.SpecialityName)
                    .IsRequired()
                    .HasColumnName("Speciality_name")
                    .HasMaxLength(200);

                entity.Property(e => e.SpecialityShifr)
                    .IsRequired()
                    .HasColumnName("Speciality_shifr")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Cafedra)
                    .WithMany(p => p.Specialities)
                    .HasForeignKey(d => d.CafedraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SPECIALIT__Cafed__22AA2996");
            });

            modelBuilder.Entity<Sprivilege>(entity =>
            {
                entity.HasKey(e => e.PrivilegeId);

                entity.ToTable("SPRIVILEGE");

                entity.Property(e => e.PrivilegeId).HasColumnName("Privilege_ID");

                entity.Property(e => e.PrivilegeName)
                    .IsRequired()
                    .HasColumnName("Privilege_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SpunishKind>(entity =>
            {
                entity.HasKey(e => e.PunishKindId);

                entity.ToTable("SPUNISH_KIND");

                entity.Property(e => e.PunishKindId).HasColumnName("Punish_kind_ID");

                entity.Property(e => e.PunishKindName)
                    .IsRequired()
                    .HasColumnName("Punish_kind_name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Ssocial>(entity =>
            {
                entity.HasKey(e => e.SocialId);

                entity.ToTable("SSOCIAL");

                entity.Property(e => e.SocialId).HasColumnName("Social_ID");

                entity.Property(e => e.SocialName)
                    .IsRequired()
                    .HasColumnName("Social_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sspecializ>(entity =>
            {
                entity.HasKey(e => e.SpecializId);

                entity.ToTable("SSPECIALIZ");

                entity.Property(e => e.SpecializId).HasColumnName("Specializ_ID");

                entity.Property(e => e.SpecializName)
                    .IsRequired()
                    .HasColumnName("Specializ_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sstatu>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("SSTATUS");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("Status_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StestKind>(entity =>
            {
                entity.HasKey(e => e.TestKindId);

                entity.ToTable("STEST_KIND");

                entity.Property(e => e.TestKindId).HasColumnName("Test_kind_ID");

                entity.Property(e => e.TestKindName)
                    .IsRequired()
                    .HasColumnName("Test_kind_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.Property(e => e.BookNo)
                    .HasColumnName("Book_no")
                    .HasMaxLength(200);

                entity.Property(e => e.DiplomaId).HasColumnName("Diploma_ID");

                entity.Property(e => e.FinanceId).HasColumnName("Finance_ID");

                entity.Property(e => e.SpecializId).HasColumnName("Specializ_ID");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.Diploma)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DiplomaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STUDENT__Diploma__403A8C7D");

                entity.HasOne(d => d.Finance)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FinanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STUDENT__Finance__3E52440B");

                entity.HasOne(d => d.Specializ)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SpecializId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STUDENT__Special__412EB0B6");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STUDENT__Status___3F466844");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("SUBJECT");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_ID");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("Subject_name")
                    .HasMaxLength(100);

                entity.Property(e => e.SubjectShifr)
                    .IsRequired()
                    .HasColumnName("Subject_shifr")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SviolationKind>(entity =>
            {
                entity.HasKey(e => e.ViolationKindId);

                entity.ToTable("SVIOLATION_KIND");

                entity.Property(e => e.ViolationKindId).HasColumnName("Violation_kind_ID");

                entity.Property(e => e.ViolationKindName)
                    .IsRequired()
                    .HasColumnName("Violation_kind_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TeachPlan>(entity =>
            {
                entity.ToTable("TEACH_PLAN");

                entity.Property(e => e.TeachPlanId).HasColumnName("Teach_plan_ID");

                entity.Property(e => e.GroupId).HasColumnName("Group_ID");

                entity.Property(e => e.IsObligatory)
                    .IsRequired()
                    .HasColumnName("Is_obligatory")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SemesterId).HasColumnName("Semester_ID");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_ID");

                entity.Property(e => e.TestDate)
                    .HasColumnName("Test_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TestKindId).HasColumnName("Test_kind_ID");

                entity.Property(e => e.TesterId).HasColumnName("Tester_ID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TeachPlans)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEACH_PLA__Group__5DCAEF64");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.TeachPlans)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEACH_PLA__Semes__5CD6CB2B");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeachPlans)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEACH_PLA__Subje__5EBF139D");

                entity.HasOne(d => d.TestKind)
                    .WithMany(p => p.TeachPlans)
                    .HasForeignKey(d => d.TestKindId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEACH_PLA__Test___60A75C0F");

                entity.HasOne(d => d.Tester)
                    .WithMany(p => p.TeachPlans)
                    .HasForeignKey(d => d.TesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEACH_PLA__Teste__5FB337D6");
            });

            modelBuilder.Entity<Violation>(entity =>
            {
                entity.ToTable("VIOLATION");

                entity.Property(e => e.ViolationId).HasColumnName("Violation_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.PersonId).HasColumnName("Person_ID");

                entity.Property(e => e.PunishKindId).HasColumnName("Punish_kind_ID");

                entity.Property(e => e.ViolationDate)
                    .HasColumnName("Violation_date")
                    .HasColumnType("date");

                entity.Property(e => e.ViolationKindId).HasColumnName("Violation_kind_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__VIOLATION__Order__5629CD9C");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VIOLATION__Perso__5535A963");

                entity.HasOne(d => d.PunishKind)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.PunishKindId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VIOLATION__Punis__5441852A");

                entity.HasOne(d => d.ViolationKind)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.ViolationKindId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VIOLATION__Viola__534D60F1");
            });
        }
    }
}
