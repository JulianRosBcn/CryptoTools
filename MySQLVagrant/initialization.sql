-- DB INITIALIZATION 0.0.1

-- /initialization
source vagrant/MySQL/initialization/initDB.sql
source vagrant/MySQL/initialization/DeleteAnalyticsTableData.sql
source vagrant/MySQL/initialization/DeleteOrdersTableData.sql
source vagrant/MySQL/initialization/DeleteQuotesTableData.sql
source vagrant/MySQL/initialization/ScheduledStoredProcedures.sql
source vagrant/MySQL/initialization/EventsCreation.sql

-- /markets
source vagrant/MySQL/quotes/InsertQuoteInfo.sql

-- /analytics
source vagrant/MySQL/analytics/indicators/SMACalculation.sql
source vagrant/MySQL/analytics/indicators/VolumenFlowCalculation.sql
source vagrant/MySQL/analytics/alarms/SMATrending.sql
source vagrant/MySQL/analytics/alarms/VolumeFlowTrending.sql
source vagrant/MySQL/analytics/signals/DetectSignals.sql

-- /orders
source vagrant/MySQL/orders/OrderManager.sql




