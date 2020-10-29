using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCC.Candle.Logic.DataTransferObjects;

namespace TCC.Candle.Web.ViewModels.Shelf
{
    public class FormViewModel
    {
        public bool Parsed { get; set; }

        public FormViewModel()
        {

        }

        public FormViewModel(ShelfFormDto dto)
        {
            if (dto != null)
            {
                Id = dto.Id;
                LibraryId = dto.LibraryId;
                Color = dto.Color;
                Description = dto.Description;
                Title = dto.Title;
                Parsed = true;
            }
            else
            {
                Parsed = false;
            }
        }


        public Guid Id { get; set; }

        [Display(Name = "Library Title")]
        [MaxLength(50, ErrorMessage = "Titl must not exceed 50 characters, Do your best :)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You didn't provide a title, what is it all about?")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [MaxLength(255, ErrorMessage = "Description must not exceed 255 characters, Consider it a tweet :3")]
        public string Description { get; set; }
        public string Color { get; set; }
        public Guid LibraryId { get; set; }

        public ShelfFormDto ToShelfFormDto()
        {
            return new ShelfFormDto
            {
                Id = Id,
                LibraryId = LibraryId,
                Description = Description,
                Color = Color,
                Title = Title
            };
        }
    }
}
