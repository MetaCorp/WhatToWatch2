   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5      )    #WpfApplication1.UserControlGroupBox   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,meclr-namespace:WpfApplication1     5      -   5          >�Name$  userControl��5      $��	40,20,0,0q�5   7    � 	Resources 5	         OnLoaded �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%�   &	        �� 5
   
   .��5      U� $ (UIElement.Opacity)�6,   $ userControl��6\   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $ 1Q�69   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� -   5         ��Name$ OnLoaded_BeginStoryboard��5      #��[  6@   5      .��5      � .+�5   
   �� ���	#FF3A3A3A���	#FF363636	 �� RadiusX$	 5��68   
 �� RadiusY$
 5��6D   $��0q�6�   $
��Left=�6�   ��6P   �� *ActualWidth+ �� ElementName$ 
labelTitle��6�   �� 5   
   -   5         ��Name$ 
labelTitle��5      $��Action >��6%   $
��Left=�6;   $
��15,0q�6V   $	��Top=�6d   
�������$��18(�6�   $
��Bold"�6�   $��0,0,30,0q�6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   ���	#FF191919���	#FF363636$��0,26,0,0q�68   �� 5   
   -   5         ��Name$ content��5       �� Orientation$ 
Horizontal=�6&   $��
10,37,10,8q�6?   .+�5      %   WpfApplication1.UserControlFilm  -   5          Name$ userControlFirstFilm��5   !   $
��Left=�6?   $
��Auto��6Z   $	��Top=�6g   � 5      -   5         �Name$ panel��5       � Orientation$ Vertical=�6'   5      5      5      