   M S B A M L   `   `   `  ����D  @iFareData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:iFareData.Views.demoiFareData.Views.demo  5   	   (    "iFareData.Views.demo.ProductWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:iFareData.Views.demo     5   	   -   5          � Title$  ProductWindow��5   	    � 
ResizeMode$ NoResize=�5	   	   $	��310��6   $	��620��6,   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��158* �6   �� 5      $	��74* �6   �� 5      $	��78* �6   �� 5      $	��35* �6   �� 5      $	��36* �6   �� 5      $
��239* �6   .+�5   
   �� $��10,10,10,10q�6   $��6��6*   .+�5      �� $��HTTPS proxy��6   $��0,0,0,10q�6,   .��5      �� $��10q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $
��Left=�6U   $��0,0,0,10q�6p   .+�5      	� -   5         	�Name$ 
rdbDefault��5   &    	� 	GroupName$ optionProxy��6:    d� 	IsChecked$
 TrueY�6R   $��Default��6c   6u   	� 5      -   5        $ 	rdbCustom��5   &   $ optionProxy��69   $��Custom��6Q   $��20,0,0,0q�6b   6t   5      �� 5      $ 
Horizontal=�6!   $��0,10,0,0q�6:   .+�5      �� $��Address��6    $��65��62   $��25��6=   $��0,0,5,0q�6I   �� 5      -   5         ��Name$ 
txtAddress��5   "   $	��300��66   �� 5      $
��Port��6    $��65��6/   $��25��6:   $��10,0,5,0q�6F   �� 5      -   5        $ txtPort��5   "   $	��100��63   5       5!      5"      �� 5$      $��Login��6   .��5%      �� $ 
Horizontal=�6   $��10q�66   .+�5&      �� $��Username��6   $��65��6/   $��25��6:   �� 5'      -   5        $ txtUsername��5'      $	��300��63   �� 5(      $��Password��6   $��65��6/   $��25��6:   $��10,0,5,0q�6F   �� 5)      -   5        $ txtPassword��5)      $	��100��63   5*      5+      �� 5-      $ 
Horizontal=�6   $��Right=�62   $��0,20,0,0q�6N   .+�5.      �� -   5         ��Name$ btnSave��5.      $
��Save��6*   $��65��69   $��25��6D   $��0,0,10,0q�6P   6b   �� 5/      -	   5        $ btnClose��5/      $��Cancel��6+   $��65��6<   $��25��6G   6S   50      51      52      53      