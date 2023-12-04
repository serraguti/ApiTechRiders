using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TECNOLOGIAS")]
    public class Tecnologia
    {
        [Key]
        [Column("IDTECNOLOGIA")]
        public int IdTecnologia { get;set; }
        [Column("NOMBRE_TECNOLOGIA")]
        public string NombreTecnologia { get; set; }
        [Column("ID_TIPO_TECNOLOGIA")]
        public int IdTipoTecnologia { get; set; }
    }
}
