using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var ans = new List<int>();
            Step(4, 1, 4, ref ans);
            foreach (var a in ans)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void Step(int x, int n, int m, ref List<int> ans)
        {
            if (x < n)
            {
                Console.WriteLine($"樓梯有{x}階，{n}步無法行走");
                if (ans.Count > 0)
                {
                    ans.RemoveAt(ans.Count - 1);
                }
            }
            if (x == n)
            {
                ans.Add(x);
                Console.WriteLine($"樓梯有{x}階，{n}步剛好走一次");
                foreach (var a in ans)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
                Console.WriteLine("走路完成");
                ans.RemoveAt(ans.Count - 1);
            }
            if (x > n)
            {
                for (var i = n; i <= m; i++)
                {
                    if (x - i >= n)
                    {
                        ans.Add(i);
                        Console.WriteLine($"走{i}步，樓梯還有{x - i}階");
                        Step(x - i, n, m, ref ans);
                        if (ans.Count > 0)
                        {
                            ans.RemoveAt(ans.Count - 1);
                        }
                    }
                    else
                    {
                        if (x - i == 0)
                        {
                            ans.Add(i);
                            Console.WriteLine($"樓梯有{x}階，{i}步剛好走一次");
                            foreach (var a in ans)
                            {
                                Console.Write(a + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine("走路完成");
                            if (ans.Count > 0)
                            {
                                ans.RemoveAt(ans.Count - 1);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"樓梯有{x}階，走了{i}步後剩下，{x - i}階無法行走-清除");
                        }
                    }
                }
            }
        }
    }
}