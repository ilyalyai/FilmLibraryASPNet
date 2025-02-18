/*
 �����:
1. ���������� �������, �� �������� � ���. ������������� �� ������, ����� (�� ���-�� ���?)
2. ���������: ����� �������, ���������� �������, ������ �������
3. ���������� �������� (� ���� ��� ����� ���) � ���� ������ (������� ��������)

�����:
�) �������
    1. ������ ��� ��������
    2. ������ ��� ������ �� ��������
    3. ������ ��� ���������� ����� ����
�) ����������
    1. �������� ��� �������� � �������
    2. �������� ��� ������ � ������
    3. �������� � ������ ��� �����
�) ������
    1. � ���������
    2. ��� ��������
�) �������������
    1. � ���������
    2. ��� ��������
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
            throw new ApplicationException("������ � ���������. ��������� � ����.");
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
            throw new ApplicationException("������ � ���������. ��������� � ����.");
        }
    });
});

app.Run();