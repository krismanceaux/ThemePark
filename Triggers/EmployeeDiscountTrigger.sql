Create TRIGGER EmployeeDiscount
ON ThemePark.SeasonPassHolder
AFTER INSERT 
AS
BEGIN

	-- If the Season Pass Holder is an Employee as well, apply a discount to their season pass
	SET NOCOUNT ON

	DECLARE @tID int
	select @tID = INSERTED.TicketNumber from INSERTED

	DECLARE @sLN nvarchar(15)
	select @sLN = INSERTED.LastName from INSERTED

	DECLARE @sSA nvarchar(30)
	select @sSA	= INSERTED.StreetAddress from INSERTED
	
	Update ThemePark.Ticket
	set Price = 20.00
	from ThemePark.Ticket as T, ThemePark.ParkEmployee as E
	where (T.TicketNumber = @tID AND @sLN = E.LastName AND @sSA = E.StreetAddress)

END
