using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZuipbekerApp.Controllers;

namespace ZuipbekerApp
{
    /// <summary>
    /// Interaction logic for OpenFolder.xaml
    /// </summary>
    public partial class OpenFolder : Window
    {
        private string path;
        private Controller controller;
        public OpenFolder()
        {
            InitializeComponent();
            controller = new Controller();
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            folderDialog.ShowDialog();
            path = folderDialog.SelectedPath;

            FolderPath.Text = path;

            controller.MaakTeams(path);
        }
        private void btnNextClick(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin(controller);
            admin.Show();
            this.Close();
        }
    }
}
