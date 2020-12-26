-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 26, 2020 at 08:02 PM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `result_manager`
--

-- --------------------------------------------------------

--
-- Table structure for table `applicants`
--

CREATE TABLE `applicants` (
  `applicantId` int(11) NOT NULL,
  `postId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dist_info`
--

CREATE TABLE `dist_info` (
  `sl` int(3) UNSIGNED ZEROFILL NOT NULL,
  `post_code` int(5) UNSIGNED DEFAULT 0,
  `post_name` varchar(100) NOT NULL,
  `dist_01` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_02` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_03` int(2) UNSIGNED ZEROFILL DEFAULT 00,
  `dist_04` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_05` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_06` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_07` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_08` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_09` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_10` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_11` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_12` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_13` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_14` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_15` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_16` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_17` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_18` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_19` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_20` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_21` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_22` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_23` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_24` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_25` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_26` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_27` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_28` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_29` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_30` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_31` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_32` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_33` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_34` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_35` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_36` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_37` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_38` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_39` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_40` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_41` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_42` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_43` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_44` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_45` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_46` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_47` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_48` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_49` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_50` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_51` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_52` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_53` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_54` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_55` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_56` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_57` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_58` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_59` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_60` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_61` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_62` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_63` int(2) UNSIGNED ZEROFILL DEFAULT NULL,
  `dist_64` int(2) UNSIGNED ZEROFILL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dist_info`
--

INSERT INTO `dist_info` (`sl`, `post_code`, `post_name`, `dist_01`, `dist_02`, `dist_03`, `dist_04`, `dist_05`, `dist_06`, `dist_07`, `dist_08`, `dist_09`, `dist_10`, `dist_11`, `dist_12`, `dist_13`, `dist_14`, `dist_15`, `dist_16`, `dist_17`, `dist_18`, `dist_19`, `dist_20`, `dist_21`, `dist_22`, `dist_23`, `dist_24`, `dist_25`, `dist_26`, `dist_27`, `dist_28`, `dist_29`, `dist_30`, `dist_31`, `dist_32`, `dist_33`, `dist_34`, `dist_35`, `dist_36`, `dist_37`, `dist_38`, `dist_39`, `dist_40`, `dist_41`, `dist_42`, `dist_43`, `dist_44`, `dist_45`, `dist_46`, `dist_47`, `dist_48`, `dist_49`, `dist_50`, `dist_51`, `dist_52`, `dist_53`, `dist_54`, `dist_55`, `dist_56`, `dist_57`, `dist_58`, `dist_59`, `dist_60`, `dist_61`, `dist_62`, `dist_63`, `dist_64`) VALUES
(001, 110, 'Auditor', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(002, 120, 'Stenographer cum Computer Operator', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(003, 130, 'Office Assistant cum Computer Typist', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(004, 140, 'Record Keeper', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(005, 150, 'Driver', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(006, 160, 'Photocopy Operator', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(007, 170, 'Cash Sarker', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(008, 180, 'Office Sohayok', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00),
(009, 190, 'Security Guard', 01, 15, 17, 18, 22, 26, 27, 28, 29, 30, 31, 32, 35, 39, 42, 48, 53, 57, 62, 63, 64, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00);

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE `posts` (
  `postId` int(11) NOT NULL,
  `postName` varchar(200) NOT NULL,
  `vacancies` int(11) NOT NULL,
  `districtQuota` int(11) NOT NULL,
  `femaleQuota` int(11) NOT NULL,
  `freedomFighterQuota` int(11) NOT NULL,
  `tribalQuota` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`postId`, `postName`, `vacancies`, `districtQuota`, `femaleQuota`, `freedomFighterQuota`, `tribalQuota`) VALUES
(1, 'asdf1212', 10, 3, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `post_calculation`
--

CREATE TABLE `post_calculation` (
  `id` int(11) NOT NULL,
  `postId` int(11) NOT NULL,
  `distQuantity` int(11) NOT NULL COMMENT 'declared by ministry',
  `distFound` int(11) NOT NULL COMMENT 'district quota claimed by applicants',
  `distTransferred` int(11) NOT NULL COMMENT 'if enough applicant not found, then transfer this quantity to general',
  `femaleQuantity` int(11) NOT NULL,
  `femaleFound` int(11) NOT NULL,
  `femaleTransferred` int(11) NOT NULL,
  `freedomFighterQuantity` int(11) NOT NULL,
  `freedomFighterFound` int(11) NOT NULL,
  `freedomFighterTransferred` int(11) NOT NULL,
  `tribalQuantity` int(11) NOT NULL,
  `tribalFound` int(11) NOT NULL,
  `tribalTransferred` int(11) NOT NULL,
  `generalQuota` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `post_calculation`
--

INSERT INTO `post_calculation` (`id`, `postId`, `distQuantity`, `distFound`, `distTransferred`, `femaleQuantity`, `femaleFound`, `femaleTransferred`, `freedomFighterQuantity`, `freedomFighterFound`, `freedomFighterTransferred`, `tribalQuantity`, `tribalFound`, `tribalTransferred`, `generalQuota`) VALUES
(1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(4, 1, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `applicants`
--
ALTER TABLE `applicants`
  ADD PRIMARY KEY (`applicantId`);

--
-- Indexes for table `dist_info`
--
ALTER TABLE `dist_info`
  ADD PRIMARY KEY (`sl`);

--
-- Indexes for table `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`postId`);

--
-- Indexes for table `post_calculation`
--
ALTER TABLE `post_calculation`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `applicants`
--
ALTER TABLE `applicants`
  MODIFY `applicantId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dist_info`
--
ALTER TABLE `dist_info`
  MODIFY `sl` int(3) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `posts`
--
ALTER TABLE `posts`
  MODIFY `postId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `post_calculation`
--
ALTER TABLE `post_calculation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
