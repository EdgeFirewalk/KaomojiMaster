   M S B A M L   `   `   `  ���� H  DKaomojiMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:KaomojiMasterKaomojiMaster      KaomojiMaster.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:KaomojiMaster     -     �Name$  mainWin�� � Title$ Kaomoji Master��$��491.333��$	��400�� � 
ResizeMode$ NoResize=� � Icon$ icon.ico�����	#FFAB65E1
�������.��� .+��� -    ��Name$ emotionsComboBox��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��366��$��25�� �� Text$ (⌒ω⌒)ﾉ Welcome!��$��Calibri)�$
��Bold"�$��14(� �� 
IsEditable .  �� 
IsReadOnly . ��Z� �� -    ��Name$ kaomojisListBox��$
��Left=�$	��340��$��	10,60,0,0q�$	��Top=�$	��366��$��Calibri)�$��20(����	#FF7C40AC
���������Z� �� -   	 ��Name$	 copiedToClipLabel��$��!COPIED TO CLIPBOARD!��$
��Left=�$��Center=�$��	10,30,0,0q�$	��Top=�$	��366��$��Center=�$��Calibri)�$
��Bold"�$��20(�$��34��
��������� -   
 ��Name$
 upArrow��$
��Left=�$	��100��$	��Top=�$	��100��$��
282,40,0,0q�$��	arrow.png���� -   $	 chooseAnEmTextLabel��$-��'CHOOSE AN 
EMOTION
HERE  (*・ω・)ﾉ��$
��Left=�$��187,107,0,0q�$	��Top=�$	��132��$��Calibri)�$
��Bold"�$��20(�$��80��
��������� -    ��Name$ editorButton��$��F9��$
��Left=�$��
33,215,0,0q�$	��Top=�$��50��$��35��
�������$��Calibri)�$��22(�
��������� -   $	 editorTextLabel��$��- open EDITOR��$
��Left=�$��
83,215,0,0q�$	��Top=�$	��131��$��Calibri)�$
��Bold"�$��20(�$��35��
��������� -	   $	 tipsTextLabel��$����• Click - Copy Kaomoji to clipboard
• Double Сlick - Copy Kaomoji + minimize
                                                                window��$
��Left=�$��
10,274,0,0q�$	��Top=�$	��366��$��Calibri)�$
��Bold"�$��20(�$��81��
��������� -
   $	 currentKaoTextLabel��$��Current Kaomoji: ��$
��Left=�$��	2,415,0,0q�$	��Top=�$	��374��$��20(�$��37��
��������� -   $	 refTextLabel��$@��:All kaomojis were taken from this site: http://kaomoji.ru/��$
��Left=�$��
10,371,0,0q�$	��Top=�$	��366��$��29��$
��Bold"�$��13(� � Cursor$
 Hand��