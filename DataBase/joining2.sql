select *from PurchaseDetails;

select *from SaleDetails;
select *from Sales;

select distinct Items.Name,PurchaseDetails.Batch,sum(PurchaseDetails.Qty) as TotalQty,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice from PurchaseDetails
join Items on Items.Name=PurchaseDetails.Item
group by Items.Name,PurchaseDetails.Batch,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice

select distinct Items.Name,sum(SaleDetails.Qty) as TotalQty from Items
join SaleDetails on SaleDetails.Item=Items.Name
group by Items.Name 

select distinct Items.Name,PurchaseDetails.Batch,(sum(PurchaseDetails.Qty) - SUM(SaleDetails.Qty)) as TotalQty,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice from PurchaseDetails
join Items on Items.Name=PurchaseDetails.Item
join SaleDetails on SaleDetails.Item=PurchaseDetails.Item
group by Items.Name,PurchaseDetails.Batch,PurchaseDetails.CostPrice,PurchaseDetails.SellingPrice



select i.Name,p.Batch,(SUM(p.Qty)-SUM(s.Qty)) as TotalQuantity from PurchaseDetails p
join Items i on i.Name=p.Item
join SaleDetails s on s.Item=p.Item
group by i.Name,p.Batch


