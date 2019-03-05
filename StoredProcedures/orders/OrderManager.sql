CREATE DEFINER=`root`@`%` PROCEDURE `OrderManager`(
_coinpair VARCHAR(20)
)

BEGIN

	-- Variables to store order and order type when a position is opened/closed in the market
	DECLARE _order VARCHAR(10);
	DECLARE _type VARCHAR(10);
	DECLARE _lastorder VARCHAR(10);
	DECLARE _krakenstate VARCHAR(10) DEFAULT "neutral"; -- BUY / SELL / NEUTRAL 
	DECLARE _binancestate VARCHAR(10) DEFAULT "neutral"; -- BUY / SELL / NEUTRAL

	SET time_zone='+01:00';
	

	-- CHECKING LAST 5 MINUTE VALUES IN ALARMS
	-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------
	
	-- Kraken gathering 1min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
		SET _krakenstate = "sell";
	END IF;
	IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
		SET _krakenstate = "buy";
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- Kraken gathering 2min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_krakenstate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _krakenstate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _krakenstate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- Kraken gathering 3min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_krakenstate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _krakenstate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _krakenstate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- Kraken gathering 4min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_krakenstate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _krakenstate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _krakenstate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- Kraken gathering 5min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.kraken_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_krakenstate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _krakenstate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _krakenstate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------

	
	-- CHECKING LAST 5 MINUTE VALUES IN ALARMS
	-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------
	
	-- binance gathering 1min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
		SET _binancestate = "sell";
	END IF;
	IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
		SET _binancestate = "buy";
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- binance gathering 2min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_binancestate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _binancestate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _binancestate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- binance gathering 3min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 2,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_binancestate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _binancestate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _binancestate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- binance gathering 4min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 3,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_binancestate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _binancestate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _binancestate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	-- binance gathering 5min data
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma5min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma60min_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60mintrending := @query_output;
	
	SET @query = CONCAT('SELECT sma24h_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24htrending := @query_output;
	
	SET @query = CONCAT('SELECT volumeflow_trending FROM analytics.binance_alarms WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 4,1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volumeflowtrending := @query_output;
	
	IF (_binancestate IS NULL) THEN
		IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24htrending = "sell") THEN 
			SET _binancestate = "sell";
		END IF;
		IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
			SET _binancestate = "buy";
		END IF;
	END IF;
	-- ------------------------------------------------------------------------------------------------------------
	-- ------------------------------------------------------------------------------------------------------------
	
	
	SET @_lastorder := (SELECT `order` FROM orders  WHERE (coinpair = _coinpair ) ORDER BY timestamp DESC LIMIT 1);
	
	-- buy top
	IF  (@_binancestate = "buy") AND (@_krakenstate = "buy") AND (@_lastorder <> "buy") THEN 
		SET _order = "buy";
		SET _type= "top";
	END IF;
	
	-- sell standard
	IF  (@_binancestate = "sell") AND (@_krakenstate = "sell") AND (@_lastorder <> "sell") THEN 
		SET _order = "sell";
		SET _type= "top";
	END IF;
	
	-- Update values in orders table
	IF (_order IS NOT NULL) AND (_type IS NOT NULL) THEN
		INSERT INTO orders (`coinpair`,`order`,`type`,`timestamp`)
		VALUES (_coinpair,_order,_type,NOW());
	END IF;

END
	
