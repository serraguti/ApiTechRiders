using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_CENTRO_EMPRESA")]
    public class PeticionCentroEmpresa
    {
        [Key]
        [Column("IDPETICION")]
        public int IdPeticion { get; set; }
        [Column("IDCENTROEMPRESA")]
        public int IdCentroEmpresa { get; set; }
    }
}
