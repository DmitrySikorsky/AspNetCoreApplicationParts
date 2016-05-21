// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNetCoreApplicationParts.ModuleA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApplicationParts.ModuleA
{
  public class ModuleAController : Controller
  {
    public ActionResult Index()
    {
      return this.View(new SomeViewModel());
    }
  }
}