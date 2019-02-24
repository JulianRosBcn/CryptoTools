CREATE DEFINER=`root`@`%` PROCEDURE `InsertQuoteInfo`(
_ask DOUBLE,
_bid DOUBLE,
_last DOUBLE,
_timestamp DATETIME
)
BEGIN
	INSERT INTO quotes (`ask`,`bid`,`last`,`timestamp`)
    VALUES (_ask,_bid,_last,_timestamp);
END