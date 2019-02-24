CREATE EVENT UpdateIndicators
    ON SCHEDULE EVERY 1 MINUTE
    DO
      CALL SMACalculation();