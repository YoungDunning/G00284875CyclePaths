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
    public sealed partial class Paint : Page
    {
        double pathLength, paintEC, paintCost;
        double paintUnitEC = 3.7652, pathWidth = 3, paintUnitCost = 19;

        public Paint()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            txtPaintWidth.Text = pathWidth.ToString();
        }
        private void btnCalc(object sender, RoutedEventArgs e)
        {
            pathLength = Convert.ToDouble(txtPaintDist.Text);

            paintEC = paintUnitEC / 1000 * (pathLength * pathWidth);
            paintCost = paintUnitCost * pathLength * pathWidth;

            txtPaintEC.Text = paintEC.ToString("F2");
            txtPaintCost.Text = paintCost.ToString("c");

        }
        private void mainBtn(object sender, RoutedEventArgs e)
        {
            Button MainPageButton = new Button();
            MainPageButton.Content = "Main Page Button";
            MainPageButton.Click += mainBtn;

            this.Frame.Navigate(typeof(MainPage));
        }

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            Button BackButton = new Button();
            BackButton.Content = "Back Button";
            BackButton.Click += BackBtn;

            this.Frame.Navigate(typeof(Signage));
        }



        private void ComboPaint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
