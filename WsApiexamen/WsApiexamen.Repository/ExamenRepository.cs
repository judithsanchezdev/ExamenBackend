
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsApiexamen.Models.Catalog;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace WsApiexamen.Repository
{
    public class ExamenRepository : IExamenRepository
    {
        private readonly clsExamenDBContext _clsExamenDBContext;
        public ExamenRepository(clsExamenDBContext examenDbContex)
        {
            this._clsExamenDBContext = examenDbContex;
        }

        public async Task<int> AgregarExamen(ExamenModels models)
        {

            await _clsExamenDBContext.tblExamen.AddAsync(models);
            await _clsExamenDBContext.SaveChangesAsync();

            return models.IdExamen;

        }

        public async Task<bool> ActualizarExamen(ExamenModels models)
        {
            var entry = _clsExamenDBContext.Attach(models);

            entry.Property(x => x.Nombre).IsModified = true;
            entry.Property(x => x.Nombre).IsModified = true;
            entry.Property(x => x.Descripcion).IsModified = true;

            await _clsExamenDBContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> EliminarExamen(int id)
        {
            var models = new ExamenModels()
            {
                IdExamen = id,
            };

            var entry = _clsExamenDBContext.Attach(models);

            entry.Property(x => x.Activo).IsModified = true;
            await _clsExamenDBContext.SaveChangesAsync();

            _clsExamenDBContext.Entry(models).State = EntityState.Detached;

            return true;

        }

        public async Task<List<ExamenModels>> ConsultarExamen()
        {
            return await _clsExamenDBContext.tblExamen.ToListAsync();
        }
        public async Task<List<ExamenModels>> ConsultarExamen(ExamenModels models) 
        {
            var response = new List<ExamenModels>();

            if (!string.IsNullOrEmpty(models.Nombre))
                return await _clsExamenDBContext.tblExamen.Where(f => f.Nombre == models.Nombre).ToListAsync();
            if (!string.IsNullOrEmpty(models.Descripcion))
                return await _clsExamenDBContext.tblExamen.Where(f => f.Descripcion == models.Descripcion).ToListAsync();
            if (!string.IsNullOrEmpty(models.Codigo))
                return await _clsExamenDBContext.tblExamen.Where(f => f.Codigo == models.Codigo).ToListAsync();
            return response;
        }
    }
}
