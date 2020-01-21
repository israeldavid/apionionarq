﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.Entities.Tab.Requests
{
    public class UpdateTabInput
    {
        public int Id { get; set; }
        public string NombreNuevo { get; set; }
        public string Base64Nuevo { get; set; }
        public string UrlPage { get; set; }
    }
}
