using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsApiexamen.Models.Catalog;
using WsApiexamen.Models.System;

namespace WsApiexamen.Domain.Catalog
{
    public interface IExamenDomain
    {
        public Task<ResponseModels> AgregarExamen(ExamenModels models);
        public Task<ResponseModels> ActualizarExamen(ExamenModels models); 
        public Task<ResponseModels> EliminarExamen(int id);
        public Task<List<ExamenModels>> ConsultarExamen();
        public Task<List<ExamenModels>> ConsultarExamen(ExamenModels models);
    }
}
