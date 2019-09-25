select *from Purchase

select Suppliers.Name,Purchase.PurchaseId,Purchase.TotalAmount,Purchase.Discount,Purchase.GrandTotal,Purchase.Status,Purchase.Date from Purchase
join Suppliers on Suppliers.Id=Purchase.SupplierId