use product_catalogue

-- insert test data
if not exists (
		select * from Catelogue
)
begin
	insert into Catelogue values (1000, 'Books', null)
	insert into Catelogue values (1001, 'Philosophy', 1000)
	insert into Catelogue values (1003, 'Confucianism', 1001)
	insert into Catelogue values (1005, 'Literature', 1000)
	insert into Catelogue values (1007, 'Software', null)
	insert into Catelogue values (1008, 'Utilities', 1007)
	
	insert into Product values (1002, 'Metaphysics', 25.50, 'A introduction to metaphysics', 1001)
	insert into Product values (1004, 'Mencius', 35.20, 'A introduction to mencius', 1003)
	insert into Product values (1006, 'Lin Yutang', 65.50, 'A introduction to lin yutang', 1005)
	insert into Product values (1009, 'File Management', 125.50, 'A introduction to file management', 1008)
end
go

select * from Product
select * from Catelogue

-- query the n-level category product recursively
with n(CatelogueID, CatelogueName, ParentcatelogueID, CatelogueLevel, Concatenador) as 
(
    select CatelogueID, CatelogueName, ParentcatelogueID, 1 as CatelogueLevel, convert(varchar(max), CatelogueName) as Concatenador
    from Catelogue
    where ParentcatelogueID is null
        union all
    select m.CatelogueID, m.CatelogueName, m.ParentcatelogueID, CatelogueLevel+1, n.Concatenador+' - '+convert(varchar(max), m.CatelogueName) as Concatenador
    from Catelogue as m, n
    where n.CatelogueID = m.ParentcatelogueID
)
select  n.Concatenador + ' - ' + Product.ProductName from Product, n where Product.CatelogueID = n.CatelogueID order by n.Concatenador asc
