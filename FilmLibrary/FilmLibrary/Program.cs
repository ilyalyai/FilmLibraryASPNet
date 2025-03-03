/*
 Планы:
1. Библиотека фильмов, мб сериалов и игр. Отсортировано по стилям, годам (мб что-то еще?)
2. Эндпойнты: Выбор позиции, добавление позиции, список позиций
3. Прикрутить нейронку (я хочу вот такое вот) и базу данных (хранить значения)

Нужны:
а) Сервисы
    1. Сервис для нейронки
    2. Сервис для поиска по фильтрам
    3. Сервис для добавления новых штук
б) Эндопойнты
    1. Эндпойнт для нейронки с строкой
    2. Эндпойнт для поиска с формой
    3. Эндпойнт с полями для ввода
в) Модели
    1. Фильмы
    2. Жанры
г) Представления
    1. С фильтрами
    2. Для нейронки
д) База данных, проверить необходимость во всех полях и добавить их
 */

using FilmLibrary.Models;

var builder = WebApplication.CreateBuilder();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>();
var app = builder.Build();
// Проверка наличия базы данных и её создание, если она отсутствует
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureCreated(); // Создаёт базу данных, если её нет
}
// Настройка middleware для обработки запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Включает HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Включаем маршрутизацию
app.UseRouting();

// Включаем работу с cookie (если нужны anti-forgery токены)
app.UseAuthorization();

// Конфигурируем конечные точки
app.MapControllerRoute(
    name: "default", // Имя маршрута
    pattern: "{controller=FilmsController}/{action=Index}/{id?}"); // Шаблон маршрута

app.Run();
