using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCC.Candle.Data.Enums;
using TCC.Candle.Logic.DataTransferObjects;

namespace TCC.Candle.Web.ViewModels.Book
{
    public class FormViewModel
    {


        public FormViewModel()
        {

        }

        public FormViewModel(BookFormDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            SubTitle = dto.SubTitle;
            Description = dto.Description;
            Pages = dto.Pages;
            ISBN13 = dto.ISBN13;
            Released = dto.Released;
            language = dto.language;
            ShelfId = dto.ShelfId;
            Author = dto.Author;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "You didn't Provide a book name")]
        public string Title { get; set; }

        [MaxLength(100)]
        public string SubTitle { get; set; }

        [MaxLength(255, ErrorMessage = "You have to be brief about your description")]
        public string Description { get; set; }

        // TODO: Create Custom Validation Attribute
        public string ISBN13 { get; set; }

        public int Pages { get; set; }

        public DateTime Released { get; set; }

        [EnumDataType(typeof(Languages), ErrorMessage = "Value is not allowed")]
        public Languages language { get; set; }

        // Navigational Properties
        [Required]
        public Guid ShelfId { get; set; }


        public string Author { get; set; }
        public BookFormDto ToBookFormDto()
        {
            return new BookFormDto
            {
                Id = Id,
                Title = Title,
                SubTitle = SubTitle,
                Description = Description,
                Pages = Pages,
                ISBN13 = ISBN13,
                Released = Released,
                language = language,
                ShelfId = ShelfId,
                Author = Author
            };
        }

    }
}
