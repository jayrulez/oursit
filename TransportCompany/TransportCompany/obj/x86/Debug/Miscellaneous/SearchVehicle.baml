   M S B A M L   `   `   `  ����  TransportCompany2    ,TransportCompany.Miscellaneous.SearchVehicle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  SearchVehicle��5      .��5	      ]� .+�5
      � -   5        $��SearchVehicleForm��5
      $	��Top=�6$    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6   $
��VIN:��6-   $��Right=�6<   �� 5   
   -   5        $��txtVIN��5      $	��150��6    $��0��6,   $��1��69   $��3q�6I   �� 5   
   $��1��6   $��0��6   $��ServiceType:��6-   $��Right=�6D   �� 5   
   -   5        $��rbtnlistType��5      $��1��6)   $��1��66   .+�5      	� -   5        $��rbtnTypeRental��5      $��Rental��60   	� 5       -   5        $��rbtnTypeDelivery��5       $��Delivery��62   	� 5!      -   5        $��rbtnTypeCharter��5!      $��Charter��61   	� 5"      -   5        $��rbtnTypeAll��5"      $	��All��6-   5#      �� 5$   
   $��Seating Capacity:��6   $��0��6,   $��2��69   $��Right=�6I   �� 5%   
   -   5        $��txtSeatingCapacity��5%      $	��150��6,   $��0��68   $��3��6E   $��3q�6U   6`   �� 5'   
   -	   5        $��btnSearchVehicle��5'      $��2��6)   $��0��66   $��2��6F   $��Search��6Z   $��Center=�6k   $	��100��6�   6�   �� 5(   
   -
   5        $��lblSearchVehicleStatus��5(      $��0��6.   $��4��6>   $��4��6K   $��3q�6_   6l   5)      &   System.Windows.Controls.DataGrid  5*      -   5        $��SearchVehicleDataGrid��5*         CanUserAddRows .     CanUserResizeColumns . $��3,3,3,3q�6_      
IsReadOnly .     CanUserDeleteRows .    CanUserSortColumns .    Columns 5,   
   0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn	   Header$		 VIN��6!   
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6@   5.        5/      $
	 Make��6%   $ 80 63   51        52      $	 Model��6%   $ 80 64   54        55      $	 Color��6%   $ 80 64   57        58      $	 	Condition��6%   $ 80 68   5:        5<      $	 Service Type��6%   $ 80 6;   5>        5?      $	 Seating Capacity��6!   $ 80 6;   5A      5C      5D      5E      