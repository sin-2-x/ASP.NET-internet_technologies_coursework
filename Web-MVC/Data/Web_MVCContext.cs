using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using baza.Models;

namespace Web_MVC.Data {
  public class Web_MVCContext : DbContext {
    public Web_MVCContext(DbContextOptions<Web_MVCContext> options)
        : base(options) {
    }

    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Usr> Usrs { get; set; } = null!;
    public virtual DbSet<Waste> Wastes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Category>(entity => {
        entity.HasKey(e => e.IdCategory);

        entity.ToTable("category");

        entity.Property(e => e.IdCategory)
            .ValueGeneratedNever()
            .HasColumnName("id_category");

        entity.Property(e => e.NameCategory).HasColumnName("name_category");

        entity.Property(e => e.UsedCountCategory).HasColumnName("used_count_category");
        entity.Property(e => e.IdUser).HasColumnName("id_user");

        entity.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.Categories)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("123)))");
      });





      modelBuilder.Entity<NameCode>(entity => {
        entity.HasNoKey();

        entity.ToView("Name_code");

        entity.Property(e => e.Oid)
            .HasColumnType("oid")
            .HasColumnName("oid");

        entity.Property(e => e.Relallvisible).HasColumnName("relallvisible");

        entity.Property(e => e.Relam)
            .HasColumnType("oid")
            .HasColumnName("relam");

        entity.Property(e => e.Relchecks).HasColumnName("relchecks");

        entity.Property(e => e.Relfilenode)
            .HasColumnType("oid")
            .HasColumnName("relfilenode");

        entity.Property(e => e.Relforcerowsecurity).HasColumnName("relforcerowsecurity");

        entity.Property(e => e.Relfrozenxid)
            .HasColumnType("xid")
            .HasColumnName("relfrozenxid");

        entity.Property(e => e.Relhasindex).HasColumnName("relhasindex");

        entity.Property(e => e.Relhasrules).HasColumnName("relhasrules");

        entity.Property(e => e.Relhassubclass).HasColumnName("relhassubclass");

        entity.Property(e => e.Relhastriggers).HasColumnName("relhastriggers");

        entity.Property(e => e.Relispartition).HasColumnName("relispartition");

        entity.Property(e => e.Relispopulated).HasColumnName("relispopulated");

        entity.Property(e => e.Relisshared).HasColumnName("relisshared");

        entity.Property(e => e.Relkind)
            .HasColumnType("char")
            .HasColumnName("relkind");

        entity.Property(e => e.Relminmxid)
            .HasColumnType("xid")
            .HasColumnName("relminmxid");

        entity.Property(e => e.Relnamespace)
            .HasColumnType("oid")
            .HasColumnName("relnamespace");

        entity.Property(e => e.Relnatts).HasColumnName("relnatts");

        entity.Property(e => e.Reloftype)
            .HasColumnType("oid")
            .HasColumnName("reloftype");

        entity.Property(e => e.Reloptions)
            .HasColumnName("reloptions")
            .UseCollation("C");

        entity.Property(e => e.Relowner)
            .HasColumnType("oid")
            .HasColumnName("relowner");

        entity.Property(e => e.Relpages).HasColumnName("relpages");

        entity.Property(e => e.Relpersistence)
            .HasColumnType("char")
            .HasColumnName("relpersistence");

        entity.Property(e => e.Relreplident)
            .HasColumnType("char")
            .HasColumnName("relreplident");

        entity.Property(e => e.Relrewrite)
            .HasColumnType("oid")
            .HasColumnName("relrewrite");

        entity.Property(e => e.Relrowsecurity).HasColumnName("relrowsecurity");

        entity.Property(e => e.Reltablespace)
            .HasColumnType("oid")
            .HasColumnName("reltablespace");

        entity.Property(e => e.Reltoastrelid)
            .HasColumnType("oid")
            .HasColumnName("reltoastrelid");

        entity.Property(e => e.Reltuples).HasColumnName("reltuples");

        entity.Property(e => e.Reltype)
            .HasColumnType("oid")
            .HasColumnName("reltype");
      });

      modelBuilder.Entity<Usr>(entity => {
        entity.HasKey(e => e.IdUsr);

        entity.ToTable("usr");

        entity.HasIndex(e => e.LoginUsr, "login")
            .IsUnique();

        entity.Property(e => e.IdUsr)
            .ValueGeneratedNever()
            .HasColumnName("id_usr");

        entity.Property(e => e.LoginUsr).HasColumnName("login_usr");

        entity.Property(e => e.PasswordUsr).HasColumnName("password_usr");
      });

      modelBuilder.Entity<Waste>(entity => {
        entity.HasKey(e => new { e.IdWaste, e.IdUser });

        entity.ToTable("waste");


        entity.HasIndex(e => e.IdCategory, "presents");

        entity.Property(e => e.IdWaste).HasColumnName("id_waste");

        entity.Property(e => e.IdUser).HasColumnName("id_user");

        entity.Property(e => e.IdCategory).HasColumnName("id_category");

        entity.Property(e => e.Value).HasColumnName("value");

        entity.Property(e => e.Comment).HasColumnName("comment");



        entity.Property(e => e.DayDate).HasColumnName("waste_date");



        entity.HasOne(d => d.IdCategoryNavigation)
            .WithMany(p => p.Wastes)
            .HasForeignKey(d => d.IdCategory)
            .HasConstraintName("presents");



        entity.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.Wastes)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("makes");
      });

      //OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
