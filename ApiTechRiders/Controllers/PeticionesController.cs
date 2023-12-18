using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class PeticionesController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public PeticionesController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/peticiones
        /// <summary>
        /// Obtiene el conjunto de PETICIONES, tabla PETICIONES.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los PETICIONES de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Peticion>>> Get()
        {
            return await this.repo.GetPeticionesAsync();
        }

        // GET: api/peticiones/{id}
        /// <summary>
        /// Obtiene un PETICIONES por su Id, tabla PETICIONES.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto PETICIONES por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto ESTADOSVALIDACION.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Peticion>> Find(int id)
        {
            var peticion = await this.repo.FindPeticionAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/peticiones
        /// <summary>
        /// Crea un nuevo PETICIONES en la BBDD, tabla PETICIONES
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo PETICIONES enviando el Objeto JSON
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Peticion>>
                InsertPeticion(Peticion peticionRequest)
        {
            Peticion peticionNew =
                    await this.repo.InsertPeticionAsync
                    (peticionRequest);
            return peticionNew;
        }

        // PUT: api/peticiones
        /// <summary>
        /// Modifica un PETICIONES en la BBDD mediante su ID, tabla PETICIONES
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePeticion
                (Peticion peticionRequest)
        {
            var peticionFind = await this.repo.FindPeticionAsync
                (peticionRequest.IdPeticion);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdatePeticionAsync(peticionRequest);
            return Ok();
        }

        // DELETE: api/peticiones/{id}
        /// <summary>
        /// Elimina un PETICIONES en la BBDD mediante su ID. Tabla PETICIONES
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de PETICIONES a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePeticion(int id)
        {
            var peticionFind = await this.repo.FindPeticionAsync
                (id);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeletePeticionAsync(id);
            return Ok();
        }
    }
}
