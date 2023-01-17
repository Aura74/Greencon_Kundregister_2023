using Microsoft.AspNetCore.Components.Forms;

namespace Kundregister.Service.IService
{
    public interface IFileUpload
    {
            Task<string> UploadFile(IBrowserFile file); 
            bool DeleteFile(string filePath);
    }
}
