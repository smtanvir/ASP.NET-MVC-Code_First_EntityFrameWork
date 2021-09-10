using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using ASP.NET_MVC_EntityFramework.Custom_Data_Annotations;
namespace ASP.NET_MVC_EntityFramework.Models
{
    public class Publisher
    {
        [Display(Name ="Publisher ID")]
        public int Id { get; set; }
        [Required,StringLength(50),Display(Name ="Publisher Name")]
        public string PublisherName { get; set; }

        //Navigation
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Book
    {
        [Display(Name ="Book ID")]
        public int Id { get; set; }
        [Required,StringLength(50),Display(Name ="Book Name")]
        public string BookName { get; set; }
        [Required,StringLength(50),Display(Name ="Author Name")]
        public string AuthorName { get; set; }
        [Required, ForeignKey("Publisher")]
        public int PublisherId { get; set; } //Foreign Key
        [Required, Column(TypeName =("date"))]
        [PublishDate(ErrorMessage ="Publish should be less than current date")]
        public DateTime PublishDate { get; set; }
        [Required]
        [Display(Name ="Book Price")]
        public decimal Price { get; set; }
        [StringLength(150)]
        [Display(Name ="Book Cover Image")]
        public string CoverImage { get; set; }

        //Navigation
        public Publisher Publisher { get; set; }
    }

    public class BookDbContext:DbContext
    {
        public BookDbContext()
        {
            Database.SetInitializer<BookDbContext>(new DropCreateDatabaseIfModelChanges<BookDbContext>());
        }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}