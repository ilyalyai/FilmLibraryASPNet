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
    1. С фильтрами
    2. Для нейронки
г) Представления
    1. С фильтрами
    2. Для нейронки
 */

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/SearchFilm", searchFilmApp =>
{
    app.Map("/byNeural", async (HttpRequest request) =>
    {
        try
        {
            return await SearchByNeural(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException("Ошибка в обработке. Сообщение в логе.");
        }
    });

    app.Map("/byFilters", async (HttpRequest request) =>
    {
        try
        {
            return await SearchByFilters(request, cvService);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException("Ошибка в обработке. Сообщение в логе.");
        }
    });
});

app.Run();