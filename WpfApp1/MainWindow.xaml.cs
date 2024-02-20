using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "file.txt";

        public MainWindow()
        {
            string str;
            InitializeComponent();

            if(File.Exists(path))
            {
                using(StreamReader file = new StreamReader(path))
                {
                    str = file.ReadToEnd();
                }
                string[] lines = str.Split('\n');
                for(int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                    {
                        string[] strings = lines[i].Split();
                        masPas.Items.Add(new Serves(strings));
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(textSer.Text != "" && textLog.Text != "" && textPas.Text != "")
            {
                if(proverka())
                {
                    masPas.Items.Add(new Serves(textSer.Text, textLog.Text, textPas.Text));

                    textSer.Text = "";
                    textLog.Text = "";
                    textPas.Text = "";
                }
                else
                {
                    MessageBox.Show("Сервис с таким логином уже существует!!!");
                    textSer.Background = Brushes.Red;
                    textLog.Background = Brushes.Red;
                }
            }
            else
            {
                if(textSer.Text == "")
                {
                    textSer.Background = Brushes.Red;
                }
                if (textLog.Text == "")
                {
                    textLog.Background = Brushes.Red;
                }
                if (textPas.Text == "")
                {
                    textPas.Background = Brushes.Red;
                }
            }
        }

        private bool proverka()
        {
             foreach(Serves ser in masPas.Items)
             {
                 if(textLog.Text == ser.Log && textSer.Text == ser.Ser)
                 {
                    return false;
                 }
             }
             return true;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach(Serves serves in masPas.Items)
                {
                    file.WriteLine(serves);
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(masPas.SelectedItem != null)
            {
                masPas.Items.Remove(masPas.SelectedItem);
            }
        }
    }
}
