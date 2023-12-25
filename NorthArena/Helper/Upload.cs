using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace NorthArena.Helper
{

    public static class upload
    {

        [HttpPost, DisableRequestSizeLimit]
        public async static Task<List<string>> UploadImage(HttpRequest Request)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                {
                    var files = Request.Form.Files;
                    var imagesPath = new List<String>();

                    foreach (var file in files)
                    {

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                            imagesPath.Add(dbPath);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                    }
                    return imagesPath;

                }
            }

            catch (Exception ex)
            {
                return new List<string> { "Internal server error" };
            }
        }
    }
}
