if exists(select * from sys.databases where name='LoveShopping')
begin						--检查是否已经存在数据库，如果存在就删除
	use master
	drop database LoveShopping
end
go 

--create database LoveShopping on					--这是在陈宗顺电脑上运行的代码
--(name = LoveShopping,
--filename = 'C:\SQL\LoveShopping.mdf',
--filegrowth = 1,
--size = 3)
--log on(name = LoveShopping_log,
--filename = 'C:\SQL\LoveShopping.ldf',
--filegrowth = 1,
--size = 1)
--go

create database LoveShopping on					--这是在机房运行的代码
(name = LoveShopping,
filename = 'E:\CShar实训商城\LoveShopping.mdf',
filegrowth = 1,
size = 3)
log on(name = LoveShopping_log,
filename = 'E:\CShar实训商城\LoveShopping.ldf',
filegrowth = 1,
size = 1)
go

--varchar(20)  存10个汉字		nvarchar(20) 存20个汉字    varchar和nvarchar的区别


use LoveShopping
go

--开始创建卖家表
if exists(select * from sys.tables where name = 'sellde')
	drop table sellde
create table sellde(
/*卖家标识列		biaoshi int identity(1000,1),*/
/*账号*/			username varchar(20) primary key,
/*密码*/			pwd varchar(20),
/*昵称*/			nicheng varchar(20),
/*真实姓名*/		zhenname varchar(20),
/*头像*/			photo image,
/*性别*/			sex nchar(1),
/*发货地址*/		fahuodizhi varchar(50),
/*余额*/			yue decimal(10,1),
/*身份证号*/		sfzh nvarchar(21),		--21个长度
/*手机号*/			telephone bigint,
/*密保问题*/		mibaowt nvarchar(50),
/*密保答案*/		mibaodan nvarchar(50),
/*注册时间*/		zhucetime datetime)
go
--开始创建商品表
if exists(select * from sys.tables where name = 'commodity')
	drop table commodity
create table commodity(
/*商品ID*/			comid bigint primary key,			--去除 identity(1000,1) 因为添加后会让同一个商品无限添加
/*主人账号*/		username varchar(20),
/*商品名*/			name nvarchar(30),
/*售价*/			shoujia decimal(10,1),
/*运送快递*/		kuadi varchar(10),
/*库存量*/			kucun int,
/*是否包邮*/		isbaoyou nvarchar(1),
/*月销量*/			yuexiaoliang int default 128,
/*添加日期*/		adddatetime datetime,	
/*生产地址*/		scd varchar(30),
/*有无颜色*/		isorcolor nvarchar(100),
/*有无其他*/		isororther nvarchar(100),
/*商品详细说明*/	xiangxi nvarchar(100),
/*浏览图*/			picda image,
/*详图1*/			pic1 image,
/*详图2*/			pic2 image,
/*详图3*/			pic3 image,
constraint spzh foreign key(username) references sellde(username))--表中的username来自于卖家表的username
go
--开始创建买家表
if exists(select * from sys.tables where name = 'buyde')
	drop table buyde
create table buyde(
/*买家标识列		biaoshi int identity(1000,1),*/
/*账号*/			username varchar(20) primary key,
/*密码*/			pwd varchar(20),
/*昵称*/			nicheng varchar(20),
/*真实姓名*/		zhenname varchar(20),
/*头像*/			photo image,
/*性别*/			sex nchar(1),
/*发货地址*/		shouhuodizhi varchar(50),
/*余额*/			yue decimal(10,1),
/*身份证号*/		sfzh nvarchar(21),		--21个长度
/*手机号*/		telephone bigint,
/*密保问题*/		mibaowt nvarchar(50),
/*密保答案*/		mibaodan nvarchar(50),
/*注册时间*/		zhucetime datetime)
go
--开始创建商品订单表
if exists(select * from sys.tables where name='goods')
	drop table goods
