CREATE SCHEMA `markets`;

USE markets;

CREATE TABLE `kraken_quotes` (
  `coinpair` VARCHAR(20) NOT NULL,  	
  `ask` DOUBLE NOT NULL,
  `bid` DOUBLE NOT NULL,
  `last` DOUBLE NOT NULL,
  `volume` DOUBLE NOT NULL,
  `timestamp` DATETIME NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `binance_quotes` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `ask` DOUBLE NOT NULL,
  `bid` DOUBLE NOT NULL,
  `last` DOUBLE NOT NULL,
  `volume` DOUBLE NOT NULL,
  `timestamp` DATETIME NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--------------------------------------------------------------------------------------------------

CREATE SCHEMA `analytics`;

USE analytics;

CREATE TABLE `kraken_indicators` (
  `sma5min` DOUBLE NOT NULL,
  `sma20min` DOUBLE NOT NULL,
  `sma60min` DOUBLE NOT NULL,
  `sma24h` DOUBLE NOT NULL,
  `volume5min` DOUBLE, -- Volume5min is updated with a SP so it will be null at first and updated later
  `volume60min` DOUBLE, -- Volume60min is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `kraken_alarms` (
  `sma5min_trending` VARCHAR(20) NOT NULL,
  `sma20min_trending` VARCHAR(20) NOT NULL,
  `sma60min_trending` VARCHAR(20) NOT NULL,
  `sma24h_trending` VARCHAR(20) NOT NULL,
  `volumeflow_trending` VARCHAR(20), -- Volume5min_trending is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `binance_indicators` (
  `sma5min` DOUBLE NOT NULL,
  `sma20min` DOUBLE NOT NULL,
  `sma60min` DOUBLE NOT NULL,
  `sma24h` DOUBLE NOT NULL,
  `volume5min` DOUBLE, -- Volume5min is updated with a SP so it will be null at first and updated later
  `volume60min` DOUBLE, -- Volume60min is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `binance_alarms` (
  `sma5min_trending` VARCHAR(20) NOT NULL,
  `sma20min_trending` VARCHAR(20) NOT NULL,
  `sma60min_trending` VARCHAR(20) NOT NULL,
  `sma24h_trending` VARCHAR(20) NOT NULL,
  `volumeflow_trending` VARCHAR(20), -- Volume5min_trending is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-------------------------------------------------------------------------------------------------


CREATE SCHEMA `orderbook`;

USE orderbook;

CREATE TABLE `orders` (
  `order` VARCHAR(20) NOT NULL,
  `type` VARCHAR(20) NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;