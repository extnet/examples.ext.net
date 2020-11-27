using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Ext.Net.Core;
using System.Text;

namespace Ext.Net.Examples.Pages.samples.layout.vboxlayout.vbox_form
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostSendClick()
        {
            this.X().Msg().Alert("Send To", "Button Clicked", null);

            // if (this.SendTo.SelectedItems.Count > 0)
            // {
            //     StringBuilder sb = new StringBuilder();

            //     foreach (Ext.Net.ListItem item in this.SendTo.SelectedItems)
            //     {
            //         sb.Append(item.Value).Append("<br/>");
            //     }

            //     this.X().Msg.Alert("Send to", sb.ToString()).Show();
            // }
            // else
            // {
            //     this.X().Msg.Alert("Send To", "No emails").Show();
            // }

            return this.Direct();
        }
    }
}
