//cambiar IDPETICION POR IDPETICION CATEGORIAS TABLA PETICIONES_CATEGORIAS
//CAMBIAR provincia STRING por IDPROVINCIA ALTER TABLE en CHARLAS
//cambiar IDPETICION POR IdPeticionAltaUsers EN PETCIONALTAUSERS
//cambiar IDPETICION POR IdPeticionCentrosEmpresa EN PETCIONCENTROSEMPRESA
//cambiar IDPETICION POR IdPeticionCharla EN PETICIONCHARLA

using ApiTechRiders.Data;
using ApiTechRiders.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTechRiders.Repositories
{
    public class RepositoryTechRiders
    {
        private TechRidersContext context;

        public RepositoryTechRiders(TechRidersContext context)
        {
            this.context = context;
        }

        #region CHARLAS

        public async Task<List<Charla>> GetCharlasAsync()
        {
            return await this.context.Charlas.ToListAsync();
        }

        public async Task<Charla>
            FindCharlaAsync(int id)
        {
            return await
                this.context.Charlas
                .FirstOrDefaultAsync(x => x.IdCharla == id);
        }

        private async Task<int> GetMaxIdCharla()
        {
            if (this.context.Charlas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Charlas.MaxAsync(z => z.IdCharla) + 1;
            }
        }

        public async Task<Charla> InsertCharlaAsync
            (Charla requestCharla)
        {
            Charla newCharla = new Charla();
            newCharla.IdCharla =await this.GetMaxIdCharla();
            newCharla.IdCurso = requestCharla.IdCurso;
            newCharla.IdEstadoCharla = requestCharla.IdEstadoCharla;
            newCharla.IdProvincia = requestCharla.IdProvincia;
            newCharla.IdTechRider = requestCharla.IdTechRider;
            newCharla.Modalidad = requestCharla.Modalidad;
            newCharla.Observaciones = requestCharla.Observaciones;
            newCharla.Turno = requestCharla.Turno;
            newCharla.Valoracion = requestCharla.Valoracion;
            newCharla.FechaCharla = requestCharla.FechaCharla;
            newCharla.FechaSolicitud = requestCharla.FechaSolicitud;
            newCharla.Descripcion = requestCharla.Descripcion;
            newCharla.Comentarios = requestCharla.Comentarios;
            newCharla.AcreditacionLinkedIn = requestCharla.AcreditacionLinkedIn;
            this.context.Charlas.Add(newCharla);
            await this.context.SaveChangesAsync();
            return newCharla;
        }

        public async Task UpdateCharlaAsync
           (Charla requestCharla)
        {
            Charla newCharla = await this.FindCharlaAsync(requestCharla.IdCharla);
            newCharla.IdCurso = requestCharla.IdCurso;
            newCharla.IdEstadoCharla = requestCharla.IdEstadoCharla;
            newCharla.IdProvincia = requestCharla.IdProvincia;
            newCharla.IdTechRider = requestCharla.IdTechRider;
            newCharla.Modalidad = requestCharla.Modalidad;
            newCharla.Observaciones = requestCharla.Observaciones;
            newCharla.Turno = requestCharla.Turno;
            newCharla.Valoracion = requestCharla.Valoracion;
            newCharla.FechaCharla = requestCharla.FechaCharla;
            newCharla.FechaSolicitud = requestCharla.FechaSolicitud;
            newCharla.Descripcion = requestCharla.Descripcion;
            newCharla.Comentarios = requestCharla.Comentarios;
            newCharla.AcreditacionLinkedIn = requestCharla.AcreditacionLinkedIn;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCharlaAsync(int idCharla)
        {
            Charla charla = await this.FindCharlaAsync(idCharla);
            this.context.Charlas.Remove(charla);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region CURSOS

        public async Task<List<Curso>> GetCursosAsync()
        {
            return await this.context.Cursos.ToListAsync();
        }

        public async Task<Curso>
            FindCursoAsync(int id)
        {
            return await
                this.context.Cursos
                .FirstOrDefaultAsync(x => x.IdCurso == id);
        }

        private async Task<int> GetMaxIdCurso()
        {
            if (this.context.Cursos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Cursos.MaxAsync(z => z.IdCurso) + 1;
            }
        }

        public async Task<Curso> InsertCursoAsync
            (Curso requestCurso)
        {
            Curso newCurso = new Curso();
            newCurso.IdCurso = await this.GetMaxIdCurso();
            newCurso.Descripcion = requestCurso.Descripcion;
            newCurso.IdCentro = requestCurso.IdCentro;
            newCurso.NombreCurso = requestCurso.NombreCurso;
            this.context.Cursos.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateCursoAsync
           (Curso requestCurso)
        {
            Curso newCurso = await this.FindCursoAsync(requestCurso.IdCurso);
            newCurso.Descripcion = requestCurso.Descripcion;
            newCurso.IdCentro = requestCurso.IdCentro;
            newCurso.NombreCurso = requestCurso.NombreCurso;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCursoAsync(int idCurso)
        {
            Curso curso = await this.FindCursoAsync(idCurso);
            this.context.Cursos.Remove(curso);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region CURSOS PROFESORES

        public async Task<List<CursosProfesores>> GetCursosProfesoresAsync()
        {
            return await this.context.CursosProfesores.ToListAsync();
        }

        public async Task<CursosProfesores>
            FindCursosProfesoresAsync(int idcurso, int idprofesor)
        {
            return await
                this.context.CursosProfesores
                .FirstOrDefaultAsync(x => x.IdCurso == idcurso && 
                x.IdProfesor == idprofesor);
        }

        //private async Task<int> GetMaxIdCursosProfesores()
        //{
        //    if (this.context.CursosProfesores.Count() == 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return await
        //            this.context.CursosProfesores.MaxAsync(z => z.IdCurso) + 1;
        //    }
        //}

        public async Task<CursosProfesores> InsertCursosProfesoresAsync
            (int idcurso, int idprofesor)
        {
            CursosProfesores newCurso = new CursosProfesores();
            newCurso.IdCurso = idcurso;
            newCurso.IdProfesor = idprofesor;
            this.context.CursosProfesores.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateProfesorCursosProfesoresAsync
            (int idcurso, int idprofesor, int newIdProfesor)
        {
            CursosProfesores newCurso =
                await this.FindCursosProfesoresAsync
                (idcurso, idprofesor);
            newCurso.IdProfesor = newIdProfesor;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCursosProfesoresAsync(int idCurso
            , int idProfesor)
        {
            CursosProfesores curso =
                await this.FindCursosProfesoresAsync
                    (idCurso, idProfesor);
            this.context.CursosProfesores.Remove(curso);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region EMPRESASCENTROS

        public async Task<List<EmpresasCentros>> GetEmpresasCentrosAsync()
        {
            return await this.context.EmpresasCentros.ToListAsync();
        }

        public async Task<EmpresasCentros>
            FindEmpresasCentrosAsync(int idempresacentro)
        {
            return await
                this.context.EmpresasCentros
                .FirstOrDefaultAsync(x => x.IdEmpresaCentro == idempresacentro);
        }

        private async Task<int> GetMaxIdEmpresasCentros()
        {
            if (this.context.EmpresasCentros.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.EmpresasCentros.MaxAsync(z => z.IdEmpresaCentro) + 1;
            }
        }

        public async Task<EmpresasCentros> InsertEmpresasCentrosAsync
            (EmpresasCentros requestEmpresasCentros)
        {
            EmpresasCentros newEmpresasCentros = new EmpresasCentros();
            newEmpresasCentros.IdEmpresaCentro = await this.GetMaxIdEmpresasCentros();
            newEmpresasCentros.Cif = requestEmpresasCentros.Cif;
            newEmpresasCentros.Direccion = requestEmpresasCentros.Direccion;
            newEmpresasCentros.IdProvincia = requestEmpresasCentros.IdProvincia;
            newEmpresasCentros.IdTipoEmpresa = requestEmpresasCentros.IdTipoEmpresa;
            newEmpresasCentros.Nombre = requestEmpresasCentros.Nombre;
            newEmpresasCentros.PersonaContacto = requestEmpresasCentros.PersonaContacto;
            newEmpresasCentros.RazonSocial = requestEmpresasCentros.RazonSocial;
            newEmpresasCentros.Telefono = requestEmpresasCentros.Telefono;
            this.context.EmpresasCentros.Add(newEmpresasCentros);
            await this.context.SaveChangesAsync();
            return newEmpresasCentros;
        }

        public async Task UpdateEmpresasCentrosAsync
           (EmpresasCentros requestEmpresasCentros)
        {
            EmpresasCentros newEmpresasCentros =
                await this.FindEmpresasCentrosAsync(requestEmpresasCentros.IdEmpresaCentro);
            newEmpresasCentros.Cif = requestEmpresasCentros.Cif;
            newEmpresasCentros.Direccion = requestEmpresasCentros.Direccion;
            newEmpresasCentros.IdProvincia = requestEmpresasCentros.IdProvincia;
            newEmpresasCentros.IdTipoEmpresa = requestEmpresasCentros.IdTipoEmpresa;
            newEmpresasCentros.Nombre = requestEmpresasCentros.Nombre;
            newEmpresasCentros.PersonaContacto = requestEmpresasCentros.PersonaContacto;
            newEmpresasCentros.RazonSocial = requestEmpresasCentros.RazonSocial;
            newEmpresasCentros.Telefono = requestEmpresasCentros.Telefono;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCursoAsync(int idEmpresaCentro)
        {
            EmpresasCentros newEmpresasCentros =
                await this.FindEmpresasCentrosAsync(idEmpresaCentro);
            this.context.EmpresasCentros.Remove(newEmpresasCentros);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region ESTADOSCHARLAS

        public async Task<List<EstadosCharla>> GetEstadosCharlaAsync()
        {
            return await this.context.EstadosCharlas.ToListAsync();
        }

        public async Task<EstadosCharla>
            FindEstadosCharlaAsync(int id)
        {
            return await
                this.context.EstadosCharlas
                .FirstOrDefaultAsync(x => x.IdEstadosCharla == id);
        }

        private async Task<int> GetMaxEstadosCharla()
        {
            if (this.context.EstadosCharlas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.EstadosCharlas.MaxAsync(z => z.IdEstadosCharla) + 1;
            }
        }

        public async Task<EstadosCharla> InsertEstadosCharlaAsync
            (EstadosCharla requestEstadosCharla)
        {
            EstadosCharla newCurso = new EstadosCharla();
            newCurso.IdEstadosCharla = await this.GetMaxEstadosCharla();
            newCurso.Tipo = requestEstadosCharla.Tipo;
            this.context.EstadosCharlas.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateEstadosCharlaAsync
           (EstadosCharla requestEstadosCharla)
        {
            EstadosCharla newCurso = await 
                this.FindEstadosCharlaAsync(requestEstadosCharla.IdEstadosCharla);
            newCurso.Tipo = requestEstadosCharla.Tipo;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteEstadosCharlaAsync(int idEstadosCharla)
        {
            EstadosCharla estadoCharla = await
                this.FindEstadosCharlaAsync(idEstadosCharla);
            this.context.EstadosCharlas.Remove(estadoCharla);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region ESTADOSVALIDACION

        public async Task<List<EstadosValidacion>> GetEstadosValidacionAsync()
        {
            return await this.context.EstadosValidacion.ToListAsync();
        }

        public async Task<EstadosValidacion>
            FindEstadosValidacionAsync(int id)
        {
            return await
                this.context.EstadosValidacion
                .FirstOrDefaultAsync(x => x.IdEstadoValidacion == id);
        }

        private async Task<int> GetMaxEstadosValidacion()
        {
            if (this.context.EstadosValidacion.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.EstadosValidacion.MaxAsync(z => z.IdEstadoValidacion) + 1;
            }
        }

        public async Task<EstadosValidacion> InsertEstadosValidacionAsync
            (EstadosValidacion requestEstadosValidacion)
        {
            EstadosValidacion newCurso = new EstadosValidacion();
            newCurso.IdEstadoValidacion = await this.GetMaxEstadosValidacion();
            newCurso.NombreEstado = requestEstadosValidacion.NombreEstado;
            this.context.EstadosValidacion.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateEstadosValidacionAsync
           (EstadosValidacion requestEstadosValidacion)
        {
            EstadosValidacion newCurso = await
                this.FindEstadosValidacionAsync(requestEstadosValidacion.IdEstadoValidacion);
            newCurso.NombreEstado = requestEstadosValidacion.NombreEstado;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteEstadosValidacionAsync(int idEstadosValidacion)
        {
            EstadosValidacion estadoCharla = await
                this.FindEstadosValidacionAsync(idEstadosValidacion);
            this.context.EstadosValidacion.Remove(estadoCharla);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES

        public async Task<List<Peticion>> GetPeticionesAsync()
        {
            return await this.context.Peticiones.ToListAsync();
        }

        public async Task<Peticion>
            FindPeticionAsync(int id)
        {
            return await
                this.context.Peticiones
                .FirstOrDefaultAsync(x => x.IdPeticion == id);
        }

        private async Task<int> GetMaxPeticion()
        {
            if (this.context.Peticiones.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Peticiones.MaxAsync(z => z.IdPeticion) + 1;
            }
        }

        public async Task<Peticion> InsertPeticionAsync
            (Peticion requestPeticion)
        {
            Peticion newPeticion = new Peticion();
            newPeticion.IdPeticion = await this.GetMaxPeticion();
            newPeticion.IdGeneral = requestPeticion.IdGeneral;
            newPeticion.FechaPeticion = requestPeticion.FechaPeticion;
            newPeticion.Descripcion = requestPeticion.Descripcion;
            newPeticion.TipoPeticion = requestPeticion.TipoPeticion;
            this.context.Peticiones.Add(newPeticion);
            await this.context.SaveChangesAsync();
            return newPeticion;
        }

        public async Task UpdatePeticionAsync
            (Peticion requestPeticion)
        {
            Peticion newPeticion = await this.FindPeticionAsync(requestPeticion.IdPeticion);
            newPeticion.IdGeneral = requestPeticion.IdGeneral;
            newPeticion.FechaPeticion = requestPeticion.FechaPeticion;
            newPeticion.Descripcion = requestPeticion.Descripcion;
            newPeticion.TipoPeticion = requestPeticion.TipoPeticion;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionAsync(int idPeticion)
        {
            Peticion peticion = await
                this.FindPeticionAsync(idPeticion);
            this.context.Peticiones.Remove(peticion);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES ALTA USERS

        public async Task<List<PeticionAltaUsers>> 
            GetPeticionesAltaUsersAsync()
        {
            return await this.context.PeticionesAltaUsers.ToListAsync();
        }

        private async Task<int> GetMaxPeticionAltaUsers()
        {
            if (this.context.PeticionesAltaUsers.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesAltaUsers.MaxAsync(z => 
                    z.IdPeticionAltaUsers) + 1;
            }
        }

        public async Task<PeticionAltaUsers>
            FindPeticionesAltaUsersAsync(int idpeticion)
        {
            return await
                this.context.PeticionesAltaUsers
                .FirstOrDefaultAsync(x => x.IdPeticionAltaUsers == idpeticion);
        }

        public async Task<List<PeticionAltaUsers>>
            FindPeticionesAltaUsuarioAsync(int iduser)
        {
            return await
                this.context.PeticionesAltaUsers
                .Where(x => x.IdUser == iduser).ToListAsync();
        }


        public async Task<PeticionAltaUsers> InsertPeticionAltaUsersAsync
            (int idpeticion, int iduser)
        {
            PeticionAltaUsers newCurso = new PeticionAltaUsers();
            newCurso.IdPeticionAltaUsers = idpeticion;
            newCurso.IdUser = iduser;
            this.context.PeticionesAltaUsers.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task DeletePeticionAltaUsersAsync
             (int idpeticion, int iduser)
        {
            PeticionAltaUsers peticionuser = await
                this.FindPeticionesAltaUsersAsync(idpeticion);
            this.context.PeticionesAltaUsers.Remove(peticionuser);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES CATEGORIAS

        public async Task<List<PeticionCategorias>> GetPeticionCategoriasAsync()
        {
            return await this.context.PeticionesCategorias.ToListAsync();
        }

        public async Task<PeticionCategorias>
            FindPeticionCategoriasAsync(int id)
        {
            return await
                this.context.PeticionesCategorias
                .FirstOrDefaultAsync(x => x.IdPeticionCategorias == id);
        }

        private async Task<int> GetMaxPeticionCategorias()
        {
            if (this.context.PeticionesCategorias.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesCategorias.MaxAsync
                    (z => z.IdPeticionCategorias) + 1;
            }
        }

        public async Task<PeticionCategorias> InsertPeticionCategoriasAsync
            (PeticionCategorias requestPeticionCategorias)
        {
            PeticionCategorias newPeticionCategorias = new PeticionCategorias();
            newPeticionCategorias.IdPeticionCategorias = await this.GetMaxPeticionCategorias();
            newPeticionCategorias.Categoria = requestPeticionCategorias.Categoria;
            this.context.PeticionesCategorias.Add(newPeticionCategorias);
            await this.context.SaveChangesAsync();
            return newPeticionCategorias;
        }

        public async Task UpdatePeticionCategoriasAsync
           (PeticionCategorias requestPeticionCategorias)
        {
            PeticionCategorias newPeticionCategorias = await
                this.FindPeticionCategoriasAsync
                (requestPeticionCategorias.IdPeticionCategorias);
            newPeticionCategorias.Categoria = requestPeticionCategorias.Categoria;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionCategoriasAsync(int idnewPeticionCategorias)
        {
            PeticionCategorias peticionCategorias = await
                this.FindPeticionCategoriasAsync(idnewPeticionCategorias);
            this.context.PeticionesCategorias.Remove(peticionCategorias);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES CENTRO EMPRESA

        public async Task<List<PeticionCentroEmpresa>> GetPeticionCentroEmpresaAsync()
        {
            return await this.context.PeticionesCentroEmpresa.ToListAsync();
        }

        public async Task<PeticionCentroEmpresa>
            FindPeticionCentroEmpresaAsync(int id)
        {
            return await
                this.context.PeticionesCentroEmpresa
                .FirstOrDefaultAsync(x => x.IdPeticionCentroEmpresa == id);
        }

        private async Task<int> GetMaxPeticionCentroEmpresa()
        {
            if (this.context.PeticionesCentroEmpresa.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesCentroEmpresa.MaxAsync
                    (z => z.IdPeticionCentroEmpresa) + 1;
            }
        }

        public async Task<PeticionCentroEmpresa> InsertPeticionCentroEmpresaAsync
            (PeticionCentroEmpresa requestPeticionCentroEmpresa)
        {
            PeticionCentroEmpresa newPeticionCentroEmpresa = new PeticionCentroEmpresa();
            newPeticionCentroEmpresa.IdPeticionCentroEmpresa = 
                await this.GetMaxPeticionCentroEmpresa();
            newPeticionCentroEmpresa.IdCentroEmpresa = requestPeticionCentroEmpresa.IdCentroEmpresa
            this.context.PeticionesCentroEmpresa.Add(newPeticionCentroEmpresa);
            await this.context.SaveChangesAsync();
            return newPeticionCentroEmpresa;
        }

        public async Task UpdatePeticionCentroEmpresaAsync
           (PeticionCentroEmpresa requestPeticionCentroEmpresa)
        {
            PeticionCentroEmpresa newPeticionCentroEmpresa = await
                this.FindPeticionCentroEmpresaAsync
                (requestPeticionCentroEmpresa.IdPeticionCentroEmpresa);
            newPeticionCentroEmpresa.IdCentroEmpresa = requestPeticionCentroEmpresa.IdCentroEmpresa;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionCentroEmpresaAsync(int idPeticionCentroEmpresa)
        {
            PeticionCentroEmpresa peticionCentroEmpresa = await
                this.FindPeticionCentroEmpresaAsync(idPeticionCentroEmpresa);
            this.context.PeticionesCentroEmpresa.Remove(peticionCentroEmpresa);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES CHARLA

        public async Task<List<PeticionCharla>> GetPeticionCharlaAsync()
        {
            return await this.context.PeticionesCharlas.ToListAsync();
        }

        public async Task<PeticionCharla>
            FindPeticionCharlaAsync(int id)
        {
            return await
                this.context.PeticionesCharlas
                .FirstOrDefaultAsync(x => x.IdPeticionCharla == id);
        }

        private async Task<int> GetMaxPeticionCharla()
        {
            if (this.context.PeticionesCharlas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesCharlas.MaxAsync
                    (z => z.IdPeticionCharla) + 1;
            }
        }

        public async Task<PeticionCharla> InsertPeticionCharlaAsync
            (PeticionCharla requestPeticionCharla)
        {
            PeticionCharla newPeticionCharla = new PeticionCharla();
            newPeticionCharla.IdPeticionCharla =
                await this.GetMaxPeticionCharla();
            newPeticionCharla.IdCharla = requestPeticionCharla.IdCharla;
            this.context.PeticionesCharlas.Add(newPeticionCharla);
            await this.context.SaveChangesAsync();
            return newPeticionCharla;
        }

        public async Task UpdatePeticionCharlaAsync
           (PeticionCharla requestPeticionCharla)
        {
            PeticionCharla newPeticionCharla = await
                this.FindPeticionCharlaAsync
                (requestPeticionCharla.IdPeticionCharla);
            newPeticionCharla.IdCharla = requestPeticionCharla.IdCharla;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionCharlaAsync(int idPeticionCharla)
        {
            PeticionCharla peticionCharla = await
                this.FindPeticionCharlaAsync(idPeticionCharla);
            this.context.PeticionesCharlas.Remove(peticionCharla);
            await this.context.SaveChangesAsync();
        }

        #endregion
    }
}
