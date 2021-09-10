using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASP.NET_MVC_EntityFramework.Custom_Data_Annotations;

namespace ASP.NET_MVC_EntityFramework.Models.ViewModels
{
    public class BookViewModel
    {
        [Display(Name = "Book ID")]
        public int BookId { get; set; }
        [RegularExpression(@"^[A-Z][a-z']+(?: [A-Za-z&-]+)*\s?", ErrorMessage = "Book name start with uppercase & Only characters are allowed!!!")]
        //[RegularExpression(@"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)*\s*$",ErrorMessage ="Only characters are allowed!!!")]
        [Required(ErrorMessage = "Book name is required")]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        [UpperCase]
        [Required(ErrorMessage = "Author name is required")]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Display(Name = "Publisher Name")]
        public int PublisherId { get; set; }

        [Display(Name = "Publish Date")]
        [PublishDate]
        public System.DateTime PublishDate { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Cover Image")]
        public string CoverImagePath { get; set; }

        [Display(Name = "Cover Image")]
        public HttpPostedFileBase CvImage { get; set; }
    }
}