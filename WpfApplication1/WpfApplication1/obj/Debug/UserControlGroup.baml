   M S B A M L   `   `   `  ����  WpfApplication1&     WpfApplication1.UserControlGroup   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$  userControl��5      $��0q�5      ���	#FF0C0C0C � 	Resources 5	         OnLoaded �� TargetProperty �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value   EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode R� KeyTime  System.Windows.Visibility	   Visible
 R� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value 
 OnHide   Hidden��%}  &	        &	 Q    �� 5
      .��5      r� $ (Border.BorderThickness)�6&   $ userControl��6[   .	�5        $ 0��6   $ 	800,0,0,0q�6*     5      $ 0:0:0.5��6   $ 0q�60    5        5      $ EaseOut=�6   5      5      T� 5      $ (UIElement.Visibility)�6#   $ userControl��6V   ..�5      i� $ 0��6   #
 Z	 6)   i� 5      $ 0:0:0.5��6   #
 Z	 6/   5      U� 5      $ (UIElement.Opacity)�6#   $ userControl��6S   .\�5        $ 0��6   $ 0Q�6'     5      $ 0:0:0.5��6   $ 1Q�6-   5      5      �� 5      .��5      U� $ (UIElement.Opacity)�6#   $ userControl��6S   .\�5        $ 0:0:0.5��6   $ 0Q�6-   5      T� 5       $ (UIElement.Visibility)�6#   $ userControl��6V   ..�5!      i� $ 0:0:0.5��6   #
 Z 6/   5"      5#      5$       � Triggers 5%      :� 5&       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5'      �� #��[  6   �� 5(      #��[ 6   5)      .��5+      � .+�5,   
   �� -   5         ��Name$ 
panelTitle��5,       �� Orientation$ 
Horizontal=�6)   $	��Top=�6B   $
��Left=�6Z   .+�5-      �� -   5         ��Name$ buttonLibrary��5-      $��	Library >��6,   $
��Left=�6C   $��10,0,0,0q�6^   $	��Top=�6p   
�������$��18(�6�   $
��Bold"�6�   $��0q�6�   ��6�   Z� ��6�   Z� 6�   �� 5.      -   5        $ buttonTitle��5.      $��Action >��6*   $
��Left=�6@   $��5,0,0,0q�6[   $	��Top=�6l   
�������$��18(�6�   $
��Bold"�6�   $��0q�6�   ��6�   Z� ��6�   Z� 6�   5/      �� 50   
   $��1��6   $��
10,26,10,0q�6   ���	#FFACACAC$	��Top=�6F   �� 51   
   $��Hidden=�6   $��0,27,0,0q�6<   .��52      � -   5         �Name$ panel��52       � Orientation$ 
Horizontal=�6'   $��10q�6@   53      54      55      