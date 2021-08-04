using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LeetCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Stack<int> ans = new();
            int con = 0;
            int conRef = 0;
            Stack<string> conStack = new();
            Stack<string> conStackRef = new();
            RefTest(2, con, ref conRef, conStack, ref conStackRef);
            Console.WriteLine($"第一次次數：\t\t{con}");
            Console.WriteLine($"第一次次數(ref)：\t{conRef}");
            Console.WriteLine($"第一次Stack內容：\t{OutPut(conStack)}");
            Console.WriteLine($"第一次Stack內容(ref)：\t{OutPut(conStackRef)}\n");
            RefTest(3, con, ref conRef, conStack, ref conStackRef);
            // 高度、最小值數大於0，
            //Step(6, 2, 3, ans, con, ref conRef, conStack, ref conStackRef);
            Console.WriteLine($"總執行次數：\t\t{con}");
            Console.WriteLine($"總執行次數(ref)：\t{conRef}");
            Console.WriteLine($"執行完Stack內容：\t{OutPut(conStack)}");
            Console.WriteLine($"執行完Stack內容(ref)：\t{OutPut(conStackRef)}");
            Console.ReadKey();
        }

        private static void RefTest(int num, int con, ref int conRef, Stack<string> conStack, ref Stack<string> conStackRef)
        {
            if (num <= 0) return;
            con++;
            Console.WriteLine($"函數內次數：\t\t{con}");
            // 只改變函數內資料
            conRef++;
            Console.WriteLine($"函數內次數(ref)：\t{conRef}");
            // 改變原始資料

            conStack.Push(num.ToString());
            // 原始Stack資料已被塞入
            conStack = new Stack<string>();
            // 函數內另外建立，因此遞迴內函數只能改變上一層，無法更改到原始資料
            Console.WriteLine($"Stack內容：\t\t{OutPut(conStack)}");

            conStackRef.Push("o");
            // 原始Stack資料已被塞入
            conStackRef = new Stack<string>();
            // 原始Stack資料資料重新建立
            Console.WriteLine($"Stack內容(ref)：\t{OutPut(conStackRef)}\n");
            num--;
            RefTest(num, con, ref conRef, conStack, ref conStackRef);
        }

        private static void Step(int high, int min, int max, Stack<int> ans)
        {
            if (high < min)
            {
                //Console.WriteLine($"樓梯有{high}階，{min}步無法行走");
                //ans.Pop();
            }
            if (high == min)
            {
                ans.Push(min);
                //Console.WriteLine($"樓梯有{high}階，{min}步剛好走一次");
                Console.WriteLine(OutPut(ans));
                //Console.WriteLine("完成");
                ans.Pop();
            }
            else
            {
                for (var i = min; i <= max; i++)
                {
                    if (high - i >= min)
                    {
                        ans.Push(i);
                        //Console.WriteLine($"走{i}步，樓梯還有{high - i}階");
                        Step(high - i, min, max, ans);
                        ans.Pop();
                    }
                    else if (high - i == 0)
                    {
                        ans.Push(i);
                        //Console.WriteLine($"樓梯有{high}階，{i}步剛好走一次");
                        Console.WriteLine(OutPut(ans));
                        //Console.WriteLine("完成");
                        ans.Pop();
                    }
                }
            }
        }

        private static string OutPut<T>(IEnumerable<T> ans)
        {
            if (ans.Any())
            {
                return ans.Aggregate((string)null, (current, i) => current + i + " ").Trim();
            }

            return "";
        }
    }
}