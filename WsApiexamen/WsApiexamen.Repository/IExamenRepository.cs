using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsApiexamen.Models.Catalog;

namespace WsApiexamen.Repository
{
    public interface IExamenRepository
    {
        Task<int> AgregarExamen(ExamenModels models);
        Task<bool> ActualizarExamen(ExamenModels models);
        Task<bool> EliminarExamen(int id);
        Task<List<ExamenModels>> ConsultarExamen();
        Task<List<ExamenModels>> ConsultarExamen(ExamenModels modelo);
    }
}
