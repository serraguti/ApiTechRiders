using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class CharlasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public CharlasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/charlas
        /// <summary>
        /// Obtiene el conjunto de CHARLAS, tabla CHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las Charlas de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Charla>>> Get()
        {
            //throw new Exception("Error personalizado con detalles");
            return await this.repo.GetCharlasAsync();
        }

        // GET: api/charlas/{id}
        /// <summary>
        /// Obtiene una Charla por su Id, tabla CHARLAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto Charla por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto Charla.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Charla>> Find(int id)
        {
            var charla = await this.repo.FindCharlaAsync(id);
            if (charla == null)
            {
                return NotFound();
            }
            return charla;
        }

        // POST: api/charlas
        /// <summary>
        /// Crea una nueva Charla en la BBDD, tabla CHARLAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo CHARLA enviando el Objeto JSON
        /// El ID de la charla se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Charla>>
            InsertCharla(Charla charla)
        {
            Charla charlaNew =
                await this.repo.InsertCharlaAsync
                (charla);
            return charlaNew;
        }

        // PUT: api/charlas
        /// <summary>
        /// Modifica una Charla en la BBDD mediante su ID, tabla CHARLA
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCharla
            (Charla charla)
        {
            var charlaFind = await this.repo.FindCharlaAsync(charla.IdCharla);
            if (charlaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateCharlaAsync(charla);
            return Ok();
        }

        // DELETE: api/charlas/{id}
        /// <summary>
        /// Elimina una Charla en la BBDD mediante su ID. Tabla CHARLAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de la Charla a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharla(int id)
        {
            var charla = await this.repo.FindCharlaAsync(id);
            if (charla == null)
            {
                return NotFound();
            }
            await this.repo.DeleteCharlaAsync(id);
            return Ok();
        }
    }
}
