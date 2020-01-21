using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Popup.Requests
{
    public class UpdatePopupInput
    {
        public int Id { get; set; }
        public string NombreNuevo { get; set; }
        public string Base64Nuevo { get; set; }
    }
}
