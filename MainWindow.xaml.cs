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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace Блокнот_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string opendFile = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            if (openFileDialog.ShowDialog() == true)
            {
                opendFile = openFileDialog.FileName;
                StreamReader rider = new StreamReader(openFileDialog.FileName);
                textBox1.Text = rider.ReadToEnd();
                rider.Close();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (opendFile == "")
            {
                seveFilesAs();
            }
            else seveFile(opendFile);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            seveFilesAs();
        }
        public void seveFilesAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == true)
            {
                opendFile = sfd.FileName;
                seveFile(sfd.FileName);
            }
        }
        private void seveFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.Write(textBox1.Text);
            writer.Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            textBox1.Copy();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            int cursorPosition = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(cursorPosition, Clipboard.GetText());
            textBox1.SelectionStart = cursorPosition + Clipboard.GetText().Length;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
        }

        
       
    }
}
