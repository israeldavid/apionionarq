using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using OnionPattern.Domain.Errors;

namespace OnionPattern.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped, JsonIgnore]
        public bool IsValid { get; set; }

        [NotMapped, JsonIgnore]
        public ICollection<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
    }
}
