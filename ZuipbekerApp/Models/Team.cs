﻿using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace ZuipbekerApp.Models
{
    public class Team : INotifyPropertyChanged
    {
        public string Naam { get; set; }

        private int amount;
        public event PropertyChangedEventHandler PropertyChanged;

        public int AmountBeer 
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Team() { }

        public Team(string naam)
        {
            Naam = naam;
            AmountBeer = 0;
        }
        public Team(string naam, int aantal)
        {
            Naam = naam;
            AmountBeer = aantal;
        }

        public void addBeer(int aantal)
        {
            AmountBeer += aantal;
            writeTeam();
        }
        public void deleteBeer(int aantal)
        {
            AmountBeer -= aantal;
            writeTeam();
        }

        public void writeTeam()
        {
            string path = @"..\..\..\..\Zuipbeker\files\" + Naam + ".txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(AmountBeer);
            }
        }
    }
}
