   M S B A M L   `   `   `  ����G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjectAlphaProjectAlpha  5   	   A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
   	   !    ProjectAlpha.ProviderWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProjectAlpha     5   	   <
viewModels%clr-namespace:ProjectAlpha.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   E ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  5	   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5
   	     � Title$  ProviderWindow��5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   $��1q�5   	    � ShowInTaskbar .  ���#1e1f1e��5   	   �� *height+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5   	   �� *width+$ TwoWay=�$ PropertyChanged=�
 � Top 5   	   �� *top+$ TwoWay=�$ PropertyChanged=� � Left 5   	   �� *left+$ TwoWay=�$ PropertyChanged=� � DataContext 5      0   *ProjectAlpha.ViewModels.ProvidersViewModel  5   
   -   5        vM��5   (   .��5      � .+�5   
   � $��40��6   $	��Top=�6   .+�5      �� ��5      �� 5      	 �� EndPoint$	 0.5,1&�6*   
 �� 
StartPoint$
 0.5, 0.1&�6;   .��5       �  � Color$ #5ea0fa��6'   � 5!      $ #3f51b5��6'    � Offset$ 1Q�67   � 5"      $ #326bc9��6'   $	 0.2Q�67   5#      5%      �� 5&      $��Fornecedores��6   $	��Top=�6,   $��Center=�6D   $
��Bold"�6a   $��20(�6s    "  PrimaryHueLightForegroundBrush#��[  6�   $	��0,5q�6�    J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         	Direction$	 -20Q�6'      RenderingBias$ Quality=�67      
BlurRadius$ 5Q�6O   5*      �� 5+      -   5         ��Name$ minimizeBtn��5+      $��25��6�   $��0q�6�   $	��Top=�6�   $��Right=�6�   $��0,5,35,0q�6�   
������ $��0q�6  
������ ��6*   �� *minimizeWindowCommand+��6T   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Minus=�   Size$ 20X�6  �� 5,      -   5        $ closeBtn��5,      $��25��6�   $��0q�6�   $	��Top=�6�   $��Right=�6�   $��0,5,3,0q�6�   
������ $��0q�6�   
������ ��6'   �� *closeWindowCommand+��6N     $ Close=�$ 20X�6  5-      � 5/   
   $��0,40,0,0q�6   .+�51        Dragablz.TabablzControl  .@�53      �� -   5         ��Name$ consultaTabMenu��53      $��Consulta��63    �� 
IsSelected 6E   �� *isQueryTabFocused+.��54      � $��
10,20,10,0q�6   $	��Top=�6/   .+�55      �� $��0,0,0,20q�6%    �� Orientation$ Vertical=�67   $	��Top=�6N   $��Center=�6f   .+�56      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5:   "   �� -   5         ��Name$ providerQueryTextBox��5;   *    �� AcceptsReturn .  $	��300��5=   *   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Fornecedor��5>   *    % !MaterialDesignFloatingHintTextBox#��[ 5?   *   $��14(�5@   *   ��5:   +   �� *searchFieldText+$ TwoWay=�$ PropertyChanged=�.��5@   8    J� InputBindings 5A   &   �� 5B   *   
 �� Key$ Return��6_    �� Command 65   �� *searchProviderCommand+6_   .��5C   =   5D   #   �� 5H   "   $
��10,0q�6T   ��6*   �� *searchProviderCommand+��5I   &   �� 5J   *   $ 
Horizontal=�65   .+�5K   .   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6F   $��0,3,3,0q�6T   $
��Left=�6e   �� 5L   .   $��Buscar��68   5M   +   5O   #   5R      �� 5S      $ 
Horizontal=�6)   $��Center=�6B   .+�5V   "   &   System.Windows.Controls.DataGrid     RowBackground
 �����}�. ���#97c8fc   AutoGenerateColumns .  $    HorizontalScrollBarVisibility$
  Auto=�5\   +   "!   VerticalScrollBarVisibility$
! Auto=�5]   +   $��20,30,20,10q�5^   +   "   
IsReadOnly" . $��2q�5`   +     PrimaryHueDarkBrush#��[ 5a   +   #   CanUserAddRows# .  $   CanUserDeleteRows$ .  %   SelectionMode$% Single=�5d   +   &   SelectionUnit$& FullRow=�5e   +   '   GridLinesVisibility$	' All=�5f   +   (   VerticalGridLinesBrush#( [ 5g   +   )   HorizontalGridLinesBrush#) [ 5h   +   *   AreRowDetailsFrozen* . +   CanUserResizeColumns+ . ,   CanUserResizeRows, .  $
��1000��5l   +   ��5Z   +   �� *dataGridSource+- �� SelectedItem- 5[   +   �� *gridCurrentProvider+$ TwoWay=�. � 	Resources. 5o   &   *  $System.Windows.Controls.DataGridCell/ �� 
TargetType0 �� Triggers1 P� Property2 P� Value3 �� Property  PrimaryHueLightBrush4 �� Value��%�   '        7  �� 5p   *   "/  60   0 5q   .   P� 5r   2   1 �@ 
IsSelected2 . . �5s   6   �� 3 � ��84   6S   5t   3   5v   +   5w   '    5{   &   d� 5|   *   5 d� MouseAction$5 LeftDoubleClicke�67   6 �� CommandParameter$6 	providers��5~   -    5}   -   �� *gridDoubleClickCommand+5~   -   7   Columns7 5�   &   0	  *System.Windows.Controls.DataGridTextColumn	  5�   *   ,
  &System.Windows.Controls.DataGridColumn8 
  Header$8 ID��6T   9 
  Width5  /System.Windows.Controls.DataGridLengthConverter$9 55 6`   1  +System.Windows.Controls.DataGridBoundColumn:   Binding: 6=   �� *id+6`   	  5�   *   $8 
Fornecedor��6V   $	9 130 6j   : 6=   �� *name+6j   	  5�   *   $8 Razão Social��6]   $	9 130 6s   : 6=   �� *social_name+6s   	  5�   *   $
8 CNPJ��6V   $9 90 6d   : 6=   �� *cnpj+6d   	  5�   *   $8 	Endereço��6X   $	9 130 6j   : 6=   �� *adress+6j   	  5�   *   $8 Telefone��6W   $	9 100 6i   : 6=   �� *phone+6i   	  5�   *   $8 Email��6W   $	9 110 6f   : 6=   �� *email+6f   	  5�   *   $
8 Ramo��6_   $	9 110 6m   : 6=   �� *main_activity+6m   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�   *   $8 Ativo��6\    - )MaterialDesignDataGridCheckBoxColumnStyle;   ElementStyle#; [ 6k   $9 80 6�   : 6A   �� *active+6�   5�   #   5�      �� 5�      $ 
Horizontal=�6)   $��Center=�6B   $��0,60,0,0q�6_   .+�5�   "   �� ��6)   �� *newProviderCommand+��5�   &   �� 5�   *   $ 
Horizontal=�65   .+�5�   .     $ 	PersonAdd=�6F   
�������$��0,2,8,0q�6j   �� 5�   .   $
��Novo��68   5�   +   5�   #   �� 5�   "   $��50,0,0,0q�6W   ��6)   �� *deleteGridProviderCommand+��5�   &   �� 5�   *   $ 
Horizontal=�65   .+�5�   .     $ PersonRemove=�6F   
�������$��0,2,8,0q�6m   �� 5�   .   $��Excluir��68   5�   +   5�   #   5�      5�      5�      5�      �� 5�      -   5        $��cadastroTabMenu��5�      $��Cadastro��61    6C   �� *isRegisterTabFocused+.��5�      � $��	0,20,10,0q�6   $	��Top=�6.   $��Center=�6F   .+�5�      �� $ Vertical=�5�   %   $	��Top=�5�   %   $��Center=�5�   %    5�   %   �� *currentProvider+$ TwoWay=�$ PropertyChanged=�.+�5�      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� -   5        $ providerNameTextBox��5�   *   < �� 	MaxLength$	< 300��6}   $	��250��6�   $ 
Fornecedor��6�   #��[ 6  $��14(�6M  ��6�   �� = �� Path$
= name�$ TwoWay=�$ PropertyChanged=�6M  �� 5�   "   -   5        $ socialTextBox��5�   *   $	< 300��6w   $��	80, 0,0,0q�6�   $	��250��6�   $ Razão Social��6�   #��[ 6$  $��14(�6_  ��6�   �� *social_name+$ TwoWay=�$ PropertyChanged=�6_  �� 5�   "   5�      �� 5�      $ 
Horizontal=�6)   $
��Left=�6B   .+�5�   "   �� -	   5        $ cnpjTextBox��5�   *   .  (MaterialDesignThemes.Wpf.TextFieldAssist>   TextFieldCornerRadius$> 5��6?   $< 14��6�   $	��250��6  $
 CNPJ��6  #��[ 6>  $��14(�6y  ��6�   �� *cnpj+$ TwoWay=�$ PropertyChanged=�.��6�   5�   &   �� 5�   *   $ Return��6s    65   �� ? �� ElementName$? vM��$= GetWebProviderCommand�6s   .��5�   =   5�   #   �� 5�   "   -
   5        $ adressTextBox��5�   *   $	< 300��6w   $��	80, 0,0,0q�6�   $	��250��6�   $ 	Endereço��6�   #��[ 6  $��14(�6U  ��6�   �� *adress+$ TwoWay=�$ PropertyChanged=�6U  5�      �� 5�      $ 
