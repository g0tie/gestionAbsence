   M S B A M L   `   `   `  ����I  EGestionAbsence, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionAbsenceGestionAbsence  5   	       GestionAbsence.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GestionAbsence     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��Center=�6   $��Center=�6(    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��Stretch=�6   $	��Top=�6-    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Identifiant��6   $
��Left=�6*   $��Center=�6E    J� RenderTransformOrigin$ 0.504,1.157&�6`   �� 5      -   5         ��Name$ login��5       �� TextWrapping$
 Wrap=�6%   $
��Left=�69   $��Center=�6T   $	��195��6o   $��1��6{   5      � 5   
   $	��Top=�6   $��1��6'    � ColumnDefinitions 5      �� 5      $	��73* �6#   �� 5      $
��122* �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Mot de passe��6   $
��Left=�6+   $��Center=�6F   $ 0.479,0.579&�6a   $��26��6�   $��81��6�   $��2��6�   5!      �� 5"   
   -   5         ��Name$ btnConnexion��5"      $��	Connexion��6'   $
��Left=�6;   $��	98,80,0,0q�6V   $��1��6i   $	��Top=�6v   $��97��6�   6�   G� 5#   
   -   5         G�Name$ password��5#      $��0,31,0,0q�6(   $��1��6:   $	��Top=�6G   $��Center=�6_   $	��195��6|   $��19��6�   5%      5&      