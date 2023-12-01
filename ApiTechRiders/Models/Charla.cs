using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("CHARLAS")]
    public class Charla
    {
        [Key]
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }
        [Column("IDESTADOCHARLA")]
        public int IdEstadoCharla { get; set; }
        [Column("FECHA_CHARLA")]
        public DateTime FechaCharla { get; set; }
        [Column("OBSERVACIONES")]
        public string Observaciones { get;set; }
        [Column("IDTECHRIDER")]
        public int IdTechRider { get; set; }
        [Column("FECHA_SOLICITUD")]
        public DateTime FechaSolicitud { get; set; }
        [Column("TURNO")]
        public string Turno { get; set; }
        [Column("MODALIDAD")]
        public string Modalidad { get; set; }
        [Column("VALORACION")]
        public int Valoracion { get;set; }
        [Column("COMENTARIOS")]
        public string Comentarios { get; set; }
        [Column("ACREDITACION_LINKEDIN")]
        public string AcreditacionLinkedIn { get; set; }
        [Column("IDCURSO")]
        public int IdCurso { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
    }
}
