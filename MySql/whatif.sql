CREATE DATABASE  IF NOT EXISTS `whatif` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `whatif`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: whatif
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `idaccount` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `balance` decimal(10,2) DEFAULT NULL,
  `deposit` decimal(10,2) DEFAULT NULL,
  `sixmonthtotal` decimal(10,2) DEFAULT NULL,
  `annualtotal` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idaccount`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `models`
--

DROP TABLE IF EXISTS `models`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `models` (
  `idmodels` int(11) NOT NULL AUTO_INCREMENT,
  `created` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `mon1` decimal(10,3) DEFAULT NULL,
  `mon2` decimal(10,3) DEFAULT NULL,
  `mon3` decimal(10,3) DEFAULT NULL,
  `mon4` decimal(10,3) DEFAULT NULL,
  `mon5` decimal(10,3) DEFAULT NULL,
  `mon6` decimal(10,3) DEFAULT NULL,
  `mon7` decimal(10,3) DEFAULT NULL,
  `mon8` decimal(10,3) DEFAULT NULL,
  `mon9` decimal(10,3) DEFAULT NULL,
  `mon10` decimal(10,3) DEFAULT NULL,
  `mon11` decimal(10,3) DEFAULT NULL,
  `mon12` decimal(10,3) DEFAULT NULL,
  `balance` decimal(10,3) DEFAULT NULL,
  `newbalance` decimal(10,3) DEFAULT NULL,
  `deposit` decimal(10,3) DEFAULT NULL,
  PRIMARY KEY (`idmodels`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `models`
--

LOCK TABLES `models` WRITE;
/*!40000 ALTER TABLE `models` DISABLE KEYS */;
/*!40000 ALTER TABLE `models` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `monthly`
--

DROP TABLE IF EXISTS `monthly`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `monthly` (
  `idmonthly` int(11) NOT NULL AUTO_INCREMENT,
  `month` varchar(45) NOT NULL,
  `interest` decimal(10,3) DEFAULT NULL,
  PRIMARY KEY (`idmonthly`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `monthly`
--

LOCK TABLES `monthly` WRITE;
/*!40000 ALTER TABLE `monthly` DISABLE KEYS */;
INSERT INTO `monthly` VALUES (2,'January',0.010),(4,'February',0.013),(5,'March',0.011),(6,'April',0.012),(7,'May',0.011),(8,'June',0.013),(9,'July',0.017),(10,'August',0.015),(11,'September',0.016),(12,'October',0.020),(13,'November',0.018),(14,'December',0.014);
/*!40000 ALTER TABLE `monthly` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'whatif'
--

--
-- Dumping routines for database 'whatif'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-30 10:22:57
