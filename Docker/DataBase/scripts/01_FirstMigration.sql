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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240418111404_Initial') THEN

    CREATE TABLE `tb_AccordType` (
        `id_accord` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `bln_active` tinyint(1) NOT NULL,
        `dt_dateCreated` datetime(6) NOT NULL DEFAULT NOW(),
        `ie_accord` smallint unsigned NOT NULL,
        `nr_percentage` double NOT NULL,
        `ds_accord` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240418111404_Initial') THEN

    CREATE TABLE `tb_VehicleType` (
        `id_vehicle` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `bln_active` tinyint(1) NOT NULL,
        `dt_dateCreated` datetime(6) NOT NULL DEFAULT NOW(),
        `vl_cost` decimal(15,2) NOT NULL,
        `ds_vehicle` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240418111404_Initial') THEN

    CREATE TABLE `tb_ControlInOut` (
        `id_controlInOut` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `cd_vehicle` TINYINT UNSIGNED NOT NULL,
        `cd_accord` TINYINT UNSIGNED NOT NULL DEFAULT 0,
        `dt_in` datetime(6) NOT NULL DEFAULT NOW(),
        `dt_out` datetime(6) NULL,
        `ds_licensePlate` varchar(7) COLLATE utf8_general_ci NOT NULL,
        CONSTRAINT `PK_tb_ControlInOut` PRIMARY KEY (`id_controlInOut`),
        CONSTRAINT `FK_tb_ControlInOut_tb_AccordType_cd_accord` FOREIGN KEY (`cd_accord`) REFERENCES `tb_AccordType` (`id_accord`),
        CONSTRAINT `FK_tb_ControlInOut_tb_VehicleType_cd_vehicle` FOREIGN KEY (`cd_vehicle`) REFERENCES `tb_VehicleType` (`id_vehicle`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240418111404_Initial') THEN

    CREATE INDEX `idx_tb_ControleInOut-dt_in_dt_out` ON `tb_ControlInOut` (`dt_in`, `dt_out`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240418111404_Initial') THEN

    CREATE INDEX `IX_tb_ControlInOut_cd_accord` ON `tb_ControlInOut` (`cd_accord`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240418111404_Initial') THEN

    CREATE INDEX `IX_tb_ControlInOut_cd_vehicle` ON `tb_ControlInOut` (`cd_vehicle`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240418111404_Initial') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240418111404_Initial', '8.0.4');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

