   M S B A M L   `   `   `  ����L  HStoreManager_4lab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StoreManager_4lab.ViewModelsStoreManager_4lab.ViewModels  5   	   C&clr-namespace:StoreManager_4lab.ModelsStoreManager_4lab.Models  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   "    StoreManager_4lab.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9vm*clr-namespace:StoreManager_4lab.ViewModels     5   	   8local&clr-namespace:StoreManager_4lab.Models     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Store Manager��5   	   $	��720��5   	   $
��1280��5	   	   ���#1F1F1F � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      0   *StoreManager_4lab.ViewModels.MainViewModel  5   
    � 	Resources 5         ProductsCollection �� Source  CartCollection  AccentColor �� Color  	DarkColor �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius ��Name  ComboBoxToggleButton �� Padding ��Name ��Name �� SelectionBoxItem d�Name K� ZIndex �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource �Name �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers P� Property P� Value �� 
TargetName  �� Triggers3  -System.Windows.Media.Effects.DropShadowEffect!   
BlurRadius"   ShadowDepth#   Opacity  HeaderCellStyle  PlaceholderStyle��%  &	        &	 )     &	 S     &	 v     '�� �     '��     &	 #    '��      '�� l    &	     &	 o    �� 5   
    6:   �� *
Products+�� 5   
    66   �� *	CartItems+�� 5   
   $ 	#FF232323��6.   �� 5   
   $ #1F1F1F��6,   �� 5   
   " ��6   .�5      ��  � �� �	#FF2721016+   �� 5       � ��$ Segoe UI)�6+   5      �� 5   
   " ��6   .�5       ��  �@J�SnapsToDevicePixels$
 True��64   �� 5!       �@�OverridesDefaultStyle$
 True��66   �� 5"       � ��$ 5q�6'   �� 5#       � ��$ 8q�6(   �� 5$       � ��$ 14(�6)   �� 5%       � ��
 �   �6+   �� 5&       � �� 5'      �� 5(      "	 ��6&   .R�5)      �� ���#F5F5F5���#CCCCCC$��1q�5+      $
 6��5,      ._�5-      �� $ PART_ContentHost��5.   #   #��z��5/   #   51      52      54      55      �� 57   
   "	 d�67   .R�58      �� 
������ $ 0q�6.   ._�59      � .+�5:      F� $��Center=�6   $��Center=�5;      "����        � 	=  	= � z     	
�������5=      5>      5?      5@      �� 5B   
   " ��6   .�5C      ��  � ��
 �   �6+   �� 5D       �@J�SnapsToDevicePixels$
 True��64   �� 5E       �@�OverridesDefaultStyle$
 True��66   �� 5F       � ��$ 5q�6'   �� 5G       � ��$ 12q�6(   �� 5H       � ��$ 16(�6)   �� 5I       � ��$ Stretch=�6;   �� 5J       � ��$ Center=�69   �� 5K       � �� 5L      �� 5M      "	 ��6&   .R�5N      � .+�5P      �� $ Border��6%   ���#F5F5F5$��1q�5R      $
 6��5S      ._�5T   "   ]� .+�5V   &   �� $ ContentSite��67   $��	10,0,30,0q�5W   /   $��Center=�5X   /   $
��Left=�5Y   /   #��z 5[   /   5\   #   5]      d� 5`      $ ToggleButton��6+   $ 1��5a      
������ $��0q�5c      $|�False��5e      $ Press=�5f      $��Stretch=�5g       5d      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5h   "   �� ���#F5F5F5���#CCCCCC$��1q�5j      $
 6��5k      $
 10,0q�5l      ._�5m   &   � .+�5n   *   �� $
��Left=�6;   $��Center=�5o      $��0,0,20,0q�5p      #��z 5q      F� 5s   *   $��Right=�6/   $��Center=�5t      $��0,0,10,0q�5u      "����        � 	=  	= � z     	
�������5w      5x   '   5y   #   5z      � 5~      $ 
PART_Popup��6$   $��Bottom=�5      #��z 5�      $
 True��5�      $|�False��5�      $
