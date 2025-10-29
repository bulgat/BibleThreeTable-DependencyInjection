select * from Author
select * from TitleBook
--select aa.Name from Author aa join TitleBook tt on aa.Id=tt.uid group by aa.Name having COUNT(aa.Name)>2
select aa.Name from Author aa left join TitleBook tt on aa.Id=tt.uid group by aa.Name having COUNT(aa.Name)<2