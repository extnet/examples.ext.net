using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.layout.accordion.basic_in_codebehind
{
    public class IndexModel : PageModel
    {
        public Window Window1;

        public void OnGet()
        {
            var panel1 = new Panel { Title = "Users" };
            var panel2 = new Panel { Title = "Settings" };
            var panel3 = new Panel { Title = "Security" };
            var panel4 = new Panel { Title = "Documents" };

            var button1 = new Button
            {
                IconCls = "x-md md-icon-add-circle-outline"
            };

            var tooltip = new ToolTip
            {
                Title = "Rich ToolTips",
                Html = "Let your users know what they can do!"
            };

            // button1.Tooltip = tooltip;

            var button2 = new Button
            {
                IconCls = "x-md md-icon-person"
            };

            var button3 = new Button
            {
                IconCls = "x-md md-icon-person"
            };

            var toolbar = new Toolbar
            {
                Items = {
                    button1,
                    button2,
                    button3
                }
            };

            Window1 = new Window
            {
                Title = "Accordion",
                Width = 360,
                Height = 600,
                AutoShow = true,
                Maximizable = true,
                Layout = LayoutType.Accordion,
                Tbar = toolbar,
                Items = {
                    panel1,
                    panel2,
                    panel3,
                    panel4
                }
            };
        }
    }
}
