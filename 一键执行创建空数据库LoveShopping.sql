if exists(select * from sys.databases where name='LoveShopping')
begin						--����Ƿ��Ѿ��������ݿ⣬������ھ�ɾ��
	use master
	drop database LoveShopping
end
go 

--create database LoveShopping on					--�����ڳ���˳���������еĴ���
--(name = LoveShopping,
--filename = 'C:\SQL\LoveShopping.mdf',
--filegrowth = 1,
--size = 3)
--log on(name = LoveShopping_log,
--filename = 'C:\SQL\LoveShopping.ldf',
--filegrowth = 1,
--size = 1)
--go

create database LoveShopping on					--�����ڻ������еĴ���
(name = LoveShopping,
filename = 'E:\CSharʵѵ�̳�\LoveShopping.mdf',
filegrowth = 1,
size = 3)
log on(name = LoveShopping_log,
filename = 'E:\CSharʵѵ�̳�\LoveShopping.ldf',
filegrowth = 1,
size = 1)
go

--varchar(20)  ��10������		nvarchar(20) ��20������    varchar��nvarchar������


use LoveShopping
go

--��ʼ�������ұ�
if exists(select * from sys.tables where name = 'sellde')
	drop table sellde
create table sellde(
/*���ұ�ʶ��		biaoshi int identity(1000,1),*/
/*�˺�*/			username varchar(20) primary key,
/*����*/			pwd varchar(20),
/*�ǳ�*/			nicheng varchar(20),
/*��ʵ����*/		zhenname varchar(20),
/*ͷ��*/			photo image,
/*�Ա�*/			sex nchar(1),
/*������ַ*/		fahuodizhi varchar(50),
/*���*/			yue decimal(10,1),
/*���֤��*/		sfzh nvarchar(21),		--21������
/*�ֻ���*/			telephone bigint,
/*�ܱ�����*/		mibaowt nvarchar(50),
/*�ܱ���*/		mibaodan nvarchar(50),
/*ע��ʱ��*/		zhucetime datetime)
go
--��ʼ������Ʒ��
if exists(select * from sys.tables where name = 'commodity')
	drop table commodity
create table commodity(
/*��ƷID*/			comid bigint primary key,			--ȥ�� identity(1000,1) ��Ϊ��Ӻ����ͬһ����Ʒ�������
/*�����˺�*/		username varchar(20),
/*��Ʒ��*/			name nvarchar(30),
/*�ۼ�*/			shoujia decimal(10,1),
/*���Ϳ��*/		kuadi varchar(10),
/*�����*/			kucun int,
/*�Ƿ����*/		isbaoyou nvarchar(1),
/*������*/			yuexiaoliang int default 128,
/*�������*/		adddatetime datetime,	
/*������ַ*/		scd varchar(30),
/*������ɫ*/		isorcolor nvarchar(100),
/*��������*/		isororther nvarchar(100),
/*��Ʒ��ϸ˵��*/	xiangxi nvarchar(100),
/*���ͼ*/			picda image,
/*��ͼ1*/			pic1 image,
/*��ͼ2*/			pic2 image,
/*��ͼ3*/			pic3 image,
constraint spzh foreign key(username) references sellde(username))--���е�username���������ұ��username
go
--��ʼ������ұ�
if exists(select * from sys.tables where name = 'buyde')
	drop table buyde
create table buyde(
/*��ұ�ʶ��		biaoshi int identity(1000,1),*/
/*�˺�*/			username varchar(20) primary key,
/*����*/			pwd varchar(20),
/*�ǳ�*/			nicheng varchar(20),
/*��ʵ����*/		zhenname varchar(20),
/*ͷ��*/			photo image,
/*�Ա�*/			sex nchar(1),
/*������ַ*/		shouhuodizhi varchar(50),
/*���*/			yue decimal(10,1),
/*���֤��*/		sfzh nvarchar(21),		--21������
/*�ֻ���*/		telephone bigint,
/*�ܱ�����*/		mibaowt nvarchar(50),
/*�ܱ���*/		mibaodan nvarchar(50),
/*ע��ʱ��*/		zhucetime datetime)
go
--��ʼ������Ʒ������
if exists(select * from sys.tables where name='goods')
	drop table goods
