using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Stairs(6, 1, 3);
            Console.ReadKey();
        }

        private static void Stairs(int x, int n, int m)
        {
            var ans = new List<int>();
            if (x < n)
            {
                Console.Write("總共走了");
                foreach (var a in ans)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
                Console.WriteLine($"樓梯有{x}階，{n}步無法行走");
                ans.Clear();
            }
            if (x == n)
            {
                ans.Add(x);
                Console.WriteLine($"樓梯有{x}階，{n}步剛好走一次");
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
                    }
                    else
                    {
                        if (x - i == 0)
                        {
                            ans.Add(i);
                            Console.WriteLine($"走了最後{i}步，樓梯還有{x - i}階");
                        }
                        foreach (var a in ans)
                        {
                            Console.Write(a + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine($"樓梯有{x}階，走了{i}步後剩下，{x - i}階無法行走");
                        ans.Clear();
                    }
                }
            }
            foreach (var a in ans)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }

        private static void Step(int x, int n, int m, ref List<int> ans)
        {
            if (x < n)
            {
                Console.Write("總共走了");
                foreach (var a in ans)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
                Console.WriteLine($"樓梯有{x}階，{n}步無法行走");
                ans.Clear();
            }
            if (x == n)
            {
                ans.Add(x);
                Console.WriteLine($"樓梯有{x}階，{n}步剛好走一次");
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
                    }
                    else
                    {
                        if (x - i == 0)
                        {
                            ans.Add(i);
                            Console.WriteLine($"走了最後{i}步，樓梯還有{x - i}階");
                        }
                        foreach (var a in ans)
                        {
                            Console.Write(a + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine($"樓梯有{x}階，走了{i}步後剩下，{x - i}階無法行走");
                        ans.Clear();
                    }
                }
            }
        }
    }
}