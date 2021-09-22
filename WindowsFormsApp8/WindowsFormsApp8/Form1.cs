using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        Timer timer = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        [Flags]
        enum MouseFlags
        {
            Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
            RightUp = 0x0010, Absolute = 0x8000
        };



        //Excell info 35 97 162
        //Высота 240 прыжки по 20 пунктов
        // Длина 35 прыжки по 65 пунктов
        int Excel_X = 100;
        int Excel_Y = 260;

        const int y_Plus = 65;
        const int x_Plus = 20;


        public void DoSmartBuyOrder(int ItemCount)
        {
            Do_Win();
            int[] ExcelCoords = { Excel_X, Excel_Y };
            int[] ExcelIcon = { 765, 845 };
            int[] AlbionIcon = { 715, 845 };
            System.Threading.Thread.Sleep(MiddlePause());

            MouseMove(ExcelIcon);
            System.Threading.Thread.Sleep(MiddlePause());

            MouseMove(ExcelCoords);
            System.Threading.Thread.Sleep(LowPause());
            Do_CtrlC();
            System.Threading.Thread.Sleep(LowPause());

            MouseMove(AlbionIcon);
            System.Threading.Thread.Sleep(HighPause());

            MouseMoveRandomTemp(PlusCostSmart);
            System.Threading.Thread.Sleep(MiddlePause());
            Do_CtrlV();
            System.Threading.Thread.Sleep(HighPause());

            MouseMoveTemp(CountBox);
            System.Threading.Thread.Sleep(MiddlePause());
            Do_10();
            System.Threading.Thread.Sleep(HighPause());


            MouseMoveRandom(MakeOrder);
            System.Threading.Thread.Sleep(HighPause());

            MouseMoveRandom(YesButton);
            System.Threading.Thread.Sleep(LowPause());
            MouseMoveRandom(YesButton2);
            System.Threading.Thread.Sleep(LowPause());
        }






        public int LowPause()
        {
            return rnd.Next(200, 300);

        }
        public int MiddlePause()
        {
            return rnd.Next(500, 700);

        }
        public int HighPause()
        {
            return rnd.Next(1500, 2000);

        }







        //Sell Buttons
        int[] SellButton_1 = { 1055, 354 };
        int[] SellButton_2 = { 1056, 437 };
        int[] SellButton_3 = { 1054, 510 };
        int[] SellButton_4 = { 1063, 588 };
        int[] SellButton_5 = { 1062, 666 };
        int[] SellButton_6 = { 1058, 749 };

        int[] BuyButton_1 = { 1030, 340 };
        int[] BuyButton_2 = { 1033, 414 };
        int[] BuyButton_3 = { 1054, 488 };
        int[] BuyButton_4 = { 1063, 559 };

        //Buy Order
        int[,] PlusCost = { { 680, 695 }, { 507, 514 } };
        int[,] PlusCostSmart = { { 495, 560 }, { 507, 514 } };

        int[,] PlusCount = { { 690, 700 }, { 475, 485 } };
        int[] PlusCountNoRnd = { rnd.Next(690, 700), rnd.Next(505, 514) };

        int[,] MakeOrder = { { 670, 740 }, { 580, 595 } };
        int[,] YesButton = { { 600, 700 }, { 460, 470 } };
        int[,] YesButton2 = { { 600, 700 }, { 450, 454 } };

        int[] CountBox = { 461, 463 };

        //Main Tier Change
        int[,] MainTier = { { 750, 810 }, { 207, 214 } };
        int[,] MainTier_4 = { { 750, 810 }, { 320, 330 } };
        int[,] MainTier_5 = { { 750, 810 }, { 335, 345 } };
        int[,] MainTier_6 = { { 750, 810 }, { 355, 370 } };
        int[,] MainTier_7 = { { 750, 810 }, { 380, 390 } };
        int[,] MainTier_8 = { { 750, 810 }, { 400, 410 } };

        int[,] MainSubTier = { { 870, 920 }, { 205, 215 } };
        int[,] MainSubTier_0 = { { 870, 920 }, { 250, 260 } };
        int[,] MainSubTier_1 = { { 870, 920 }, { 272, 282 } };

        //Check Black Market
        int[] QualityBox = { 650, 320 };
        int[] CommonQuality = { 657, 342 };
        int[] TierBox = { 408, 323 };
        int[] Tier_4 = { 408, 345 };
        int[] Tier_5 = { 409, 366 };
        int[] Tier_6 = { 410, 385 };
        int[] Tier_7 = { 408, 405 };
        int[] Tier_8 = { 407, 425 };
        int[] SubTierBox = { 539, 323 };
        int[] SubTier_0 = { 540, 345 };
        int[] SubTier_1 = { 541, 365 };
        int[] X_Button = { 752, 248 };


        private void button1_Click(object sender, EventArgs e)
        {
            MouseMove(SellButton_1);
            System.Threading.Thread.Sleep(500);

            CheckItem();

            MouseMove(X_Button);
        }

        // нажмёт CapsLock;
        // 0x11 - Ctrl
        // 0x43 - C button
        // 0x56 - V button
        // 0x30 - 0 button
        // 0x31 - 1 button
        // 0x32 - 2 button
        // 0x02 - keyup, 0 - keydown;
        public void Do_CtrlC()
        {
            keybd_event(0x11, 0, 0, UIntPtr.Zero); 
            System.Threading.Thread.Sleep(30);
            keybd_event(0x43, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x43, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x11, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
        }

        public void Do_CtrlV()
        {
            keybd_event(0x11, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x56, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x56, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x11, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
        }

        public void Do_Win()
        {
            keybd_event(0x5B, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);

            keybd_event(0x5B, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
        }

        public void Do_10()
        {
            keybd_event(0x31, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x31, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x30, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x30, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
        }

        public void Do_20()
        {
            keybd_event(0x32, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x32, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x30, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
            keybd_event(0x30, 0, 0x02, UIntPtr.Zero);
            System.Threading.Thread.Sleep(30);
        }

        public void DoAction(int X, int Y)
        {
            const double dbl_x = 42.68155025;
            const double dbl_y = 75.89257131;

            int x = Convert.ToInt32(X * dbl_x);
            int y = Convert.ToInt32(Y * dbl_y);


            mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
        }

        public void DoActionTemp(int X, int Y)
        {
            const double dbl_x = 42.68155025;
            const double dbl_y = 75.89257131;

            int x = Convert.ToInt32(X * dbl_x);
            int y = Convert.ToInt32(Y * dbl_y);


            mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(43);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
        }

        public void MouseMove(int[] NameOfAction)
        {
            DoAction(NameOfAction[0], NameOfAction[1]);
        }

        public void MouseMoveTemp(int[] NameOfAction)
        {
            DoActionTemp(NameOfAction[0], NameOfAction[1]);
        }

        public void DoAllTiers()
        {
            MouseMove(TierBox);
            System.Threading.Thread.Sleep(500);
            MouseMove(Tier_4);
            System.Threading.Thread.Sleep(500);

            MouseMove(TierBox);
            System.Threading.Thread.Sleep(500);
            MouseMove(Tier_5);
            System.Threading.Thread.Sleep(500);

            MouseMove(TierBox);
            System.Threading.Thread.Sleep(500);
            MouseMove(Tier_6);
            System.Threading.Thread.Sleep(500);

            MouseMove(TierBox);
            System.Threading.Thread.Sleep(500);
            MouseMove(Tier_7);
            System.Threading.Thread.Sleep(500);

            MouseMove(TierBox);
            System.Threading.Thread.Sleep(500);
            MouseMove(Tier_8);
            System.Threading.Thread.Sleep(500);
        }

        public void CheckItem()
        {

            MouseMove(QualityBox);
            System.Threading.Thread.Sleep(500);

            MouseMove(CommonQuality);
            System.Threading.Thread.Sleep(500);

            DoAllTiers();
            System.Threading.Thread.Sleep(500);

            MouseMove(SubTierBox);
            System.Threading.Thread.Sleep(500);

            MouseMove(SubTier_1);
            System.Threading.Thread.Sleep(500);

            DoAllTiers();
            System.Threading.Thread.Sleep(500);

        }





        public void ScrollMouse(double y_old, double y_new)
        {
            const double dbl_x = 42.68155025;
            const double dbl_y = 75.89257131;

            int x = Convert.ToInt32(1080 * dbl_x);
            int y = Convert.ToInt32(y_old * dbl_y);

            mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);

            System.Threading.Thread.Sleep(200);


            x = Convert.ToInt32(1080 * dbl_x);
            y = Convert.ToInt32(y_new * dbl_y);


            mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);

            System.Threading.Thread.Sleep(200);

        }


        public void MouseMoveRandom(int[,] NameOfAction)
        {
            Random randX = new Random();
            Random randY = new Random();

            int x = randX.Next(NameOfAction[0, 0], NameOfAction[0, 1]);
            int y = randY.Next(NameOfAction[1, 0], NameOfAction[1, 1]);


            DoAction(x, y);
        }

        public void MouseMoveRandomTemp(int[,] NameOfAction)
        {
            Random randX = new Random();
            Random randY = new Random();

            int x = randX.Next(NameOfAction[0, 0], NameOfAction[0, 1]);
            int y = randY.Next(NameOfAction[1, 0], NameOfAction[1, 1]);


            DoActionTemp(x, y);
        }

        public void DoBuyOrder(int ItemCount)
        {
            MouseMoveRandom(PlusCost);
            System.Threading.Thread.Sleep(HighPause());

            int[] coords = { rnd.Next(PlusCount[0, 0], PlusCount[0, 1]), rnd.Next(PlusCount[1, 0], PlusCount[1, 1]) };

            for (int i = 1; i < ItemCount; i++)
            {
                MouseMove(coords);
                System.Threading.Thread.Sleep(LowPause());
            }

            System.Threading.Thread.Sleep(MiddlePause());

            MouseMoveRandom(MakeOrder);
            System.Threading.Thread.Sleep(HighPause());

            MouseMoveRandom(YesButton2);
            System.Threading.Thread.Sleep(LowPause());
            MouseMoveRandom(YesButton);
            System.Threading.Thread.Sleep(LowPause());
        }

        public void BuyFullTier(int ItemCount)
        {
            //
            MouseMove(SellButton_1);
            System.Threading.Thread.Sleep(HighPause());
            DoBuyOrder(ItemCount);
            System.Threading.Thread.Sleep(HighPause());

            //
            MouseMove(SellButton_2);
            System.Threading.Thread.Sleep(HighPause());
            DoBuyOrder(ItemCount);
            System.Threading.Thread.Sleep(HighPause());

            //
            MouseMove(SellButton_3);
            System.Threading.Thread.Sleep(HighPause());
            DoBuyOrder(ItemCount);
            System.Threading.Thread.Sleep(HighPause());

            //
            MouseMove(SellButton_4);
            System.Threading.Thread.Sleep(HighPause());
            DoBuyOrder(ItemCount);
            System.Threading.Thread.Sleep(HighPause());

            //
            System.Threading.Thread.Sleep(5000);

        }

        public void Buy_Full_Item()
        {
            //
            //MouseMoveRandom(MainTier);
            //System.Threading.Thread.Sleep(rnd.Next(1515, 1616));
            //MouseMoveRandom(MainTier_4);
            //System.Threading.Thread.Sleep(rnd.Next(1515, 1616));

            //BuyFullTier(7);
            //System.Threading.Thread.Sleep(rnd.Next(1515, 1616));
            

            //
            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(HighPause());
            MouseMoveRandom(MainTier_5);
            System.Threading.Thread.Sleep(HighPause());

            BuyFullTier(7);
            System.Threading.Thread.Sleep(HighPause());


            //
            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(HighPause());
            MouseMoveRandom(MainTier_6);
            System.Threading.Thread.Sleep(HighPause());

            BuyFullTier(3);
            System.Threading.Thread.Sleep(HighPause());


            //
            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(HighPause());
            MouseMoveRandom(MainTier_7);
            System.Threading.Thread.Sleep(HighPause());

            BuyFullTier(2);
            System.Threading.Thread.Sleep(HighPause());

            //
            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(HighPause());
            MouseMoveRandom(MainTier_8);
            System.Threading.Thread.Sleep(HighPause());

            BuyFullTier(1);
            System.Threading.Thread.Sleep(HighPause());

        }




        private void button8_Click(object sender, EventArgs e)
        {
            DoBuyOrder(3);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            BuyFullTier(2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(rnd.Next(456, 789));
            MouseMoveRandom(MainSubTier_0);
            System.Threading.Thread.Sleep(rnd.Next(456, 789));

            Buy_Full_Item();
            System.Threading.Thread.Sleep(rnd.Next(456, 789));


            //
            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(rnd.Next(456, 789));
            MouseMoveRandom(MainSubTier_1);
            System.Threading.Thread.Sleep(rnd.Next(456, 789));

            Buy_Full_Item();
            System.Threading.Thread.Sleep(rnd.Next(456, 789));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            Do_CtrlV();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            Do_CtrlC();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Do_Win();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MouseMove(SellButton_1);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            SmartTier_6();


        }

        public void SmartTier_6()
        {
            Excel_Y = 260;
            Excel_X = 100;


            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(LowPause());

            MouseMoveRandom(MainTier_6);
            System.Threading.Thread.Sleep(LowPause());

            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(LowPause());

            MouseMoveRandom(MainSubTier_0);
            System.Threading.Thread.Sleep(LowPause());

            MouseMove(BuyButton_1);
            System.Threading.Thread.Sleep(MiddlePause());
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(HighPause());

            MouseMove(BuyButton_2);
            System.Threading.Thread.Sleep(MiddlePause());
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(HighPause());

            MouseMove(BuyButton_3);
            System.Threading.Thread.Sleep(MiddlePause());
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(HighPause());

            MouseMove(BuyButton_4);
            System.Threading.Thread.Sleep(MiddlePause());
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
        }
        public void SmartTier_7()
        {

            Excel_Y = 260;
            Excel_X = 165;

            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainTier_7);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier_0);
            System.Threading.Thread.Sleep(345);

            MouseMove(BuyButton_1);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_2);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_3);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_4);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
        }

        public void SmartTier_8()
        {
            Excel_Y = 260;
            Excel_X = 230;


            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainTier_8);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier_0);
            System.Threading.Thread.Sleep(345);

            MouseMove(BuyButton_1);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_2);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_3);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_4);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
        }

        public void SmartTier_51()
        {
            Excel_Y = 260;
            Excel_X = 295;

            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainTier_5);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier_1);
            System.Threading.Thread.Sleep(345);

            MouseMove(BuyButton_1);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_2);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_3);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_4);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
        }

        public void SmartTier_61()
        {
            Excel_Y = 260;
            Excel_X = 350;


            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainTier_6);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier_1);
            System.Threading.Thread.Sleep(345);

            MouseMove(BuyButton_1);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_2);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_3);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_4);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
        }

        public void SmartTier_71()
        {
            Excel_Y = 260;
            Excel_X = 415;


            MouseMoveRandom(MainTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainTier_7);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier);
            System.Threading.Thread.Sleep(345);

            MouseMoveRandom(MainSubTier_1);
            System.Threading.Thread.Sleep(345);

            MouseMove(BuyButton_1);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_2);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_3);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
            System.Threading.Thread.Sleep(5000);

            MouseMove(BuyButton_4);
            System.Threading.Thread.Sleep(456);
            DoSmartBuyOrder(3);
            Excel_Y += x_Plus;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SmartTier_7();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SmartTier_8();

        }

        private void button18_Click(object sender, EventArgs e)
        {
            SmartTier_51();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            SmartTier_61();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            SmartTier_71();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SmartTier_6();
            System.Threading.Thread.Sleep(3000);

            SmartTier_7();
            System.Threading.Thread.Sleep(3000);

            SmartTier_8();
            System.Threading.Thread.Sleep(3000);

            SmartTier_51();
            System.Threading.Thread.Sleep(3000);

            SmartTier_61();
            System.Threading.Thread.Sleep(3000);

            SmartTier_71();
            System.Threading.Thread.Sleep(3000);
        }
    }
}
