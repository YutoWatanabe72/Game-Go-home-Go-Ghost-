-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- ホスト: 127.0.0.1
-- 生成日時: 
-- サーバのバージョン： 10.4.6-MariaDB
-- PHP のバージョン: 7.2.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `techtest`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `gamescore`
--

CREATE TABLE `gamescore` (
  `Id` int(11) NOT NULL,
  `Score` int(11) NOT NULL,
  `Day` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- テーブルのデータのダンプ `gamescore`
--

INSERT INTO `gamescore` (`Id`, `Score`, `Day`) VALUES
(1, 1000, '2019-10-01'),
(2, 2000, '2019-10-01'),
(3, 3000, '2019-10-01'),
(4, 4000, '2019-10-01'),
(5, 5000, '2019-10-01'),
(17, 910, '2019-12-15'),
(18, 2000, '2019-12-15'),
(19, 1110, '2019-12-15'),
(20, 1690, '2019-12-15'),
(21, 15230, '2020-02-11'),
(22, 4210, '2020-02-11'),
(23, 14440, '2020-02-11'),
(24, 800, '2020-02-11'),
(25, 14280, '2020-02-11'),
(26, 10820, '2020-02-11'),
(27, 1010, '2020-02-11'),
(28, 510, '2020-02-12'),
(29, 27010, '2020-02-12'),
(30, 920, '2020-02-12'),
(31, 27830, '2020-02-12'),
(32, 27550, '2020-02-12'),
(33, 30870, '2020-02-12'),
(34, 0, '2020-02-18'),
(35, 30250, '2020-02-27'),
(36, 0, '2020-03-02'),
(37, 960, '2020-03-05'),
(38, 1110, '2020-03-05'),
(39, 940, '2020-03-05'),
(40, 800, '2020-03-05'),
(41, 950, '2020-03-05'),
(42, 6570, '2020-03-05'),
(43, 1230, '2020-03-05'),
(44, 940, '2020-03-05'),
(45, 900, '2020-03-05'),
(46, 1190, '2020-03-05'),
(47, 580, '2020-03-05'),
(48, 4550, '2020-03-05'),
(49, 690, '2020-03-05'),
(50, 12600, '2020-03-05'),
(51, 4180, '2020-03-06'),
(52, 17480, '2020-03-06'),
(53, 21250, '2020-03-06'),
(54, 380, '2020-03-06'),
(55, 600, '2020-03-06'),
(56, 600, '2020-03-06'),
(57, 700, '2020-03-06'),
(58, 19270, '2020-03-12'),
(59, 540, '2020-03-12'),
(60, 30880, '2020-03-12');

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `gamescore`
--
ALTER TABLE `gamescore`
  ADD PRIMARY KEY (`Id`);

--
-- ダンプしたテーブルのAUTO_INCREMENT
--

--
-- テーブルのAUTO_INCREMENT `gamescore`
--
ALTER TABLE `gamescore`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
