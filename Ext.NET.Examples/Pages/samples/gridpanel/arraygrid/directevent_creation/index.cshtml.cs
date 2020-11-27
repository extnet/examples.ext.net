using System;
using System.Collections.Generic;
using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.gridpanel.arraygrid.directevent_creation
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostButton1_Click(Button button, string gridId)
        {
            var grid = this.BuildGridPanel();

            grid.RenderTo = gridId;

            this.Render(grid);

            // Disable the Button
            button.Disabled = true;

            return this.Direct();
        }

        private GridPanel BuildGridPanel()
        {
            return new GridPanel
            {
                Id = "GridPanel1",
                Title = "Dymanic GridPanel",
                Frame = true,
                Width = 960,
                Height = 600,
                Store = this.BuildStore(),
                SelModel = new RowSelectionModel
                {
                    Mode = Mode.SINGLE
                },
                Columns = new List<Column>
                {
                    new Column
                    {
                        Text = "Company",
                        DataIndex = "company",
                        Flex = 1
                    },
                    new Column
                    {
                        Text = "Price",
                        DataIndex = "price",
                        Renderer = "Ext.util.Format.usMoney"
                    },
                    new Column
                    {
                        Text = "Change",
                        DataIndex = "change",
                        Renderer = "change"
                    },
                    new Column
                    {
                        Text = "Change",
                        DataIndex = "pctChange",
                        Renderer = "pctChange"
                    },
                    new DateColumn
                    {
                        Text = "Last Updated",
                        DataIndex = "lastChange",
                        Format = "yyyy-MM-dd",
                        Width = 150,
                    }
                },
                ViewConfig = new TableView
                {
                    StripeRows = true,
                    TrackOver = true
                }
            };
        }

        private Store BuildStore()
        {
            return new Store
            {
                Data = this.Data,
                Fields = new List<DataField>
                {
                    new DataField{ Name = "company" },
                    new NumberDataField { Name = "price" },
                    new NumberDataField { Name = "change" },
                    new NumberDataField { Name = "pctChange" },
                    new DateDataField
                    {
                        Name = "lastChange",
                        DateFormat = "yyyy-MM-dd hh:mm:tt"
                    }
                }
            };
        }

        List<object> Data = new List<object>
        {
            new object[] { "3m Co", 71.72, 0.02, 0.03, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "American Express Company", 52.55, 0.01, 0.02, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Boeing Co.", 75.43, 0.53, 0.71, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "General Electric Company", 34.14, -0.08, -0.23, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Intel Corporation", 19.88, 0.31, 1.58, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "International Business Machines", 81.41, 0.44, 0.54, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "McDonald's Corporation", 36.76, 0.86, 2.40, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Verizon Communications", 35.57, 0.39, 1.11, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") },
            new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt") }
        };
    }
}
