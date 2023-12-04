using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_CHARLAS")]
    public class PeticionCharlas
    {
        [Key]
        [Column("IDPETICION")]
        public int IdPeticion { get; set; }
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
    }
}
