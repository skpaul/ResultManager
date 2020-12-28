-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 28, 2020 at 02:29 PM
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
-- Table structure for table `districts`
--

CREATE TABLE `districts` (
  `id` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `division` varchar(200) NOT NULL,
  `percentage` double(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `districts`
--

INSERT INTO `districts` (`id`, `name`, `division`, `percentage`) VALUES
(1, 'Barguna', 'Barishal', 0.62),
(2, 'Barishal', 'Barishal', 1.61),
(3, 'Bhola', 'Barishal', 1.23),
(4, 'Jhalokhathi', 'Barishal', 0.47),
(5, 'Patuakhali', 'Barishal', 1.07),
(6, 'Pirojpur', 'Barishal', 0.77),
(7, 'Bandarban', 'Chattogram', 0.27),
(8, 'Brahamanbaria', 'Chattogram', 1.97),
(9, 'Chandpur', 'Chattogram', 1.68),
(10, 'Chattogram', 'Chattogram', 5.29),
(11, 'Cox`s Bazar', 'Chattogram', 1.59),
(12, 'Cumilla', 'Chattogram', 3.74),
(13, 'Feni', 'Chattogram', 1.00),
(14, 'Khagrachhari', 'Chattogram', 0.43),
(15, 'Luxmipur', 'Chattogram', 1.20),
(16, 'Noakhali', 'Chattogram', 2.16),
(17, 'Rangamati', 'Chattogram', 0.41),
(18, 'Dhaka', 'Dhaka', 8.36),
(19, 'Faridpur', 'Dhaka', 1.33),
(20, 'Gazipur', 'Dhaka', 2.36),
(21, 'Gopalganj', 'Dhaka', 0.81),
(22, 'Jamalpur', 'Mymensingh', 1.59),
(23, 'Kishorganj', 'Dhaka', 2.02),
(24, 'Madaripur', 'Dhaka', 0.81),
(25, 'Manikganj', 'Dhaka', 0.97),
(26, 'Munshiganj', 'Dhaka', 1.00),
(27, 'Mymensingh', 'Mymensingh', 3.55),
(28, 'Narayanganj', 'Dhaka', 2.05),
(29, 'Narsingdi', 'Dhaka', 1.54),
(30, 'Netrokona', 'Mymensingh', 1.55),
(31, 'Rajbari', 'Dhaka', 0.73),
(32, 'Shariatpur', 'Dhaka', 0.80),
(33, 'Sherpur', 'Mymensingh', 0.94),
(34, 'Tangail', 'Dhaka', 2.50),
(35, 'Bagerhat', 'Khulna', 1.02),
(36, 'Chuadanga', 'Khulna', 0.78),
(37, 'Jashore', 'Khulna', 1.92),
(38, 'Jhenaidah', 'Khulna', 1.23),
(39, 'Khulna', 'Khulna', 1.61),
(40, 'Kushtia', 'Khulna', 1.35),
(41, 'Magura', 'Khulna', 0.64),
(42, 'Meharpur', 'Khulna', 0.45),
(43, 'Narail', 'Khulna', 0.50),
(44, 'Satkhira', 'Khulna', 1.38),
(45, 'Bogra', 'Rajshahi', 2.36),
(46, 'Chapai Nawabganj', 'Rajshahi', 1.14),
(47, 'Jaipurhat', 'Rajshahi', 0.63),
(48, 'Naogaon', 'Rajshahi', 1.81),
(49, 'Natore', 'Rajshahi', 1.18),
(50, 'Pabna', 'Rajshahi', 1.75),
(51, 'Rajshahi', 'Rajshahi', 1.80),
(52, 'Sirajganj', 'Rajshahi', 2.15),
(53, 'Dinajpur', 'Rangpur', 2.08),
(54, 'Gaibanda', 'Rangpur', 1.65),
(55, 'Kurigram', 'Rangpur', 1.44),
(56, 'Lalmonirhat', 'Rangpur', 0.87),
(57, 'Nilphamari', 'Rangpur', 1.27),
(58, 'Panchagarh', 'Rangpur', 0.69),
(59, 'Rangpur', 'Rangpur', 2.00),
(60, 'Thakurgaon', 'Rangpur', 0.97),
(61, 'Habiganj', 'Sylhet', 1.45),
(62, 'Mouluvibazar', 'Sylhet', 1.33),
(63, 'Sunamganj', 'Sylhet', 1.71),
(64, 'Sylhet', 'Sylhet', 2.38);

-- --------------------------------------------------------

--
-- Table structure for table `divisions`
--

CREATE TABLE `divisions` (
  `id` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `percentage` double(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `divisions`
--

INSERT INTO `divisions` (`id`, `name`, `percentage`) VALUES
(1, 'Barishal', 5.78),
(2, 'Chattogram', 19.79),
(3, 'Dhaka', 25.29),
(4, 'Khulna', 10.89),
(5, 'Rajshahi', 12.83),
(6, 'Rangpur', 10.96),
(7, 'Sylhet', 6.88),
(8, 'Mymensingh', 7.63);

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE `posts` (
  `postId` int(11) NOT NULL,
  `postName` varchar(200) NOT NULL,
  `vacancies` int(11) NOT NULL,
  `totalQuotaPercentage` double(5,2) NOT NULL,
  `totalQuotaQuantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`postId`, `postName`, `vacancies`, `totalQuotaPercentage`, `totalQuotaQuantity`) VALUES
(1, 'Auditor', 10, 0.00, 0),
(2, 'Cash Sarker', 1, 0.00, 0),
(3, 'Driver', 2, 0.00, 0),
(4, 'Office Assistant cum Computer Typist', 8, 0.00, 0),
(5, 'Office Sohayok', 9, 0.00, 0),
(6, 'Photocopy Operator', 1, 0.00, 0),
(7, 'Record Keeper', 3, 0.00, 0),
(8, 'Security Guard', 1, 0.00, 0),
(9, 'Stenographer cum Computer Operator', 3, 0.00, 0);

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
(4, 1, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10),
(6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10),
(7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10),
(8, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10),
(9, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10),
(10, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10),
(11, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10),
(12, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10);

-- --------------------------------------------------------

--
-- Table structure for table `post_quota_distribution`
--

CREATE TABLE `post_quota_distribution` (
  `id` int(11) NOT NULL,
  `postName` varchar(200) NOT NULL,
  `quotaName` varchar(200) NOT NULL,
  `decimalQuantity` float(5,2) NOT NULL,
  `roundedQuantity` float(5,2) NOT NULL,
  `applicantFound` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `quotas`
--

CREATE TABLE `quotas` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `percentage` float(5,2) NOT NULL,
  `priority` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `quotas`
--

INSERT INTO `quotas` (`id`, `name`, `percentage`, `priority`) VALUES
(1, 'Freedom Fighter', 30.00, 1),
(2, 'Ansar-VDP', 10.00, 2),
(3, 'Physically Handicapped', 10.00, 3),
(4, 'Female', 15.00, 4),
(5, 'Tribal', 5.00, 5);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `applicants`
--
ALTER TABLE `applicants`
  ADD PRIMARY KEY (`applicantId`);

--
-- Indexes for table `districts`
--
ALTER TABLE `districts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `divisions`
--
ALTER TABLE `divisions`
  ADD PRIMARY KEY (`id`);

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
-- Indexes for table `post_quota_distribution`
--
ALTER TABLE `post_quota_distribution`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `quotas`
--
ALTER TABLE `quotas`
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
-- AUTO_INCREMENT for table `divisions`
--
ALTER TABLE `divisions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `posts`
--
ALTER TABLE `posts`
  MODIFY `postId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `post_calculation`
--
ALTER TABLE `post_calculation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `post_quota_distribution`
--
ALTER TABLE `post_quota_distribution`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `quotas`
--
ALTER TABLE `quotas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
