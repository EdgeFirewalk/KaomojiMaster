   M S B A M L   `   `   `  ���� H  DKaomojiMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:KaomojiMasterKaomojiMaster  !    KaomojiMaster.CreatorWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:KaomojiMaster     -     � Title$  Kaomoji Creator��$	��450��$	��800�� � 
ResizeMode$ NoResize=����	#FFAB65E1
�������.��� .+��� -    ��Name$ emotionsComboBox�� �� Text$ Choose an emotion��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��366��$��25��$��Calibri)�$
��Bold"�$��14(� �� 
IsEditable .  �� 
IsReadOnly . ��Z� �� -    ��Name$ kaomojisListBox��$
��Left=�$	��340��$��	10,60,0,0q�$	��Top=�$	��366��$��Calibri)�$��20(����	#FF7C40AC
���������Z� �� $��OR��$
��Left=�$��	381,2,0,0q�$	��Top=�$��63��$��Calibri)�$
��Bold"�$��25(�$��46��
�������$��Center=��� -    ��Name$ newEmotionTextBox��$
��Left=�$��25��$��
449,10,0,0q� �� TextWrapping$
 Wrap=�$��NAME OF NEW EMOTION��$	��Top=�$	��329���� -   	 ��Name$	 newEmotionButton��$��Create New Emotion��$
��Left=�$��
509,40,0,0q�$	��Top=�$	��219��$��Calibri)����	#FF6FE3FD���	#FF13B4F0$
��Bold"�$��29��$��18(��� -   
 ��Name$
 newEmotionArrow��$
��Left=�$��70��$��
354,38,0,0q�$	��Top=�$��80��$��	arrow.png�� J� RenderTransformOrigin$ 0.5,0.5&�$y�Hidden=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFFA0A0��   
BlurRadius$ 10Q�z�V� .~���  �� ScaleX$ -1Q��� �� T� �� $��---NEW KAOMOJI---��$
��Left=�$��
392,65,0,0q�$	��Top=�$	��392��$��Calibri)�$
��Bold"�$��20(�$��30��
�������$��Center=��� -   $ handsComboBox��$
��Left=�$��392,110,0,0q�$	��Top=�$	��120��{�.  $��16(��� $��- Hands��$
��Left=�$��517,106,0,0q�$	��Top=�$	��261��$��Calibri)�$
��Bold"�$��16(�$��31��
��������� -   $ bodiesComboBox��$
��Left=�$��392,142,0,0q�$	��Top=�$	��120��{�.  $��16(��� $��- Body��$
��Left=�$��517,138,0,0q�$	��Top=�$	��261��$��Calibri)�$
��Bold"�$��16(�$��31��
��������� -	   $ mouthsComboBox��$
��Left=�$��392,174,0,0q�$	��Top=�$	��120��{�.  $��16(��� $��- Mouth��$
��Left=�$��517,170,0,0q�$	��Top=�$	��261��$��Calibri)�$
��Bold"�$��16(�$��31��
��������� -
   $ eyesComboBox��$
��Left=�$��392,206,0,0q�$	��Top=�$	��120��{�.  $��16(��� $��- Eyes ��$
��Left=�$��517,202,0,0q�$	��Top=�$	��261��$��Calibri)�$
��Bold"�$��16(�$��31��
��������� -    ��Name$ constructedKaoTextLabel��$��
----------��$
��Left=�$��392,325,0,0q�$	��Top=�$	��380��$��20(�$��40��
�������$��Center=��� -   $	 createNewKaomojiButton��$��Create New Kaomoji��$
��Left=�$��392,369,0,0q�$	��Top=�$	��380��$��31��{�.  