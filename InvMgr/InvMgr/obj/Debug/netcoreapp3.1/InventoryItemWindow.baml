   M S B A M L   `   `   `  ����A  =InvMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:InvMgrInvMgr  5   	        InvMgr.InventoryItemWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:InvMgr     5   	   -   5          � Title$  Inventory Item��5   	   $	��300��6    $	��280��6,    � WindowStartupLocation$ CenterOwner=�5   	    +� FocusedElement 5	   	   ��  �� ElementName$ uxDescription��.��5      � -   5         �Name$ uxGrid��5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $
��auto �6   .+�5    
   �� $��0��6   $��0��6$   $
��Left=�61   Description:6Z   �� 5!   
   -   5         ��Name$ uxDescription��5!      $��1��6)   $��0��69   .��6F   .��5"      ��  �� Path$ description�6   	 �� UpdateSourceTrigger$	 PropertyChanged=�6)   
 �� ValidationRules
 5#      &    InvMgr.EmptyStringValidationRule  5$      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�66   5&       =� ErrorTemplate 5'      �� 5(      .R�5)      �� .+�5*      ��  ��Name$ textBox��64   �� 5+      
���  ����6$   �� *[0].ErrorContent+6F   5,      5-      .��5.   (   5/      �� 51   
   $��0��6   $��2��6$   $
��Left=�61   	Location:6W   �� 52   
   -   5        $ 
uxLocation��52      $��1��6&   $��2��66   .��6C   .��53      �� $ location�6   $	 PropertyChanged=�6&   
 54        55      $ RawProposedValue=�66   57       58      �� 59      .R�5:      �� .+�5;      �� $ textBox��64   �� 5<      
���  ����6$   �� *[0].ErrorContent+6F   5=      5>      .��5?   (   5@      �� 5B   
   $��0��6   $��4��6$   $
��Left=�61   Price:6T   �� 5C   
   -   5        $ uxPrice��5C      $��1��6#   $��4��63   .��6@   .��5D      �� $ price�6   $	 PropertyChanged=�6#   
 5E      &    InvMgr.StringToIntValidationRule  5F      $ RawProposedValue=�66   5H       5I      �� 5J      .R�5K      �� .+�5L      �� $ textBox��64   �� 5M      
���  ����6$   �� *[0].ErrorContent+6F   5N      5O      .��5P   (   5Q      �� 5S   
   $��0��6   $��6��6$   $
��Left=�61   Cost:6S   �� 5T   
   -   5        $ uxCost��5T      $��1��6#   $��6��63   .��6@   .��5U      �� $
 cost�6   $	 PropertyChanged=�6"   
 5V        5W      $ RawProposedValue=�66   5Y       5Z      �� 5[      .R�5\      �� .+�5]      �� $ textBox��64   �� 5^      
���  ����6$   �� *[0].ErrorContent+6F   5_      5`      .��5a   (   5b      �� 5d   
   $��0��6   $��8��6$   $
��Left=�61   	Quantity:6W   �� 5e   
   -   5        $ 
uxQuantity��5e      $��1��6&   $��8��66   .��6C   .��5f      �� $ quantity�6   $	 PropertyChanged=�6&   
 5g        5h      $ RawProposedValue=�66   5j       5k      �� 5l      .R�5m      �� .+�5n      �� $ textBox��64   �� 5o      
���  ����6$   �� *[0].ErrorContent+6F   5p      5q      .��5r   (   5s      �� 5u   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��10��6>   $��Right=�6L   .+�5v      �� -   5         ��Name$ uxSubmit��5v      $	��Add��6(   $��10��66   $��Center=�6D   $��10q�6x   ��5w      �� 5x       �� 
TargetType" ��6   .�5y      ��  �� Property � {� �� Value$ false��66    �� Triggers 5z      ^� 5{       ^� 
Conditions 5|   "   �� 5}   &    �� Binding 60   �� $ uxDescription��$ (Validation.HasError)� �� Value	 false6z   �� 5~   &    60   �� $ 
uxLocation��$ (Validation.HasError)�	 false6w   �� 5   &    60   �� $ uxPrice��$ (Validation.HasError)�	 false6t   �� 5�   &    60   �� $ uxCost��$ (Validation.HasError)�	 false6s   �� 5�   &    60   �� $ 
uxQuantity��$ (Validation.HasError)�	 false6w   .0�5�   "   ��  � {�$
 true��6>   5�      5�      5�      �� 5�      -	   5        $ uxCancel��5�      $��10��6(   $��Center=�66   $��10q�6j   .��6v   Cancel6~   5�      5�      5�      