using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interview.Models.Test
{
    public class GenerateTestViewModel
    {
        public GenerateTestViewModel()
        {
            //TO DO GET THEM FROM DB 17/12/2021
            this.Languages = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = "Изберете език", Disabled=true,Selected=true},
                new SelectListItem {Value = ".NET", Text =".NET"}
            };
            this.Levels = new List<SelectListItem> 
            {
                new SelectListItem {Value = "", Text = "Позиция", Disabled=true,Selected=true},
                new SelectListItem {Value = "D63FD2BC-17A3-4DC3-8D14-69EFC0457161", Text ="Intern"},
                new SelectListItem {Value = "9A2FDE70-8D1C-4B82-BD28-347C66C437C2", Text ="Junior"},
                new SelectListItem {Value = "AE8C61F7-3EF8-47CD-A32F-509017E03F41", Text ="Regular"},
                new SelectListItem {Value = "7FA24D56-48C0-483B-AE21-9117D411C15D", Text ="Senior"}
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
