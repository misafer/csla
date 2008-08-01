﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DataBinding.Business;
using Csla;

namespace DataBinding.Test
{
  public partial class Page : UserControl
  {
    public Page()
    {
      InitializeComponent();
    }

    private void FetchComplete(object sender, DataPortalResult<CustomerList> result)
    {
      this.DataContext = result.Object;
    }

    private void fetch_Click(object sender, RoutedEventArgs e)
    {
      CustomerList.FetchByName(null, FetchComplete);
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      Customer selected = null;
      if (e.AddedItems.Count > 0)
      {
        selected = (Customer)e.AddedItems[0];
      }

      details.Content = selected;
    }
  }
}