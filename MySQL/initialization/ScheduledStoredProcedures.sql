
delimiter |

DROP PROCEDURE IF EXISTS analytics.UpdateIndicators;

CREATE DEFINER=`root`@`%` PROCEDURE analytics.UpdateIndicators()
BEGIN
	CALL SMACalculation("kraken","btcusd");
	CALL SMACalculation("kraken","btcltc");
	CALL SMACalculation("kraken","btceth");
	
	CALL SMACalculation("binance","btcusd");
	CALL SMACalculation("binance","btcltc");
	CALL SMACalculation("binance","btceth");
	
	CALL VolumeFlowCalculation("kraken","btcusd");
	CALL VolumeFlowCalculation("kraken","btcltc");
	CALL VolumeFlowCalculation("kraken","btceth");
	
	CALL VolumeFlowCalculation("binance","btcusd");
	CALL VolumeFlowCalculation("binance","btcltc");
	CALL VolumeFlowCalculation("binance","btceth");
END
|

delimiter |

DROP PROCEDURE IF EXISTS analytics.UpdateAlarms;

CREATE DEFINER=`root`@`%` PROCEDURE analytics.UpdateAlarms()
BEGIN
	CALL SMATrending("kraken","btcusd");
	CALL SMATrending("kraken","btcltc");
	CALL SMATrending("kraken","btceth");
	
	CALL SMATrending("binance","btcusd");
	CALL SMATrending("binance","btcltc");
	CALL SMATrending("binance","btceth");
	
	CALL VolumeFlowTrending("kraken","btcusd");
	CALL VolumeFlowTrending("kraken","btcltc");
	CALL VolumeFlowTrending("kraken","btceth");
	
	CALL VolumeFlowTrending("binance","btcusd");
	CALL VolumeFlowTrending("binance","btcltc");
	CALL VolumeFlowTrending("binance","btceth");
END
|

delimiter |

DROP PROCEDURE IF EXISTS analytics.UpdateSignals;

CREATE DEFINER=`root`@`%` PROCEDURE analytics.UpdateSignals()
BEGIN
	CALL DetectSignals("kraken","btcusd");
	CALL DetectSignals("kraken","btcltc");
	CALL DetectSignals("kraken","btceth");
	
	CALL DetectSignals("binance","btcusd");
	CALL DetectSignals("binance","btcltc");
	CALL DetectSignals("binance","btceth");
	

END
|

delimiter |

DROP PROCEDURE IF EXISTS orderbook.UpdateOrders;

CREATE DEFINER=`root`@`%` PROCEDURE orderbook.UpdateOrders()
BEGIN
	CALL OrderManager("btcusd");
	CALL OrderManager("btcltc");
	CALL OrderManager("btceth");
END

|