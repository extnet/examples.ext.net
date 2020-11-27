using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples
{
    public class IndexModel : PageModel
    {
        public List<string> Examples { get; private set; } = new List<string>();
        public void OnGet()
        {
            var urlPattern = Path.Combine("Pages", "examples") + Path.DirectorySeparatorChar;

            var filelist = Directory.GetFiles(Directory.GetCurrentDirectory(), "index.cshtml", SearchOption.AllDirectories);

            foreach (var file in filelist)
            {
                var startPos = file.IndexOf(urlPattern) + urlPattern.Length;

                if (startPos < urlPattern.Length) continue;

                var length = file.LastIndexOf("index.cshtml") - startPos;

                if (length < 5) continue;

                Examples.Add(file.Substring(startPos, length).Replace('\\', '/'));
            }

            Examples.Sort();
        }
    }
}
