// See https://aka.ms/new-console-template for more information
using System;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Lession_Delegat
{
   
    public  class MyClass
    {
       
        public string ReplaceSpaces(string s)
        {
            Console.WriteLine("Замена пробелов дефисами.");
            return s.Replace(' ', '-');

        }

        public static string ReSpa(string s)
        {
            Console.WriteLine("Замена пробелов звездами.");
            return s.Replace(' ', '*'); 
        } 

        public string RemoveString(string s)
        {
            string str = "";

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


    public class MyClass_Grup
    {
        public static  void ReplaceSpaces_Grup( ref string s)
        {
            Console.WriteLine("Замена пробелов дефисами.");
            s = s.Replace(' ', '-');

        }

        public static void ReSpa_Grup(ref string s)
        {
            Console.WriteLine("Замена пробелов звездами.");
            s = s.Replace(' ', '*');
        }


        public static void Reverse2(ref string s)
        {
            string temp = "";
            int i, j;
            Console.WriteLine("Обращение строки.");
            for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
                temp += s[i];
            s = temp;
        }


        public void RemoveString_Grup(ref string s)
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

           s = str;
        }
    }

    delegate string StrMod(string str);

    delegate void Grup(ref string str);



    class Program
    {

        class MyClass2
        {
            public static string Printf(string s)
            { return s + "*"; }
        }



        static  void Main() 
        {

            //MyClass myClass = new MyClass();
            //StrMod strMod = myClass.ReplaceSpaces;//StrMod strMod = new StrMod(myClass.ReplaceSpaces);
            //string s = strMod("Привет Дрон");
            //Console.WriteLine(s);

            ////  StrMod strMod1 = MyClass.ReSpa;// StrMod strMod1 = new StrMod(MyClass.ReSpa); // StrMod strMod1 = MyClass.ReSpa;
            //s = strMod("Привет Лера");
            //Console.WriteLine(s);

            //strMod = MyClass.ReSpa;

            //s = strMod("Привет Ната");
            //Console.WriteLine(s);

            //strMod = myClass.RemoveString;
            //s = strMod("Привет Ната");
            //Console.WriteLine(s);
            //strMod = Printf2;


            //s = strMod("Чики");
            //Console.WriteLine(s);

            //strMod = RemoveString2;
            //s = strMod("Привет Андрей");
            //Console.WriteLine(s);

            MyClass_Grup grup = new MyClass_Grup();
            Grup? gruppa;
            // метод ReplaceSpaces_Grup замена пробелов дефисов
            Grup? repl = MyClass_Grup.ReplaceSpaces_Grup;
            //Grup resp = MyClass_Grup.ReSpa_Grup;
            //Grup rever = MyClass_Grup.Reverse2;   
            //Удаление пробелов
            Grup? remov =grup.RemoveString_Grup; 
            string? str = "Это простой тест";


           
            //gruppa += repl;
            //gruppa += rever;
            gruppa = remov;
            gruppa += repl;
            gruppa -= remov;

            gruppa(ref ?str);
            Console.WriteLine("Групповая адресация методов: " + str);

            
            //Console.WriteLine("Групповая адресация методов: " + str);











        }


        //Обратить строку.
       




        public static string Printf2(string s)
        { return s + "%"; }


        public static string RemoveString2(string s)
        {
            string str = "";

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



}

















