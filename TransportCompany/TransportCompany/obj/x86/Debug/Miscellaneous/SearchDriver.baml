   M S B A M L   `   `   `  ����  TransportCompany1    +TransportCompany.Miscellaneous.SearchDriver   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  SearchDriver��5      .��5	      ]� .+�5
      � -   5        $��SearchDriverForm��5
      $	��Top=�6#    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6   $	��Id:��6-   $��Right=�6;   �� 5      -   5        $��txtId��5      $	��150��6#   $��0��6/   $��1��6<   $��3q�6L   6W   �� 5   
   $��2��6   $��0��6   $
��NIS:��6-   $��Right=�6<   �� 5   
   -   5        $��txtNis��5      $	��150��6    $��2��6,   $��1��69   $��3q�6I   �� 5   
   $��2��6   $��2��6   $
��TRN:��6-   $��Right=�6<   �� 5    
   -   5        $��txtTrn��5       $	��150��6    $��2��6,   $��3��69   $��3q�6I   6T   �� 5"   
   -   5        $��btnSearchDriver��5"      $��3��6(   $��0��65   $��2��6E   $��Search��6Y   $��Center=�6j   $	��100��6�   6�   �� 5#   
   -   5        $��btnClearFields��5#      $��3��6'   $��2��64   $��2��6D   $��Clear Fields��6X   $��Center=�6o   $	��100��6�   6�   5$      �� 5%      -   5        $��lblSearchStatus��5%      $��3,3,3,3q�6#   $	��Top=�64   6K   &   System.Windows.Controls.DataGrid  5&      -   5        $��SearchDriverDataGrid��5&         CanUserAddRows .     CanUserResizeColumns . $��3,3,3,3q�6^      
IsReadOnly .     CanUserDeleteRows .    CanUserSortColumns .    Columns 5(   
   0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Driver ID��6%   
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6J   5+        5,      $	 
First Name��6%   $ 80 6:   5.        5/      $	 	Last Name��6%   $ 80 68   51        52      $
	 NIS#��6%   $ 80 63   54        55      $
	 TRN#��6%   $ 80 63   57        58      $	 District��6%   $ 80 67   5:        5<      $	 Parish��6%   $ 80 65   5>        5?      $	 Contact Number��6%   $ 80 6=   5A      5C      5D      5E      