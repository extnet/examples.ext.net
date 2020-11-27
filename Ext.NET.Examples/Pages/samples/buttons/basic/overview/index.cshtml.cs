using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Ext.Net.Core;

namespace Ext.Net.Examples.Pages.samples.buttons.basic.overview
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostButton_Click(string item)
        {
            this.X().Toast("Server click 👍");

            return this.Direct();
        }
    }
}
