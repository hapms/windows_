using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var 전교생      = Get전교생();
            var 장학생_명단 = new List<string>();

            var 장학생명단_1학년 = 전교생
                                    .학년별(학년:  1)
                                    .석차별(조건: 석차 => 석차 < 3)
                                        .이름만선택();
            var 장학생명단_2학년 = 전교생
                                    .학년별(학년:  2)
                                    .석차별(조건: 석차 => 석차 < 3)
                                        .이름만선택();

            장학생_명단.AddRange(장학생명단_1학년);
            장학생_명단.AddRange(장학생명단_2학년);

            foreach (var 장학생이름 in 장학생_명단)
            {
                Console.WriteLine(장학생이름);
            }
        }

        private static IEnumerable<학생> Get전교생()
        {
            return new [] { 
                new 학생 { 학년 = 1, 학번 = "101", 석차 =  1, 이름 = "가" },
                new 학생 { 학년 = 1, 학번 = "110", 석차 = 10, 이름 = "나" },
                new 학생 { 학년 = 1, 학번 = "120", 석차 = 20, 이름 = "다" },
                new 학생 { 학년 = 2, 학번 = "201", 석차 =  1, 이름 = "라" },
                new 학생 { 학년 = 2, 학번 = "210", 석차 = 10, 이름 = "마" },
                new 학생 { 학년 = 2, 학번 = "220", 석차 = 20, 이름 = "바" },
            };
        }
    }

    public static class 장학생선별기
    {
        public static IEnumerable<학생> 석차별(this IEnumerable<학생> 학생들, Predicate<int> 조건)
        {
            return 학생들.중에서(학 => 조건.Invoke(학.석차));
        }

        public static IEnumerable<학생> 학년별(this IEnumerable<학생> 학생들, int 학년)
        {
            return 학생들.중에서(학 => 학.학년 == 학년);
        }

        public static IEnumerable<string> 이름만선택(this IEnumerable<학생> 학생들)
        {
            return 학생들.뽑는다(학 => 학.이름);
        }
    }

    public class 학생
    {
        public string 학번 { get; set; }

        public string 이름 { get; set; }

        public int 학년 { get; set; }

        public int 석차 { get; set; }
    }

    public static class EnumerableK
    {
        public static IEnumerable<TSource> 중에서<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => source.Where(predicate);

        public static IEnumerable<TResult> 뽑는다<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            => source.Select(selector);
    }
}
