   M S B A M L   `   `   `  ����  	iFareData*    $iFareData.Views.demo.IFareDataWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  IFareDataWindow��5   	   $	��450��6!   $	��800��6.    � 	Resources 5       #  Body_Content_DataGrid_Centering �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� 
TargetType  header_style=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  &	        &	 �     �� 5	   
   "  5
      .�5      ��  � �� 5      �� 5      "  6&   .R�5      � #��z��6   .+�5      �� $��Center=�6/   5      5      5      5      �� 5   
   "  6%   .�5      ��  � ��
 �   �6,   �� 5       � ��$ 0,0,1,1q�60   �� 5       � ��
 ��ح�6+   �� 5       � ��$ 5q�6(   5      5      .��5      � .+�5   
   �� $��10q�6   .+�5      �� $
��Auto=�6   $
��Auto=�6>   $	��200��6c   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5          HeadersVisibility$ Column=�5"         AutoGenerateColumns$ False��5#      	   SelectionUnit$	 CellOrRowHeader=�5$      
���   �$��
1, 1, 0, 0q�5&      
   
IsReadOnly$

 True��5'      $��False��5(      $��Disabled=�5)      $��Disabled=�5*         	CellStyle# [  5+         ColumnHeaderStyle# [ 5,         	RowHeight$ 28Q�5-         CanUserAddRows$ False��5.      ��5!      ��  5/        NoRightBorderHeaderStyle)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%�  &	       '  �     �� 51      "  6    .�52      ��  � ��$ 0q�6@   �� 53       � ��
 �   �6<   �� 54       � ��$ 	0,0,0,0.5q�6@   �� 55       � ��$ 5q�68   56      �� 57      "  6    .�58      ��  � ��
 �����6;   �� 5:       � ��
 �   �6;    5<      P� 5>   "    �@ 
IsSelected$
 True��6@   . �5?   &   ��  � ��
 �  ��6C   �� 5@   &    � ��
 �����6C   5B   #   5D      5E         Columns 5F      4  .System.Windows.Controls.DataGridTemplateColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 61      HeaderTemplate 5H      �� 5I   "   .R�5J   &   ��  ��Name$ SelectAllCheckBox��6/   -   5        5J   n   5K   #      CellTemplate 5M      �� 5N   "   .R�5O   &   �� -   5        $��Center=�5R   /   $��Center=�5S   /    d� 	IsChecked 5O   /   �� *
IsSelected+ �� Mode$ TwoWay=�5S   /   5T   #   5V      0  *System.Windows.Controls.DataGridTextColumn  5W         Header$ 
first name��6-   $ 3* 6_   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6A   �� *	FirstName+6_     5X      $ 	last name��6-   $ * 6]    6@   �� *
LastName+ 	  ElementStyle 5Y      �� 5Z   "   " ��6(   .�5[   &   ��  � ��$ Center=�6L   �� 5\   &    � ��$ Center=�6J   5]   #   5_        5`      $
 city��6-      HeaderStyle# [ 6T   $ * 6�    6;   �� *City+ 5a      �� 5b   "   " ��6(   .�5c   &   ��  � ��$ Center=�6L   �� 5d   &    � ��$ Center=�6J   5e   #   5g      5i      5j      5k      5l      5m      