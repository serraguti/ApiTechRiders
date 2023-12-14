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
    }
}
