   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFApp.WindowsWPFApp.Windows  5   	        WPFApp.Windows.TeamDetails   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPFApp.Windows     5   	     � Title$  TeamDetails��5   	   $	��300��6   $	��400��6*    � WindowStartupLocation$ CenterScreen=�66   .��5
      � $	��Top=�6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5       � Triggers 5   
   :� 5       :� RoutedEvent$ Window.Loaded��6   [�5      �� 5       .��5!      ��  �� TargetProperty$ Height�6%   .��5"      W�  W� From 05#      	 W� To 2505$      	 g� Duration$	 0:0:0.5D�5%      5&      5'      5)      .+�5,   
   �� -   5        
 ��Name$
 	lbCountry��5,      $��Country:��6#   $��0��66   $��0��6C   $��Right=�6S   6q   �� 5-   
   $��0��6,   $��1��69   ��6   �� *	Country+6K   �� 5/   
   -   5        $
 
lbFifaCode��5/      $��
FIFA code:��6$   $��1��69   $��0��6F   $��Right=�6V   6t   �� 50   
   $��1��6-   $��1��6:   ��6   �� *
FifaCode+6L   �� 52   
   -   5        $
 lbGamesPlayed��52      $��Games played:��6'   $��2��6?   $��0��6L   $��Right=�6\   6z   �� 53   
   $��2��60   $��1��6=   ��6   �� *GamesPlayed+6O   �� 55   
   -   5        $
 lbWins��55      $��Wins:��6    $��3��60   $��0��6=   $��Right=�6M   6k   �� 56   
   $��3��6)   $��1��66   ��6   �� *Wins+6H   �� 58   
   -   5        $
 lbLosses��58      $��Losses:��6"   $��4��64   $��0��6A   $��Right=�6Q   6o   �� 59   
   $��4��6+   $��1��68   ��6   �� *Losses+6J   �� 5;   
   -   5        $
 lbDraws��5;      $��Draws:��6!   $��5��62   $��0��6?   $��Right=�6O   6m   �� 5<   
   $��5��6*   $��1��67   ��6   �� *Draws+6I   �� 5>   
   -   5        $
 lbScoredGoals��5>      $��Scored goals:��6'   $��6��6?   $��0��6L   $��Right=�6\   6z   �� 5?   
   $��6��6-   $��1��6:   ��6   �� *
GoalsFor+6L   �� 5A   
   -   5        $
 lbAgainstGoals��5A      $��Against goals:��6(   $��7��6A   $��0��6N   $��Right=�6^   6|   �� 5B   
   $��7��61   $��1��6>   ��6   �� *GoalsAgainst+6P   �� 5D   
   -	   5        $
 lbGoalsDifferential��5D      $��Goals differential:��6-   $��8��6K   $��0��6X   $��Right=�6h   6�   �� 5E   
   $��8��65   $��1��6B   ��6   �� *GoalDifferential+6T   �� 5G   
   -
   5         ��Name$ btnClose��5G      $��Close��6#   $��9��63   $��2��6@   $	��150��6T   $��20��6`   6l   5H      5I      