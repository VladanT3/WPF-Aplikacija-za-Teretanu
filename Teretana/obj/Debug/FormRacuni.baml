   M S B A M L   `   `   `  ????C  ?Teretana, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TeretanaTeretana  5   	       Teretana.FormRacuni   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Teretana     5   	     ? Title$  
FormRacuni??5   	   $	??309??6   $	??473??6)   .??5	      ? $	??473??6   $	??309??6   .+?5
   
   &   System.Windows.Controls.DataGrid  -   5        $??dataGridRacuni??5
         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $??33,31,47,86q?6?    ? ContextMenu 5      ?? 5      .@?5      m? -   5        $??menuUknjizi??5      $??Uknjizi racun??62   6I   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Racun??6A      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6P   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   ?? *	RacunID+6P     5      $ Datum kreiranja??6H   $	 150 6a   	 6%   ?? *DatumKreiranja+6a     5      $ Iznos??6D   $ 80 6S   	 6%   ?? *
CenaRacuna+6S     5      $ Klijent??6C   $ 80 6T   	 6%   ?? *	KlijentID+6T   5      ?? 5   
   $
??Left=?6   $??	33,10,0,0q?6/   $
??Wrap=?6B   $??Neuknjizeni racuni??6V   $	??Top=?6p   ?? 5   
   -   5        $??
btnZatvori??5      $??Zatvori??6#   $
??Left=?65   $??202,238,0,0q?6P   $	??Top=?6e   $??54??6}   6?   5      5      