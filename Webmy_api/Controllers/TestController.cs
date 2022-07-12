using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webmy_api.Controllers
{
    public class TestController : ApiController
    {
        [HttpPost]
        //Работаем через пост и там в body заносим данные,которые хотим поместит в этот метод
        public HttpResponseMessage Mymetod([FromBody] Human human) // public List<Human> Mymetod()
        {
            List<Human> humans = new List<Human>(); // или var numan = new List<Human>();

            //Human human = new Human() { Name = "Lera", Age = 10 };
            //Human human1 = new Human() { Name = "Nata", Age = 39 };
            //var human3 = new Human() { Name = "Dron", Age = 38 };
            //humans.Add(human);
            //humans.Add(human1);
            //humans.Add(human3);



            //humans.Add(new Human() { Name = "Lera", Age = 10 });
            //humans.Add(new Human() { Name = "Nata", Age = 39 });

            if (human != null && human.Age < 20)
            {
              return Request.CreateResponse(HttpStatusCode.Forbidden,"Вот так",Configuration.Formatters.JsonFormatter);
            }
         
            humans.Add(human);
            

            // return humans;
            //как создать джейсончик(JsonFormatter) формат
            return Request.CreateResponse(HttpStatusCode.OK, humans, Configuration.Formatters.JsonFormatter);

        }

        [HttpGet]
        public HttpResponseMessage GetUsers(string name) //  public List<Human> GetUsers(string name)
        {
            List<Human> humans = new List<Human>(); // или var numan = new List<Human>();

            humans.Add(new Human() { Name = "Dron", Age = 38 });
            humans.Add(new Human() { Name = "Nata", Age = 39 });
            humans.Add(new Human() { Name = "Lera", Age = 10 });
            humans.Add(new Human() { Name = "Харьков", Age = 10 });

            //Human human = new Human() { Name = "Lera", Age = 10 };
            //Human human1 = new Human() { Name = "Nata", Age = 39 };
            //var human3 = new Human() { Name = "Компот", Age = 5 };
            //humans.Add(human);
            //humans.Add(human1);
            //humans.Add(human3);

            return Request.CreateResponse(HttpStatusCode.OK, humans, Configuration.Formatters.JsonFormatter);   






        }


        public class Human
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }


        //public class Car
        //{
        //    public int MySpeid { get; set; }
        //    public string MyCar { get; set; }

        //}
        //[HttpPost]
        //public HttpResponseMessage Avto()
        //{
        //    List<Car> cars = new List<Car>();// создаем коллекцию  List типа Car со ссылкой cars
        //    Car car = new Car() { MyCar = "Ваз", MySpeid = 90 };//создаем обьект типа Car со ссылкой car         
        //    cars.Add(car); // добавляем в коллекцию ссылку на обьект типа Car
        //    Car car1 = new Car() { MyCar = "Ланос", MySpeid = 90 };
        //    cars.Add(car1);
        //    return Request.CreateResponse(HttpStatusCode.OK, cars, Configuration.Formatters.JsonFormatter); // возврат коллекции 
        //}

    }
}
