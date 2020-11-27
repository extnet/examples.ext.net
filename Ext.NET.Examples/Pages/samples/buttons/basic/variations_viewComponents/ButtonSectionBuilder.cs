using System;

using Ext.Net;

namespace Ext.Net.Examples.Pages.samples.buttons.basic.variations_viewComponents
{
    public class ButtonSectionBuilder
    {
        public string Name { get; set; }

        public Action<Button> Build { get; set; }
    }
}
