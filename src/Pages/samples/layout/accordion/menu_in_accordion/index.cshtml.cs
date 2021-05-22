using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Ext.Net.Examples.Pages.samples.layout.accordion.menu_in_accordion
{
    public class IndexModel : PageModel
    {
        public List<Menu> Menus = new List<Menu>();
        public Panel AccordionPanel;

        private string[] IconClses = new string[] { "home", "analytics", "api", "toll", "build", "book", "help", "gavel", "https", "support", "verified" };

        public void OnGet()
        {
            AccordionPanel = new Panel()
            {
                Frame = true,
                Layout = LayoutType.Accordion,
                Scrollable = true,
                Title = "Accordion Panel 2",
                Width = 240
            };

            var menuPanel = new Panel()
            {
                CustomConfig = new JsObject(),
                Title = "File"
            };

            menuPanel.CustomConfig.Add("xtype", "netmenupanel");
            menuPanel.CustomConfig.Add("menu", new JsObject(SubItem(null, 10)));
            AccordionPanel.Items.Add(menuPanel);

            menuPanel = new Panel()
            {
                Title = "Edit",
                CustomConfig = new JsObject()
            };

            menuPanel.CustomConfig.Add("xtype", "netmenupanel");
            menuPanel.CustomConfig.Add("menu", new JsObject(SubItem(null, 4)));
            AccordionPanel.Items.Add(menuPanel);

            Menus.Add(SubItem("File", 10));
            Menus.Add(SubItem("Edit", 4));
            Menus.Add(SubItem("Options", 8));
            Menus.Add(SubItem("About", 3));
        }

        private Menu SubItem(string name, int subCount)
        {
            var menu = new Menu()
            {
                Title = name
            };

            for (var cnt = 1; cnt <= subCount; cnt++)
            {
                menu.Items.Add(new MenuItem()
                {
                    Text = "Item #" + cnt,
                    IconCls = "x-md md-icon-" + IconClses[cnt % IconClses.Length]
                });
            }

            return menu;
        }
    }
}
