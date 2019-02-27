CREATE SCHEMA `kraken`

USE kraken;

CREATE TABLE `quotes` (
  `ask` DOUBLE NOT NULL,
  `bid` DOUBLE NOT NULL,
  `last` DOUBLE NOT NULL,
  `volume` DOUBLE NOT NULL,
  `volumetoday` DOUBLE NOT NULL,
  `volumeavgprice` DOUBLE NOT NULL,
  `numoftrades` DOUBLE NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `indicators` (
  `sma5min` DOUBLE NOT NULL,
  `sma20min` DOUBLE NOT NULL,
  `sma60min` DOUBLE NOT NULL,
  `sma24h` DOUBLE NOT NULL,
  `volume5min` DOUBLE, -- Volume5min is updated with a SP so it will be null at first and updated later
  `volume60min` DOUBLE, -- Volume60min is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `alarms` (
  `sma5min_trending` VARCHAR(20) NOT NULL,
  `sma20min_trending` VARCHAR(20) NOT NULL,
  `sma60min_trending` VARCHAR(20) NOT NULL,
  `sma24h_trending` VARCHAR(20) NOT NULL,
  `volumeflow_trending` VARCHAR(20), -- Volume5min_trending is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `orders` (
  `order` VARCHAR(20) NOT NULL,
  `type` VARCHAR(20) NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;