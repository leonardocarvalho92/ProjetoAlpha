   M S B A M L   `   `   `  ����G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectAlpha.ViewsProjectAlpha.Views  5   	   A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels  5   	   $    ProjectAlpha.Views.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectAlpha.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   6
viewModels%clr-namespace:ProjectAlpha.ViewModels  5   	     � Title$  Alpha��5
   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � WindowStyle$
 None=�6k    � Icon$! /Assets/ALPHA_LOGO_BLUE.ico��6~    � DataContext 5      ,   &ProjectAlpha.ViewModels.LoginViewModel  5   
   .��5      �  � UseLayoutRounding .  .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      � 	 � Color$	 #3c77d8��6#   � 5      $	 #18204b��6#   
 � Offset$
 1Q�63   � 5      $	 #2d3a85��6#   $	
 0.5Q�63   5      5      �� 5   
   $"��/Assets/ALPHA_LOGO_WHITE.png��6   $	��100��66   $	��100��6B   $	��top=�6O   $��130,40,120,0q�6g   �� 5   
   $	��280��6   $	��240��6    
�������$��Bottom=�6:   $��0,110q�6U    �� RadiusY$ 25.15��6d    �� RadiusX$ 25.15��6t    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFBBBBBB��6#      	Direction$ 0Q�65      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6k   5      � 5   
   $	��280��6   $	��240��6   $��Bottom=�6(   $��0,110q�6C   .+�5       �� $��LOGIN��6   $��Center=�6%   $��25q�6B   
�������$��18(�6`   �� 5!      -   5         ��Name$ loginMessage��5!      $#��Usuário ou senha inválidos.��6.   $��Center=�6Q   $��55q�6n   
���  ��$��14(�6�   $y�Hidden=�6�   �� 5"      $��Center=�6   $��10q�64   .+�5#      �� -   5         ��Name$ userTextBox��5#       �� 	MaxLength$ 50��6�   $	��200��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuário��6�    %  !MaterialDesignFloatingHintTextBox#��[  6#  $
��0,10q�6^  $��18(�6l  ��6�   �� *
username+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6z  5$      G� 5%      -   5         G�Name$ passwordTextBox��5%      $	��200��6z   $ Senha��6�    ) %MaterialDesignFloatingHintPasswordBox#��[ 6�   $��18(�6   J� InputBindings 5&      �� 5'      
 �� Key$ F1��6I    �� Command 6%   �� *showHashCommand+6I   �� 5(      $ Return��6G    6%   �� *signInCommand+6G   5*      5,      5-      �� 5.   
   -   5         ��Name$ loginBtn��5.      $��Bottom=�6#   $
��0,90q�6>   $	��150��6L   $��LOGIN��6X   ��6h   �� *signInCommand+�� 5/   
   $��Esqueceu sua senha?��6   $��Center=�6/   $��Bottom=�6L   $��50q�6g   
������� � Cursor$
 Hand��6�   � 50   
   $	��Top=�6   $��Right=�6(   .+�51      �� -   5        $ closeBtn��51      $��0q�6�   
������ 
������ $��5,3,5,0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   ��6'   �� *closeWindowCommand+��6N   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Power=�    Size$  30X�6�   52      �� 53   
   $/��)Desenvolvido por Leonardo Carvalho - 2020��6   $��Center=�54      $��0,25,0,5q�62   
�������$��Bottom=�55   '   ! �� TextAlignment$! Center=�56      57      59      