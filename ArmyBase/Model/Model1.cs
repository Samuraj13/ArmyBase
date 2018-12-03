namespace ArmyBase.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=GiRDatabase")
        {
        }

        public virtual DbSet<BARAK> BARAK { get; set; }
        public virtual DbSet<DRUZYNA> DRUZYNA { get; set; }
        public virtual DbSet<MISJA> MISJA { get; set; }
        public virtual DbSet<PRACOWNIK> PRACOWNIK { get; set; }
        public virtual DbSet<SPECJALIZACJA> SPECJALIZACJA { get; set; }
        public virtual DbSet<SPRZET> SPRZET { get; set; }
        public virtual DbSet<STOPIEN> STOPIEN { get; set; }
        public virtual DbSet<TYPBRONI> TYPBRONI { get; set; }
        public virtual DbSet<TYPDRUZYNY> TYPDRUZYNY { get; set; }
        public virtual DbSet<TYPMISJI> TYPMISJI { get; set; }
        public virtual DbSet<UPRAWNIENIE> UPRAWNIENIE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BARAK>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<BARAK>()
                .Property(e => e.NAZWA)
                .IsUnicode(false);

            modelBuilder.Entity<BARAK>()
                .Property(e => e.POJEMNOSC)
                .HasPrecision(10, 0);

            modelBuilder.Entity<BARAK>()
                .Property(e => e.ZARZADCA)
                .HasPrecision(10, 0);

            modelBuilder.Entity<BARAK>()
                .HasMany(e => e.PRACOWNIK1)
                .WithOptional(e => e.BARAK2)
                .HasForeignKey(e => e.BARAK);

            modelBuilder.Entity<DRUZYNA>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<DRUZYNA>()
                .Property(e => e.DRUZYNA1)
                .IsUnicode(false);

            modelBuilder.Entity<DRUZYNA>()
                .Property(e => e.DOWODCA)
                .HasPrecision(10, 0);

            modelBuilder.Entity<DRUZYNA>()
                .Property(e => e.TYP)
                .HasPrecision(10, 0);

            modelBuilder.Entity<DRUZYNA>()
                .Property(e => e.OBOWIAZKI)
                .IsUnicode(false);

            modelBuilder.Entity<DRUZYNA>()
                .HasMany(e => e.MISJA)
                .WithOptional(e => e.DRUZYNA1)
                .HasForeignKey(e => e.DRUZYNA);

            modelBuilder.Entity<DRUZYNA>()
                .HasMany(e => e.PRACOWNIK1)
                .WithOptional(e => e.DRUZYNA2)
                .HasForeignKey(e => e.DRUZYNA);

            modelBuilder.Entity<MISJA>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MISJA>()
                .Property(e => e.NAZWA)
                .IsUnicode(false);

            modelBuilder.Entity<MISJA>()
                .Property(e => e.TYPMISJI)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MISJA>()
                .Property(e => e.DRUZYNA)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.PESEL)
                .HasPrecision(11, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.IMIE)
                .IsUnicode(false);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.NAZWISKO)
                .IsUnicode(false);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.ZAROBKI)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.SPECJALIZACJA)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.STOPIEN)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.DRUZYNA)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .Property(e => e.BARAK)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PRACOWNIK>()
                .HasMany(e => e.BARAK1)
                .WithRequired(e => e.PRACOWNIK)
                .HasForeignKey(e => e.ZARZADCA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRACOWNIK>()
                .HasMany(e => e.DRUZYNA1)
                .WithRequired(e => e.PRACOWNIK)
                .HasForeignKey(e => e.DOWODCA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPECJALIZACJA>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SPECJALIZACJA>()
                .Property(e => e.SPECJALIZACJA1)
                .IsUnicode(false);

            modelBuilder.Entity<SPECJALIZACJA>()
                .Property(e => e.BRON)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SPECJALIZACJA>()
                .Property(e => e.UPRAWNIENIE)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SPECJALIZACJA>()
                .HasMany(e => e.PRACOWNIK)
                .WithOptional(e => e.SPECJALIZACJA1)
                .HasForeignKey(e => e.SPECJALIZACJA);

            modelBuilder.Entity<SPRZET>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SPRZET>()
                .Property(e => e.NAZWA)
                .IsUnicode(false);

            modelBuilder.Entity<SPRZET>()
                .Property(e => e.TYPBRONI)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SPRZET>()
                .Property(e => e.ILOSC)
                .HasPrecision(10, 0);

            modelBuilder.Entity<SPRZET>()
                .HasMany(e => e.SPECJALIZACJA)
                .WithOptional(e => e.SPRZET)
                .HasForeignKey(e => e.BRON);

            modelBuilder.Entity<STOPIEN>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<STOPIEN>()
                .Property(e => e.STOPIEN1)
                .IsUnicode(false);

            modelBuilder.Entity<STOPIEN>()
                .Property(e => e.MINSTAZ)
                .HasPrecision(10, 0);

            modelBuilder.Entity<STOPIEN>()
                .Property(e => e.DODATEK)
                .HasPrecision(10, 0);

            modelBuilder.Entity<STOPIEN>()
                .HasMany(e => e.PRACOWNIK)
                .WithRequired(e => e.STOPIEN1)
                .HasForeignKey(e => e.STOPIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STOPIEN>()
                .HasMany(e => e.UPRAWNIENIE)
                .WithRequired(e => e.STOPIEN)
                .HasForeignKey(e => e.MINSTOPIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TYPBRONI>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<TYPBRONI>()
                .Property(e => e.TYP)
                .IsUnicode(false);

            modelBuilder.Entity<TYPBRONI>()
                .HasMany(e => e.SPRZET)
                .WithOptional(e => e.TYPBRONI1)
                .HasForeignKey(e => e.TYPBRONI);

            modelBuilder.Entity<TYPDRUZYNY>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<TYPDRUZYNY>()
                .Property(e => e.TYP)
                .IsUnicode(false);

            modelBuilder.Entity<TYPDRUZYNY>()
                .HasMany(e => e.DRUZYNA)
                .WithRequired(e => e.TYPDRUZYNY)
                .HasForeignKey(e => e.TYP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TYPMISJI>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<TYPMISJI>()
                .Property(e => e.TYP)
                .IsUnicode(false);

            modelBuilder.Entity<TYPMISJI>()
                .HasMany(e => e.MISJA)
                .WithRequired(e => e.TYPMISJI1)
                .HasForeignKey(e => e.TYPMISJI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UPRAWNIENIE>()
                .Property(e => e.ID)
                .HasPrecision(10, 0);

            modelBuilder.Entity<UPRAWNIENIE>()
                .Property(e => e.OPIS)
                .IsUnicode(false);

            modelBuilder.Entity<UPRAWNIENIE>()
                .Property(e => e.MINSTOPIEN)
                .HasPrecision(10, 0);

            modelBuilder.Entity<UPRAWNIENIE>()
                .HasMany(e => e.SPECJALIZACJA)
                .WithOptional(e => e.UPRAWNIENIE1)
                .HasForeignKey(e => e.UPRAWNIENIE);
        }
    }
}
