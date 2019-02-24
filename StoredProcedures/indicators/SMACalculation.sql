CREATE DEFINER=`root`@`%` PROCEDURE `SMACalculation`(

)

BEGIN

	SET time_zone='+01:00';
	
	INSERT INTO kraken.indicators (sma5min) SELECT AVG(last) FROM kraken.quotes WHERE timestamp < (NOW() - INTERVAL 5 minute);
	INSERT INTO kraken.indicators (sma20min) SELECT AVG(last) FROM kraken.quotes WHERE timestamp < (NOW() - INTERVAL 20 minute);
	INSERT INTO kraken.indicators (sma60min) SELECT AVG(last) FROM kraken.quotes WHERE timestamp < (NOW() - INTERVAL 60 minute);
	INSERT INTO kraken.indicators (sma24h) SELECT AVG(last) FROM kraken.quotes WHERE timestamp < (NOW() - INTERVAL 24 hour);
	INSERT INTO kraken.indicators (timestamp) VALUES (NOW());
	
END