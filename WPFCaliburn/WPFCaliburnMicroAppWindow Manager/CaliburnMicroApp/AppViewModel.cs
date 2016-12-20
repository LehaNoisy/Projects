using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Windows;

namespace CaliburnMicroApp
{
  [Export(typeof(AppViewModel))]
  public class AppViewModel : PropertyChangedBase, IHaveDisplayName
  {
    private string _displayName = "Caliburn Micro Part 5: The Window Manager";

    private readonly IWindowManager _windowManager;

    [ImportingConstructor]
    public AppViewModel(IWindowManager windowManager)
    {
      _windowManager = windowManager;
    }

    public string DisplayName
    {
      get { return _displayName; }
      set { _displayName = value; }
    }

    public void OpenWindow()
    {
      dynamic settings = new ExpandoObject();
      settings.WindowStartupLocation = WindowStartupLocation.Manual;

      _windowManager.ShowWindow(new AppViewModel(_windowManager), null, settings);
    }
  }
}
