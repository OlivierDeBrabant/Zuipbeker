using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuipbekerApp.Models;

namespace ZuipbekerApp.Controllers
{
    public class Controller
    {
        ObservableCollection<Team> teams = new ObservableCollection<Team>();
        string logTxt = System.IO.Path.Combine(@"..\..\..\..\Zuipbeker\files", "logs.txt");

        public void MaakTeams()
        {
            string filesFolder = System.IO.Path.Combine(@"..\..\..\..\Zuipbeker", "files");
            System.IO.Directory.CreateDirectory(filesFolder);
            string teamsTxt = System.IO.Path.Combine(@"..\..\..\..\Zuipbeker\files", "Teams.txt");
            if (!System.IO.File.Exists(teamsTxt))
            {
                System.IO.File.Create(teamsTxt);
            }
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\Zuipbeker\files\Teams.txt");
            foreach (string team in lines)
            {
                Team t;
                if (File.Exists(@"..\..\..\..\Zuipbeker\files\" + team + ".txt"))
                {
                    var lastline = File.ReadLines(@"..\..\..\..\Zuipbeker\files\" + team + ".txt").Last();
                    t = new Team(team, Int16.Parse(lastline));
                }
                else
                {
                    t = new Team(team);
                }

                teams.Add(t);
            }
            if (!System.IO.File.Exists(logTxt))
            {
                System.IO.File.Create(logTxt);
            }
        }
        public ObservableCollection<Team> GetTeams()
        {
            return teams;
        }
        public Team GetTeam(string naam)
        {
            return teams.First(val => val.Naam == naam);
        }

        public List<Team> GetSortedTeams()
        {
            return teams.OrderByDescending(t => t.AmountBeer).ToList();
        }
        public void WriteLog(string team, string addDelete, string amount)
        {
            using (StreamWriter sw = File.AppendText(logTxt))
            {
                sw.WriteLine(DateTime.Now.ToString() + "\t" + team + "\t" + addDelete + "\t" + amount);
            }
        }
    }
}