// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace AspNetCoreApplicationParts.ModuleA.ViewModels
{
  public class SomeViewModel
  {
    public string Text { get; set; }

    public SomeViewModel()
    {
      this.Text = "Hello from SomeViewModel!";
    }
  }
}