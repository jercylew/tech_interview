use product_catalogue

-- insert test data
if not exists (
		select * from catelogue
)
begin
	insert into catelogue values (1000, 'books', null)
	insert into catelogue values (1001, 'philosophy', 1000)
	insert into catelogue values (1002, 'metaphysics', 1001)
	insert into catelogue values (1003, 'confucianism', 1001)
	insert into catelogue values (1004, 'mencius', 1003)
	insert into catelogue values (1005, 'literature', 1000)
	insert into catelogue values (1006, 'lin yutang', 1005)
	insert into catelogue values (1007, 'software', null)
	insert into catelogue values (1008, 'utilities', 1007)
	insert into catelogue values (1009, 'file management', 1008)
end
go

-- query the n-level category product recursively
with n(catelogueid, cateloguename, parentcatelogueid, cateloguelevel, concatenador) as 
(
    select catelogueid, cateloguename, parentcatelogueid, 1 as cateloguelevel, convert(varchar(max), cateloguename) as concatenador
    from catelogue
    where parentcatelogueid is null
        union all
    select m.catelogueid, m.cateloguename, m.parentcatelogueid, cateloguelevel+1, n.concatenador+' - '+convert(varchar(max), m.cateloguename) as concatenador
    from catelogue as m, n
    where n.catelogueid = m.parentcatelogueid
)
select concatenador as 'category products' from n order by concatenador asc 
