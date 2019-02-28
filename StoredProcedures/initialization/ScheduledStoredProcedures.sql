CREATE DEFINER=`root`@`%` PROCEDURE `UpdateIndicators`()
BEGIN
	CALL SMACalculation();
	CALL VolumeFlowCalculation();
END

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateAlarms`()
BEGIN
	CALL SMATrending();
	CALL VolumeFlowTrending();
END

CREATE DEFINER=`root`@`%` PROCEDURE `UpdateOrders`()
BEGIN
	CALL OrderManager();
END