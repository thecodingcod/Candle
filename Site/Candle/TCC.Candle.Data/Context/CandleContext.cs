using Microsoft.EntityFrameworkCore;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Mapping;

namespace TCC.Candle.Data
{
    public class CandleContext : DbContext
    {
        public CandleContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LibraryETC());
            modelBuilder.ApplyConfiguration(new ShelfETC());
            modelBuilder.ApplyConfiguration(new VolumeETC());
            modelBuilder.ApplyConfiguration(new BookETC());
            modelBuilder.ApplyConfiguration(new AuthorETC());
            modelBuilder.ApplyConfiguration(new BookAuthorETC());
            modelBuilder.ApplyConfiguration(new TaggedBookETC());
        }

        // DBSets
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<TaggedBook> TaggedBooks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
