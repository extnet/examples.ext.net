using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Ext.Net.Core;

namespace Ext.Net.Examples.Pages.samples.window.basic.show
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostButton2_Click()
        {
            this.GetCmp<Window>("Window2").Show();

            return this.Direct();
        }
    }
}
