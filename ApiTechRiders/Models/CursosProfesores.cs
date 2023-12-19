using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("CURSOS_PROFESORES")]
    public class CursosProfesores
    {
        //[Key, Column(Order = 0, TypeName = "IDCURSO") ]
        [Column("IDCURSO")]
        public int IdCurso { get; set; }
        //[Key, Column(Order = 1, TypeName = "IDPROFESOR")]
        [Column("IDPROFESOR")]
        public int IdProfesor { get; set; }
    }
}
