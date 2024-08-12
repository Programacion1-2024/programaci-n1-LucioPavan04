using CEntidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CDatos.Contexts
{
    public partial class LibreriaContext : DbContext
    {
        public LibreriaContext()
        {
        }

        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<AutorLibro> AutorLibro { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Copia> Copia { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<GeneroLibro> GeneroLibro { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=LibreriaProg2024;Integrated Security=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                      .HasName("PK_ID_AUTOR");
                entity.HasMany(e => e.Libros)
                      .WithMany(e => e.Autores)
                      .UsingEntity<AutorLibro>(
                        l => l.HasOne<Libro>().WithMany().HasForeignKey(e => e.IdLibro),
                        a => a.HasOne<Autor>().WithMany().HasForeignKey(e => e.IdAutor)
                       );
            });

            modelBuilder.Entity<AutorLibro>(entity =>
            {
                entity.HasKey(e => e.IdAutorLibro)
                      .HasName("PK_ID_AUTORLIBRO");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                      .HasName("PK_ID_CLIENTE");
                entity.HasMany(e => e.Prestamos)
                      .WithOne(e => e.Cliente)
                      .HasForeignKey("IdCliente")
                      .IsRequired();
                entity.HasMany(e => e.Ventas)
                      .WithOne(e => e.Cliente)
                      .HasForeignKey("IdCliente")
                      .IsRequired();
            });

            modelBuilder.Entity<Copia>(entity =>
            {
                entity.HasKey(e => e.IdCopia)
                    .HasName("PK_ID_COPIA");
                entity.HasMany(e => e.Prestamos)
                      .WithOne(e => e.Copia)
                      .HasForeignKey("IdCopia")
                      .IsRequired();
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                      .HasName("PK_ID_EDITORIAL");
                entity.HasMany(e => e.Libros)
                      .WithOne(e => e.Editorial)
                      .HasForeignKey("IdEditorial")
                      .IsRequired();
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                      .HasName("PK_ID_EMPLEADO");
                entity.HasMany(e => e.Ventas)
                      .WithOne(e => e.Empleado)
                      .HasForeignKey("IdEmpleado")
                      .IsRequired();
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                      .HasName("PK_ID_FORMAPAGO");
                entity.HasMany(e => e.Prestamos)
                      .WithOne(e => e.FormaPago)
                      .HasForeignKey("IdFormaPago")
                      .IsRequired();
                entity.HasMany(e => e.Ventas)
                      .WithOne(e => e.FormaPago)
                      .HasForeignKey("IdFormaPago")
                      .IsRequired();
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK_ID_GENERO");
                entity.HasMany(e => e.Libros)
                      .WithMany(e => e.Generos)
                      .UsingEntity<GeneroLibro>(
                        l => l.HasOne<Libro>().WithMany().HasForeignKey(e => e.IdLibro),
                        a => a.HasOne<Genero>().WithMany().HasForeignKey(e => e.IdGenero)
                      );

            });

            modelBuilder.Entity<GeneroLibro>(entity =>
            {
                entity.HasKey(e => e.IdGeneroLibro)
                    .HasName("PK_ID_GENEROLIBRO");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK_ID_LIBRO");
                entity.HasMany(e => e.Copias)
                      .WithOne(e => e.Libro)
                      .HasForeignKey("IdLibro")
                      .IsRequired();
                entity.HasMany(e => e.Ventas)
                      .WithOne(e => e.Libro)
                      .HasForeignKey("IdLibro")
                      .IsRequired();
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                      .HasName("PK_ID_PERSONA");
                entity.HasOne(e => e.Autor)
                      .WithOne(e => e.Persona)
                      .HasForeignKey<Autor>("IdPersona")
                      .IsRequired(false);
                entity.HasOne(e => e.Cliente)
                      .WithOne(e => e.Persona)
                      .HasForeignKey<Cliente>("IdPersona")
                      .IsRequired(false);
                entity.HasOne(e => e.Empleado)
                      .WithOne(e => e.Persona)
                      .HasForeignKey<Empleado>("IdPersona")
                      .IsRequired(false);
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK_ID_PRESTAMO");

            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK_ID_VENTA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
