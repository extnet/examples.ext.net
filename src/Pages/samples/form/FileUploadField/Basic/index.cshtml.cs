using Ext.Net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Cryptography;

namespace Ext.Net.Examples.Pages.samples.form.fileuploadfield.basic
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostUploadClick(IFormFile file, string desc)
        {
            if (file == null)
            {
                this.X().Toast("No file specified.");
            }
            else
            {
                // Fake some processing...
                System.Threading.Thread.Sleep(2000);

                var md5SumBytes = MD5.Create().ComputeHash(file.OpenReadStream());
                var md5SumHash = BitConverter.ToString(md5SumBytes).Replace("-", "").ToLower();

                var toast = new Toast()
                {
                    Title = "Upload complete",
                    Html = "<b>Upload processed for file:</b><br />" +
                        "<b>Name:</b> " + file.FileName + "<br />" +
                        "<b>Description:</b> " + desc + "<br />" +
                        "<b>Size:</b> " + file.Length + " bytes<br />" +
                        "<b>MD5 sum:</b> " + md5SumHash,
                    AutoClose = false,
                    Closable = true,
                    Modal = true,
                    Anchor = "BasicForm"
                };

                toast.Show();
                this.Render(toast);
            }
            
            return this.Direct();
        }
    }
}
