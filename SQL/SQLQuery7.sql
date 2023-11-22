-- explicit transaction

create table Account(
Id int not null identity(1,1),
Balance money not null
)

insert Account (Balance) values(200)

alter table account add constraint chk_acc_bal check (Balance >= 1000)
update Account set Balance=10000 where id=1

-- consider proc as a function
alter proc MoveMoney(@dacno int, @cracno int, @amt money)
as
-- initiates a new transaction in the database with the name "Movemoney"
begin tran Movemoney

begin try
    update Account set Balance = Balance-@amt where id = @cracno
    update Account set Balance = Balance+@amt where id = @dacno
	--print 'Money moved successfully'
   -- commit: save the changes made during the transaction
   commit tran Movemoney
   raiserror('Money moved successfully', 10,0)
end try
begin catch
   declare @er int
   set @er = @@ERROR
   if @er = 547
     begin
       -- print 'Could not remove money'
       -- rollback: undo the changes made during the transaction
       rollback tran Movemoney
	   raiserror('Could not remove money', 16, 0)
    end
end catch

exec MoveMoney 1, 2, 100

select * from Account