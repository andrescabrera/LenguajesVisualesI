



-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'Vendedor'
-- 
-- ---

DROP TABLE IF EXISTS `Vendedor`;
		
CREATE TABLE `Vendedor` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `legajo` INTEGER NULL DEFAULT NULL,
  `nombre` VARCHAR(20) NULL DEFAULT NULL,
  `apellido` VARCHAR(20) NULL DEFAULT NULL,
  `direccion` VARCHAR(20) NULL DEFAULT NULL,
  `telefono` VARCHAR(20) NULL DEFAULT NULL,
  `comision` DECIMAL NULL DEFAULT NULL,
  `id_CargaHoraria` INTEGER NULL DEFAULT NULL,
  `inactivo` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'Operario'
-- 
-- ---

DROP TABLE IF EXISTS `Operario`;
		
CREATE TABLE `Operario` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `legajo` INTEGER NULL DEFAULT NULL,
  `nombre` VARCHAR(20) NULL DEFAULT NULL,
  `apellido` VARCHAR(20) NULL DEFAULT NULL,
  `direccion` VARCHAR(20) NULL DEFAULT NULL,
  `telefono` VARCHAR(20) NULL DEFAULT NULL,
  `id_CargaHoraria` INTEGER NULL DEFAULT NULL,
  `inactivo` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'Administrativo'
-- 
-- ---

DROP TABLE IF EXISTS `Administrativo`;
		
CREATE TABLE `Administrativo` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `legajo` INTEGER NULL DEFAULT NULL,
  `nombre` VARCHAR(20) NULL DEFAULT NULL,
  `apellido` VARCHAR(20) NULL DEFAULT NULL,
  `direccion` VARCHAR(20) NULL DEFAULT NULL,
  `telefono` VARCHAR(20) NULL DEFAULT NULL,
  `id_CargaHoraria` INTEGER NULL DEFAULT NULL,
  `inactivo` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'CargaHoraria'
-- 
-- ---

DROP TABLE IF EXISTS `CargaHoraria`;
		
CREATE TABLE `CargaHoraria` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `inactivo` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'Horario'
-- 
-- ---

DROP TABLE IF EXISTS `Horario`;
		
CREATE TABLE `Horario` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `id_CargaHoraria` INTEGER NULL DEFAULT NULL,
  `dia` INTEGER NULL DEFAULT NULL,
  `fechaDesde` DATETIME NULL DEFAULT NULL,
  `fechaHasta` DATETIME NULL DEFAULT NULL,
  `inactivo` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'Ausencia'
-- 
-- ---

DROP TABLE IF EXISTS `Ausencia`;
		
CREATE TABLE `Ausencia` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `motivo` VARCHAR(100) NULL DEFAULT NULL,
  `id_Vendedor` INTEGER NULL DEFAULT NULL,
  `id_Operario` INTEGER NULL DEFAULT NULL,
  `id_Administrativo` INTEGER NULL DEFAULT NULL,
  `fechaIngresoPautado` DATETIME NULL DEFAULT NULL,
  `fechaEgresoPautado` DATETIME NULL DEFAULT NULL,
  `id_ControlLaboral` INTEGER NULL DEFAULT NULL,
  `inactivo` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'Asistencia'
-- 
-- ---

DROP TABLE IF EXISTS `Asistencia`;
		
CREATE TABLE `Asistencia` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `id_Vendedor` INTEGER NULL DEFAULT NULL,
  `id_Operario` INTEGER NULL DEFAULT NULL,
  `id_Administrativo` INTEGER NULL DEFAULT NULL,
  `fechaDesde` DATETIME NULL DEFAULT NULL,
  `fechaHasta` DATETIME NULL DEFAULT NULL,
  `fechaIngresoPautado` DATETIME NULL DEFAULT NULL,
  `fechaEgresoPautado` DATETIME NULL DEFAULT NULL,
  `id_ControlLaboral` INTEGER NULL DEFAULT NULL,
  `inactivo` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
);

-- ---
-- Foreign Keys 
-- ---

ALTER TABLE `Vendedor` ADD FOREIGN KEY (id_CargaHoraria) REFERENCES `CargaHoraria` (`id`);
ALTER TABLE `Operario` ADD FOREIGN KEY (id_CargaHoraria) REFERENCES `CargaHoraria` (`id`);
ALTER TABLE `Administrativo` ADD FOREIGN KEY (id_CargaHoraria) REFERENCES `CargaHoraria` (`id`);
ALTER TABLE `Horario` ADD FOREIGN KEY (id_CargaHoraria) REFERENCES `CargaHoraria` (`id`);
ALTER TABLE `Ausencia` ADD FOREIGN KEY (id_Vendedor) REFERENCES `Vendedor` (`id`);
ALTER TABLE `Ausencia` ADD FOREIGN KEY (id_Operario) REFERENCES `Operario` (`id`);
ALTER TABLE `Ausencia` ADD FOREIGN KEY (id_Administrativo) REFERENCES `Administrativo` (`id`);
ALTER TABLE `Asistencia` ADD FOREIGN KEY (id_Vendedor) REFERENCES `Vendedor` (`id`);
ALTER TABLE `Asistencia` ADD FOREIGN KEY (id_Operario) REFERENCES `Operario` (`id`);
ALTER TABLE `Asistencia` ADD FOREIGN KEY (id_Administrativo) REFERENCES `Administrativo` (`id`);

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `Vendedor` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Operario` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Administrativo` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `CargaHoraria` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Horario` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Ausencia` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Asistencia` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `Vendedor` (`id`,`legajo`,`nombre`,`apellido`,`direccion`,`telefono`,`comision`,`id_CargaHoraria`,`inactivo`) VALUES
-- ('','','','','','','','','');
-- INSERT INTO `Operario` (`id`,`legajo`,`nombre`,`apellido`,`direccion`,`telefono`,`id_CargaHoraria`,`inactivo`) VALUES
-- ('','','','','','','','');
-- INSERT INTO `Administrativo` (`id`,`legajo`,`nombre`,`apellido`,`direccion`,`telefono`,`id_CargaHoraria`,`inactivo`) VALUES
-- ('','','','','','','','');
-- INSERT INTO `CargaHoraria` (`id`,`inactivo`) VALUES
-- ('','');
-- INSERT INTO `Horario` (`id`,`id_CargaHoraria`,`dia`,`fechaDesde`,`fechaHasta`,`inactivo`) VALUES
-- ('','','','','','');
-- INSERT INTO `Ausencia` (`id`,`motivo`,`id_Vendedor`,`id_Operario`,`id_Administrativo`,`fechaIngresoPautado`,`fechaEgresoPautado`,`id_ControlLaboral`,`inactivo`) VALUES
-- ('','','','','','','','','');
-- INSERT INTO `Asistencia` (`id`,`id_Vendedor`,`id_Operario`,`id_Administrativo`,`fechaDesde`,`fechaHasta`,`fechaIngresoPautado`,`fechaEgresoPautado`,`id_ControlLaboral`,`inactivo`) VALUES
-- ('','','','','','','','','','');

