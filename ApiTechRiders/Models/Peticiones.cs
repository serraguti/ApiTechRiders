using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES")]
    public class Peticiones
    {
        [Key]
        [Column("IDPETICION")]
        public int IdPeticion { get; set; }
        [Column("TIPO_PETICION")]
        public string TipoPeticion { get; set; }
        [Column("ID_GENERAL")]
        public int IdGeneral { get;set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }
        [Column("FECHA_PETICION")]
        public DateTime FechaPeticion { get;set; }
    }
}
