   M S B A M L   `   `   `  ����H  DWpfAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfAssignment.ConverterWpfAssignment.Converter  5   	   A%clr-namespace:WpfAssignment.BehaviorsWpfAssignment.Behaviors  5   	   #    WpfAssignment.View.PersonList   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <
converters%clr-namespace:WpfAssignment.Converter     5   	   @customBehavior%clr-namespace:WpfAssignment.Behaviors     5   	     � Title$  Person Catalog��5   	   $	��350��6    $	��525��6-   ,   &WpfAssignment.Behaviors.WindowBehavior   WindowLoadedCommand 5   	   ��  �� Path$ WindowLoaded� � 	Resources 5      5   /WpfAssignment.Converter.PersonToStringConverter   PersonToStringConverter��%   &	          5	   
   6-   5
      .��5      � $��10,10,10,10q�6   $	��250��6     � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��50 �6   .+�5   
   �� -   5        $��uxFullNamelbl��5      $��0��5      $��0��5      $
��Left=�5      $��Center=�5      $
��Left=�5      ��5      �� *PersonSelected+ �� Mode$ TwoWay=� �� 	Converter# [  5      �� 5   
   -   5        $��uxEditButton��5      $��0��5       $��1��5!      $��50��5"      $��Right=�5#      $��25��5$      $
��Edit��5%      ,   &WpfAssignment.Behaviors.ButtonBehavior   ButtonClickedCommand 5&      �� $ EditCommand��� 5(   
   -   5        $��
uxListBoxt��5)      $��1��5*      $��0��5+      $��2��5,      	 �� DisplayMemberPath$	 FullName��5.      ��5-      �� *
PersonList+$ TwoWay=�
 �� SelectedItem
 5/      �� *PersonSelected+$ OneWayToSource=�51      52      