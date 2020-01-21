using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Popup.Requests
{
    public class CreatePopupInput
    {
        public string Nombre { get; set; }
        public string Base64 { get; set; }

    }
}
