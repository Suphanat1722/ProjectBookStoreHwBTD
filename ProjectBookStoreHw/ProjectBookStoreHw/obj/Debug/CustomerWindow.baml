   M S B A M L   `   `   `  ����M  IProjectBookStoreHw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectBookStoreHwProjectBookStoreHw  5   	   '    !ProjectBookStoreHw.CustomerWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectBookStoreHw     5   	     � Title$  CustomerWindow��5   	   $	��500��6    $
��1280��6-   .��5	      � .+�5   
   �� $��ID��6   $
��Left=�6   $	��Top=�68   $��	35,58,0,0q�6P   $��20(�6c   �� 5   
   -   5         ��Name$ txtCustomer_Id��5      $
��Left=�6*   $	��Top=�6E   $	��150��6]   $��
213,57,0,0q�6i   $��30��6}   �� 5   
   $*��$ชื่อ - นามสกุล��6   $
��Left=�6)   $	��Top=�6D   $��	35,98,0,0q�6\   $��20(�6o   �� 5   
   -   5        $ txtCustomer_Name��5      $
��Left=�6,   $	��Top=�6G   $	��250��6_   $��30��6k   $��213,104,0,0q�6w    �� TextWrapping$
 Wrap=�6�   �� 5   
   $��ที่อยู่��6   $
��Left=�6"   $	��Top=�6=   $��
35,144,0,0q�6U   $��20(�6i   �� 5   
   -   5        $ 
txtAddress��5      $
��Left=�6&   $	��Top=�6A   $	��457��6Y   $��213,154,0,0q�6e   $��63��6z   �� 5   
   -   5         ��Name$ ButtonAddCustomer��5      $	��Add��6,   $
��Left=�6:   $	��Top=�6U   $	��100��6m   $��
722,61,0,0q�6y   $��30��6�   �� 5   
   -   5        $ buttonDeleteCustomer��5      $��Delete��6/   $
��Left=�6@   $	��Top=�6[   $	��100��6s   $��722,254,0,0q�6   $��30��6�   �� 5   
   -   5         ��Name$ customersListView��5      $
��Left=�6.   $	��100��6I   $��
35,327,0,0q�6V   $	��Top=�6j   $��1200                   ��6�    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$	 100��6^    �� DisplayMemberBinding 61   �� *Customer_Id+6^   �� 5      $
��Name��6%   $	 250��6b    63   �� *Customer_Name+6b   �� 5      $��Address��6%   $	 600��6_    66   �� *	Address+6_   �� 5      $��Email��6%   $	 250��6[    64   �� *Email+6[   5      5      �� 5    
   -   5        $ ButtonSearchCustomers��5       $��Search��60   $
��Left=�6A   $	��Top=�6\   $	��100��6t   $��722,124,0,0q�6�   $��30��6�   �� 5!   
   -   5        $ ButtonUpdateCustomer��5!      $��Update��6/   $
��Left=�6@   $	��Top=�6[   $	��100��6s   $��722,187,0,0q�6    J� RenderTransformOrigin$ 0.225,0.492&�6�   $��30��6�   �� 5"   
   -	   5        $ txtEmail��5"      $
��Left=�6$   $	��Top=�6?   $	��250��6W   $��30��6c   $��213,240,0,0q�6o   $
 Wrap=�6�   �� 5#   
   $��Email��6   $
��Left=�6    $	��Top=�6;   $��
35,233,0,0q�6S   $��20(�6g   5%      5&      