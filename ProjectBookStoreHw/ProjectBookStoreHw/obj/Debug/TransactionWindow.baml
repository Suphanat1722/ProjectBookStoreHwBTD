   M S B A M L   `   `   `  ����M  IProjectBookStoreHw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectBookStoreHwProjectBookStoreHw  5   	   *    $ProjectBookStoreHw.TransactionWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectBookStoreHw     5   	     � Title$  TransactionWindow��5   	   $	��650��6#   $
��1280��60   .��5	      � .+�5
   
   �� $
��ISBN��6   $
��Left=�6   $	��Top=�6:   $��
40,102,0,0q�6R   $��20(�6f   �� 5   
   -   5         ��Name$ txtISBN��5      $
��Left=�6#   $	��Top=�6>   $	��200��6V   $��123,107,0,0q�6b   $��30��6w   6�   �� 5   
   $*��$จำนวนหนังสือ��6   $
��Left=�6'   $	��Top=�6B   $��424,329,0,0q�6Z   $��20(�6o   �� 5   
   -   5        $ 
txtQuatity��5      $
��Left=�6&   $	��Top=�6A   $��97��6Y   $��30��6d   $��610,334,0,0q�6p    �� TextWrapping$
 Wrap=�6�   �� 5   
   $-��'หมายเลขสมาชิก��6   $
��Left=�6(   $	��Top=�6C   $��424,370,0,0q�6[   $��20(�6p   �� 5   
   -   5        $ 	txtCus_Id��5      $
��Left=�6%   $	��Top=�6@   $	��200��6X   $��610,377,0,0q�6d   $��30��6y   �� 5   
   -   5         ��Name$ buttonApply��5      $9��3ยืนยันการสั่งซื้อ��6&   $
��Left=�6B   $��474,434,0,0q�6]   $	��Top=�6r   $	��250��6�   $��68��6�   $��20(�6�   6�   �� 5   
   -   5         ��Name$ transactionListView��5      $
��Left=�60   $	��100��6K   $��
40,172,0,0q�6X   $	��Top=�6l   $
��1200��6�    �� View 5      �� 5      .P�5      �� $$��รหัสสินค้า��6%    �� Width$	 150��6_    �� DisplayMemberBinding 69   �� *ISBN+6_   �� 5      $'��!ชื่อหนังสือ��6%   $	 300��6a    6:   �� *Title+6a   �� 5      $$��รายละเอียด��6%   $	 600��6f    69   �� *Description+6f   �� 5      $��ราคา��6%   $	 150��6Z    63   �� *Price+6Z   5      5      5      5      