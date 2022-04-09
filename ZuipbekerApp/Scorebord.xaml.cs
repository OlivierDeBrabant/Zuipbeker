using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Scorebord.xaml
    /// </summary>
    public partial class Scorebord : Window
    {
        private readonly Controller controller;
        private List<Team> teams;

        public Scorebord(Controller c)
        {
            InitializeComponent();

            controller = c;
            PerformLoad();


        }

        public void PerformLoad()
        {
            teams = controller.GetSortedTeams();
            int numberofTeams = teams.Count();
            if(numberofTeams >= 3)
            {
                Winner.Text = "1. " + teams.First().Naam.ToString();
                WinnerAmount.Text = teams.First().AmountBeer.ToString();

                Second.Text = "2. " + teams[1].Naam.ToString();
                SecondAmount.Text = teams[1].AmountBeer.ToString();

                Third.Text = "3. " + teams[2].Naam.ToString();
                ThirdAmount.Text = teams[2].AmountBeer.ToString();
            }
            
            if(numberofTeams >= 10)
            {
                FirstSevenTeamsNaam.ItemsSource = teams.GetRange(3, 7);
                FirstSevenTeamsAmountBeer.ItemsSource = teams.GetRange(3, 7);
            }
            if(numberofTeams >= 17)
            {
                SecondSevenTeamsNaam.ItemsSource = teams.GetRange(10, 7);
                SecondSevenTeamsAmountBeer.ItemsSource = teams.GetRange(10, 7);
            }
            if(numberofTeams >= 24)
            {
                ThirdSevenTeamsNaam.ItemsSource = teams.GetRange(17, 7);
                ThirdSevenTeamsAmountBeer.ItemsSource = teams.GetRange(17, 7);
            }
        }
    }
}
