   M S B A M L   `   `   `  ����A  =InvMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:InvMgrInvMgr  5   	       InvMgr.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:InvMgr     5   	     � Title$  Inventory Manager��5   	   $	��310��6#   $	��800��60    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$	 New��5
      6E   .��5      ��  � 	Resources 5   
    �� 
TargetType��%E   '��       �� 5      " ��6   .�5      -   5        5      5      .+�5   
   o� .@�5      m� $��_File��6   .@�5      m� -   5        $
��_New��5      6)   �� 5      m� 5      -   5        $��E_xit��5      6*   5      m� 5      $��_Edit��6   .@�5      m� -   5         m�Name$ uxEditDelete��5      $��_Delete��61   6]   m� 5      -   5        $ uxEditChange��5      $��_Modify��61   5      5      5      �� 5   
   Search Description:6)   �� 64   -   5         ��Name$ uxSearchInput��5   <   6S   �� 5!   
   -   5         ��Name$ uxInventoryList��5!      $	��200��6,    � ContextMenu 5"      �� 5#      .@�5$      m� -	   5        $ uxContextFileNew��5$      $
��_New��69   6G   m� 5%      -
   5        $ uxContextEditChange��5%      $��_Modify��6<   6h   m� 5&      -   5        $ uxContextEditDelete��5&      $��_Delete��6<   6h   5'      	 �� View	 5)      �� 5*      .P�5+      �� 
 �� Width$	
 100��6R    �� DisplayMemberBinding 6%   �� *description+��5,      �� 5-      -   5        $��Description��5-   3   
 � Tag$ description��6I   6[   5/      �� 50      $	
 100��6O    6%   �� *
location+��51      �� 52      -   5        $��Location��52   3   $ location��6F   6U   54      �� 55      $	
 100��6L    6%   �� *price+��56      �� 57      -   5        $��Price��57   3   $ price��6C   6O   59      �� 5:      $	
 100��6K    6%   �� *cost+��5;      �� 5<      -   5        $
��Cost��5<   3   $
 cost��6B   6M   5>      �� 5?      $	
 100��6O    6%   �� *
quantity+��5@      �� 5A      -   5        $��Quantity��5A   3   $ quantity��6F   6U   5C      5D      5F      ]� 5G   
   .+�5H      �� $��Bottom=�6   
�������.@�5I      �� .��5J      �� -   5        $��uxItemCount��5J       5K      5L      5M      5N      5P      