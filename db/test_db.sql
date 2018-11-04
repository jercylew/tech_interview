use product_catalogue

-- insert test data
if not exists (
		select * from Catelogue
)
begin
	insert into Catelogue values (1000, 'books', null)
	insert into Catelogue values (1001, 'philosophy', 1000)
	insert into Catelogue values (1002, 'metaphysics', 1001)
	insert into Catelogue values (1003, 'confucianism', 1001)
	insert into Catelogue values (1004, 'mencius', 1003)
	insert into Catelogue values (1005, 'literature', 1000)
	insert into Catelogue values (1006, 'lin yutang', 1005)
	insert into Catelogue values (1007, 'software', null)
	insert into Catelogue values (1008, 'utilities', 1007)
	insert into Catelogue values (1009, 'file management', 1008)
end
go

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
select Concatenador as 'Category Products' from n order by Concatenador asc 
