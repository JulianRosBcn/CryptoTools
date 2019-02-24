CREATE DEFINER=`root`@`%` PROCEDURE `InsertQuoteInfo`(
_ask DOUBLE,
_bid DOUBLE,
_last DOUBLE,
_volume DOUBLE,
_volumeavgprice DOUBLE,
_numoftrades DOUBLE,
_timestamp DATETIME
)
BEGIN
	INSERT INTO quotes (`ask`,`bid`,`last`,`volume`,`volumeavgprice`,`numoftrades`,`timestamp`)
    VALUES (_ask,_bid,_last,_volume,_volumeavgprice,_numoftrades,_timestamp);
END