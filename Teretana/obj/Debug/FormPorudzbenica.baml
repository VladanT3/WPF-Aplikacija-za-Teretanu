   M S B A M L   `   `   `  ????C  ?Teretana, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TeretanaTeretana  5   	       Teretana.FormPorudzbenica   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Teretana     5   	     ? Title$  FormPorudzbenica??5   	   $	??537??6"   $	??708??6/    ? 	Resources 5	         cbDobavljaciTemplate??%T   &	        ?? 5
   
   .R?5      ?? ??6   ?? *NazivDobavljaca+5      5      .??5      ? $	??496??6   $	??676??6   .+?5   
   ?? $
??Left=?6   $??	10,10,0,0q?6/   $
??Wrap=?6B   $??	Proizvodi??6V   $	??Top=?6g   ?? 5   
   $
??Left=?6   $??
420,31,0,0q?6/   $
??Wrap=?6C   $&?? Unesite kolicinu za narucivanje:??6W   $	??Top=?6   ?? 5   
   -   5        $??
tbKolicina??5      {?.  $
??Left=?66   $??
590,31,0,0q?6Q    ?? TextWrapping$
 Wrap=?6e   $	??Top=?6y   $??60??6?   ?? 5   
   -   5        $??btnDodaj??5      {?.  $??Dodaj stavku??63   $
??Left=?6J   $??490,111,0,0q?6e   $	??Top=?6z   $??84??6?   6?   ?? 5   
   $
??Left=?6   $??
10,234,0,0q?6/   $
??Wrap=?6C   $??Trenutna porudzbenica??6W   $	??Top=?6t   ?? 5   
   -   5        $??	btnNaruci??5      $??Naruci??6"   {?.  $
??Left=?6E   $??163,460,0,0q?6`   $	??Top=?6u   $??84??6?   6?   ?? 5   
   -   5        $??cbDobavljaci??5      #??[  6'   $
??Left=?6\   $??420,281,0,0q?6w   $	??Top=?6?   $	??120??6?   ?? 5   
   $
??Left=?6   $??420,260,0,0q?6/   $
??Wrap=?6D   $4??.Izaberite od kog Dobavljaca da se naruci roba:??6X   $	??Top=?6?   $	??255??6?   ?? 5   
   -   5        $??btnObrisiStavku??5      $??Obrisi poslednju stavku??6(   $
??Left=?6J   $??420,414,0,0q?6e   $	??Top=?6z   $	??141??6?   6?   &   System.Windows.Controls.DataGrid  5   
   -   5        $??dataGridProizvodi??5         AutoGenerateColumns .  $??10,31,276,270q?6H   $	??390??6_      CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Proizvoda??6D   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 6Z   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   ?? *
ProizvodID+6Z     5      $ Naziv??6H   $		 150 6W   
 6%   ?? *NazivProizvoda+6W     5      $ Kolicina??6B   $	 60 6T   
 6%   ?? *
Kolicina+6T     5      $ Nabavna cena??6E   $		 100 6[   
 6%   ?? *NabavnaCena+6[   5      ?? 5    
   -   5        $??listBoxPorudzbenica??5       $??10,255,276,46q?6-   ?? 5!   
   -   5        $??tbUkupnaCena??5!      {?.  $
??Left=?68   $??420,352,0,0q?6S   $
 Wrap=?6h   $	??Top=?6|   $	??120??6?   ?? 5"   
   $
??Left=?6   $??420,331,0,0q?6/   $
??Wrap=?6D   $??Ukupna cena: ??6X   $	??Top=?6m   5#      5$      