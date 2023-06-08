using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using Microsoft.Extensions.Hosting;

namespace LibraryAPI.Data
{
    public class LibraryDatabaseContext : DbContext
    {
        public LibraryDatabaseContext (DbContextOptions<LibraryDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<LibraryAPI.Models.Author> Author { get; set; } = default!;

        public DbSet<LibraryAPI.Models.Book>? Book { get; set; }

        public DbSet<LibraryAPI.Models.Category>? Category { get; set; }

        public DbSet<LibraryAPI.Models.Publisher>? Publisher { get; set; }

        public DbSet<LibraryAPI.Models.Reader>? Reader { get; set; }

		// Tabela "Wypożyczenia"
        public DbSet<LibraryAPI.Models.ReaderBook>? ReaderBook { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Konfiguracja dla Wishlist
			modelBuilder.Entity<Reader>()
				.HasMany(e => e.Wishlist)
				.WithMany(e => e.WishingReaders);

			// Mechanizm zautomatyzowanego tworzenia tabeli many-to-many ReaderBookScore - oceny książek przez czytelników
			modelBuilder.Entity<Reader>()
				.HasMany(e => e.ScoredBooks)
				.WithMany(e => e.ScoringReaders)
				.UsingEntity<ReaderBookScore>();
		}
		public DbSet<LibraryAPI.Models.ReaderBookScore>? ReaderBookScore { get; set; }
	}
}
