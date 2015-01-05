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
    public sealed partial class Guardrails : Page
    {
        double steel, rumble, res1, res2, arg1, arg2, mesh1, mesh2, timber1, timber2;
        double steelEC, rumbleEC, res1EC, res2EC, arg1EC, arg2EC, mesh1EC, mesh2EC, timber1EC, timber2EC, guardrailsEC;
        double steelCost, rumbleCost, res1Cost, res2Cost, arg1Cost, arg2Cost, mesh1Cost, mesh2Cost, timber1Cost, timber2Cost, guardrailsCost;
        double steelUnitCost = 45.93, steelUnitEC = 29.10;
        double rumbleUnitCost = 2.9, rumbleUnitEC = 11.59;
        double resUnitCost = 33.5, resUnitEC = 19.6812;
        double argUnitCost = 4.5, argUnitEC = 5.3;
        double timberUnitCost = 14, timberUnitEC = 9.81;
        double meshUnitCost = 10, meshUnitEC = 15.54;
        
        public Guardrails()
        {
            this.InitializeComponent();
        }
        public class AnotherPagePayLoad
        {

        }
        
        private void backBtn(object sender, RoutedEventArgs e)
        {
            Button BackButton = new Button();
            BackButton.Content = "Back Button";
            BackButton.Click += backBtn;

            this.Frame.Navigate(typeof(Material));
        }

        private void signBtn(object sender, RoutedEventArgs e)
        {
            Button SignButton = new Button();
            SignButton.Content = "Sign Button";
            SignButton.Click += signBtn;


            AnotherPagePayLoad payload = new AnotherPagePayLoad();

            this.Frame.Navigate(typeof(Signage), payload);
        }

        private void btnCalc(object sender, RoutedEventArgs e)
        {
            steel = Convert.ToDouble(txtSteel.Text);
            rumble = Convert.ToDouble(txtRumble.Text);
            res1 = Convert.ToDouble(txtRes1.Text);
            res2 = Convert.ToDouble(txtRes2.Text);
            arg1 = Convert.ToDouble(txtArg1.Text);
            arg2 = Convert.ToDouble(txtArg2.Text);
            mesh1 = Convert.ToDouble(txtMesh1.Text);
            mesh2 = Convert.ToDouble(txtMesh2.Text);
            timber1 = Convert.ToDouble(txtTimber1.Text);
            timber2 = Convert.ToDouble(txtTimber2.Text);

            //Embodied Carbon Calculations
            steelEC = steel * (steelUnitEC / 1000);
            rumbleEC = rumble * (rumbleUnitEC / 1000);
            res1EC = res1 * (resUnitEC / 1000);
            res2EC = (res2 * (resUnitEC / 1000)) * 2;
            arg1EC = arg1 * (argUnitEC / 1000);
            arg2EC = (arg2 * (argUnitEC / 1000)) * 2;
            mesh1EC = mesh1 * (meshUnitEC / 1000);
            mesh2EC = (mesh2 * (meshUnitEC / 1000)) * 2;
            timber1EC = timber1 * (timberUnitEC / 1000);
            timber2EC = (timber2 * (timberUnitEC / 1000)) * 2;
            guardrailsEC = steelEC + rumbleEC + res1EC + res2EC + arg1EC + arg2EC + mesh1EC + mesh2EC + timber1EC + timber2EC;

            //cost calculations
            steelCost = steel * steelUnitCost;
            rumbleCost = rumble * rumbleUnitCost;
            res1Cost = res1 * resUnitCost;
            res2Cost = res2 * resUnitCost * 2;
            arg1Cost = arg1 * argUnitCost;
            arg2Cost = arg2 * argUnitCost * 2;
            mesh1Cost = mesh1 * meshUnitCost;
            mesh2Cost = mesh2 * meshUnitCost * 2;
            timber1Cost = timber1 * timberUnitCost;
            timber2Cost = timber2 * timberUnitCost * 2;
            guardrailsCost = steelCost + rumbleCost + res1Cost + res2Cost + arg1Cost + arg2Cost + mesh1Cost + mesh2Cost + timber1Cost + timber2Cost;

            txtSteelEC.Text = steelEC.ToString();
            txtRumbleEC.Text = rumbleEC.ToString();
            txtRes1EC.Text = res1EC.ToString();
            txtRes2EC.Text = res2EC.ToString();
            txtArg1EC.Text = arg1EC.ToString();
            txtArg2EC.Text = arg2EC.ToString();
            txtMesh1EC.Text = mesh1EC.ToString();
            txtMesh2EC.Text = mesh2EC.ToString();
            txtTimber1EC.Text = timber1EC.ToString();
            txtTimber2EC.Text = timber2EC.ToString();
            txtTotalEC.Text = guardrailsEC.ToString("F2");

            txtSteelCost.Text = steelCost.ToString("c");
            txtRumbleCost.Text = rumbleCost.ToString("c");
            txtRes1Cost.Text = res1Cost.ToString("c");
            txtRes2Cost.Text = res2Cost.ToString("c");
            txtArg1Cost.Text = arg1Cost.ToString("c");
            txtArg2Cost.Text = arg2Cost.ToString("c");
            txtMesh1Cost.Text = mesh1Cost.ToString("c");
            txtMesh2Cost.Text = mesh2Cost.ToString("c");
            txtTimber1Cost.Text = timber1Cost.ToString("c");
            txtTimber2Cost.Text = timber2Cost.ToString("c");
            txtTotalCost.Text = guardrailsCost.ToString("c");
        }
    }
}
