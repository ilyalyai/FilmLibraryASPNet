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
    1. ������
    2. �����
�) �������������
    1. � ���������
    2. ��� ��������
�) ���� ������, ��������� ������������� �� ���� ����� � �������� ��
 */

using FilmLibrary.Models;

var builder = WebApplication.CreateBuilder();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>();
var app = builder.Build();
// �������� ������� ���� ������ � � ��������, ���� ��� �����������
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureCreated(); // ������ ���� ������, ���� � ���
}
// ��������� middleware ��� ��������� ��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // �������� HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// �������� �������������
app.UseRouting();

// �������� ������ � cookie (���� ����� anti-forgery ������)
app.UseAuthorization();

// ������������� �������� �����
app.MapControllerRoute(
    name: "default", // ��� ��������
    pattern: "{controller=FilmsController}/{action=Index}/{id?}"); // ������ ��������

app.Run();
