   M S B A M L   `   `   `  ����?  ;Bank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BankBank  5   	       Bank.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Bank     5   	   -   5          � Title$  Банк��5   	   $	��327��6   $	��642��6#    � Icon$ /42492bank_99001.ico��6H    � WindowStartupLocation$ CenterScreen=�6d    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 	20 8 20 8q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 30��6'   5      5      .��5      � $��0,0,0,70q�6    � ColumnDefinitions 5   
   �� 5      $
��101* �6   �� 5      $
��265* �6   �� 5      $	��34* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 	usersGrid��5   /   
   AutoGenerateColumns
 .  $��3��6B   $	��NaN��6V   $��0,0,0,10q�6c   $��2��6u    � Cursor$
 Hand��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6H     5      $ Роль��6G   $	 140 6U    6%   �� *Role.RoleName+6U     5      $ Рахунок��6@   $	 100 6Q    6%   �� *Number+6Q     5      $% Кількість коштів��6@   $	 110 6Z    6%   �� *Amount+6Z     5       $ ПІБ��6=   $	 200 6J    6%   �� *PIB+6J   5"      �� 5$   
   $
��Left=�6    �� Orientation$ 
Horizontal=�60   $��10,35,0,-58q�6I    J� RenderTransformOrigin$ 0.521,-1.101&�6^   $��1��6�   $��1��6�   .+�5%      �� -   5         ��Name$ updateButton��5%      $��Оновити��6+   $
 Hand��6X   �� 5&      -   5        $ deleteButton��5&      $��Видалити��6+   $
 Hand��6Y   5'      5(      5)      