   M S B A M L   `   `   `  ����H  DRentalService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RentalServiceRentalService  5   	       RentalService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:RentalService  5   	   -   5          � Title$%  Rental Service by Mykola Zaiets��5	   	   $	��600��61   $
��1040��6>    � WindowStyle$
 None=�6K   $	��600��6_   $
��1040��6o   $	��450��6   $	��650��6�    � WindowStartupLocation$ CenterScreen=�6�   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.8* �6   �� 5      $��1* �6   .+�5   
   �� $��Stretch=�6   $��Stretch=�6/   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF163077��6#   	 � Offset$	 1Q�65   � 5      $ 	#FF10A3D6��6#   5      5      ]� 5   
   ��.  $��Center=�6*   $��Stretch=�6E   .+�5      �� $
��50,0q�6   ���	#DDFFFFFF$��Corbel Light)�69   $��48(�6S   $	��Top=�6a   .��6w   
Welcome to6�   �� 5      $
��50,0q�6   ���	#DDFFFFFF$��48(�69   $
��Bold"�6G   $��Segoe UI Symbol)�6Y   $	��Top=�6v   .��6�   Rental Service6�   �� 5      $
��50,0q�6   ���	#DDFFFFFF$��Corbel Light)�69   $��18(�6S   $	��Top=�6a   .��6w   !The best service for car rental6�   5      ]� 5    
   $��1��6   .+�5!      � .+�5#      � -   5        $��LOGIN��5#      .+�5$      � $��Right=�6   $	��Top=�64   $��10q�6L   .+�5%      �� -   5        
������ 
������ ���	#FF27AAF0$	��Top=�5%   �   .��6�   	SIGN UP6�   '  !MaterialDesignThemes.Wpf.PackIcon  5&      
   Kind$
 
ArrowRight=�62   ���	#FF27AAF0$��Center=�6[   $��Right=�6v   5'      ]� 5(      $��1��6    $��2��6-   ��.  $��Center=�6W   .+�5)      �� $	��Top=�6    $��16(�65   $
��Bold"�6C   ���#27AAF0$��30,30,30,10q�6j   .��6   LOGIN6�   �� 5*      -   5        $��logTxtBox_login��5*   "   $	��Top=�69   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Login��6N   $��30��6u   $��30,10q�6�    �� 
CaretBrush �	#FF005DFF6�   G� 5+      -   5        $��	passwdbox��5+   &   $	��Top=�67   $ Password��6L   $��30��6v   $��30,10q�6�    G� 
CaretBrush �	#FF005DFF6�   �� 5,      -   5        $��30,10q�5,   !   ���	#FF27AAF0���	#FF27AAF0$	��Top=�6_   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 12��6t   
�������.��6�   LOGIN6�   �� 5-      $	��Top=�6#   $��Right=�68   $
��30,5q�6T   .��6c   Remember me6p   �� 5.      -   5        $��
chb_alogin��5.   #    J� Opacity$ 0Q�65   $	��Top=�6A   $��Right=�6V   $
��30,5q�6r   
������ 
������ 
������ 6�   5/      50      � 52      -   5        $��SignUP��52      $y�Hidden=�6!   .+�53      � $��Right=�6   $	��Top=�63   $��10q�6K   .+�54      �� -	   5        
������ 
������ ���	#FF27AAF0.��54   �   Login6�     55      $
 
ArrowRight=�6.   ���	#FF27AAF0$��Center=�6W   $��Right=�6r   56      ]� 57      $��1��6   $��2��6)   ��.  $��Center=�6S   .+�58      �� $	��Top=�6   $��16(�61   $
��Bold"�6?   ���#27AAF0$��30,30,30,10q�6f   .��6{   Create account6�   �� 59       �� 	MaxLength$ 10��6   $	��Top=�6-   $ Login��6B   $��30��6i   $��30,10q�6u    �	#FF005DFF.��6�   ��5:      �� 5;   "    �� Path$ RegisterModel.Login�6*    �� ValidationRules 5<   &   5  /System.Windows.Controls.DataErrorValidationRule  5=   *   5?   #   .��5@   ,   5A      �� 5B      $ 30��6   $	��Top=�6-   $ Email��6B   $��30��6i   $��30,10q�6u    �	#FF005DFF.��6�   ��5C      �� 5D   "   $ RegisterModel.Email�6*    5E   &     5F   *   5H   #   .��5I   ,   5J      �� 5K      $ 12��6"   $	��Top=�61   $ Password��6F   $��30��6p   $��30,10q�6|    �	#FF005DFF.��6�   ��5L      �� 5M   "   $ RegisterModel.Passwd�6*    5N   &     5O   *   5Q   #   .��5R   ,   5S      �� 5T      $ 12��6"   $	��Top=�61   $ Confirm your password��6F   $��30��6}   $��30,10q�6�    �	#FF005DFF.��6�   ��5U      �� 5V   "   $! RegisterModel.ConfirmPasswd�6*    5W   &     5X   *   5Z   #   .��5[   ,   5\      �� 5]      -
   5        $��licAgree��5]   g   $	��Top=�6w   $
��Left=�6�   $
��30,5q�6�   ���	#FF27AAF0���	#FF27AAF0 d� 	IsChecked 6#   �� *RegisterModel.isAgreeLic+ �� Mode$ OneWayToSource=�.��6�    I accept the license agreement6  �� 5^      -   5        $��30,10q�5^   Q   ���	#FF27AAF0���	#FF27AAF0$	��Top=�6�   $ 12��6�   
�������{�6!   �� *RegisterModel.isAllValide+.��6   	Sign Up6	  5_      5`      5a      5b      5c      5d      