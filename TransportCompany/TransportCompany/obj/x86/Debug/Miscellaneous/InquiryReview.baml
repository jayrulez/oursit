   M S B A M L   `   `   `  ����  TransportCompany2    ,TransportCompany.Miscellaneous.InquiryReview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  ViewInquire��5      .��5	      ]� .+�5
      � -   5        $��InquiryReviewForm��5
      $	��Top=�6$    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Customer ID:��6   $��0��6'   $��0��67   $��Right=�6D   $��3q�6`   6m   �� 5   
   -   5        $��txtCustomerId��5      $��1��6'   $��0��67   $	��150��6D   $��3q�6P   �� 5   
   $��InquiryDate: (dd/mm/yyyy)��6   $��2��64   $��0��6D   $��Right=�6Q   $��3q�6m   �� 5   
   -   5        $��txtInquiryDate��5      $��3��6(   $��0��68   $	��150��6E   $��3q�6Q   �� 5   
   -   5        $��btnViewInquiry��5      $��0��6'   $��1��67   $��2��6D   $	��100��6X   $
��View��6d   $��3q�6s   6~   �� 5      -   5        $��lblViewInquiryStatus��5      $��0��60   $��2��6@   $��4��6M   5      &   System.Windows.Controls.DataGrid  5      -   5        $��SearchInquiryDataGrid��5         CanUserAddRows .     CanUserResizeColumns . $��3,3,3,3q�6_      
IsReadOnly .    CanUserDeleteRows .     CanUserSortColumns .  � ContextMenu 5      �� 5       .@�5!      �  5"      �� 5#      �� 5$       5&      �� 5'      �� 5(      .+�5*      �� -   5        $��	lblReason��5*       $��	FeedBack:��61   $��0��6E   $��0��6R   $��Right=�6b   $��3q�6~   �� 5+      -   5        $��	txtReason��5+   "   $	��200��63   $��50��6?   $��1��6K   $��0��6[   $��3q�6h   	 �� TextWrapping$
	 Wrap=�6s   �� 5,      -	   5        $��btnPostFeedback��5,   !   $��Post Feedback��68   $��1��6k   $��0��6x   $��Center=�6�   $��3q�6�   5-      5.      
   Columns
 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6!      
IsReadOnly . 53        54      $ Customer ID��6!    . 56        57      $ Subject��6!    . 59        5:      $
 Body��6%    . 5<        5=      $ Created��6%    . 5?      5A      5B      5C      