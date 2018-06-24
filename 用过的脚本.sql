use LoveShopping

select * from sellde 
select * from buyde
select * from goods
select * from commodity
select * from comcolor where comid =12
select * from comorther

select comid from commodity where name = '{0}' and shoujia = {1}and isbaoyou= '{2}' and kuadi = '{3}' and kucun = {4} yuexiaoliang {5} and scd = '{6}'

select top 1 comid from commodity where name = '小' and shoujia = 9.0and isbaoyou= '是' and kuadi = '佳吉快运' and kucun = 699 and yuexiaoliang = 56 and scd = '深圳'

select c.comid 商品id,c.name 商品名,c.shoujia 售价,c.kuadi 快递,c.kucun 库存,
c.isbaoyou 是否包邮,c.yuexiaoliang 月销量,c.adddatetime 添加时间,c.scd 生产地,c.xiangxi 详细信息 from commodity c

comid	username	name	shoujia	kuadi	kucun	isbaoyou	yuexiaoliang	adddatetime	scd	isorcolor	isororther	xiangxi	picda	pic1	pic2	pic3 

select * from comcolor where comid = 1

select * from comorther where comid = 1


update commodity set kucun=@kucun,name=@name,scd=@scd,shoujia=@shoujia,kuadi=@kuadi, adddatetime=@adddatetime,isbaoyou=@isbaoyou,pic1=@pic1,pic2=@pic2,pic3=@pic3,picda=@picda,xiangxi=@xiangxi,isorcolor=@isorcolor,isororther=@isororther where comid = @comid


@kucun   @name    @scd    @shoujia   @kuadi    @adddatetime    @isbaoyou   @pic1   @pic2   @pic3   @picda   @xiangxi   @isorcolor   @isororther   @comid

 
select yue from buyde where username = 'b' 
 
update buyde set yue-=10 where username = 'b'
 
select * from sellde
 
update sellde set yue+=10  where username = 'a'

use LoveShopping

select neirong from goods where pjdh =''

select * from goods

print getdate()

--create procedure doodszongjine @username decimal as
declare @zong decimal
select @zong = @zong + fkje from goods where goods.buydename = 'b' or goods.selledname = 'a'
print @zong 

select sum(fkje) from goods where goods.buydename = 'b' or goods.selledname = 'a'


select xingji from goods where pjdh =

UPDATE goods set xingji = 4 where pjdh = 100540

select sum(fkje) from goods where goods.selledname = 'a'


select nicheng from buyde where username= 'b'

select pwd from sellde where username= 'b'

select mibaodan from buyde where username = ''
select mibaodan from sellde where username = ''