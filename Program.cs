using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace l5t10
{
    /*
     * Внутри класса RandomString создайте и реализуйте метод GetRandomString(), который:
     *      1) Принимает строку в качестве входящего параметра.
     *      2) Возвращает случайную строку, составленную из символов входящей строки.
     *      3) Длина возвращаемой строки должна совпадать с длиной принятой.
     *      4) Символы в разных регистрах считаются различными символами.
     *      5) Каждый раз при вызове этого метода – строка должна быть разной, а случае если
     *         длина принятой строки не позволяет сформировать новую уникальную строку (все варианты исчерпаны),
     *         то длина возвращаемой строки должна увеличиваться в два раза.
     *      6) Возвращает null, если полученная строка пустая или null.
     */

    public class RandomString
    {
        public static void Main(string[] args)
        {
            /* Добавьте свой код ниже */
        }
        public Dictionary<string, MyString> list = new Dictionary<string, MyString>();
        public static Random rnd = new Random();

        public string GetRandomString(string str)
        {
            if (String.IsNullOrEmpty(str)) return null;
            bool status = list.Keys.Contains(str);
            if (status) // если слово уже было введено, проверяем
                        // было исчерпаны ли все возможные комбинации,
                        // если да, то увеличиваем длину строки в 2 раза
            {
                BigInteger numberOfCombinations;

                if (list[str].uniq.Count > 10 && list[str].length > 10)
                {
                    numberOfCombinations = new BigInteger(Math.Pow(10, 10));
                }
                else
                {
                    numberOfCombinations = new BigInteger(Math.Pow(list[str].uniq.Count, (double)list[str].length));
                }
                if (list[str].outPutLines.Count == numberOfCombinations)
                {
                    var newbee = new MyString(str, list[str].count + 1);
                    list.Remove(str);
                    list.Add(str, newbee);
                }

            }
            else // иначе добавляем слово в словарь
            {
                list.Add(str, new MyString(str, 0));
            }

            var arr = list[str].uniq;
            while (true) //бесконечный цикл где рандомно генерируется строка,
                         //если она не содержится в списке уже использованных,
                         //то метод её возвращает в качестве результата
            {
                string res = "";
                for (BigInteger i = 0; i < list[str].length; i++)
                {
                    res += arr[rnd.Next(0, arr.Count)].ToString();
                }

                if (!list[str].outPutLines.Contains(res))
                {
                    list[str].outPutLines.Add(res);
                    return res;
                }
            }


        }

        public struct MyString
        {
            public string s;
            public List<char> uniq;
            public BigInteger length;
            public List<String> outPutLines;
            public int count;

            public MyString(string s, int count) : this()
            {
                this.s = s;
                this.length = s.Length * (BigInteger)Math.Pow(2, count);
                //this.length = s.Length * (BigInteger)(count+1);
                this.outPutLines = new List<string>();
                uniq = new List<char>();
                foreach (var c in s)
                {
                    if (!uniq.Contains(c)) uniq.Add(c);
                }

                this.count = count;
            }
        }
    }
}