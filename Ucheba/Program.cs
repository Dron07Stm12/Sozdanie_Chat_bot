using System;
using System.Collections;
namespace Ucheba
{
    class Car 
    {
        public string Name { get; set; }
        public int Spied { get; set; }

       

        public Car(string name, int spied)
        {
            Name = name;
            Spied = spied;
        }

       

       
    }
    class Garaz :Car,Iseries,IEnumerable
    {
        private Car[] cars = new Car[4];
        private int i;
        private int statr;



     

       

        //Car this[ object i] {

        //     get { return (Car)i; }
        //     set { i = value; }

        // }



        public Garaz(string name, int spied) : base(name,spied)
        {
            cars[0] = new Car("Жигули", 90);
            cars[1] = new Car("Ланос", 110);
            cars[2] = new Car("AUDI", 150);
            cars[3] = new Car("BMW", 180);
        }

        //public IEnumerator GetEnumerator()
        //{
        //   return cars.GetEnumerator(); 
        //}

        public int GetNext()
        {
          return ++i;
        }

        public void Reset()
        {
            i = statr;
        }

        public void SetStart(int x)
        {
            statr = x;
            i = statr;
        }

        public int GetPrevious()
        {

            return i;
        }

        public IEnumerator GetEnumerator() // используем метод GetEnumerator() интерфейса IEnumerable,который возвращает тип
                                           // IEnumerator(в который входит ряд методов,для того..) - что бы достать через forech
                                           // не явно иницилиpованные обьекты(которые будут иницилизированы при вызове конструктора
        {
            return cars.GetEnumerator(); 
        }

      
    }
    public interface Iseries
    {
        int GetNext();
        void Reset();

        void SetStart(int x);
    
    }

    class MyClass2
    {
        private int[] array = null;
        public bool s = true;
        public MyClass2(int x)
        {
            array = new int[x]; //создание ссылочного обькта(массива),с i размером

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }
                
        }

        public int MyProperty 
        {
            get { return array.Length; }  //   Length - свойство от класса Array
        }


        public override string ToString() // переопределяем базовый метод ToString() для работы с обьектом конкретного члена данного
                                          // класса, чтобы в дальнейшем иметь возможность его индексировать
        {
            if (s)
            {
                string obj = "{" + array[0];

                for (int i = 1; i < array.Length; i++)
                {
                    obj += "," + array[i];
                }

                obj += "}";
                return obj;
            }

            else
            {
                return base.ToString();  
            }

           
        }

