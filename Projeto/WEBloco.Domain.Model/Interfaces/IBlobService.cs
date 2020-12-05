using System.IO;
using System.Threading.Tasks;

namespace WEBloco.Domain.Model.Interfaces
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream blobStream);
    }
}
