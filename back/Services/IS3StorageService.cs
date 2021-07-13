using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Netfritz.Services
{
    public interface IS3StorageService
    {
        Task<string> UploadImagem(IFormFile file, string fitaId);
    }
}