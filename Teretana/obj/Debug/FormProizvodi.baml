   M S B A M L   `   `   `  ????C  ?Teretana, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TeretanaTeretana  5   	       Teretana.FormProizvodi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Teretana     5   	     ? Title$  FormProizvodi??5   	   $	??335??6   $	??826??6,   .??5	      ? $	??311??6   $	??800??6   .+?5
   
   &   System.Windows.Controls.DataGrid  -   5        $??dataGridProizvodi??5
         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $??10,95,298,31q?6?    ? ContextMenu 5      ?? 5      .@?5      m? -   5        $??menuBrisanje??5      $??Obrisi proizvod??63   6L   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Proizvoda??6D      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Z   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   ?? *
ProizvodID+6Z     5      $ Naziv??6H   $	 150 6W   	 6%   ?? *NazivProizvoda+6W     5      $ Kolicina??6B   $ 60 6T   	 6%   ?? *
Kolicina+6T     5      $ Nabavna cena??6E   $	 100 6[   	 6%   ?? *NabavnaCena+6[     5      $ Prodajna cena??6F   $	 100 6]   	 6%   ?? *ProdajnaCena+6]   5      ?? 5   
   $??Pretraga po nazivu??6   $??10,10,604,221q?6/   .??5      ? .+?5      ?? $
??Left=?6   $??0,21,0,0q?67   $
??Wrap=?6I   $??Naziv: ??6]   $	??Top=?6l   ?? 5      -   5        $??
tbPretraga??5      $
??Left=?6,   $??	40,21,0,0q?6G   
 ?? TextWrapping$

 Wrap=?6Z   $	??Top=?6n   $	??120??6?   5      5      ?? 5   
   $??Unos i izmena proizvoda??6   $??507,10,10,31q?64   .??5      ? .+?5       ?? $
??Left=?6   $??	10,10,0,0q?67   $
??Wrap=?6J   $
??ID: ??6^   $	??Top=?6j   ?? 5!      -   5        $
??tbID??5!      $
??Left=?6&   $??	96,10,0,0q?6A   $

 Wrap=?6T   $	??Top=?6h   $	??120??6?   ?? 5"      $
??Left=?6   $??	10,51,0,0q?67   $
??Wrap=?6J   $??Naziv: ??6^   $	??Top=?6m   ?? 5#      -   5        $??tbNaziv??5#      $
??Left=?6)   $??	96,51,0,0q?6D   $

 Wrap=?6W   $	??Top=?6k   $	??120??6?   ?? 5$      $
??Left=?6   $??	10,95,0,0q?67   $
??Wrap=?6J   $??Nabavna cena: ??6^   $	??Top=?6t   ?? 5%      -   5        $??tbNabavnaCena??5%      $
??Left=?6/   $??	96,95,0,0q?6J   $

 Wrap=?6]   $	??Top=?6q   $	??120??6?   ?? 5&      $
??Left=?6   $??
10,139,0,0q?67   $
??Wrap=?6K   $??Prodajna cena: ??6_   $	??Top=?6v   ?? 5'      -   5        $??tbProdajnaCena??5'      $
??Left=?60   $??
96,138,0,0q?6K   $

 Wrap=?6_   $	??Top=?6s   $	??120??6?   ?? 5(      -   5        $??btnUnos??5(      $??Unesi proizvod??6(   $
??Left=?6A   $??
10,212,0,0q?6\   $	??Top=?6p   $	??102??6?   6?   ?? 5)      -	   5        $??	btnIzmena??5)      $??Promeni proizvod??6*   {?.  $
??Left=?6W   $??156,212,0,0q?6r   $	??Top=?6?   $	??103??6?   6?   5+      5,      ?? 5-   
   -
   5        $??btnPretrazi??5-      $??Pretrazi??6$   $
??Left=?67   $??
201,48,0,0q?6R   $	??Top=?6f   $??54??6~   6?   ?? 5.   
   -   5        $??btnReset??5.      $??Resetuj formu za izmenu??6!   $
??Left=?6C   $??
354,48,0,0q?6^   $	??Top=?6r   $	??148??6?   6?   5/      50      