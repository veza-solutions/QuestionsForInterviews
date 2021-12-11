using Microsoft.AspNetCore.Mvc;

namespace Interview.Models.Test
{
    [BindProperties]
    public class GetTestProperties
    {
        public string Language { get; set; }

        public string Rank { get; set; }

        public string  Questions { get; set; }
    }
}
