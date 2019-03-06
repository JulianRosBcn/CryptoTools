
-- SET GLOBAL event_scheduler = ON;

CREATE EVENT IF NOT EXISTS Event_Indicators
    ON SCHEDULE EVERY 1 MINUTE
    DO CALL analytics.UpdateIndicators();
		
CREATE EVENT IF NOT EXISTS Event_Alarms
    ON SCHEDULE EVERY 1 MINUTE
    DO CALL analytics.UpdateAlarms();
		
CREATE EVENT IF NOT EXISTS Event_Signals
    ON SCHEDULE EVERY 1 MINUTE
    DO CALL analytics.UpdateSignals();
		
		
CREATE EVENT IF NOT EXISTS Event_Orders
    ON SCHEDULE EVERY 1 MINUTE
    DO CALL orderbook.UpdateOrders();
		
