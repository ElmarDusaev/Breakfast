using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Models
{
    /// <summary>
    /// Инициализация первичными данными
    /// </summary>
    public class BreakfasDbInitizalize
    {
        private ModelBuilder modelBuilder;

        public BreakfasDbInitizalize(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        internal void AddCategory()
        {
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, Name = "#Завтраки" },
                new Category { Id = 2, Name = "#Десерты" },
                new Category { Id = 3, Name = "#Соки" },
                new Category { Id = 4, Name = "#Хлеб" }
                );
        }

        internal void AddProducts()
        {

            #region Завтраки
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Яичница в хлебе",
                    Price = 90,
                    IsHit = true,
                    Stars = 4.9,
                    Status = ProductStatus.Active,
                    Image = "https://i.ytimg.com/vi/s0L8hrM6dXw/maxresdefault.jpg"
                },

                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Яичница по‑французски",
                    Price = 100,
                    IsHit = false,
                    Stars = 4.6,
                    Status = ProductStatus.Active,
                    Image = "https://foodandmood.com.ua/i/70/97/05/709705/gallery/e6a40ddde8c4b09d1c72dcdaae662a96-quality_75Xresize_1Xallow_enlarge_0Xw_700Xh_700.jpg"
                },

                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Яичница в помидоре",
                    Price = 110,
                    IsHit = false,
                    Stars = 4.4,
                    Status = ProductStatus.Active,
                    Image = "https://img1.liveinternet.ru/images/attach/d/0/143/161/143161575_6425626_zavtrak_za_20_min_1.jpg"
                },

                new Product
                {
                    Id = 4,
                    CategoryId = 1,
                    Name = "Бульбяная яичница",
                    Price = 135,
                    IsHit = false,
                    Stars = 4.2,
                    Status = ProductStatus.Active,
                    Image = "https://elisheva.ru/uploads/posts/2016-11/1478615735_nezhnyi-omlet-s-gribami-i-syrom.jpg"

                },

                new Product
                {
                    Id = 5,
                    CategoryId = 1,
                    Name = "Яичница в перце",
                    Price = 125,
                    IsHit = false,
                    Stars = 4.1,
                    Status = ProductStatus.Active,
                    Image = "https://moi-kulinar.ru/uploads/posts/2018-07/1530946713_yaichnitsa-v-pertse.jpg"
                },

                new Product
                {
                    Id = 6,
                    CategoryId = 1,
                    Name = "Яичница в помидорах",
                    Price = 220,
                    IsHit = false,
                    Stars = 4.2,
                    Status = ProductStatus.Active,
                    Image = "https://omj.ru/wp-content/uploads/2017/04/4a1fa458fea1c74302fb2bf21b661a81.jpg"
                },

                new Product
                {
                    Id = 7,
                    CategoryId = 1,
                    Name = "Яичница по‑французски в хлебе",
                    Price = 185,
                    IsHit = false,
                    Stars = 4.3,
                    Status = ProductStatus.Active,
                    Image = "https://foodman.club/wp-content/uploads/2017/10/21-5.jpg"
                },

                new Product
                {
                    Id = 8,
                    CategoryId = 1,
                    Name = "Яичница со сметаной",
                    Price = 200,
                    IsHit = false,
                    Stars = 4.1,
                    Status = ProductStatus.Active,
                    Image = "https://cs8.pikabu.ru/post_img/2017/04/05/4/1491367487164439680.png"
                },

                new Product
                {
                    Id = 9,
                    CategoryId = 1,
                    Name = "Яичница-глазунья",
                    Price = 185,
                    IsHit = false,
                    Stars = 4.4,
                    Status = ProductStatus.Active,
                    Image = "https://fannykitchen.com/image/ing/2299.jpg"
                },

                new Product
                {
                    Id = 10,
                    CategoryId = 1,
                    Name = "Яичница-болтунья со шпинатом",
                    Price = 140,
                    IsHit = false,
                    Stars = 4.5,
                    Status = ProductStatus.Active,
                    Image = "https://cdn.segodnya.ua/img/article/11299/45_main_new.1523463015.jpg"
                },

                new Product
                {
                    Id = 11,
                    CategoryId = 1,
                    Name = "Яичница-болтунья",
                    Price = 150,
                    IsHit = false,
                    Stars = 4.7,
                    Status = ProductStatus.Active,
                    Image = "https://www.owoman.ru/assets/images/cook/boltunya_iz_yaic2.jpg"
                },

                new Product
                {
                    Id = 12,
                    CategoryId = 1,
                    Name = "Яичница с брынзой",
                    Price = 145,
                    IsHit = false,
                    Stars = 4.8,
                    Status = ProductStatus.Active,
                    Image = "https://imgtest.mir24.tv/uploaded/images/crops/2018/October/870x489_1x1_detail_crop_c2325328884af7e2fee9343cbbe83a13f13d6a347fd4b10a5b98255587d6845f.jpg"
                },

                new Product
                {
                    Id = 13,
                    CategoryId = 1,
                    Name = "Взбитая яичница",
                    Price = 135,
                    IsHit = false,
                    Stars = 4.9,
                    Status = ProductStatus.Active,
                    Image = "https://foodmag.me/wp-content/uploads/2017/05/yaichnitsa-v-pertsah-1.jpg"
                },

                new Product
                {
                    Id = 14,
                    CategoryId = 1,
                    Name = "Яичница по‑баскски",
                    Price = 210,
                    IsHit = false,
                    Stars = 4.2,
                    Status = ProductStatus.Active,
                    Image = "https://foodmag.me/wp-content/uploads/2017/05/yaichnitsa-v-pertsah-1-650x450.jpg"
                },

                new Product
                {
                    Id = 15,
                    CategoryId = 1,
                    Name = "Яичница по‑кончаловски",
                    Price = 150,
                    IsHit = false,
                    Stars = 4.3,
                    Status = ProductStatus.Active,
                    Image = "https://media-cdn.tripadvisor.com/media/photo-s/08/9b/f2/3e/caption.jpg"
                }

                );
            #endregion

            #region Десерты
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 16,
                    CategoryId = 2,
                    Name = "Классический чизкейк",
                    Price = 250,
                    IsHit = false,
                    Stars = 4.1,
                    Status = ProductStatus.Active,
                    Image = "https://www.koolinar.ru/all_image/recipes/144/144777/recipe_1b7d00e6-ae0c-4d14-b3ee-fa3af188873c_large.jpg"
                },

                new Product
                {
                    Id = 17,
                    CategoryId = 2,
                    Name = "Сметанный торт",
                    Price = 250,
                    IsHit = false,
                    Stars = 4.2,
                    Status = ProductStatus.Active,
                    Image = "https://sovkusom.ru/wp-content/uploads/recepty/k/kak-prigotovit-smetannyi-tort-na-skovorode/thumb-840x440.jpg"
                },

                new Product
                {
                    Id = 18,
                    CategoryId = 2,
                    Name = "Шоколадные маффины",
                    Price = 250,
                    IsHit = false,
                    Stars = 4.3,
                    Status = ProductStatus.Active,
                    Image = "https://www.koolinar.ru/all_image/recipes/144/144903/recipe_3865e7be-2722-40a3-87a7-4634c5dfced4_large.jpg"
                }

            );
            #endregion

            #region Соки
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 19,
                CategoryId = 3,
                Name = "Свежевыжатый гранатовый сок",
                Price = 100,
                IsHit = false,
                Stars = 4.8,
                Status = ProductStatus.Active,
                Image = "https://img03.rl0.ru/7ecccd2ce12010f05a4e3f36a6fbb120/c615x400i/news.rambler.ru/img/2019/01/12025238.761283.5915.jpeg"
            },
            new Product
            {
                Id = 20,
                CategoryId = 3,
                Name = "Свежевыжатый апельсиновый сок",
                Price = 80,
                IsHit = false,
                Stars = 4.7,
                Status = ProductStatus.Active,
                Image = "https://polzavred-edi.ru/wp-content/uploads/2019/06/polza-i-vred-apelsinovogo-soka.jpg"
            },
            new Product
            {
                Id = 21,
                CategoryId = 3,
                Name = "Свежевыжатый виноградный сок",
                Price = 80,
                IsHit = false,
                Stars = 4.7,
                Status = ProductStatus.Active,
                Image = "https://www.inmoment.ru/img/health-body/grapes-juice1.jpg"
            },
            new Product
            {
                Id = 22,
                CategoryId = 3,
                Name = "Свежевыжатый ананасовый сок",
                Price = 80,
                IsHit = false,
                Stars = 4.7,
                Status = ProductStatus.Active,
                Image = "https://cafesahara.ru/upload/iblock/7ed/7eddcb30773af9e076d4d6ae8bc6a96a.jpg"
            }
                );
            #endregion

            #region Хлеб
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 23,
                CategoryId = 4,
                Name = "Белый хлеб",
                Price = 55,
                IsHit = false,
                Stars = 4.1,
                Status = ProductStatus.Active,
                Image = "http://russian7.ru/wp-content/uploads/2013/03/13.jpg"
            },
            new Product
            {
                Id = 24,
                CategoryId = 4,
                Name = "Черный хлеб",
                Price = 45,
                IsHit = false,
                Stars = 4.3,
                Status = ProductStatus.Active,
                Image = "http://russian7.ru/wp-content/uploads/2013/03/22.jpg"
            },
            new Product
            {
                Id = 25,
                CategoryId = 4,
                Name = "Красносельский хлеб",
                Price = 65,
                IsHit = false,
                Stars = 4.2,
                Status = ProductStatus.Active,
                Image = "http://russian7.ru/wp-content/uploads/2013/03/22.jpg"
            },
            new Product
            {
                Id = 26,
                CategoryId = 4,
                Name = "Заварной хлеб",
                Price = 75,
                IsHit = false,
                Stars = 4.3,
                Status = ProductStatus.Active,
                Image = "http://russian7.ru/wp-content/uploads/2013/03/7_russkix_xlebov.jpg"
            },
            new Product
            {
                Id = 27,
                CategoryId = 4,
                Name = "Бородинский хлеб",
                Price = 80,
                IsHit = false,
                Stars = 4.4,
                Status = ProductStatus.Active,
                Image = "http://russian7.ru/wp-content/uploads/2013/03/53.jpg"
            },
            new Product
            {
                Id = 28,
                CategoryId = 4,
                Name = "Московский боярский хлеб",
                Price = 70,
                IsHit = false,
                Stars = 4.5,
                Status = ProductStatus.Active,
                Image = "http://russian7.ru/wp-content/uploads/2013/03/63.jpg"
            },
            new Product
            {
                Id = 29,
                CategoryId = 4,
                Name = "Стародубский хлеб",
                Price = 45,
                IsHit = false,
                Stars = 4.6,
                Status = ProductStatus.Active,
                Image = "http://russian7.ru/wp-content/uploads/2013/03/81.jpg"
            }
                );
            #endregion

        }

        internal void AddOrder()
        {
            modelBuilder.Entity<OrderHdr>().HasData(
                new OrderHdr
                {
                    Id = 1,
                    ClientId = 1,
                    CreatedDate = DateTime.Now,
                    ClientName = "Невилл Долгопупс",
                    Address = "Школа Чародейства и Волшебства Хогвартс 1",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 1, 10),
                    Sum = 120
                },

                new OrderHdr
                {
                    Id = 2,
                    ClientId = 2,
                    CreatedDate = DateTime.Now,
                    ClientName = "Сириус Блек",
                    Address = "Школа Чародейства и Волшебства Хогвартс 2",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 2, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 3,
                    ClientId = 3,
                    CreatedDate = DateTime.Now,
                    ClientName = "Гермиона Грейнджер",
                    Address = "Школа Чародейства и Волшебства Хогвартс 3",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Delivery,
                    DeliveryDateTime = new DateTime(2020, 3, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 4,
                    ClientId = 4,
                    CreatedDate = DateTime.Now,
                    ClientName = "Гарри Поттер",
                    Address = "Школа Чародейства и Волшебства Хогвартс 4",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.InProgress,
                    DeliveryDateTime = new DateTime(2020, 4, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 5,
                    ClientId = 5,
                    CreatedDate = DateTime.Now,
                    ClientName = "Рональд Уизли",
                    Address = "Школа Чародейства и Волшебства Хогвартс 5",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Rejected,
                    DeliveryDateTime = new DateTime(2020, 5, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 6,
                    ClientId = 6,
                    CreatedDate = DateTime.Now,
                    ClientName = "Игорь Николев",
                    Address = "Школа Чародейства и Волшебства Хогвартс 6",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Rejected,
                    DeliveryDateTime = new DateTime(2020, 6, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 7,
                    ClientId = 7,
                    CreatedDate = DateTime.Now,
                    ClientName = "Альбус Дамблдор",
                    Address = "Школа Чародейства и Волшебства Хогвартс 7",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Requested,
                    DeliveryDateTime = new DateTime(2020, 7, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 8,
                    ClientId = 1,
                    CreatedDate = DateTime.Now,
                    ClientName = "Невилл Долгопупс",
                    Address = "Школа Чародейства и Волшебства Хогвартс 1",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Requested,
                    DeliveryDateTime = new DateTime(2020, 8, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 9,
                    ClientId = 2,
                    CreatedDate = DateTime.Now,
                    ClientName = "Сириус Блек",
                    Address = "Школа Чародейства и Волшебства Хогвартс 2",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Requested,
                    DeliveryDateTime = new DateTime(2020, 9, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 10,
                    ClientId = 3,
                    CreatedDate = DateTime.Now,
                    ClientName = "Гермиона Грейнджер",
                    Address = "Школа Чародейства и Волшебства Хогвартс 3",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Requested,
                    DeliveryDateTime = new DateTime(2020, 10, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 11,
                    ClientId = 4,
                    CreatedDate = DateTime.Now,
                    ClientName = "Гарри Поттер",
                    Address = "Школа Чародейства и Волшебства Хогвартс 4",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 11, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 12,
                    ClientId = 5,
                    CreatedDate = DateTime.Now,
                    ClientName = "Рональд Уизли",
                    Address = "Школа Чародейства и Волшебства Хогвартс 5",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Rejected,
                    DeliveryDateTime = new DateTime(2020, 12, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 13,
                    ClientId = 6,
                    CreatedDate = DateTime.Now,
                    ClientName = "Игорь Николев",
                    Address = "Школа Чародейства и Волшебства Хогвартс 6",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Rejected,
                    DeliveryDateTime = new DateTime(2020, 1, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 14,
                    ClientId = 7,
                    CreatedDate = DateTime.Now,
                    ClientName = "Альбус Дамблдор",
                    Address = "Школа Чародейства и Волшебства Хогвартс 7",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.InProgress,
                    DeliveryDateTime = new DateTime(2020, 1, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 15,
                    ClientId = 1,
                    CreatedDate = DateTime.Now,
                    ClientName = "Невилл Долгопупс",
                    Address = "Школа Чародейства и Волшебства Хогвартс 1",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.InProgress,
                    DeliveryDateTime = new DateTime(2020, 1, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 16,
                    ClientId = 1,
                    CreatedDate = DateTime.Now,
                    ClientName = "Невилл Долгопупс",
                    Address = "Школа Чародейства и Волшебства Хогвартс 1",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 2, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 17,
                    ClientId = 2,
                    CreatedDate = DateTime.Now,
                    ClientName = "Сириус Блек",
                    Address = "Школа Чародейства и Волшебства Хогвартс 2",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 4, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 18,
                    ClientId = 3,
                    CreatedDate = DateTime.Now,
                    ClientName = "Гермиона Грейнджер",
                    Address = "Школа Чародейства и Волшебства Хогвартс 3",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Delivery,
                    DeliveryDateTime = new DateTime(2020, 5, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 19,
                    ClientId = 3,
                    CreatedDate = DateTime.Now,
                    ClientName = "Гермиона Грейнджер",
                    Address = "Школа Чародейства и Волшебства Хогвартс 3",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Rejected,
                    DeliveryDateTime = new DateTime(2020, 5, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 20,
                    ClientId = 4,
                    CreatedDate = DateTime.Now,
                    ClientName = "Гарри Поттер",
                    Address = "Школа Чародейства и Волшебства Хогвартс 4",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Requested,
                    DeliveryDateTime = new DateTime(2020, 5, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 21,
                    ClientId = 5,
                    CreatedDate = DateTime.Now,
                    ClientName = "Рональд Уизли",
                    Address = "Школа Чародейства и Волшебства Хогвартс 5",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 5, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 22,
                    ClientId = 5,
                    CreatedDate = DateTime.Now,
                    ClientName = "Рональд Уизли",
                    Address = "Школа Чародейства и Волшебства Хогвартс 5",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 6, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 23,
                    ClientId = 7,
                    CreatedDate = DateTime.Now,
                    ClientName = "Альбус Дамблдор",
                    Address = "Школа Чародейства и Волшебства Хогвартс 7",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 7, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 24,
                    ClientId = 7,
                    CreatedDate = DateTime.Now,
                    ClientName = "Альбус Дамблдор",
                    Address = "Школа Чародейства и Волшебства Хогвартс 7",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 7, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 25,
                    ClientId = 7,
                    CreatedDate = DateTime.Now,
                    ClientName = "Альбус Дамблдор",
                    Address = "Школа Чародейства и Волшебства Хогвартс 7",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 7, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 26,
                    ClientId = 7,
                    CreatedDate = DateTime.Now,
                    ClientName = "Альбус Дамблдор",
                    Address = "Школа Чародейства и Волшебства Хогвартс 7",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 8, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 27,
                    ClientId = 2,
                    CreatedDate = DateTime.Now,
                    ClientName = "Сириус Блек",
                    Address = "Школа Чародейства и Волшебства Хогвартс 2",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 9, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 28,
                    ClientId = 5,
                    CreatedDate = DateTime.Now,
                    ClientName = "Рональд Уизли",
                    Address = "Школа Чародейства и Волшебства Хогвартс 5",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 9, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 29,
                    ClientId = 5,
                    CreatedDate = DateTime.Now,
                    ClientName = "Рональд Уизли",
                    Address = "Школа Чародейства и Волшебства Хогвартс 5",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 10, 10),
                    Sum = 120
                },


                new OrderHdr
                {
                    Id = 30,
                    ClientId = 4,
                    CreatedDate = DateTime.Now,
                    ClientName = "Игорь Николев",
                    Address = "Школа Чародейства и Волшебства Хогвартс 4",
                    Latitude = 15,
                    Longtitude = 16,
                    Phone = "1234567890",
                    Status = OrderHdrStatus.Done,
                    DeliveryDateTime = new DateTime(2020, 12, 10),
                    Sum = 120
                }

            );
        }
        internal void AddOrderDtl()
        {

        }

        internal void AddClient()
        {
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, ClientToken = Guid.NewGuid().ToString() },
                new Client { Id = 2, ClientToken = Guid.NewGuid().ToString() },
                new Client { Id = 3, ClientToken = Guid.NewGuid().ToString() },
                new Client { Id = 4, ClientToken = Guid.NewGuid().ToString() },
                new Client { Id = 5, ClientToken = Guid.NewGuid().ToString() },
                new Client { Id = 6, ClientToken = Guid.NewGuid().ToString() },
                new Client { Id = 7, ClientToken = Guid.NewGuid().ToString() }
                );
        }
                        
        internal void AddAdmin()
        {
            var UserId = Guid.NewGuid().ToString();

            var user = new IdentityUser
            {
                Id = UserId,
                UserName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = false,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            };

            modelBuilder.Entity<IdentityUser>().HasData(user);
        }
    }
}
