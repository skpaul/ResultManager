-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 28, 2020 at 07:23 PM
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
  `id` int(3) NOT NULL,
  `userId` varchar(6) DEFAULT NULL,
  `roll` int(8) DEFAULT NULL,
  `postCode` int(3) DEFAULT NULL,
  `postName` varchar(200) DEFAULT NULL,
  `name` varchar(27) DEFAULT NULL,
  `dob` varchar(10) DEFAULT NULL,
  `sex` int(1) DEFAULT NULL,
  `religion` varchar(9) DEFAULT NULL,
  `ffq` varchar(30) DEFAULT NULL,
  `presentDistrict` varchar(200) DEFAULT NULL,
  `permanentDistrict` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `applicants`
--

INSERT INTO `applicants` (`id`, `userId`, `roll`, `postCode`, `postName`, `name`, `dob`, `sex`, `religion`, `ffq`, `presentDistrict`, `permanentDistrict`) VALUES
(1, '4M4GRL', 15000017, 150, 'Driver', 'MD. SHOYAN HOSSAIN', '4/23/1997', 1, 'Islam ', 'Non Quota', 'Chuadanga', 'Chuadanga'),
(2, '4Y6A3T', 15000018, 150, 'Driver', 'MD. RAKIBUL HASAN', '3/2/1994', 1, 'Islam ', 'Ansar-VDP', 'Gazipur', 'Gazipur'),
(3, '58N94D', 15000019, 150, 'Driver', 'MD. RAKIBUL MIAH ', '12/31/1991', 1, 'Islam ', 'Non Quota', 'Faridpur', 'Faridpur'),
(4, '7AE7U2', 15000023, 150, 'Driver', 'MD. SHAHJAHAN', '11/25/1991', 1, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(5, '7FLCHD', 15000024, 150, 'Driver', 'SHEIKH MD ABDUL HAMID RAKIB', '7/10/1991', 1, 'Islam ', 'Non Quota', 'Brahamanbaria', 'Brahamanbaria'),
(6, '7HTD8R', 15000026, 150, 'Driver', 'ABDUR RAHMAN', '3/1/1993', 1, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(7, '9XHN6H', 15000039, 150, 'Driver', 'MOHAMMAD YEASIN', '1/1/1992', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Cumilla'),
(8, 'BSVBV3', 15000046, 150, 'Driver', 'MD. MAHABUR', '3/12/1987', 1, 'Islam ', 'Child of Freedom Fighter', 'Gopalganj', 'Gopalganj'),
(9, 'DJJ6WV', 15000053, 150, 'Driver', 'MD SOHAG HOSSAIN', '9/20/1997', 1, 'Islam ', 'Non Quota', 'Faridpur', 'Faridpur'),
(10, 'ESMA28', 15000055, 150, 'Driver', 'MD. HUMAYUN KABIR ', '1/1/1993', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Jamalpur'),
(11, 'FTP421', 15000062, 150, 'Driver', 'MD. AL AMIN ISLAM', '12/10/1996', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(12, 'GHQV73', 15000066, 150, 'Driver', 'SUKUR ALI', '7/2/1992', 1, 'Islam ', 'Ansar-VDP', 'Gopalganj', 'Gopalganj'),
(13, 'JB6U8D', 15000069, 150, 'Driver', 'SAMIR BISWAS', '10/20/1989', 1, 'Hinduism ', 'Non Quota', 'Khulna', 'Khulna'),
(14, 'KCXSXM', 15000072, 150, 'Driver', 'JAMAL UDDIN', '1/1/1994', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(15, 'LPU9WE', 15000075, 150, 'Driver', 'MD. DELOWAR HOSAIN', '1/1/1993', 1, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(16, 'N8BNHX', 15000080, 150, 'Driver', 'RANA MOLLA', '5/27/1997', 1, 'Islam ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(17, 'NBUHEW', 15000081, 150, 'Driver', 'MD.MEHEDI HASAN', '3/13/1992', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(18, 'PLAGAW', 15000084, 150, 'Driver', 'SHEIKH KHAIRUL ISLAM', '12/10/1994', 1, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(19, 'PULMBY', 15000086, 150, 'Driver', 'MOHAMMAD SOHEL RANA', '12/5/1990', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(20, 'RMHFCF', 15000092, 150, 'Driver', 'MD. AKTHERUZZAMAN KHAN', '11/23/1994', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(21, 'SVD5XN', 15000093, 150, 'Driver', 'MOFIZUL HOQUE', '5/14/1990', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Jamalpur'),
(22, 'V5S6NJ', 15000101, 150, 'Driver', 'MD AKTARUL MIAH', '1/29/1991', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(23, 'VYULUE', 15000107, 150, 'Driver', 'MD. UNUS ALI', '12/27/1992', 1, 'Islam ', 'Non Quota', 'Magura', 'Magura'),
(24, '3DS1SC', 16000004, 160, 'Photocopy Operator', 'MD. ASIM MIA', '6/10/1989', 1, 'Islam ', 'Physically Handicapped', 'Manikganj', 'Manikganj'),
(25, 'V64N5W', 16000058, 160, 'Photocopy Operator', 'MD. NURUNNABI ISLAM', '11/17/1992', 1, 'Islam ', 'Non Quota', 'Nilphamari', 'Nilphamari'),
(26, 'XMY5YC', 16000070, 160, 'Photocopy Operator', 'SAJIBUL ALAM', '1/30/1994', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(27, '26XU3H', 17000009, 170, 'Cash Sarker', 'MD. MEHEDI HASAN', '1/23/1990', 1, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(28, '27ARAH', 17000010, 170, 'Cash Sarker', 'MEHEDY HASAN', '12/15/1989', 1, 'Islam ', 'Non Quota', 'Gazipur', 'Faridpur'),
(29, '5GDGN7', 17000035, 170, 'Cash Sarker', 'RAJIB CHANDRA RAY', '6/2/1989', 1, 'Hinduism ', 'Non Quota', 'Noakhali', 'Noakhali'),
(30, 'M8AWKN', 17000130, 170, 'Cash Sarker', 'MD. ABU YOUSUF', '10/11/1997', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(31, 'P97327', 17000152, 170, 'Cash Sarker', 'PIJUSH KUMAR DEV', '10/28/1990', 1, 'Hinduism ', 'Non Quota', 'Dinajpur', 'Dinajpur'),
(32, 'PSMQCX', 17000154, 170, 'Cash Sarker', 'MD.ABDUR RAHAMAN', '1/1/1992', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(33, 'R887F7', 17000161, 170, 'Cash Sarker', 'MD. TITU BISWAS', '12/25/1991', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(34, '1EP8AT', 18000055, 180, 'Office Sohayok', 'MD ABDUR RAZZAK', '1/1/1991', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Jamalpur'),
(35, '23BEE6', 18000132, 180, 'Office Sohayok', 'KABIR HASHAN', '1/31/1995', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Dhaka'),
(36, '2LFP5D', 18000192, 180, 'Office Sohayok', 'UTTAM KUMAR SUTRADHAR', '12/24/1991', 1, 'Hinduism ', 'Non Quota', 'Bogra', 'Bogra'),
(37, '5XHXUT', 18000551, 180, 'Office Sohayok', 'MD.SHOHAG MOSTOFA', '10/10/1990', 1, 'Islam ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(38, '636JQX', 18000562, 180, 'Office Sohayok', 'MD. SUMON MIA', '8/29/1994', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(39, '66TJX4', 18000572, 180, 'Office Sohayok', 'MD.MASUD REZA', '10/13/1996', 1, 'Islam ', 'Non Quota', 'Thakurgaon', 'Thakurgaon'),
(40, '6V31F9', 18000659, 180, 'Office Sohayok', 'MD. TAIZUL ISLAM', '1/3/1990', 1, 'Islam ', 'Non Quota', 'Natore', 'Natore'),
(41, '6VRD7M', 18000661, 180, 'Office Sohayok', 'MST. SHAHNAJ PARVIN', '1/1/1990', 2, 'Islam ', 'Non Quota', 'Pabna', 'Pabna'),
(42, '8AQ9XX', 18000830, 180, 'Office Sohayok', 'ROBIN', '10/20/1993', 1, 'Islam ', 'Ansar-VDP', 'Rajbari', 'Rajbari'),
(43, '8XFHRY', 18000923, 180, 'Office Sohayok', 'BAPPY PAUL', '1/1/1994', 1, 'Hinduism ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(44, '953JS7', 18000950, 180, 'Office Sohayok', 'SHUHADA AFRIN', '5/26/1992', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Faridpur'),
(45, '9G2KDL', 18000986, 180, 'Office Sohayok', 'JANNATUL BUSHRA MALEK', '5/5/1990', 2, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(46, 'A6BD1Q', 18001068, 180, 'Office Sohayok', 'MD.ABDUL MALEK', '1/3/1994', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Kurigram'),
(47, 'AX71RC', 18001156, 180, 'Office Sohayok', 'MD. ANSARUZZAMAN', '11/22/1991', 1, 'Islam ', 'Ansar-VDP', 'Chapai Nawabganj', 'Chapai Nawabganj'),
(48, 'BUWVSQ', 18001263, 180, 'Office Sohayok', 'RANJAN KANTI ROY', '3/1/1994', 1, 'Hinduism ', 'Non Quota', 'Cumilla', 'Cumilla'),
(49, 'BZYFLJ', 18001280, 180, 'Office Sohayok', 'SHYAMAL KUMAR DEVNATH ', '1/20/1990', 1, 'Hinduism ', 'Non Quota', 'Satkhira', 'Satkhira'),
(50, 'CR6FEB', 18001373, 180, 'Office Sohayok', 'LITON KHAN', '12/31/1991', 1, 'Islam ', 'Ansar-VDP', 'Tangail', 'Tangail'),
(51, 'DJHYVQ', 18001479, 180, 'Office Sohayok', 'MD.SHAHINUR RAHMAN', '2/1/1993', 1, 'Islam ', 'Non Quota', 'Chuadanga', 'Chuadanga'),
(52, 'DRZASW', 18001505, 180, 'Office Sohayok', 'MD NABIR HOSSAIN ', '10/1/1989', 1, 'Islam ', 'Ansar-VDP', 'Chandpur', 'Chandpur'),
(53, 'ENWHGP', 18001609, 180, 'Office Sohayok', 'SHODON CHANDRA DAS', '4/16/1989', 1, 'Hinduism ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(54, 'EUXMWZ', 18001628, 180, 'Office Sohayok', 'ANAMUL HOQ', '10/12/1990', 1, 'Islam ', 'Ansar-VDP', 'Netrokona', 'Netrokona'),
(55, 'GEEVYD', 18001801, 180, 'Office Sohayok', 'MD.ANWAR HOSSAIN', '12/15/1994', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(56, 'JSKFC9', 18002069, 180, 'Office Sohayok', 'MD. ANAMUL HAQUE', '10/23/1989', 1, 'Islam ', 'Non Quota', 'Bogra', 'Bogra'),
(57, 'JZ9UGP', 18002092, 180, 'Office Sohayok', 'MD. SOHRAB HOSSAIN', '12/12/1996', 1, 'Islam ', 'Child of Freedom Fighter', 'Satkhira', 'Satkhira'),
(58, 'K3DXX5', 18002098, 180, 'Office Sohayok', 'MANIR HOSEN', '11/30/1994', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(59, 'KZETVC', 18002197, 180, 'Office Sohayok', 'MD. ABDUR RASHID', '2/5/1990', 1, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(60, 'L6DA9E', 18002220, 180, 'Office Sohayok', 'FOYAZ AHMED', '8/10/1992', 1, 'Islam ', 'Non Quota', 'Sylhet', 'Sylhet'),
(61, 'M3YDVL', 18002317, 180, 'Office Sohayok', 'CHIRANJIT MALLICK', '10/7/1991', 1, 'Hinduism ', 'Ansar-VDP', 'Khulna', 'Khulna'),
(62, 'NMR91Y', 18002477, 180, 'Office Sohayok', 'MD. TAUFIQ AHMED', '6/6/1989', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(63, 'NZ48R8', 18002519, 180, 'Office Sohayok', 'RAKIBUL ISLAM MOKAMI ', '1/1/1992', 1, 'Islam ', 'Non Quota', 'Gazipur', 'Gazipur'),
(64, 'QGUFMF', 18002684, 180, 'Office Sohayok', 'TANBIR SIDDIKY RAKIB', '12/17/1995', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(65, 'QJXZG4', 18002693, 180, 'Office Sohayok', 'MD. ROBIUL ISLAM', '3/1/1991', 1, 'Islam ', 'Child of Freedom Fighter', 'Thakurgaon', 'Thakurgaon'),
(66, 'S6FUJP', 18002881, 180, 'Office Sohayok', 'SADEKUR RAHMAN', '2/15/1997', 1, 'Islam ', 'Physically Handicapped', 'Gaibanda', 'Gaibanda'),
(67, 'SF2V32', 18002916, 180, 'Office Sohayok', 'MD. ANISUR RAHMAN', '3/3/1992', 1, 'Islam ', 'Non Quota', 'Cumilla', 'Cumilla'),
(68, 'SKYUH2', 18002932, 180, 'Office Sohayok', 'MD.EASHIR ARAFAT', '2/4/1991', 1, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(69, 'TK546H', 18003051, 180, 'Office Sohayok', 'MD. HISAB UDDIN', '1/1/1991', 1, 'Islam ', 'Non Quota', 'Thakurgaon', 'Thakurgaon'),
(70, 'UEV62Q', 18003167, 180, 'Office Sohayok', 'MADON KUMAR BISWAS', '12/31/1998', 1, 'Hinduism ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(71, 'UKE4CS', 18003183, 180, 'Office Sohayok', 'MD.AL AMIN', '7/23/1991', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(72, 'VNN4HE', 18003306, 180, 'Office Sohayok', 'MD.MOZAHIDHUL ALAM', '10/30/1993', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(73, 'VQZM6Q', 18003314, 180, 'Office Sohayok', 'JASIM KAZI', '1/17/1996', 1, 'Islam ', 'Non Quota', 'Faridpur', 'Faridpur'),
(74, 'W9L21Z', 18003380, 180, 'Office Sohayok', 'MD. SAHINUR ISLAM', '1/10/1990', 1, 'Islam ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(75, 'Y1DHGS', 18003560, 180, 'Office Sohayok', 'RASHIDUL ISLAM', '1/3/1999', 1, 'Islam ', 'Non Quota', 'Dinajpur', 'Dinajpur'),
(76, 'YFHRAF', 18003607, 180, 'Office Sohayok', 'MD. NURUL AMIN', '3/10/1988', 1, 'Islam ', 'Physically Handicapped', 'Mymensingh', 'Mymensingh'),
(77, 'ZG34S8', 18003736, 180, 'Office Sohayok', 'BISWAJIT BISWAS', '6/15/1991', 1, 'Hinduism ', 'Non Quota', 'Dhaka', 'Dhaka'),
(78, 'ZG6Z9M', 18003737, 180, 'Office Sohayok', 'NARAYAN CHANDRO BISWAS', '12/11/1991', 1, 'Hinduism ', 'Non Quota', 'Khulna', 'Khulna'),
(79, 'ZLVW3G', 18003756, 180, 'Office Sohayok', 'AKKAS ALI', '1/1/1991', 1, 'Islam ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(80, 'ZVVM1V', 18003790, 180, 'Office Sohayok', 'MD. ARIFUL ISLAM', '2/2/1999', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(81, '2GH3NN', 19000003, 190, 'Security Guard', 'ZAHIDUL ', '8/5/1998', 1, 'Islam ', 'Grand Child of Freedom Fighter', 'Jamalpur', 'Jamalpur'),
(82, '9GXY5V', 19000015, 190, 'Security Guard', 'MD. GOLAM MOSTOFA', '10/15/1996', 1, 'Islam ', 'Non Quota', 'Lalmonirhat', 'Lalmonirhat'),
(83, 'R6EAL6', 19000022, 190, 'Security Guard', 'MOHAMMAD SANOWER HOSSAIN', '8/8/1987', 1, 'Islam ', 'Child of Freedom Fighter', 'Narayanganj', 'Narayanganj'),
(84, 'Y5SE57', 11001291, 110, 'Auditor', 'NUR MOHAMMAD', '4/15/1984', 1, 'Islam ', 'Non Quota', 'Jaipurhat', 'Jaipurhat'),
(85, 'XZ35PT', 11001407, 110, 'Auditor', 'MD. KAWSAR ALI', '6/16/1992', 1, 'Islam ', 'Non Quota', 'Thakurgaon', 'Thakurgaon'),
(86, 'FW2G69', 11001691, 110, 'Auditor', 'AMIT DAS', '9/30/1990', 1, 'Hinduism ', 'Non Quota', 'Dhaka', 'Noakhali'),
(87, '6JPP1K', 11002567, 110, 'Auditor', 'MD.MIZANUR RAHMAN', '12/25/1991', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(88, 'D75BTR', 11003068, 110, 'Auditor', 'PROSHENJIT KUMAR', '1/1/1992', 1, 'Hinduism ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(89, '6WQ3T2', 11003495, 110, 'Auditor', 'MD. ABU SUFIAN', '11/15/1985', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Jaipurhat'),
(90, 'A93QNE', 11003781, 110, 'Auditor', 'MD. GIASUDDIN AHMED', '9/16/1992', 1, 'Islam ', 'Non Quota', 'Satkhira', 'Satkhira'),
(91, 'LR85KB', 11003909, 110, 'Auditor', 'MD.TAMIM HASAN', '12/17/1991', 1, 'Islam ', 'Non Quota', 'Natore', 'Natore'),
(92, 'AEABQC', 11003923, 110, 'Auditor', 'MD. SOHEL RANA', '1/1/1992', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Nilphamari'),
(93, 'LHC3VP', 11004813, 110, 'Auditor', 'ASIM KUMAR BAIRAGI', '12/24/1991', 1, 'Hinduism ', 'Non Quota', 'Dhaka', 'Khulna'),
(94, 'S58SJ8', 11006419, 110, 'Auditor', 'MD.FAZLUL HAQUE', '5/10/1991', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(95, 'SAPQFZ', 11006995, 110, 'Auditor', 'SHARIF KHAN  ', '9/14/1990', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(96, 'SM1346', 11007877, 110, 'Auditor', 'MOST.FARJANA AKTER', '4/14/1995', 2, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(97, 'GMU8B5', 11008108, 110, 'Auditor', 'SAJEDUL ISLAM', '2/1/1994', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Pabna'),
(98, 'JSEPBZ', 11008469, 110, 'Auditor', 'MD.BELALUR RAHMAN BELAL', '2/21/1990', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(99, 'FP1KB9', 11008628, 110, 'Auditor', 'KAZI TAREQ MAHMUD', '4/9/1992', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(100, 'CRM8U9', 11008767, 110, 'Auditor', 'SABNAJ ARA SAMSHIN', '12/4/1989', 2, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(101, 'TM5JF9', 11008998, 110, 'Auditor', 'MD. MAHMUDUL HASAN', '12/3/1990', 1, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(102, 'W4TJ4Y', 11009017, 110, 'Auditor', 'MD. RUBEL PARVEZ ', '10/21/1991', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Tangail'),
(103, 'UHHBRC', 11009021, 110, 'Auditor', 'HABIBULLAH MASBAH', '9/11/1992', 1, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(104, 'A7N3X6', 11009028, 110, 'Auditor', 'MD.SALIM-AL-SABAH', '1/1/1993', 1, 'Islam ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(105, 'GQKRDC', 11009130, 110, 'Auditor', 'AZIZUL ISLAM', '10/10/1993', 1, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(106, 'X1YXHZ', 11009291, 110, 'Auditor', 'MD. JABID IQBAL', '12/2/1987', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Satkhira'),
(107, '5J91L9', 11009307, 110, 'Auditor', 'MASUMA HABIBA ', '2/18/1994', 2, 'Islam ', 'Non Quota', 'Satkhira', 'Satkhira'),
(108, 'KQU5JD', 11009326, 110, 'Auditor', 'DIBAS DAS', '2/26/1993', 1, 'Hinduism ', 'Non Quota', 'Chattogram', 'Chattogram'),
(109, 'AXKE2Q', 11009349, 110, 'Auditor', 'BIDURRAJ PRAMANIK', '2/12/1992', 1, 'Hinduism ', 'Non Quota', 'Naogaon', 'Naogaon'),
(110, 'QY4YYD', 11009450, 110, 'Auditor', 'MD. EUSUF ALI', '3/1/1996', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(111, 'CJLEW6', 11009463, 110, 'Auditor', 'MD. ASHIQUR RAHMAN', '12/25/1989', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(112, 'NKL1VV', 11009585, 110, 'Auditor', 'MD.SHAHPARAN MIA', '1/10/1991', 1, 'Islam ', 'Non Quota', 'Chandpur', 'Chandpur'),
(113, 'TJ9RRX', 11009608, 110, 'Auditor', 'HELAL UDDIN', '10/20/1986', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(114, 'M5BJLX', 11010032, 110, 'Auditor', 'MIR ABU NAYEEM', '12/25/1989', 1, 'Islam ', 'Non Quota', 'Noakhali', 'Noakhali'),
(115, 'XDJ7TT', 11010418, 110, 'Auditor', 'MD. ARIFUL ISLAM', '1/19/1992', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(116, 'CLTQ4Z', 11010433, 110, 'Auditor', 'SHAKIL AHAMED', '10/28/1988', 1, 'Islam ', 'Non Quota', 'Natore', 'Natore'),
(117, '8A7LFS', 11010575, 110, 'Auditor', 'MOHAMMED KAMRUL HASAN', '9/1/1990', 1, 'Islam ', 'Non Quota', 'Feni', 'Feni'),
(118, 'WEUJY6', 11010579, 110, 'Auditor', 'MD. ANWAR HOSSAIN', '4/20/1988', 1, 'Islam ', 'Non Quota', 'Thakurgaon', 'Thakurgaon'),
(119, 'TSVNPY', 11011165, 110, 'Auditor', 'ROMANA AHMED', '8/30/1991', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Pabna'),
(120, '1MSD92', 11011728, 110, 'Auditor', 'MD. ARIFHUR RAHMAN', '3/2/1988', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(121, 'QFETF3', 11011813, 110, 'Auditor', 'AMIR HOSSAIN', '1/1/1994', 1, 'Islam ', 'Non Quota', 'Shariatpur', 'Shariatpur'),
(122, 'CBMVBU', 11011843, 110, 'Auditor', 'MD.MAHABUBUL HOSSIN', '9/8/1989', 1, 'Islam ', 'Non Quota', 'Natore', 'Natore'),
(123, '917STV', 11012237, 110, 'Auditor', 'MD. MASUD HOSSAIN ', '11/15/1993', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Kishorganj'),
(124, '837FES', 11012704, 110, 'Auditor', 'KAZI NAHAZ PASHA', '12/31/1991', 1, 'Islam ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(125, '3KCSJM', 11012789, 110, 'Auditor', 'PARVEZ FAKIR', '8/12/1991', 1, 'Islam ', 'Non Quota', 'Satkhira', 'Satkhira'),
(126, 'E45Y6T', 11012795, 110, 'Auditor', 'MD. SANOAR HOSSAIN', '7/21/1987', 1, 'Islam ', 'Child of Freedom Fighter', 'Natore', 'Natore'),
(127, 'P72TAC', 11013060, 110, 'Auditor', 'MD. HARISUL ISLAM HERA', '6/10/1991', 1, 'Islam ', 'Non Quota', 'Dinajpur', 'Dinajpur'),
(128, '41CE4K', 11013119, 110, 'Auditor', 'SAWRAB DEBNATH', '2/10/1995', 1, 'Hinduism ', 'Non Quota', 'Sunamganj', 'Sunamganj'),
(129, '6EXWA7', 11013132, 110, 'Auditor', 'NAZNEEN SULTANA', '12/31/1992', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(130, '16QWX6', 12000008, 120, 'Stenographer cum Computer Operator', 'MOHAMMAD ARIFUL ISLAM ', '12/30/1990', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(131, '1M91J8', 12000019, 120, 'Stenographer cum Computer Operator', 'ABDUS SALAM', '1/2/1990', 1, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(132, '3S28E3', 12000079, 120, 'Stenographer cum Computer Operator', 'M. DELWAR HOSSAIN', '12/2/1991', 1, 'Islam ', 'Ansar-VDP', 'Chapai Nawabganj', 'Chapai Nawabganj'),
(133, '4LNRNL', 12000097, 120, 'Stenographer cum Computer Operator', 'MD. RABIUL AUWAL', '2/1/1991', 1, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(134, '5VXX3K', 12000134, 120, 'Stenographer cum Computer Operator', 'ZAFAR MOLLA', '7/18/1990', 1, 'Islam ', 'Ansar-VDP', 'Faridpur', 'Faridpur'),
(135, '63GKH1', 12000142, 120, 'Stenographer cum Computer Operator', 'MD. AHSAN HABIB ', '6/13/1995', 1, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(136, '67P6UL', 12000147, 120, 'Stenographer cum Computer Operator', 'MD REYAD HOSSAIN', '1/1/1994', 1, 'Islam ', 'Non Quota', 'Chandpur', 'Chandpur'),
(137, '6UTE6B', 12000171, 120, 'Stenographer cum Computer Operator', 'MD. MAHAMUDUL HASAN', '3/15/1998', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(138, '6W335C', 12000172, 120, 'Stenographer cum Computer Operator', 'SIMAB AL AHMMED', '12/23/1993', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(139, '7KWUPG', 12000193, 120, 'Stenographer cum Computer Operator', 'MD. TOWHIDUR RAHMAN', '10/27/1992', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(140, '8SX3KA', 12000233, 120, 'Stenographer cum Computer Operator', 'MST.JABIN AKTER', '7/1/1998', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(141, 'D69R8Z', 12000378, 120, 'Stenographer cum Computer Operator', 'MD. RASHEDUL ISLAM', '5/8/1993', 1, 'Islam ', 'Ansar-VDP', 'Kurigram', 'Kurigram'),
(142, 'F94R3D', 12000446, 120, 'Stenographer cum Computer Operator', 'RAZESH MOZUMDER', '10/15/1990', 1, 'Hinduism ', 'Non Quota', 'Khulna', 'Khulna'),
(143, 'JY3UWL', 12000552, 120, 'Stenographer cum Computer Operator', 'MD. MAHABUBUL ALAM', '9/6/1989', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Satkhira'),
(144, 'LHJH6B', 12000602, 120, 'Stenographer cum Computer Operator', 'MD. ABUL KALAM AZAD', '12/20/1989', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Feni'),
(145, 'MWEUSD', 12000639, 120, 'Stenographer cum Computer Operator', 'ZAKAREYA', '1/5/1990', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Mymensingh'),
(146, 'TSAGFZ', 12000817, 120, 'Stenographer cum Computer Operator', 'MD.KAMRUL ISLAM SAKIL', '2/12/1995', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(147, 'U8BQ7R', 12000834, 120, 'Stenographer cum Computer Operator', 'ISRAT JAHAN RINKO', '2/11/1991', 2, 'Islam ', 'Ansar-VDP', 'Mymensingh', 'Mymensingh'),
(148, 'VUG5V6', 12000886, 120, 'Stenographer cum Computer Operator', 'TASRIFUL ISLAM', '9/27/1997', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Shariatpur'),
(149, 'Y8FPFN', 12000972, 120, 'Stenographer cum Computer Operator', 'JUWEL MIA', '10/22/1998', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(150, '146JG6', 13000018, 130, 'Office Assistant cum Computer Typist', 'MD.ABDUL KADIR', '2/1/1994', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(151, '18FBRE', 13000040, 130, 'Office Assistant cum Computer Typist', 'MD. JEWEL RANA', '1/1/1993', 1, 'Islam ', 'Non Quota', 'Rajshahi', 'Rajshahi'),
(152, '1B1UM6', 13000049, 130, 'Office Assistant cum Computer Typist', 'MD. FARHAD MIA ', '7/4/1989', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Brahamanbaria'),
(153, '1B5J3S', 13000050, 130, 'Office Assistant cum Computer Typist', 'AFIF ARAFI', '12/15/1990', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(154, '1HL5X9', 13000082, 130, 'Office Assistant cum Computer Typist', 'MST. LUTFUNNAHER RIMA', '5/7/1994', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(155, '1HQQQB', 13000083, 130, 'Office Assistant cum Computer Typist', 'JUBORAZ RAJIB', '1/1/1991', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(156, '1JG4YQ', 13000087, 130, 'Office Assistant cum Computer Typist', 'MD. RIPON UDDIN', '8/30/1993', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(157, '1P97KV', 13000104, 130, 'Office Assistant cum Computer Typist', 'JOYNUL ABEDIN LION', '8/6/1989', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(158, '232ULQ', 13000159, 130, 'Office Assistant cum Computer Typist', 'UMMEKULSUM SHAGORIKA ', '12/26/1994', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(159, '23YPBQ', 13000162, 130, 'Office Assistant cum Computer Typist', 'MD. SHIHAB SHOVAN', '11/8/1997', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(160, '2FGHPJ', 13000205, 130, 'Office Assistant cum Computer Typist', 'ASEQUR RAHAMAN', '3/24/1990', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(161, '2JHYVF', 13000219, 130, 'Office Assistant cum Computer Typist', 'TAPOSH MONDOL', '12/10/1994', 1, 'Hinduism ', 'Non Quota', 'Satkhira', 'Satkhira'),
(162, '2PZQ1M', 13000234, 130, 'Office Assistant cum Computer Typist', 'MD. ALIM HUSSAIN', '12/25/1992', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(163, '2U6TXA', 13000252, 130, 'Office Assistant cum Computer Typist', 'MD. JEWEL MIAH', '3/21/2000', 1, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(164, '2XRUPE', 13000273, 130, 'Office Assistant cum Computer Typist', 'ABDUL MALEK', '10/12/1990', 1, 'Islam ', 'Non Quota', 'Jaipurhat', 'Jaipurhat'),
(165, '32GVDD', 13000289, 130, 'Office Assistant cum Computer Typist', 'MD. ABDUS SALAM', '11/2/1989', 1, 'Islam ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(166, '3GT9NR', 13000350, 130, 'Office Assistant cum Computer Typist', 'MD.ARIFUL ISLAM', '1/1/1994', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(167, '41674V', 13000418, 130, 'Office Assistant cum Computer Typist', 'MOST.BILKIS KHATUN', '4/13/1993', 2, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(168, '41KF5S', 13000420, 130, 'Office Assistant cum Computer Typist', 'MOSA.SHARMIN SULTANA', '6/1/1991', 2, 'Islam ', 'Non Quota', 'Cumilla', 'Cumilla'),
(169, '435YYP', 13000429, 130, 'Office Assistant cum Computer Typist', 'JIBAN KRISHNA DAS', '3/23/1990', 1, 'Hinduism ', 'Non Quota', 'Noakhali', 'Noakhali'),
(170, '4476BV', 13000434, 130, 'Office Assistant cum Computer Typist', 'IMRUL HOSSAIN', '6/22/1995', 1, 'Islam ', 'Ansar-VDP', 'Rajbari', 'Rajbari'),
(171, '476K4X', 13000446, 130, 'Office Assistant cum Computer Typist', 'MD ZUNAEID HOSSAIN  ', '12/31/1999', 1, 'Islam ', 'Non Quota', 'Magura', 'Magura'),
(172, '4BFB9S', 13000464, 130, 'Office Assistant cum Computer Typist', 'AMINA KHATUN', '6/15/1989', 2, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(173, '4EHNFM', 13000472, 130, 'Office Assistant cum Computer Typist', 'MD.ABDUR RAZZAQUE', '3/15/1990', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(174, '4FHXKY', 13000474, 130, 'Office Assistant cum Computer Typist', 'KRISHNO KANTO BAROI', '7/5/1993', 1, 'Hinduism ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(175, '4K5GBC', 13000487, 130, 'Office Assistant cum Computer Typist', 'NUR ISLAM', '12/23/1991', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(176, '4N6UG4', 13000501, 130, 'Office Assistant cum Computer Typist', 'MD. RAFIKUL ISLAM', '5/4/1990', 1, 'Islam ', 'Ansar-VDP', 'Jhenaidah', 'Jhenaidah'),
(177, '4YTWKS', 13000540, 130, 'Office Assistant cum Computer Typist', 'MD. ASHRAFUL ISLAM ', '1/1/1994', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(178, '59VXVP', 13000581, 130, 'Office Assistant cum Computer Typist', 'RATAN MANDAL', '9/15/1994', 1, 'Hinduism ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(179, '5GDGWQ', 13000598, 130, 'Office Assistant cum Computer Typist', 'MD. SHAHEEN ALOM', '4/12/1993', 1, 'Islam ', 'Non Quota', 'Nilphamari', 'Nilphamari'),
(180, '5PE3SW', 13000634, 130, 'Office Assistant cum Computer Typist', 'JAKIR HOSSEN ', '3/5/1991', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(181, '5PZ6HS', 13000639, 130, 'Office Assistant cum Computer Typist', 'SENTU HOSSAIN', '3/10/1991', 1, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(182, '63CZ61', 13000712, 130, 'Office Assistant cum Computer Typist', 'MD.IBRAHIM', '9/2/1993', 1, 'Islam ', 'Non Quota', 'Munshiganj', 'Munshiganj'),
(183, '67GBUA', 13000728, 130, 'Office Assistant cum Computer Typist', 'NAZMUL HOQUE', '4/3/1990', 1, 'Islam ', 'Ansar-VDP', 'Kishorganj', 'Kishorganj'),
(184, '694RLU', 13000734, 130, 'Office Assistant cum Computer Typist', 'TANJIAKADIR  TANIA', '10/26/1992', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(185, '69NQHF', 13000738, 130, 'Office Assistant cum Computer Typist', 'MD. AKTAR HOSEN', '1/17/1991', 1, 'Islam ', 'Ansar-VDP', 'Satkhira', 'Satkhira'),
(186, '6B8V4L', 13000743, 130, 'Office Assistant cum Computer Typist', 'KOHINOOR AKTER', '2/25/1995', 2, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(187, '6CC5VQ', 13000746, 130, 'Office Assistant cum Computer Typist', 'MOHAMMAD IMRAN HOSSAN', '1/1/1991', 1, 'Islam ', 'Non Quota', 'Noakhali', 'Noakhali'),
(188, '6CH7AL', 13000748, 130, 'Office Assistant cum Computer Typist', 'MD KAMRUL HASAN', '5/12/1996', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(189, '6GACTL', 13000762, 130, 'Office Assistant cum Computer Typist', 'MD. MASUM KHAN', '1/1/1994', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(190, '6KHUEL', 13000775, 130, 'Office Assistant cum Computer Typist', 'MD.ASHRAFUL ISLAM', '1/24/1994', 1, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(191, '6M8Q8J', 13000785, 130, 'Office Assistant cum Computer Typist', 'MD. BODIUZZAMAN', '11/12/1992', 1, 'Islam ', 'Ansar-VDP', 'Jamalpur', 'Jamalpur'),
(192, '6NXESD', 13000788, 130, 'Office Assistant cum Computer Typist', 'MD.NAYEB ALI', '1/1/1996', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(193, '7VC4FH', 13000946, 130, 'Office Assistant cum Computer Typist', 'MD SHAFIUL ISLAM RUSHO', '6/10/1991', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(194, '7WKXYR', 13000955, 130, 'Office Assistant cum Computer Typist', 'NAHID AKTER TRISHNA', '3/15/1992', 2, 'Islam ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(195, '7ZZ3TD', 13000967, 130, 'Office Assistant cum Computer Typist', 'MD. NAZMUL HUDA', '1/3/1996', 1, 'Islam ', 'Non Quota', 'Pabna', 'Pabna'),
(196, '869KEL', 13000991, 130, 'Office Assistant cum Computer Typist', 'MST. HASINA KHATUN', '8/11/1990', 2, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(197, '89T5PJ', 13001003, 130, 'Office Assistant cum Computer Typist', 'MD. AKBAR HOSSAIN', '6/15/1995', 1, 'Islam ', 'Non Quota', 'Faridpur', 'Faridpur'),
(198, '8DFB8K', 13001017, 130, 'Office Assistant cum Computer Typist', 'MD.FARUQUE MIA', '2/3/1990', 1, 'Islam ', 'Non Quota', 'Netrokona', 'Netrokona'),
(199, '8DHSD2', 13001018, 130, 'Office Assistant cum Computer Typist', 'MD. KAYUM HOWLADER', '7/26/1991', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(200, '8DN3A4', 13001021, 130, 'Office Assistant cum Computer Typist', 'MD. AKTER HOSSAIN AKAND', '11/6/1990', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(201, '8KWP56', 13001038, 130, 'Office Assistant cum Computer Typist', 'MASHUD RANA', '1/28/1991', 1, 'Islam ', 'Non Quota', 'Gazipur', 'Mymensingh'),
(202, '8YK86W', 13001085, 130, 'Office Assistant cum Computer Typist', 'MD.SIFUL ISLAM', '12/10/1998', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(203, '8YWYYP', 13001090, 130, 'Office Assistant cum Computer Typist', 'HOSAINI AHMED', '7/5/1993', 1, 'Islam ', 'Ansar-VDP', 'Kishorganj', 'Kishorganj'),
(204, '94AD1A', 13001113, 130, 'Office Assistant cum Computer Typist', 'KALLYAN DEBNATH', '3/15/1990', 1, 'Hinduism ', 'Non Quota', 'Dhaka', 'Cumilla'),
(205, '95MZDP', 13001118, 130, 'Office Assistant cum Computer Typist', 'KAZI IMRAN HASSAN', '12/15/1994', 1, 'Islam ', 'Child of Freedom Fighter', 'Narail', 'Narail'),
(206, '9NT74J', 13001185, 130, 'Office Assistant cum Computer Typist', 'MD.ABUL KALAM AZAD', '5/5/1989', 1, 'Islam ', 'Ansar-VDP', 'Lalmonirhat', 'Lalmonirhat'),
(207, '9P6DCV', 13001186, 130, 'Office Assistant cum Computer Typist', 'MD. ASADUZZAMAN', '5/3/1989', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(208, '9TUGAF', 13001199, 130, 'Office Assistant cum Computer Typist', 'RIMUN HAQUE', '10/22/1992', 1, 'Islam ', 'Child of Freedom Fighter', 'Panchagarh', 'Panchagarh'),
(209, '9V2BBG', 13001208, 130, 'Office Assistant cum Computer Typist', 'AKTAROZZAMAN', '6/1/1992', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(210, 'A4HDJB', 13001242, 130, 'Office Assistant cum Computer Typist', 'KHANDAKAR MD. ARIFUL ISLAM', '12/8/1989', 1, 'Islam ', 'Ansar-VDP', 'Naogaon', 'Naogaon'),
(211, 'A6VZAY', 13001256, 130, 'Office Assistant cum Computer Typist', 'MD REZAUL KARIM ', '4/8/1993', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Cumilla'),
(212, 'A7SS1R', 13001261, 130, 'Office Assistant cum Computer Typist', 'LUTFOR RAHMAN', '10/14/1997', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(213, 'A8QPGT', 13001264, 130, 'Office Assistant cum Computer Typist', 'MILTON SARKAR', '8/12/1993', 1, 'Hinduism ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(214, 'ABLU2N', 13001277, 130, 'Office Assistant cum Computer Typist', 'MST. SARMIN SHULTANA', '11/9/1990', 2, 'Islam ', 'Non Quota', 'Rajshahi', 'Rajshahi'),
(215, 'AF7QYQ', 13001287, 130, 'Office Assistant cum Computer Typist', 'SHAFIQUR RAHMAN', '4/11/1994', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(216, 'AFY8A9', 13001289, 130, 'Office Assistant cum Computer Typist', 'SAJAL KUMAR DAS', '4/20/1993', 1, 'Hinduism ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(217, 'AJRYRC', 13001307, 130, 'Office Assistant cum Computer Typist', 'MD.MIZANUR RAHMAN AKAND', '9/5/1993', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(218, 'AJZ2L1', 13001308, 130, 'Office Assistant cum Computer Typist', 'SHAMIM REZA', '12/31/1989', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(219, 'AR8D2C', 13001327, 130, 'Office Assistant cum Computer Typist', 'MOST. KARIMA', '12/25/1999', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(220, 'AT1DM5', 13001335, 130, 'Office Assistant cum Computer Typist', 'MD. MOSTAFIZUR RAHMAN', '1/27/1991', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(221, 'B22L82', 13001371, 130, 'Office Assistant cum Computer Typist', 'MST. SALMA AKTER', '6/15/1994', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(222, 'B9G8SD', 13001396, 130, 'Office Assistant cum Computer Typist', 'JOSEF SORDAR', '12/4/1997', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(223, 'BC4FWJ', 13001410, 130, 'Office Assistant cum Computer Typist', 'LABONI ATKER', '8/5/1991', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Narayanganj'),
(224, 'BDFE1Z', 13001413, 130, 'Office Assistant cum Computer Typist', 'ASRAFUL HASSAN ', '11/1/1993', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Tangail'),
(225, 'BFPM73', 13001419, 130, 'Office Assistant cum Computer Typist', 'MD. PARVEZ', '3/12/1989', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Munshiganj'),
(226, 'BJKV1C', 13001429, 130, 'Office Assistant cum Computer Typist', 'IKTIAR UDDIN', '12/16/1994', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(227, 'C4XR3Y', 13001517, 130, 'Office Assistant cum Computer Typist', 'MOHAMMAD KABIR HOSSAIN', '9/12/1989', 1, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(228, 'CBFXQW', 13001533, 130, 'Office Assistant cum Computer Typist', 'MD. ABU JAFAR SIDDIK', '11/11/1993', 1, 'Islam ', 'Non Quota', 'Jaipurhat', 'Jaipurhat'),
(229, 'CBS651', 13001536, 130, 'Office Assistant cum Computer Typist', 'MD.SHAKIBUL ISLAM', '5/1/1997', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Naogaon'),
(230, 'CLRN9P', 13001566, 130, 'Office Assistant cum Computer Typist', 'MD SIMUL REZA', '3/9/1993', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(231, 'CSWT3K', 13001588, 130, 'Office Assistant cum Computer Typist', 'MD. ANAMUL HAQUE', '4/24/1992', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(232, 'CTKP3D', 13001594, 130, 'Office Assistant cum Computer Typist', 'MD. MIJANUR RAHMAN', '3/22/1993', 1, 'Islam ', 'Non Quota', 'Jaipurhat', 'Jaipurhat'),
(233, 'CUBET7', 13001603, 130, 'Office Assistant cum Computer Typist', 'MD. ABDUR RAHIM', '11/10/1990', 1, 'Islam ', 'Non Quota', 'Chattogram', 'Chattogram'),
(234, 'D3KFD2', 13001645, 130, 'Office Assistant cum Computer Typist', 'MD. BILLAL HOSSAIN', '11/7/1990', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(235, 'DKEQNY', 13001711, 130, 'Office Assistant cum Computer Typist', 'RIAZ MAHAMUD ', '3/18/1990', 1, 'Islam ', 'Non Quota', 'Chandpur', 'Chandpur'),
(236, 'DKPELS', 13001712, 130, 'Office Assistant cum Computer Typist', 'MD.ABDULLAH', '1/1/1999', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(237, 'DLL228', 13001720, 130, 'Office Assistant cum Computer Typist', 'TAMANNA KHATUN', '11/15/1998', 2, 'Islam ', 'Non Quota', 'Jhenaidah', 'Jhenaidah'),
(238, 'DSW5AF', 13001738, 130, 'Office Assistant cum Computer Typist', 'MD NURUN NOBI MAZUMDER', '12/9/1988', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Feni'),
(239, 'DWV2L9', 13001753, 130, 'Office Assistant cum Computer Typist', 'FULLBABU SARKAR', '10/24/1991', 1, 'Hinduism ', 'Non Quota', 'Kurigram', 'Kurigram'),
(240, 'DZRWZW', 13001762, 130, 'Office Assistant cum Computer Typist', 'IBRAHIM', '8/22/1998', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(241, 'E18UMM', 13001764, 130, 'Office Assistant cum Computer Typist', 'MAHFUZ AHAMED', '5/28/1995', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Noakhali'),
(242, 'EEZJWC', 13001825, 130, 'Office Assistant cum Computer Typist', 'MD. KUTUBUDDIN', '3/2/1991', 1, 'Islam ', 'Non Quota', 'Magura', 'Magura'),
(243, 'EPFBZ2', 13001862, 130, 'Office Assistant cum Computer Typist', 'SHODON CHANDRA DAS', '4/16/1989', 1, 'Hinduism ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(244, 'EQHAKU', 13001868, 130, 'Office Assistant cum Computer Typist', 'KHAIRUL ALAM', '2/25/1990', 1, 'Islam ', 'Physically Handicapped', 'Kishorganj', 'Kishorganj'),
(245, 'ETHTXV', 13001874, 130, 'Office Assistant cum Computer Typist', 'MD. RUBAYET IBINE ARMAN', '10/15/1990', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(246, 'F4B4SU', 13001910, 130, 'Office Assistant cum Computer Typist', 'LOTFAR RAHAMAN', '2/12/1990', 1, 'Islam ', 'Physically Handicapped', 'Mymensingh', 'Mymensingh'),
(247, 'F5C1VG', 13001917, 130, 'Office Assistant cum Computer Typist', 'NASRIN AKTHER', '2/11/1999', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(248, 'F5WTPH', 13001920, 130, 'Office Assistant cum Computer Typist', 'MD. SHAKIRUL ISLAM', '1/1/1990', 1, 'Islam ', 'Non Quota', 'Bogra', 'Bogra'),
(249, 'FS46TU', 13002011, 130, 'Office Assistant cum Computer Typist', 'MD. SADDAM HOSSAIN', '8/25/1992', 1, 'Islam ', 'Non Quota', 'Satkhira', 'Satkhira'),
(250, 'FYRUWN', 13002041, 130, 'Office Assistant cum Computer Typist', 'MEHEDI HASAN', '10/2/1991', 1, 'Islam ', 'Non Quota', 'Bogra', 'Bogra'),
(251, 'GC9FXA', 13002090, 130, 'Office Assistant cum Computer Typist', 'APARUP SARKER', '10/1/1989', 1, 'Hinduism ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(252, 'HCUU4Q', 13002234, 130, 'Office Assistant cum Computer Typist', 'MOSTAFIJUR RAHAMAN', '1/1/1989', 1, 'Islam ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(253, 'HV6ZHX', 13002293, 130, 'Office Assistant cum Computer Typist', 'RIMO AKTER', '4/5/1998', 2, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(254, 'HWSDXX', 13002298, 130, 'Office Assistant cum Computer Typist', 'TAHER AHMED', '4/10/1993', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(255, 'J3PD26', 13002323, 130, 'Office Assistant cum Computer Typist', 'RABINDRO NATH ROY', '2/6/1990', 1, 'Hinduism ', 'Ansar-VDP', 'Lalmonirhat', 'Lalmonirhat'),
(256, 'K78ML4', 13002491, 130, 'Office Assistant cum Computer Typist', 'MD. HUMAUN KABIR SARKER', '1/14/1988', 1, 'Islam ', 'Child of Freedom Fighter', 'Dhaka', 'Dhaka'),
(257, 'KNFABU', 13002557, 130, 'Office Assistant cum Computer Typist', 'MD. MAHMUDUR RAHMAN', '10/15/1990', 1, 'Islam ', 'Non Quota', 'Brahamanbaria', 'Brahamanbaria'),
(258, 'KNJ1TA', 13002558, 130, 'Office Assistant cum Computer Typist', 'SHAMIM UDDIN ', '4/9/1989', 1, 'Islam ', 'Ansar-VDP', 'Brahamanbaria', 'Brahamanbaria'),
(259, 'KPHJD8', 13002564, 130, 'Office Assistant cum Computer Typist', 'RAFSAN JANI', '12/15/1991', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(260, 'KR3BN9', 13002567, 130, 'Office Assistant cum Computer Typist', 'MANIK MIAH', '9/3/1990', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(261, 'KRQDKS', 13002570, 130, 'Office Assistant cum Computer Typist', 'TANIYA SULTANA', '4/10/1990', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Jashore'),
(262, 'KYB164', 13002592, 130, 'Office Assistant cum Computer Typist', 'MD. MAZHARUL ISLAM', '11/15/1989', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(263, 'L9BJV9', 13002640, 130, 'Office Assistant cum Computer Typist', 'KHADIZA AKHTER ', '11/5/1991', 2, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(264, 'LFJYEK', 13002662, 130, 'Office Assistant cum Computer Typist', 'MD. ABDUL KARIM', '12/10/1991', 1, 'Islam ', 'Non Quota', 'Gazipur', 'Gazipur'),
(265, 'N26PWR', 13002855, 130, 'Office Assistant cum Computer Typist', 'MD. NAZMUL HAQUE MONDOL', '4/2/1989', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(266, 'N3V5GD', 13002870, 130, 'Office Assistant cum Computer Typist', 'MOST. KAMONA KHATUN', '12/18/1999', 2, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(267, 'N54J2W', 13002875, 130, 'Office Assistant cum Computer Typist', 'MD. SOHARAB HOSSAIN', '10/19/1993', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(268, 'N6D8MT', 13002880, 130, 'Office Assistant cum Computer Typist', 'SUKKUR ALI', '8/15/1991', 1, 'Islam ', 'Non Quota', 'Gazipur', 'Gazipur'),
(269, 'N6UZFP', 13002883, 130, 'Office Assistant cum Computer Typist', 'BISHAJIT TALUKDER', '6/6/1990', 1, 'Hinduism ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(270, 'N9GUU9', 13002893, 130, 'Office Assistant cum Computer Typist', 'MOST. SHAHANA YASMIN.', '11/30/1988', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Satkhira'),
(271, 'NJ21NU', 13002924, 130, 'Office Assistant cum Computer Typist', 'MD.MUSHARRAF HOSSEN', '2/1/1990', 1, 'Islam ', 'Ansar-VDP', 'Mymensingh', 'Mymensingh'),
(272, 'NJGKPF', 13002926, 130, 'Office Assistant cum Computer Typist', 'MD. MAHFUJUL ISLAM', '12/16/1999', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Cumilla'),
(273, 'NQSCH9', 13002950, 130, 'Office Assistant cum Computer Typist', 'MD. SOLAIMAN HOSSAIN', '5/3/1990', 1, 'Islam ', 'Ansar-VDP', 'Gaibanda', 'Gaibanda'),
(274, 'NWWZDG', 13002980, 130, 'Office Assistant cum Computer Typist', 'SANCHIT BHOWMIK', '5/4/1995', 1, 'Hinduism ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(275, 'P2DTA6', 13003011, 130, 'Office Assistant cum Computer Typist', 'MD. ARIFUL ISLAM', '11/20/1990', 1, 'Islam ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(276, 'PEXG9B', 13003065, 130, 'Office Assistant cum Computer Typist', 'IMRUL HASAN ', '9/17/1992', 1, 'Islam ', 'Non Quota', 'Netrokona', 'Netrokona'),
(277, 'PFJU1S', 13003071, 130, 'Office Assistant cum Computer Typist', 'MD. IBRAHIM HOSSAIN', '12/10/1989', 1, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(278, 'PFL5DC', 13003073, 130, 'Office Assistant cum Computer Typist', 'GOPAL DEBNATH', '10/15/1988', 1, 'Hinduism ', 'Non Quota', 'Khulna', 'Khulna'),
(279, 'PTRPZR', 13003127, 130, 'Office Assistant cum Computer Typist', 'MD. RAHAT SHEIKH', '3/9/1996', 1, 'Islam ', 'Non Quota', 'Faridpur', 'Faridpur'),
(280, 'Q1SDDG', 13003151, 130, 'Office Assistant cum Computer Typist', 'MD. LITU MIA', '2/10/1991', 1, 'Islam ', 'Non Quota', 'Jamalpur', 'Jamalpur'),
(281, 'Q7VD4Z', 13003179, 130, 'Office Assistant cum Computer Typist', 'LAILA SHARMIN', '12/15/1993', 2, 'Islam ', 'Non Quota', 'Pabna', 'Pabna'),
(282, 'QG6NMR', 13003210, 130, 'Office Assistant cum Computer Typist', 'LUKHY KHATUN', '7/10/1989', 2, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(283, 'QM28DX', 13003228, 130, 'Office Assistant cum Computer Typist', 'MD. MOHIDUL ISLAM', '1/3/1991', 1, 'Islam ', 'Non Quota', 'Bogra', 'Bogra'),
(284, 'QM7NWF', 13003232, 130, 'Office Assistant cum Computer Typist', 'MD.BADAL HOSSAIN ', '11/24/1990', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(285, 'QRS61U', 13003252, 130, 'Office Assistant cum Computer Typist', 'SHARMIN AKTER', '10/6/1998', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(286, 'R12ZG3', 13003284, 130, 'Office Assistant cum Computer Typist', 'MD.ARMAN HOSSAIN ', '2/23/1988', 1, 'Islam ', 'Physically Handicapped', 'Naogaon', 'Naogaon'),
(287, 'R3P3TZ', 13003294, 130, 'Office Assistant cum Computer Typist', 'MD. ROBEL MAHAMUD', '6/15/1989', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(288, 'R3S5WN', 13003295, 130, 'Office Assistant cum Computer Typist', 'ATIKUR RAHMAN', '1/1/1991', 1, 'Islam ', 'Ansar-VDP', 'Mymensingh', 'Mymensingh'),
(289, 'RHVG32', 13003344, 130, 'Office Assistant cum Computer Typist', 'HUMAYUN KABIR', '10/23/1989', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(290, 'RN4RAZ', 13003363, 130, 'Office Assistant cum Computer Typist', 'MST. ASMANI  KHATUN', '10/15/1996', 2, 'Islam ', 'Ansar-VDP', 'Kurigram', 'Kurigram'),
(291, 'RTPMGT', 13003377, 130, 'Office Assistant cum Computer Typist', 'AFSANA JAHAN ALPONA', '12/31/1997', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(292, 'RZU7BT', 13003402, 130, 'Office Assistant cum Computer Typist', 'MD.BELAL HOSSAIN', '1/1/1991', 1, 'Islam ', 'Non Quota', 'Cumilla', 'Cumilla'),
(293, 'SFUHZA', 13003461, 130, 'Office Assistant cum Computer Typist', 'MD.NAZMUL HOUDA', '1/1/1992', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(294, 'TBRMKB', 13003577, 130, 'Office Assistant cum Computer Typist', 'IBRAHIM MIAH', '3/3/1991', 1, 'Islam ', 'Non Quota', 'Cumilla', 'Cumilla'),
(295, 'TEPND6', 13003590, 130, 'Office Assistant cum Computer Typist', 'MD. ABU SHAMAH DINER', '4/15/1990', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(296, 'TF1EXD', 13003591, 130, 'Office Assistant cum Computer Typist', 'SHAHIDA KHATUN', '7/2/1990', 2, 'Islam ', 'Ansar-VDP', 'Jashore', 'Jashore'),
(297, 'TLRK6R', 13003616, 130, 'Office Assistant cum Computer Typist', 'MD.SHOHEL RANA', '10/30/1994', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Kurigram'),
(298, 'TPB5VH', 13003625, 130, 'Office Assistant cum Computer Typist', 'MD AMAN PERVEZ', '7/8/1994', 1, 'Islam ', 'Non Quota', 'Chuadanga', 'Chuadanga'),
(299, 'TYJ99R', 13003659, 130, 'Office Assistant cum Computer Typist', 'MUNJURUL ISLAM', '11/5/1993', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(300, 'U7WVP6', 13003691, 130, 'Office Assistant cum Computer Typist', 'SHEKHAR BISWAS', '11/6/1989', 1, 'Hinduism ', 'Ansar-VDP', 'Jashore', 'Jashore'),
(301, 'UE54PP', 13003716, 130, 'Office Assistant cum Computer Typist', 'ISMAT ARA KABIR', '6/22/1992', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Noakhali'),
(302, 'UKM77S', 13003739, 130, 'Office Assistant cum Computer Typist', 'MD.ANWAR HOSSAIN', '9/4/1993', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Lalmonirhat'),
(303, 'URYP1M', 13003771, 130, 'Office Assistant cum Computer Typist', 'MD. ABDUR RAUF MIA', '8/22/1991', 1, 'Islam ', 'Non Quota', 'Gaibanda', 'Gaibanda'),
(304, 'UZCPXM', 13003797, 130, 'Office Assistant cum Computer Typist', 'OMAR FARUQUE', '10/18/1993', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(305, 'V3RA4S', 13003812, 130, 'Office Assistant cum Computer Typist', 'ASADUZZAMAN AKTER', '11/20/1990', 1, 'Islam ', 'Physically Handicapped', 'Rajbari', 'Rajbari'),
(306, 'VNYZC4', 13003895, 130, 'Office Assistant cum Computer Typist', 'SHEIKH ABDUL MALEK', '3/1/1992', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Chandpur'),
(307, 'VPM4MM', 13003898, 130, 'Office Assistant cum Computer Typist', 'MST. TANIA KHATUN', '11/15/1992', 2, 'Islam ', 'Non Quota', 'Magura', 'Magura'),
(308, 'VVT5D2', 13003924, 130, 'Office Assistant cum Computer Typist', 'MD. HRIDOY MATUBBER', '9/11/1991', 1, 'Islam ', 'Non Quota', 'Faridpur', 'Faridpur'),
(309, 'W2AEX5', 13003960, 130, 'Office Assistant cum Computer Typist', 'MD. ATAUR RAHMAN', '12/17/1992', 1, 'Islam ', 'Non Quota', 'Jashore', 'Jashore'),
(310, 'W7C2EQ', 13003977, 130, 'Office Assistant cum Computer Typist', 'MD. JAHANGIR HOSSAIN', '4/22/1989', 1, 'Islam ', 'Ansar-VDP', 'Jashore', 'Jashore'),
(311, 'W9X5Y1', 13003987, 130, 'Office Assistant cum Computer Typist', 'RUPKUMAR MONDAL', '1/19/1990', 1, 'Hinduism ', 'Non Quota', 'Khulna', 'Khulna'),
(312, 'WBT33S', 13003996, 130, 'Office Assistant cum Computer Typist', 'IRIN SULTANA', '7/14/1995', 2, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(313, 'WS94AJ', 13004045, 130, 'Office Assistant cum Computer Typist', 'ASIT KUMAR MONDAL', '2/11/1990', 1, 'Hinduism ', 'Non Quota', 'Dhaka', 'Satkhira'),
(314, 'WT1XF6', 13004047, 130, 'Office Assistant cum Computer Typist', 'ASHISH KUMAR BAIRAGI', '12/16/1992', 1, 'Hinduism ', 'Non Quota', 'Satkhira', 'Satkhira'),
(315, 'X8AFCG', 13004096, 130, 'Office Assistant cum Computer Typist', 'MD NAYEEM KHAN', '1/3/1995', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Dhaka'),
(316, 'X9WGPZ', 13004102, 130, 'Office Assistant cum Computer Typist', 'MD RAJIB RANA', '10/10/1994', 1, 'Islam ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(317, 'XTBW2M', 13004170, 130, 'Office Assistant cum Computer Typist', 'MD. SHIRAZUL ISLAM', '12/10/1994', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(318, 'Y13GKW', 13004201, 130, 'Office Assistant cum Computer Typist', 'SIRAJUL ISLAM', '12/24/1992', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(319, 'Y4PJXW', 13004217, 130, 'Office Assistant cum Computer Typist', 'MD. MASUD RANA', '4/15/1991', 1, 'Islam ', 'Non Quota', 'Tangail', 'Tangail'),
(320, 'YNE61A', 13004295, 130, 'Office Assistant cum Computer Typist', 'MD.TAHIDUL ISLAM', '9/28/1993', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Gazipur'),
(321, 'YSHQAM', 13004312, 130, 'Office Assistant cum Computer Typist', 'SAPAN CHANDRA BARMAN', '11/12/1990', 1, 'Hinduism ', 'Non Quota', 'Rangpur', 'Rangpur'),
(322, 'Z2BSRJ', 13004344, 130, 'Office Assistant cum Computer Typist', 'ABDULLAH AL MAMUN', '1/31/1990', 1, 'Islam ', 'Non Quota', 'Mymensingh', 'Mymensingh'),
(323, 'ZLBZ3C', 13004415, 130, 'Office Assistant cum Computer Typist', 'MD. MAZHARUL ISLAM', '5/7/1993', 1, 'Islam ', 'Non Quota', 'Cumilla', 'Cumilla'),
(324, '18Z6M3', 14000015, 140, 'Record Keeper', 'SAMAREN SARKAR', '10/15/1992', 1, 'Hinduism ', 'Non Quota', 'Rajbari', 'Rajbari'),
(325, '2XNC18', 14000077, 140, 'Record Keeper', 'ASADUZZAMAN', '12/6/1990', 1, 'Islam ', 'Non Quota', 'Netrokona', 'Netrokona'),
(326, '4KFCJ1', 14000154, 140, 'Record Keeper', 'IFFAT ARA', '1/22/1992', 2, 'Islam ', 'Non Quota', 'Dhaka', 'Tangail'),
(327, '7H6E5L', 14000289, 140, 'Record Keeper', 'NAGMUL MRIDHA', '6/3/1989', 1, 'Islam ', 'Non Quota', 'Dhaka', 'Rajbari'),
(328, '7HUZYM', 14000290, 140, 'Record Keeper', 'MD.ABU SAYEED', '7/6/1992', 1, 'Islam ', 'Non Quota', 'Rangpur', 'Rangpur'),
(329, '7JJFA9', 14000292, 140, 'Record Keeper', 'MD.ABUL HASAN', '8/12/1992', 1, 'Islam ', 'Non Quota', 'Khulna', 'Khulna'),
(330, '7KSVTM', 14000295, 140, 'Record Keeper', 'JOBAYER ALAM', '12/25/1990', 1, 'Islam ', 'Non Quota', 'Brahamanbaria', 'Brahamanbaria'),
(331, '7P7QTH', 14000298, 140, 'Record Keeper', 'MD MAHBUBUR RAHMAN', '5/10/1989', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(332, '7TGTNE', 14000303, 140, 'Record Keeper', 'MD.KAMRUL ISLAM', '5/4/1989', 1, 'Islam ', 'Non Quota', 'Satkhira', 'Satkhira'),
(333, '8C5QX4', 14000321, 140, 'Record Keeper', 'MD. MAHMUDUL HASAN BHUIYAN', '2/10/1991', 1, 'Islam ', 'Ansar-VDP', 'Noakhali', 'Noakhali'),
(334, '8EREHG', 14000330, 140, 'Record Keeper', 'ABU ESAHAK ALI', '10/23/1996', 1, 'Islam ', 'Non Quota', 'Kurigram', 'Kurigram'),
(335, '92EM5N', 14000358, 140, 'Record Keeper', 'MD. MIZANUR RAHMAN', '12/25/1993', 1, 'Islam ', 'Non Quota', 'Naogaon', 'Naogaon'),
(336, 'B776NW', 14000460, 140, 'Record Keeper', 'LIAKOT HOSSAIN', '1/30/1989', 1, 'Islam ', 'Non Quota', 'Netrokona', 'Netrokona'),
(337, 'CP6RX6', 14000534, 140, 'Record Keeper', 'MD. GOLAM SARRWAR', '11/20/1988', 1, 'Islam ', 'Non Quota', 'Rajshahi', 'Rajshahi'),
(338, 'GLE56M', 14000723, 140, 'Record Keeper', 'ATAL BANIK', '1/30/1995', 1, 'Hinduism ', 'Non Quota', 'Narayanganj', 'Narayanganj'),
(339, 'HPW1KD', 14000772, 140, 'Record Keeper', 'BIPLOB BISWAS', '12/30/1992', 1, 'Hinduism ', 'Non Quota', 'Gopalganj', 'Gopalganj'),
(340, 'LQQ7PZ', 14000909, 140, 'Record Keeper', 'MD. ALI ERSHAD', '6/25/1989', 1, 'Islam ', 'Ansar-VDP', 'Magura', 'Magura'),
(341, 'RVDC1Q', 14001128, 140, 'Record Keeper', 'SHAHIDUL ISLAM ', '6/17/1989', 1, 'Islam ', 'Non Quota', 'Rajbari', 'Rajbari'),
(342, 'UPUK2S', 14001271, 140, 'Record Keeper', 'MONET KUMAR SAHA', '3/20/1991', 1, 'Hinduism ', 'Non Quota', 'Narsingdi', 'Cumilla'),
(343, 'VVAWNR', 14001325, 140, 'Record Keeper', 'K.A.M. RUSHDI ZAMAN', '10/1/1988', 1, 'Islam ', 'Ansar-VDP', 'Dhaka', 'Jamalpur'),
(344, 'W3MR8S', 14001335, 140, 'Record Keeper', 'MD.SAYEM KHAN', '5/10/1995', 1, 'Islam ', 'Non Quota', 'Kishorganj', 'Kishorganj'),
(345, 'WJ728R', 14001362, 140, 'Record Keeper', 'ABINASH CHANDRA ROY', '9/10/1990', 1, 'Hinduism ', 'Non Quota', 'Thakurgaon', 'Thakurgaon');

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
  `totalQuotaQuantity` double(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`postId`, `postName`, `vacancies`, `totalQuotaPercentage`, `totalQuotaQuantity`) VALUES
(1, 'Auditor', 10, 70.00, 7.00),
(2, 'Cash Sarker', 1, 70.00, 1.00),
(3, 'Driver', 2, 70.00, 1.00),
(4, 'Office Assistant cum Computer Typist', 8, 70.00, 6.00),
(5, 'Office Sohayok', 9, 70.00, 6.00),
(6, 'Photocopy Operator', 1, 70.00, 1.00),
(7, 'Record Keeper', 3, 70.00, 2.00),
(8, 'Security Guard', 1, 70.00, 1.00),
(9, 'Stenographer cum Computer Operator', 3, 70.00, 2.00);

-- --------------------------------------------------------

--
-- Table structure for table `post_quota`
--

CREATE TABLE `post_quota` (
  `id` int(11) NOT NULL,
  `postName` varchar(200) NOT NULL,
  `quotaName` varchar(200) NOT NULL,
  `decimalQuantity` double(5,2) NOT NULL,
  `roundedQuantity` double(5,2) NOT NULL,
  `applicantFound` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `post_quota`
--

INSERT INTO `post_quota` (`id`, `postName`, `quotaName`, `decimalQuantity`, `roundedQuantity`, `applicantFound`) VALUES
(1, 'Auditor', 'Freedom Fighter', 3.00, 0.00, 0),
(2, 'Auditor', 'Ansar-VDP', 1.00, 0.00, 0),
(3, 'Auditor', 'Physically Handicapped', 1.00, 0.00, 0),
(4, 'Auditor', 'Female', 1.50, 0.00, 0),
(5, 'Auditor', 'Tribal', 0.50, 0.00, 0),
(6, 'Cash Sarker', 'Tribal', 0.05, 0.00, 0),
(7, 'Cash Sarker', 'Female', 0.15, 0.00, 0),
(8, 'Cash Sarker', 'Physically Handicapped', 0.10, 0.00, 0),
(9, 'Cash Sarker', 'Ansar-VDP', 0.10, 0.00, 0),
(10, 'Cash Sarker', 'Freedom Fighter', 0.30, 0.00, 0),
(11, 'Driver', 'Tribal', 0.10, 0.00, 0),
(12, 'Driver', 'Female', 0.30, 0.00, 0),
(13, 'Driver', 'Physically Handicapped', 0.20, 0.00, 0),
(14, 'Driver', 'Ansar-VDP', 0.20, 0.00, 0),
(15, 'Driver', 'Freedom Fighter', 0.60, 0.00, 0),
(16, 'Office Assistant cum Computer Typist', 'Tribal', 0.40, 0.00, 0),
(17, 'Office Assistant cum Computer Typist', 'Female', 1.20, 0.00, 0),
(18, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 0.80, 0.00, 0),
(19, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 0.80, 0.00, 0),
(20, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 2.40, 0.00, 0),
(21, 'Office Sohayok', 'Tribal', 0.45, 0.00, 0),
(22, 'Office Sohayok', 'Female', 1.35, 0.00, 0),
(23, 'Office Sohayok', 'Physically Handicapped', 0.90, 0.00, 0),
(24, 'Office Sohayok', 'Ansar-VDP', 0.90, 0.00, 0),
(25, 'Office Sohayok', 'Freedom Fighter', 2.70, 0.00, 0),
(26, 'Photocopy Operator', 'Tribal', 0.05, 0.00, 0),
(27, 'Photocopy Operator', 'Female', 0.15, 0.00, 0),
(28, 'Photocopy Operator', 'Physically Handicapped', 0.10, 0.00, 0),
(29, 'Photocopy Operator', 'Ansar-VDP', 0.10, 0.00, 0),
(30, 'Photocopy Operator', 'Freedom Fighter', 0.30, 0.00, 0),
(31, 'Record Keeper', 'Tribal', 0.15, 0.00, 0),
(32, 'Record Keeper', 'Female', 0.45, 0.00, 0),
(33, 'Record Keeper', 'Physically Handicapped', 0.30, 0.00, 0),
(34, 'Record Keeper', 'Ansar-VDP', 0.30, 0.00, 0),
(35, 'Record Keeper', 'Freedom Fighter', 0.90, 0.00, 0),
(36, 'Security Guard', 'Tribal', 0.05, 0.00, 0),
(37, 'Security Guard', 'Female', 0.15, 0.00, 0),
(38, 'Security Guard', 'Physically Handicapped', 0.10, 0.00, 0),
(39, 'Security Guard', 'Ansar-VDP', 0.10, 0.00, 0),
(40, 'Security Guard', 'Freedom Fighter', 0.30, 0.00, 0),
(41, 'Stenographer cum Computer Operator', 'Tribal', 0.15, 0.00, 0),
(42, 'Stenographer cum Computer Operator', 'Female', 0.45, 0.00, 0),
(43, 'Stenographer cum Computer Operator', 'Physically Handicapped', 0.30, 0.00, 0),
(44, 'Stenographer cum Computer Operator', 'Ansar-VDP', 0.30, 0.00, 0),
(45, 'Stenographer cum Computer Operator', 'Freedom Fighter', 0.90, 0.00, 0);

-- --------------------------------------------------------

--
-- Table structure for table `post_quota_division`
--

CREATE TABLE `post_quota_division` (
  `id` int(11) NOT NULL,
  `postName` varchar(200) NOT NULL,
  `quotaName` varchar(200) NOT NULL,
  `divisionName` varchar(200) NOT NULL,
  `decimalQuantity` double(12,9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `post_quota_division`
--

INSERT INTO `post_quota_division` (`id`, `postName`, `quotaName`, `divisionName`, `decimalQuantity`) VALUES
(1, 'Auditor', 'Ansar-VDP', 'Dhaka', 0.252900000),
(2, 'Auditor', 'Ansar-VDP', 'Chattogram', 0.197900000),
(3, 'Auditor', 'Ansar-VDP', 'Rajshahi', 0.128300000),
(4, 'Auditor', 'Ansar-VDP', 'Rangpur', 0.109600000),
(5, 'Auditor', 'Ansar-VDP', 'Khulna', 0.108900000),
(6, 'Auditor', 'Ansar-VDP', 'Mymensingh', 0.076300000),
(7, 'Auditor', 'Ansar-VDP', 'Sylhet', 0.068800000),
(8, 'Auditor', 'Ansar-VDP', 'Barishal', 0.057800000),
(9, 'Auditor', 'Female', 'Dhaka', 0.379350000),
(10, 'Auditor', 'Female', 'Chattogram', 0.296850000),
(11, 'Auditor', 'Female', 'Rajshahi', 0.192450000),
(12, 'Auditor', 'Female', 'Rangpur', 0.164400000),
(13, 'Auditor', 'Female', 'Khulna', 0.163350000),
(14, 'Auditor', 'Female', 'Mymensingh', 0.114450000),
(15, 'Auditor', 'Female', 'Sylhet', 0.103200000),
(16, 'Auditor', 'Female', 'Barishal', 0.086700000),
(17, 'Auditor', 'Freedom Fighter', 'Dhaka', 0.758700000),
(18, 'Auditor', 'Freedom Fighter', 'Chattogram', 0.593700000),
(19, 'Auditor', 'Freedom Fighter', 'Rajshahi', 0.384900000),
(20, 'Auditor', 'Freedom Fighter', 'Rangpur', 0.328800000),
(21, 'Auditor', 'Freedom Fighter', 'Khulna', 0.326700000),
(22, 'Auditor', 'Freedom Fighter', 'Mymensingh', 0.228900000),
(23, 'Auditor', 'Freedom Fighter', 'Sylhet', 0.206400000),
(24, 'Auditor', 'Freedom Fighter', 'Barishal', 0.173400000),
(25, 'Auditor', 'Physically Handicapped', 'Dhaka', 0.252900000),
(26, 'Auditor', 'Physically Handicapped', 'Chattogram', 0.197900000),
(27, 'Auditor', 'Physically Handicapped', 'Rajshahi', 0.128300000),
(28, 'Auditor', 'Physically Handicapped', 'Rangpur', 0.109600000),
(29, 'Auditor', 'Physically Handicapped', 'Khulna', 0.108900000),
(30, 'Auditor', 'Physically Handicapped', 'Mymensingh', 0.076300000),
(31, 'Auditor', 'Physically Handicapped', 'Sylhet', 0.068800000),
(32, 'Auditor', 'Physically Handicapped', 'Barishal', 0.057800000),
(33, 'Auditor', 'Tribal', 'Dhaka', 0.126450000),
(34, 'Auditor', 'Tribal', 'Chattogram', 0.098950000),
(35, 'Auditor', 'Tribal', 'Rajshahi', 0.064150000),
(36, 'Auditor', 'Tribal', 'Rangpur', 0.054800000),
(37, 'Auditor', 'Tribal', 'Khulna', 0.054450000),
(38, 'Auditor', 'Tribal', 'Mymensingh', 0.038150000),
(39, 'Auditor', 'Tribal', 'Sylhet', 0.034400000),
(40, 'Auditor', 'Tribal', 'Barishal', 0.028900000),
(41, 'Cash Sarker', 'Ansar-VDP', 'Dhaka', 0.025290000),
(42, 'Cash Sarker', 'Ansar-VDP', 'Chattogram', 0.019790000),
(43, 'Cash Sarker', 'Ansar-VDP', 'Rajshahi', 0.012830000),
(44, 'Cash Sarker', 'Ansar-VDP', 'Rangpur', 0.010960000),
(45, 'Cash Sarker', 'Ansar-VDP', 'Khulna', 0.010890000),
(46, 'Cash Sarker', 'Ansar-VDP', 'Mymensingh', 0.007630000),
(47, 'Cash Sarker', 'Ansar-VDP', 'Sylhet', 0.006880000),
(48, 'Cash Sarker', 'Ansar-VDP', 'Barishal', 0.005780000),
(49, 'Cash Sarker', 'Female', 'Dhaka', 0.037935000),
(50, 'Cash Sarker', 'Female', 'Chattogram', 0.029685000),
(51, 'Cash Sarker', 'Female', 'Rajshahi', 0.019245000),
(52, 'Cash Sarker', 'Female', 'Rangpur', 0.016440000),
(53, 'Cash Sarker', 'Female', 'Khulna', 0.016335000),
(54, 'Cash Sarker', 'Female', 'Mymensingh', 0.011445000),
(55, 'Cash Sarker', 'Female', 'Sylhet', 0.010320000),
(56, 'Cash Sarker', 'Female', 'Barishal', 0.008670000),
(57, 'Cash Sarker', 'Freedom Fighter', 'Dhaka', 0.075870000),
(58, 'Cash Sarker', 'Freedom Fighter', 'Chattogram', 0.059370000),
(59, 'Cash Sarker', 'Freedom Fighter', 'Rajshahi', 0.038490000),
(60, 'Cash Sarker', 'Freedom Fighter', 'Rangpur', 0.032880000),
(61, 'Cash Sarker', 'Freedom Fighter', 'Khulna', 0.032670000),
(62, 'Cash Sarker', 'Freedom Fighter', 'Mymensingh', 0.022890000),
(63, 'Cash Sarker', 'Freedom Fighter', 'Sylhet', 0.020640000),
(64, 'Cash Sarker', 'Freedom Fighter', 'Barishal', 0.017340000),
(65, 'Cash Sarker', 'Physically Handicapped', 'Dhaka', 0.025290000),
(66, 'Cash Sarker', 'Physically Handicapped', 'Chattogram', 0.019790000),
(67, 'Cash Sarker', 'Physically Handicapped', 'Rajshahi', 0.012830000),
(68, 'Cash Sarker', 'Physically Handicapped', 'Rangpur', 0.010960000),
(69, 'Cash Sarker', 'Physically Handicapped', 'Khulna', 0.010890000),
(70, 'Cash Sarker', 'Physically Handicapped', 'Mymensingh', 0.007630000),
(71, 'Cash Sarker', 'Physically Handicapped', 'Sylhet', 0.006880000),
(72, 'Cash Sarker', 'Physically Handicapped', 'Barishal', 0.005780000),
(73, 'Cash Sarker', 'Tribal', 'Dhaka', 0.012645000),
(74, 'Cash Sarker', 'Tribal', 'Chattogram', 0.009895000),
(75, 'Cash Sarker', 'Tribal', 'Rajshahi', 0.006415000),
(76, 'Cash Sarker', 'Tribal', 'Rangpur', 0.005480000),
(77, 'Cash Sarker', 'Tribal', 'Khulna', 0.005445000),
(78, 'Cash Sarker', 'Tribal', 'Mymensingh', 0.003815000),
(79, 'Cash Sarker', 'Tribal', 'Sylhet', 0.003440000),
(80, 'Cash Sarker', 'Tribal', 'Barishal', 0.002890000),
(81, 'Driver', 'Ansar-VDP', 'Dhaka', 0.050580000),
(82, 'Driver', 'Ansar-VDP', 'Chattogram', 0.039580000),
(83, 'Driver', 'Ansar-VDP', 'Rajshahi', 0.025660000),
(84, 'Driver', 'Ansar-VDP', 'Rangpur', 0.021920000),
(85, 'Driver', 'Ansar-VDP', 'Khulna', 0.021780000),
(86, 'Driver', 'Ansar-VDP', 'Mymensingh', 0.015260000),
(87, 'Driver', 'Ansar-VDP', 'Sylhet', 0.013760000),
(88, 'Driver', 'Ansar-VDP', 'Barishal', 0.011560000),
(89, 'Driver', 'Female', 'Dhaka', 0.075870000),
(90, 'Driver', 'Female', 'Chattogram', 0.059370000),
(91, 'Driver', 'Female', 'Rajshahi', 0.038490000),
(92, 'Driver', 'Female', 'Rangpur', 0.032880000),
(93, 'Driver', 'Female', 'Khulna', 0.032670000),
(94, 'Driver', 'Female', 'Mymensingh', 0.022890000),
(95, 'Driver', 'Female', 'Sylhet', 0.020640000),
(96, 'Driver', 'Female', 'Barishal', 0.017340000),
(97, 'Driver', 'Freedom Fighter', 'Dhaka', 0.151740000),
(98, 'Driver', 'Freedom Fighter', 'Chattogram', 0.118740000),
(99, 'Driver', 'Freedom Fighter', 'Rajshahi', 0.076980000),
(100, 'Driver', 'Freedom Fighter', 'Rangpur', 0.065760000),
(101, 'Driver', 'Freedom Fighter', 'Khulna', 0.065340000),
(102, 'Driver', 'Freedom Fighter', 'Mymensingh', 0.045780000),
(103, 'Driver', 'Freedom Fighter', 'Sylhet', 0.041280000),
(104, 'Driver', 'Freedom Fighter', 'Barishal', 0.034680000),
(105, 'Driver', 'Physically Handicapped', 'Dhaka', 0.050580000),
(106, 'Driver', 'Physically Handicapped', 'Chattogram', 0.039580000),
(107, 'Driver', 'Physically Handicapped', 'Rajshahi', 0.025660000),
(108, 'Driver', 'Physically Handicapped', 'Rangpur', 0.021920000),
(109, 'Driver', 'Physically Handicapped', 'Khulna', 0.021780000),
(110, 'Driver', 'Physically Handicapped', 'Mymensingh', 0.015260000),
(111, 'Driver', 'Physically Handicapped', 'Sylhet', 0.013760000),
(112, 'Driver', 'Physically Handicapped', 'Barishal', 0.011560000),
(113, 'Driver', 'Tribal', 'Dhaka', 0.025290000),
(114, 'Driver', 'Tribal', 'Chattogram', 0.019790000),
(115, 'Driver', 'Tribal', 'Rajshahi', 0.012830000),
(116, 'Driver', 'Tribal', 'Rangpur', 0.010960000),
(117, 'Driver', 'Tribal', 'Khulna', 0.010890000),
(118, 'Driver', 'Tribal', 'Mymensingh', 0.007630000),
(119, 'Driver', 'Tribal', 'Sylhet', 0.006880000),
(120, 'Driver', 'Tribal', 'Barishal', 0.005780000),
(121, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Dhaka', 0.202320000),
(122, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Chattogram', 0.158320000),
(123, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Rajshahi', 0.102640000),
(124, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Rangpur', 0.087680000),
(125, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Khulna', 0.087120000),
(126, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Mymensingh', 0.061040000),
(127, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Sylhet', 0.055040000),
(128, 'Office Assistant cum Computer Typist', 'Ansar-VDP', 'Barishal', 0.046240000),
(129, 'Office Assistant cum Computer Typist', 'Female', 'Dhaka', 0.303480000),
(130, 'Office Assistant cum Computer Typist', 'Female', 'Chattogram', 0.237480000),
(131, 'Office Assistant cum Computer Typist', 'Female', 'Rajshahi', 0.153960000),
(132, 'Office Assistant cum Computer Typist', 'Female', 'Rangpur', 0.131520000),
(133, 'Office Assistant cum Computer Typist', 'Female', 'Khulna', 0.130680000),
(134, 'Office Assistant cum Computer Typist', 'Female', 'Mymensingh', 0.091560000),
(135, 'Office Assistant cum Computer Typist', 'Female', 'Sylhet', 0.082560000),
(136, 'Office Assistant cum Computer Typist', 'Female', 'Barishal', 0.069360000),
(137, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Dhaka', 0.606960000),
(138, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Chattogram', 0.474960000),
(139, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Rajshahi', 0.307920000),
(140, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Rangpur', 0.263040000),
(141, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Khulna', 0.261360000),
(142, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Mymensingh', 0.183120000),
(143, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Sylhet', 0.165120000),
(144, 'Office Assistant cum Computer Typist', 'Freedom Fighter', 'Barishal', 0.138720000),
(145, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Dhaka', 0.202320000),
(146, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Chattogram', 0.158320000),
(147, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Rajshahi', 0.102640000),
(148, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Rangpur', 0.087680000),
(149, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Khulna', 0.087120000),
(150, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Mymensingh', 0.061040000),
(151, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Sylhet', 0.055040000),
(152, 'Office Assistant cum Computer Typist', 'Physically Handicapped', 'Barishal', 0.046240000),
(153, 'Office Assistant cum Computer Typist', 'Tribal', 'Dhaka', 0.101160000),
(154, 'Office Assistant cum Computer Typist', 'Tribal', 'Chattogram', 0.079160000),
(155, 'Office Assistant cum Computer Typist', 'Tribal', 'Rajshahi', 0.051320000),
(156, 'Office Assistant cum Computer Typist', 'Tribal', 'Rangpur', 0.043840000),
(157, 'Office Assistant cum Computer Typist', 'Tribal', 'Khulna', 0.043560000),
(158, 'Office Assistant cum Computer Typist', 'Tribal', 'Mymensingh', 0.030520000),
(159, 'Office Assistant cum Computer Typist', 'Tribal', 'Sylhet', 0.027520000),
(160, 'Office Assistant cum Computer Typist', 'Tribal', 'Barishal', 0.023120000),
(161, 'Office Sohayok', 'Ansar-VDP', 'Dhaka', 0.227610000),
(162, 'Office Sohayok', 'Ansar-VDP', 'Chattogram', 0.178110000),
(163, 'Office Sohayok', 'Ansar-VDP', 'Rajshahi', 0.115470000),
(164, 'Office Sohayok', 'Ansar-VDP', 'Rangpur', 0.098640000),
(165, 'Office Sohayok', 'Ansar-VDP', 'Khulna', 0.098010000),
(166, 'Office Sohayok', 'Ansar-VDP', 'Mymensingh', 0.068670000),
(167, 'Office Sohayok', 'Ansar-VDP', 'Sylhet', 0.061920000),
(168, 'Office Sohayok', 'Ansar-VDP', 'Barishal', 0.052020000),
(169, 'Office Sohayok', 'Female', 'Dhaka', 0.341415000),
(170, 'Office Sohayok', 'Female', 'Chattogram', 0.267165000),
(171, 'Office Sohayok', 'Female', 'Rajshahi', 0.173205000),
(172, 'Office Sohayok', 'Female', 'Rangpur', 0.147960000),
(173, 'Office Sohayok', 'Female', 'Khulna', 0.147015000),
(174, 'Office Sohayok', 'Female', 'Mymensingh', 0.103005000),
(175, 'Office Sohayok', 'Female', 'Sylhet', 0.092880000),
(176, 'Office Sohayok', 'Female', 'Barishal', 0.078030000),
(177, 'Office Sohayok', 'Freedom Fighter', 'Dhaka', 0.682830000),
(178, 'Office Sohayok', 'Freedom Fighter', 'Chattogram', 0.534330000),
(179, 'Office Sohayok', 'Freedom Fighter', 'Rajshahi', 0.346410000),
(180, 'Office Sohayok', 'Freedom Fighter', 'Rangpur', 0.295920000),
(181, 'Office Sohayok', 'Freedom Fighter', 'Khulna', 0.294030000),
(182, 'Office Sohayok', 'Freedom Fighter', 'Mymensingh', 0.206010000),
(183, 'Office Sohayok', 'Freedom Fighter', 'Sylhet', 0.185760000),
(184, 'Office Sohayok', 'Freedom Fighter', 'Barishal', 0.156060000),
(185, 'Office Sohayok', 'Physically Handicapped', 'Dhaka', 0.227610000),
(186, 'Office Sohayok', 'Physically Handicapped', 'Chattogram', 0.178110000),
(187, 'Office Sohayok', 'Physically Handicapped', 'Rajshahi', 0.115470000),
(188, 'Office Sohayok', 'Physically Handicapped', 'Rangpur', 0.098640000),
(189, 'Office Sohayok', 'Physically Handicapped', 'Khulna', 0.098010000),
(190, 'Office Sohayok', 'Physically Handicapped', 'Mymensingh', 0.068670000),
(191, 'Office Sohayok', 'Physically Handicapped', 'Sylhet', 0.061920000),
(192, 'Office Sohayok', 'Physically Handicapped', 'Barishal', 0.052020000),
(193, 'Office Sohayok', 'Tribal', 'Dhaka', 0.113805000),
(194, 'Office Sohayok', 'Tribal', 'Chattogram', 0.089055000),
(195, 'Office Sohayok', 'Tribal', 'Rajshahi', 0.057735000),
(196, 'Office Sohayok', 'Tribal', 'Rangpur', 0.049320000),
(197, 'Office Sohayok', 'Tribal', 'Khulna', 0.049005000),
(198, 'Office Sohayok', 'Tribal', 'Mymensingh', 0.034335000),
(199, 'Office Sohayok', 'Tribal', 'Sylhet', 0.030960000),
(200, 'Office Sohayok', 'Tribal', 'Barishal', 0.026010000),
(201, 'Photocopy Operator', 'Ansar-VDP', 'Dhaka', 0.025290000),
(202, 'Photocopy Operator', 'Ansar-VDP', 'Chattogram', 0.019790000),
(203, 'Photocopy Operator', 'Ansar-VDP', 'Rajshahi', 0.012830000),
(204, 'Photocopy Operator', 'Ansar-VDP', 'Rangpur', 0.010960000),
(205, 'Photocopy Operator', 'Ansar-VDP', 'Khulna', 0.010890000),
(206, 'Photocopy Operator', 'Ansar-VDP', 'Mymensingh', 0.007630000),
(207, 'Photocopy Operator', 'Ansar-VDP', 'Sylhet', 0.006880000),
(208, 'Photocopy Operator', 'Ansar-VDP', 'Barishal', 0.005780000),
(209, 'Photocopy Operator', 'Female', 'Dhaka', 0.037935000),
(210, 'Photocopy Operator', 'Female', 'Chattogram', 0.029685000),
(211, 'Photocopy Operator', 'Female', 'Rajshahi', 0.019245000),
(212, 'Photocopy Operator', 'Female', 'Rangpur', 0.016440000),
(213, 'Photocopy Operator', 'Female', 'Khulna', 0.016335000),
(214, 'Photocopy Operator', 'Female', 'Mymensingh', 0.011445000),
(215, 'Photocopy Operator', 'Female', 'Sylhet', 0.010320000),
(216, 'Photocopy Operator', 'Female', 'Barishal', 0.008670000),
(217, 'Photocopy Operator', 'Freedom Fighter', 'Dhaka', 0.075870000),
(218, 'Photocopy Operator', 'Freedom Fighter', 'Chattogram', 0.059370000),
(219, 'Photocopy Operator', 'Freedom Fighter', 'Rajshahi', 0.038490000),
(220, 'Photocopy Operator', 'Freedom Fighter', 'Rangpur', 0.032880000),
(221, 'Photocopy Operator', 'Freedom Fighter', 'Khulna', 0.032670000),
(222, 'Photocopy Operator', 'Freedom Fighter', 'Mymensingh', 0.022890000),
(223, 'Photocopy Operator', 'Freedom Fighter', 'Sylhet', 0.020640000),
(224, 'Photocopy Operator', 'Freedom Fighter', 'Barishal', 0.017340000),
(225, 'Photocopy Operator', 'Physically Handicapped', 'Dhaka', 0.025290000),
(226, 'Photocopy Operator', 'Physically Handicapped', 'Chattogram', 0.019790000),
(227, 'Photocopy Operator', 'Physically Handicapped', 'Rajshahi', 0.012830000),
(228, 'Photocopy Operator', 'Physically Handicapped', 'Rangpur', 0.010960000),
(229, 'Photocopy Operator', 'Physically Handicapped', 'Khulna', 0.010890000),
(230, 'Photocopy Operator', 'Physically Handicapped', 'Mymensingh', 0.007630000),
(231, 'Photocopy Operator', 'Physically Handicapped', 'Sylhet', 0.006880000),
(232, 'Photocopy Operator', 'Physically Handicapped', 'Barishal', 0.005780000),
(233, 'Photocopy Operator', 'Tribal', 'Dhaka', 0.012645000),
(234, 'Photocopy Operator', 'Tribal', 'Chattogram', 0.009895000),
(235, 'Photocopy Operator', 'Tribal', 'Rajshahi', 0.006415000),
(236, 'Photocopy Operator', 'Tribal', 'Rangpur', 0.005480000),
(237, 'Photocopy Operator', 'Tribal', 'Khulna', 0.005445000),
(238, 'Photocopy Operator', 'Tribal', 'Mymensingh', 0.003815000),
(239, 'Photocopy Operator', 'Tribal', 'Sylhet', 0.003440000),
(240, 'Photocopy Operator', 'Tribal', 'Barishal', 0.002890000),
(241, 'Record Keeper', 'Ansar-VDP', 'Dhaka', 0.075870000),
(242, 'Record Keeper', 'Ansar-VDP', 'Chattogram', 0.059370000),
(243, 'Record Keeper', 'Ansar-VDP', 'Rajshahi', 0.038490000),
(244, 'Record Keeper', 'Ansar-VDP', 'Rangpur', 0.032880000),
(245, 'Record Keeper', 'Ansar-VDP', 'Khulna', 0.032670000),
(246, 'Record Keeper', 'Ansar-VDP', 'Mymensingh', 0.022890000),
(247, 'Record Keeper', 'Ansar-VDP', 'Sylhet', 0.020640000),
(248, 'Record Keeper', 'Ansar-VDP', 'Barishal', 0.017340000),
(249, 'Record Keeper', 'Female', 'Dhaka', 0.113805000),
(250, 'Record Keeper', 'Female', 'Chattogram', 0.089055000),
(251, 'Record Keeper', 'Female', 'Rajshahi', 0.057735000),
(252, 'Record Keeper', 'Female', 'Rangpur', 0.049320000),
(253, 'Record Keeper', 'Female', 'Khulna', 0.049005000),
(254, 'Record Keeper', 'Female', 'Mymensingh', 0.034335000),
(255, 'Record Keeper', 'Female', 'Sylhet', 0.030960000),
(256, 'Record Keeper', 'Female', 'Barishal', 0.026010000),
(257, 'Record Keeper', 'Freedom Fighter', 'Dhaka', 0.227610000),
(258, 'Record Keeper', 'Freedom Fighter', 'Chattogram', 0.178110000),
(259, 'Record Keeper', 'Freedom Fighter', 'Rajshahi', 0.115470000),
(260, 'Record Keeper', 'Freedom Fighter', 'Rangpur', 0.098640000),
(261, 'Record Keeper', 'Freedom Fighter', 'Khulna', 0.098010000),
(262, 'Record Keeper', 'Freedom Fighter', 'Mymensingh', 0.068670000),
(263, 'Record Keeper', 'Freedom Fighter', 'Sylhet', 0.061920000),
(264, 'Record Keeper', 'Freedom Fighter', 'Barishal', 0.052020000),
(265, 'Record Keeper', 'Physically Handicapped', 'Dhaka', 0.075870000),
(266, 'Record Keeper', 'Physically Handicapped', 'Chattogram', 0.059370000),
(267, 'Record Keeper', 'Physically Handicapped', 'Rajshahi', 0.038490000),
(268, 'Record Keeper', 'Physically Handicapped', 'Rangpur', 0.032880000),
(269, 'Record Keeper', 'Physically Handicapped', 'Khulna', 0.032670000),
(270, 'Record Keeper', 'Physically Handicapped', 'Mymensingh', 0.022890000),
(271, 'Record Keeper', 'Physically Handicapped', 'Sylhet', 0.020640000),
(272, 'Record Keeper', 'Physically Handicapped', 'Barishal', 0.017340000),
(273, 'Record Keeper', 'Tribal', 'Dhaka', 0.037935000),
(274, 'Record Keeper', 'Tribal', 'Chattogram', 0.029685000),
(275, 'Record Keeper', 'Tribal', 'Rajshahi', 0.019245000),
(276, 'Record Keeper', 'Tribal', 'Rangpur', 0.016440000),
(277, 'Record Keeper', 'Tribal', 'Khulna', 0.016335000),
(278, 'Record Keeper', 'Tribal', 'Mymensingh', 0.011445000),
(279, 'Record Keeper', 'Tribal', 'Sylhet', 0.010320000),
(280, 'Record Keeper', 'Tribal', 'Barishal', 0.008670000),
(281, 'Security Guard', 'Ansar-VDP', 'Dhaka', 0.025290000),
(282, 'Security Guard', 'Ansar-VDP', 'Chattogram', 0.019790000),
(283, 'Security Guard', 'Ansar-VDP', 'Rajshahi', 0.012830000),
(284, 'Security Guard', 'Ansar-VDP', 'Rangpur', 0.010960000),
(285, 'Security Guard', 'Ansar-VDP', 'Khulna', 0.010890000),
(286, 'Security Guard', 'Ansar-VDP', 'Mymensingh', 0.007630000),
(287, 'Security Guard', 'Ansar-VDP', 'Sylhet', 0.006880000),
(288, 'Security Guard', 'Ansar-VDP', 'Barishal', 0.005780000),
(289, 'Security Guard', 'Female', 'Dhaka', 0.037935000),
(290, 'Security Guard', 'Female', 'Chattogram', 0.029685000),
(291, 'Security Guard', 'Female', 'Rajshahi', 0.019245000),
(292, 'Security Guard', 'Female', 'Rangpur', 0.016440000),
(293, 'Security Guard', 'Female', 'Khulna', 0.016335000),
(294, 'Security Guard', 'Female', 'Mymensingh', 0.011445000),
(295, 'Security Guard', 'Female', 'Sylhet', 0.010320000),
(296, 'Security Guard', 'Female', 'Barishal', 0.008670000),
(297, 'Security Guard', 'Freedom Fighter', 'Dhaka', 0.075870000),
(298, 'Security Guard', 'Freedom Fighter', 'Chattogram', 0.059370000),
(299, 'Security Guard', 'Freedom Fighter', 'Rajshahi', 0.038490000),
(300, 'Security Guard', 'Freedom Fighter', 'Rangpur', 0.032880000),
(301, 'Security Guard', 'Freedom Fighter', 'Khulna', 0.032670000),
(302, 'Security Guard', 'Freedom Fighter', 'Mymensingh', 0.022890000),
(303, 'Security Guard', 'Freedom Fighter', 'Sylhet', 0.020640000),
(304, 'Security Guard', 'Freedom Fighter', 'Barishal', 0.017340000),
(305, 'Security Guard', 'Physically Handicapped', 'Dhaka', 0.025290000),
(306, 'Security Guard', 'Physically Handicapped', 'Chattogram', 0.019790000),
(307, 'Security Guard', 'Physically Handicapped', 'Rajshahi', 0.012830000),
(308, 'Security Guard', 'Physically Handicapped', 'Rangpur', 0.010960000),
(309, 'Security Guard', 'Physically Handicapped', 'Khulna', 0.010890000),
(310, 'Security Guard', 'Physically Handicapped', 'Mymensingh', 0.007630000),
(311, 'Security Guard', 'Physically Handicapped', 'Sylhet', 0.006880000),
(312, 'Security Guard', 'Physically Handicapped', 'Barishal', 0.005780000),
(313, 'Security Guard', 'Tribal', 'Dhaka', 0.012645000),
(314, 'Security Guard', 'Tribal', 'Chattogram', 0.009895000),
(315, 'Security Guard', 'Tribal', 'Rajshahi', 0.006415000),
(316, 'Security Guard', 'Tribal', 'Rangpur', 0.005480000),
(317, 'Security Guard', 'Tribal', 'Khulna', 0.005445000),
(318, 'Security Guard', 'Tribal', 'Mymensingh', 0.003815000),
(319, 'Security Guard', 'Tribal', 'Sylhet', 0.003440000),
(320, 'Security Guard', 'Tribal', 'Barishal', 0.002890000),
(321, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Dhaka', 0.075870000),
(322, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Chattogram', 0.059370000),
(323, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Rajshahi', 0.038490000),
(324, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Rangpur', 0.032880000),
(325, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Khulna', 0.032670000),
(326, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Mymensingh', 0.022890000),
(327, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Sylhet', 0.020640000),
(328, 'Stenographer cum Computer Operator', 'Ansar-VDP', 'Barishal', 0.017340000),
(329, 'Stenographer cum Computer Operator', 'Female', 'Dhaka', 0.113805000),
(330, 'Stenographer cum Computer Operator', 'Female', 'Chattogram', 0.089055000),
(331, 'Stenographer cum Computer Operator', 'Female', 'Rajshahi', 0.057735000),
(332, 'Stenographer cum Computer Operator', 'Female', 'Rangpur', 0.049320000),
(333, 'Stenographer cum Computer Operator', 'Female', 'Khulna', 0.049005000),
(334, 'Stenographer cum Computer Operator', 'Female', 'Mymensingh', 0.034335000),
(335, 'Stenographer cum Computer Operator', 'Female', 'Sylhet', 0.030960000),
(336, 'Stenographer cum Computer Operator', 'Female', 'Barishal', 0.026010000),
(337, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Dhaka', 0.227610000),
(338, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Chattogram', 0.178110000),
(339, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Rajshahi', 0.115470000),
(340, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Rangpur', 0.098640000),
(341, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Khulna', 0.098010000),
(342, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Mymensingh', 0.068670000),
(343, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Sylhet', 0.061920000),
(344, 'Stenographer cum Computer Operator', 'Freedom Fighter', 'Barishal', 0.052020000),
(345, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Dhaka', 0.075870000),
(346, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Chattogram', 0.059370000),
(347, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Rajshahi', 0.038490000),
(348, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Rangpur', 0.032880000),
(349, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Khulna', 0.032670000),
(350, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Mymensingh', 0.022890000),
(351, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Sylhet', 0.020640000),
(352, 'Stenographer cum Computer Operator', 'Physically Handicapped', 'Barishal', 0.017340000),
(353, 'Stenographer cum Computer Operator', 'Tribal', 'Dhaka', 0.037935000),
(354, 'Stenographer cum Computer Operator', 'Tribal', 'Chattogram', 0.029685000),
(355, 'Stenographer cum Computer Operator', 'Tribal', 'Rajshahi', 0.019245000),
(356, 'Stenographer cum Computer Operator', 'Tribal', 'Rangpur', 0.016440000),
(357, 'Stenographer cum Computer Operator', 'Tribal', 'Khulna', 0.016335000),
(358, 'Stenographer cum Computer Operator', 'Tribal', 'Mymensingh', 0.011445000),
(359, 'Stenographer cum Computer Operator', 'Tribal', 'Sylhet', 0.010320000),
(360, 'Stenographer cum Computer Operator', 'Tribal', 'Barishal', 0.008670000);

-- --------------------------------------------------------

--
-- Table structure for table `post_quota_division_district`
--

CREATE TABLE `post_quota_division_district` (
  `id` int(11) NOT NULL,
  `postName` varchar(200) NOT NULL,
  `quotaName` varchar(200) NOT NULL,
  `divisionName` varchar(200) NOT NULL,
  `districtName` varchar(200) NOT NULL,
  `decimalQuantity` double(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `quotas`
--

CREATE TABLE `quotas` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `percentage` double(5,2) NOT NULL,
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
  ADD PRIMARY KEY (`id`);

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
-- Indexes for table `post_quota`
--
ALTER TABLE `post_quota`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `post_quota_division`
--
ALTER TABLE `post_quota_division`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `post_quota_division_district`
--
ALTER TABLE `post_quota_division_district`
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
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=346;

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
-- AUTO_INCREMENT for table `post_quota`
--
ALTER TABLE `post_quota`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT for table `post_quota_division`
--
ALTER TABLE `post_quota_division`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=361;

--
-- AUTO_INCREMENT for table `post_quota_division_district`
--
ALTER TABLE `post_quota_division_district`
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
