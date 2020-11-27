using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Ext.Net.Core;

namespace Ext.Net.Examples.Pages.samples.layout.formlayout.login
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostLogin_Click(string username, string password)
        {
            this.GetCmp<Window>("Window1").Hide();

            this.X().Toast("LOGIN SUCCESS");

            string msg = $"<br /><br />Username: {username}<br />Password: {password}";

            this.GetCmp<Label>("lblMessage").Html = msg;

            return this.Direct();
        }
    }
}
