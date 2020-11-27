using Ext.Net;
using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Ext.Net.Examples.Pages.samples.window.basic.hello_world
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostShowWindowDirect()
        {
            this.GetCmp<Window>("Window1").Show();

            return this.Direct();
        }
    }
}
