using System;

namespace Console_delegate
{

    public class MyClass
    {
       
        public string RemoveString(ref string s)
        {
            string str = "";
            Console.WriteLine("Удаление пробелов");

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    str += s[i];
                }
            }

         return str;
        }
    }

    delegate string StrMod(ref  string str);

    delegate void Grup(ref string str);

    public class X
    {

        public int Val; 
    }

    public class Y : X
    {

    }

    public class Z : Y  
    { }

    delegate X Gibciy (Y obj);
    delegate Y Gibciy2(Z obj2);

    public class CoContraVariance
    {
        public  static X Foo_X(X obj)
        {
            X x = new X();
            x.Val = obj.Val + 5;
            return x; 
        
        }   

        public  static Y Foo_Y(Y obj)
        {
          Y y = new Y();    
          y.Val = obj.Val + 3;
          return y;  

        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Иницилизируем  делегат с помощью создания экземпляра обьекта через конструктор
            StrMod strMod = new StrMod(ReplaceSpaces);
            string str = "Дрон переньен";
            Console.WriteLine(strMod(ref str));
            //начиная с c#2 можно по проще присвоить имя метода делегату
            strMod =  ReSpa;
            string s = strMod(ref str);
            Console.WriteLine(s);   
            // можно и через экземпляр класса
            MyClass myClass = new MyClass();
            strMod = myClass.RemoveString;
            Console.WriteLine(strMod(ref str));
            Console.WriteLine("**");
            //создаем цепочку делегатов и далее добавляем и убавляем
            StrMod grup;
            StrMod strMod1 = ReplaceSpaces;
            StrMod strMod2 =  ReSpa;
            StrMod strMod3 = Reverse;
            grup = strMod1;
            grup += strMod2;
            Console.WriteLine(grup(ref str));
            Console.WriteLine("**");

            grup -= strMod2;         
            Console.WriteLine(grup(ref str));
            Console.WriteLine("**");

            grup += strMod2;
            grup += strMod3;
            Console.WriteLine(grup(ref str));

            // Продемонстрировать ковариантность и контравариантность. 
            // Создаем обьект типа Y со ссылкой job
            Y job = new Y();
            // Сконструировать делегат и передаем метод   Foo_X делегату  Gibciy gibciy(  delegate X Gibciy (Y obj))
            Gibciy gibciy = CoContraVariance. Foo_X;
            // и  так как класс Y является наследником класса X, то ссылка типа класса Y может передаваться
            // методу Foo_X, который используется делегатом.
            X x = gibciy(job);
            Console.WriteLine("x: " + x.Val);

            gibciy = CoContraVariance.Foo_Y;
            x = gibciy(job);
            Console.WriteLine("x: " + x.Val);
            

            // Z z = new Z();  

            //gibciy = CoContraVariance.Foo_Y;
            // x = gibciy(z);
            //Console.WriteLine("x: " + x.Val);

            //Gibciy2 gibciy2 = CoContraVariance.Foo_Y;
            //job = gibciy2(z);
            //Console.WriteLine("x:" + job.Val);  

            //job = (Y) gibciy(job);
            //Console.WriteLine("x:" + job.Val);
            
        }

        public static string ReplaceSpaces(ref string s)
        {
            Console.WriteLine("Замена пробелов дефисами.");
            s = s.Replace(' ', '-');
            return s;   

        }

        public static string ReSpa(ref string s)
        {
            Console.WriteLine("Замена пробелов звездами.");
            s = s.Replace(' ', '*');
            return s;   
        }

        public static string Reverse(ref string s)
        {
            string temp = "";
            int i, j;
            Console.WriteLine("Обращение строки.");
            for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
                temp += s[i];
           return temp; 
        }


    }
}