Horizontal=�6)   $
��Left=�6B   .+�5�   "   �� -   5        $ phoneTextBox��5�   *   $< 13��6}   $	��200��6�   $ Telefone��6�   #��[ 6  $��14(�6F  ��6�   �� *phone+$ TwoWay=�$ PropertyChanged=�6F  �� 5�   "   -   5        $ emailTextBox��5�   *   $	< 300��6{   $��
130, 0,0,0q�6�   $	��250��6�   $ Email��6�   #��[ 6  $��14(�6V  ��6�   �� *email+$ TwoWay=�$ PropertyChanged=�6V  5�      �� 5�      $ 
Horizontal=�6)   $
��Left=�6B   .+�5�   "   �� -   5        $ activityTextBox��5�   *   $	< 300��6y   $	��Top=�6�   $	��200��6�   $ Ramo de Atividade��6�   #��[ 61  $��14(�6l  ��6�   �� *main_activity+$ TwoWay=�$ PropertyChanged=�6l  �� 5�   "   $��Fornecedor Ativo:��6,   $��130,20,20,0q�6E   
�������$��14(�6l   d� 5�   "   $��0,15,0,0q�6~    * &MaterialDesignSwitchAccentToggleButton#��[ 6�   @ d� 	IsChecked@ 6/   �� *active+$ TwoWay=�$ PropertyChanged=�6�   5�      5�      �� 5�      $ 
Horizontal=�6%   $��Center=�6>   $��	0,260,0,0q�6[   .+�5�      �� ��6%   �� *resetCurrentProviderCommand+��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     $ 	PersonAdd=�6B   
�������$��0,2,8,0q�6f   �� 5�   *   $
��Novo��64   5�   '   5�      �� 5�      $��50,0,0,0q�6T   ��6%   �� *saveCurrentProviderCommand+��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     
�������$��0,2,8,0q�6r    6B   �� *SaveBtnIcon+6r   �� 5�   *   ��64   �� *SaveBtnText+5�   '   5�      �� 5�      $��50,0,0,0q�6V   ��6%   �� *deleteCurrentProviderCommand+{�6h   �� *CanDeleteProvider+��5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     $ PersonRemove=�6B   
�������$��0,2,8,0q�6i   �� 5�   *   $��Excluir��64   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      