create table goods(
/*评价单号*/		pjdh bigint identity(100000,45) primary key,
/*商品id*/			cmid bigint,
/*商品名字*/		comname nvarchar(30),
/*卖家是否查看*/	selldeischakan nvarchar(1),
/*商品图片*/		compic image,
/*卖家账号*/		selledname varchar(20),
/*买家账号*/		buydename varchar(20),
/*付款金额*/		fkje decimal(18, 0),
/*评价内容*/		neirong nvarchar(50),
/*评价星级*/		xingji int check(xingji = 1 or xingji = 2 or xingji = 3 or xingji = 4 or xingji = 5),
/*付款时间*/		fktime datetime,
/*收货时间*/		shtime datetime,
/*评价时间*/		pjtime datetime
--下面三个说明：买家id为买家表中的id，卖家等同，商品id来自商品表的id
constraint sellde_goods_userid foreign key(selledname) references sellde(username),
constraint commodity_goods_commdityid foreign key(cmid) references commodity(comid),
constraint buyde_goods_userid foreign key(buydename) references buyde(username))
go
--开始创建商品颜色分类表
if exists(select * from sys.tables where name='comcolor')
	drop table comcolor
create table comcolor(
comid bigint, 
color nvarchar(20)
constraint commodity_comcolor_comid foreign key(comid) references commodity(comid))	
go
--开始创建商品其他属性表
if exists(select * from sys.tables where name='comorther')
	drop table comorther
create table comorther(
comid bigint, 
orther nvarchar(20)
constraint commodity_comorther_comid foreign key(comid) references commodity(comid))

select * from sellde 

 
 
select * from comcolor	 
--insert comcolor(comid,c1,c2,c3) values(1001,'234','234','234')
select * from comorther
--insert comorther(comid,o1,o2,o3) values(1001,'234','234','234')



--insert commodity(comid,username,name,shoujia,kuadi,kucun,isbaoyou,yuexiaoliang,adddatetime,scd)
--values(1003,'a','小米6Plus',3000,'顺丰',654253502,'是',186110,GETDATE(),'深圳小米')		--没有插入四个图片和颜色分类和其它分类

--select * from commodity where comid=1005	--判断是否已经存在此商品



----下面插入一个只有用户名密码和头像的卖家记录
--insert into sellde(username,pwd,photo) values('a','a','')
----下面插入一个只有用户名密码和头像的买家记录
--insert into buyde(username,pwd,photo) values('b','b','')
--go

--下面插入剩余的卖家字段
update sellde set
nicheng = '小',
zhenname = '顺',
sex='女',
fahuodizhi='湖南省 娄底市 娄星区 娄底职业技术学院',
yue=0,
telephone=110,
mibaowt='我是哪里人？',
mibaodan='湘潭人',
zhucetime=GETDATE(),			--使用数据库中的方法，计算机本地的时间（并非网络上的北京时间）
sfzh='41565644111566541'
where username = 'a'
go
 
--下面插入剩余的买家字段
update buyde set
nicheng = '大',
zhenname = '发',
sex='男',
shouhuodizhi='湖南省 娄底市 娄星区 复健科',
yue=0,
telephone=110,
mibaowt='我在哪？',
mibaodan='娄底',
zhucetime=GETDATE(),			--使用数据库中的方法，计算机本地的时间（并非网络上的北京时间）
sfzh='41565644111566541'
where username = 'b'
go

----插入到商品表
--select * from commodity   --仅仅用作测试，由于图片不能够通过二进制代码执行脚本到数据库所以在C#软件中进行插入图片
--insert commodity values	
--(1001,'a','360N5',1599,'京东',135,'是',888,'2017-03-08','深圳','有','有','商品详细',/*大图 */'',/*详图1*/'',/*详图2*/'',/*详图3*/''),
--(1002,'a','华硕A',7599,'亚马逊',14561,'否',32,'2017-08-08','深圳福田','无','无','商品详细',/*大图*/'',/*详图1*/'',/*详图2*/'',/*详图3*/'')
--go

----插入颜色和其它分类
--insert comcolor values(1001,'红'),(1001,'橙'),(1001,'黄'),(1001,'绿'),(1001,'青')
--insert comorther values(1001,'小号'),(1001,'中号'),(1001,'大号')


go
  
----插入到订单表
--select * from goods
--insert into goods(cmid,selledname,buydename,neirong,xingji,fktime,shtime,pjtime) values	 
--(1001,'a','b','耗电快',4,'2015-05-26','2018-01-05','2017-02-28') 
--go

--查询商品表，额外加上卖家的地址当做发货地址
select c.*,s.fahuodizhi from commodity c join sellde s 
on c.username=s.username
where c.comid=1002
go


select * from sellde 
select * from buyde
select * from goods
select * from commodity
select * from comcolor
select * from comorther
go 

select photo from sellde where username = '1'












 