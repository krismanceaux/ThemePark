Create Trigger ToggleRideStatusOp
On ThemePark.Maintenance
After Update
AS
Begin

--If an emergency maintenance record is completed and the corrective action was submitted,
	-- check how many incommplete emergency records for that specific ride exist 
	-- if there are no more incomplete emergency records for that ride, switch its status to Operable
	Set NOCOUNT ON

	Declare @rID int
	select @rID = INSERTED.RideID from INSERTED

	DECLARE @NumberOfEmergencyMaint int = (SELECT COUNT(M.MaintenanceID) 
											from ThemePark.Maintenance as M
											where(CorrectiveAction is null AND M.RideID = @rID AND M.MaintCode = 4))

	Update ThemePark.Ride
	Set RideStatus = 1
	from ThemePark.Ride as R, ThemePark.Maintenance as M
	where(@rID = R.RideID AND @rID = M.RideID AND M.MaintCode = 4 AND @NumberOfEmergencyMaint = 0)
End