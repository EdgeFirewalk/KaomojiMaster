using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KaomojiMaster
{
    public partial class MainWindow : Window
    {
        private string emotionsPath;

        private string[] emotions;

        private string selectedEmotion;

        MediaPlayer mpPick = new MediaPlayer();
        MediaPlayer mpPickHigh = new MediaPlayer();

        Random rnd = new Random();

        Brush[] fontColors = new Brush[]
        { Brushes.White, Brushes.Black, Brushes.MediumSpringGreen };

        private bool emotionSelected = false;

        public MainWindow()
        {
            InitializeComponent();

            mpPick.Open(new Uri(Environment.CurrentDirectory + "\\pick.wav"));
            mpPickHigh.Open(new Uri(Environment.CurrentDirectory + "\\pickHigh.wav"));

            copiedToClipLabel.Visibility = Visibility.Hidden;
            currentKaoTextLabel.Visibility = Visibility.Hidden;

            emotionsPath = Environment.CurrentDirectory + "\\Emotions";

            ReadEmotionsPath();

            emotionsComboBox.MaxDropDownHeight = 170;
        }

        private void ReadEmotionsPath()
        {
            int emotionsAmount = Directory.GetFiles(emotionsPath).Length;
            emotions = new string[emotionsAmount];
            emotions = Directory.GetFiles(emotionsPath);
            for (int i = 0; i < emotionsAmount; i++)
            {
                emotionsComboBox.Items.Add(System.IO.Path.GetFileName(emotions[i].Substring(0, emotions[i].Length - 4)));
            }
        }

        private void emotionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            emotionSelected = true;

            //==========================VISUAL STUFF================================
            chooseAnEmTextLabel.Visibility = Visibility.Collapsed;
            upArrow.Visibility = Visibility.Collapsed;
            tipsTextLabel.Visibility = Visibility.Collapsed;
            refTextLabel.Visibility = Visibility.Collapsed;
            currentKaoTextLabel.Visibility = Visibility.Visible;
            kaomojisListBox.Items.Clear();
            //======================================================================

            //===================APPLYING/CHANGING AN EMOTION=======================
            selectedEmotion = Convert.ToString(emotionsComboBox.SelectedItem);
            //======================================================================

            //===================READING AN EMOTION FILE AND ADDING KAOMOJIS========
            string line;
            StreamReader file = new StreamReader(emotionsPath + "\\" + selectedEmotion + ".kao");
            while ((line = file.ReadLine()) != null)
            {
                kaomojisListBox.Items.Add(line);
            }
            file.Close();
            //======================================================================
        }

        private void kaomojisListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //=========================ZEROING THE LABEL============================
            currentKaoTextLabel.Content = "Current Kaomoji: ";
            //======================================================================

            //================CLIPBOARDING SELECTED KAOMOJI=========================
            Clipboard.SetText(Convert.ToString(kaomojisListBox.SelectedItem));
            //======================================================================

            //====================CREATING A RANDOM NUMBER==========================
            int i = rnd.Next(fontColors.Length);
            //=========================APPLYING IT==================================
            if (copiedToClipLabel.Foreground == fontColors[i]) // IF IT'S THE SAME COLOR
            {
                i = rnd.Next(fontColors.Length); // GENERATING AGAIN
                copiedToClipLabel.Foreground = fontColors[i]; // APPLYING
            }
            else
            {
                copiedToClipLabel.Foreground = fontColors[i]; // APPLYING
            }
            //======================================================================

            //===========================PLAYING SOUND==============================
            mpPick.Play();
            //==========================LOADING IT AGAIN============================
            mpPick.Open(new Uri(Environment.CurrentDirectory + "\\pick.wav"));
            //======================================================================

            //=====SHOWING THAT EMOJI IS SUCCESFULLY COPYED TO CLIPBOARD============
            copiedToClipLabel.Visibility = Visibility.Visible;
            //=====================SHOWING THE CURRENT KAOMOJI======================
            currentKaoTextLabel.Content += Convert.ToString(kaomojisListBox.SelectedItem);
            //======================================================================
        }

        private void kaomojisListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (emotionSelected)
            {
                mpPickHigh.Play();
                mainWin.WindowState = WindowState.Minimized;
                mpPickHigh.Open(new Uri(Environment.CurrentDirectory + "\\pickHigh.wav"));
            }
        }

        private void refTextLabel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://kaomoji.ru/");
        }
    }
}
