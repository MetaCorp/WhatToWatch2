   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,meclr-namespace:WpfApplication1     5   	   -   5          � Title$  
MainWindow��5   	   $	��708��6   $
��1175��6)   .��5      � 
���   � � RowDefinitions 5   
   �� 5	      $	��105 �6   �� 5
      .+�5   
   �� $��0��6   ���	#FF0A0A0A6!   �� 5   
   $��What To Watch��6    �� TextAlignment$ Center=�6)   
�������$��92��6S   $
��Left=�6^   $	��Top=�6y   $
��Wrap=�6�   $��	10,21,0,0q�6�   $
��Bold"�6�   $��63��6�   $��22(�6�   �� 5   
   -   5         ��Name$ textBoxSearch��5      $
��Left=�6)   $��0��6D   $��24��6T   $��
159,71,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $��TextBox��6�   $	��Top=�6�   $	��304��6�   
���������6�   Z� 6�   �� 5   
   $��1��6    �� TabStripPlacement$
 Left=�68   ���	#FFACACAC$��0q�6i   ��6"   Z� .@�5      �� $
��Home��6   $	��110��6$   $��40��60   $��0q�6<   .��5      �� $��1��6    $��Hidden=�6-   $��Stretch=�6R   $��Stretch=�6w   $��1,0,0,0q�6�   .��5      � .+�5      � -   5         �Name$ 	panelHome��5   $   .+�5      *   $WpfApplication1.UserControlGroupLine  -   5          Name$" userControlGroupLineToFinish��5   6     5      -   5        $! userControlGroupLineToWatch��5   6     5      -   5        $' !userControlGroupLineRecentlyWatch��5   6     5      -   5        $' !userControlGroupLineRecentlyAdded��5   6     5      -   5        $ userControlGroupLineLocal��5   6   5      5      5      5      �� 5      -	   5         ��Name$ 
tabLibrary��5      $��Library��6*   $	��110��6;   $��40��6G   $��15,2,6,2q�6S   $��0q�6f   .��5      � .+�5       �� $��Hidden=�6#   $��Stretch=�6H   $��Stretch=�6m   $��1,0,0,0q�6�   .��5!      � -
   5        $ 
panelGenre��5!   $   5"      &    WpfApplication1.UserControlGroup  5#      -   5        	  Name$	 userControlGroup��5#   *   $y�Hidden=�6D   +   %WpfApplication1.UserControlFlmPreview  5$      -   5        
  Name$
 userControlFilmPreview��5$   /   $��-1,0,0,0q�6O   $y�Hidden=�6a   $
��Auto��6u   $
��Auto��6�   5%      5&      5'      �� 5(   
   $��Right=�6   $��23��61   $��	0,22,10,0q�6=   $	��Top=�6P    �� Orientation$ 
Horizontal=�6h   $	��203��6�   .+�5)      	� -   5         	�Name$ radioButtonGenre��5)      $��Genre��64   $��Center=�6D   
�������6r   	� 5*      -   5        $ radioButtonYear��5*      $
��Year��63   $��Center=�6B   
�������6p   	� 5+      -   5        $ radioButtonActor��5+      $��Actor��64   $��Center=�6D   
�������6r   	� 5,      -   5        $ radioButtonDirector��5,      $��Director��67   $��Center=�6J   
�������6x   5-      5.      5/      