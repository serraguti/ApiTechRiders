using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class QueryToolsController : ControllerBase
    {
        private RepositoryTechRiders repo;

        public QueryToolsController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/querytools/charlasviewall
        /// <summary>
        /// Obtiene el conjunto de CHARLAS CON DETALLES, VIEW VISTACHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las Charlas con Formato de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CharlaView>>> CharlasViewAll()
        {
            return await this.repo.GetCharlasViewAsync();
        }

        // GET: api/querytools/FindCharlaView/{idcharla}
        /// <summary>
        /// Permite buscar CHARLAS CON DETALLES, VIEW VISTACHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para buscar charlas por el ID de Charla
        /// </remarks>
        /// <param name="idcharla">Id (GUID) del objeto Charla.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CharlaView>>
            FindCharlaView(int idcharla)
        {
            return await this.repo.FindCharlaViewAsync(idcharla);
        }

        // GET: api/querytools/charlastechrider/{idtechrider}
        /// <summary>
        /// Obtiene el conjunto de CHARLAS con detalles de un TECHRIDER, VIEW VISTACHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las Charlas de un TechRider con Formato de la BBDD
        /// </remarks>
        /// <param name="idtechrider">Id del TechRider para buscar sus charlas.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CharlaView>>>
            CharlasTechRider(int idtechrider)
        {
            return await this.repo.GetCharlasViewTechrRiderAsync(idtechrider);
        }

        // GET: api/querytools/tecnologiastechriders
        /// <summary>
        /// Obtiene el conjunto de Tecnologías de TechRiders con Detalles, VIEW DATOSTECHRIDERTECNOLOGIAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las Charlas con Formato de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TechRiderTecnologia>>>
            TecnologiasTechriders()
        {
            return await this.repo.GetTechRidersTecnologias();
        }

        // GET: api/querytools/Findtecnologiastechrider/{idtechrider}
        /// <summary>
        /// Permite buscar Tecnologías de un TechRider, VIEW DATOSTECHRIDERTECNOLOGIAS.
        /// </summary>
        /// <remarks>
        /// Método para buscar de Tecnologías de TechRiders con Detalles mediante el ID del TechRider
        /// </remarks>
        /// <param name="idtechrider">Id del TechRider para ver sus tecnologías.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TechRiderTecnologia>>>
            FindTecnologiasTechrider(int idtechrider)
        {
            return await this.repo.FindTechRidersTecnologias(idtechrider);
        }

        // GET: api/querytools/cursosprofesorall
        /// <summary>
        /// Devuelve el conjunto de CURSOSPROFESORES, VIEW CURSOSPROFESORESVIEW.
        /// </summary>
        /// <remarks>
        /// Método para recuperar todos los Cursos con profesores
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CursoProfesorView>>>
            CursosProfesorAll()
        {
            return await this.repo.GetCursosProfesoresView();
        }

        // GET: api/querytools/FindCursosProfesor/{idprofesor}
        /// <summary>
        /// Permite buscar Cursos de un Profesor, VIEW CURSOSPROFESORESVIEW.
        /// </summary>
        /// <remarks>
        /// Método para buscar todos los cursos de un Profesor mediante el Id del profesor
        /// </remarks>
        /// <param name="idprofesor">Id del Profesor para ver sus cursos.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]/{idprofesor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CursoProfesorView>>>
            FindCursosProfesor(int idprofesor)
        {
            return await this.repo.GetCursosProfesorView(idprofesor);
        }

        // GET: api/querytools/techridersempresasall
        /// <summary>
        /// Devuelve el conjunto de TECHRIDERSEMPRESASVIEW, VIEW TECHRIDERSEMPRESASVIEW.
        /// </summary>
        /// <remarks>
        /// Método para recuperar todos los Cursos con profesores
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TechRiderEmpresaView>>>
            TechRidersEmpresasAll()
        {
            return await this.repo.GetTechRidersEmpresasViewAsync();
        }

        // GET: api/querytools/FindEmpresaTechRider/{idtechrider}
        /// <summary>
        /// Permite buscar las Empresas de un TechRider, VIEW TECHRIDERSEMPRESASVIEW.
        /// </summary>
        /// <remarks>
        /// Método para buscar la empresa/s de un TechRider mediante el Id del TechRider
        /// </remarks>
        /// <param name="idtechrider">Id del TechRider para ver su Empresa.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]/{idtechrider}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TechRiderEmpresaView>>>
            FindEmpresaTechRider(int idtechrider)
        {
            return await this.repo.FindTechRidersEmpresaByTechRiderViewAsync(idtechrider);
        }

        // GET: api/querytools/FindEmpresaTechRider/{idtechrider}
        /// <summary>
        /// Permite buscar los TechRiders por Empresa, VIEW TECHRIDERSEMPRESASVIEW.
        /// </summary>
        /// <remarks>
        /// Método para buscar los TechRiders de una Empresa mediante el Id de empresa
        /// </remarks>
        /// <param name="idempresa">Id de la empresa para ver sus TechRiders.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]/{idempresa}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TechRiderEmpresaView>>>
            FindTechRidersEnEmpresa(int idempresa)
        {
            return await this.repo.FindTechRidersEmpresaByEmpresaViewAsync(idempresa);
        }

        // GET: api/querytools/charlasempresas
        /// <summary>
        /// Devuelve todas las charlas por empresa, VIEW CHARLASTECHRIDERSEMPRESAVIEW.
        /// </summary>
        /// <remarks>
        /// Método para recuperar todas las charlas por empresa
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CharlaTechRiderEmpresaView>>>
            CharlasEmpresas()
        {
            return await this.repo.GetCharlasTechRidersViewAsync();
        }

        // GET: api/querytools/findcharlastechriderempresa/{idempresa}
        /// <summary>
        /// Busca todas las charlas por empresa, VIEW CHARLASTECHRIDERSEMPRESAVIEW.
        /// </summary>
        /// <remarks>
        /// Método para buscar las charlas de un TechRider mediante el Id del Empresa
        /// </remarks>
        /// <param name="idempresa">Id de la empresa para ver las charlas de sus Techriders.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]/{idempresa}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CharlaTechRiderEmpresaView>>>
            FindCharlasTechriderEmpresa(int idempresa)
        {
            return await this.repo.FindCharlasTechRidersViewAsync(idempresa);
        }
    }
}
