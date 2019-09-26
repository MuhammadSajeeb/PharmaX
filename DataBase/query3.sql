select *from PurchaseDetails

--select (SUM(PurchaseDetails.Qty)-SUM(SaleDetails.Qty)) from PurchaseDetails

select SUM(Qty) from PurchaseDetails where Item='Napa';

select SUM(Qty) from SaleDetails Where Item='Napa';

Select top 1 SellingPrice from PurchaseDetails where Item='Napa' order by SellingPrice desc