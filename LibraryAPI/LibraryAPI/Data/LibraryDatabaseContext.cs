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

        public DbSet<LibraryAPI.Models.ReaderBook>? ReaderBook { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reader>()
				.HasMany(e => e.FavouriteAuthors)
				.WithMany(e => e.Readers)
				.UsingEntity<ReaderAuthor>();
		}
		public DbSet<LibraryAPI.Models.ReaderAuthor>? ReaderAuthor { get; set; }

        //testowa wiadomosc 2
	}
}
