using DAL.Entities;

namespace DAL.Context
{
    public static class DatabaseInitializer
    {
        public static void Initialize(AppDbContext context)
        {

            context.Database.EnsureCreated();

            if (context.Providers.Any() || context.Services.Any())
            {
                return;
            }

            var providers = new List<ProviderEntity>
            {
                new ProviderEntity
                {
                    
                    Name = "ТехноСервис",
                    Phone = "+7 (495) 123-45-67",
                    Address = "г. Москва, ул. Ленина, д. 10"
                },
                new ProviderEntity
                {
                    
                    Name = "Домашний Уют",
                    Phone = "+7 (812) 234-56-78",
                    Address = "г. Санкт-Петербург, Невский пр-т, д. 25"
                },
                new ProviderEntity
                {
                    
                    Name = "ЭкоКлининг",
                    Phone = "+7 (383) 345-67-89",
                    Address = "г. Новосибирск, ул. Кирова, д. 15"
                },
                new ProviderEntity
                {
                   
                    Name = "Быстрая Помощь",
                    Phone = "+7 (843) 456-78-90",
                    Address = "г. Казань, ул. Баумана, д. 7"
                },
                new ProviderEntity
                {
                    
                    Name = "ПрофиРемонт",
                    Phone = "+7 (351) 567-89-01",
                    Address = "г. Челябинск, пр-т Победы, д. 32"
                }
            };

            var services = new List<ServiceEntity>
            {
                // Услуги для ТехноСервис (Id = 1)
                new ServiceEntity {Name = "Ремонт компьютеров", Description = "Диагностика и ремонт ПК и ноутбуков", Price = 1500, Duration = 60, ProviderId = 1 },
                new ServiceEntity {Name = "Установка ОС", Description = "Установка и настройка операционной системы", Price = 2000, Duration = 90, ProviderId = 1 },
                new ServiceEntity {Name = "Удаление вирусов", Description = "Лечение ПК от вредоносных программ", Price = 1200, Duration = 45, ProviderId = 1 },
                new ServiceEntity {Name = "Настройка сети", Description = "Настройка Wi-Fi и локальной сети", Price = 1800, Duration = 75, ProviderId = 1 },
                new ServiceEntity {Name = "Восстановление данных", Description = "Восстановление удаленных файлов", Price = 2500, Duration = 120, ProviderId = 1 },

                // Услуги для Домашний Уют (Id = 2)
                new ServiceEntity {Name = "Уборка квартиры", Description = "Генеральная уборка жилых помещений", Price = 3000, Duration = 180, ProviderId = 2 },
                new ServiceEntity {Name = "Мойка окон", Description = "Чистка стекол и оконных рам", Price = 1500, Duration = 90, ProviderId = 2 },
                new ServiceEntity {Name = "Химчистка дивана", Description = "Профессиональная чистка мягкой мебели", Price = 4500, Duration = 150, ProviderId = 2 },
                new ServiceEntity {Name = "Уборка после ремонта", Description = "Уборка строительной пыли и мусора", Price = 5000, Duration = 240, ProviderId = 2 },
                new ServiceEntity {Name = "Мытье холодильника", Description = "Глубокая чистка холодильника", Price = 2000, Duration = 60, ProviderId = 2 },

                // Услуги для ЭкоКлининг (Id = 3)
                new ServiceEntity {Name = "Экоуборка офиса", Description = "Уборка с использованием экосредств", Price = 4000, Duration = 120, ProviderId = 3 },
                new ServiceEntity {Name = "Чистка ковров", Description = "Экологичная чистка ковровых покрытий", Price = 2800, Duration = 90, ProviderId = 3 },
                new ServiceEntity {Name = "Дезинфекция помещений", Description = "Обработка от бактерий и вирусов", Price = 3500, Duration = 60, ProviderId = 3 },
                new ServiceEntity {Name = "Уход за растениями", Description = "Полив и уход за офисными растениями", Price = 1500, Duration = 45, ProviderId = 3 },

                // Услуги для Быстрая Помощь (Id = 4)
                new ServiceEntity {Name = "Сантехнические работы", Description = "Устранение протечек и засоров", Price = 2500, Duration = 60, ProviderId = 4 },
                new ServiceEntity {Name = "Электромонтажные работы", Description = "Установка розеток и выключателей", Price = 1800, Duration = 45, ProviderId = 4 },
                new ServiceEntity {Name = "Установка замков", Description = "Врезка и замена дверных замков", Price = 3200, Duration = 90, ProviderId = 4 },
                new ServiceEntity {Name = "Сборка мебели", Description = "Сборка корпусной и мягкой мебели", Price = 2800, Duration = 120, ProviderId = 4 },
                new ServiceEntity {Name = "Установка кондиционера", Description = "Монтаж и подключение сплит-системы", Price = 6000, Duration = 180, ProviderId = 4 },
                new ServiceEntity {Name = "Ремонт дверей", Description = "Регулировка и ремонт межкомнатных дверей", Price = 2200, Duration = 75, ProviderId = 4 },

                // Услуги для ПрофиРемонт (Id = 5)
                new ServiceEntity {Name = "Штукатурные работы", Description = "Выравнивание стен штукатуркой", Price = 800, Duration = 30, ProviderId = 5 },
                new ServiceEntity {Name = "Покраска стен", Description = "Окрашивание стен и потолков", Price = 500, Duration = 30, ProviderId = 5 },
                new ServiceEntity {Name = "Укладка плитки", Description = "Облицовка стен и пола керамикой", Price = 1200, Duration = 45, ProviderId = 5 },
                new ServiceEntity {Name = "Установка натяжных потолков", Description = "Монтаж ПВХ потолков", Price = 3500, Duration = 150, ProviderId = 5 },
                new ServiceEntity {Name = "Установка ламината", Description = "Укладка ламинированного покрытия", Price = 900, Duration = 40, ProviderId = 5 }
            };

            context.Providers.AddRange(providers);
            context.SaveChanges();

            context.Services.AddRange(services);
            context.SaveChanges();
        }
    }
}
