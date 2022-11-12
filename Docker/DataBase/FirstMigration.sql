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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

    CREATE TABLE `tb_ControlInOut` (
        `id_controlInOut` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `cd_vehicle` TINYINT UNSIGNED NOT NULL,
        `cd_accord` TINYINT UNSIGNED NULL,
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

    INSERT INTO `tb_AccordType` (`id_accord`, `ie_accord`, `bln_active`, `dt_dateCreated`, `ds_accord`, `nr_percentage`)
    VALUES (1, 0, TRUE, TIMESTAMP '2022-11-12 09:01:57', 'PharmaTech', 0.0);
    INSERT INTO `tb_AccordType` (`id_accord`, `ie_accord`, `bln_active`, `dt_dateCreated`, `ds_accord`, `nr_percentage`)
    VALUES (2, 1, TRUE, TIMESTAMP '2022-11-12 09:01:57', 'Subway', 50.0);
    INSERT INTO `tb_AccordType` (`id_accord`, `ie_accord`, `bln_active`, `dt_dateCreated`, `ds_accord`, `nr_percentage`)
    VALUES (3, 2, TRUE, TIMESTAMP '2022-11-12 09:01:57', 'McDonald''s', 100.0);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

    INSERT INTO `tb_ControlInOut` (`id_controlInOut`, `cd_accord`, `dt_in`, `dt_out`, `ds_licensePlate`, `cd_vehicle`)
    VALUES (1, NULL, TIMESTAMP '2022-11-12 09:01:57', NULL, 'BRL-123', 1);
    INSERT INTO `tb_ControlInOut` (`id_controlInOut`, `cd_accord`, `dt_in`, `dt_out`, `ds_licensePlate`, `cd_vehicle`)
    VALUES (2, NULL, TIMESTAMP '2022-11-12 09:01:57', NULL, 'BRL-456', 2);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (1, TRUE, 5.0, TIMESTAMP '2022-11-12 09:01:57', 'Car 1');
    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (2, TRUE, 5.5, TIMESTAMP '2022-11-12 09:01:57', 'Car 2');
    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (3, TRUE, 3.0, TIMESTAMP '2022-11-12 09:01:57', 'Moto 1');
    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (4, TRUE, 3.5, TIMESTAMP '2022-11-12 09:01:57', 'Moto 2');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221112120157_Initial') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221112120157_Initial', '6.0.7');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

