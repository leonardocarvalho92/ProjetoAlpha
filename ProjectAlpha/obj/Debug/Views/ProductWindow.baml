   M S B A M L   `   `   `  ����G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectAlpha.ViewsProjectAlpha.Views  5   	   A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels  5	   	   &     ProjectAlpha.Views.ProductWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectAlpha.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   E ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  5   	   6
viewModels%clr-namespace:ProjectAlpha.ViewModels  5	   	     � Title$  ProductWindow��5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   $��1q�5   	    � ShowInTaskbar .  ���#1e1f1e��5   	   �� *height+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5   	   �� *width+$ TwoWay=�$ PropertyChanged=�
 � Top 5   	   �� *top+$ TwoWay=�$ PropertyChanged=� � Left 5   	   �� *left+$ TwoWay=�$ PropertyChanged=� � DataContext 5      .   (ProjectAlpha.ViewModels.ProductViewModel  5   
   .��5      � .+�5   
   � $��40��6   $	��Top=�6   .+�5      �� ��5      �� 5      	 �� EndPoint$	 0.5,1&�6*   
 �� 
StartPoint$
 0.5, 0.1&�6;   .��5      �  � Color$ #5ea0fa��6'   � 5      $ #3f51b5��6'    � Offset$ 1Q�67   � 5       $ #326bc9��6'   $	 0.2Q�67   5!      5#      �� 5$      $��Produtos��6   $	��Top=�6(   $��Center=�6@   $
��Bold"�6]   $��20(�6o    "  PrimaryHueLightForegroundBrush#��[  6}   $	��0,5q�6�    J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         	Direction$	 -20Q�6'      RenderingBias$ Quality=�67      
BlurRadius$ 5Q�6O   5(      �� 5)      -   5         ��Name$ minimizeBtn��5)      $��25��6�   $��0q�6�   $	��Top=�6�   $��Right=�6�   $��0,5,35,0q�6�   
������ $��0q�6  
������ ��6*   �� *minimizeWindowCommand+��6T   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Minus=�   Size$ 20X�6  �� 5*      -   5        $ closeBtn��5*      $��25��6�   $��0q�6�   $	��Top=�6�   $��Right=�6�   $��0,5,3,0q�6�   
������ $��0q�6�   
������ ��6'   �� *closeWindowCommand+��6N     $ Close=�$ 20X�6  5+      � 5,   
   $��0,40,0,0q�6   .+�5.        Dragablz.TabablzControl  .@�50      �� -   5         ��Name$ consultaTabMenu��50      $��Consulta��63    �� 
IsSelected 6E   �� *isQueryTabFocused+.��51      � $��
10,20,10,0q�6   $	��Top=�6/   .+�52      �� $��0,0,0,20q�6%    �� Orientation$ Vertical=�67   $	��Top=�6N   $��Center=�6f   .+�53      �� $ 
Horizontal=�6)   $��Center=�6B   .+�54   "   �� -   5         ��Name$ productsQueryTextBox��55   *    �� AcceptsReturn .  $	��300��57   *   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Produto��58   *    % !MaterialDesignFloatingHintTextBox#��[ 59   *   $��14(�5:   *   ��54   +   �� *searchFieldText+$ TwoWay=�$ PropertyChanged=�.��5:   8    J� InputBindings 5;   &   �� 5<   *   
 �� Key$ Return��6^    �� Command 65   �� *searchProductCommand+6^   .��5=   =   5>   #   �� 5?   "   $
��10,0q�6S   ��6*   �� *searchProductCommand+��5@   &   �� 5A   *   $ 
Horizontal=�65   .+�5B   .   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6F   $��0,3,3,0q�6T   $
��Left=�6e   �� 5C   .   $��Buscar��68   5D   +   5F   #   5G      �� 5H      $ 
Horizontal=�6)   $��Center=�6B   .+�5J   "   &   System.Windows.Controls.DataGrid     RowBackground
 �����}�. ���#97c8fc   AutoGenerateColumns .  $    HorizontalScrollBarVisibility$
  Auto=�5P   +   "!   VerticalScrollBarVisibility$
! Auto=�5Q   +   $��20,30,20,10q�5R   +   "   
IsReadOnly" . $��2q�5T   +     PrimaryHueDarkBrush#��[ 5U   +   #   CanUserAddRows# .  $   CanUserDeleteRows$ .  %   SelectionMode$% Single=�5X   +   &   SelectionUnit$& FullRow=�5Y   +   '   GridLinesVisibility$	' All=�5Z   +   (   VerticalGridLinesBrush#( [ 5[   +   )   HorizontalGridLinesBrush#) [ 5\   +   *   AreRowDetailsFrozen* . +   CanUserResizeColumns+ . ,   CanUserResizeRows, .  $
��1000��5`   +   ��5N   +   �� *dataGridSource+- �� SelectedItem- 5O   +   �� *gridCurrentProduct+$ TwoWay=�$ PropertyChanged=�. � 	Resources. 5c   &   *  $System.Windows.Controls.DataGridCell/ �� 
TargetType0 �� Triggers1 P� Property2 P� Value3 �� Property  PrimaryHueLightBrush4 �� Value��%�   '        7  �� 5d   *   "/  60   0 5e   .   P� 5f   2   1 �@ 
IsSelected2 . . �5g   6   �� 3 � ��84   6S   5h   3   5j   +   5k   '    5o   &   d� 5p   *   5 d� MouseAction$5 LeftDoubleClicke�67   6 �� CommandParameter$6 products��5r   -    5q   -   �� *gridDoubleClickCommand+5r   -   7   Columns7 5w   &   0	  *System.Windows.Controls.DataGridTextColumn	  5x   *   ,
  &System.Windows.Controls.DataGridColumn8 
  Header$8 ID��6T   9 
  Width5  /System.Windows.Controls.DataGridLengthConverter$9 55 6`   1  +System.Windows.Controls.DataGridBoundColumn:   Binding: 6=   �� *id+6`   	  5y   *   $8 Produto��6V   $	9 180 6g   : 6=   �� *name+6g   	  5z   *   $8 
