   M S B A M L   `   `   `  ���� G  CProjectAlpha, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjectAlphaProjectAlpha  A%clr-namespace:ProjectAlpha.ViewModelsProjectAlpha.ViewModels  !    ProjectAlpha.ProviderWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ProjectAlpha     <
viewModels%clr-namespace:ProjectAlpha.ViewModels     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  E ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz    � Title$  ProviderWindow�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�$��1q� � ShowInTaskbar .  ���#1e1f1e���� *height+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� *width+$ TwoWay=�$ PropertyChanged=�
 � Top �� *top+$ TwoWay=�$ PropertyChanged=� � Left �� *left+$ TwoWay=�$ PropertyChanged=� � DataContext 0   *ProjectAlpha.ViewModels.ProvidersViewModel  .��� .+�� $��40��$	��Top=�.+��� ���� 	 �� EndPoint$	 0.5,1&�
 �� 
StartPoint$
 0.5, 0.1&�.���  � Color$ #5ea0fa��� $ #3f51b5�� � Offset$ 1Q�� $ #326bc9��$	 0.2Q��� $��Fornecedores��$	��Top=�$��Center=�$
��Bold"�$��20(� "  PrimaryHueLightForegroundBrush#��[  $	��0,5q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 -20Q�   RenderingBias$ Quality=�   
BlurRadius$ 5Q��� -    ��Name$ minimizeBtn��$��25��$��0q�$	��Top=�$��Right=�$��0,5,35,0q�
������ $��0q�
������ ���� *minimizeWindowCommand+��0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Minus=�   Size$ 20X��� -   $ closeBtn��$��25��$��0q�$	��Top=�$��Right=�$��0,5,3,0q�
������ $��0q�
������ ���� *closeWindowCommand+��  $ Close=�$ 20X�� $��0,40,0,0q�.+�  Dragablz.TabablzControl  .@��� -    ��Name$ consultaTabMenu��$��Consulta�� �� 
IsSelected �� *isQueryTabFocused+.��� $��
10,20,10,0q�$	��Top=�.+��� $��0,0,0,20q� �� Orientation$ Vertical=�$	��Top=�$��Center=�.+��� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ providerQueryTextBox�� �� AcceptsReturn .  $	��300��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Fornecedor�� % !MaterialDesignFloatingHintTextBox#��[ $��14(����� *searchFieldText+$ TwoWay=�$ PropertyChanged=�.�� J� InputBindings �� 
 �� Key$ Return�� �� Command �� *searchProviderCommand+.���� $
��10,0q����� *searchProviderCommand+���� $ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�$��0,3,3,0q�$
��Left=��� $��Buscar���� $ 
Horizontal=�$��Center=�.+�&   System.Windows.Controls.DataGrid     RowBackground
 �����}�. ���#97c8fc   AutoGenerateColumns .  $    HorizontalScrollBarVisibility$
  Auto=�"!   VerticalScrollBarVisibility$
! Auto=�$��20,30,20,10q�"   
IsReadOnly" . $��2q�  PrimaryHueDarkBrush#��[ #   CanUserAddRows# .  $   CanUserDeleteRows$ .  %   SelectionMode$% Single=�&   SelectionUnit$& FullRow=�'   GridLinesVisibility$	' All=�(   VerticalGridLinesBrush#( [ )   HorizontalGridLinesBrush#) [ *   AreRowDetailsFrozen* . +   CanUserResizeColumns+ . ,   CanUserResizeRows, .  $
��1000������ *dataGridSource+- �� SelectedItem- �� *gridCurrentProvider+$ TwoWay=�. � 	Resources. *  $System.Windows.Controls.DataGridCell/ �� 
TargetType0 �� Triggers1 P� Property2 P� Value3 �� Property  PrimaryHueLightBrush4 �� Value��%P   '        7  �� "/  0 P� 1 �@ 
IsSelected2 . . ��� 3 � ��84    d� 5 d� MouseAction$5 LeftDoubleClicke�6 �� CommandParameter$6 	providers�� �� *gridDoubleClickCommand+7   Columns7 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn8 
  Header$8 ID��9 
  Width5  /System.Windows.Controls.DataGridLengthConverter$9 55 1  +System.Windows.Controls.DataGridBoundColumn:   Binding: �� *id+	  $8 
Fornecedor��$	9 130 : �� *name+	  $8 Razão Social��$	9 130 : �� *social_name+	  $
8 CNPJ��$9 90 : �� *cnpj+	  $8 	Endereço��$	9 130 : �� *adress+	  $8 Telefone��$	9 100 : �� *phone+	  $8 Email��$	9 110 : �� *email+	  $
8 Ramo��$	9 110 : �� *main_activity+4  .System.Windows.Controls.DataGridCheckBoxColumn  $8 Ativo�� - )MaterialDesignDataGridCheckBoxColumnStyle;   ElementStyle#; [ $9 80 : �� *active+�� $ 
Horizontal=�$��Center=�$��0,60,0,0q�.+��� ���� *newProviderCommand+���� $ 
Horizontal=�.+�  $ 	PersonAdd=�
�������$��0,2,8,0q��� $
��Novo���� $��50,0,0,0q����� *deleteGridProviderCommand+���� $ 
Horizontal=�.+�  $ PersonRemove=�
�������$��0,2,8,0q��� $��Excluir���� -   $��cadastroTabMenu��$��Cadastro�� �� *isRegisterTabFocused+.��� $��	0,20,10,0q�$	��Top=�$��Center=�.+��� $ Vertical=�$	��Top=�$��Center=� �� *currentProvider+$ TwoWay=�$ PropertyChanged=�.+��� $ 
Horizontal=�$��Center=�.+��� -   $ providerNameTextBox��$	��250��$ 
Fornecedor��#��[ $��14(����� < �� Path$
< name�$ TwoWay=�$ PropertyChanged=��� -   $ socialTextBox��$��	80, 0,0,0q�$	��250��$ Razão Social��#��[ $��14(����� *social_name+$ TwoWay=�$ PropertyChanged=��� �� $ 
Horizontal=�$
��Left=�.+��� -   $ cnpjTextBox��$	��250��$
 CNPJ��#��[ $��14(����� *cnpj+$ TwoWay=�$ PropertyChanged=��� -	   $ adressTextBox��$��	80, 0,0,0q�$	��250��$ 	Endereço��#��[ $��14(����� *adress+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�$
��Left=�.+��� -
   $ phoneTextBox��$	��200��$ Telefone��#��[ $��14(����� *phone+$ TwoWay=�$ PropertyChanged=��� -   $ emailTextBox��$��
130, 0,0,0q�$	��250��$ Email��#��[ $��14(����� *email+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�$
��Left=�.+��� -   $ activityTextBox��$	��Top=�$	��200��$ Ramo de Atividade��#��[ $��14(����� *main_activity+$ TwoWay=�$ PropertyChanged=��� $��Fornecedor Ativo:��$��130,20,20,0q�
�������$��14(�d� $��0,15,0,0q� * &MaterialDesignSwitchAccentToggleButton#��[ = d� 	IsChecked= �� *active+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�$��Center=�$��	0,260,0,0q�.+��� ���� *resetCurrentProviderCommand+���� $ 
Horizontal=�.+�  $ 	PersonAdd=�
�������$��0,2,8,0q��� $
��Novo���� $��50,0,0,0q����� *saveCurrentProviderCommand+���� $ 
Horizontal=�.+�  
�������$��0,2,8,0q� �� *SaveBtnIcon+�� ���� *SaveBtnText+�� $��50,0,0,0q����� *deleteCurrentProviderCommand+{��� *CanDeleteProvider+���� $ 
Horizontal=�.+�  $ PersonRemove=�
�������$��0,2,8,0q��� $��Excluir��