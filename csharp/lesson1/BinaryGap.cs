using System;
using System.Collections.Generic;
using System.Linq;

//https://app.codility.com/demo/results/trainingW2TNA5-CST/

namespace lesson1
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solution(1041));
            // solution(1041);
        }

        public static int solution(int N) {
            var result = 0;
            if(N > 0) {
                var output = Convert.ToString(N, 2);
                var gaps = new List<int>();
                var counter = 0;
                foreach (char c in output) {
                    int num = int.Parse(c.ToString());
                    var isZero = num == 0;
                    var isOne = num > 0;

                    if(isZero) {
                        counter++;
                    }

                    if(isOne) {
                        if(counter > 0) {
                            gaps.Add(counter);
                        }
                        counter = 0;
                    }
                }

                if(gaps.Count > 0) {
                    var max = gaps.Select((n, i) => (Number: n, Index: i)).Max();

                    return max.Number;
                } else {
                    return 0;
                }
            }
            return result;
        }
    }
}
