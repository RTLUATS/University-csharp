using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace Lab3
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
    
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog()== true)
            {
                if ( (myStream = saveFileDialog1.OpenFile())  != null)
                {
                    string text = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd).Text;
                    var file = saveFileDialog1.FileName;
                    byte[] arr = Encoding.Default.GetBytes(text);
                    myStream.Write(arr,0, arr.Length);
                }
            }

        }

        private void NewFile(object sender, RoutedEventArgs e)
        {
            ActivateButton();
        }

        private void ActivateButton()
        {
            docBox.Visibility = Visibility.Visible;
            Canvas1.Visibility = Visibility.Visible;
            Canvas2.Visibility = Visibility.Visible;
            wordCount.IsEnabled = true;
            numberOfOffenses.IsEnabled = true;
            selectionOfOffers.IsEnabled = true;
            save.IsEnabled = true;
            docBox.IsEnabled = true;
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            var content = string.Empty;
            var path = string.Empty;

            OpenFileDialog dialog =  new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.Filter = "Text file(*.txt)|*.txt";
            dialog.CheckFileExists = true;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                var stream = dialog.OpenFile();
                using (StreamReader read = new StreamReader(stream))
                {
                    content = read.ReadToEnd();
                    docBox.AppendText(content);
                    ActivateButton();
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WordCount(object sender, RoutedEventArgs e)
        {
            box.Document.Blocks.Clear();
            var text = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd).Text;
            text = text.TrimEnd();
            var words = text.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            var len = words.Count(word => word.Length <= 4);
            box.AppendText(Convert.ToString(len));
        }

        private void NumbersOfOffers(object sender, RoutedEventArgs e)
        {
            box.Document.Blocks.Clear();
            var len = 0;
            var text = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd).Text;
            text = text.TrimEnd();
            var offers = text.Split(new char[] { '.' });
            for (int i = 1; i < offers.Length; i++)
            {
                if (Regex.IsMatch(offers[i-1],"(\"( )+\")$") && Regex.IsMatch(offers[i], "^(-)"))
                {
                    len++;
                }
            }
            box.AppendText(Convert.ToString(len));

        }

        private void SelectionOfOffers(object sender, RoutedEventArgs e)
        {
            box.Document.Blocks.Clear();
            var text = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd).Text;
            text = text.TrimEnd();
            var offers = text.Split(new char[] { '.' });
            List<string> newOffers = offers.Where(offer => Regex.IsMatch(offer, "(\\d{2})")).ToList();
            Regex regex = new Regex("(\\d{2})");
            string result = "";
            for (int i = 0; i < newOffers.Count; i++)
            {
                var words = newOffers[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < words.Length; j++)
                {
                    if (regex.IsMatch(words[j]))
                    {
                        words[j] = regex.Replace(words[j], Branch(words[j]));
                    }

                    result += words[j] + " ";
                }

                result += ".";
            }

            box.AppendText(result);
        }

        private string Branch(string word)
        {
            if (Regex.IsMatch(word,"^(1)"))
            {
                if (word == "12")
                {
                    return "двеннадцать";
                }
                else if (Regex.IsMatch(word,"0$"))
                {
                    return "десять";
                }
                else
                {
                    return Branch2(word) + "надцать";
                }
            }
            else if (Regex.IsMatch(word, "^(2)"))
            {
                if (word == "20")
                {
                    return "двадцать";
                }
                else
                {
                    return "двадцать " + Branch2(word);
                }
            }
            else if (Regex.IsMatch(word, "^(3)"))
            {
                if (word == "30")
                {
                    return "тридцать";
                }
                else
                {
                    return "тридцать " + Branch2(word);
                }
            }
            else if (Regex.IsMatch(word, "^(4)"))
            {
                if (word == "40")
                {
                    return "сорок";
                }
                else
                {
                    return "сорок " + Branch2(word);
                }
            }
            else if (Regex.IsMatch(word, "^(5)"))
            {
                if (word == "50")
                {
                    return "пятьдесят";
                }
                else
                {
                    return "пятьдесят " + Branch2(word);
                }
            }
            else if (Regex.IsMatch(word, "^(6)"))
            {
                if (word == "60")
                {
                    return "шестьдесят";
                }
                else
                {
                    return "шестьдесят " + Branch2(word);
                }
            }
            else if (Regex.IsMatch(word, "^(7)"))
            {
                if (word == "70")
                {
                    return "семдесят";
                }
                else
                {
                    return "семдесят " + Branch2(word);
                }
            }
            else if (Regex.IsMatch(word, "^(8)"))
            {
                if (word == "80")
                {
                    return "восемьдесят";
                }
                else
                {
                    return "восемьдесят " + Branch2(word);
                }
            }
            else if (Regex.IsMatch(word, "^(9)"))
            {
                if (word == "90")
                {
                    return "девяносто";
                }
                else
                {
                    return "девяносто " + Branch2(word);
                }
            }


            return "";
        }

        private string Branch2(string word)
        {
            if (Regex.IsMatch(word, "1$"))
            {
                return "один";
            }
            else if(Regex.IsMatch(word, "2$"))
            {
                return "два";
            }
            else if (Regex.IsMatch(word, "3$"))
            {
                return "три";
            }
            else if (Regex.IsMatch(word, "4$"))
            {
                return "четыре";
            }
            else if (Regex.IsMatch(word, "5$"))
            {
                return "пять";
            }
            else if (Regex.IsMatch(word, "6$"))
            {
                return "шесть";
            }
            else if (Regex.IsMatch(word, "7$"))
            {
                return "семь";
            }
            else if (Regex.IsMatch(word, "8$"))
            {
                return "восемь";
            }
            else if (Regex.IsMatch(word, "9$"))
            {
                return "девять";
            }

            return "";
        }

        private void AboutAuthor(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Background =  new SolidColorBrush(Colors.Black);
            win.GridSplitter1.Width = 0;
            win.GridSplitter2.Height = 0;
            win.Yaaa.Visibility = Visibility.Visible;
            win.Text.Visibility = Visibility.Visible;
            win.Show();

        }
    }
}
