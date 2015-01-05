using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CyclePaths
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void ModicationCosts(object sender, RoutedEventArgs e)
        {
            Button ModButton = new Button();
            ModButton.Content = "Costs and EC";
            ModButton.Click += ModicationCosts;

            this.Frame.Navigate(typeof(ModificationCosts));
        }

        private void PathType(object sender, RoutedEventArgs e)
        {
            Button StartButton = new Button();
            StartButton.Content = "Path Type";
            StartButton.Click += PathType;

            this.Frame.Navigate(typeof(PathType));

        }
    }
}
