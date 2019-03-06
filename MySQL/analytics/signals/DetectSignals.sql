delimiter | 

DROP PROCEDURE IF EXISTS analytics.DetectSignals;

CREATE DEFINER=`root`@`%` PROCEDURE analytics.DetectSignals(
_market VARCHAR(20),
_coinpair VARCHAR(20)
)

BEGIN

	-- Variables to store order and order type when a position is opened/closed in the market
	DECLARE _order VARCHAR(10);
	DECLARE _marketstate VARCHAR(10) DEFAULT "neutral"; -- BUY / SELL / NEUTRAL 
	
	-- SET time_zone='+01:00';
	
	-- kraken gathering data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.',_market,'_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.',_market,'_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.',_market,'_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.',_market,'_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.',_market,'_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	-- Last quote in markets DB for this coinpair will be considered the price for the alarm
	SET @query = CONCAT('SELECT last FROM markets.',_market,'_quotes WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_lastquote := @query_output;
	
	IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
		SET _marketstate = "sell";
	END IF;
	IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
		SET _marketstate = "buy";
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	
	
	-- buy top
	IF  (_marketstate = "buy") THEN 
	 SET _order = "buy";
	END IF;
	
	-- sell standard
	IF  (_marketstate = "sell") THEN 
	 SET _order = "sell";
	END IF;
	
	
	-- Update values in  table
	
	IF (_market = 'kraken') THEN
	 IF (_order IS NOT NULL) THEN
		INSERT INTO analytics.kraken_signals (`coinpair`,`order`,`price`,`timestamp`)
		VALUES (_coinpair,_order,@_lastquote,NOW());
	 END IF;
	END IF;
	
	IF (_market = 'binance') THEN
	 IF (_order IS NOT NULL) THEN
		INSERT INTO analytics.binance_signals (`coinpair`,`order`,`price`,`timestamp`)
		VALUES (_coinpair,_order,@_lastquote,NOW());
	 END IF;
	END IF;
	
END
|