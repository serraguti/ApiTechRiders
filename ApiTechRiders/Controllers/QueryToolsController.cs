using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

////PONER EN LA DOCUMENTACION QUE CERO QUITARA AL TECHRIDER DE LA CHARLA
//asociartechridercharla /{ idtechrider}/{ idcharla}
//updateobservacionescharla//{idcharla}/{observaciones}
//updateestadocharla//{idcharla}/{idestadocharla}
//updatefechacharla//{idcharla}/{fechacharla}

//USUARIOS
//	DAR DE ALTA USUARIO (CAMBIAR ESTADO)
//	DAR DE BAJA USUARIO (CAMBIAR ESTADO)

//BUSCAR CHARLAS DE UN TECHRIDER/PROFESOR

//METODO CON TODOS LOS DATOS DE UNA CHARLA

//CURSOS POR PROFESOR (VARIOS)

namespace ApiTechRiders.Controllers
{
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

    }
}
