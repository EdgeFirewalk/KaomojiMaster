using System;
using System.IO;
using System.Windows;

namespace KaomojiMaster
{
    public partial class CreatorWindow : Window
    {
        string emotionsPath; // DISC:\...\.\..\...\Emotions
        string[] emotions;  // EMOTIONS FROM --> DISC:\...\.\..\...\Emotions

        string selectedEmotion; // CURRENTLY SELECTED EMOTION

        string[] hands = new string[] { "  ", @"/\", @"\/", "╯╰", "ヽﾉ", "╰╯", "ヾツ", "୧୨", "٩۶", "凸凸", " Ψ", 
                                        "oo", "ᕕᕗ", "σ ", " σ", "ლლ" };
        string selectedHands;

        string[] bodies = new string[] { "()", "{}", "[]" };
        string selectedBody;

        string[] mouths = new string[] { " ", "__", "∀", "ω", "◡", "ε", "o", "▽", "□", "0", "ｍ", "﹏",
                                        "﹌", "ヘ", "‸", "ᗣ", "Д", "皿", "益", "人", "Δ", "△", "～"};
        string selectedMouth;

        string[] eyes = new string[] { "OO", "oO", "Oo", "oo", "><", "XX", "xx", "＋＋", "±±", "▔▔",
                                      "⌒⌒", "♡♡", "◕◕", "••", "・・", "°°", "˘˘", "´`", "μμ", "--", "〃〃", 
                                        "╥╥", "~~", "▼▼", "ÒÓ", "ΦΦ", "☆@", "⇀⇀", "↼↼", "⊙⊙", "□□", "≧≦" };
        string selectedEyes;

        public CreatorWindow(string emotionsPathFromMain, string[] emotionsFromMain)
        {
            InitializeComponent();

            //===================JUST COPYING THIS INFO FROM THE MAIN WINDOW=================
            emotionsPath = emotionsPathFromMain; 
            emotions = emotionsFromMain;
            //===============================================================================

            ReadEmotionsPath(emotionsPath, emotions); // WORKS JUST LIKE THE METHOD FROM MAIN WINDOW

            emotionsComboBox.MaxDropDownHeight = 215;

            AddKaomojiParts();
        }

        private void ReadEmotionsPath(string emotionsPath, string[] emotions)
        {
            int emotionsAmount = Directory.GetFiles(emotionsPath).Length; // AMOUNT OF .kao FILES 
            emotions = Directory.GetFiles(emotionsPath); // READING THOSE EMOTIONS
            for (int i = 0; i < emotionsAmount; i++)
            {
                // ADDING EMOTIONS
                emotionsComboBox.Items.Add(System.IO.Path.GetFileName(emotions[i].Substring(0, emotions[i].Length - 4)));
                // AND MAKING THEM FROM "DISC:\...\.\..\...\Emotions\Emotion.kao" TO "Emotion.kao"
            }
        }

        private void AddKaomojiParts()
        {
            //===================ADDING ALL OF THE PARTS TO SPECIAL COMBO BOXES==============
            for (int i = 0; i < hands.Length; i++) { handsComboBox.Items.Add(hands[i]); }
            for (int i = 0; i < bodies.Length; i++) { bodiesComboBox.Items.Add(bodies[i]); }
            for (int i = 0; i < mouths.Length; i++) { mouthsComboBox.Items.Add(mouths[i]); }
            for (int i = 0; i < eyes.Length; i++) { eyesComboBox.Items.Add(eyes[i]); }
            //===============================================================================
        }

        private void emotionsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            newEmotionArrow.Visibility = Visibility.Hidden;

            //===================APPLYING/CHANGING AN EMOTION=======================
            selectedEmotion = Convert.ToString(emotionsComboBox.SelectedItem);
            //======================================================================

            ReadAndAddKaomojis();

