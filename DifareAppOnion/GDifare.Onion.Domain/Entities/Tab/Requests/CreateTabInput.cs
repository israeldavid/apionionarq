using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Tab.Requests
{
    public class CreateTabInput
    {
        public string Nombre { get; set; }
        public string Base64 { get; set; }
        public string UrlPage { get; set; }

    }
}
