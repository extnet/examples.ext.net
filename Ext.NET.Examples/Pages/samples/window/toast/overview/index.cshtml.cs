using Ext.Net.Core;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Ext.Net.Examples.Pages.samples.window.toast.overview
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostButton2_Click()
        {
            this.X().Toast("Toast 2");

            return this.Direct();
        }

        public IActionResult OnPostButton3_Click()
        {
            var toast = new Toast
            {
                Id = "Toast1",
                Title = "Toast",
                Align = ToastAlign.B,
                Html = "Toast 3",
                Width = 100
            };

            toast.Show();

            this.Render(toast);

            return this.Direct();
        }

        public IActionResult OnPostButton4_Click()
        {
            var config = new Toast()
            {
                Html = "Toast 4",
                Title = "Toast",
                Align = ToastAlign.R,
                Anchor = "Button4",
                StickWhileHover = true,
                CloseOnMouseDown = true,
                AutoClose = true,
                AutoCloseDelay = 2500,
                Width = 180
            };

            config.Show();
            this.Render(config);

            return this.Direct();
        }
    }
}
