using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Menu.Requests
{
    public class CreateMenuInput
    {
        public string Nombre { get; set; }
        public string Base64 { get; set; }
        public string UrlPage { get; set; }

    }
}
