using Ext.Net.Core;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.layout.cardlayout.basic
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostNext_Click(int index, int count, Panel panel, Button btnPrev, Button btnNext)
        {
            if ((index + 1) < count)
            {
                panel.ActiveItem = index + 1;
                this.X().Toast($"index: {index + 1}, count: {count}");
            }

            this.CheckButtons(panel, btnPrev, btnNext, count);

            return this.Direct();
        }

        public IActionResult OnPostPrev_Click(int index, int count, Panel panel, Button btnPrev, Button btnNext)
        {
            if ((index - 1) >= 0)
            {
                this.X().Toast($"index: {index - 1}, count: {count}");
                panel.ActiveItem = index - 1;
            }

            this.CheckButtons(panel, btnPrev, btnNext, count);

            return this.Direct();
        }

        private void CheckButtons(Panel panel, Button btnPrev, Button btnNext, int count)
        {
            var index = panel.ActiveItem
                .As(
                    s => int.Parse(s),  /* string => int */
                    d => (int)d         /* double => int */
                );

            btnNext.Disabled = index == (count - 1);
            btnPrev.Disabled = index == 0;
        }
    }
}
