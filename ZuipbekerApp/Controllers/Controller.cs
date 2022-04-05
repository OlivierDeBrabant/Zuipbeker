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
        private string folderPath;

        public void MaakTeams(string path)
        {
            folderPath = path;

            string teamsTxt = System.IO.Path.Combine(folderPath, "Teams.txt");
            if (!System.IO.File.Exists(teamsTxt))
            {
                System.IO.File.Create(teamsTxt);
            }
            else
            {
                string[] lines = System.IO.File.ReadAllLines(folderPath + @"\Teams.txt");
                foreach (string team in lines)
                {
                    Team t;
                    if (File.Exists(System.IO.Path.Combine(folderPath, team + ".txt")))
                    {
                        var lastline = File.ReadLines(System.IO.Path.Combine(folderPath, team + ".txt")).Last();
                        t = new Team(team, Int16.Parse(lastline));
                    }
                    else
                    {
                        t = new Team(team);
                    }

                    teams.Add(t);
                }
            }
            
            if (!System.IO.File.Exists(System.IO.Path.Combine(folderPath, "logs.txt")))
            {
                System.IO.File.Create(System.IO.Path.Combine(folderPath, "logs.txt"));
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
            using (StreamWriter sw = File.AppendText(System.IO.Path.Combine(folderPath, "logs.txt")))
            {
                sw.WriteLine(DateTime.Now.ToString() + "\t" + team + "\t" + addDelete + "\t" + amount);
            }
        }
        public String getFolderPath()
        {
            if(folderPath != null)
            {
                return folderPath;
            }
            else
            {
                return "NullPointer";
            }
        }
    }
}