   M S B A M L   `   `   `  ���� G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjectAlphaProjectAlpha  A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels      ProjectAlpha.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ProjectAlpha     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6
viewModels%clr-namespace:ProjectAlpha.ViewModels    � Title$  Alpha��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=� � Icon$8 2/ProjectAlpha;component/Assets/ALPHA_LOGO_BLUE.ico������ *height+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� *width+$ TwoWay=�$ PropertyChanged=�
 � Top �� *top+$ TwoWay=�$ PropertyChanged=� � Left �� *left+$ TwoWay=�$ PropertyChanged=� � DataContext +   %ProjectAlpha.ViewModels.MainViewModel  .��� .+�� .+��� $��60��$	��Top=�����  �� EndPoint$ 0.5,1&�	 �� 
StartPoint$	 0.5, 0&�.��� 
 � Color$
 #3c77d8��� $
 #18204b�� � Offset$ 1Q�� $
 #2d3a85��$	 0.5Q�� $��60��$	��Top=�.+��� $��Alpha��$��90��$��Italic$�$��28(�
�������$
��Left=�$��30,10q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  � $��
110,0,0, 0q�.+���  �� Orientation$ 
Horizontal=�
������ $��60��.+�c� 
������    MaterialDesignToolBar#��[  .@�o� 
������   MaterialDesignMenu#��[ .@�m� $��60��
������   MaterialDesignMenuItem#��[ ���� $ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�
�������$��0,1,5,0q��� $��Início��
�������m� $��60��
������ #��[ ���� $ 
Horizontal=�.+�  $ CreateNewFolder=�
�������$��0,1,5,0q��� $��	Cadastros��
�������.@�m� $��60��  PrimaryHueMidBrush#��[ #��[  m� Command �� *showProvidersWindowCommand+���� $ 
Horizontal=�.+�  $ 
AccountBox=�
�������$��0,1,5,0q��� $��Fornecedores��
�������m� $��60��#��[ #��[  �� *showProductsWindowCommand+���� $ 
Horizontal=�.+�  $ ShoppingCart=�
�������$��0,1,5,0q��� $��Produtos��
�������m� $��60��
������ #��[  �� *signOutCommand+���� $ 
Horizontal=�.+�  $ ExitRun=�
�������$��0,1,5,0q��� $
��Sair��
�������� -    �Name$ registerSubMenu��$��
245,50,0,0q�$	��135��$	��Top=�$
��Left=����� *registerSubMenuHeight+.+�c� $��80��$	��135��.@��� ���� $ 0.5,1&�$	 0.5, 0&�.��� $
 #61a0ff��� $
 #3083ff��$	 0.5Q�� $
 #194d9a��$ 1Q��� o� .@�m� $
��Menu��.@�m� .@��� .+��� -    ��Name$ providersMenuBtn��$	��Top=�$��40��$��0q�
������ 
�������$
��Left=����� *showProvidersWindowCommand+.���� $ 
Horizontal=�.+�  $ 
AccountBox=�
�������$��0,2,2,0q��� $��Fornecedores���� -   $ productsMenuBtn��$	��Top=�$��40��$��0q�
������ 
�������$
��Left=����� *showProductsWindowCommand+.���� $ 
Horizontal=�.+�  $ ShoppingCart=�
�������$��0,2,2,0q��� $��Produtos��� $��0,60,0,0q�.+��� $ 
Horizontal=�$��10q�.+��� 
������ $��0q�$	��170��$	��100��$	��Top=�$
��Left=�$	��5,0q����� *maxProductWindowCommand+y��� *productThumbIsVisible+.���� $��/Assets/productThumb.png���� 
������ $��0q�$	��170��$	��100��$	��5,0q�$	��Top=�$
��Left=����� *maxProviderWindowCommand+y��� *providerThumbIsVisible+.���� $��/Assets/providerThumb.png���� $��Center=�$��Center=�$��280,210,396,260q�$��1��.+��� $!��/Assets/ALPHA_LOGO_BLUE.png��$	��200��$	��120���� $ ��Alpha - Sistema de Gestão��$��Center=����#666666$��14(��� $/��)Desenvolvido por Leonardo Carvalho - 2020��$��263,0,379,20q�$��Center=�$��Bottom=����#6b6b6b$��12(�$��1��� $��Bottom=�$��20��$��2��.+��� ���� $ 0.5,1&�$	 0.5, 0&�.��� $
 #3c77d8��� $
 #18204b��$ 1Q�� $
 #2d3a85��$	 0.8Q��� $ 
Horizontal=�$��20��.+��� $��
Usuário: ��
�������$
��Left=�$��14(�$��Bottom=�$��5,0,0,1q��� -    ��Name$ logedUserTextBlock��
�������$
��Left=�$��16(�$��5,0,0,1q�$��Bottom=����� *userFirstName+