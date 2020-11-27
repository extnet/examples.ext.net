using System;
using System.Linq;

using Ext.Net;

using Microsoft.AspNetCore.Mvc;

namespace Ext.Net.Examples.Pages.samples.buttons.basic.variations_viewComponents
{
    public class ButtonVariations : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var btnBuilders = new[]
            {
                new ButtonSectionBuilder
                {
                    Name = "Text Only",
                    Build = btn => { }
                },
                new ButtonSectionBuilder
                {
                    Name = "Disabled",
                    Build = btn => { btn.Disabled = true; }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon Only",
                    Build =  btn => { btn.IconCls = "x-md md-icon-check-circle-outline"; }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (left) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = "left";
                    }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (top) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = "top";
                    }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (right) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = "right";
                    }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (bottom) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = "bottom";
                    }
                }
            };

            var samples = new ButtonSample[]
            {
                AddButtonSample("Normal Buttons", btnBuilders, new Button { Cls = "floater" }),
                AddButtonSample("Toggle Buttons", btnBuilders, new Button { Cls = "floater", EnableToggle = true }),
                AddButtonSample("Menu Buttons", btnBuilders, new Button { Cls = "floater" }, true),
                AddButtonSample("Split Buttons", btnBuilders, new SplitButton { Cls = "floater" }, true),
                AddButtonSample("Menu Buttons (Arrow on bottom)", btnBuilders, new Button { Cls = "floater", ArrowAlign = "bottom" }, true),
                AddButtonSample("Split Buttons (Arrow on bottom)", btnBuilders, new SplitButton { Cls = "floater", ArrowAlign = "bottom" }, true),
                AddButtonSample("Text align: left", btnBuilders, new Button { Cls = "floater", TextAlign = "left", Width = 200}),
                AddButtonSample("Text align: right", btnBuilders, new Button { Cls = "floater", TextAlign = "right", Width = 200}),
                AddButtonSample("Href Buttons", btnBuilders, new Button { Cls = "floater", Href = "https://ext.net/"}),
            };

            var res = View(samples);

            return res;
        }

        private ButtonSample AddButtonSample(string title, ButtonSectionBuilder[] btnBuilders, Button btnTemplate, bool menu = false)
        {
            var sample = new ButtonSample
            {
                Title = title
            };

            foreach (var btnBuilder in btnBuilders)
            {
                var section = new ButtonSection
                {
                    Name = btnBuilder.Name
                };

                foreach (var scale in Enum.GetValues(typeof(Scale)).Cast<Scale>())
                {
                    // Clone the model
                    var btn = (Button)btnTemplate.Clone();

                    // Build the default configs
                    btnBuilder.Build(btn);

                    // Set Section specific configs
                    btn.Scale = scale;

                    if (btnBuilder.Name != "Icon Only")
                    {
                        btn.Text = scale.ToString();
                    }

                    if (menu)
                    {
                        btn.Menu = new Menu
                        {
                            Plain = true,
                            Items = new[]
                            {
                                new MenuItem{ Text = "Menu Item 1", IconCls = "x-md md-icon-check-circle-outline" },
                                new MenuItem{ Text = "Menu Item 2", IconCls = "x-md md-icon-check-circle-outline" },
                                new MenuItem{ Text = "Menu Item 3", IconCls = "x-md md-icon-check-circle-outline" }
                            }
                        };
                    }

                    // Add the button to the section
                    section.Buttons.Add(btn);
                }

                // Add the section to the sample
                sample.Sections.Add(section);
            }

            return sample;
        }
    }
}
