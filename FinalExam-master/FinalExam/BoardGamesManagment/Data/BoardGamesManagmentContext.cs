using FinalExam.BoardGamesManagment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BoardGamesManagment.Data
{
    public  class BoardGamesManagmentContext : DbContext 
    {
        public DbSet<Game> Gamesss { get; set; }
        public DbSet<Member> Membersss { get; set; }
        public DbSet<Session> Sessionsss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(g => g.Genre)
                      .IsRequired();

                entity.Property(g => g.MinPlayers).HasDefaultValue(1);

                entity.Property(g => g.MaxPlayers).HasDefaultValue(1);

                entity.HasMany(g => g.Sessions).WithOne(s => s.Game).HasForeignKey(s => s.GameId);
            });

            modelBuilder.Entity<Game>().ToTable(g => g.HasCheckConstraint("CK_Players_Game" , "[MinPlayers] > 0 AND [MaxPlayers] > 0"));

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasMany(m => m.Sessions).WithOne(s => s.Member).HasForeignKey(s => s.MemberId);
            });

            modelBuilder.Entity<Session>(entity => {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.DurationMinutes).HasDefaultValue(0);
            });
            modelBuilder.Entity<Session>().ToTable(s => s.HasCheckConstraint("CK_DurationMinutes_Session" , "[DurationMinutes] >= 0"));



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../board_games.db");
        }
    }
}
