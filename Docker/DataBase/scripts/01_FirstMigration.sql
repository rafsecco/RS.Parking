-- CREATE DATABASE `RS.Parking`;
-- USE `RS.Parking`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    CREATE TABLE `tb_AccordType` (
        `id_accord` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `bln_active` tinyint(1) NOT NULL,
        `dt_dateCreated` datetime(6) NOT NULL DEFAULT NOW(),
        `ie_accord` smallint unsigned NOT NULL,
        `nr_percentage` decimal(5,2) NOT NULL,
        `ds_accord` varchar(100) COLLATE utf8_general_ci NOT NULL,
        CONSTRAINT `PK_tb_AccordType` PRIMARY KEY (`id_accord`)
    ) COLLATE=utf8_general_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    CREATE TABLE `tb_ControlInOut` (
        `id_controlInOut` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `cd_vehicle` TINYINT UNSIGNED NOT NULL,
        `cd_accord` TINYINT UNSIGNED NOT NULL,
        `dt_in` datetime(6) NOT NULL DEFAULT NOW(),
        `dt_out` datetime(6) NULL,
        `ds_licensePlate` varchar(7) COLLATE utf8_general_ci NOT NULL,
        CONSTRAINT `PK_tb_ControlInOut` PRIMARY KEY (`id_controlInOut`)
    ) COLLATE=utf8_general_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    CREATE TABLE `tb_VehicleType` (
        `id_vehicle` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `bln_active` tinyint(1) NOT NULL,
        `dt_dateCreated` datetime(6) NOT NULL DEFAULT NOW(),
        `vl_cost` decimal(15,2) NOT NULL,
        `ds_vehicle` varchar(100) COLLATE utf8_general_ci NOT NULL,
        CONSTRAINT `PK_tb_VehicleType` PRIMARY KEY (`id_vehicle`)
    ) COLLATE=utf8_general_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    INSERT INTO `tb_AccordType` (`id_accord`, `bln_active`, `dt_dateCreated`, `ds_accord`, `ie_accord`, `nr_percentage`)
    VALUES (1, TRUE, TIMESTAMP '2024-04-06 17:17:33', 'No Discount', 0, 0.0),
    (2, TRUE, TIMESTAMP '2024-04-06 17:17:33', 'Subway', 1, 50.0),
    (3, TRUE, TIMESTAMP '2024-04-06 17:17:33', 'McDonald''s', 2, 100.0),
    (4, TRUE, TIMESTAMP '2024-04-06 17:17:33', 'PharmaTech', 2, 50.0);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    INSERT INTO `tb_ControlInOut` (`id_controlInOut`, `cd_accord`, `dt_in`, `dt_out`, `ds_licensePlate`, `cd_vehicle`)
    VALUES (1, 1, TIMESTAMP '2024-04-05 08:00:00', TIMESTAMP '2024-04-05 10:00:00', 'BRL-123', 1),
    (2, 2, TIMESTAMP '2024-04-05 10:00:00', TIMESTAMP '2024-04-05 12:30:00', 'BRL-456', 1),
    (3, 3, TIMESTAMP '2024-04-05 12:30:00', TIMESTAMP '2024-04-05 14:30:00', 'BRL-789', 1),
    (4, 4, TIMESTAMP '2024-04-05 16:30:00', TIMESTAMP '2024-04-05 18:30:00', 'BRL-147', 1),
    (5, 1, TIMESTAMP '2024-04-04 08:00:00', TIMESTAMP '2024-04-04 10:00:00', 'BRL-123', 2),
    (6, 2, TIMESTAMP '2024-04-04 10:00:00', TIMESTAMP '2024-04-04 12:30:00', 'BRL-456', 2),
    (7, 3, TIMESTAMP '2024-04-04 12:30:00', TIMESTAMP '2024-04-04 14:30:00', 'BRL-789', 2),
    (8, 4, TIMESTAMP '2024-04-04 16:30:00', TIMESTAMP '2024-04-04 18:30:00', 'BRL-147', 2),
    (9, 1, TIMESTAMP '2024-04-03 08:00:00', TIMESTAMP '2024-04-03 10:00:00', 'BRL-123', 3),
    (10, 2, TIMESTAMP '2024-04-03 10:00:00', TIMESTAMP '2024-04-03 12:30:00', 'BRL-456', 3),
    (11, 3, TIMESTAMP '2024-04-03 12:30:00', TIMESTAMP '2024-04-03 14:30:00', 'BRL-789', 3),
    (12, 4, TIMESTAMP '2024-04-03 16:30:00', TIMESTAMP '2024-04-03 18:30:00', 'BRL-147', 3),
    (13, 1, TIMESTAMP '2024-04-06 08:00:00', NULL, 'BRL-123', 3),
    (14, 2, TIMESTAMP '2024-04-06 10:00:00', NULL, 'BRL-456', 3),
    (15, 3, TIMESTAMP '2024-04-06 12:30:00', NULL, 'BRL-789', 3),
    (16, 4, TIMESTAMP '2024-04-06 16:30:00', NULL, 'BRL-147', 3);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (1, TRUE, 4.0, TIMESTAMP '2024-04-06 17:17:33', 'Car 1 (small)'),
    (2, TRUE, 5.5, TIMESTAMP '2024-04-06 17:17:33', 'Car 2 (big)'),
    (3, TRUE, 3.0, TIMESTAMP '2024-04-06 17:17:33', 'Moto 1');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    CREATE INDEX `idx_tb_ControleInOut_dt_out` ON `tb_ControlInOut` (`dt_out`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240406201734_Initial') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240406201734_Initial', '8.0.3');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

