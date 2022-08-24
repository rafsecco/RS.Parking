CREATE DATABASE `RS.Parking`;

-- --To create a new user for DataBase RS.Parking
-- CREATE USER 'RsParking'@localhost IDENTIFIED BY 'MyDB@123';

-- --Only allow access from localhost (this is the most secure and common configuration you will use for a web application):
-- --GRANT USAGE ON *.* TO 'ProjectA'@localhost IDENTIFIED BY 'ProjectA@123';
-- --To allow access to MySQL server from any other computer on the network:
-- GRANT USAGE ON *.* TO 'RsParking'@'%' IDENTIFIED BY 'MyDB@123';

-- --Grant all privileges to a user on a specific database
-- --GRANT ALL privileges ON `RS.Log.ProjectA`.* TO 'ProjectA'@localhost;
-- GRANT ALL privileges ON `RS.Parking`.* TO 'RsParking'@'%';

-- --To be effective the new assigned permissions you must finish with the following command:
-- FLUSH PRIVILEGES;

USE `RS.Parking`;