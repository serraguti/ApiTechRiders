using ApiTechRiders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiTechRiders.Data
{
    public class TechRidersContext: DbContext
    {
        public TechRidersContext(DbContextOptions<TechRidersContext> options) : base(options) { }
        public DbSet<Charla> Charlas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursosProfesores> CursosProfesores { get; set; }
        public DbSet<EmpresasCentros> EmpresasCentros { get; set; }
        public DbSet<EstadosCharla> EstadosCharlas { get; set; }
        public DbSet<EstadosValidacion> EstadosValidacion { get; set; }
        public DbSet<Peticion> Peticiones { get; set; }
        public DbSet<PeticionAltaUsers> PeticionesAltaUsers { get; set; }
        public DbSet<PeticionCategorias> PeticionesCategorias { get; set; }
        public DbSet<PeticionCentroEmpresa> PeticionesCentroEmpresa { get; set; }
        public DbSet<PeticionCharlas> PeticionesCharlas { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<TecnologiaTechRiders> TecnologiasTechRiders { get; set; }
        public DbSet<TecnologiaCharlas> TecnologiasCharlas { get; set; }
        public DbSet<TipoTecnologia> TiposTecnologias { get; set; }
        public DbSet<Usuario> Usuarios { get;set; }
        public DbSet<ValoracionCharla> ValoracionesCharlas { get; set; }

    }
}
