   M S B A M L   `   `   `  ����G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectAlpha.ViewsProjectAlpha.Views  5   	   A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels  5   	   &     ProjectAlpha.Views.StartupWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectAlpha.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   6
viewModels%clr-namespace:ProjectAlpha.ViewModels  5   	     � Title$  Alpha��5
   	   $	��500��6   $	��350��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6G    � WindowStyle$
 None=�6l    � Icon$! /Assets/ALPHA_LOGO_BLUE.ico��6    � DataContext 5      .   (ProjectAlpha.ViewModels.StartupViewModel  5   
   .��5      �  � UseLayoutRounding .  .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5, 0&�67   .��5      � 	 � Color$	 #3c77d8��6#   � 5      $	 #18204b��6#   
 � Offset$
 1Q�63   � 5      $	 #2d3a85��6#   $	
 0.5Q�63   5      5      �� 5   
   $	��280��6   $	��340��6    
�������$	��Top=�6:   $
��0,80q�6R    �� RadiusY$ 25.15��6`    �� RadiusX$ 25.15��6p    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFBBBBBB��6#      	Direction$ 0Q�65      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6k   5      � 5   
   $	��280��6   $	��340��6   $	��Top=�6(   $
��0,80q�6@   .+�5      �� $��Configuraçes Iniciais��6   $��Center=�65   $��15q�6R   
�������$��18(�6p   �� 5      -   5         ��Name$ loginMessage��5      $#��Usuário ou senha inválidos.��6.   $��Center=�6Q   $��55q�6n   
���  ��$��14(�6�   $y�Hidden=�6�   �� 5       $��Center=�6   $��10q�64   .+�5!      �� $	��220��5#      $��0q�6'   $	��Top=�62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Instância SQL Server��5$       &  "MaterialDesignFloatingHintComboBox#��[  5%      ��5!      �� *sqlInstances+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5"      �� *selectedSqlInstance+$ TwoWay=�$ PropertyChanged=�5%      �� 5&      $��Center=�5'      $��0,25,0,5q�69   
�������$	��220��6]   $��50��6i   $	��Top=�6u    �� TextAlignment$ Center=�6�   ��5&      �� *
statusText+$ TwoWay=�$ PropertyChanged=�5'   �   �� 5(      $��90��6   $��Avançar��6D   $��0,50,0,0q�6V   ��6$   �� *nextCommand+6V   5)      5*      � 5+   
   $	��Top=�6   $��Right=�6(   .+�5,      �� -   5         ��Name$ closeBtn��5,   <   $��0q�6�   
������ 
������ $��5,3,5,0q�6�   $
��Left=�6�   $��30��6�   $	��Top=�6�   ��6   �� *closeWindowCommand+��6N   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Power=�   Size$ 30X�6�   5-      �� 5.   
   $/��)Desenvolvido por Leonardo Carvalho - 2020��6   $��Center=�5/      $��0,25,0,5q�62   
�������$��Bottom=�50   '   $ Center=�51      52      54      