using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interview.Models.Test
{
    public class GenerateTestViewModel
    {
        public GenerateTestViewModel()
        {
            this.Languages = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "Изберете език", Disabled=true,Selected=true},
                new SelectListItem {Value = ".NET", Text =".NET"}
            };
            this.Levels = new List<SelectListItem> 
            {
                new SelectListItem {Value = "", Text = "Позиция", Disabled=true,Selected=true},
                new SelectListItem {Value = "Intern", Text ="Intern"},
                new SelectListItem {Value = "Junior", Text ="Junior"},
                new SelectListItem {Value = "Regular", Text ="Regular"},
                new SelectListItem {Value = "Senior", Text ="Senior"}
            };
            this.NumberOfQuestions = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "Брой въпроси", Disabled=true,Selected=true},
                new SelectListItem {Value = "8" , Text = "8"},
                new SelectListItem {Value = "12" , Text = "12"},
                new SelectListItem {Value = "14" , Text = "14"},
                new SelectListItem {Value = "20" , Text = "20"},
            };
        }
        [Required]
        public List<SelectListItem> Languages { get; set; }

        [Required]
        public List<SelectListItem> Levels { get; set; }

        [Required]
        public List<SelectListItem> NumberOfQuestions { get; set; }

        public string Language { get; set; }

        public string Level { get; set; }

        public string Question { get; set; }
    }
}