        public  int this[int i] // индексатор данного класса для индексирования обьектов этого класса
        {
           get { return array[i]; } // метод возвращает индексируемый обьект(array[i])
            set { array[i] = value; } // метод задает индексируемый обьект(array[i])  
        } 



    }

    class MyClass
        
    {
        public int[] my = {2,2,3,4};
        public bool r = true;
        public int MyProperty { get { return my.Length; } }

        public  int this[int i ]

        { get { return my[i]; }
          set { my[i] = value; }    
        }

        public override string ToString()
        {
            if (r)
            {
                System.String s = "{" + 0;

                for (int i = 0; i < my.Length; i++)
                {
                    s += "," + my[i];
                }
                s += "}";

                return s;
            }


            else
            {
                return base.ToString();
            }




           
        }


    }

     public class Person
    { 
        
        public int Age{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString() //переопределяем обьект типа Person
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }


     }

    public class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();
        // Приведение для вызывающего кода.
        public Person GetPerson(int pos)          // => (Person)arPeople[pos];
        {
            
                return (Person)arPeople[pos];
            

        }
         
        // Вставка только объектов Person.
        public void AddPerson(Person p)
        { arPeople.Add(p); }

        public void ClearPeople()
        { arPeople.Clear(); }

        public int Count //=> arPeople.Count;
        { get { return arPeople.Count; } }

        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator() //=> arPeople.GetEnumerator();
        {
            return  arPeople.GetEnumerator();
        }



    }

    class MyClass3 : IEnumerable
    {
        private MyClass4[] array = new MyClass4[3];


        public MyClass3()
        {
            array[0] = new MyClass4() { FirstName = "Dron", Age = 38 };
            array[1] = new MyClass4() { FirstName = "Nata", Age = 39 };
            array[2] = new MyClass4() { FirstName = "Lera", Age = 10 };
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

       


    }

    class MyClass4
    {

        public int Age { get; set; }
        public string FirstName { get; set; }

        // переобределяем базовый метод ToString(),чтобы экземпляр обьекта  класса MyClass4 представлял конкретно члены этого класса, а не
        // просто пространство имен и класс
        public override string ToString()
        {
            return "имя: " + FirstName + " Возвраст: " + Age;
        }


    }



    internal class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            int[] ints = { 3, 4, 6,0 };   
            Array.Sort<int>(ints);
            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("***");


            MyClass3 myClass3 = new MyClass3();


            foreach (MyClass4 myClass4 in myClass3)// теперь можно итерировать обьекты класса  MyClass3,даже если они располагаются и созданы
                                                   //внутри класса, а не в главном методе Main
            {
                Console.WriteLine(myClass4);
            }

            Console.WriteLine();
            Console.WriteLine("***");

            IEnumerator enumerator = myClass3.GetEnumerator();// создаем ссылку типа IEnumerator, в которую будет присвоено реализация метода
                                                              // GetEnumerator() обьекта класса MyClass3 в которой он определен

            enumerator.MoveNext(); // движение(благодаря методу MoveNext()) по обьектам массива

            MyClass4 myClass44 = (MyClass4)enumerator.Current; // возвращает элемент массива

            Console.WriteLine(" имя: {0} возвраст: {1}", myClass44.FirstName,myClass44.Age);//вывод элемента массива

            enumerator.MoveNext();//и.т.д
            myClass44 = (MyClass4)enumerator.Current;   
            Console.WriteLine(" имя: {0} возвраст: {1}", myClass44.FirstName, myClass44.Age);
            enumerator.MoveNext();
            myClass44 = (MyClass4)enumerator.Current;
            Console.WriteLine(" имя: {0} возвраст: {1}", myClass44.FirstName, myClass44.Age);


            Console.WriteLine();
            Console.WriteLine("***");

            PersonCollection personCollection = new PersonCollection(); // создаем обьект коллекции
            personCollection.AddPerson(new Person("Dron","Laushkin",38));
            personCollection.AddPerson(new Person("Nata", "Lauchkina", 39));
            personCollection.AddPerson(new Person("Lera", "Lauchkina", 10));

            foreach (var item in personCollection)
            {
                Console.WriteLine(item);
            }


            //String
            //char[] sim = { 'Я', ' ', 'и', 'з', '.', 'Я', 'з', 'ы', 'к', ' ', 'C', '#' };
            //string s = new String(sim, 5, 6); //создаем текстовый обьект на основе символьного массива - вызывается конструктор класса  String(s2)
            //Console.WriteLine(s);
            //Console.WriteLine("Я: \"{0}\"", s);


            ArrayList arrayList = new ArrayList();
           // Хотя здесь числовые данные напрямую передаются методам, которые требуют эк¬
           //земпляров типа object, исполняющая среда выполняет автоматическую упаковку таких
           //основанных на стеке данных.Когда позже понадобится извлечь элемент из ArrayList
           //с применением индексатора типа, находящийся в куче объект должен быть распакован
           //в целочисленное значение, расположенное в стеке, посредством операции приведения.
           //Не забывайте, что индексатор ArrayList возвращает элементы типа System.Object, а
           //не System.Int32:

            arrayList.Add(10);
            arrayList.Add(20);
            arrayList.Add(34);

            

            int i = (int)arrayList[0];
            
            Console.WriteLine(i);
           
           

            // упаковка распаковка
            //int i = 25;
            //object obj = i;

            //// int i2 = (int)obj;

            //// System.InvalidCastException

            //try
            //{
            //    long y = (long)obj;
            //}
            //catch (System.InvalidCastException e)
            //{
            //    Console.WriteLine(e.Message);

            //}

            //finally
            //{ Console.WriteLine("Unable to cast object of type 'System.Int32' to type 'System.Int64'"); }


            //string s2 = new string('#',7);
            //Console.WriteLine(s2);
            //string s3 = String.Copy(s2);
            //Console.WriteLine(s3);

            //string s4 = new string("C#");
            //Console.WriteLine(s4);  


            //MyClass myClass = new MyClass();

            //Console.WriteLine(myClass);
            //for (int i = 0; i <myClass.MyProperty; i++)
            //{

            //    Console.Write(myClass[i] = i);
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(myClass);

            //Garaz garaz = new Garaz(null, default);
            //foreach (Car item in garaz)
            //{
            //    Console.WriteLine("Авто: {0}, скорость: {1}", item.Name, item.Spied);
            //}
            //Console.WriteLine("***");
            //Car[] garazs = { new Garaz("Гараж", 1), new Car("Car", 1) };
            //foreach (var item in garazs)
            //{
            //    Console.WriteLine(item.Name + " " + item.Spied);
            //}
            //Console.WriteLine("***");

            //Console.WriteLine();

            //MyClass2 myClass2 = new MyClass2(7);
            ////  myClass2.s = false;       
            //Console.WriteLine(myClass2); // благодаря переопределению базового метода ToString() - ссылка(myClass2) на обьект у нас представляет
            //                             // как бы значение всех ячеек массива, что потом благодаря индексации мы сможем заполнить  массив данного
            //                             // класса
            //for (int i = 0; i < myClass2.MyProperty; i++)
            //{
            //    myClass2[i] = (i * 2) +1;
            //}
            //Console.WriteLine(myClass2);
            //for (int i = 0; i < myClass2.MyProperty; i++)
            //{
            //    Console.Write(" " + myClass2[i]);
            //}

            //Console.WriteLine();



        }
    }
}
