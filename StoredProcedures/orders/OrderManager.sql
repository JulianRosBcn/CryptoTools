CREATE DEFINER=`root`@`%` PROCEDURE `OrderManager`(
_coinpair VARCHAR(20)
)

BEGIN

	-- Variables to store order and order type when a position is opened/closed in the market
	DECLARE _order VARCHAR(10);
	DECLARE _lastorder VARCHAR(10);
	DECLARE _krakenstate VARCHAR(10) DEFAULT "neutral"; -- BUY / SELL / NEUTRAL 
	DECLARE _binancestate VARCHAR(10) DEFAULT "neutral"; -- BUY / SELL / NEUTRAL

	SET time_zone='+01:00';

	
	-- Kraken gathering
	SET @query = CONCAT('SELECT `order` FROM analytics.kraken_signals WHERE (timestamp > (NOW() - INTERVAL 5 minute))  AND (coinpair = "',_coinpair, '") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET _krakenstate := @query_output;
	
		-- Binance gathering
	SET @query = CONCAT('SELECT `order` FROM analytics.binance_signals WHERE (timestamp > (NOW() - INTERVAL 5 minute))  AND (coinpair = "',_coinpair, '") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET _binancestate := @query_output;
	
	
	
	SET _lastorder := (SELECT `order` FROM orders  WHERE (coinpair = _coinpair ) ORDER BY timestamp DESC LIMIT 1);
	
	-- buy
	IF  (_binancestate = "buy") AND (_krakenstate = "buy") AND (_lastorder <> "buy") THEN 
		SET _order = "buy";
	END IF;
	
	-- sell standard
	IF  (_binancestate = "sell") AND (_krakenstate = "sell") AND (_lastorder <> "sell") THEN 
		SET _order = "sell";
	END IF;
	
	
	-- Update values in orders table
	IF (_order IS NOT NULL) THEN
		INSERT INTO orders (`coinpair`,`order`,`timestamp`)
		VALUES (_coinpair,_order,NOW());
	END IF;

	-- SELECT _krakenstate, _binancestate, _order, _lastorder;
END
	
