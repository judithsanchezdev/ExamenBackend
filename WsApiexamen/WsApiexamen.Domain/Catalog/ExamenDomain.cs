using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WsApiexamen.Models.Catalog;
using WsApiexamen.Models.System;
using WsApiexamen.Repository;

namespace WsApiexamen.Domain.Catalog
{
    public class ExamenDomain : IExamenDomain
    {
        private readonly IExamenRepository _examenRepository;
        public ExamenDomain(IExamenRepository examenRepository) {
            this._examenRepository = examenRepository;
        }

        public async Task<ResponseModels> EliminarExamen(int id)
        {
            var response = new ResponseModels();
            try
            {
               await _examenRepository.EliminarExamen(id);
               response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                throw;
            }
            
            return response;
        }

        public async Task<List<ExamenModels>> ConsultarExamen()
        {
   
           return await _examenRepository.ConsultarExamen();
 
        }

        public async Task<List<ExamenModels>> ConsultarExamen(ExamenModels models)
        {

            return await _examenRepository.ConsultarExamen(models);

        }


        public async Task<ResponseModels> AgregarExamen(ExamenModels models)
        {
            var response = new ResponseModels();
            try
            {
                await _examenRepository.AgregarExamen(models);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                throw;
            }

            return response;
        }

        public async Task<ResponseModels> ActualizarExamen(ExamenModels models)
        {
            var response = new ResponseModels();
            try
            {
                await _examenRepository.ActualizarExamen(models);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                throw;
            }

            return response;
        }
    }
}