create table goods(
/*���۵���*/		pjdh bigint identity(100000,45) primary key,
/*��Ʒid*/			cmid bigint,
/*��Ʒ����*/		comname nvarchar(30),
/*�����Ƿ�鿴*/	selldeischakan nvarchar(1),
/*��ƷͼƬ*/		compic image,
/*�����˺�*/		selledname varchar(20),
/*����˺�*/		buydename varchar(20),
/*������*/		fkje decimal(18, 0),
/*��������*/		neirong nvarchar(50),
/*�����Ǽ�*/		xingji int check(xingji = 1 or xingji = 2 or xingji = 3 or xingji = 4 or xingji = 5),
/*����ʱ��*/		fktime datetime,
/*�ջ�ʱ��*/		shtime datetime,
/*����ʱ��*/		pjtime datetime
--��������˵�������idΪ��ұ��е�id�����ҵ�ͬ����Ʒid������Ʒ���id
constraint sellde_goods_userid foreign key(selledname) references sellde(username),
constraint commodity_goods_commdityid foreign key(cmid) references commodity(comid),
constraint buyde_goods_userid foreign key(buydename) references buyde(username))
go
--��ʼ������Ʒ��ɫ�����
if exists(select * from sys.tables where name='comcolor')
	drop table comcolor
create table comcolor(
comid bigint, 
color nvarchar(20)
constraint commodity_comcolor_comid foreign key(comid) references commodity(comid))	
go
--��ʼ������Ʒ�������Ա�
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
--values(1003,'a','С��6Plus',3000,'˳��',654253502,'��',186110,GETDATE(),'����С��')		--û�в����ĸ�ͼƬ����ɫ�������������

--select * from commodity where comid=1005	--�ж��Ƿ��Ѿ����ڴ���Ʒ



----�������һ��ֻ���û��������ͷ������Ҽ�¼
--insert into sellde(username,pwd,photo) values('a','a','')
----�������һ��ֻ���û��������ͷ�����Ҽ�¼
--insert into buyde(username,pwd,photo) values('b','b','')
--go

--�������ʣ��������ֶ�
update sellde set
nicheng = 'С',
zhenname = '˳',
sex='Ů',
fahuodizhi='����ʡ ¦���� ¦���� ¦��ְҵ����ѧԺ',
yue=0,
telephone=110,
mibaowt='���������ˣ�',
mibaodan='��̶��',
zhucetime=GETDATE(),			--ʹ�����ݿ��еķ�������������ص�ʱ�䣨���������ϵı���ʱ�䣩
sfzh='41565644111566541'
where username = 'a'
go
 
--�������ʣ�������ֶ�
update buyde set
nicheng = '��',
zhenname = '��',
sex='��',
shouhuodizhi='����ʡ ¦���� ¦���� ������',
yue=0,
telephone=110,
mibaowt='�����ģ�',
mibaodan='¦��',
zhucetime=GETDATE(),			--ʹ�����ݿ��еķ�������������ص�ʱ�䣨���������ϵı���ʱ�䣩
sfzh='41565644111566541'
where username = 'b'
go

----���뵽��Ʒ��
--select * from commodity   --�����������ԣ�����ͼƬ���ܹ�ͨ�������ƴ���ִ�нű������ݿ�������C#����н��в���ͼƬ
--insert commodity values	
--(1001,'a','360N5',1599,'����',135,'��',888,'2017-03-08','����','��','��','��Ʒ��ϸ',/*��ͼ */'',/*��ͼ1*/'',/*��ͼ2*/'',/*��ͼ3*/''),
--(1002,'a','��˶A',7599,'����ѷ',14561,'��',32,'2017-08-08','���ڸ���','��','��','��Ʒ��ϸ',/*��ͼ*/'',/*��ͼ1*/'',/*��ͼ2*/'',/*��ͼ3*/'')
--go

----������ɫ����������
--insert comcolor values(1001,'��'),(1001,'��'),(1001,'��'),(1001,'��'),(1001,'��')
--insert comorther values(1001,'С��'),(1001,'�к�'),(1001,'���')


go
  
----���뵽������
--select * from goods
--insert into goods(cmid,selledname,buydename,neirong,xingji,fktime,shtime,pjtime) values	 
--(1001,'a','b','�ĵ��',4,'2015-05-26','2018-01-05','2017-02-28') 
--go

--��ѯ��Ʒ������������ҵĵ�ַ����������ַ
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












 