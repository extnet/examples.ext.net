using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.layout.borderlayout.simple_in_codebehind
{
    public class IndexModel : PageModel
    {
        public Window Window1;

        public void OnGet()
        {
            var tabPanel1 = new TabPanel
            {
                Id = "TabPanel1",
                Region = RegionType.Center,
                ActiveTab = 0,
                Rounded = false,
                Plain = true,
                Items = {
                    new Panel
                    {
                        Title = "First Tab",
                        BodyStyle = "padding: 6px;",
                        Html = "First Tab",
                        Rounded = false,
                        BodyPadding = 18
                    },
                    new Panel
                    {
                        Title = "Another Tab",
                        BodyStyle = "padding: 6px;",
                        Html = "Another Tab",
                        Rounded = false,
                        BodyPadding = 18
                    }
                }
            };

            Window1 = new Window
            {
                Id = "Window1",
                Layout = LayoutType.Border,
                Title = "Simple Layout",
                Width = 720,
                Height = 480,
                AutoShow = true,
                Collapsible = true,
                Items = {
                    new Panel
                    {
                        Id = "Panel1",
                        Title = "Navigation",
                        Variant = Variant.Light,
                        Width = 270,
                        Region = RegionType.West,
                        CustomConfig = new JsObject
                        {
                            { "split", true }
                        },
                        Collapsible = true,
                        MinWidth = 175,
                        Rounded = false
                    },
                    tabPanel1
                }
            };
        }
    }
}
