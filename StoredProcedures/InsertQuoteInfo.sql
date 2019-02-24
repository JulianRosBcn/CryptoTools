CREATE DEFINER=`root`@`%` PROCEDURE `InsertQuoteInfo`(
_ask DOUBLE,
_bid DOUBLE,
_last DOUBLE,
_timestamp DATETIME
)
BEGIN
	INSERT INTO Quotes (`ask`,`bid`,`last`,`timestamp`)
    VALUES (_ask,_bid_last,_timestamp);
END