using Business.Concrete;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("*****************Mevcut arabalar****************");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);

            }





            Console.WriteLine("\n***************** Girilen colorID ile bilgilere ulaşma****************");
            carManager.GetAllByColor(2);




            Console.WriteLine("\n***************** Girilen brandId ile bilgilere ulaşma****************");
            carManager.GetAllByBrand(1);




            Console.WriteLine("\n***************** Girilen CarId ile bilgilere ulaşma****************");

            foreach (var car in carManager.GetAllById(2))
            {
                Console.WriteLine("Girilen araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }





            Car car1 = new Car()
            {
                CarId = 5,
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 52000,
                ModelYear = 2000,
                Description = "Tertemiz pırıl pırıl"
            };
            carManager.Add(car1);

            Console.WriteLine("\n***************** Ekleme yapıldıktan sonraki mevcut arabalar ****************");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
                
            }





            Console.WriteLine("\n***************** Yeni renk ****************");
            Color color1 = new Color()
            {
                ColorId = 3,
                ColorName = "Vişne"
            };
            colorManager.Add(color1);
            Console.WriteLine("Yeni eklenen renk id: {0}  renk adı: {1}", color1.ColorId, color1.ColorName);


            Console.WriteLine("\n***************** renkler ****************");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("renk id: {0}  renk adı: {1}", color.ColorId, color.ColorName);
            }





            Console.WriteLine("\n***************** Araba rengi güncelleme ****************");
            Car car2 = new Car()
            {
                CarId = 5,
                BrandId = 3,
                ColorId = 3,
                DailyPrice = 52000,
                ModelYear = 2000,
                Description = "Tertemiz pırıl pırıl"
            };
            carManager.Update(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }


            Console.ReadKey();
        }
    }
}
