using System.Collections.Generic;
using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ext.Net.Examples.Pages.samples.gridpanel.miscellaneous.reusable_config
{
    public class ReusableGridModel : PageModel
    {
        public virtual IActionResult OnPostHandleGridAdd()
        {
            this.X().Toast("Adding item.");

            return this.Direct();
        }

        public virtual IActionResult OnPostHandleGridRemove(int id)
        {
            this.X().Toast("Removing item: " + id);

            return this.Direct();
        }

        public virtual IActionResult OnPostHandleGridEdit(int id)
        {
            this.X().Toast("Editing item: " + id);

            return this.Direct();
        }

        private GridPanel reusableGrid = null;

        public GridPanel ReusableGrid
        {
            get
            {
                if (reusableGrid != null)
                {
                    return reusableGrid;
                }

                reusableGrid = new GridPanel();
                var gridTopBar = new Toolbar();

                gridTopBar.Items.Add(new Button()
                {
                    Text = "Add",
                    OnDirectClick = "HandleGridAdd"
                });

                var removeBtn = new Button()
                {
                    Text = "Remove"
                };

                string pageHandlerPath(string pageHandler)
                {
                    return HttpContext.Request.Path + "?handler=" + pageHandler;
                };

                void bindPageHandler(DirectEventHandler directEvent, string pageHandler)
                {
                    directEvent.Method = HttpMethod.POST;
                    directEvent.Url = pageHandlerPath(pageHandler);
                    directEvent.Before = new JsFunction("if (!this.up('grid').hasSelection()) { Ext.toast('Please select a record.'); return false; } else { return true; }");
                    directEvent.ExtraParams.Add(new DirectEventParameter()
                    {
                        Key = "id",
                        Value = "function() { var grid = this.up('gridpanel'); if (grid.hasSelection()) return this.up('gridpanel').getSelection()[0].get('id'); }",
                        Mode = ParameterMode.Raw
                    });
                }

                bindPageHandler(removeBtn.DirectEvents.Click, "HandleGridRemove");

                gridTopBar.Items.Add(removeBtn);

                var editBtn = new Button()
                {
                    Text = "Edit"
                };

                bindPageHandler(editBtn.DirectEvents.Click, "HandleGridEdit");

                gridTopBar.Items.Add(editBtn);

                reusableGrid.Tbar = gridTopBar;

                ensureGridStore();

                reusableGrid.Store = this.gridStore;

                return reusableGrid;
            }
        }

        private Store gridStore = null;

        private void ensureGridStore()
        {
            if (this.gridStore == null)
            {
                this.gridStore = new Store();
            }
        }

        protected List<object> ReusableGridData
        {
            get
            {
                ensureGridStore();
                return this.gridStore.Data.As<List<object>>();
            }
            set
            {
                ensureGridStore();
                this.gridStore.Data = value;
            }
        }
    }

    public class IndexModel : ReusableGridModel
    {
        public void OnGet()
        {
            this.ReusableGrid.Title = "Super GridPanel instance";

            // Syntax sugar to feed data to the grid.
            this.ReusableGridData = new List<object>
            {
                new { Id = 1, Name = "Homer" },
                new { Id = 2, Name = "Lisa" },
                new { Id = 3, Name = "Marge" },
                new { Id = 4, Name = "Bart" },
                new { Id = 5, Name = "Maggie" }
            };
        }

        public override IActionResult OnPostHandleGridEdit(int id)
        {
            this.X().Toast("Custom-fashionedly editing item: " + id);

            return this.Direct();
        }
    }
}
