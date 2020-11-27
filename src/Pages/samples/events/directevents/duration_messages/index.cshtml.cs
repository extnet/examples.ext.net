using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.events.directevents.duration_messages
{
    [DirectModel]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostDoSomething()
        {
            System.Threading.Thread.Sleep(8000);
            return this.Direct();
        }

        [Direct]
        public IActionResult OnPostSomeDirectMethod()
        {
            System.Threading.Thread.Sleep(8000);
            return this.Direct();
        }
    }
}
