   M S B A M L   `   `   `  ���� I  ECalculator_wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Calculator_wpfCalculator_wpf      Calculator_wpf.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:Calculator_wpf       � Title$-  'Calculo de adiantamento de prestações��$��467.015��$��872.91�� � 	Resources    brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder  EntryFieldStyle �� 
TargetType �� Property �� Value  validationTemplate��%?  &	        &	      &	 +     &	 =     &	 �     �� $ White���� $ LightSteelBlue���� $ Indigo���� " �.���  � ��$ Stretch=���  � ��$ Center=���  � ��$
 20,0q��� .R�� .+��� 
���  ��$��Right=�$��Center=�.��Please insert a integer�� $��1q�
���  ��._��� .��� .+�� $��0,10,602,388q�.+��� -    ��Name$ textBox��$	��250��$��Center=�$
��Left=�$��5q� =� ErrorTemplate# [ ��  J� IsHitTestVisible .  $��Valor da parcela��$��Center=�$
��Left=�$��10,0,0,0q�
����������� " ��.���  � y�$ 	Collapsed=�	 �� Triggers	 �� 
 �� Binding
 �� *Text+ �� ElementName$ textBox�� �� Value  .a���  � y�$ Visible=�� $��0,49,602,349q�.+��� -   $ textBox1��$	��250��$��Center=�$
��Left=�$��5q���  .  $��Taxa de juros(ao mês)��$��Center=�$
��Left=�$��10,0,0,0q�
����������� " ��.���  � y�$ 	Collapsed=�	 �� 
 �� *Text+$ textBox1��  .a���  � y�$ Visible=�� $��0,88,602,310q�.+��� -   $ textBox2��$	��250��$��Center=�$
��Left=�$��5q���  .  $��Dia do vencimento��$��Center=�$
��Left=�$��10,0,0,0q�
����������� " ��.���  � y�$ 	Collapsed=�	 �� 
 �� *Text+$ textBox2��  .a���  � y�$ Visible=�� $��0,127,602,271q�.+��� -   $ textBox4��$	��250��$��Center=�$
��Left=�$��5q���  .  $��Quantidade de parcelas��$��Center=�$
��Left=�$��10,0,0,0q�
����������� " ��.���  � y�$ 	Collapsed=�	 �� 
 �� *Text+$ textBox4��  .a���  � y�$ Visible=�� $��0,166,602,232q�.+���  .  $��Center=�$
��Left=�$��10,0,0,0q�
����������� " ��.���  � y�$ 	Collapsed=�	 �� 
 �� *Text+$ textBox3��  .a���  � y�$ Visible=��� $#�Data de quitação dd/mm/aaaa��(  "System.Windows.Controls.DatePicker  -     Name$ 
datePicker��$
��Left=�$��10,5,0,0q�$	��Top=�$	��243���� -    ��Name$ button��$��Calcular��$
��Left=�$��
10,210,0,0q�$	��Top=�$	��244���� -   $��listView��$
��Left=�$	��300��$��
268,10,0,0q�$	��Top=�$	��587�� �� View ��  �� AllowsColumnReorder .  .P��� -   	listView1��$��
Vencimento�� �� Width$	 200�� �� DisplayMemberBinding �� *
vencimento+�� -	   	listView2��$��Valor��$	 175�� �� *valor+�� -
   	listView3��$��	Acumulado��$	 200�� �� *
acumulador+.@�� $	��236��$	��322��