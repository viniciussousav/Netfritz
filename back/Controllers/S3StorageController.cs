using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Repositories.Fitas;
using Netfritz.Services;

namespace Netfritz.Controllers
{
    public class S3StorageController
    {
        private readonly IFitaRepository _fitaRepository;
        private readonly S3StorageService _s3StorageService;

        public S3StorageController(IFitaRepository fitaRepository)
        {
            _fitaRepository = fitaRepository;
            _s3StorageService = S3StorageService.GetInstance();
        }
        
        public async Task<IActionResult> UploadImagem (string fitaId, IFormFile file)
        {
            var fita = _fitaRepository
                .GetFitas()
                .FirstOrDefault(f => f.Id == fitaId);
            
            if (fita is null)
            {
                return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
            }
            
            var url = await _s3StorageService.UploadImagem(file, fitaId);
            fita.imagemUrl = url;
            _fitaRepository.Atualizar(fita);

            return Response.CreateResponse(fita, StatusCodes.Status200OK);
        } 
    }
}