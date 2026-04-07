using CalculationOfSpecificPowerWebApp.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

//подключаю middleware дл€ логгировани€
app.UseLoggingMiddleware();

app.MapControllers();

app.MapGet("/", GetMenu);
app.Run();

IResult GetMenu()
{
    return Results.Ok(new
    {
        Endpoints = new[]
        {
            "GET: /api/calculator/specific-power?count={количество потребителей}&type={тип потребител€} - удельна€ мощность, Pуд",
            "GET: /api/calculator/rated-power?count={количество потребителей}&type={тип потребител€} - расчЄтна€ мощность, Pp",
            "GET: /api/calculator/electric-current?count={количество потребителей}&type={тип потребител€}&cosf={0.98 - п.у.} - сила тока, Ip",
            "GET: /api/calculator/moment?count={количество потребителей}&type={тип потребител€}&length={длина ЋЁѕ метров} - момент",
        }
    });
}
