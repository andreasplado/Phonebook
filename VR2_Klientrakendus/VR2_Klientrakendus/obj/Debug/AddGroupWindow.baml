   M S B A M L   `   `   `  ����M  IVR2_Klientrakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VR2_KlientrakendusVR2_Klientrakendus  5   	   ` \Xceed.Wpf.Toolkit, Version=3.0.16174.17450, Culture=neutral, PublicKeyToken=ba83ff368b7563c6P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5   	   '    !VR2_Klientrakendus.AddGroupWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:VR2_Klientrakendus     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	     � Title$  	Add Group��5	   	   $	��350��6   $	��300��6(   .��5
      � .+�5   
   �� -   5         ��Name$ BtnAddGroup��5      $��	Add group��6&   $
��Left=�6:   $��207,239,0,47q�6U   $��75��6k   6v   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��	10,14,0,0q�6B   $
��Wrap=�6U   $��Group name:��6i   $	��Top=�6|   �� 5   
   -   5         ��Name$ TxtGroupName��5      $
��Left=�6(   $��23��6C   $��	84,10,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��198��6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��	10,38,0,0q�6C   $
��Wrap=�6V   $��Group description:��6j   $	��Top=�6�   %  Xceed.Wpf.Toolkit.MaskedTextBox  5   
   -   5          Name$ TxtGroupDescription��5       $
��Left=�6=   $	��175��6X   $��	10,59,0,0q�6e   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��272��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   5      5      