   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5       TransportCompany3   -TransportCompany.Miscellaneous.SearchCustomer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5      _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5        N� Title$  SearchCustomer��5
      .��5      ]� .+�5      � -   5        $��SearchCustomerForm��5      $	��Top=�6%    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6   $	��ID:��6-   $��Right=�6;   �� 5   
   -   5        $��txtId��5      $	��150��6   $��0��6+   $��1��68   $��3q�6H   6S   �� 5   
   $��1��6   $��0��6   $��First Name:��6-   $��Right=�6C   �� 5   
   -   5        $��txtFirstName��5      $	��150��6&   $��1��62   $��1��6?   $��3q�6O   �� 5!   
   $��1��6   $��2��6   $��	LastName:��6-   $��Right=�6A   �� 5"   
   -   5        $��txtLastName��5"      $	��150��6%   $��1��61   $��3��6>   $��3q�6N   �� 5$   
   $��2��6   $��0��6   $��Email Address:��6-   $��Right=�6F   �� 5%   
   -   5        $��txtEmailAddress��5%      $	��150��6)   $��2��65   $��1��6B   $��3q�6R   �� 5'   
   -   5        $��btnSearchCustomer��5'      $��3��6*   $��0��67   $��2��6G   $��Search��6[   $��Center=�6l   $	��100��6�   6�   5(      �� 5)   
   -   5        $��lblSearchStatus��5)      $��3,3,3,3q�6'   $	��Top=�68   6O   &   System.Windows.Controls.DataGrid  5*   
   -   5        $��SearchCustomerDataGrid��5*   %   
�������   CanUserAddRows .     CanUserResizeColumns . $��3,3,3,3q�6v      
IsReadOnly .     CanUserDeleteRows .    CanUserSortColumns .    Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Customer ID��6%   
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6L   5/        50      $	 
First Name��6%   $ 80 69   52        53      $	 	Last Name��6%   $ 80 68   55        57      $	 Email Address��6%   $ 80 6<   59        5:      $	 Contact Number��6%   $ 80 6=   5<        5=      $	 Account Created��6%   
 . $ 80 6P   5?      5A      5C      5D      