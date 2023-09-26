--select * from [dbo].[Table] 
--select [dbo].[Table].Id,[dbo].[Table].uid,[dbo].[Table].title from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].uid=6
--select * from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].Id=17 order by [dbo].[Table].Id desc offset 10 rows
--select top 3  * from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].Id=17
--select * from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].Id=17
select * from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].Id=1