��Fade=�5�      ��5�   $   �� *ActualWidth+ �� *TemplatedParent+.��5�   "   � .+�5�   &   �� 
����������#CCCCCC$��1q�5�   %   $
 6��5�   %   $
 True��5�   %   ._�5�   *   �� $��0q�67   $
 True��6B   .��5�   .   �� $
 True��69   $ 	Contained=�6L   5�   +   5�   '   5�   #   5�      5�       5�      P� 5�       � {�$ False��6;   . �5�   "   �� $ Border��6)    � �� �#EEE6S   �� 5�   "    � �� �#8886?   5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� $ Border��6)    � �� �#8886T   5�      P� 5�       �@J�	IsFocused$
 True��6;   . �5�   "   �� $ Border��6)    � �� �	#FF610F906T   5�      5�      5�      �� 5�       � �� 5�      �� 5�      " ��6   .�5�      ��  � ��
 �OO/�67   �� 5�       � ��
 �����67   �� 5�       � ��$	 8,4q�64   �� 5�       � ��$ 14(�65     5�      P� 5�       �@��
IsSelected$
 True��6<   . �5�   "   ��  � �� �	#FF2FA71E6?   �� 5�   "    � �� �	#FF3E02696?   5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   ��  � �� �#E3F2FD6?   5�      5�      5�      5�      �� 5�   
   " ��6   .�5�      ��  � �� �	#FF724FD46+   �� 5�       � �� �#fff6+   �� 5�       � ��$ 14(�6)   �� 5�       � ��$ 5q�6(   �� 5�       � ��$ 5q�6'   �� 5�       �@�Cursor$
 Hand��6'   �� 5�       � ��
 ���� 6,   �� 5�       � ��$ 0q�60   �� 5�       �@J�Effect 5�        5�      $! 5Q�6'   $" 2Q�66   $	# 0.2Q�6F   5�      �� 5�       � �� 5�      �� 5�      "	 ��6&   .R�5�      �� #��z��6!   $
 6��5�      #��z��5�      #��z��5�      # z��5�   "   ._�5�      �� $��Center=�6+   $��Center=�5�   '   5�      5�      5�        5�      P� 5�       �@J�IsMouseOver$
 True��61   . �5�      ��  � �� �	#FF610F9063   5�      P� 5�       � {�$ False��6/   . �5�      ��  � �� �#B0BEC563   �� 5�       � �� �	#FF19181863   5�      5�      �� 5�   
   " ��6(   .�5�      ��  � �� �	#FF724FD46+   �� 5�       � �� �	#FFFDF6F66+   �� 5�       � ��$
 Bold"�6+   �� 5�       �@��Padding$ 5q�6(   �� 5�       � ��$ Stretch=�64   �� 5�       � ��$ Stretch=�62   �� 5�       �@��TextAlignment$ Center=�6.   5�      �� 5�   
   " ��6)   .�5�      ��  � �� �#8886+   �� 5�       � ��$ Italic$�6*   �� 5�       � ��$ 10,5,0,0q�6'   �� 5�       �@J�IsHitTestVisible$ False��61   �� 5�       � ��$ Center=�62   �� 5�       � y�$ 	Collapsed=�6+   5�      5�      .��5�      ]� ��5�   
   �� 5�      $ �� ImageSource$$ /pc.jpg��6   .+�5�   
   �� $	��Top=�6   $
��0,10q�6*   $��37��68   $
��1107��6D   .+�5�      �� $<��6Магазин компьютерной техники��6   $��24(�6<   $
��Bold"�6J   !  System.Windows.SystemColors%   InfoBrushKey#��� % 5�      $��Center=�6\   $��	0,10,0,20q�6y   5�      � 5  
   $��20q�6   & � ColumnDefinitions& 5     �� 5     $��* �6#   �� 5     $��* �6#   �� 5     $��* �6#   .+�5	     �� $��0��6   $��Товары��6'   
�������.��5
     �� .+�5     �� -   5        $	��200��5  T   $��0,0,0,10q�6a   ' �� SelectedItem' 6   �� *SelectedProduct+$ TwoWay=� 5     ( �� DataType&    StoreManager_4lab.Models.Product��%=  (��       5  +   *, +)�� 6   "(  6+   .R�5  "   � & 5  &   �� 5  *   $	��120 �6;   �� 5  *   $��80 �6;   �� 5  *   $��80 �6;   �� 5  *   $	��110 �6;   .+�5  &   �� $��0��6F   $
��Wrap=�6X   $��CharacterEllipsis=�6l   ��60   �� *Name+6l   �� 5  &   $��1��6G   $
��15,0q�6W   ��60   �� *Price+6W   �� 5  &   $��2��6G   $
��25,0q�6W   ��60   �� *Stock+6W   �� 5  &   $��3��6J   $	��4,0q�6[   $
��Wrap=�6j   $��CharacterEllipsis=�6~   ��60   �� *
Category+6~   5  #   5     5     ��5      -  'System.Windows.Data.CompositeCollection  5!     �� 5#  "   .��5$  &   � ���#EEE& 5%  *   �� 5&  .   $	��120 �6?   �� 5'  .   $��80 �6?   �� 5(  .   $��80 �6?   �� 5)  .   $	��110 �6?   .+�5+  *   �� $��Название��64   $��0��6D   #��[ 6T   �� 5,  *   $��Цена��64   $��1��6@   #��[ 6P   �� 5-  *   $��Остаток��64   $��2��6C   #��[ 6S   �� 5.  *   $��Категория��64   $��3��6E   #��[ 6U   5/  '   50  #   �� 53  "   ) �� 
Collection) 66   �� * �� Source#* [  54     56     � 59     .+�5:     �� -   5        + ��Name$+ ProductNameBox��5:  "   ��6:   �� *NewProductName+, �� UpdateSourceTrigger$, PropertyChanged=��� 5;     $��Название��6$   ��5<     �� 5=  "   " ��6(   - �� BasedOn#- [ 6?     5>  &   �� 5?  *   . �� Binding. 66   �� *Text+/ �� ElementName$/ ProductNameBox��0 �� Value0  6k   .a�5@  .   ��  � y�$ Visible=�6K   5A  +   5C  #   5E     5F     � 5H     .+�5I     �� -   5        $+ ProductPriceBox��5I  "   ��6;   �� *NewProductPrice+$, PropertyChanged=��� 5J     $��Цена��6$   ��5K     �� 5L  "   " ��6(   #- [ 6?     5M  &   �� 5N  *   . 66   �� *Text+$/ ProductPriceBox��0  6l   .a�5O  .   ��  � y�$ Visible=�6K   5P  +   5R  #   5T     5U     � 5W     .+�5X     �� -   5        $+ ProductStockBox��5X  "   ��6;   �� *NewProductStock+$, PropertyChanged=��� 5Y     $��Остаток��6$   ��5Z     �� 5[  "   " ��6(   #- [ 6?     5\  &   �� 5]  *   . 66   �� *Text+$/ ProductStockBox��0  6l   .a�5^  .   ��  � y�$ Visible=�6K   5_  +   5a  #   5c     5d     � 5f     .+�5g     �� -   5        1 ��Name$1 CategoryComboBox��5g  #   ��6=   �� *
Categories+' 6`   �� *SelectedCategory+�� 5h     $)��#Выберите категорию��6$   ��5i     �� 5j  "   " ��6(   #- [ 6?     5k  &   �� 5l  *   . 66   �� *SelectedItem+$/ CategoryComboBox��0 6u   Z� .a�5m  .   ��  � y�$ Visible=�6K   5n  +   5p  #   5r     5s     A� 5v     2 A� Columns$2 3��6"   $��0,10,0,0q�6.   $��Stretch=�6@   .+�5w     �� $��Добавить��6!   ��64   �� *AddProductCommand+�� 5x     $��Обновить��6!   ��64   �� *UpdateProductCommand+�� 5y     $��Удалить��6!   ��63   �� *DeleteProductCommand+5z     �� 5|     $��В корзину��6   $	��120��5~     $��0,10,0,0q�5     ��5}     �� *AddToCartCommand+5     5�     5�     �� 5�     $��1��6   $��Корзина��6'   
�������.��5�     �� .+�5�     �� -   5        $	��201��5�  �   $	��409��6�   ' 6   �� *SelectedCartItem+$ TwoWay=���5�     �� 5�     .R�5�  "   � & 5�  &   �� 5�  *   $��80 �6;   �� 5�  *   $��80 �6;   �� 5�  *   $	��100 �6;   �� 5�  *   $	��130 �6;   .+�5�  &   �� $��0��6N   $��4,0,0,0q�6^   $
��Wrap=�6r   $��CharacterEllipsis=�6�   ��60   �� *Product.Name+6�   �� 5�  &   $��1��6O   $��25,0,0,0q�6_   ��60   �� *Product.Price+6_   �� 5�  &   $��2��6R   $��5,0,0,0q�6c   $
��Wrap=�6v   $��CharacterEllipsis=�6�   ��60   �� *Product.Category+6�   �� 5�  &   3 �� Orientation$3 
Horizontal=�61   $��3��6J   $��25,0,0,0q�6[   .+�5�  *   �� $��-��61   $��20��6=   $��20��6H   $��0q�6T   
����������	#FF1914CC��5�  %   �� *%#DataContext.DecreaseQuantityCommand+ �� 4 �� AncestorType4 ListBox��5�  %   �� 6U   �� 5�  *   $��30��6N   5 �� TextAlignment$5 Center=�6Y   $��Center=�6p   ��64   �� *
Quantity+6p   �� 5�  *   $��+��61   $��20��6=   $��20��6H   $��0q�6T   
����������	#FF1914CC��5�  %   �� *%#DataContext.IncreaseQuantityCommand+ �� 4 ListBox��5�  %   �� 6U   5�  '   5�  #   5�     ��5�       5�     �� 5�  "   .��5�  &   � ���#EEE& 5�  *   �� 5�  .   $��80 �6?   �� 5�  .   $��80 �6?   �� 5�  .   $	��100 �6?   �� 5�  .   $	��130 �6?   .+�5�  *   �� $��
Товар��64   $��0��6A   #��[ 6Q   �� 5�  *   $��Цена��64   $��1��6@   #��[ 6P   �� 5�  *   $��Категория��64   $��2��6E   #��[ 6U   �� 5�  *   $��Кол-во��64   $��3��6B   #��[ 6R   5�  '   5�  #   �� 5�  "   ) 66   �� #* [ 5�     5�     �� 5�     $(��"Удалить из корзины��6   $	��150��5�     $��0,10,0,0q�6   
���������5�     �� *RemoveFromCartCommand+5�     5�     5�     �� 5�     $��2��6   $��Заказы��6'   
�������.��5�     �� .+�5�     �� -   5        $	��200��5�  E   $��0,0,0,10q�6R   ��5�     �� *Orders+' 5�     �� *SelectedOrder+��5�     �� 5�     .R�5�  "   �� .+�5�  &   �� $
��Bold"�6N   ��60   �� *CustomerName+6N   �� 5�  &   $��Italic$�6l   ��60   �� *	OrderDate+6 �� StringFormat$6 dd.MM.yyyy HH:mm��6l   �� 5�  &   ��63   �� *Items+��5�  *   �� 5�  .   .R�5�  2   �� �� 5�  6   �6:   �� *Product.Name+ �� 5�  6   $� (��6:    �� 5�  6   �6:   �� *
Quantity+ �� 5�  6   $� шт.)��6:   5�  3   5�  /   5�  '   5�  #   5�     5�     � 5�     $��0,0,0,10q�6   .+�5�     �� -   5        $+ CustomerNameBox��5�  "   ��6;   �� *CustomerName+$, PropertyChanged=��� 5�     $��Имя клиента��6$   ��5�     �� 5�  "   " ��6(   #- [ 6?     5�  &   �� 5�  *   . 66   �� *Text+$/ CustomerNameBox��0  6l   .a�5�  .   ��  � y�$ Visible=�6K   5�  +   5�  #   5�     5�     �� 5�     $3 
Horizontal=�6!   .+�5�     �� $��Создать заказ��6!   $	��120��6]   ��69   �� *AddOrderCommand+6]   �� 5�     $!��Отменить заказ��6!   $	��120��6a   ��6:   �� *DeleteOrderCommand+6a   5�     5�     5�     5�     5�     5      