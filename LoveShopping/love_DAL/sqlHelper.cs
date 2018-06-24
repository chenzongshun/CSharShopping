using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;//有关于数据库的操作
using System.Configuration;//配置文件，用来连接数据库名字的
using System.Data;//引用数据
using Microsoft.Office.Interop.Excel;//可以调用Excel程序
using System.IO;//可以使用文件流
using System.Drawing;

using System.Windows.Forms;                     //数据访问层ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString

//SqlConnection Server = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString);
//注意它的配置文件需要app.config，并且需要放到表示

namespace love_DAL
{ 
    /// <summary>
    /// 数据访问层    主要访问数据库    主要执行增删改除  这个方法里面包含了查询数据库是否存在了数据库名、以及增添删减
    /// </summary>
    public class sqlHelper//因为在其他层里面需要访问到这个类，所以前面的访问修饰符要添加一个public
    {
        /// <summary>
        /// 传入一个server连接对象来判断数据库是否已经连接好了，返回true说明连接好了，连接失败会结束程序
        /// </summary>
        /// <param name="Server">数据库对象，</param>
        public static bool ServerConnection(SqlConnection Server)
        { 
            try
            {
                Server.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("请打开数据库连接！", "随笔记提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Windows.Forms.Application.ExitThread();
                return false;
            }
        }

        /// <summary>
        /// 这个方法用执行带参数的SQL查询命令，最后返回读取器的数据
        /// </summary>
        /// <param name="cmdd">代表SQL命令</param>
        /// <param name="p">代表SQL命令参数</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteSelect(string cmdd, SqlParameter[] p)
        {//创建好一个连接对象
            SqlConnection Server = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString);
            if (Server.State == ConnectionState.Closed) Server.Open();
            SqlCommand cmd = new SqlCommand(cmdd, Server);
            if (p != null)//如果参数不是空的话就添加
            {
                foreach (var a in p)
                {
                    cmd.Parameters.Add(a);
                }
            }
            return cmd.ExecuteReader();
        }


        /// <summary>
        /// 能够执行增加、删除、修改并且带参数的SQL命令，可以是存储过程，返回一个执行过后受影响的int行数
        /// </summary>
        /// <param name="cmdd">代表SQL命令</param>
        /// <param name="type">命令的类型</param>
        /// <param name="p">代表SQL命令参数，如果没有参数的话，那么请写null</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdd, CommandType type, SqlParameter[] p)
        {
            SqlConnection Server = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString);
            if (Server.State == ConnectionState.Closed) Server.Open();
            SqlCommand cmd = new SqlCommand(cmdd, Server);

            cmd.CommandType = type;//和上面不同的地方，，，命令的类型

            if (p != null)//如果参数不是空的话就添加
            {
                foreach (SqlParameter a in p)//命令的参数
                {
                    cmd.Parameters.Add(a);
                }
            }
            return cmd.ExecuteNonQuery();//只要是增、删、改都用这个
        }

