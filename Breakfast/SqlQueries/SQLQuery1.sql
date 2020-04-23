update Categories set Name = REPLACE(Name,'#', '')
select * from Categories

select * from Basket
select * from OrderHdrs
select * from OrderDtls

delete from OrderDtls
delete from OrderHdrs


select * from products
update products set name = 'Торт Наполеон' where id = 43
delete from products where id =46


select * from OrderHdrs
update OrderHdrs set Status = 0 where DeliveryDateTime>'2020-04-20'

select * from OrderDtls 
where ProductId = 38


select * from OrderHdrs h
join OrderDtls d on h.Id = d.OrderHdrId 
where h.Id = 70

update d
set d.Status = 1
from OrderDtls as d
join OrderHdrs h on h.Id = d.OrderHdrId
where DeliveryDateTime<'2020-04-25'

update  OrderHdrs set  Status = 3 where Id in(61, 76)
update  OrderHdrs set  Status = 5 where DeliveryDateTime<'2020-04-25'

delete from OrderDtls where OrderHdrId in (
select Id from OrderHdrs where DeliveryDateTime>'2020-04-25'
)

delete from OrderHdrs where DeliveryDateTime>'2020-04-25'
