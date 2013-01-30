/*
MySQL Data Transfer
Source Host: localhost
Source Database: vod
Target Host: localhost
Target Database: vod
Date: 2012/11/19 20:51:41
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for bookinfo
-- ----------------------------
CREATE TABLE `bookinfo` (
  `BookID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `ChannelID` int(11) NOT NULL,
  PRIMARY KEY (`BookID`),
  KEY `BookandUser` (`UserID`),
  KEY `BookandChannel` (`ChannelID`),
  CONSTRAINT `BookandChannel` FOREIGN KEY (`ChannelID`) REFERENCES `channelinfo` (`ChannelID`),
  CONSTRAINT `BookandUser` FOREIGN KEY (`UserID`) REFERENCES `userinfo` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for channelinfo
-- ----------------------------
CREATE TABLE `channelinfo` (
  `ChannelID` int(11) NOT NULL AUTO_INCREMENT,
  `ChannelName` varchar(30) NOT NULL,
  `ChannelMMS` varchar(200) NOT NULL,
  PRIMARY KEY (`ChannelID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dvinfo
-- ----------------------------
CREATE TABLE `dvinfo` (
  `DVID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `DVName` varchar(50) NOT NULL,
  `DVUrl` varchar(200) NOT NULL,
  `DVLength` double NOT NULL,
  `UploadTime` datetime NOT NULL,
  PRIMARY KEY (`DVID`),
  KEY `DVandUser` (`UserID`),
  CONSTRAINT `DVandUser` FOREIGN KEY (`UserID`) REFERENCES `userinfo` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for programinfo
-- ----------------------------
CREATE TABLE `programinfo` (
  `ProgramID` int(11) NOT NULL AUTO_INCREMENT,
  `ProgramName` varchar(50) NOT NULL,
  `ProgramUrl` varchar(200) DEFAULT NULL,
  `ProgramDescribe` varchar(500) DEFAULT NULL,
  `ChannelID` int(11) NOT NULL,
  `BeginTime` datetime DEFAULT NULL,
  `EndTime` datetime NOT NULL,
  PRIMARY KEY (`ProgramID`),
  KEY `ProgarmandChannel` (`ChannelID`),
  CONSTRAINT `ProgarmandChannel` FOREIGN KEY (`ChannelID`) REFERENCES `channelinfo` (`ChannelID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for userinfo
-- ----------------------------
CREATE TABLE `userinfo` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Type` int(11) NOT NULL DEFAULT '0' COMMENT '用户类型，1代表用户，2代表管理员',
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `channelinfo` VALUES ('1', 'CCTV13（央视新闻）', 'mms://221.0.188.40/39');
INSERT INTO `programinfo` VALUES ('1', '中国税收', 'video/中国税收.mp4', '中国税收', '1', '2012-02-08 10:02:22', '2012-02-08 10:02:12');
INSERT INTO `programinfo` VALUES ('5', 'Sequence 01_Compress', 'video/Sequence 01_Compress.MP4', 'Sequence 01_Compress.MP4', '1', '2012-02-08 10:02:22', '2012-02-08 10:02:22');
INSERT INTO `userinfo` VALUES ('1', '1', '06-D4-96-32-C9-DC-9B-CB-62-AE-AE-F9-96-12-BA-6B', '1@2.com', '1');
INSERT INTO `userinfo` VALUES ('2', '2', '6D-5A-BA-BB-65-E9-FF-21-4B-73-E8-91-B4-AF-E6-E8', '2@2.com', '2');
INSERT INTO `userinfo` VALUES ('3', '3', '30-9F-C7-D3-BC-53-BB-63-AC-42-E3-59-26-0A-C7-40', '3@3.com', '1');