            //======================YOU CAN MAKE A NEW KAOMOJI ONLY IF YOU'VE CHOOSEN AN EMOTION======
            createNewKaomojiButton.IsEnabled = true;
            handsComboBox.IsEnabled = true;
            bodiesComboBox.IsEnabled = true;
            mouthsComboBox.IsEnabled = true;
            eyesComboBox.IsEnabled = true;

            createNewKaomojiButton.Content = $"Save new Kaomoji to {selectedEmotion.ToUpper()} emotions";
            //=========================================================================================
        }

        private void ReadAndAddKaomojis()
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

        private void newEmotionButton_Click(object sender, RoutedEventArgs e)
        {
            string newEmotionName = newEmotionTextBox.Text.Trim(); // NAME OF THE EMOTION YOU ENTERED
            newEmotionName = newEmotionName.Substring(0, 1).ToUpper() + newEmotionName.Substring(1, newEmotionName.Length - 1); // MAKING IT BEAUTIFUL
            
            if (newEmotionName == string.Empty)
            {
                // YOU CAN'T MAKE AN EMOTION WITH EMPTY STRING AS ITS NAME
                MessageBox.Show($"Can't make an emotion with name \"{newEmotionName}\"");
            }
            else
            {
                if (File.Exists(emotionsPath + "\\" + newEmotionName + ".kao"))
                {
                    // YOU CAN'T MAKE AN EMOTION THAT ALREADY EXISTS
                    MessageBox.Show($"Emotion \"{newEmotionName}\" already exists");
                }
                else
                {
                    File.Create(emotionsPath + "\\" + newEmotionName + ".kao");
                    ReadEmotionsPath(emotionsPath, emotions); // READING IT AGAIN TO ADD NEW EMOTION TO LIST OF EMOTIONS
                    newEmotionArrow.Visibility = Visibility.Visible;
                }
            }
        }

        private void createNewKaomojiButton_Click(object sender, RoutedEventArgs e)
        {
            if (handsComboBox.SelectedIndex != -1 && bodiesComboBox.SelectedIndex != -1 
                && mouthsComboBox.SelectedIndex != -1 && eyesComboBox.SelectedIndex != -1)
            {
                FileStream file = new FileStream(emotionsPath + "\\" + selectedEmotion + ".kao", FileMode.Append);
                byte[] kao = System.Text.Encoding.UTF8.GetBytes(Convert.ToString(constructedKaoTextLabel.Content) + "\n");
                file.Write(kao, 0, kao.Length);
                file.Close();

                ReadAndAddKaomojis();
            }
            else
            {
                MessageBox.Show("Your Kaomoji is empty");
            }
        }

        private void handsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedHands = Convert.ToString(handsComboBox.SelectedItem);
            ConstructKaomoji();
        }

        private void bodiesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedBody = Convert.ToString(bodiesComboBox.SelectedItem);
            ConstructKaomoji();
        }

        private void mouthsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedMouth = Convert.ToString(mouthsComboBox.SelectedItem);
            ConstructKaomoji();
        }

        private void eyesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedEyes = Convert.ToString(eyesComboBox.SelectedItem);
            ConstructKaomoji();
        }

        private void ConstructKaomoji()
        {
            constructedKaoTextLabel.Content = String.Empty;
            try {
                int halfOfTheHands = selectedHands.Length / 2;
                int halfOfTheBody = selectedBody.Length / 2;
                int halfOfTheEyes = selectedEyes.Length / 2;

                constructedKaoTextLabel.Content = $"{selectedHands.Substring(0, halfOfTheHands)}{selectedBody.Substring(0, halfOfTheBody)}{selectedEyes.Substring(0, halfOfTheEyes)}{selectedMouth}{selectedEyes.Substring(halfOfTheEyes, selectedEyes.Length - 1)}{selectedBody.Substring(halfOfTheBody, selectedBody.Length - 1)}{selectedHands.Substring(halfOfTheHands, selectedHands.Length - 1)}";
            } catch { }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.creatorOpened = false;
        }
    }
}
