   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFApp.WindowsWPFApp.Windows  5   	   "    WPFApp.Windows.PlayerDetails   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPFApp.Windows     5   	     � Title$  PlayerDetails��5   	   $	��300��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68   .��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5       � Triggers 5   
   :� 5       :� RoutedEvent$ Window.Loaded��6   [�5      �� 5      .��5      ��  �� TargetProperty$ Opacity�6%   .��5      W�  W� From 05       	 W� To 15!      	 g� Duration$	 0:0:1D�5"      5#      5$      5&      .+�5)   
   (� 
 (� Stretch$

 Fill=�6   $��0��6!   $��0��6.   $��2��6>   $	��100��6R   .��5*      �� ��6   �� *PlayerPicture+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �5+      �� 5-   
   -   5         ��Name$ lbName��5-      $��Name:��6    $��1��60   $��0��6=   $��Right=�6M   $��Center=�6i   6�   �� 5.   
   $��1��6)   $��1��66   $��Center=�6F   ��6   �� *Name+6c   �� 50   
   -   5        $ lbNumber��50      $��Number:��6"   $��2��64   $��0��6A   $��Right=�6Q   $��Center=�6m   6�   �� 51   
   $��2��60   $��1��6=   $��Center=�6M   ��6   �� *ShirtNumber+6j   �� 53   
   -   5        $ 
lbPosition��53      $��	Position:��6$   $��3��68   $��0��6E   $��Right=�6U   $��Center=�6q   6�   �� 54   
   $��3��6-   $��1��6:   $��Center=�6J   ��6   �� *
Position+6g   �� 56   
   -   5        $ 	lbCaptain��56      $��Captain:��6#   $��4��66   $��0��6C   $��Right=�6S   $��Center=�6o   6�   �� 57   
   $��4��6,   $��1��69   $��Center=�6I   ��6   �� *	Captain+6f   �� 59   
   -   5        $ lbGoals��59      $��Goals:��6!   $��5��62   $��0��6?   $��Right=�6O   $��Center=�6k   6�   �� 5:   
   $��5��6{   $��1��6�   $��Center=�6�   ��6   �� *Goals+ �� $ FindAncestor=�" �6�   �� 5<   
   -   5        $ lbYellowCards��5<      $��Yellow cards:��6'   $��6��6?   $��0��6L   $��Right=�6\   $��Center=�6x   6�   �� 5=   
   $��6��6�   $��1��6�   $��Center=�6�   ��6   �� *YellowCards+ �� $ FindAncestor=�" �6�   �� 5?   
   -   5         ��Name$ btnClose��5?      $��Close��6#   $��7��63   $��0��6@   $��2��6P   $	��150��6d   $��20��6p   6�   5@      5A      