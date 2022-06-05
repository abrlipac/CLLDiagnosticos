using System.Collections.Generic;

namespace WebClientBlazor.Models.Identity.Responses
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}
