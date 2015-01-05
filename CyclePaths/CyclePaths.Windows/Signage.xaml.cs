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
    public sealed partial class Signage : Page
    {
        double sign, signEC, signCost;
        double signUnitEC = 29.1, signUnitCost = 205.38;

        public Signage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        public class AnotherPagePayLoad
        {
            public double signEC { get; set; }
            public double signCost { get; set; }
        }
        private void paintBtn(object sender, RoutedEventArgs e)
        {
            Button PaintButton = new Button();
            PaintButton.Content = "Paint Button";
            PaintButton.Click += paintBtn;

            AnotherPagePayLoad payload = new AnotherPagePayLoad();
            payload.signCost = signCost;
            payload.signEC = signEC;

            this.Frame.Navigate(typeof(Paint), payload);
        }

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            Button BackButton = new Button();
            BackButton.Content = "Back Button";
            BackButton.Click += BackBtn;

            this.Frame.Navigate(typeof(Guardrails));
        }



        private void btnCalc(object sender, RoutedEventArgs e)
        {
            sign = Convert.ToDouble(txtSignNum.Text);
            signEC = sign * (signUnitEC / 1000);
            signCost = sign * signUnitCost;

            txtSignEC.Text = signEC.ToString("F2");
            txtSignCost.Text = signCost.ToString("c");
        }


    }
}
