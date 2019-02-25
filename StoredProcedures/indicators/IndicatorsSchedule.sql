SET GLOBAL event_scheduler = ON

CREATE EVENT UpdateIndicators
    ON SCHEDULE EVERY 1 MINUTE
    DO CALL SMACalculation();