using CalculationOfSpecificPowerWebApp.Infrastructure;
using CalculationOfSpecificPowerWebApp.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//�������� ������ ��� ��������� ���� ����������
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
//��������� ���������� ����������
app.UseExceptionHandler();

//��������� middleware ��� ������������
app.UseLoggingMiddleware();

app.MapControllers();

//app.MapGet("/", GetMenu);
app.Run();

IResult GetMenu()
{
    return Results.Ok(new
    {
        Endpoints = new[]
        {
            "GET: /api/calculator/specific-power?count={���������� ������������}&type={��� �����������} - �������� ��������, P��",
            "GET: /api/calculator/rated-power?count={���������� ������������}&type={��� �����������} - ��������� ��������, Pp",
            "GET: /api/calculator/electric-current?count={���������� ������������}&type={��� �����������}&cosf={0.98 - �.�.} - ���� ����, Ip",
            "GET: /api/calculator/moment?count={���������� ������������}&type={��� �����������}&length={����� ��� ������} - ������",
        }
    });
}
