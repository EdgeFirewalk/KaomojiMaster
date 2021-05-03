using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KaomojiMaster
{
    public partial class MainWindow : Window
    {
        string emotionsPath; // DISC:\...\.\..\...\Emotions
        string[] emotions;  // EMOTIONS FROM --> DISC:\...\.\..\...\Emotions

        string selectedEmotion; // CURRENTLY SELECTED EMOTION

        MediaPlayer mpPick = new MediaPlayer();     // SOUND THAT USED WHEN YOU PICK A KAOMOJI
        MediaPlayer mpPickHigh = new MediaPlayer(); // SOUND THAT USED WHEN YOU DOUBLE CLICK ON KAOMOJI

        Random rnd = new Random(); // JUST RANDOM ¯\_(ツ)_/¯

        Brush[] fontColors = new Brush[]
        { Brushes.White, Brushes.Black, Brushes.MediumSpringGreen }; // "COPIED TO CLIPBOARD" TEXT FONT COLORS

        bool emotionSelected = false; // EQUALS TRUE WHEN YOU CHOOSE AN EMOTION FOR THE FIRST TIME (USED TO PREVENT THE APP FROM DOUBLE CLICK CLOSING BEFORE EVEN CHOOSING AN EMOTION)
        // (DOUBLE CLICK ON LISTBOX WITH EMOTIONS CLOSES IT, SO WE NEED TO PICK AN EMOTION FIRST TO MAKE THE APP WORK PROPERLY)

        public static bool creatorOpened; // MADE IT STATIC TO HAVE AN ACCESS TO IT FROM EDITOR WINDOW

        public MainWindow()
        {
            InitializeComponent();

            mpPick.Open(new Uri(Environment.CurrentDirectory + "\\pick.wav"));
            mpPickHigh.Open(new Uri(Environment.CurrentDirectory + "\\pickHigh.wav"));

            copiedToClipLabel.Visibility = Visibility.Hidden;   // NOTHING IS COPIED AT THE BEGINNING 
            currentKaoTextLabel.Visibility = Visibility.Hidden; // NO KAOMOJI SELECTED AT THE BEGINNING

            emotionsPath = Environment.CurrentDirectory + "\\Emotions"; // DISC:\...\.\..\...\Emotions

            ReadEmotionsPath(); // READS ALL EMOTIONS AND ADDS THEM TO COMBOBOX WITH EMOTIONS

            emotionsComboBox.MaxDropDownHeight = 170; // JUST TO MAKE THE APP BEAUTIFUL
        }

        private void ReadEmotionsPath()
        {
            int emotionsAmount = Directory.GetFiles(emotionsPath).Length; // AMOUNT OF .kao FILES 
            emotions = new string[emotionsAmount];  // ARRAY WITH ALL EMOTIONS
            emotions = Directory.GetFiles(emotionsPath); // READING THOSE EMOTIONS
            for (int i = 0; i < emotionsAmount; i++)
            {
                // ADDING EMOTIONS
                emotionsComboBox.Items.Add(System.IO.Path.GetFileName(emotions[i].Substring(0, emotions[i].Length - 4)));
                // AND MAKING THEM FROM "DISC:\...\.\..\...\Emotions\Emotion.kao" TO "Emotion.kao"
            }
        }

        private void emotionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            emotionSelected = true; // NOW DLOUBLE CLICK WORKS (READ ABOUT IT ABOVE)

            //==========================VISUAL STUFF================================
            chooseAnEmTextLabel.Visibility = Visibility.Collapsed;
            upArrow.Visibility = Visibility.Collapsed;
            tipsTextLabel.Visibility = Visibility.Collapsed;
            refTextLabel.Visibility = Visibility.Collapsed;
            editorButton.Visibility = Visibility.Collapsed;
            editorTextLabel.Visibility = Visibility.Collapsed;
            currentKaoTextLabel.Visibility = Visibility.Visible;
            kaomojisListBox.Items.Clear();
            //======================================================================

            //===================APPLYING/CHANGING AN EMOTION=======================
            selectedEmotion = Convert.ToString(emotionsComboBox.SelectedItem);
            //======================================================================

            ReadAndAddKaomojis();
        }

        public void ReadAndAddKaomojis()
        {
            kaomojisListBox.Items.Clear();
            string line; // EACH LINE OF THE EMOTION FILE
            StreamReader file = new StreamReader(emotionsPath + "\\" + selectedEmotion + ".kao"); // OPENING EMOTION FILE
            while ((line = file.ReadLine()) != null) // READING TO THE END OF THE FILE
            {
                kaomojisListBox.Items.Add(line); // ADDING AN EMOTION TO LIST
            }
            file.Close(); // OUR WORK HERE IS DONE
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
                mpPickHigh.Play(); // PLAYING DOUBLE CLICK SOUND
                mainWin.WindowState = WindowState.Minimized; // HIDING THE WINDOW
                mpPickHigh.Open(new Uri(Environment.CurrentDirectory + "\\pickHigh.wav")); // LOADING THE SOUND AGAIN
            }
        }

        private void refTextLabel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://kaomoji.ru/");
        }

        //==================================CREATOR WINDOW STUFF====================================
        private void mainWin_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F9)
            {
                openCreator(sender, e);
            }
        }
        private void openCreator(object sender, RoutedEventArgs e)
        {
            if (!creatorOpened)
            {
                creatorOpened = true;
                CreatorWindow creatorWin = new CreatorWindow(emotionsPath, emotions);
                creatorWin.Show();
            }
        }
        //==========================================================================================
    }
}
