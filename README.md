# Моя коллекция фильмов и сериалов

Backend часть приложения для управления персональной коллекцией медиа контента (фильмов/сериалов). 
REST API сервис, построенный на .NET 8 и FastEndpoints.

---

## О проекте

Это backend API для одностраничного приложения, предоставляющее функционал для управления коллекцией медиа контента (фильмов/сериалов). 
API поддерживает все необходимые CRUD операции и предоставляет данные в формате JSON.

---

## Основные возможности

- Добавление новых медиа-объектов
- Получение списка медиа-объектов (фильмов/сериалов) пользователя
- Регистрация пользователя и его аутентификация

---

## Технологии

- .NET 8.0
- FastEndpoints - высокопроизводительный фреймворк для API
- Entity Framework Core - ORM для работы с базой данных
- Swagger - автоматическая документация API
- PostgreSQL - база данных

---
## Как запустить проект локально

1. Клонируйте репозиторий:

   ```bash
   git clone https://github.com/ojelem2001/media-collection.api.git
   cd media-collection.api
2. Настройка конекста базы данных для запуска миграций. Добавить в MediaDbContext:
	```
	public MediaDbContext()
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			// Конфигурация для дизайн-тайма (миграций)
			optionsBuilder.UseNpgsql("Host=localhost;Database=media_db;Username=<USERNAME>;Password=<PASSWORD>;Port=5432",
				npgsqlOptions =>
				{
					npgsqlOptions.MigrationsAssembly(GetType().Assembly.FullName);
				});
		}
	}
2.1. Создание миграции:
	`Add-Migration Initial -Project MediaCollection.Data -StartupProject MediaCollection.Data  -o Database\Migrations -context MediaDbContext -Verbose`
2.2. Удаление миграции:
	`Remove-Migration -Force -Project MediaCollection.Data -StartupProject MediaCollection.Data -context MediaDbContext -Verbose`
3. Обновление базы данных:
	`Update-Database  -Project MediaCollection.Data -StartupProject MediaCollection.Data -verbose -context MediaDbContext`
3. Запустите приложение:
	`dotnet run`
4. Откройте в браузере http://localhost:7128/swagger/