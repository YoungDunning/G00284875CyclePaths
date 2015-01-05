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
    public sealed partial class Material : Page
    {
        double asphaltDensity, typeDensity, typeDensity1, geotextileDensity;
        double surfMatToEC, surfMatRetEC, surfMatTotalEC, baseMatToEC,
            baseMatRetEC, baseMatTotalEC, subBaseToEC, subBaseRetEC,
            subBaseTotalEC, geoToEC, geoRetEC, geoTotalEC, materialEC;
        double ecToSite = 0.1203, ecFromSite = 0.7925;
        double surfaceDist, baseDist, subBaseDist, geoDist;

        public Material()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CyclePaths.PathType.AnotherPagePayLoad passedParameter =
                e.Parameter as CyclePaths.PathType.AnotherPagePayLoad;
            double surfaceVol = passedParameter.surfaceVol;
            double asphaltDensity = passedParameter.asphaltDensity;
            double baseVol = passedParameter.baseVol;
            //double typeCost = passedParameter.typeCost;
            double typeDensity = passedParameter.typeDensity;
            double typeDensity1 = passedParameter.typeDensity1;
            double subBaseVol = passedParameter.subBaseVol;
            double geotextileArea = passedParameter.geotextileArea;
            double geotextileDensity = passedParameter.geotextileDensity;
            //double homeEC = passedParameter.homeEC;
            //double homeCost = passedParameter.homeCost;

            //calculate weight(tonnes)
            //massSurface = (surfaceVol * asphaltDensity) / 1000;
            //massBase = (baseVol * typeDensity) / 1000;
            //massSubBase = (subBaseVol * typeDensity) / 1000;
            //massGeotextile = (geotextileArea * geotextileDensity) / 1000;


            txtSurfMatMass.Text = asphaltDensity.ToString("F2");
            txtBaseMatMass.Text = typeDensity.ToString("F2");
            txtSubBaseMass.Text = typeDensity1.ToString("F2");
            txtGeoMass.Text = geotextileDensity.ToString("F2");
        }
        public class AnotherPagePayLoad
        {
            public double subBaseVol { get; set; }
            public double asphaltDensity { get; set; }
            public double pathWidth { get; set; }
            public double typeDensity { get; set; }
            public double typeDensity1 { get; set; }

        }


        private void PathType(object sender, RoutedEventArgs e)
        {
            Button StartButton = new Button();
            StartButton.Content = "Path Type";
            StartButton.Click += PathType;

            this.Frame.Navigate(typeof(PathType));

        }

        private void Guardrails(object sender, RoutedEventArgs e)
        {
            Button GuardButton = new Button();
            GuardButton.Content = "Guardrails";
            GuardButton.Click += Guardrails;

            AnotherPagePayLoad payload = new AnotherPagePayLoad();



            this.Frame.Navigate(typeof(Guardrails), payload);
        }

        private void btnCalc(object sender, RoutedEventArgs e)
        {
            //Surface Material Calculations
            asphaltDensity = Convert.ToDouble(txtSurfMatMass.Text);
            surfaceDist = Convert.ToDouble(txtSurfMat.Text);
            surfMatToEC = (surfaceDist / 1000) * asphaltDensity * (ecToSite / 1000);
            //txtSample.Text = Convert.ToString(surfaceDist) + " " + Convert.ToString(asphaltDensity) + " " + Convert.ToString(ecToSite);
            surfMatRetEC = ((surfaceDist / 1000) * ecFromSite / 1000) * (asphaltDensity / 30);
            surfMatTotalEC = surfMatToEC + surfMatRetEC;

            txtSurfMatTo.Text = surfMatToEC.ToString("F2");
            txtSurfMatRet.Text = surfMatRetEC.ToString("F2");
            txtSurfMatTotal.Text = surfMatTotalEC.ToString("F2");

            //Base Material Calculations

            typeDensity = Convert.ToDouble(txtBaseMatMass.Text);
            baseDist = Convert.ToDouble(txtBaseMat.Text);
            baseMatToEC = (baseDist / 1000) * typeDensity * (ecToSite / 1000);
            baseMatRetEC = ((baseDist / 1000) * ecFromSite / 1000) * (typeDensity / 30);
            baseMatTotalEC = baseMatToEC + baseMatRetEC;

            txtBaseMatTo.Text = baseMatToEC.ToString("F2");
            txtBaseMatRet.Text = baseMatRetEC.ToString("F2");
            txtBaseMatTotal.Text = baseMatTotalEC.ToString("F2");

            //Sub-Base material calculations
            typeDensity1 = Convert.ToDouble(txtSubBaseMass.Text);
            subBaseDist = Convert.ToDouble(txtSubBase.Text);
            subBaseToEC = (subBaseDist / 1000) * typeDensity1 * (ecToSite / 1000);
            subBaseRetEC = ((subBaseDist / 1000) * ecFromSite / 1000) * (typeDensity1 / 30);
            subBaseTotalEC = subBaseToEC + subBaseRetEC;

            txtSubBaseTo.Text = subBaseToEC.ToString("F2");
            txtSubBaseRet.Text = subBaseRetEC.ToString("F2");
            txtSubBaseTotal.Text = subBaseTotalEC.ToString("F2");

            //Geotextile Calculations
            geotextileDensity = Convert.ToDouble(txtGeoMass.Text);
            geoDist = Convert.ToDouble(txtGeo.Text);
            geoToEC = (geoDist / 1000) * geotextileDensity * (ecToSite / 1000);
            geoRetEC = ((geoDist / 1000) * ecFromSite / 1000) * (geotextileDensity / 30);
            geoTotalEC = geoToEC + geoRetEC;

            txtGeoTo.Text = geoToEC.ToString("F2");
            txtGeoRet.Text = geoRetEC.ToString("F2");
            txtGeoTotal.Text = geoTotalEC.ToString("F2");

            //Totals
            materialEC = surfMatTotalEC + baseMatTotalEC + subBaseTotalEC + geoTotalEC;
            txtTotalEC.Text = materialEC.ToString("F2");


        }
    }

}
