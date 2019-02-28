SET GLOBAL event_scheduler = ON

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