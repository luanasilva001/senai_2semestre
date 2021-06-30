using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_wishlist_webApi.Domains;

#nullable disable

namespace senai_wishlist_webApi.Contexts
{
  public partial class WishListContext : DbContext
  {
    public WishListContext()
    {
    }

    public WishListContext(DbContextOptions<WishListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ListaDesejo> ListaDesejos { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlServer("Data Source=HISP-LSILVA\\SQLEXPRESS; initial catalog=projeto_medicals; user Id=sa; pwd=senai@132");
        // optionsBuilder.UseSqlServer("Data Source=DESKTOP-BI41T69\\SQLEXPRESS; initial catalog=Projeto_WishList; user Id=sa; pwd=senai@132");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

      modelBuilder.Entity<ListaDesejo>(entity =>
      {
        entity.HasKey(e => e.IdDesejo)
                  .HasName("PK__ListaDes__D580C0E628C49794");

        entity.HasIndex(e => e.Descricaodesejo, "UQ__ListaDes__ABC640B91A9F2734")
                  .IsUnique();

        entity.Property(e => e.Descricaodesejo)
                  .IsRequired()
                  .HasMaxLength(250)
                  .IsUnicode(false);

        entity.HasOne(d => d.IdUsuarioNavigation)
                  .WithMany(p => p.ListaDesejos)
                  .HasForeignKey(d => d.IdUsuario)
                  .HasConstraintName("FK__ListaDese__IdUsu__286302EC");
      });

      modelBuilder.Entity<Usuario>(entity =>
      {
        entity.HasKey(e => e.IdUsuario)
                  .HasName("PK__Usuarios__5B65BF9707BA0494");

        entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053404E4EAE5")
                  .IsUnique();

        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(100)
                  .IsUnicode(false);

        entity.Property(e => e.Senha)
                  .IsRequired()
                  .HasMaxLength(80)
                  .IsUnicode(false);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
