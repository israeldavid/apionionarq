using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Tema.Requests
{
    public class UpdateTemaInput
    {
        public int Id { get; set; }
        public string NombreNuevo { get; set; }
        public string Descripcion { get; set; }
    }
}
