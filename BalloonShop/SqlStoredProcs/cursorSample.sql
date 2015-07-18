use BalloonShop
go

Declare @Did as int;
Declare @DName as nvarchar(50);

Declare @DepCursor as Cursor;

Set @DepCursor = cursor for
Select DepartmentID, Name  
from Department

Open @DepCursor;
Fetch next from @DepCursor into @Did, @DName;

While @@FETCH_STATUS = 0
Begin
  Print cast(@Did as varchar(10)) + ' ' + @Dname
  Fetch next from @DepCursor into @Did, @DName;
end

close @DepCursor;
Deallocate @DepCursor;