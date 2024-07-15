using Microsoft.AspNetCore.Mvc;

namespace ModelBinding
{
    public class NewType
    {

        [FromHeader(Name = "User-Agent")]
        public string UserAgent { get; set; }

        [FromQuery]
        public string Name { get; set; }    
    }
}
