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
        private readonly Controller controller;
        private ObservableCollection<Team> teams;
        private readonly  Scorebord scorebord;
        Boolean logMessageShown = false;

        private readonly string folderPath;

        public Admin(Controller c)
        {
            InitializeComponent();
            controller = c;

            scorebord = new Scorebord(controller);
            scorebord.Show();
            folderPath = controller.GetFolderPath();

            PerformLoadTeams();

        }

        private void PerformLoadTeams()
        {
            teams = controller.GetTeams();
            TeamList.ItemsSource = teams;
        }

        private void AddCustomBeer(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            
            controller.GetTeam(naam).addBeer(1, folderPath);
        }
        private void AddOneBeer(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.addBeer(1, folderPath);

            controller.WriteLog(t.Naam, "add", (1).ToString());

            scorebord.PerformLoad();
        }
        private void AddMeter(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.addBeer(11, folderPath);

            controller.WriteLog(t.Naam, "add", (11).ToString());
            scorebord.PerformLoad();
        }
        private void DeleteOneBeer(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.deleteBeer(1, folderPath);

            controller.WriteLog(t.Naam, "delete", (1).ToString());
            scorebord.PerformLoad();
        }
        private void DeleteMeter(object sender, RoutedEventArgs e)
        {
            string naam = ((Button)sender).Tag.ToString();
            Team t = controller.GetTeam(naam);
            t.deleteBeer(11, folderPath);
            controller.WriteLog(t.Naam, "delete", (11).ToString());
            scorebord.PerformLoad();
        }
        private void BtnOpenLogFile(object sender, RoutedEventArgs e)
        {
            if (!logMessageShown)
            {
                MessageBox.Show("Do not change anything in this file!\nIf changes are made, close the file without saving it.","Warning", 
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                logMessageShown = true;
            }

            System.Diagnostics.Process.Start(System.IO.Path.Combine(folderPath, "logs.txt"));
        }
    }
}
