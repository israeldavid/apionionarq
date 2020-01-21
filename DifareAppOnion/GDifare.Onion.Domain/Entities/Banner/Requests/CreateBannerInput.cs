using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Banner.Requests
{
    public class CreateBannerInput
    {
        public string Nombre { get; set; }
        public string Base64 { get; set; }

    }
}
