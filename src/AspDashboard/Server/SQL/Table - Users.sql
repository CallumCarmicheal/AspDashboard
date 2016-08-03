-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Author: Callum Carmicheal
-- Host: localhost
-- Generation Time: Aug 03, 2016 at 05:22 PM
-- Server version: 	5.6.13
-- PHP Version: 	5.4.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `AspDashboard`
--
-- --------------------------------------------------------

--
-- Table structure for table `users`
--
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(255) NOT NULL AUTO_INCREMENT COMMENT 'User ID',
  `cuid` varchar(255) NOT NULL COMMENT 'User''s Personal ID',
  `level` varchar(255) NOT NULL COMMENT 'Global Auth Level',
  `state` int(3) NOT NULL COMMENT 'User State, Disabled = 0, Enabled = 1, Banned = 2',
  `username` varchar(255) NOT NULL COMMENT 'Username',
  `email` varchar(255) NOT NULL COMMENT 'Users Email',
  `password` varchar(100) NOT NULL COMMENT 'BCrypt Password',
  `datecreated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'The time the user''s account was created',
  `lastaccess` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'The last time the user was online',
  `lastupdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'The date of last alteration to the user',
  PRIMARY KEY (`id`),
  UNIQUE KEY `cuid` (`cuid`,`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='The table used to store all Auth Users' AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
