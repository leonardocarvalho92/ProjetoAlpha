   M S B A M L   `   `   `  ����G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjectAlphaProjectAlpha  5   	   A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels  5   	       ProjectAlpha.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProjectAlpha     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   6
viewModels%clr-namespace:ProjectAlpha.ViewModels  5   	     � Title$  Alpha��5
   	   $	��700��5   	   $
��1000��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$8 2/ProjectAlpha;component/Assets/ALPHA_LOGO_BLUE.ico��5   Q   ��5   	   �� *height+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5   	   �� *width+$ TwoWay=�$ PropertyChanged=�
 � Top 5   	   �� *top+$ TwoWay=�$ PropertyChanged=� � Left 5   	   �� *left+$ TwoWay=�$ PropertyChanged=� � DataContext 5      +   %ProjectAlpha.ViewModels.MainViewModel  5   
   .��5      � .+�5   
   � .+�5      �� $��60��6   $	��Top=�6$   ��5      �� 5       �� EndPoint$ 0.5,1&�6*   	 �� 
StartPoint$	 0.5, 0&�6;   .��5      � 
 � Color$
 #3c77d8��6'   � 5      $
 #18204b��6'    � Offset$ 1Q�67   � 5      $
 #2d3a85��6'   $	 0.5Q�67   5      5!      � 5#      $��60��6   $	��Top=�6   .+�5$      �� $��Alpha��6   $��90��6)   $��Italic$�64   $��28(�6G   
�������$
��Left=�6h   $��30,10q�6�    J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&      5(      � 5)      $��
110,0,0, 0q�6   .+�5*      ��  �� Orientation$ 
Horizontal=�6!   
������ $��60��6S   .+�5+      c� 
������    MaterialDesignToolBar#��[  6;   .@�5,      o� 
������   MaterialDesignMenu#��[ 6<   .@�5-   "   m� $��60��6+   
������   MaterialDesignMenuItem#��[ 6P   ��5.   &   �� 5/   *   $ 
Horizontal=�65   .+�50   .   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�6F   
�������$��0,1,5,0q�6f   �� 51   .   $��Início��68   
�������6F   52   +   54   #   m� 55   "   $��60��6+   
������ #��[ 6Q   ��56   &   �� 57   *   $ 
Horizontal=�65   .+�58   .     $ CreateNewFolder=�6F   
�������$��0,1,5,0q�6s   �� 59   .   $��	Cadastros��68   
�������6I   5:   +   .@�5<   &   m� $��60��6/     PrimaryHueMidBrush#��[ 6j   #��[ 6�    m� Command 6;   �� *showProvidersWindowCommand+��5=   *   �� 5>   .   $ 
Horizontal=�69   .+�5?   2     $ 
AccountBox=�6J   
�������$��0,1,5,0q�6p   �� 5@   2   $��Fornecedores��6<   
�������6P   5A   /   5C   '   m� 5D   &   $��60��6/   #��[ 6i   #��[ 6�    6;   �� *showProductsWindowCommand+��5E   *   �� 5F   .   $ 
Horizontal=�69   .+�5G   2     $ ShoppingCart=�6J   
�������$��0,1,5,0q�6r   �� 5H   2   $��Produtos��6<   
�������6L   5I   /   5K   '   5L   #   m� 5M   "   $��60��6N   
������ #��[ 6s    6+   �� *signOutCommand+��5N   &   �� 5O   *   $ 
Horizontal=�65   .+�5P   .     $ ExitRun=�6F   
�������$��0,1,5,0q�6i   �� 5Q   .   $
��Sair��68   
�������6D   5R   +   5T   #   5U      5V      5W      5Z      5[      � 5\      -   5         �Name$ registerSubMenu��5\      $��
245,50,0,0q�6,   $	��135��6@   $	��Top=�6L   $
��Left=�6d   ��6   �� *registerSubMenuHeight+.+�5]      c� $��80��6   $	��135��6&   .@�5^      �� ��5_      �� 5`      $ 0.5,1&�62   $	 0.5, 0&�6C   .��5a   "   � $
 #61a0ff��6/   � 5b   "   $
 #3083ff��6/   $	 0.5Q�6?   � 5c   "   $
 #194d9a��6/   $ 1Q�6?   5d      5f      �� 5g      6    o� 5h      .@�5i      m� $
��Menu��6#   .@�5j      m� .@�5k   "   �� .+�5l   &   �� -   5         ��Name$ providersMenuBtn��5l   -   $	��Top=�6v   $��40��6�   $��0q�6�   
������ 
�������$
��Left=�6�   ��6G   �� *showProvidersWindowCommand+.��5m   *   �� $ 
Horizontal=�65   .+�5n   .     $ 
AccountBox=�6F   
�������$��0,2,2,0q�6l   �� 5o   .   $��Fornecedores��68   5p   +   5q   '   �� 5r   &   -   5        $ productsMenuBtn��5r   -   $	��Top=�6t   $��40��6�   $��0q�6�   
������ 
�������$
��Left=�6�   ��6F   �� *showProductsWindowCommand+.��5s   *   �� $ 
Horizontal=�65   .+�5t   .     $ ShoppingCart=�6F   
�������$��0,2,2,0q�6n   �� 5u   .   $��Produtos��68   5v   +   5w   '   5x   #   5y      5z      5{      5|      5~      � 5�      $��0,60,0,0q�6   .+�5�      �� $ 
Horizontal=�6   $��10q�66   .+�5�      �� 
������ $��0q�6b   $	��170��6v   $	��100��6�   $	��Top=�6�   $
��Left=�6�   $	��5,0q�6�   ��6   �� *maxProductWindowCommand+y�6�   �� *productThumbIsVisible+.��5�      �� $��/Assets/productThumb.png��6    5�      �� 5�      
������ $��0q�6c   $	��170��6w   $	��100��6�   $	��5,0q�6�   $	��Top=�6�   $
��Left=�6�   ��6   �� *maxProviderWindowCommand+y�6�   �� *providerThumbIsVisible+.��5�      �� $��/Assets/providerThumb.png��6   5�      5�      �� 5�      $	��500��6   $��Center=�6)   $��Center=�6D   .+�5�      �� $!��/Assets/ALPHA_LOGO_BLUE.png��6   $	��200��6A   $	��120��6M   �� 5�      $ ��Alpha - Sistema de Gestão��6    $��Center=�6A   ���#666666$��14(�6s   5�      �� 5�      $/��)Desenvolvido por Leonardo Carvalho - 2020��6   $��263,0,379,20q�6M   $��Center=�6c   $��Bottom=�6�   ���#6b6b6b$��12(�6�   $��1��6�   � 5�      $��Bottom=�6   $��20��62   $��2��6>   .+�5�      �� ��5�      �� 5�      $ 0.5,1&�62   $	 0.5, 0&�6C   .��5�   "   � $
 #3c77d8��6/   � 5�   "   $
 #18204b��6/   $ 1Q�6?   � 5�   "   $
 #2d3a85��6/   $	 0.8Q�6?   5�      5�      �� 5�      $ 
Horizontal=�6!   $��20��6:   .+�5�      �� $��
Usuário: ��6%   
�������$
��Left=�6I   $��14(�6d   $��Bottom=�6r   $��5,0,0,1q�6�   �� 5�      -   5         ��Name$ logedUserTextBlock��5�   $   
�������$
��Left=�6s   $��16(�6�   $��5,0,0,1q�6�   $��Bottom=�6�   ��6A   �� *userFirstName+6�   5�      5�      5�      5�      5�      5�      