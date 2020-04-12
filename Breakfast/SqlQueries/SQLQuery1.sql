update Categories set Name = REPLACE(Name,'#', '')
select * from Categories

select * from Basket
select * from OrderHdrs
select * from OrderDtls

delete from OrderDtls
delete from OrderHdrs


select * from products
update products set name = 'Торт Наполеон' where id = 43
delete from products where id between 47 and 51




