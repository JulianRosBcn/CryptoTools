CREATE SCHEMA `kraken`

USE kraken;

CREATE TABLE `quotes` (
  `ask` DOUBLE NOT NULL,
  `bid` DOUBLE NOT NULL,
  `last` DOUBLE NOT NULL,
  `volume` DOUBLE NOT NULL,
  `volumeavgprice` DOUBLE NOT NULL,
  `numoftrades` DOUBLE NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `indicators` (
  `sma5min` DOUBLE NOT NULL,
  `sma20min` DOUBLE NOT NULL,
  `sma60min` DOUBLE NOT NULL,
  `sma24h` DOUBLE NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;