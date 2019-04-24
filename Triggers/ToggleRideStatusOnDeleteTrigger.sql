Create Trigger ToggleRideStatusOnDelete
On ThemePark.Maintenance
After Delete
AS
Begin
	
	--If we delete an emergency maintenance record, and there are no more incomplete emergency records for that ride
	-- switch it's ride status to Operable

	Set NOCOUNT ON

	Declare @rID int
	select @rID = DELETED.RideID from DELETED

	DECLARE @NumberOfEmergencyMaint int = (SELECT COUNT(M.MaintenanceID) 
											from ThemePark.Maintenance as M
											where(CorrectiveAction is null AND M.RideID = @rID AND M.MaintCode = 4))

	Update ThemePark.Ride
	Set RideStatus = 1
	from ThemePark.Ride as R
	where(@rID = R.RideID  AND @NumberOfEmergencyMaint = 0)
End