        /// <summary>
        /// 用来检查时否存在记录,存在的话就返回大于0的int数值
        /// </summary>
        /// <param name="a">查询数据库的语句</param>
        /// <returns></returns>
        public static int ExecutChaXun(string a)
        {
            SqlConnection Server = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString);
            if (Server.State == ConnectionState.Closed) Server.Open();
            SqlDataAdapter ad = new SqlDataAdapter(a, Server);
//Adapter：适配器，，创建一个数据库的适配器，然后把数据库查询语句穿进去，就是a，然后要放到哪个链接对象里面去，也就是server
            DataSet set = new DataSet();//set:集合、数组   单纯的创建一个数据集合
            ad.Fill(set, "e");//然后用适配器的填充方法填充到 set 就是上面的数据集里面去   取名为  e
            return set.Tables["e"].Rows.Count;//数据集中某表的的行数
            //set里面有表，表名为'e'，行数统计总数  把这个数返回去，返回的
        }



        /// <summary>
        /// 用来导出数据库的内容，调用了系统的Excel程序，保存为Excel.xls文件，如果成功的话就返回true
        /// </summary>
        /// <param name="Excel">一个Excel程序Name</param>
        /// <param name="saveDlg">一个保存文件对话框</param>
        /// <param name="Dgv">一个装有数据的DataGridView表格</param>
        public static bool DaoChuExcelApp(Microsoft.Office.Interop.Excel.Application Excel, SaveFileDialog FileDialog, DataGridView Dgv)
        {
            if (Excel == null)
            {
                MessageBox.Show("很抱歉！无法调用Excel程序以此来导出文件，可能你的机器没有安装Excel程序，请安装后再次尝试。", "操作系统没有安装所需的程序", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                Workbooks wkbs = Excel.Workbooks;   //可以说创建一个xls文件
                Workbook wkb = wkbs.Add(XlWBATemplate.xlWBATWorksheet); //创建了一个sheet1表格
                Worksheet wksheet = (Worksheet)wkb.Worksheets[1];   //转换成为worksheet格式，表格sheet1
                for (int i = 0; i < Dgv.ColumnCount; i++)   //ColumnCount:列数
                {   //写入标题行
                    wksheet.Cells[1, i + 1] = Dgv.Columns[i].HeaderText;
                }
                for (int i = 0; i < Dgv.RowCount; i++)      //RowCount:行数
                {   //写入内容
                    for (int j = 0; j < Dgv.Columns.Count; j++)
                    {
                        wksheet.Cells[i + 2, j + 1] = Dgv.Rows[i].Cells[j].Value;   //只有展示在控件上的时候才写tostring();
                        //wksheet.Cells[i + 2, j + 1] = dgv_Display.Rows[i].Cells[j].Value.ToString();
                    }
                    System.Windows.Forms.Application.DoEvents();        //  可以不写，处理当前在消息队列中的所有 Windows 消息。
                }
                wksheet.Columns.EntireColumn.AutoFit();//自动保存文件       可以不写
                if (FileDialog.FileName != null)
                {
                    try
                    {
                        wkb.Saved = true;//不写的话就会自动打开Excel软件询问你是否保存表格
                        wkb.SaveCopyAs(FileDialog.FileName);       //在磁盘上创建文件，不写不创建
                    }
                    catch
                    {
                        MessageBox.Show("导出文件时出错，文件可能正在被打开！");
                    }
                }
                GC.Collect();   // 控制系统垃圾回收器（一种自动回收未使用内存的服务）。  强制对所有代进行即时垃圾回收
                Excel.Quit();   //Quit:离开退出，记得要关闭Excel表格 
                return true;
            }
        }

        /// <summary>
        /// 使用文件流的方式导出为Excel文件，日期列会乱码，把日期列拖宽一点就好，如果成功的话就返回true
        /// </summary>
        /// <param name="sfd">一个保存文件对话框，一个带有数据的DataGridView表格</param>
        /// <param name="Dgv"></param>
        public static bool DaoChuExcelStream(SaveFileDialog sfd, DataGridView Dgv)
        {
            Stream St = sfd.OpenFile();
            StreamWriter Sw = new StreamWriter(St, Encoding.Default);
            string temp = "";
            try
            {
                for (int i = 0; i < Dgv.Columns.Count; i++)
                {
                    temp += Dgv.Columns[i].HeaderText.ToString() + "\t";
                }
                Sw.WriteLine(temp);
                string temp2 = "";
                for (int i = 0; i < Dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < Dgv.Columns.Count; j++)
                    {
                        if (j > 0)
                        {
                            temp2 += "\t";
                        }
                        temp2 += Dgv.Rows[i].Cells[j].Value.ToString();
                    }
                    Sw.WriteLine(temp2);
                    temp2 = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Sw.Close();
                St.Close();
            }
            return true;
        }


 

        /// <summary>
        /// 定义一个可以执行查询命令或者存储过程，并且返回一个数据表DataTable的方法
        /// </summary>
        /// <param name="sql">数据库语句</param>
        /// <param name="commandtype">数据库类型</param>
        /// <param name="paramaters">参数类数组，没有的话那么就可以传入一个null</param>
        /// <returns></returns>
        public static System.Data.DataTable ExecutedataTable(string sql, CommandType commandtype, SqlParameter[] paramaters)
        {
            System.Data.DataTable data = new System.Data.DataTable();//定义一个数据表对象
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = commandtype;//用来指明命令的类型是文本还是存储过程    commandtype是传过来的参数
                    if (paramaters != null)//如果有参数的话那么就循环添加参数进去
                    {
                        foreach (var item in paramaters)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);//
                    //创建一个适配器来执行命令cmd，然后它就持有数据了，因为命令已经有链接对象了，所以不需要写数据库对象了
                    try
                    {
                        da.Fill(data);//适配器有装入方法，把数据装入到上面定义的data这个表里面去
                    }
                    catch (Exception e)
                    {//如果try里面没有出错的话那么才会执行这里面的东西，这个东西是出错的提示
                        throw e;
                    }
                }
            }
            return data;//返回装满数据的data数据表
        }

        //将图片转为二进制存储到数据库
        /// <summary>
        /// 存储图片进入数据库
        /// </summary>
        /// <param name="sql">sql语句</param> 
        /// <param name="pic_photo">图片框</param>
        /// <param name="path">文件路径，注意包含文件名</param>
        public static void imageru(string sql, PictureBox pic_photo, string path)
        {
            SqlConnection Server = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString);
            if (Server.State == System.Data.ConnectionState.Closed) Server.Open();
            SqlCommand cmd = new SqlCommand(sql, Server);
            {
                if (pic_photo.Image == null)//如果没找到图片就插入空值的数据到数据库
                {
                    cmd.Parameters.Add(DBNull.Value);
                }
                else//否则就存储图片到数据库
                {
                    try { if (File.Exists(path)) File.Delete(path); }
                    catch { }//如果文件存在就删除它，否则下面将会冲突 
                    pic_photo.Image.Save(path);//将图片保存到指定路径
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);//创建一个文件流，打开方式为打开，文件访问为读
                    byte[] imab = new byte[fs.Length];//数组的长度等于文件流的长度
                    fs.Read(imab, 0, imab.Length);//文件流读到imgb字节数组里面去，从0开始一直读到最后
                    cmd.Parameters.AddWithValue("@aa", imab);//把图片存储到数据库里面去
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 从数据库中取出图片，然后装入到PictureBox控件中去
        /// </summary>
        /// <param name="sql">查询图片二进制的语句  如：select selldeico from image where selldename='s'</param>
        /// <param name="pic_photo">PictureBox控件name</param>
        public static void imagechu(string sql, PictureBox pic_photo)
        {
            //byte[] image = (byte[])r.Cells[4].Value;
            //MemoryStream ms = new MemoryStream(image, true);
            //pic_photo.Image = Image.FromStream(ms);

            SqlConnection Server = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString);
            if (Server.State == ConnectionState.Closed) Server.Open();
            DataSet ds = new DataSet();//"select selldeico from image where selldename='s'"
            SqlCommand cmd = new SqlCommand(sql, Server);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            byte[] imgb = (byte[])(dr[0]);//把图片值强制转换成为byte类型
            MemoryStream ms = new MemoryStream(imgb, true);//悬浮提示：创建它支持存储区的内存的流    就是支持读取它的文件流 
            pic_photo.Image = System.Drawing.Image.FromStream(ms);
            dr.Close();
        }

        
        /// <summary>
        /// 传入一个数据库图片数组然后装入到图片框里面去
        /// </summary>
        /// <param name="image">数据库数组</param>
        /// <param name="pic_photo">图片name</param>
        public static void imagechu(object image, PictureBox pic_photo)
        {
            byte[] asdf = (byte[])image;
            MemoryStream ms = new MemoryStream(asdf, true);
            pic_photo.Image = Image.FromStream(ms); 
        }

        /// <summary>
        /// 本方法用来备份数据库到指定的文件夹，如果备份成功，将会返回一个bool类型的true
        /// </summary>
        /// <param name="path">输入文件路径，数据库将会备份到此路径</param>
        /// <returns>bool类型</returns> 
        public static bool BackupDateBase(string path)
        {   //using不要打分号。。。
            using (SqlConnection Server = new SqlConnection(ConfigurationManager.ConnectionStrings["LoveShopping"].ConnectionString))
            {   //backup database NoteTaking to disk='D:\Server.mdf'//标准的备份数据库代码
                string sql = string.Format("backup database LoveShopping to disk='{0}'", path);
                using (SqlCommand cmd = new SqlCommand(sql, Server))
                {
                    if (Server.State == ConnectionState.Closed) Server.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                    finally//不管怎么样都要释放掉内存，关闭数据库的链接，以减轻系统的负担
                    {
                        Server.Close();
                        Server.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 本方法传入一个数据库备份文件用来恢复数据库，如果恢复成功，将会返回一个bool类型的true
        /// </summary>
        /// <param name="path">备份的文件路径，包括文件名</param>
        /// <returns>bool类型</returns>
        public static bool RestoreDateBase(string path)
        {
            //因为数据库已经不存在，所以先使用系统的数据库
            using (SqlConnection Server = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True"))
            {
                string sql = string.Format("use master  restore database LoveShopping from disk='{0}' with replace", path);
                using (SqlCommand cmd = new SqlCommand(sql, Server))
                {
                    if (Server.State == ConnectionState.Closed) Server.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
            }
        }
  
        /// <summary>
        /// 传入一个图片框返回一个二进制图片数组
        /// </summary>
        /// <param name="pic">图片框</param>
        /// <param name="path">创建一个临时文件的路径，包含文件名</param>
        /// <returns></returns>
        public static byte[] tiqupic(PictureBox pic,string path)
        { 
            pic.Image.Save(path);//保存图片框，它的路径名字为上面定义的path
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);//创建一个文件流，把这个文件作为流，打开方式为打开，文件的访问权限为阅读
            byte[] image = new byte[fs.Length];//定义一个byte(字节)数组   长度为文件流fs的长度。length：长度
            fs.Read(image, 0, image.Length);//文件流读取到image这个数组里面去,从 0 开始，一直到文件流的最大长度  -- 其实就是读取所有
            fs.Close();//吸取经验，记得关闭，以保证下一次处理文件    关闭文件流
            File.Delete(path);//删除磁盘文件
            return image;//返回二进制图片数组
        }








    }
}