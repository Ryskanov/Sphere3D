   M S B A M L   `   `   `  ����E  AGeometry3D, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Geometry3D
Geometry3D  5          Geometry3D.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Geometry3D     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��800��5	      $	��650��5
      .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5      �� $��0��5      $��25��5       � Maximum$	 360Q�5       � Minimum$ 0Q�5       � Value 5      ��  �� ElementName$ rotate1�� �� Path$ Angle��� 5      $��1��5      $��25��5      $	 360Q�5      $ 0Q�5       5      �� $ rotate2��$ Angle�'� 5      $��2��6    '� Camera 5      =� 5        � LookDirection$ 0,0.6,-15�6   	 � Position$	 0,-2.3,41�61   x�5"      g� 5#      
 g� Content
 5$      "� 5%       !� Position$ -2,-4,41�6    �� Color$ White��6&   5'      g� 5(      
 5)      � 5*       � Geometry 5+   	   k� 5,   
   -   5        Sphere3D��5,       � Material 5.   	   u� 5/   
    u� Brush
 ��  �6   51   	    g� 	Transform 53      Y� 54      .�55   	   ��  �� Rotation 56   
   �� 57      -   5        rotate1�� �� Axis$ 1 1 15�57   0   59   
   �� 5:   	    5;   
   �� 5<      -   5        rotate2��$ 0 0 15�5<   0   5>   
   5?   	   5A      5C      5D      5E      