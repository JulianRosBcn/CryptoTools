CREATE DEFINER=`root`@`%` PROCEDURE `UpdateIndicators`()
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

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateAlarms`()
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


CREATE DEFINER=`root`@`%` PROCEDURE `UpdateOrders`()
BEGIN
	CALL OrderManager();
END

