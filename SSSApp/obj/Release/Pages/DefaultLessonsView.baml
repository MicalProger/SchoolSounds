   M S B A M L   `   `   `  ���� A  =SSSApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SSSApp.PagesSSSApp.Pages  clr-namespace:SSSAppSSSApp  %    SSSApp.Pages.DefaultLessonsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:SSSApp.Pages     'SSSAppclr-namespace:SSSApp       N� Title$  DefaultLessonsView��.���  � RowDefinitions �� �� $��50 �.+�]� ��. .+�9� $ ��Игнорирование��$��Bottom=�.���� .+�	� -   $��UnMuteRB��$��5q�$!��Активно всегда�� d� 	IsChecked$
 TrueY�	� -   $��MuteRB��$��5q�$7��1Активно в определенные дни��� -   $��WBCollector�� � Orientation$ 
Horizontal=�{�.  .+��� -   $
 TrueY�$��Понедельник��$��5q��� -   $
 TrueY�$��Вторник��$��5q��� -   $
 TrueY�$��
Среда��$��5q��� -   $
 TrueY�$��Четверг��$��5q��� -   $
 TrueY�$��Пятница��$��5q��� -	   $
 TrueY�$��Суббота��$��5q��� -
   $
 TrueY�$��Воскресенье��$��5q��� -    ��Name$
 LsLB��$��5,5,5,5q� �� SelectionMode$ Extended=�$	��Top=�
������ ���� .R�]� $	��580������ *	LsColor+.+��� $1��+Cтандартное время урока��$��Right=�$��Center=�$��5q� �� *IsDefaultLsTime+��  �� Orientation$ Vertical=�$
��Left=�.+��� $��23(����� *Name+�� $ 
Horizontal=�.+��� $��15(�$��Время начала:��$��5q��� $��15(�$��5q����� *
STimeStr+�� $��15(�$��Время конца:��$��5q��� $��15(�$��5q����� *
ETimeStr+]� $��1����.  .+��� -   $��5q�$��5q�$��Добавить урок��$��Right=��� -   $��5q�$��5q�$��Удалить урок��$
��Left=