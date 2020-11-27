using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.layout.tablelayout.simple_in_codebehind
{
    public class IndexModel : PageModel
    {
        public Viewport Viewport1;

        public void OnGet()
        {
            // Build all the Panels which will fill the Table Cells.
            var panel1 = new Panel
            {
                Title = "Lots of Spanning",
                Height = 320,
                Html = "Row spanning",
                CustomConfig = new JsObject
                {
                    { "rowspan", 3 }
                }
            };

            // panel1.CustomConfig = new JsObject();
            // panel1.CustomConfig.Add("rowspan", new JsObject(3));

            var panel2 = new Panel
            {
                Title = "Basic Table Cell",
                Height = 105,
                Html = "Basic panel in a table cell"
            };

            var panel3 = new Panel
            {
                Header = false,
                Height = 105,
                Html = "Plain panel"
            };

            var panel4 = new Panel
            {
                Title = "Another Cell",
                Width = 480,
                Height = 220,
                Html = "Row spanning",
                CustomConfig = new JsObject
                {
                    { "rowspan", 2 }
                }
            };

            var panel5 = new Panel
            {
                Height = 100,
                Html = "Plain cell spanning two columns",
                CustomConfig = new JsObject
                {
                    { "colspan", 2 }
                }
            };

            var panel6 = new Panel
            {
                Title = "More Column Spanning",
                Height = 85,
                Html = "Spanning three columns",
                CustomConfig = new JsObject
                {
                    { "colspan", 3 }
                }
            };

            var panel7 = new Panel
            {
                Title = "Spanning All Columns",
                Html = "Spanning all columns",
                CustomConfig = new JsObject
                {
                    { "colspan", 4 }
                }
            };


            var pnlTableLayout = new Panel
            {
                Id = "pnlTableLayout",
                Region = RegionType.Center,
                Title = "Table Layout",
                Frame = true,
                BodyPadding = 18,
                Layout = new TableLayout
                {
                    Columns = 4
                },
                Defaults = new JsObject
                {
                    { "bodyPadding", new JsObject(18) },
                    { "frame", new JsObject(true) }
                },
                Items =
                {
                    panel1,
                    panel2,
                    panel3,
                    panel4,
                    panel5,
                    panel6,
                    panel7
                }
            };

            Viewport1 = new Viewport
            {
                Layout = LayoutType.Border,
                Items =
                {
                    pnlTableLayout
                }
            };
        }
    }
}
