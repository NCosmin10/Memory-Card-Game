   M S B A M L   `   `   `  ����F  BMemory_game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Memory_gameMemory_game  5   	       Memory_game.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Memory_game     5   	   -   5          � Title$  
GameWindow��5   	   $	��550��6   $	��550��6)    � DataContext 5         Memory_game.Game  5   
   .��5      � .+�5   
   �� -   5        $��Board��5   L   $��0,10,191,35.8q�65   $��Right=�6Y   $	��326��6u   ��6   �� *cards+��5      �� 5      .R�5      A� 5      ��5      �� 5      .R�5      ��  ��Name$ 
cardButton��66   -   5        $
��Auto��5   J   $
��Auto��6W   ��5      �� 5      $I��CD://An_2_sem2//MVP/Memory_game//Memory_game//Photos//Basic_Back.jpg��6$   $��Stretch=�6q   $��Stretch=�6�   5      5      5      �� 5    
   -   5        $��	imgPlayer��5       $
��Left=�6!   $	��132��6<   $��
380,25,0,0q�6I   $	��Top=�6]   $	��128��6u   �� 5!   
   -   5        $��labelPlayerName��5!      $��Player name��6'   $
��Left=�6=   $��380,175,0,0q�6X   $	��Top=�6m    J� RenderTransformOrigin$ -0.185,-0.125&�6�   $��26��6�   $	��128��6�   �� 5"   
   -   5        $��
labelRound��5"      $��Round��6"   $
��Left=�62   $��380,201,0,0q�6M   $	��Top=�6b   $	��128��6z   �� 5#   
   $��Remaining time:��6   $
��Left=�6*   $��380,227,0,0q�6E   $	��Top=�6Z   $��96��6r   �� 5$   
   -   5        $��RemainingTime��5$      $
��Time��6%   $
��Left=�64   $��476,227,0,0q�6O   $	��Top=�6d   5&      5'      