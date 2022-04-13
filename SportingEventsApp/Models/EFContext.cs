using Microsoft.EntityFrameworkCore;

namespace SportingEventsApp.Models
{
    public class EFContext : DbContext
    {
        private string connectionString;

        public EFContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


        public DbSet<Atleta>? Atletas { get; set; }
        public DbSet<Evento>? Eventos { get; set; }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .ToTable("Eventos")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Evento>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Evento>()
                .Property(p => p.Titulo)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            
            modelBuilder.Entity<Evento>()
                .Property(p => p.Modalidade)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            
            modelBuilder.Entity<Evento>()
                .Property(p => p.TotalParticipantes)
                .HasColumnType("INT")
                .IsRequired();
            
            modelBuilder.Entity<Evento>()
                .Property(p => p.Data)
                .HasColumnType("DATETIME")
                .IsRequired();
            
            modelBuilder.Entity<Evento>()
                .Property(p => p.Local)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .HasMany(p => p.Atletas)
                .WithOne(p => p.Evento)
                .HasConstraintName("FK_Evento_Atleta");



            modelBuilder.Entity<Atleta>()
                .ToTable("Atletas")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Atleta>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Atleta>()
                .Property(p => p.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<Atleta>()
                .Property(p => p.Modalidade)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<Atleta>()
                .Property(p => p.NivelExperiencia)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<Atleta>()
                .Property(p => p.DataConfirmacao)
                .HasColumnType("DATETIME")
                .IsRequired();
        }
    }
}
