   M S B A M L   `   `   `  ���� N  JFC.Ninja CSV Search, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SearchSNLog.ViewModelSearchSNLog.ViewModel      SearchSNLog.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9	viewModel#clr-namespace:SearchSNLog.ViewModel     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  FC.Ninja CSV Search��$	��233��$	��538�� � DataContext 0   *SearchSNLog.ViewModel.SearchSNLogViewModel  .��%  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *	IsWaiting+   BusyContent �� *WaitingContent+.��� .+�� -    �Name$ GridMain��$y�Visible=� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��2��$��	CSV Files��$
��Left=�$	��Top=�$��5,0,0,0q��� $��2��
���  ��$
��Left=�$	��Top=�$��75,5,0,0q����� *TargetFileError+�� $��3��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��450��$��7,0,0,0q����� *TargetFileName+�� $��3��$��	Browse...��$
��Left=�$	��Top=�$��	462,0,0,0q�$��56������ *SetTargetFileNameCommand+�� $��4��$��SN��$
��Left=�$	��Top=�$��7,0,0,0q��� $��4��
���  ��$
��Left=�$	��Top=�$��33,5,0,0q����� *	SNError+�� -    ��Name$ SN��$��5��$
��Left=�$��23��$
 Wrap=�$	��450��$��7,0,0,0q����� *
SNFileName+�� $��5��$��	Browse...��$
��Left=�$	��Top=�$��	462,0,0,0q�$��56������ *SetSNFileNameCommand+�� $��6��$��Save Directory��$
��Left=�$��5,0,0,0q��� $��7��$
��Left=�$��23��$	��450��$��7,0,0,42q�$��2������ *	ResultDir+�� $��7��$��	Browse...��$
��Left=�$	��Top=�$��	462,0,0,0q�$��56������ *SetResultLogDirCommand+�� $��8��
���  ��$
��Left=�$	��Top=�$��7,12,0,0q����� *	ResultStr+�� $��8��$��Search��$��Center=�$��75��$��10q����� *SearchSNLogCommand+� -   $ SNGrid��$y�	Collapsed=�.+��� ���	#90000000._��  � ColumnDefinitions �� $
��auto ��� .+��� $
��Left=�$	��Top=�$	��300��$	��200��$��5q�$��0��$
 Wrap=�	 �� AcceptsReturn	 . ���� *	SNTextBox+�� -   $��Confirm��$
��Left=�$	��Top=�$��74��$��26��$��60,80q�$��1��