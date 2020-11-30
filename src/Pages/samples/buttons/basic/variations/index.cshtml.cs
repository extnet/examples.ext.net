using Ext.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Net.Examples.Pages.samples.buttons.basic.variations
{
    public class IndexModel : PageModel
    {
        public Container Samples { get; set; }

        public void OnGet()
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
                    Build = btn => { btn.IconCls = "x-md md-icon-check-circle-outline"; }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (left) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = Dock.Left;
                    }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (top) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = Dock.Top;
                    }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (right) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = Dock.Right;
                    }
                },
                new ButtonSectionBuilder
                {
                    Name = "Icon (bottom) and Text",
                    Build = btn =>
                    {
                        btn.IconCls = "x-md md-icon-check-circle-outline";
                        btn.IconAlign = Dock.Bottom;
                    }
                }
            };

            Samples = new Container()
            {
                Layout = LayoutType.VBox,
                Items = new ItemCollection<Component>() { }
            };

            var buttonSampleList = new List<Container>()
            {
                AddButtonSample("Normal Buttons", btnBuilders, new Button { Cls = "floater" }),
                AddButtonSample("Toggle Buttons", btnBuilders, new Button { Cls = "floater", EnableToggle = true }),
                AddButtonSample("Menu Buttons", btnBuilders, new Button { Cls = "floater" }, true),
                AddButtonSample("Split Buttons", btnBuilders, new SplitButton { Cls = "floater" }, true),
                AddButtonSample("Menu Buttons (Arrow on bottom)", btnBuilders, new Button { Cls = "floater", ArrowAlign = "bottom" }, true),
                AddButtonSample("Split Buttons (Arrow on bottom)", btnBuilders, new SplitButton { Cls = "floater", ArrowAlign = "bottom" }, true),
                AddButtonSample("Text align: left", btnBuilders, new Button { Cls = "floater", TextAlign = "left", Width = 200 }),
                AddButtonSample("Text align: right", btnBuilders, new Button { Cls = "floater", TextAlign = "right", Width = 200 }),
                AddButtonSample("Href Buttons", btnBuilders, new Button { Cls = "floater", Href = "https://ext.net/" })
            };

            foreach (var sample in buttonSampleList)
            {
                Samples.Items.Add(sample);
            }
        }

        private Container AddButtonSample(string title, ButtonSectionBuilder[] btnBuilders, Button btnTemplate, bool menu = false)
        {
            var samplesContainer = new Container();

            samplesContainer.Items.Add(new Component() { Html = $"<h2>{title}</h2>" });

            foreach (var btnBuilder in btnBuilders)
            {
                samplesContainer.Items.Add(new Component() { Html = $"<h4>{btnBuilder.Name}</h4>" });

                var buttonCluster = new Container() { Layout = LayoutType.HBox };

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
                            Items = new[]
                            {
                                new MenuItem{ Text = "Menu Item 1", IconCls = "x-md md-icon-check-circle-outline" },
                                new MenuItem{ Text = "Menu Item 2", IconCls = "x-md md-icon-check-circle-outline" },
                                new MenuItem{ Text = "Menu Item 3", IconCls = "x-md md-icon-check-circle-outline" }
                            }
                        };
                    }

                    // Add the button to the section
                    buttonCluster.Items.Add(btn);
                }

                // Add the section to the sample
                samplesContainer.Items.Add(buttonCluster);
            }

            return samplesContainer;
        }
    }

    public class ButtonSample
    {
        public string Title { get; set; }

        public List<ButtonSection> Sections { get; set; } = new List<ButtonSection>();
    }

    public class ButtonSection
    {
        public string Name { get; set; }

        public List<Button> Buttons { get; set; } = new List<Button>();
    }

    public class ButtonSectionBuilder
    {
        public string Name { get; set; }

        public Action<Button> Build { get; set; }
    }
}
