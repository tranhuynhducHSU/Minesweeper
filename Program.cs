using System;
using System.Collections;
using System.Collections.Generic;

namespace domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell[,] table;

            

            Console.WriteLine("Hi there!\nLet play");
            Console.ReadKey();
            Console.WriteLine();
            int a=0, b=0;
            ChoiseTable(a,b);
            table = CreateTable(a, b);

            Address addressFirst;
            System.Console.Write("Open(x,y) x= ");
            addressFirst.x = int.Parse(Console.ReadLine());
            System.Console.Write("Open(x,y) y= ");
            addressFirst.y = int.Parse(Console.ReadLine());

            Address[] addresses = CreateListBomb(a, b,addressFirst);
            table = CreateBombInTable(table, addresses, a, b);
            AddNum(table, a,b);

            //DisplayTest(table, a, b);//test
            System.Console.WriteLine();
            OpenElement(table, a, b);
                

            Console.ReadKey();

        }



        public struct Cell
        {
            public int numBomb;
            public bool isBomb;
            public bool flag;
            public Address address;
            public bool inStack;
        }
        public struct Address
        {
            public int x;
            public int y;
        }
        static Cell[,] CreateTable(int x, int y)
        {
            Cell[,] table = new Cell[x, y];
            return table;
        }
        static void ChoiseTable(int x,int y)
        {
            int temp = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Choise the table you want: \n1. Easy   9 x 9.");
                Console.WriteLine("2. Medium 16x16.");
                Console.WriteLine("3. Expert 30x16.");
                Console.WriteLine("4. Custom.");
                Console.Write("Your choise: ");
                temp =int.Parse(Console.ReadLine());
            } while (temp != 1 && temp != 2 && temp != 3 && temp != 4);
            switch (temp)
            {
                case 1:
                    x = y = 9;
                    break;
                case 2:
                    x = y = 16;
                    break;
                case 3:
                    x =  30;
                    y = 16;
                    break;
                case 4:
                    do
                    {
                        Console.Clear();
                        Console.Write("Width: ");
                        x = int.Parse(Console.ReadLine());
                        Console.Write("Height: ");
                        y = int.Parse(Console.ReadLine());
                    } while (10>x && 10>y);
                    break;
            }

            
        }
        static Address[] CreateListBomb(int x, int y,Address firstAdd)
        {
            int i = 0;
            int Bomb = x * y * 2 / 20;//test
            Random rand = new Random();
            Address[] addresses = new Address[Bomb];
            do
            {
                Address address = new Address();
                address.x = rand.Next(0, x);
                address.y = rand.Next(0, y);
                if (firstAdd.x == address.x && firstAdd.y == address.y)
                {

                }
                else if(NotInToArr(address, addresses) == true )
                {
                    addresses[i] = address;
                    i++;
                }

            } while (i==Bomb);
            return addresses;
        }
        static bool NotInToArr(Address addr, Address[] arrAdd)
        {
            for (int i = 0; i < arrAdd.Length; i++)
            {
                if (arrAdd[i].x != addr.x && arrAdd[i].y != addr.y)
                {
                    return true;
                }
            }
            return false;
        }
        static Cell[,] CreateBombInTable(Cell[,] table, Address[] addresses, int x, int y)
        {
            Address bombAdd;
            for (int i = 0; i < addresses.Length; i++)
            {
                bombAdd = addresses[i];
                table[bombAdd.x, bombAdd.y].isBomb = true;
                table[bombAdd.x, bombAdd.y].numBomb = -1;
                table[bombAdd.x, bombAdd.y].address = bombAdd;
            }
            return table;
        }
        static void Display(Cell[,] table, int x, int y)
        {
            string str = "---";

            Console.Write("     ");
            for (int i = 0; i <= x-1; i++)
            {
                if (i > 9)
                {
                    Console.Write("|"+i);
                }
                else
                {
                    Console.Write("|" + i + " ");
                }
            }

            Console.WriteLine(); ;
            Console.Write("     ");
            for (int i = 0; i <= x-1; i++)
            {
                Console.Write(str);
            }
            Console.WriteLine();
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (j==0)
                    {
                        if(i<10)
                            Console.Write("   "+i+"|");
                        else
                            Console.Write("  " + i + "|");
                    }
                    
                    if (table[i, j].flag == false)//chua mo
                    {
                        System.Console.Write("   ");
                    }
                    if (table[i, j].flag == true)//da mo
                    {
                        
                        int bomb = table[i, j].numBomb;
                        if (bomb == -1)//bomb
                        {
                            System.Console.Write(" * ");
                        }
                        else//so
                        {
                            
                            System.Console.Write(" "+table[i, j].numBomb + " ");
                        }
                    }
                    if (j == x - 1)
                    {
                        Console.Write("|");
                    }
                }
                System.Console.WriteLine();
            }

            Console.Write("     ");
            for (int i = 0; i <= x-1; i++)
            {
                Console.Write(str);
            }
            System.Console.WriteLine();

        }
        static void DisplayTest(Cell[,] table, int x, int y)
        {
            Address address;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    address.x = j;
                    address.y = i;
                    int bomb = table[i, j].numBomb;
                    table[i, j].address = address;
                    if (bomb == -1)
                    {
                        System.Console.Write(" * ");
                    }
                    else
                    {
                        System.Console.Write(" "+table[i, j].numBomb + " ");
                    }

                }
                System.Console.WriteLine();
            }
        }

        static int CreateNumBomb(Cell[,] table, int element, Address[] can8, int w, int h)
        {
            if (element != -1)
            {
                for (int i = 0; i < can8.Length; i++)
                {
                    if (can8[i].x >= 0 && can8[i].x < w && can8[i].y >= 0 && can8[i].y < h)
                    {
                        if (table[can8[i].x, can8[i].y].numBomb == -1)
                        {
                            element++;
                        }
                    }
                }
            }
            return element;
        }
        static Address[] GetCan8(int x, int y)
        {
            Address[] addresses = new Address[8];
            addresses[0] = new Address() { x = x - 1, y = y - 1 };
            addresses[1] = new Address() { x = x, y = y - 1 };
            addresses[2] = new Address() { x = x + 1, y = y - 1 };
            addresses[3] = new Address() { x = x - 1, y = y };
            addresses[4] = new Address() { x = x + 1, y = y };
            addresses[5] = new Address() { x = x - 1, y = y + 1 };
            addresses[6] = new Address() { x = x, y = y + 1 };
            addresses[7] = new Address() { x = x + 1, y = y + 1 };
            return addresses;
        }


        static void AddNum(Cell[,] table, int x, int y)
        {
            int[] can8 = new int[8];
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {

                    table[i, j].numBomb = CreateNumBomb(table, table[i, j].numBomb, GetCan8(i, j), x, y);

                }
            }
        }
        static void OpenElement(Cell[,] table, int a, int b)
        {
            Cell cell;
            int x, y;
            
            System.Console.Write("Open(x,y) x= ");
            y = int.Parse(Console.ReadLine());

            System.Console.Write("Open(x,y) y= ");
            x = int.Parse(Console.ReadLine());
            cell = table[x, y];
            while (cell.flag != false)
            {
                System.Console.WriteLine("Open another. Please!");
                System.Console.Write("Open(x,y) x= ");
                y = int.Parse(Console.ReadLine());
                System.Console.Write("Open(x,y) y= ");
                x = int.Parse(Console.ReadLine());
                cell = table[x, y];
            }

            if (cell.numBomb == 0)//chon o "0"
            {
                table[cell.address.y, cell.address.x].flag = true;
                Loang(table,cell.address);
                Display(table, 15, 15);
                OpenElement(table, x, y);
            }
            else if (cell.numBomb == -1)//chon o "bom"
            {
                cell.flag = true;
                System.Console.WriteLine("BUMMMM, End game");
            }
            else 
            {
                table[cell.address.y, cell.address.x].flag = true;
                Display(table, 15, 15); 
                OpenElement(table, x, y);
             


            }
            if (GameOver(table, a, b) == true)
            {
                Console.WriteLine("Congratulations, You are the winner!!");
                return;
            }
        }
        static public void Loang(Cell[,] table, Address address)
        {
            Stack<Cell> stack = new Stack<Cell>();
            CheckAndPushToStack(address, table, stack,14,14);
            Cell cellTemp;
            while (stack.Count!=0)
            {
                cellTemp = stack.Pop();
                if (cellTemp.flag == false)
                {
                    if (cellTemp.numBomb != 0)//1,2,3,....
                    {
                        table[cellTemp.address.y,cellTemp.address.x].flag = true;

                    }
                    else//0
                    {
                        table[cellTemp.address.y,cellTemp.address.x].flag = true;
                        CheckAndPushToStack(cellTemp.address,table,stack,14,14);

                    }

                }
                
            }
        }
        static void CheckAndPushToStack(Address address,Cell[,] table, Stack<Cell> stack,int sizeX,int sizeY)
        {
            Address[] addresses;
            addresses = GetCan8(address.x,address.y);
            for (int i = 0; i < addresses.Length; i++)
            {
 
                if (!(addresses[i].x < 0 || addresses[i].y < 0 || addresses[i].x > sizeX || addresses[i].y > sizeY || table[addresses[i].y,addresses[i].x].inStack == true)){
                    table[addresses[i].y, addresses[i].x].inStack = true;
                    stack.Push(table[addresses[i].y, addresses[i].x]);
                }
            }
        }
        static bool GameOver(Cell[,] table,int sizeX,int sizeY)
        {
            //bool HasOpen = true;
            for(int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (table[i, j].numBomb != -1)
                    {
                        if (table[i, j].flag == false)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}