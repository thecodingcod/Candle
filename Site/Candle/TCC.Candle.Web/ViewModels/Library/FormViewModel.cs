using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCC.Candle.Logic.DataTransferObjects;

namespace TCC.Candle.Web.ViewModels.Library
{
    public class FormViewModel
    {
        public FormViewModel()
        {

        }
        public FormViewModel(LibraryFormDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            Description = dto.Description;
        }

        public Guid Id { get; set; }


        [Display(Name = "Library Title")]
        [MaxLength(50, ErrorMessage = "Titl must not exceed 50 characters, Do your best :)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You didn't provide a title, what is it all about?")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [MaxLength(255, ErrorMessage = "Description must not exceed 255 characters, Consider it a tweet :3")]
        public string Description { get; set; }


        // Integerate Later
        //public string ImageUrl { get; set; }


        public LibraryFormDto ToLibraryFormDto()
        {
            return new LibraryFormDto { Id = Id, Title = Title, Description = Description };
        }




    }
}
