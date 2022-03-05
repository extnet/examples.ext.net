using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

using Amazon;
using Amazon.S3;

using AspNetCore.DataProtection.Aws.S3;

using Ext.Net.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#if DEBUG
using Westwind.AspNetCore.LiveReload;
#endif

namespace Ext.Net.Examples
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDataProtection(services);

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();

                options.MimeTypes = new[]
                {
                    "text/css",
                    "application/javascript",
                    "application/json",
                    "text/json",
                    "application/xml",
                    "text/xml",
                    "text/plain",
                    "image/svg+xml",
                    "application/x-font-ttf"
                };
            });

            var mvcBuilder = services.AddRazorPages();

            // Enable Live reloading/Runtime compilation for Debug configuration only
#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();

            // See https://github.com/RickStrahl/Westwind.AspnetCore.LiveReload
            services.AddLiveReload();
#endif

            // 1. Register Ext.NET services
            services.AddExtNet();
            services.AddExtCharts();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
#if DEBUG
                app.UseLiveReload();
#endif
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseResponseCompression();

            // 2. Use Ext.NET resources
            //    To be added prior to app.UseStaticFiles()
            app.UseExtNetResources("/extnet/" + ExtNetVersion.CacheBuster, cfg =>
            {
#if DEBUG
                cfg.UseDebug(true);
#endif
                cfg.UseEmbedded();
                cfg.UseCharts();
                cfg.UseThemeSpotless();
            });

            // Must come before 'UseRouting()' or /favicon.ico would be unreachable.
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // 3. Enable Ext.NET localization [not required]
            //    If included, localization will be handled automatically
            //    based on client browser preferences
            app.UseExtNetLocalization();

            // 4. Ext.NET middleware
            //    To be added prior to app.UseEndpoints()
            app.UseExtNet(config =>
            {
                config.Theme = ThemeKind.Spotless;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void ConfigureDataProtection(IServiceCollection services)
        {
            var awsRegion = Environment.GetEnvironmentVariable("AWS_REGION");

            var csrfCert = new X509Certificate2("csrf.pfx", "examples-csrf");

            if (!string.IsNullOrEmpty(awsRegion))
            {
                var region = RegionEndpoint.GetBySystemName(awsRegion);
                var s3 = new AmazonS3Client(region);

                services.AddDataProtection()
                    .SetApplicationName("Ext.NET Examples")
                    .ProtectKeysWithCertificate(csrfCert)
                    .PersistKeysToAwsS3(s3, new S3XmlRepositoryConfig
                    {
                        Bucket = "extnet-examples",
                        KeyPrefix = "csrf-keys/",
                    });
            }
            else
            {
                services.AddDataProtection()
                    .SetApplicationName("Ext.NET Examples")
                    .ProtectKeysWithCertificate(csrfCert)
                    .PersistKeysToFileSystem(new DirectoryInfo("./csrf-keys"));
            }
        }
    }
}
