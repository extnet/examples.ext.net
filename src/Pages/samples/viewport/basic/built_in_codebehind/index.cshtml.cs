using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.viewport.basic.built_in_codebehind
{
    public class IndexModel : PageModel
    {
        public Viewport Viewport1;

        public void OnGet()
        {
            // Center Region
            var center = new TabPanel
            {
                Region = RegionType.Center,
                Rounded = false,
                ActiveTab = 0,
                Items =
                {
                    new Panel
                    {
                        Title = "Center",
                        BodyPadding = 18,
                        Html = "<h1>Viewport with BorderLayout</h1>"
                    },
                    new Panel
                    {
                        Title = "Close Me",
                        Closable = true,
                        BodyPadding = 18,
                        Html = "Closable Tab"
                    }
                }
            };

            // South Region
            var north = new Panel
            {
                Title = "North",
                Region = RegionType.North,
                Rounded = false,
                Height = 180,
                BodyPadding = 18,
                Html = "North",
                Collapsible = true
            };

            // East Region
            var east = new Panel
            {
                Title = "East",
                Region = RegionType.East,
                Layout = LayoutType.Fit,
                Rounded = false,
                Width = 270,
                MinWidth = 180,
                Collapsible = true,
                Items =
                {
                    new TabPanel
                    {
                        ActiveTab = 1,
                        TabPosition = Dock.Bottom,
                        Rounded = false,
                        Items =
                        {
                            new Panel
                            {
                                Title = "Tab 1",
                                BodyPadding = 18,
                                Html = "East Tab 1"
                            },
                            new Panel
                            {
                                Title = "Tab 2",
                                BodyPadding = 18,
                                Html = "East Tab 2",
                                Closable = true
                            }
                        }
                    }
                }
            };

            // West Region
            var west = new Panel
            {
                Title = "West",
                Region = RegionType.West,
                Rounded = false,
                Width = 270,
                Layout = LayoutType.Accordion,
                MinWidth = 180,
                MaxWidth = 360,
                Collapsible = true,
                Items =
                {
                    new Panel
                    {
                        Title = "Navigation",
                        BodyPadding = 18,
                        Html = "West"
                    },
                    new Panel
                    {
                        Title = "Settings",
                        BodyPadding = 18,
                        Html = "Some settings in here"
                    }
                }
            };

            // Viewport
            Viewport1 = new Viewport
            {
                Layout = LayoutType.Border,
                Items =
                {
                    center,
                    north,
                    east,
                    west,
                    new Panel
                    {
                        Title = "South",
                        Region = RegionType.South,
                        Rounded = false,
                        Height = 180,
                        BodyPadding = 18,
                        Html = "South",
                        Collapsible = true
                    }
                }
            };
        }
    }
}
