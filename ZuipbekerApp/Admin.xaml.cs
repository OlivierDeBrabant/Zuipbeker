using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZuipbekerApp.Controllers;
using ZuipbekerApp.Models;

namespace ZuipbekerApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private Controller controller;
        private ObservableCollection<Team> teams;
        private Scorebord scorebord;
        public Admin()
        {
            InitializeComponent();

            controller = new Controller();
            controller.MaakTeams();

            scorebord = new Scorebord(controller);
            scorebord.Show();

            performLoadTeams();
        }

        private async void performLoadTeams()
        {
            teams = controller.GetTeams();
            TeamList.ItemsSource = teams;
        }

        private async void AddCustomBeer(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            
            controller.GetTeam(naam).addBeer(1);
        }
        private async void AddOneBeer(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.addBeer(1);

            controller.WriteLog(t.Naam, "add", (1).ToString());

            scorebord.performLoad();
        }
        private async void AddMeter(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.addBeer(11);

            controller.WriteLog(t.Naam, "add", (11).ToString());
            scorebord.performLoad();
        }
        private async void DeleteOneBeer(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.deleteBeer(1);

            controller.WriteLog(t.Naam, "delete", (1).ToString());
            scorebord.performLoad();
        }
        private async void DeleteMeter(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.deleteBeer(11);
            controller.WriteLog(t.Naam, "delete", (11).ToString());
            scorebord.performLoad();
        }
    }
}
