using Listson.Helpers;
using Listson.Management;
using Listson.Models;
using System.Diagnostics;

namespace Listson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            string name;
            double price;
            int stockCount;
            string choose;
            string processor;
            int storageCapacity;
            Category category;
            Store store = new Store();
            do
            {
                Console.WriteLine("***MENYU***\r\n 1. Məhsul əlavə et\r\n 2. Bütün məhsulları gör\r\n 3. Kateqoriyaya görə məhsulları axtar\r\n 4. Məhsul sat (ID daxil edərək)\r\n 5. Noutbuklara endirim tətbiq et\r\n 6. Məhsulu sil\r\n 0. cixis");
                choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Məhsulun adını daxil edin:");
                        name = Console.ReadLine();
                        Console.WriteLine("Məhsulun qiymətini daxil edin:");
                        price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Məhsulun stok sayını daxil edin:");
                        stockCount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kateqoriya seçin: 1. Telefon, 2. Noutbuk, 3. Planşet, 4. Aksesuar");
                        category = new Category();
                        if (category == Category.Phone)
                        {
                            Console.WriteLine("Telefonun kamera megapikselini daxil edin:");
                            int cameraMegaPixel = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Telefonun RAM miqdarını daxil edin:");
                            int ram = Convert.ToInt32(Console.ReadLine());
                            Phone phone = new Phone(cameraMegaPixel, ram, name, price);
                            store.AddProduct(phone);
                        }
                        else if (category == Category.Laptop)
                        {
                            Console.WriteLine("Noutbukun prosessorunu daxil edin:");
                            processor = Console.ReadLine();
                            Console.WriteLine("Noutbukun yaddaş tutumunu daxil edin:");
                            storageCapacity = Convert.ToInt32(Console.ReadLine());
                            Laptop laptop = new Laptop(processor, storageCapacity, name, price);
                            store.AddProduct(laptop);
                        }
                        break;
                    case "2":
                        store.GetAllProducts();
                        break;
                    case "3":
                        Console.WriteLine("Kateqoriya seçin: 1. Telefon, 2. Noutbuk, 3. Planşet, 4. Aksesuar");
                        Category category2 = new Category();
                        store.GetProductsByCategory(category2);
                        break;
                    case "4":
                        Console.WriteLine("Satmaq istediyiniz mehsulun ID'sini daxil edin:");
                        int sellId = Convert.ToInt32(Console.ReadLine());
                        store.SellProductById(sellId);

                        break;
                    case "5":
                        Console.WriteLine("Noutbuklara tətbiq etmək istədiyiniz endirim faizini daxil edin:");
                        double discountPercentage = Convert.ToDouble(Console.ReadLine());
                        store.ApplyDiscountToLaptops(discountPercentage);

                        break;
                    case "6":
                        Console.WriteLine("Silmek istediyiniz mehsulun ID'sini daxil edin:");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                        store.RemoveProductById(removeId);
                        Console.WriteLine("Məhsul ugurla silindi.");
                        break;
                    case "0":
                        isExit = true;
                        break;
                    default:
                        break;
                }
            }
            while (choose != "exit");
        }
    }
}
