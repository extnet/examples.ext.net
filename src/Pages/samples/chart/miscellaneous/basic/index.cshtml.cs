using System;
using System.Collections.Generic;
using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.chart.miscellaneous.basic
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public List<object> ChartData
        {
            get
            {
                var rnd = new Random((int)DateTime.Now.Ticks);

                short nextRnd() => (short)rnd.Next(0, 100);

                return new List<object>
                {
                    new { Name = "Jan", Value = nextRnd() },
                    new { Name = "Feb", Value = nextRnd() },
                    new { Name = "Mar", Value = nextRnd() },
                    new { Name = "Apr", Value = nextRnd() },
                    new { Name = "May", Value = nextRnd() },
                    new { Name = "Jun", Value = nextRnd() },
                    new { Name = "Jul", Value = nextRnd() },
                    new { Name = "Aug", Value = nextRnd() },
                    new { Name = "Oct", Value = nextRnd() },
                    new { Name = "Nov", Value = nextRnd() },
                    new { Name = "Dec", Value = nextRnd() }
                };
            }
        }
    }
}
