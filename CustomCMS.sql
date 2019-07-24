-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: customcms
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblcategory`
--

DROP TABLE IF EXISTS `tblcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblcategory` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(200) DEFAULT NULL,
  `CategoryImage` varchar(200) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcategory`
--

LOCK TABLES `tblcategory` WRITE;
/*!40000 ALTER TABLE `tblcategory` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblgallery`
--

DROP TABLE IF EXISTS `tblgallery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblgallery` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryId` int(11) DEFAULT NULL,
  `Image` varchar(200) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblgallery`
--

LOCK TABLES `tblgallery` WRITE;
/*!40000 ALTER TABLE `tblgallery` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblgallery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllogin`
--

DROP TABLE IF EXISTS `tbllogin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbllogin` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` varchar(250) DEFAULT NULL,
  `Password` varchar(250) DEFAULT NULL,
  `LastLogin` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllogin`
--

LOCK TABLES `tbllogin` WRITE;
/*!40000 ALTER TABLE `tbllogin` DISABLE KEYS */;
INSERT INTO `tbllogin` VALUES (1,'admin@gmail.com','fc0iUkg331qk3V8HY6MWvQ==',NULL);
/*!40000 ALTER TABLE `tbllogin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblservice`
--

DROP TABLE IF EXISTS `tblservice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblservice` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(300) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Image` varchar(200) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblservice`
--

LOCK TABLES `tblservice` WRITE;
/*!40000 ALTER TABLE `tblservice` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblservice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblslider`
--

DROP TABLE IF EXISTS `tblslider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblslider` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(500) DEFAULT NULL,
  `Image` varchar(500) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblslider`
--

LOCK TABLES `tblslider` WRITE;
/*!40000 ALTER TABLE `tblslider` DISABLE KEYS */;
INSERT INTO `tblslider` VALUES (2,'Sachchi Prajapati','1960_chevrolet_corvette_convertible-wallpaper-1280x768.jpg',1,'2019-03-18 00:00:00',1,'2019-03-22 17:29:30'),(3,'Test','aston_martin_db_5-wallpaper-1280x768.jpg',1,'2019-03-18 00:00:00',1,'2019-03-18 00:00:00');
/*!40000 ALTER TABLE `tblslider` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsocialmediadetail`
--

DROP TABLE IF EXISTS `tblsocialmediadetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblsocialmediadetail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SMID` int(11) DEFAULT NULL,
  `SocialURL` varchar(200) DEFAULT NULL,
  `SocialStatus` bit(1) DEFAULT b'0',
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsocialmediadetail`
--

LOCK TABLES `tblsocialmediadetail` WRITE;
/*!40000 ALTER TABLE `tblsocialmediadetail` DISABLE KEYS */;
INSERT INTO `tblsocialmediadetail` VALUES (1,2,'http://google.co.in/',_binary '',1,'2019-03-19 17:31:30',1,'2019-03-22 15:50:55'),(2,5,'http://google.co.in/',_binary '',1,'2019-03-19 17:31:42',1,'2019-03-19 18:13:47');
/*!40000 ALTER TABLE `tblsocialmediadetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsocialmediamaster`
--

DROP TABLE IF EXISTS `tblsocialmediamaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblsocialmediamaster` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SocialMediaName` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsocialmediamaster`
--

LOCK TABLES `tblsocialmediamaster` WRITE;
/*!40000 ALTER TABLE `tblsocialmediamaster` DISABLE KEYS */;
INSERT INTO `tblsocialmediamaster` VALUES (1,'Twitter'),(2,'Facebook'),(3,'Youtube'),(4,'Linkedin'),(5,'Google'),(6,'Skype'),(7,'Dribble'),(8,'Rss'),(9,'Instragram');
/*!40000 ALTER TABLE `tblsocialmediamaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltestimonial`
--

DROP TABLE IF EXISTS `tbltestimonial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbltestimonial` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Designation` varchar(45) DEFAULT NULL,
  `Comments` varchar(45) DEFAULT NULL,
  `Image` varchar(45) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltestimonial`
--

LOCK TABLES `tbltestimonial` WRITE;
/*!40000 ALTER TABLE `tbltestimonial` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbltestimonial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'customcms'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login`(LEmail varchar(250),
							LPassword varchar(250))
BEGIN
	select * from tbllogin where Email=LEmail and Password=LPassword ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_slider` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_slider`( Mode varchar(20),
	  Title varchar(500)
      ,Image varchar(500)
      ,CreatedBy int
      ,UpdatedBy int , SId int)
BEGIN
	-- SELECT
    IF Mode = "SELECT" THEN
        SELECT * FROM tblslider;
     END IF;
 
    -- INSERT
    IF Mode = "INSERT" THEN
        INSERT INTO tblslider(Title, Image,CreatedBy,CreatedDate)
        VALUES (Title, Image,CreatedBy,NOW());
    END IF;
 
    -- UPDATE
    IF Mode = "UPDATE" THEN
        UPDATE tblslider
        SET Title = Title, Image = Image , UpdatedBy=UpdatedBy, UpdatedDate= NOW()
        WHERE Id = SId;
    END IF;
     
    -- DELETE
    IF Mode = "DELETE" THEN
        DELETE FROM tblslider WHERE Id = SId;
    END IF;
    
     -- SELECT BY ID
    IF Mode = "SELECTBYID" THEN
        SELECT * FROM tblslider WHERE Id = SId;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_socialmediadetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_socialmediadetail`(Mode varchar(20),
	  SocialURL varchar(200)
      ,SocialStatus bit
      ,CreatedBy int
      ,UpdatedBy int , SId int , SMID int)
BEGIN
	-- SELECT
    IF Mode = "SELECT" THEN
        -- SELECT * FROM tblsocialmediadetail;
        SELECT SMD.Id, SMD.SocialURL, SMD.SocialStatus,SMD.SMId, SMM.SocialMediaName FROM customcms.tblsocialmediadetail SMD 
        inner join customcms.tblsocialmediamaster SMM on SMD.SMID = SMM.Id;
     END IF;
 
    -- INSERT
    IF Mode = "INSERT" THEN
        INSERT INTO tblsocialmediadetail(SMID, SocialURL,SocialStatus,CreatedBy,CreatedDate)
        VALUES (SMID, SocialURL,SocialStatus,CreatedBy,NOW());
    END IF;
 
    -- UPDATE
    IF Mode = "UPDATE" THEN
        UPDATE tblsocialmediadetail
        SET SMID = SMID, SocialURL = SocialURL ,SocialStatus=SocialStatus, UpdatedBy=UpdatedBy, 
        UpdatedDate= NOW() WHERE Id = SId;
    END IF;
     
    -- DELETE
    IF Mode = "DELETE" THEN
        DELETE FROM tblsocialmediadetail WHERE Id = SId;
    END IF;
    
     -- SELECT BY ID
    IF Mode = "SELECTBYID" THEN
        SELECT * FROM tblsocialmediadetail WHERE Id = SId;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_socialmediamaster` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_socialmediamaster`()
BEGIN
	-- SELECT
	SELECT * FROM tblsocialmediamaster;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-31 14:43:09
