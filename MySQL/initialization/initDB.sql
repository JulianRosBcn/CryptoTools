CREATE SCHEMA IF NOT EXISTS `markets`;

USE markets;

CREATE TABLE IF NOT EXISTS  `kraken_quotes` (
  `coinpair` VARCHAR(20) NOT NULL,  	
  `ask` DOUBLE NOT NULL,
  `bid` DOUBLE NOT NULL,
  `last` DOUBLE NOT NULL,
  `volume` DOUBLE NOT NULL,
  `timestamp` DATETIME NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS  `binance_quotes` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `ask` DOUBLE NOT NULL,
  `bid` DOUBLE NOT NULL,
  `last` DOUBLE NOT NULL,
  `volume` DOUBLE NOT NULL,
  `timestamp` DATETIME NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ------------------------------------------------------------------------------------------------

CREATE SCHEMA IF NOT EXISTS `analytics`;

USE analytics;

CREATE TABLE IF NOT EXISTS  `kraken_indicators` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `sma5min` DOUBLE NOT NULL,
  `sma20min` DOUBLE NOT NULL,
  `sma60min` DOUBLE NOT NULL,
  `sma24h` DOUBLE NOT NULL,
  `volume5min` DOUBLE, -- Volume5min is updated with a SP so it will be null at first and updated later
  `volume60min` DOUBLE, -- Volume60min is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS  `kraken_alarms` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `sma5min_trending` VARCHAR(20) NOT NULL,
  `sma20min_trending` VARCHAR(20) NOT NULL,
  `sma60min_trending` VARCHAR(20) NOT NULL,
  `sma24h_trending` VARCHAR(20) NOT NULL,
  `volumeflow_trending` VARCHAR(20), -- Volume5min_trending is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS  `binance_indicators` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `sma5min` DOUBLE NOT NULL,
  `sma20min` DOUBLE NOT NULL,
  `sma60min` DOUBLE NOT NULL,
  `sma24h` DOUBLE NOT NULL,
  `volume5min` DOUBLE, -- Volume5min is updated with a SP so it will be null at first and updated later
  `volume60min` DOUBLE, -- Volume60min is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS  `binance_alarms` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `sma5min_trending` VARCHAR(20) NOT NULL,
  `sma20min_trending` VARCHAR(20) NOT NULL,
  `sma60min_trending` VARCHAR(20) NOT NULL,
  `sma24h_trending` VARCHAR(20) NOT NULL,
  `volumeflow_trending` VARCHAR(20), -- Volume5min_trending is updated with a SP so it will be null at first and updated later
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS  `kraken_signals` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `order` VARCHAR(20) NOT NULL,
  `price` DOUBLE NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS  `binance_signals` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `order` VARCHAR(20) NOT NULL,	
  `price` DOUBLE NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- -----------------------------------------------------------------------------------------------


CREATE SCHEMA IF NOT EXISTS `orderbook`;

USE orderbook;

CREATE TABLE IF NOT EXISTS  `orders` (
  `coinpair` VARCHAR(20) NOT NULL, 
  `order` VARCHAR(20) NOT NULL,
  `price` DOUBLE NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;