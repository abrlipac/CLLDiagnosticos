using System.Collections.Generic;

namespace Identity.Service.EventHandlers.Responses
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}
