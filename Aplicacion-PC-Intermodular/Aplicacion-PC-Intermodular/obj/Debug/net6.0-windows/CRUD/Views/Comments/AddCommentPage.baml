   M S B A M L   `   `   `  ����U  QAplicacion-PC-Intermodular, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:Aplicacion_PC_Intermodular.CRUD.Views.Comments.Aplicacion_PC_Intermodular.CRUD.Views.Comments  5      C    =Aplicacion_PC_Intermodular.CRUD.Views.Comments.AddCommentPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:Aplicacion_PC_Intermodular.CRUD.Views.Comments     5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$  AddCommentPage��5
       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %    5       � Triggers 5      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  g� Duration$ 	00:00:0.5D�6&    �� TargetProperty$ Opacity�6;    W� From 06_   		 W� To	 16h   5      5      5      .��5       �� .+�5!   
   � $	��100��6   �� 5"   
   $��Center=�6   $��Add comment��61   $��Calibri)�6D   $��32(�6Y   $
��Bold"�6g   ���#4a2908$��	0,58,0,50q�6�   �� 5#   
   -   5        
 ��Name$
 
tb_comment��5%      
���   �$��1q�5$       %  !MaterialDesignFloatingHintTextBox#��[  5&      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Write a comment...��5'         
Foreground
 �   � �� 
CaretBrush
 �   � �� TextWrapping$
 Wrap=�5*      $��16(�5+      $��Calibri)�5,      $��Center=�5-      $��Center=�5.      $��80��5/      $	��400��50      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   � �� 	MaxLength$	 200��52      �� 53   
   $J��DRemember you will post this comment with official WikiTrail account.��6   $��Calibri)�6`   $��10(�6u   $��Center=�6�   $��	0,0,120,0q�6�   ���#4a29086�   �� 54   
   -   5         ��Name$ addCommentBtn��54   �     modifyButton#��[ 6   $	��200��67   $��Add comment��6C   $��22(�6Y   
�������$��55��6z   ���#115511$��0,50,0,0q�6�   6�   55      56      