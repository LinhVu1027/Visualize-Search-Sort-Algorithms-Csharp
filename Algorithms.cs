using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment
{
    public partial class Algorithms : Form
    {
        public Algorithms()
        {
            InitializeComponent();
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
        }

        #region KHAI BÁO BIẾN TOÀN CỤC
        TextBox[] node;                         // Mảng chứa TextBox ra màn hình
        TextBox[] node1, node2;                 // Mảng TextBox phụ sau khi cắt ra màn hình 
        Label[] index;                          // Chỉ số dưới cái TextBox
        int[] mainArr, tmpArr1, tmpArr2, h;     // Mảng chứa dữ liệu đầu vào sử dụng cho các thuật toán
        int numOfElement = 0;                   // Số phần tử
        int speed;                              // Tốc độ                
        Boolean checkArray, checkStop = false;  // Biến kiểm tra đã tạo mảng và kiểm tra tạm dừng
        Boolean checkSortStepByStep;            // Biến dùng trong pause;
        int dataSearch;                         // Biến giữ dữ liệu cần tìm
        #endregion

        #region CÁC THUỘC TÍNH ĐỊNH DẠNG NODE
        int distance;   // khoảng cách 2 node liên tiếp
        int margin;     // canh lề node
        int sizeOfNode; // kích thước node
        int sizeOfChar; // kích thước chữ
        #endregion

        #region CÁC HÀM DI CHUYỂN NODE

        /// <summary>
        /// HÀM HOÁN ĐỔI VỊ TRÍ 2 NODE
        /// 1. Node đầu tiên lên, Node tiếp theo xuống
        ///    1. Node đầu tiên đi xuống một khoảng bằng kích thước node + 5px
        ///    2. Node thứ 2 đi lên một khoảng bằng kích thước node + 5px
        /// 2. Nếu node đầu tiên bên trái node thứ 2
        ///    1. Node đầu tiên dịch phải
        ///    2. Node thứ 2 dịch trái
        /// 3. Ngược lại
        /// 4. Node đầu tiên xuống, Node tiếp theo lên, kết thúc quá trình
        /// </summary>
        /// <param name="node1">Node đầu tiên</param>
        /// <param name="node2">Node tiếp theo</param>
        /// <requirement>
        /// Truyền node1 và node2 phai theo đúng thứ tự trong mảng, tức là:
        ///    1. Vị trí node1 bên trái node2 thì mọi hàm swapNode sau node1 bên trái node2
        ///    2. Ngược lại
        /// </requirement>
        public void swapNode(Control node1, Control node2)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                Point p1 = node1.Location; // Lưu vị trí ban đầu của node1
                Point p2 = node2.Location; // Lưu vị trí ban đầu của node2
                if (p1 != p2)
                {
                    // Node đầu tiên lên, Node tiếp theo xuống
                    while ((node1.Location.Y > p1.Y - (sizeOfNode + 5)) || (node2.Location.Y < p2.Y + (sizeOfNode + 5)))
                    {
                        Application.DoEvents();
                        node1.Top -= 1; // Giảm khoảng cách so với bìa trên = đi lên
                        node2.Top += 1; // Tăng khoảng cách so với bìa trên = đi xuống
                        delay(speed);
                    }
                    // Node đầu tiên dịch phải, Node thứ 2 dịch trái
                    if (node1.Location.X < node2.Location.X)
                    {
                        while ((node1.Location.X < p2.X) || (node2.Location.X > p1.X))
                        {
                            Application.DoEvents();
                            node1.Left += 1; // Tăng khoảng cách với bìa trái = dịch phải
                            node2.Left -= 1; // Giảm khoảng cách với bìa trái = dịch trái
                            delay(speed);
                        }
                    }
                    // Node đầu tiên dịch trái, Node thứ 2 dịch phải
                    else
                    {
                        while ((node1.Location.X > p2.X) || (node2.Location.X < p1.X))
                        {
                            Application.DoEvents();
                            node1.Left -= 1; // Giảm khoảng cách với bìa trái = dịch trái
                            node2.Left += 1; // Tăng khoảng cách với bìa trái = dịch phải
                            delay(speed);
                        }
                    }
                    // Node đầu tiên xuống, Node tiếp theo lên, kết thúc quá trình
                    while ((node1.Location.Y < p2.Y) || (node2.Location.Y > p1.Y))
                    {
                        Application.DoEvents();
                        node1.Top += 1; // Tăng khoảng cách so với bìa trên = đi xuống
                        node2.Top -= 1; // Giảm khoảng cách so với bìa trên = đi lên
                        delay(speed);
                    }
                    node1.Refresh();
                    node2.Refresh();
                }
            });

        }

        /// <summary>
        /// HÀM DỊCH CHUYỂN NODE SANG PHẢI
        /// </summary>
        /// <param name="node">Node đàu vào</param>
        /// <param name="step">Hiệu của vị trí node đầu vào và node nó cần đi tới</param>
        public void moveRight(Control node, int step)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loopCount = (sizeOfNode + distance) * step; // Số lần dịch chuyển
                while (loopCount > 0)
                {
                    Application.DoEvents();
                    node.Left += 1; // Di chuyển sang phải
                    delay(speed);
                    loopCount--;
                }
                node.Refresh();
            });
        }

        /// <summary>
        /// HÀM DỊCH CHUYỂN NODE SANG TRÁI
        /// </summary>
        /// <param name="node">Node đầu vào</param>
        /// <param name="step">Hiệu của vị trí node đầu vào và node nó cần đi tới</param>
        public void moveLeft(Control node, int step)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loopCount = ((sizeOfNode + distance)) * step; //Số lần dịch chuyển
                while (loopCount > 0)
                {
                    Application.DoEvents();
                    node.Left -= 1; // Di chuyển sang trái
                    delay(speed);
                    loopCount--;
                }
                node.Refresh();
            });
        }

        /// <summary>
        /// HÀM DỊCH CHUYỂN NODE ĐI LÊN QUÃNG ĐƯỜNG S
        /// </summary>
        /// <param name="node">Node đầu vào</param>
        /// <param name="s">Quãng đường di chuyển lên (thường là hằng số)</param>
        public void moveUp(Control node, int s)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loopCount = s;
                while (loopCount > 0)
                {
                    Application.DoEvents();
                    node.Top -= 1; // Di chuyển lên
                    delay(speed);
                    loopCount--;
                }
                node.Refresh();
            });
        }

        /// <summary>
        /// HÀM DỊCH CHUYỂN NODE ĐI XUỐNG QUÃNG ĐƯỜNG S
        /// </summary>
        /// <param name="node">Node đầu vào</param>
        /// <param name="s">Quãng đường di chuyển xuống (thường là hằng số)</param>
        public void moveDown(Control node, int s)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                int loopCount = s;
                while (loopCount > 0)
                {
                    Application.DoEvents();
                    node.Top += 1; // Di chuyển xuống
                    delay(speed);
                    loopCount--;
                }
                node.Refresh();
            });
        }

        /// <summary>
        /// HÀM DI CHUYỂN NODE TRONG MẢNG PHỤ ĐẾN VỊ TRÍ NODE[I] TRONG MẢNG CHÍNH
        /// 1. Di chuyển node xuống hoặc lên tùy theo mảng phụ
        ///    1. Nếu mảng phụ ở trên, di chuyển node xuống 1/2 khoảng cách từ mảng phụ tới mảng chính
        ///    2. Nếu mảng phụ ở dưới, di chuyển node lên 1/2 khoảng cách từ mảng phụ tới mảng chính
        /// 2. Di chuyển node qua phải hoặc qua trái phụ thuộc tương tác vị trí của node và node muốn tới
        /// 3. Tiếp tục di chuyển nút xuống nữa đường còn lại, kết khúc quá trình
        /// </summary>
        /// <param name="node">Node trong mảng được tạo thành sau khi cắt</param>
        /// <param name="i">Vị trí của node muốn tới trong mảng chính</param>
        public void moveToPos(Control node, int i)
        {
            Point p1 = node.Location;                                        // Lưu lại vị trí của node
            Point p2 = new Point(margin + (sizeOfNode + distance) * i, 150); // Vị trí của node i
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                // Di chuyển node xuống 1/2 khoảng cách node và node[i]
                if (p1.Y < p2.Y)
                {
                    while (node.Location.Y < p2.Y - ((p2.Y - p1.Y) / 2))
                    {
                        Application.DoEvents();
                        node.Top += 1; // Di chuyển xuống
                        node.Refresh();
                        delay(speed);
                    }
                }
                // Di chuyển node lên 1/2 khoảng cách node và node[i]
                else
                {
                    while (node.Location.Y > p2.Y + ((p1.Y - p2.Y) / 2))
                    {
                        Application.DoEvents();
                        node.Top -= 1; // Di chuyển lên
                        node.Refresh();
                        delay(speed);

                    }
                }
                // Di chuyển node qua phải
                if (p1.X < p2.X)
                {
                    while (node.Location.X < p2.X)
                    {
                        Application.DoEvents();
                        node.Left += 1; // Di chuyển qua phải
                        node.Refresh();
                        delay(speed);
                    }
                }
                // Di chuyển node qua trái
                else
                {
                    while (node.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        node.Left -= 1; // Di chuyển qua trái
                        node.Refresh();
                        delay(speed);
                    }
                }
                // Tiếp tục di chuyển nút xuống nữa đường còn lại
                if (p1.Y < p2.Y)
                {
                    while (node.Location.Y < p2.Y)
                    {
                        Application.DoEvents();
                        node.Top += 1; // Di chuyển xuống
                        node.Refresh();
                        delay(speed);
                    }
                }
                // Hoặc tiếp tục di chuyển nút lên nữa đường còn lại
                else
                {
                    while (node.Location.Y > p2.Y)
                    {
                        Application.DoEvents();
                        node.Top -= 1; // Di chuyển lên
                        node.Refresh();
                        delay(speed);
                    }
                }
            });
        }

        /// <summary>
        /// HÀM DỊCH CHUYỂN NODE VỀ VỊ TRÍ NODE[I].X
        /// Di chuyển node qua phải hoặc qua trái phụ thuộc tương tác vị trí của node và node muốn tới
        /// </summary>
        /// <param name="node">Node trong mảng chính</param>
        /// <param name="i">Vị trí của node muốn tới trong mảng phụ</param>
        public void moveToPosX(Control node, int i)
        {
            Point p1 = node.Location; // lưu lại vị trí của t
            Point p2 = new Point(margin + (sizeOfNode + distance) * i, 150);//vị trí của Node i
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                // Di chuyển node qua phải
                if (p1.X < p2.X)
                {
                    while (node.Location.X < p2.X)
                    {
                        Application.DoEvents();
                        node.Left += 1; // Di chuyển sang phải
                        node.Refresh();
                        delay(speed);
                    }
                }
                // Hoặc di chuyển node qua phải
                else
                {
                    while (node.Location.X > p2.X)
                    {
                        Application.DoEvents();
                        node.Left -= 1; // Di chuyển sang trái
                        node.Refresh();
                        delay(speed);
                    }
                }

            });
        }
        #endregion

        #region CÁC HÀM KHÁC

        /// <summary>
        /// HÀM NGỦ
        /// </summary>
        /// <param name="milisecond">Thời gian</param>
        public void sleep(int milisecond)
        {
            int i;
            for (i = 0; i < milisecond; i++)
            {
                Application.DoEvents();
                Thread.Sleep(5);
            }
            Application.DoEvents();
        }

        /// <summary>
        /// HÀM TRÌ HOÃN
        /// </summary>
        /// <param name="milisecond">Thời gian</param>
        public void delay(int milisecond)
        {
            if (tbrSpeed.Value == tbrSpeed.Maximum) //nếu tốc độ max thì ko sleep
            {
                Application.DoEvents();
                return;
            }
            sleep(milisecond);
        }

        /// <summary>
        /// HÀM HOÁN VỊ 2 NODE THÔNG QUA CHỈ SỐ
        /// </summary>
        /// <param name="index1">Chỉ số thứ 1</param>
        /// <param name="index2">Chỉ số thứ 2</param>
        public void swapNodeByIndex(int index1, int index2)
        {
            TextBox tmp = node[index1];
            node[index1] = node[index2];
            node[index2] = tmp;
        }

        /// <summary>
        /// HÀM HOÁN VỊ 2 GIÁ TRỊ
        /// </summary>
        /// <param name="value1">Giá trị 1</param>
        /// <param name="value2">Giá trị 2</param>
        public void swapValue(ref int value1, ref int value2)
        {
            int tmp = value1;
            value1 = value2;
            value2 = tmp;
        }

        //Sắp xếp hoàn thành
        public void finish()
        {
            for (int i = 0; i < numOfElement; i++)
            {
                setColor(node[i], Color.LawnGreen, Color.Black);
            }
            menuSort.Enabled = true;
            menuSearch.Enabled = true;
            menuFile.Enabled = true;
        }

        /// <summary>
        /// HÀM TẠO MẢNG MỘT CHUỖI SỐ HIỆN TRÊN GIAO DIỆN
        /// </summary>
        public void buildArray()
        {
            if ((numOfElement < 2) || (numOfElement > 30))
            {
                //lbl_A.Visible = false;
                MessageBox.Show("2 <= Số Phần Tử <= 30");

                //this.txt_sophantu.Clear();
                checkArray = false;
                return;
            }

            #region THIẾT LẬP THUỘC TÍNH NODE ỨNG VỚI SỐ PHẦN TỬ
            switch (numOfElement)
            {
                case 30:
                case 29:
                case 28:
                case 27:
                case 26:
                    sizeOfNode = 27;
                    sizeOfChar = 10;
                    distance = 6;
                    margin = (1024 - sizeOfNode * numOfElement - distance * (numOfElement - 1)) / 2;
                    break;
                case 25:
                case 24:
                case 23:
                case 22:
                case 21:
                    sizeOfNode = 30;
                    sizeOfChar = 13;
                    distance = 10;
                    margin = (1024 - sizeOfNode * numOfElement - distance * (numOfElement - 1)) / 2;
                    break;
                case 20:
                case 19:
                    sizeOfNode = 40;
                    sizeOfChar = 18;
                    distance = 5;
                    margin = (1024 - sizeOfNode * numOfElement - distance * (numOfElement - 1)) / 2;
                    break;
                case 18:
                case 17:
                case 16:
                    sizeOfNode = 40;
                    sizeOfChar = 18;
                    distance = 10;
                    margin = (1024 - sizeOfNode * numOfElement - distance * (numOfElement - 1)) / 2;
                    break;
                case 15:
                case 14:
                case 13:
                case 12:
                case 11:
                    sizeOfNode = 40;
                    sizeOfChar = 18;
                    distance = 18;
                    margin = (1024 - sizeOfNode * numOfElement - distance * (numOfElement - 1)) / 2;
                    break;
                case 10:
                case 9:
                case 8:
                case 7:
                case 6:
                case 5:
                case 4:
                case 3:
                case 2:
                    sizeOfNode = 50;
                    sizeOfChar = 25;
                    distance = 40;
                    margin = (1024 - sizeOfNode * numOfElement - distance * (numOfElement - 1)) / 2;
                    break;
            }
            #endregion

            #region TẠO CÁC MẢNG DỮ LIỆU
            node = new TextBox[numOfElement];   // Mảng dưới dạng TextBox thể hiện ra màn hình
            index = new Label[numOfElement];    // Chỉ số dưới cái TextBox thể hiện ra màn hình
            #endregion

            #region KHỞI TẠO NODE VÀ CHỈ SỐ RA MÀN HÌNH
            for (int i = 0; i < numOfElement; i++)
            {
                node[i] = new TextBox();
                node[i].Multiline = true;
                node[i].Text = mainArr[i].ToString();
                node[i].TextAlign = HorizontalAlignment.Center;
                node[i].Width = sizeOfNode;
                node[i].Height = sizeOfNode;
                node[i].Location = new Point(margin + (sizeOfNode + distance) * i, 150);
                node[i].BackColor = Color.OrangeRed;
                node[i].ForeColor = Color.White;
                node[i].Font = new Font(this.Font, FontStyle.Bold);
                node[i].Font = new System.Drawing.Font("Arial", sizeOfChar, FontStyle.Bold);
                node[i].ReadOnly = true;
                this.Controls.Add(node[i]);

                index[i] = new Label();
                index[i].TextAlign = ContentAlignment.MiddleCenter;
                index[i].Text = i.ToString();
                index[i].Width = sizeOfNode;
                index[i].Height = sizeOfNode;
                index[i].ForeColor = Color.Purple;
                index[i].Location = new Point(margin + (sizeOfNode + distance) * i, 200 + 3 * sizeOfNode);
                if (numOfElement <= 10)
                    index[i].Font = new System.Drawing.Font("Arial", sizeOfChar - 10, FontStyle.Regular);
                else
                    index[i].Font = new System.Drawing.Font("Arial", sizeOfChar, FontStyle.Regular);
                this.Controls.Add(index[i]);
            }
            #endregion

            checkArray = true; //Xác nhận đã tạo mảng
            //Cho phép các nút điều khiển có tác dụng khi đã tạo mảng
            //btn_Sapxep.Enabled = true;
            //btn_Ngaunhien.Enabled = true;
            //btn_Nhap.Enabled = true;
        }

        /// <summary>
        /// HÀM XÓA MẢNG CHUỖI SỐ HIỂN THỊ TRÊN GIAO DIỆN
        /// </summary>
        public void deleteArray()
        {
            //btn_Nhap.Enabled = false;
            //btn_Ngaunhien.Enabled = false;
            //btn_Sapxep.Enabled = false;
           
            if (checkArray)
            {
                for (int i = 0; i < numOfElement; i++)
                {
                    this.Controls.Remove(node[i]);
                    this.Controls.Remove(index[i]);
                }
                numOfElement = 0;
            }
        }

        /// <summary>
        /// HÀM DỪNG HOẶC CHẠY TOÀN BỘ CHƯƠNG TRÌNH
        /// </summary>
        public void playOrStop()
        {
            while (checkStop)
                Application.DoEvents();
        }

        /// <summary>
        /// HÀM TẠM DỪNG CHƯƠNG TRÌNH
        /// </summary>
        public void pause()
        {
            if (checkSortStepByStep)
            {
                checkStop = true;
                //btn_Dung.Enabled = false;
                playOrStop();
            }
        }

        /// <summary>
        /// HÀM THIẾT LẬP MÀU CHO NODE
        /// </summary>
        /// <param name="node">Node cần được thiết lập màu</param>
        /// <param name="backColor">Màu nền</param>
        /// <param name="foreColor">Màu chữ</param>
        public void setColor(Control node, System.Drawing.Color backColor, System.Drawing.Color foreColor)
        {
            node.BackColor = backColor;
            node.ForeColor = foreColor;
            node.Refresh();
        }
        #endregion

        #region HÀM HỖ TRỢ CLICK VAO FILE->NEW
        /// <summary>
        /// HÀM SAU KHI CLICK VAO MENU FILE NEW
        /// Tạo random số phần tử được nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            deleteArray();
            FileNew fnw = new FileNew();
            fnw.ShowDialog();
            numOfElement = fnw.numOfElement;
            fnw.Close();

            mainArr = new int[numOfElement];
            Random r = new Random();
            for (int i = 0; i < numOfElement; i++)
                mainArr[i] = r.Next(100);
            buildArray();

            menuSearch.Enabled = true;
            menuSort.Enabled = true;
        }
        #endregion

        #region HÀM HỖ TRỢ CLICK VÀO FILE->OPEN

        /// <summary>
        /// HÀM SAU KHI CLICK VÀO MENU FILE OPEN
        /// 1. Xoán biến toàn cục TextBox[] node và Label[] index
        /// 2. Khởi tạo lại số phần tử bằng 0
        /// 3. Lấy đường dẫn đến file
        /// 4. Đọc file: Set vào biến numOfElement, mainArr[];
        /// 5. Xây dựng lại mảng
        ///    1. Xây dựng lại TextBox[] node
        ///    2. Xây dựng lại Label[] index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            deleteArray();                                                      // Xóa mảng lúc trước
            string inputFile = null;                                            // Biến dữ tên file
            Boolean checkError = false;                                         // Kiểm tra file đưa vào đúng định dạng
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open file";
            dlg.Filter = "Text file (*.txt)|*.txt| All file (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputFile = dlg.FileName;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Unable to load file: " + ex.Message);
                    checkError = true;
                    return;
                }
            }
            dlg.Dispose();

            if (!checkError) readText(inputFile);
            buildArray();

            menuSearch.Enabled = true;
            menuSort.Enabled = true;
        }

        /// <summary>
        /// HÀM ĐỌC FILE
        /// </summary>
        /// <param name="path">Đường dẫn đến file cần đọc</param>
        public void readText(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);            // Đối tượng quản lí file
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);     // Đối tượng phục vụ đọc file
            string buf = null;                                                  // Biến giữ giá trị từ file text
            readItem(reader, ref buf); numOfElement = Int32.Parse(buf);         // Đọc số phần tử
            mainArr = new int[numOfElement];
            for (int i = 0; i < numOfElement; i++)
            {
                readItem(reader, ref buf);
                mainArr[i] = Int32.Parse(buf);
            }
            reader.Close();
            stream.Close();
        }

        /// <summary>
        /// HÀM LẤY DỮ LIỆU TỪ FILE TEXT
        /// </summary>
        /// <param name="reader">Đối tượng đọc file</param>
        /// <param name="buf">Biến trả về giá trị đọc được dạng string</param>
        /// <requirement>
        /// File nhận vào sẽ được tách biệt giữa các dấu ','.
        /// Giả sử: , , 5 , 4 , , , 7 , 8, 1 vẫn được hiểu là 5 phần tử
        /// </requirement>
        public void readItem(StreamReader reader, ref String buf)
        {
            char ch = '\0';
            buf = "";                                                   // Thiết lập chuỗi nhập được lúc đầu là rỗng
            while (reader.EndOfStream != true)                          // Nếu chưa tới cuối cùng của file, tiếp tục đọc
            {                                                           // Lặp đọc bỏ các dấu ngăn 
                ch = (char)reader.Read();                               // Đọc 1 ký tự 
                if (ch != ',' && ch != '\r' && ch != '\n')
                    break;                                              // Nếu là ký tự bình thường thì dừng 
            }
            buf += ch.ToString();                                       // Đưa kí tự đọc được vào chuỗi  
            while (reader.EndOfStream != true)                          // Lặp đọc các ký tự của chuỗi dữ liệu
            {
                ch = (char)reader.Read();                               // Đọc 1 ký tự 
                if (ch == ',' || ch == '\r' || ch == '\n')
                    return;                                             // Nếu là dấu ngăn thì dừng 
                buf += ch.ToString();                                   // Chứa ký tự vào bộ đệm 
            }
        } 
        #endregion

        #region HÀM THOÁT KHỎI CHƯƠNG TRÌNH
        /// <summary>
        /// HÀM THOAT KHỎI CHƯƠNG TRÌNH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region CÁC HÀM SẮP XẾP

        /// <summary>
        /// SẮP XẾP INSERTION SORT
        /// </summary>
        public void insertionSort()
        {
            int i, pos, x;
            TextBox tmpNode;
            int tmpIndex;
            int count;

            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 1; i < numOfElement; i++)
                {
                    delay(40 * speed);
                    Application.DoEvents();
                    setColor(node[0], Color.LawnGreen, Color.Black);    // Thiết lập Node đầu tiên, là Node đã có thứ tự 
                    count = 0;                                          // Đếm số bước dịch chuyển 1 Node
                    x = mainArr[i];                                     // Gián giá trị hiện tại cho x 
                    tmpNode = node[i];                                  // Node giá trị hiện tại
                    tmpIndex = i;                                       // Chỉ số hiện tai
                    pos = i - 1;                                        // Chỉ số của nước phía trước
                    Application.DoEvents();                             // Di chuyển Node cần chèn lên
                    this.Invoke((MethodInvoker)delegate
                    {
                        moveUp(tmpNode, (sizeOfNode + 5));
                    });
                    pause();                                            // Tạm dừng sau 1 bước dịch chuyển Node
                    delay(40 * speed);
                    while ((pos >= 0) && (mainArr[pos] > x))
                    {
                        Application.DoEvents();
                        delay(40 * speed);
                        mainArr[pos + 1] = mainArr[pos];                // Dịch chuyển Node qua phải
                        count++;
                        Application.DoEvents();
                        this.Invoke((MethodInvoker)delegate
                        {
                            moveRight(node[pos], 1);
                        });
                        swapNodeByIndex(pos + 1, pos);
                        pos--;
                        mainArr[pos + 1] = x;
                        pause();                                        // Tạm dừng sau 1 bước dịch chuyển Node
                    }
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        moveLeft(tmpNode, count);
                    });
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        moveDown(tmpNode, (sizeOfNode + 5));
                    });
                    node[pos + 1] = tmpNode;                                // Thiết lập node nằm trong nhóm đã có thứ tự
                    setColor(node[pos + 1], Color.LawnGreen, Color.Black);
                    pause();                                                // Tạm dừng sau 1 bước dịch chuyển Node
                }
            });
            finish();
        }

        /// <summary>
        /// SẮP XẾP SELECTION SORT
        /// </summary>
        void selectionSort()
        {
            int min, i, j;

            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < numOfElement - 1; i++)
                {
                    Application.DoEvents();
                    delay(40 * speed);
                    min = i;
                    for (j = i + 1; j < numOfElement; j++)
                    {
                        Application.DoEvents();
                        setColor(node[j], Color.Navy, Color.White);             // Đánh dấu phần tử lúc so sánh với min 
                        delay(40 * speed);
                        setColor(node[j], Color.OrangeRed, Color.White);    // Bỏ đánh dấu sau khi đã có kết quả so sánh

                        if (mainArr[j] < mainArr[min])
                            min = j;
                        pause();
                    }
                    swapValue(ref mainArr[min], ref mainArr[i]);
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        swapNode(node[min], node[i]);
                    });
                    pause();
                    swapNodeByIndex(min, i);
                    setColor(node[i], Color.LawnGreen, Color.Black);        //Thiết lập nút đã có thứ tự
                }
                setColor(node[numOfElement - 1], Color.LawnGreen, Color.Black);  //Thiết lập nút cuối cùng đúng thứ tự

            });
            finish();
        }

        /// <summary>
        /// SẮP XẾP BUBBLE SORT
        /// </summary>
        void bubbleSort()
        {
            int i, j;

            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (i = 0; i < numOfElement - 1; i++)
                {
                    Application.DoEvents();
                    for (j = numOfElement - 1; j > i; j--)
                    {
                        Application.DoEvents();
                        if (mainArr[j] < mainArr[j - 1])
                        {
                            swapValue(ref mainArr[j], ref mainArr[j - 1]);
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                swapNode(node[j], node[j - 1]);
                                pause();
                            });
                            swapNodeByIndex(j, j - 1);
                        }
                    }
                    setColor(node[i], Color.LawnGreen, Color.Black);    // Đặt lại màu cho phần tử đã được sắp xếp
                }
                setColor(node[i], Color.LawnGreen, Color.Black);        // Đặt lại màu cho phần tử cuối
            });
            finish();
        }

        /// <summary>
        /// SẮP XẾP QUICKSORT (ĐỆ QUY)
        /// </summary>
        /// <param name="left">Nửa bên trái</param>
        /// <param name="right">Nửa bên phải</param>
        void quickSort(int left, int right)
        {
            int i, j, x, average;

            x = mainArr[(left + right) / 2];
            average = (left + right) / 2;
            i = left; j = right;
            do
            {
                while (mainArr[i] < x)
                    i++;
                while (mainArr[j] > x)
                    j--;
                if (i <= j)
                {
                    swapValue(ref mainArr[i], ref mainArr[j]);
                    //Tìm vị trí mới của x
                    if (i == average)
                        average = j;
                    else if (j == average)
                        average = i;

                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        swapNode(node[i], node[j]);
                    });
                    pause();
                    swapNodeByIndex(i, j);
                    i++; j--;
                }
            } while (i <= j);
            //Đặt màu nút x
            if (j == 0)
            {
                setColor(node[j], Color.LawnGreen, Color.Black);
            }
            if (i == numOfElement - 1)
            {
                setColor(node[j], Color.LawnGreen, Color.Black);
            }

            if (left < j)
                quickSort(left, j);
            if (i < right)
                quickSort(i, right);
        }

        /// <summary>
        /// HÀM TÌM MIN 2 SỐ, HỖ TRỢ MERGE SORT
        /// </summary>
        /// <param name="a">Tham số đầu tiên</param>
        /// <param name="b">Tham số thứ hai</param>
        /// <returns></returns>
        int min(int a, int b)
        {
            if (a > b)
                return b;
            else
                return a;
        }
        
        /// <summary>
        /// HÀM CHIA MẢNG CHÍNH THÀNH 2 MẢNG PHỤ
        /// </summary>
        /// <param name="nb"></param>
        /// <param name="nc"></param>
        /// <param name="k"></param>
        void distribute(ref int nb, ref int nc, int k)
        {
            int i, pa, pb, pc;
            pa = pb = pc = 0;
            while (pa < numOfElement)
            {
                Application.DoEvents();
                for (i = 0; (pa < numOfElement) && (i < k); i++, pa++, pb++)
                {
                    tmpArr1[pb] = mainArr[pa];
                    node1[pb] = node[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        moveUp(node1[pb], 2 * (sizeOfNode + 5));
                        moveToPosX(node1[pb], pb);
                    });

                    setColor(node1[pb], Color.Navy, Color.White);
                    pause();
                }
                for (i = 0; (pa < numOfElement) && (i < k); i++, pa++, pc++)
                {
                    tmpArr2[pc] = mainArr[pa];
                    node2[pc] = node[pa];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        moveDown(node2[pc], 2 * (sizeOfNode + 5));
                        moveToPosX(node2[pc], pc);
                    });
                    setColor(node2[pc], Color.White, Color.Navy);
                    pause();
                }
            }
            nb = pb;
            nc = pc;
        }

        /// <summary>
        /// HÀM KẾT HỢP 2 MẢNG PHỤ TẠO THÀNH 1 MẢNG CHÍNH
        /// </summary>
        /// <param name="nb"></param>
        /// <param name="nc"></param>
        /// <param name="k"></param>
        void merge(int nb, int nc, int k)
        {
            int pa, pb, pc, ib, ic, kb, kc, lennb, lennc;
            //lưu những giá trị để đếm Node dư   
            lennb = nb;
            lennc = nc;
            pa = pb = pc = 0; ib = ic = 0;
            while ((nb > 0) && (nc > 0))
            {
                Application.DoEvents();
                kb = min(k, nb);
                kc = min(k, nc);
                if (tmpArr1[pb + ib] <= tmpArr2[pc + ic])
                {
                    mainArr[pa] = tmpArr1[pb + ib];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        moveToPos(node1[pb + ib], pa);
                    });
                    setColor(node1[pb + ib], Color.OrangeRed, Color.White);
                    pause();
                    node[pa] = node1[pb + ib];
                    pa++;
                    ib++;
                    if (ib == kb)
                    {
                        for (; ic < kc; ic++)
                        {
                            mainArr[pa] = tmpArr2[pc + ic];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                moveToPos(node2[pc + ic], pa);
                            });
                            setColor(node2[pc + ic], Color.OrangeRed, Color.White);
                            pause();
                            node[pa] = node2[pc + ic];
                            pa++;
                        }
                        pb += kb;
                        pc += kc;
                        ib = ic = 0;
                        nb -= kb;
                        nc -= kc;
                    }
                }
                else
                {
                    mainArr[pa] = tmpArr2[pc + ic];
                    Application.DoEvents();
                    this.Invoke((MethodInvoker)delegate
                    {
                        moveToPos(node2[pc + ic], pa);
                        setColor(node2[pc + ic], Color.OrangeRed, Color.White);
                        pause();
                    });
                    node[pa] = node2[pc + ic];
                    pa++;
                    ic++;
                    if (ic == kc)
                    {
                        for (; ib < kb; ib++)
                        {
                            mainArr[pa] = tmpArr1[pb + ib];
                            Application.DoEvents();
                            this.Invoke((MethodInvoker)delegate
                            {
                                moveToPos(node1[pb + ib], pa);
                            });
                            setColor(node1[pb + ib], Color.OrangeRed, Color.White);
                            pause();
                            node[pa] = node1[pb + ib];
                            pa++;
                        }
                        pb += kb;
                        pc += kc;
                        ib = ic = 0;
                        nb -= kb;
                        nc -= kc;
                    }
                }
            }
            //Di chuyển các Node dư thừa vào vị trí
            for (; nb > 0; nb--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    moveToPos(node1[lennb - nb], pa);
                });
                pause();
                pa++;
            }
            for (; nc > 0; nc--)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    moveToPos(node2[lennc - nc], pa);
                });
                pause();
                pa++;
            }
        }

        /// <summary>
        /// SẮP XẾP MERGE SORT
        /// </summary>
        /// <param name="n"></param>
        void mergeSort(int n)
        {
            int k, nc = 0, nb = 0;
            for (k = 1; k < n; k *= 2)
            {
                distribute(ref nb, ref nc, k);
                merge(nb, nc, k);
            }
            //Sắp xếp hoàn thành
            finish();
        } 
        #endregion

        #region INTERVAL THAY ĐỔI TỐC ĐỘ
        /// <summary>
        /// HÀM XÁC NHẬN THAY ĐỔI TỐC ĐỘ SAU MỖI 1ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrChangeSpeed_Tick(object sender, EventArgs e)
        {
            speed = (tbrSpeed.Maximum - tbrSpeed.Value);    // Giá trị trên thanh tốc độ cao -> giá trị speed thấp -> ngủ nhanh -> chạy nhanh
            lblSpeed.Text = tbrSpeed.Value.ToString();      // Ghi giá trị thể hiện kế bên
        }
        #endregion

        #region XỬ LÍ SORT SAU KHI ĐƯỢC CLICK
        private void menuSortInsertion_Click(object sender, EventArgs e)
        {
            menuFile.Enabled = false;
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
            insertionSort();
        }

        private void menuSortSelection_Click(object sender, EventArgs e)
        {
            menuFile.Enabled = false;
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
            selectionSort();
        }

        private void menuSortBubble_Click(object sender, EventArgs e)
        {
            menuFile.Enabled = false;
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
            bubbleSort();
        }

        private void menuSortQuick_Click(object sender, EventArgs e)
        {
            menuFile.Enabled = false;
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
            quickSort(0, numOfElement - 1);
            finish();
        }

        private void menuSortMerge_Click(object sender, EventArgs e)
        {
            menuFile.Enabled = false;
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
            tmpArr1 = new int[numOfElement];
            tmpArr2 = new int[numOfElement];
            node1 = new TextBox[numOfElement];
            node2 = new TextBox[numOfElement];
            mergeSort(numOfElement);
        }
        #endregion

        #region CÁC HÀM TÌM KIẾM
        
        /// <summary>
        /// HÀM TÌM KIẾM TUYẾN TÍNH
        /// </summary>
        /// <param name="data">Dữ liệu cần tìm</param>
        public void linearSearch(int data)
        {
             Application.DoEvents();
             this.Invoke((MethodInvoker)delegate
             {
                 for (int i = 0; i < numOfElement; i++)
                 {
                     delay(40 * speed);
                     Application.DoEvents();
                     this.Invoke((MethodInvoker)delegate
                     {
                         moveUp(node[i], sizeOfNode + 5);
                     });
                     if (data == mainArr[i])
                     {   
                         setColor(node[i], Color.LawnGreen, Color.Black);
                         delay(40 * speed);
                         Application.DoEvents();
                         this.Invoke((MethodInvoker)delegate
                         {
                             moveDown(node[i], sizeOfNode + 5);
                         });
                         MessageBox.Show("Đã thấy dữ liệu cần tim");
                         return;
                     }
                     delay(40 * speed);
                     Application.DoEvents();
                     this.Invoke((MethodInvoker)delegate
                     {
                         moveDown(node[i], sizeOfNode + 5);
                     });
                 }
                 MessageBox.Show("Không tìm thấy dữ liệu");
                 return;
             });
        }

        public void binarySearch(int head, int tail, int data)
        {
            int average = (tail + head) / 2;
            if (head == tail && data != mainArr[average])
            {
                MessageBox.Show("Không tìm thấy dữ liệu");
                return;
            }
            if (data == mainArr[average])
            {
                for (int n = 0; n < 5; n++)
                {
                    setColor(node[average], Color.LawnGreen, Color.Black);
                    delay(4 * speed);
                    Application.DoEvents();
                    setColor(node[average], Color.OrangeRed, Color.White);
                    delay(4 * speed);
                    Application.DoEvents();
                }
                setColor(node[average], Color.LawnGreen, Color.Black);
                MessageBox.Show("Đã thấy dữ liệu cần tim");
                return;
            }
            else if (data < mainArr[average])
            {
                for (int n = 0; n < 5; n++)
                {
                    for (int k = head; k < average; k++)
                        setColor(node[k], Color.LawnGreen, Color.Black);
                    delay(40 * speed);
                    Application.DoEvents();
                    for (int k = head; k < average; k++)
                        setColor(node[k], Color.OrangeRed, Color.White);
                    delay(40 * speed);
                    Application.DoEvents();
                }
                binarySearch(head, average-1, data);
            }
            else 
            {
                for (int n = 0; n < 5; n++)
                {
                    for (int k = average + 1; k <= tail; k++)
                        setColor(node[k], Color.LawnGreen, Color.Black);
                    delay(40 * speed);
                    Application.DoEvents();
                    for (int k = average + 1; k <= tail; k++)
                        setColor(node[k], Color.OrangeRed, Color.White);
                    delay(40 * speed);
                    Application.DoEvents();
                }
                binarySearch(average + 1, tail, data);
            }
        }

        #endregion

        private void menuSearchLinear_Click(object sender, EventArgs e)
        {
            SearchData sda = new SearchData();
            sda.ShowDialog();
            dataSearch = sda.dataSearch;
            sda.Close();

            menuFile.Enabled = false;
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
            linearSearch(dataSearch);
            menuFile.Enabled = true;
            menuSort.Enabled = true;
            menuSearch.Enabled = true;
        }

        private void binarySearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchData sda = new SearchData();
            sda.ShowDialog();
            dataSearch = sda.dataSearch;
            sda.Close();

            menuFile.Enabled = false;
            menuSort.Enabled = false;
            menuSearch.Enabled = false;
            insertionSort();
            for (int i = 0; i < numOfElement; i++)
                setColor(node[i], Color.OrangeRed, Color.White);
            binarySearch(0, numOfElement-1, dataSearch);
            menuFile.Enabled = true;
            menuSort.Enabled = true;
            menuSearch.Enabled = true;
        }



    } // End of class

}
