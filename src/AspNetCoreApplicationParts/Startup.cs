// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AspNetCoreApplicationParts
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      PortableExecutableReference reference = MetadataReference.CreateFromFile(@"C:\{PathToTheProject}\AspNetCoreApplicationParts\src\AspNetCoreApplicationParts.ModuleA\bin\Debug\netstandard1.5\AspNetCoreApplicationParts.ModuleA.dll");
      Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\{PathToTheProject}\AspNetCoreApplicationParts\src\AspNetCoreApplicationParts.ModuleA\bin\Debug\netstandard1.5\AspNetCoreApplicationParts.ModuleA.dll");

      services.AddMvc().AddApplicationPart(assembly).AddRazorOptions(
        o =>
        {
          o.FileProviders.Add(new EmbeddedFileProvider(assembly, assembly.GetName().Name));

          Action<RoslynCompilationContext> previous = o.CompilationCallback;

          o.CompilationCallback = c =>
          {
            if (previous != null)
            {
              previous(c);
            }

            c.Compilation = c.Compilation.AddReferences(reference);
          };
        }
      );
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseMvc(routes =>
        {
          routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
        }
      );
    }
  }
}