using System;

namespace OnionPattern.Domain.Entities.Banner
{
    public class BannerEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public string Base64 { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