Quantidade��6X   $	9 110 6l   : 6=   �� *amount+6l   	  5{   *   $8 
Fornecedor��6_   $	9 160 6s   : 6=   �� *provider_name+6s   	  5|   *   $8 ID Fornecedor��6]   $	9 160 6t   ; 
  
Visibility$; Hidden=�6�   : 6=   �� *provider_id+6�   5�   #   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   $��0,60,0,0q�6_   .+�5�   "   �� ��6)   �� *newProductCommand+��5�   &   �� 5�   *   $ 
Horizontal=�65   .+�5�   .     $ ShoppingCartPlus=�6F   
�������$��0,2,8,0q�6q   �� 5�   .   $
��Novo��68   5�   +   5�   #   �� 5�   "   $��50,0,0,0q�6]   ��6)   �� *!deleteGridCurrentProductCommand+��5�   &   �� 5�   *   $ 
Horizontal=�65   .+�5�   .     $ RemoveShoppingCart=�6F   
�������$��0,2,8,0q�6s   �� 5�   .   $��Excluir��68   5�   +   5�   #   5�      5�      5�      5�      �� 5�      -   5        $��cadastroTabMenuProducts��5�      $��Cadastro��69    6K   �� *isRegisterTabFocused+.��5�      � $��	0,20,10,0q�6   $	��Top=�6.   $��Center=�6F   .+�5�      �� $ Vertical=�6&   $	��Top=�6=   $��Center=�6U   .+�5�      �� $ 
Horizontal=�6)   $��Center=�6i    6B   �� *currentProduct+.+�5�   "   �� -   5        $ productNameTextBox��5�   *   < �� 	MaxLength$	< 300��6|   $	��250��6�   $ Produto��6�   #��[ 6	  $��14(�6D  ��6�   �� *name+$ TwoWay=�$ PropertyChanged=�6D  �� 5�   "   -   5        $ amountTextBox��5�   *   $< 9��6~   $��	80, 0,0,0q�6�   $	��250��6�   $ 
Quantidade��6�   #��[ 6!  $��14(�6\  ��6�   �� *amount+$ TwoWay=�$ PropertyChanged=�6\  �� 5�   "   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� -   5        = ��Name$= providerComboBox��5�   +   $��Center=�5�   +   $
��Left=�5�   +   $	��250��5�   +   $ 
Fornecedor��5�   +    & "MaterialDesignFloatingHintComboBox#��[ 5�   +   $��14(�5�   +   > �� SelectedValue> 5�   +   �� *selectedProvider+$ TwoWay=�$ PropertyChanged=���5�   +   �� *providersList+$ TwoWay=�$ PropertyChanged=�5�   +   �� 5�   "   
������ $��5,13,0,0q�6i   $��5q�6{   $��0q�6�   ��6)   �� *refreshListCommand+��5�   &     5�   *   $ Refresh=�6B   #��[ 6Q   5�   #   5�      5�      �� 5�      $ 
Horizontal=�6%   $��Center=�6>   $��	0,260,0,0q�6[   .+�5�      �� ��6%   �� *resetCurrentProductCommand+��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     $ ShoppingCartPlus=�6B   
�������$��0,2,8,0q�6m   �� 5�   *   $
��Novo��64   5�   '   5�      �� 5�      $��50,0,0,0q�6S   ��6%   �� *saveCurrentProductCommand+��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     
�������$��0,2,8,0q�6r    6B   �� *SaveBtnIcon+6r   �� 5�   *   ��64   �� *SaveBtnText+5�   '   5�      �� 5�      $��50,0,0,0q�6U   ��6%   �� *deleteCurrentProductCommand+{�6g   �� *CanDeleteProduct+��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     $ RemoveShoppingCart=�6B   
�������$��0,2,8,0q�6o   �� 5�   *   $��Excluir��64   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      