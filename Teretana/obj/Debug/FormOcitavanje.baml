   M S B A M L   `   `   `  ????C  ?Teretana, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TeretanaTeretana  5   	       Teretana.FormOcitavanje   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Teretana     5   	     ? Title$  FormOcitavanje??5   	   $	??467??6    $	??518??6-   .??5	      ? $	??450??6   $	??494??6   .+?5
   
   ?? -   5        $
??tbID??5
      $
??Left=?6   $??
140,31,0,0q?69    ?? TextWrapping$
 Wrap=?6M   $	??Top=?6a   $	??150??6y   6?   ?? 5   
   $
??Left=?6   $??	32,31,0,0q?6/   $
??Wrap=?6B   $??Unesite ID Klijenta: ??6V   $	??Top=?6s   ?? 5   
   $
??Left=?6   $??	32,67,0,0q?6/   $
??Wrap=?6B   $ ??Danas su na trening dosli:??6V   $	??Top=?6x   &   System.Windows.Controls.DataGrid  5   
   -   5        $??dataGridKlijenti??5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $??32,88,32,67q?6?      RowDetailsVisibilityMode$ VisibleWhenSelected=?6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Klijenta??6C   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 6X   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   ?? *	KlijentID+6X     5      $	 Ime??6=   $		 100 6J   
 6%   ?? *Ime+6J     5      $ Prezime??6A   $		 100 6R   
 6%   ?? *	Prezime+6R     5      $ Email??6?   $		 150 6N   
 6%   ?? *Email+6N      RowDetailsTemplate 5      ?? 5      .R?5      ?? $??0q?6   
??????? ?? Padding$ 10q?6H   ._?5      ?  ? ColumnDefinitions 5      ?? 5   "   $	??100 ?63   ?? 5   "   $	??100 ?63   ?? 5   "   $	??100 ?63   ?? 5   "   $	??100 ?63    ? RowDefinitions 5      ?? 5   "   $
??Auto ?60   ?? 5    "   $
??Auto ?60   .+?5"      ?? $??Clanarina: ??6(   $??0??6;   $??0??6H   $??2q?6X   ?? 5#      $??
Traje od: ??6(   $??1??6:   $??0??6G   $??2q?6W   ?? 5$      $??
Traje do: ??6(   $??1??6:   $??2??6G   $??2q?6W   ?? 5%      $??Broj termina: ??6(   $??0??6>   $??2??6K   $??2q?6[   ?? 5&       ?? 
IsReadOnly . $??0??6U   $??1??6b   $??2q?6r   ??68   ?? *ClanarinaID+6r   ?? 5'       . $??0??6U   $??3??6b   $??2q?6r   ??68   ?? *BrojTermina+6r   ?? 5(       . $??1??6_   $??1??6l   $??2q?6|   ??68   ?? *DatumPocetkaClanarine+6|   ?? 5)       . $??1??6^   $??3??6k   $??2q?6{   ??68   ?? *DatumIstekaClanarine+6{   5*      5+      5,      5.      ?? 5/   
   -   5        $??
btnZatvori??5/      $??Zatvori??6#   $??Center=?65   $??	0,396,0,0q?6R   $	??Top=?6e   $??68??6}   6?   ?? 50   
   -   5        $??	btnOcitaj??50      $??Ocitaj??6"   {?.  $
??Left=?6E   $??
306,30,0,0q?6`   $	??Top=?6t   $??50??6?   6?   51      52      