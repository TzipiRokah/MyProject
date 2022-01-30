---פרוצדורה לעדכון מספר האנשים המקסימלי במתקן לאחר שנשברו מספר מושבים
alter procedure UpdateMaxPeopleFromCurrHour @TimeNow DateTime, @AttractionId int, @AttractionMaxPeople int, @MaxPeopleNow int
as
begin
begin
declare @temp int
set @temp=@AttractionMaxPeople-@MaxPeopleNow
update [dbo].[Queues]
set [MaxPeopleInAttraction]+=@temp
where([Hour]>@TimeNow) and ([AttractionId]=@AttractionId)
end
select * from dbo.FindQueuesWithNullTickets(@TimeNow,@AttractionId)
end


exec UpdateMaxPeopleFromCurrHour '2020-10-18 09:24:00.000',7,2,3

----מציאת האנשים האחרונים שנכנסו לתור במקרה שבו נמכרו כל הכרטיסים
--ופתאום נשברו מספר מושבים

alter function FindQueuesWithNullTickets(@TimeNow DateTime, @AtrractionId int)
returns @NullQueuesTab table([QueueId][int],[AttractionId][int],[Hour][DateTime],[MaxPeopleInAttraction][int])
as
begin
insert into @NullQueuesTab
select * from [dbo].[Queues] 
where [MaxPeopleInAttraction]<0 and [AttractionId]=@AtrractionId and [Hour]>=@TimeNow
return
end


select * from dbo.FindQueuesWithNullTickets('2020-10-14 11:30:00.000',7)


---פרוצדורה לאיפוס התורים כל יום מחדש
create procedure ResetQueues
as
begin
delete from [dbo].[QueuePerUser]
DBCC CHECKIDENT ('[QueuePerUser]', RESEED, 0)
delete from [Queues]
DBCC CHECKIDENT ('[Queues]', RESEED, 0)
end

exec ResetQueues
-----reset tables Queues and QueuePerUser every day
/*delete from [dbo].[QueuePerUser]
DBCC CHECKIDENT ('[QueuePerUser]', RESEED, 0)
insert into  [dbo].[QueuePerUser]([QueueId],[UserId],[CountTickets]) values(1,1,3)
select * from [dbo].[QueuePerUser]

delete from [Queues]
DBCC CHECKIDENT ('[Queues]', RESEED, 0)
insert into  [dbo].[Queues]([AttractionId],[Hour],MaxPeopleInAttraction) values(1,'2020-09-21 08:00:00.000',50)
select * from [dbo].[Queues]*/

----פונקציה למציאת התור האחרון להיום למתקן מסוים
alter function LastQueuePerAttraction(@AttractionId int)
returns int
as
begin
declare @QueueId int
select @QueueId= MAX([QueueId]) from [dbo].[Queues] where [AttractionId]=@AttractionId
return @QueueId
end

print dbo.LastQueuePerAttraction(1)

----פרוצדורה למציאת התור האחרון להיום למתקן מסוים
alter procedure LastQueuePerAttractionProc @AttractionId int
as
begin
return (select MAX([QueueId]) from [dbo].[Queues] where [AttractionId]=@AttractionId)
end

declare @answer int
exec @answer= dbo.LastQueuePerAttractionProc 2
select @answer

