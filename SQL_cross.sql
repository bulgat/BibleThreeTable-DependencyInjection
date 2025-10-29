declare @tb0 table (num int);
declare @tb1 table (num int);

insert into @tb0 (num) values (1),(7),(rand()*10)
insert into @tb1 (num) values (1),(7),(110)
select * from @tb0;
select * from @tb1;
--select * from @tb0 t0 join cross @tb1 t1 on t0.num=t1.num
select * from @tb0  cross join @tb1 