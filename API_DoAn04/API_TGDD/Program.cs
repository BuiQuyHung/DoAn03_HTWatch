using BBL_TGDD.Interfaces;
using BBL_TGDD;
using DAL_TGDD.Interfaces;
using DAL_TGDD;
using DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models_TGDD;
using System.Text;
using Helper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IKhachRepository, KhachRepository>();
builder.Services.AddTransient<IKhachBusiness, KhachBusiness>();

builder.Services.AddTransient<INhanVienRepository, NhanVienRepository>();
builder.Services.AddTransient<INhanVienBusiness, NhanVienBusiness>();

builder.Services.AddTransient<IDanhMucRepository, DanhMucRepository>();
builder.Services.AddTransient<IDanhMucBusiness, DanhMucBusiness>();

builder.Services.AddTransient<INhaPhanPhoiRepository, NhaPhanPhoiRepository>();
builder.Services.AddTransient<INhaPhanPhoiBusiness, NhaPhanPhoiBusiness>();

builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();

builder.Services.AddTransient<INguoiDungRepository, NguoiDungRepository>();
builder.Services.AddTransient<INguoiDungBusiness, NguoiDungBusiness>();

builder.Services.AddTransient<ITinTucRepository, TinTucRepository>();
builder.Services.AddTransient<ITinTucBusiness, TinTucBusiness>();

builder.Services.AddTransient<IKhuyenMaiRepository, KhuyenMaiRepository>();
builder.Services.AddTransient<IKhuyenMaiBusiness, KhuyenMaiBusiness>();

builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<IMenuBusiness, MenuBusiness>();

builder.Services.AddTransient<IDonHangRepository, DonHangRepository>();
builder.Services.AddTransient<IDonHangBusiness, DonHangBusiness>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<BBL_TGDD.Interfaces.IUserBusiness, UserBusiness>();


// configure strongly typed settings objects
IConfiguration configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();