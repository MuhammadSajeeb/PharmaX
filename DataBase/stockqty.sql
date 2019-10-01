(select t3.Item,t3.Batch,t3.StockQty,t3.CostPrice,t3.SellingPrice from((select t1.Item,t1.Batch,((t1.TotalPurchaseQty)-(t2.TotalSellingQty)) as StockQty,t1.CostPrice,t1.SellingPrice from (select Item,Batch,Sum(Qty) as TotalPurchaseQty,CostPrice,SellingPrice from PurchaseDetails group by Item,Batch,CostPrice,SellingPrice) t1 
inner join
(Select Item,sum(Qty) as TotalSellingQty from SaleDetails group by Item) t2 on t1.Item=t2.Item ) t3
inner join
(select Name,ReorderLevel from Items)t4 on t3.Item=t4.Name) where t3.StockQty < t4.ReorderLevel)



select Item,Batch,CostPrice from PurchaseDetails where Item='Napa' order by Id desc