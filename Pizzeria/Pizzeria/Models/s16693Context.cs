using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s16693Context : DbContext
    {
        public s16693Context()
        {
        }

        public s16693Context(DbContextOptions<s16693Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<Dostawa> Dostawa { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Nowosc> Nowosc { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Platnosc> Platnosc { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<SkladPizzy> SkladPizzy { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Wykonanie> Wykonanie { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<Zestaw> Zestaw { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16693;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.HasKey(e => e.IdProdukt)
                    .HasName("Dodatek_pk");

                entity.Property(e => e.IdProdukt).ValueGeneratedNever();

                entity.Property(e => e.RodzajDodatku)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProduktNavigation)
                    .WithOne(p => p.Dodatek)
                    .HasForeignKey<Dodatek>(d => d.IdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dodatek_Produkt");
            });

            modelBuilder.Entity<Dostawa>(entity =>
            {
                entity.HasKey(e => new { e.IdPracownik, e.IdZamowienia, e.StartDostawy })
                    .HasName("Dostawa_pk");

                entity.Property(e => e.StartDostawy).HasColumnType("datetime");

                entity.Property(e => e.KoniecDostawy).HasColumnType("datetime");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Dostawa)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_19_Pracownik");

                entity.HasOne(d => d.IdZamowieniaNavigation)
                    .WithMany(p => p.Dostawa)
                    .HasForeignKey(d => d.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_19_Zamowienie");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NrTelefonu)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nowosc>(entity =>
            {
                entity.HasKey(e => e.IdNowosc)
                    .HasName("Nowosc_pk");

                entity.Property(e => e.IdNowosc).ValueGeneratedNever();

                entity.Property(e => e.DoKiedy).HasColumnType("date");

                entity.Property(e => e.OdKiedy).HasColumnType("date");

                entity.Property(e => e.ProduktIdProdukt).HasColumnName("Produkt_IdProdukt");

                entity.HasOne(d => d.ProduktIdProduktNavigation)
                    .WithMany(p => p.Nowosc)
                    .HasForeignKey(d => d.ProduktIdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Nowosc_Produkt");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdProdukt)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdProdukt).ValueGeneratedNever();

                entity.Property(e => e.Rozmiar)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProduktNavigation)
                    .WithOne(p => p.Pizza)
                    .HasForeignKey<Pizza>(d => d.IdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Produkt");
            });

            modelBuilder.Entity<Platnosc>(entity =>
            {
                entity.HasKey(e => e.IdPlatnosc)
                    .HasName("Platnosc_pk");

                entity.Property(e => e.IdPlatnosc).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.DataUrodzenia).HasColumnType("date");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasKey(e => e.IdProdukt)
                    .HasName("Produkt_pk");

                entity.Property(e => e.IdProdukt).ValueGeneratedNever();
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocja).ValueGeneratedNever();

                entity.Property(e => e.DoKiedy).HasColumnType("date");

                entity.Property(e => e.NazwaPromocja)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OdKiedy).HasColumnType("date");

                entity.Property(e => e.ProduktIdProdukt).HasColumnName("Produkt_IdProdukt");

                entity.HasOne(d => d.ProduktIdProduktNavigation)
                    .WithMany(p => p.Promocja)
                    .HasForeignKey(d => d.ProduktIdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_Produkt");
            });

            modelBuilder.Entity<SkladPizzy>(entity =>
            {
                entity.HasKey(e => new { e.IdProdukt, e.IdSkladnik, e.IloscSkladnikow })
                    .HasName("SkladPizzy_pk");

                entity.HasOne(d => d.IdProduktNavigation)
                    .WithMany(p => p.SkladPizzy)
                    .HasForeignKey(d => d.IdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SkladPizzy_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.SkladPizzy)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnik_Skladnik");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wykonanie>(entity =>
            {
                entity.HasKey(e => e.IdWykonanie)
                    .HasName("Wykonanie_pk");

                entity.Property(e => e.IdWykonanie).ValueGeneratedNever();

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Wykonanie)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PracownikZamowienie_Pracownik");

                entity.HasOne(d => d.IdZamowieniaNavigation)
                    .WithMany(p => p.Wykonanie)
                    .HasForeignKey(d => d.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PracownikZamowienie_Zamowienie");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienia).ValueGeneratedNever();

                entity.Property(e => e.AdresZamowienia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrzyjecieZamowienia).HasColumnType("datetime");

                entity.Property(e => e.Stan)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");

                entity.HasOne(d => d.IdPlatnoscNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPlatnosc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Platnosc");

                entity.HasOne(d => d.IdPromocjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPromocja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Promocja");
            });

            modelBuilder.Entity<Zestaw>(entity =>
            {
                entity.HasKey(e => e.IdZestaw)
                    .HasName("Zestaw_pk");

                entity.Property(e => e.IdZestaw).ValueGeneratedNever();

                entity.HasOne(d => d.IdProduktNavigation)
                    .WithMany(p => p.Zestaw)
                    .HasForeignKey(d => d.IdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProduktZamowienie_Produkt");

                entity.HasOne(d => d.IdZamowieniaNavigation)
                    .WithMany(p => p.Zestaw)
                    .HasForeignKey(d => d.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProduktZamowienie_Zamowienie");
            });
        }
    }
}
