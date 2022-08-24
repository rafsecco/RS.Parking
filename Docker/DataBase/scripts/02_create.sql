USE `RS.Parking`;

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

    CREATE TABLE `tb_AccordType` (
        `id_accord` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `bln_active` tinyint(1) NOT NULL,
        `dt_dateCreated` datetime(6) NOT NULL DEFAULT NOW(),
        `ie_accord` int NOT NULL,
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

    CREATE TABLE `tb_ControlInOut` (
        `id_controlInOut` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
        `cd_vehicle` TINYINT UNSIGNED NOT NULL,
        `cd_accord` TINYINT UNSIGNED NOT NULL,
        `dt_in` datetime(6) NOT NULL DEFAULT NOW(),
        `dt_out` datetime(6) NULL,
        `ds_licensePlate` varchar(7) COLLATE utf8_general_ci NOT NULL,
        CONSTRAINT `PK_tb_ControlInOut` PRIMARY KEY (`id_controlInOut`),
        CONSTRAINT `FK_tb_ControlInOut_tb_AccordType_cd_accord` FOREIGN KEY (`cd_accord`) REFERENCES `tb_AccordType` (`id_accord`) ON DELETE CASCADE,
        CONSTRAINT `FK_tb_ControlInOut_tb_VehicleType_cd_vehicle` FOREIGN KEY (`cd_vehicle`) REFERENCES `tb_VehicleType` (`id_vehicle`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

    INSERT INTO `tb_AccordType` (`id_accord`, `ie_accord`, `bln_active`, `dt_dateCreated`, `ds_accord`, `nr_percentage`)
    VALUES (1, 0, TRUE, TIMESTAMP '2022-08-06 13:57:46', 'PharmaTech', 0.0);
    INSERT INTO `tb_AccordType` (`id_accord`, `ie_accord`, `bln_active`, `dt_dateCreated`, `ds_accord`, `nr_percentage`)
    VALUES (2, 1, TRUE, TIMESTAMP '2022-08-06 13:57:46', 'Subway', 50.0);
    INSERT INTO `tb_AccordType` (`id_accord`, `ie_accord`, `bln_active`, `dt_dateCreated`, `ds_accord`, `nr_percentage`)
    VALUES (3, 2, TRUE, TIMESTAMP '2022-08-06 13:57:46', 'McDonald''s', 100.0);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (2, TRUE, 5.0, TIMESTAMP '2022-08-06 13:57:46', 'Car 1');
    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (3, TRUE, 5.5, TIMESTAMP '2022-08-06 13:57:46', 'Car 2');
    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (4, TRUE, 3.0, TIMESTAMP '2022-08-06 13:57:46', 'Moto 1');
    INSERT INTO `tb_VehicleType` (`id_vehicle`, `bln_active`, `vl_cost`, `dt_dateCreated`, `ds_vehicle`)
    VALUES (5, TRUE, 3.5, TIMESTAMP '2022-08-06 13:57:46', 'Moto 2');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20220806165747_Initial') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20220806165747_Initial', '6.0.7');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

