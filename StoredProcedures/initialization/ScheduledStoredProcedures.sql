CREATE DEFINER=`root`@`%` PROCEDURE `UpdateIndicators`()
BEGIN
	CALL SMACalculation("kraken");
	CALL SMACalculation("binance");
	CALL VolumeFlowCalculation("kraken");
	CALL VolumeFlowCalculation("binance");
END

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateAlarms`()
BEGIN
	CALL SMATrending("kraken");
	CALL SMATrending("binance");
	CALL VolumeFlowTrending("kraken");
	CALL VolumeFlowTrending("binance");
END

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateOrders`()
BEGIN
	CALL OrderManager();
END

