using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Net.Examples.Pages.samples.kitchen_sink.gridpanels.grouped_header_gridpanel
{
    public class IndexModel : PageModel
    {
        private string Now() => DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt");

        public List<object> Data
        {
            get => new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03, Now() },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, Now() },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, Now() },
                new object[] { "American Express Company", 52.55, 0.01, 0.02, Now() },
                new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49, Now() },
                new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, Now() },
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71, Now() },
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, Now() },
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, Now() },
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, Now() },
                new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, Now() },
                new object[] { "General Electric Company", 34.14, -0.08, -0.23, Now() },
                new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, Now() },
                new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, Now() },
                new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, Now() },
                new object[] { "Intel Corporation", 19.88, 0.31, 1.58, Now() },
                new object[] { "International Business Machines", 81.41, 0.44, 0.54, Now() },
                new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, Now() },
                new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, Now() },
                new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40, Now() },
                new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, Now() },
                new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, Now() },
                new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, Now() },
                new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, Now() },
                new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, Now() },
                new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, Now() },
                new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, Now() },
                new object[] { "Verizon Communications", 35.57, 0.39, 1.11, Now() },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, Now() }
            }.ToList();
        }
        public void OnGet()
        {

        }
    }
}
