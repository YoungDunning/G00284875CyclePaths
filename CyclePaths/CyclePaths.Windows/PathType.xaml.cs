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
    public sealed partial class PathType : Page
    {
        double surfaceArea, geotextileArea,
        surfaceVol, baseVol, subBaseVol,
        surfaceEC, baseEC, subBaseEC, geotextileEC,
        surfaceCost, baseCost, subBaseCost, geotextileCost,
        pathTypeEC, pathTypeCost, width, length, surfaceDepth, baseDepth, subBaseDepth;


        double asphaltDensity = 2243, typeDensity = 1600, typeDensity1 = 1600, geotextileDensity = 0.12,
        asphaltCost = 11.68, typeCost = 39.69, geoCost = 2.47,
        asphaltEC = 71, typeAEC = 4.54, typeBEC = 4.58, geoEC = 3430;

        public PathType()
        {
            this.InitializeComponent();
        }
        private void btnCalc(object sender, RoutedEventArgs e)
        {
            width = Convert.ToDouble(txtWidth.Text);
            length = Convert.ToDouble(txtLength.Text);
            surfaceDepth = Convert.ToDouble(txtSurfDepth.Text);
            baseDepth = Convert.ToDouble(txtBaseDepth.Text);
            subBaseDepth = Convert.ToDouble(txtSubBase.Text);
            //pathName = txtDescription.Text

            //Area Calculations
            surfaceArea = width * length;
            geotextileArea = surfaceArea;

            //volume Calculations
            surfaceVol = width * length * surfaceDepth;
            baseVol = width * length * baseDepth;
            subBaseVol = width * length * subBaseDepth;

            //Embodied Carbon Calculations
            surfaceEC = (surfaceVol * ((asphaltDensity * asphaltEC) / 1000)) / 1000;
            baseEC = (baseVol * ((typeDensity * typeAEC) / 1000)) / 1000;
            subBaseEC = (subBaseVol * ((typeDensity * typeBEC) / 1000)) / 1000;
            geotextileEC = (geotextileArea * ((geotextileDensity * geoEC) / 1000)) / 1000;

            //Cost Calculations
            surfaceCost = asphaltCost * surfaceArea;
            baseCost = typeCost * baseVol;
            subBaseCost = typeCost * subBaseVol;
            geotextileCost = geotextileArea * geoCost;

            //Totals
            pathTypeCost = surfaceCost + baseCost + subBaseCost + geotextileCost;
            pathTypeEC = surfaceEC + baseEC + subBaseEC + geotextileEC;

            txtEc.Text = pathTypeEC.ToString("F2");
            txtCost.Text = pathTypeCost.ToString("c");
        }

        public class AnotherPagePayLoad
        {
            public double surfaceVol { get; set; }
            public double baseVol { get; set; }
            public double subBaseVol { get; set; }
            public double geotextileArea { get; set; }
            public double asphaltDensity { get; set; }
            public double typeDensity { get; set; }
            public double typeDensity1 { get; set; }
            public double geotextileDensity { get; set; }
            public double width { get; set; }
            public double pathTypeCost { get; set; }
            public double pathTypeEC { get; set; }
        }

        private void comboPath_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (comboPath.SelectedValue.ToString())
            {
                //Sets each of the paths to there Parameters
                case "Greenway":
                    txtWidth.Text = "3";
                    txtLength.Text = "";
                    txtSurfDepth.Text = "0.06";
                    txtBaseDepth.Text = "0.15";
                    txtSubBase.Text = "0.365";
                    break;

                case "Disused Railway":
                    txtWidth.Text = "3";
                    txtLength.Text = "";
                    txtSurfDepth.Text = "0.06";
                    txtBaseDepth.Text = "0.15";
                    txtSubBase.Text = "0";
                    break;

                case "Resurfacing":
                    txtWidth.Text = "3";
                    txtLength.Text = "";
                    txtSurfDepth.Text = "0.06";
                    txtBaseDepth.Text = "0";
                    txtSubBase.Text = "0";
                    break;

            }
        }

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            Button BackButton = new Button();
            BackButton.Content = "Back Button";
            BackButton.Click += BackBtn;

            this.Frame.Navigate(typeof(MainPage));
        }

        private void MaterialBtn(object sender, RoutedEventArgs e)
        {
            Button MaterialButton = new Button();
            MaterialButton.Content = "Material Button";
            MaterialButton.Click += MaterialBtn;

            AnotherPagePayLoad payload = new AnotherPagePayLoad();
            payload.surfaceVol = width * length * surfaceDepth;
            payload.asphaltDensity = asphaltDensity * surfaceVol;
            payload.baseVol = width * length * baseDepth;
            payload.typeDensity = typeDensity * baseVol;
            payload.subBaseVol = width * length * subBaseDepth;
            payload.typeDensity1 = typeDensity1 * subBaseVol;
            payload.geotextileArea = surfaceArea;
            payload.geotextileDensity = geotextileDensity * geotextileArea;

            this.Frame.Navigate(typeof(Material), payload);

        }
    }
}
