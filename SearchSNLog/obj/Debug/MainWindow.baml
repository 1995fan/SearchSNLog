   M S B A M L   `   `   `  ����F  BSearchSNLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SearchSNLog.ViewModelSearchSNLog.ViewModel  5   	       SearchSNLog.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9	viewModel#clr-namespace:SearchSNLog.ViewModel     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  
MainWindow��5   	   $	��233��6   $	��538��6,    � DataContext 5      0   *SearchSNLog.ViewModel.SearchSNLogViewModel  5   
   6+   .��5
      %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *	IsWaiting+   BusyContent 69   �� *WaitingContent+.��5   
   � .+�5      � -   5         �Name$ GridMain��5      $y�Visible=�6%    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5      �� $��2��6   $��查询的文件��6%   $
��Left=�65   $	��Top=�6P   6j   �� 5      $��2��6   
���  ��$
��Left=�6;   $	��Top=�6V   $��75,5,0,0q�6�   ��6n   �� *TargetFileError+6�   �� 5      $��3��6   $
��Left=�6'   $��23��6B    �� TextWrapping$
 Wrap=�6N   $	��450��6b   $��7,1,0,1q�6n   ��6   �� *TargetFileName+6�   �� 5      $��3��6   $��浏览��6&   $
��Left=�63   $	��Top=�6N   $��	462,0,0,0q�6f   $��52��6y   ��6�   �� *SetTargetFileNameCommand+6�   �� 5      $��4��6   $��SN��6%   $
��Left=�62   $	��Top=�6M   $��0,0,0,0q�6e   �� 5      $��4��6   
���  ��$
��Left=�6;   $	��Top=�6V   $��30,5,0,0q�6�   ��6n   �� *	SNError+6�   �� 5      -   5         ��Name$ SN��5   '   $��5��6   $
��Left=�63   $��23��6N   $
 Wrap=�6Z   $	��450��6n   $��7,0,0,0q�6z   ��6�   �� *
SNFileName+6�   �� 5      $��5��6   $��浏览��6&   $
��Left=�63   $	��Top=�6N   $��	462,0,0,0q�6f   $��52��6y   ��6�   �� *SetSNFileNameCommand+6�   �� 5       $��6��6   $��生成目录��6%   $
��Left=�64   6Q   �� 5!      $��7��6   $
��Left=�6'   $��23��6B   $	��450��6N   $��7,1,0,42q�6Z   $��2��6l   ��6}   �� *	ResultDir+6�   �� 5"      $��7��6   $��浏览��6&   $
��Left=�63   $	��Top=�6N   $��	462,0,0,0q�6f   $��52��6y   ��6�   �� *SetResultLogDirCommand+6�   �� 5#      $��8��6   
���  ��$
��Left=�6;   $	��Top=�6V   $��5,10,0,0q�6�   ��6n   �� *	ResultStr+6�   �� 5$      $��8��6   $��查询��6&   $��Center=�63   $��75��6P   $��10q�6[   ��6g   �� *SearchSNLogCommand+6�   5%      � 5'      -   5        $ SNGrid��5'      $y�	Collapsed=�6#   .+�5(      �� ���	#90000000._�5)      �  � ColumnDefinitions 5*      �� 5+      $
��auto �60   �� 5,      .+�5.      �� $
��Left=�6"   $	��Top=�6=   $	��300��6U   $	��200��6a   $��5q�6n   $��0��6y   $
 Wrap=�6�   	 �� AcceptsReturn	 . ��6�   �� *	SNTextBox+6�   �� 5/      -   5        $��确定��5/   !   $
��Left=�6.   $	��Top=�6I   $��74��6a   $��60,80q�6l   $��1��6{   6�   50      51      52      54      55      57      