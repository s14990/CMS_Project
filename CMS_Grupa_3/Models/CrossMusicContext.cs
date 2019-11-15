using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMS_Grupa_3.Models
{
    public partial class CrossMusicContext : DbContext
    {
        public CrossMusicContext()
        {
        }

        public CrossMusicContext(DbContextOptions<CrossMusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<FriendList> FriendList { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<MediaFile> MediaFile { get; set; }
        public virtual DbSet<MediaPost> MediaPost { get; set; }
        public virtual DbSet<Msg> Msg { get; set; }
        public virtual DbSet<Sesn> Sesn { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UsersInFl> UsersInFl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:cmsproject.database.windows.net,1433;Initial Catalog=CrossMusic;User ID=cmsAdmin;Password=2019CMS_Project;MultipleActiveResultSets =False;Encrypt=True;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.CommentDate)
                    .HasColumnName("comment_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CommentHtml)
                    .IsRequired()
                    .HasColumnName("comment_html");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comment_User");
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.HasKey(e => e.FlId)
                    .HasName("FriendList_pk");

                entity.Property(e => e.FlId).HasColumnName("fl_id");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.FriendList)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FriendList_User");
            });

            modelBuilder.Entity<Likes>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("Likes_pk");

                entity.Property(e => e.LikeId).HasColumnName("like_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Likes_MediaPost");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Likes_User");
            });

            modelBuilder.Entity<MediaFile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("MediaFile_pk");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.FileLink)
                    .IsRequired()
                    .HasColumnName("file_link")
                    .HasMaxLength(100);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasMaxLength(30);

                entity.Property(e => e.FileType)
                    .HasColumnName("file_type")
                    .HasMaxLength(10);

                entity.Property(e => e.MediaDate)
                    .HasColumnName("media_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MediaDescription)
                    .HasColumnName("media_description")
                    .HasMaxLength(100);

                entity.Property(e => e.MediaName)
                    .IsRequired()
                    .HasColumnName("media_name")
                    .HasMaxLength(30);

                entity.Property(e => e.MediaType)
                    .HasColumnName("media_type")
                    .HasMaxLength(30);

                entity.Property(e => e.UploaderId)
                    .HasColumnName("uploader_id")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Uploader)
                    .WithMany(p => p.MediaFile)
                    .HasForeignKey(d => d.UploaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MediaFile_User");
            });

            modelBuilder.Entity<MediaPost>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("MediaPost_pk");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MediaFileId).HasColumnName("MediaFile_id");

                entity.Property(e => e.PostDate)
                    .HasColumnName("post_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostHtml)
                    .IsRequired()
                    .HasColumnName("post_html");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.MediaPost)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MediaPost_User");

                entity.HasOne(d => d.MediaFile)
                    .WithMany(p => p.MediaPost)
                    .HasForeignKey(d => d.MediaFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MediaPost_MediaFile");
            });

            modelBuilder.Entity<Msg>(entity =>
            {
                entity.Property(e => e.MsgId).HasColumnName("msg_id");

                entity.Property(e => e.AutorId).HasColumnName("autor_id");

                entity.Property(e => e.MsgDate)
                    .HasColumnName("msg_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TargetId).HasColumnName("target_id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(400);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.MsgAutor)
                    .HasForeignKey(d => d.AutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Message_User_Target");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.MsgTarget)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Message_User_Author");
            });

            modelBuilder.Entity<Sesn>(entity =>
            {
                entity.Property(e => e.SesnId).HasColumnName("sesn_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sesn)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Session_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserConfirmed)
                    .HasColumnName("user_confirmed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(30);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(30);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(30);

                entity.Property(e => e.UserRank).HasColumnName("user_rank");

                entity.Property(e => e.UserStatus)
                    .HasColumnName("user_status")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<UsersInFl>(entity =>
            {
                entity.HasKey(e => e.UflId)
                    .HasName("Users_in_FL_pk");

                entity.ToTable("Users_in_FL");

                entity.Property(e => e.UflId).HasColumnName("ufl_id");

                entity.Property(e => e.FlId).HasColumnName("fl_id");

                entity.Property(e => e.FlStatus).HasColumnName("fl_status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Fl)
                    .WithMany(p => p.UsersInFl)
                    .HasForeignKey(d => d.FlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_in_FL_FriendList");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersInFl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_in_FL_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
