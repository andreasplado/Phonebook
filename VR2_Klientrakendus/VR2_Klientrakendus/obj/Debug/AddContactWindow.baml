   M S B A M L   `   `   `  ����M  IVR2_Klientrakendus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VR2_KlientrakendusVR2_Klientrakendus  5   	   )    #VR2_Klientrakendus.AddContactWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:VR2_Klientrakendus     5   	     � Title$  Add Contact��5   	   $	��300��6   $	��300��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ TxtContactName��5
      $
��Left=�6*   $��23��6E   $��
145,92,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��137��6�   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��	14,92,0,0q�6B   $
��Wrap=�6U   $	��Top=�6i   $��23��6�   $��99��6�   �� 6�   $�Contact ��6�   �� 6�   $
�name��6�   �� 6�   $�:��6�   6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��
14,148,0,0q�6C   $
��Wrap=�6W   $	��Top=�6k   $��23��6�   $	��126��6�   �� 6�   $�Contact type��6�   �� 6�   $�:��6�   6�   �� 5   
   -   5         ��Name$ label��5      $��ADD CONTACT��6   $
��Left=�65   $��	10,51,0,0q�6P   $	��Top=�6c   $
��Bold"�6{   $��26��6�   $��94��6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��
14,120,0,0q�6C   $
��Wrap=�6W   $��Contact lastname:��6k   $	��Top=�6�   $��23��6�   �� 5   
   -   5        $ TxtContactLastName��5      $
��Left=�6.   $��23��6I   $��145,120,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��137��6�   �� 5   
   -   5         ��Name$ contactTypeComboBox��5      $
��Left=�60   $��145,148,0,0q�6K   $	��Top=�6`   $	��137��6x   �� 5   
   -   5        $ TxtContactValue��5      $
��Left=�6+   $��23��6F   $��145,175,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��137��6�   �� 5   
   -	   5        $ 
textBlock3��5      $
��Left=�6(   $��
14,176,0,0q�6C   $
��Wrap=�6W   $��Contact:��6k   $	��Top=�6{    J� RenderTransformOrigin$ 
1.68,0.691&�6�   $��22��6�   $��99��6�   �� 5   
   -
   5         ��Name$ BtnAddContact��5      $��Add contact��6(   $
��Left=�6>   $��191,219,0,0q�6Y   $	��Top=�6n   $��75��6�   6�   5      5      