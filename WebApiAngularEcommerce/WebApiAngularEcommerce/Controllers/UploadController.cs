using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApiAngularEcommerce.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        [Route("api/Upload")]
        public async Task<string> UploadFile()
        {
            var fullPath="";
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;
                    name = name.Trim('"');
                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, name);

                    //var path = File(Server.MapPath($"~/App_Data/{fileName}"), "image/jpeg");
                    File.Move(localFileName, filePath);
                     fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/" + name);

                }
                //var streamProvider = await Request.Content.ReadAsMultipartAsync(); // HERE
                //foreach (var file in streamProvider.Contents)
                //{
                //    var imageFilename = file.Headers.ContentDisposition.FileName.Trim('\"');
                //    var imageStream = await file.ReadAsStreamAsync();
                //}
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

            return fullPath;
        }
    }
}
