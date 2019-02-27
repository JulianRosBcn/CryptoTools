SET GLOBAL event_scheduler = ON

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateIndicators`()
BEGIN
	CALL SMACalculation();
	CALL VolumeFlowCalculation();
END

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateAlarms`()
BEGIN
	CALL SMATrending();
	CALL VolumeFlowTrending();
END

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateOrders`()
BEGIN
	CALL OrderManager();
END


CREATE EVENT Event_Indicators
    ON SCHEDULE EVERY 1 MINUTE
    DO 
		CALL UpdateIndicators();
		
CREATE EVENT Event_Alarms
    ON SCHEDULE EVERY 1 MINUTE
    DO 
		CALL UpdateAlarms();
		
CREATE EVENT Event_Orders
    ON SCHEDULE EVERY 1 MINUTE
    DO 
		CALL UpdateOrders();