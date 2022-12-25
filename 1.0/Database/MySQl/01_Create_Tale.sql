create database Algorithms;
use Algorithms;
create table SP_Shortest_Path_Header(
	 algo_id int,
     algo_Type varchar(40),
     algo_Input LONGTEXT,
     algo_Output LONGTEXT,
     primary key(algo_id)
);

create table SP_Routes(
	 route_id int,
	 city_from_code varchar(10),
     city_from_name varchar(40),
     city_to_code varchar(10),
     city_to_name varchar(40),
     distance double(25,10),
     primary key(route_id)
);

create table SP_City_Master(
	city_id int,
    city_code varchar(10),
    city_name varchar(40),
    primary key(city_id)
);