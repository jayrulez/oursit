   M S B A M L   `   `   `  ����  TransportCompany/    )TransportCompany.Miscellaneous.ViewRental   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  
ViewRental��5      .��5	      ]� .+�5
   
   � -   5        $��ViewRequestForm��5
      $	��Top=�6&    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� $��Customer ID:��6   $��0��6+   $��0��6;   $��Right=�6H   $��3q�6d   6q   �� 5      -   5        $��txtCustomerId��5      $��1��6+   $��0��6;   $	��150��6H   $��3q�6T   �� 5      -   5        $��chbxViewAll��5   ;   $��View All Customer Rentals��6   $��2��6O   $��0��6_   $��3q�6l   $��Center=�6w   6�   �� 5      -   5        $��btnViewRental��5      $��0��6*   $��1��6:   $��2��6G   $	��100��6[   $
��View��6g   $��3q�6v   6�   �� 5      -   5        $��lblViewRentalRequest��5      $��0��60   $��2��6@   $��4��6M   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��SearchRentalDataGrid��5         CanUserAddRows .     CanUserSortColumns .    CanUserDeleteRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Ref. Id��6%      
IsReadOnly . 5"        5#      $ Customer ID��6%    . 5%        5&      $ Vehicle ID (vin)��6%    . 5(        5)      $ Rental Date��6%    . 5*        5+      $ Return Date��6%    .  5-        5.      $
 Cost��6%    . 50      5:      5;      5<      