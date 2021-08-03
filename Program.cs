using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Stack<int> ans = new();
            // 高度、最小值數大於0，且最大值大於最小值
            Step(4, 2, 6, ref ans);
            Console.ReadKey();
        }

        private static void Step(int high, int min, int max, ref Stack<int> ans)
        {
            if (high < min)
            {
                //Console.WriteLine($"樓梯有{high}階，{min}步無法行走");
                ans.Pop();
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
                        Step(high - i, min, max, ref ans);
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

        private static string OutPut(IEnumerable<int> ans)
        {
            return ans.Aggregate((string)null, (current, i) => current + i + " ").Trim();
        }
    }
}