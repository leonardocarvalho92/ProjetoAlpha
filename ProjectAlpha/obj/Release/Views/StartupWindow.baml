   M S B A M L   `   `   `  ���� G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectAlpha.ViewsProjectAlpha.Views  A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels  &     ProjectAlpha.Views.StartupWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:ProjectAlpha.Views     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6
viewModels%clr-namespace:ProjectAlpha.ViewModels    � Title$  Alpha��$	��500��$	��350�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � Icon$! /Assets/ALPHA_LOGO_BLUE.ico�� � DataContext .   (ProjectAlpha.ViewModels.StartupViewModel  .���  � UseLayoutRounding .  .+��� $	��280��$	��Top=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5, 0&�.��� 	 � Color$	 #3c77d8��� $	 #18204b��
 � Offset$
 1Q�� $	 #2d3a85��$	
 0.5Q��� $	��280��$	��340��
�������$	��Top=�$
��0,80q� �� RadiusY$ 25.15�� �� RadiusX$ 25.15�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFBBBBBB��   	Direction$ 0Q�   
BlurRadius$ 15Q�   RenderingBias$ Quality=�   ShadowDepth$ 1Q�� $	��280��$	��340��$	��Top=�$
��0,80q�.+��� $��Configuraçes Iniciais��$��Center=�$��15q�
�������$��18(��� -    ��Name$ loginMessage��$#��Usuário ou senha inválidos.��$��Center=�$��55q�
���  ��$��14(�$y�Hidden=��� $��Center=�$��10q�.+��� $	��220��$��0q�$	��Top=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Instância SQL Server�� &  "MaterialDesignFloatingHintComboBox#��[  ���� *sqlInstances+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *selectedSqlInstance+$ TwoWay=�$ PropertyChanged=��� $��Center=�$��0,25,0,5q�
�������$	��220��$��50��$	��Top=� �� TextAlignment$ Center=����� *
statusText+$ TwoWay=�$ PropertyChanged=��� $��90��$��Avançar��$��0,50,0,0q����� *nextCommand+� $	��Top=�$��Right=�.+��� -    ��Name$ closeBtn��$��0q�
������ 
������ $��5,3,5,0q�$
��Left=�$��30��$	��Top=���0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Power=�   Size$ 30X��� $/��)Desenvolvido por Leonardo Carvalho - 2020��$��Center=�$��0,25,0,5q�
�������$��Bottom=�$ Center=