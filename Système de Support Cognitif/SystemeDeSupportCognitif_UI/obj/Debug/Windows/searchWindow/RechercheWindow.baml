   M S B A M L   `   `   `  ????  SystemeDeSupportCognitif_UIF    @SystemeDeSupportCognitif_UI.Windows.SearchWindow.RechercheWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $	??500??5   	   $	??300??5   	   ???#141414  ? Title$  	Recherche??5
   	    ? WindowStartupLocation$ CenterOwner=?5   	    ? WindowStyle$
 None=?5   	    ? Topmost . '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 30Q?6    ? 	Resources 5       ?? 
TargetType ?? Property	 ?? Value
 ?? 
TargetType ?? ClearTypeHint&   System.Windows.Media.TextOptions   TextRenderingMode   TextFormattingMode ?? Triggers P? Property P? Value ?? 
TargetName??%+  '??       ?? 5   
   " ??6   .?5      ??   ?@ IsHitTestVisibleInChrome	 . 6F   ?? 5       ? ??	 5      ?? 5      "
 ??6&   .R?5      ]? $??WindowButton??6$   $??45??68   .+?5      ?? $??Center=?6$   $??Center=?6A   #??z??6\   $??12(?6?   $??Segoe MDL2 Assets)?6?   ???#d2d2d2$
 Auto=?6?   $ Aliased=?6?   $ Display=?6  5       5       P? 5!       ?@J?IsMouseOver . . ?5"   "   ?? $ WindowButton??6)    ? ??	 ?#4b4b4b6Y   5$      5(      5,      5.      50       J? CommandBindings 52      )  #System.Windows.Input.CommandBinding  53   
   -   5        #  System.Windows.SystemCommands   MinimizeWindowCommand   Command# Z 53      6S     55   
   -   5           MaximizeWindowCommand# Z 55      6S     57   
   -   5           RestoreWindowCommand# Z 57      6R     59   
   -   5           CloseWindowCommand# Z 59      6P   .??5=      ?? $??2q?6   ???#4b96ff._?5>   
   ]? .+?5?      ]? $	??Top=?6   $??30??6-   .+?5@      ??  ?? Orientation$ 
Horizontal=?6   $
??Left=?66   .+?5A      ?? -   5        $??
WindowIcon??5A      $??Center=?6.   $	????6I   $??15(?6\   $??
UltraBlack"?6j   $??Segoe MDL2 Assets)?6?   ???#4b96ff6?   ?? 5C      $??Center=?6   $??Recheche??67   $??12(?6J   $??Arial)?6X   ???#d2d2d26k   5E      ?? 5G      $ 
Horizontal=?6   $??Right=?66   .+?5H      ?? $	????6   #??Z 60   ?? 5J      -   5        $??MaximizeWindowButton??5J      $	????69   #??Z 6L   ?? 5L      -   5        $??RestoreWindowButton??5L      $	????68   $y?	Collapsed=?6K   #??Z 6b   ?? 5N      $	????6   #??Z 60   5P      5R      ]? 5T      .+?5U      ? $??Bottom=?6   .+?5V      ?? -   5        $??SearchButton??5V   -   $??0??6   $??Center=?6A   $??
Rechercher??6\   $??20(?6q   $
??Bold"?6   $??Arial)?6?    5W      ??%^   '??       ?? 5X      " ??6$   .?5Y   "   ??  ?@??CornerRadius$	 5??6A   5[      5]      ??5_      ?? 5`      " ??6$   .?5a   "   ??  ? ??	 ?#64c84b6?   ?? 5c   "    ? ??	 5d   &   ?? 5e   *   "
 ??6:   .R?5f   .   ?? $??5q?65    ?? Padding$ 5q?6@   #??z??6L   ._?5g   2   ?? $??Center=?6C   $??Center=?6`   5i   /    5k   .   P? 5l   2    ?@J?IsMouseOver . . ?5m   6   ??  ? ??	 ?#64d7556S   5o   3   5s   +   5w   #   5y      5}      5      ? 5?      $??Center=?6    ? ColumnDefinitions 5?      ?? 5?      ?? 5?       ? RowDefinitions 5?      ?? 5?      ?? 5?      .+?5?      ?? $??Type:??6    
???????$??10 0 0 0q?6@   ?? 5?      -	   5        $??TypeComboBox??5?      $??1??63   $??10q?6@   5?      ?? 5?      $??1??6!   $??1??61   .+?5?      ?? -
   5        $??SearchTextbox??5?   >   $??Center=?6#   $??10q?6S   5?      5?      5?      5?      5?      5?      