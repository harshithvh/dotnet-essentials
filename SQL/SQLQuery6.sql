-- implicit transaction

create table Student(
Id int not null identity(1,1),
[Name] nvarchar(50) not null
)

insert Student ([Name]) values ('Student1')
insert Student ([Name]) values ('Student2')

update Student set [Name]='Stu1' where id=5

delete from Student where id=5

select * from student

-- will rollback to the previous commit - undo all the changes made previously, works only when implicit_transactions is on
rollback

-- has to be executed when implicit_transactions is on
commit

-- this command will not commit the data automatically, has to be done explicity(default is off)
set implicit_transactions on

-- this is a predefined variable which returns the no of uncommited data else returns 0
select @@TRANCOUNT