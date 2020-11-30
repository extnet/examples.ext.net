using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.layout.borderlayout.complex_in_codebehind
{
    public class IndexModel : PageModel
    {
        public Window Window1;

        public void OnGet()
        {
            /////////////////
            // WEST REGION //
            /////////////////

            // Make Panel for West Region
            var west = new Panel
            {
                Title = "West",
                Region = RegionType.West,
                Variant = Variant.Light,
                Width = 270,
                MaxWidth = 360,
                Rounded = false,
                Collapsible = true,
                Layout = LayoutType.Accordion
            };

            // Make Navigation Panel for Accordion
            var pnlNavigation = new Panel
            {
                Title = "Navigation",
                BodyPadding = 18,
                Html = "Navigation"
            };

            // Make Settings Panel for Accordion
            var pnlSettings = new Panel
            {
                Title = "Settings",
                BodyPadding = 18,
                Html = "Some settings in here"
            };

            // Add Navigation and Settings Panels to West Panel
            west.Items.Add(pnlNavigation);
            west.Items.Add(pnlSettings);

            ///////////////////
            // CENTER REGION //
            ///////////////////
            // Make TabPanel for Center Region
            var center = new TabPanel
            {
                ActiveTab = 0,
                Region = RegionType.Center,
                Plain = true
            };

            // Make Tab
            var tab1 = new Panel
            {
                Title = "Center Tab 1",
                BodyPadding = 18,
                Html = "Hello ...",
            };

            var tab2 = new Panel
            {
                Title = "Center Tab 2",
                BodyPadding = 18,
                Html = "... World",
            };


            // Add Tab's to TabPanel
            center.Items.Add(tab1);
            center.Items.Add(tab2);

            /////////////////
            // EAST REGION //
            /////////////////

            // Make Panel for East Region
            Panel east = new Panel
            {
                Title = "East",
                Region = RegionType.East,
                Variant = Variant.Light,
                Width = 270,
                MinWidth = 180,
                Rounded = false,
                Layout = LayoutType.Fit,
                Collapsible = true
            };

            // Make TabPanel for East Panel
            TabPanel tpEast = new TabPanel
            {
                ActiveTab = 1,
                TabPosition = Dock.Bottom,
                Plain = true
            };


            // Make Tab 1
            Panel tabEast1 = new Panel
            {
                Title = "Tab 1",
                BodyPadding = 18,
                Html = "East Tab 1"
            };

            // Make Tab 2
            Panel tabEast2 = new Panel
            {
                Title = "Tab 2",
                BodyPadding = 18,
                Html = "East Tab 2",
            };

            // Add Tab's to East TabPanel
            tpEast.Items.Add(tabEast1);
            tpEast.Items.Add(tabEast2);

            // Add FitLayout container to East Panel
            east.Items.Add(tpEast);

            //////////////////
            // SOUTH REGION //
            //////////////////

            // Make Panel for South Region
            Panel south = new Panel
            {
                Title = "South",
                Variant = Variant.Light,
                Rounded = false,
                Height = 180,
                BodyPadding = 18,
                Html = "South",
                Collapsible = true,
                Collapsed = true,
                Region = RegionType.South,
            };

            /////////////////
            // MAIN WINDOW //
            /////////////////

            // Make Window to hold everything
            Window1 = new Window
            {
                Title = "Complex Layout",
                Width = 960,
                Height = 640,
                AutoShow = true,
                Collapsible = true,
                Layout = LayoutType.Border,
                Items =
                {
                    west,
                    east,
                    center,
                    south
                }
            };
        }
    }
}
