   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFApp.WindowsWPFApp.Windows  5   	       WPFApp.Windows.Settings   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPFApp.Windows     5   	     � Title$  Settings��5   	   $	��250��6   $	��400��6'    � WindowStartupLocation$ CenterScreen=�63   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      $��2* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $��3* �6   .+�5   
   �� -   5         ��Name$ lbChampionship��5      $��0��6(   $��0��65   $��Center=�6E   $��Center=�6b   .��6}   Championship:6�   �� 5   
   -   5         ��Name$ cmbChampionships��5      $��0��6-   $��1��6:   $	��150��6J   $��20��6V   $
��Left=�6b    �� SelectedIndex$ 0��5      .@�5      �� -   5         ��Name$ itMen��5      $	��Men��6*   �� 5      -   5        $ itWomen��5      $��Women��6,   5      �� 5   
   -   5        $ 
lbLanguage��5      $��1��6$   $��0��61   $��Center=�6A   $��Center=�6^   .��6y   	Language:6�   �� 5   
   -   5        $ cmbLanguages��5      $��1��6)   $��1��66   $	��150��6F   $��20��6R   $
��Left=�6^   $ 0��5      .@�5      �� -   5        $ 
itCroatian��5      $��Croatian��6/   �� 5       -   5        $ 	itEnglish��5       $��English��6.   5!      �� 5#   
   -	   5        $ lbSize��5#      $��2��6    $��0��6-   $��Center=�6=   $	��Top=�6Z   .��6r   Size:6y   �� 5$   
   -
   5         ��Name$ spRadioButtons��5$      $��2��6-   $��1��6:   .+�5%      	� -   5        	 	�Name$	 	rbDefault��5%      
 	� 	GroupName$

 Size��6-   
 � Tag$ 800;450��6>   $��0,7,0,0q�6L   .��6]   	Default6f   	� 5&      -   5        $	 
rb1024x768��5&      $

 Size��6.   $ 1024;768��6?   .��6N   
1024x7686X   	� 5'      -   5        $	 	rb700x700��5'      $

 Size��6-   $ 700;700��6>   .��6L   	700x7006U   	� 5(      -   5        $	 rbFullScreen��5(      $

 Size��60   $ 
FullScreen��6A   .��6R   Full screen6_   5)      �� 5*   
   -   5         ��Name$ btnApply��5*      $��4��6#   $��1��60   $��80��6@   $��20��6K   $
��Left=�6W   .��6�   Apply6�   �� 5+   
   -   5        $ 	btnCancel��5+      $��4��6$   $��1��61   $��80��6A   $��20��6L   $
��Left=�6X   $��85,0,0,0q�6s   .��6�   Cancel6�   5,      5-      