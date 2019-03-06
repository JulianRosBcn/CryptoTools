CREATE DEFINER=`root`@`%` PROCEDURE `OrderManager`(
_coinpair VARCHAR(20)
)
BEGIN

	-- Variables to store order and order type when a position is opened/closed in the market
	DECLARE _order VARCHAR(10);
	DECLARE _lastorder VARCHAR(10);
	DECLARE _price DOUBLE;
	DECLARE _krakenstate VARCHAR(10) DEFAULT "neutral"; -- BUY / SELL / NEUTRAL 
	DECLARE _binancestate VARCHAR(10) DEFAULT "neutral"; -- BUY / SELL / NEUTRAL

	SET time_zone='+01:00';

	
	-- Kraken gathering
	SET @query = CONCAT('SELECT `order` FROM analytics.kraken_signals WHERE (timestamp > (NOW() - INTERVAL 5 minute))  AND (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET _krakenstate := @query_output;
	
	-- Last quote in Kraken for this coinpair will be considered the price for the alarm
	SET @query = CONCAT('SELECT last FROM markets.kraken_quotes WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_binancelastquote := @query_output;
	
	-- ------------------------------------------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------------------------------------------
	
	-- Binance gathering
	SET @query = CONCAT('SELECT `order` FROM analytics.binance_signals WHERE (timestamp > (NOW() - INTERVAL 5 minute))  AND (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET _binancestate := @query_output;
	
	-- Last quote in Binance for this coinpair will be considered the price for the alarm
	SET @query = CONCAT('SELECT last FROM markets.binance_quotes WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_krakenlastquote := @query_output;
	
	-- ------------------------------------------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------------------------------------------
	
	SET _lastorder := (SELECT `order` FROM orders  WHERE (coinpair = _coinpair ) ORDER BY timestamp DESC LIMIT 1);
	
	IF (_lastorder IS NULL) THEN SET _lastorder="none";
	END IF;
	
	-- buy
	IF  (_binancestate = "buy") AND (_krakenstate = "buy") AND (_lastorder <> "buy") THEN 
		SET _order = "buy";
		SET _price = @_krakenlastquote;
	END IF;
	
	-- sell standard
	IF  (_binancestate = "sell") AND (_krakenstate = "sell") AND (_lastorder <> "sell") THEN 
		SET _order = "sell";
		SET _price = @_binancelastquote;
	END IF;
	
	
	-- Update values in orders table
	IF (_order IS NOT NULL) THEN
		INSERT INTO orders (`coinpair`,`order`,`price`,`timestamp`)
		VALUES (_coinpair,_order,`_price`,NOW());
	END IF;

	-- SELECT _krakenstate, _binancestate, _order, _lastorder;
END