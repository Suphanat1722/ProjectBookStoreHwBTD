   M S B A M L   `   `   `  ����M  IProjectBookStoreHw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectBookStoreHwProjectBookStoreHw  5   	   #    ProjectBookStoreHw.BookWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ProjectBookStoreHw     5   	     � Title$  
BookWindow��5   	   $	��720��6   $
��1280��6)   .��5	      � .+�5   
   �� $'��!ชื่อหนังสือ��6   $
��Left=�6&   $	��Top=�6A   $��	37,80,0,0q�6Y   $��20(�6l   �� 5   
   -   5         ��Name$ txtTitleBook��5      $
��Left=�6(   $	��Top=�6C   $	��200��6[   $��
178,89,0,0q�6g   $��30��6{   �� 5   
   $$��รายละเอียด��6   $
��Left=�6%   $	��Top=�6@   $��
37,140,0,0q�6X   $��20(�6l   �� 5   
   -   5        $ txtDescriptionBook��5      $
��Left=�6.   $	��Top=�6I   $	��417��6a   $��85��6m   $��178,146,0,0q�6y    �� TextWrapping$
 Wrap=�6�   �� 5   
   $��ราคา��6   $
��Left=�6   $	��Top=�6:   $��
37,236,0,0q�6R   $��20(�6f   �� 5   
   -   5        $ txtPriceBook��5      $
��Left=�6(   $	��Top=�6C   $	��100��6[   $��178,244,0,0q�6g   $��30��6|   �� 5   
   -   5         ��Name$ ButtonAddBook��5      $	��Add��6(   $
��Left=�66   $	��Top=�6Q   $	��100��6i   $��
660,24,0,0q�6u   $��30��6�   �� 5   
   -   5        $ buttonDeleteBook��5      $��Delete��6+   $
��Left=�6<   $	��Top=�6W   $	��100��6o   $��660,212,0,0q�6{   $��30��6�   �� 5   
   -   5         ��Name$ booksListView��5      $
��Left=�6*   $	��350��6E   $��
35,300,0,0q�6R   $	��Top=�6f   $
��1200��6~    �� View 5      �� 5      .P�5      �� $
��ISBN��6%    �� Width$	 150��6Y    �� DisplayMemberBinding 63   �� *ISBN+6Y   �� 5      $��Title��6%   $	 300��6[    64   �� *Title+6[   �� 5      $��Description��6%   $	 600��6g    6:   �� *Description+6g   �� 5      $��Price��6%   $	 150��6[    64   �� *Price+6[   5      5      �� 5    
   -   5        $ ButtonSearchBook��5       $��Search��6+   $
��Left=�6<   $	��Top=�6W   $	��100��6o   $��
660,88,0,0q�6{   $��28��6�   �� 5!   
   -   5        $ ButtonUpdateBook��5!      $��Update��6+   $
��Left=�6<   $	��Top=�6W   $	��100��6o   $��660,146,0,0q�6{    J� RenderTransformOrigin$ 0.225,0.492&�6�   $��30��6�   �� 5"   
   $
��ISBN��6   $
��Left=�6   $	��Top=�6:   $��	37,19,0,0q�6R   $��20(�6e   �� 5#   
   -	   5        $ txtIsbn��5#      $
��Left=�6#   $	��Top=�6>   $	��200��6V   $��
178,27,0,0q�6b   $��30��6v   5%      5&      