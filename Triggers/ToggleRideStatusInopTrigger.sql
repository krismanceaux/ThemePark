Create Trigger ToggleRideStatusInop
On ThemePark.Maintenance
After Insert
AS
Begin

	--If an emergency maintenance record is created for a ride,
	-- switch the ride's status to Inoperable
	Set NOCOUNT ON

	Declare @rID int
	select @rID = INSERTED.RideID from INSERTED

	Declare @mID int
	select @mID = INSERTED.MaintenanceID from INSERTED

	Update ThemePark.Ride
	Set RideStatus = 2
	from ThemePark.Ride as R, ThemePark.Maintenance as M
	where(R.RideID = @rID AND M.MaintenanceID = @mID AND M.MaintCode = 4)
End