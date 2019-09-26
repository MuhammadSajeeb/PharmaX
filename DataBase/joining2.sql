select *from PurchaseDetails;

select *from SaleDetails;

select distinct Items.Name,PurchaseDetails.Batch,sum(PurchaseDetails.Qty) as TotalQty,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice from PurchaseDetails
join Items on Items.Name=PurchaseDetails.Item
group by Items.Name,PurchaseDetails.Batch,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice


select i.Name,p.Batch,(SUM(p.Qty)-SUM(s.Qty)) as TotalQuantity from PurchaseDetails p
join Items i on i.Name=p.Item
join SaleDetails s on s.Item=p.Item
group by i.Name,p.Batch

truncate table Sales 