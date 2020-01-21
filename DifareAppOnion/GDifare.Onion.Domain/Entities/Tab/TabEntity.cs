﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionPattern.Domain.Entities.Tab
{
    public class TabEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public string Base64 { get; set; }
        public string UrlPage { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
