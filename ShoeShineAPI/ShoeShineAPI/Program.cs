using ShoeShineAPI.Infracstructure.Service_Extension;
using ShoeShineAPI.Service.Service;
using ShoeShineAPI.Service.Service.IService;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using AutoMapper;
using Microsoft.OpenApi.Models;
using ShoeShineAPI.Gateway.Config;
using ShoeShineAPI.Gateway.IConfig;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDIServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// cài đặt swagger set token
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "shoeshine", Version = "v1" });
    // document for api
    //var programDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    //var filePath = Path.Combine(programDirectory, "api-doc.xml");
    //c.IncludeXmlComments(filePath); // Đường dẫn đến tệp YAML của bạn

    // Cấu hình cho OAuth 2.0 (Bearer Token)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "Please Enter The Token To Authenticate The Role",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = "Bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] { }
		}
	});
});
// Cấu hình Memory Cache
builder.Services.AddMemoryCache();
// Service
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryStoreService, CategoryStoreService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceStoreService, ServiceStoreService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IRatingStoreService, RatingStoreService>();
builder.Services.AddScoped<IRatingCommentService, RatingCommentService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICommentStoreService, CommentStoreService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IMomoConfig,MomoConfig>();
builder.Services.AddScoped<IImageStoreService, ImageStoreSevice>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
//Gateway
builder.Services.Configure<MomoConfig>(builder.Configuration.GetSection(MomoConfig.ConfigName));
// Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Token
var serect =builder.Configuration["AppSettings:SecretKey"];
var key = Encoding.ASCII.GetBytes(serect);
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "shoeshine");
    c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "shoeshine");
    c.RoutePrefix = string.Empty;

});
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
