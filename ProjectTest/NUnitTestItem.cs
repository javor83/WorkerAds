namespace WebApplication6;

using GCommon.Contracts;
using GCommon.Data;
using GCommon.Models;
using GCommon.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Moq;
using NUnit.Framework;



public class NUnitTestItem
{
    private MeisterContext _context = null;
    private IWageTaxService _tax_service = null;
    private IWorkerService _worker_service = null;
    private Mock<IFormFile> _upload_service = null;
    private Mock<IWebHostEnvironment> _web_host_service;
    //**********************************************************************************
    [SetUp]
    public void SetUp()
    {
        // Define a unique name for the in-memory database per test run
        var services = new ServiceCollection();
        services.AddHttpContextAccessor();
        services.AddDistributedMemoryCache();
        // Add DB Context
        services.AddDbContext<MeisterContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        services.AddTransient<IManageOrders, ManageOrders>();
        services.AddTransient<IManageAsk, ManageAsk>();
                services.AddTransient<IWageTaxService, WageTaxService>();
        services.AddTransient<IWorkCategoryService, WorkCategoryService>();
        services.AddTransient<IWorkHoursService, WorkHoursService>();
                services.AddTransient<IWorkerService, WorkerService>();
        services.AddTransient<IAdsPersonService, AdsPersonService>();
        services.AddTransient<ICapabilityService, CapabilityService>();

        services.AddTransient<IPublishAdsService, PublishAdsService>();
        services.AddScoped<ILocalProfiles, LocalProfiles>();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(60); // Session expiration
            options.Cookie.HttpOnly = true;                // Security: Prevent JS access
            options.Cookie.IsEssential = true;             // Mark as essential for GDPR
        });

        //-------------------------------------
        var serviceProvider = services.BuildServiceProvider();
        //-------------------------------------
        this._web_host_service = new Mock<IWebHostEnvironment>();
        
        // Setup the paths and environment name
        this._web_host_service.Setup(m => m.WebRootPath).Returns(@"C:\Test\wwwroot");
        this._web_host_service.Setup(m => m.ContentRootPath).Returns(@"C:\Test");
        this._web_host_service.Setup(m => m.EnvironmentName).Returns("Development");
        //-------------------------------------
        this._upload_service = new Mock<IFormFile>();
        this._upload_service.Setup(f => f.Length).Returns(100 * 1024); // 100 kb
        this._upload_service.Setup(f => f.FileName).Returns("filename.jpg");
        //-------------------------------------
        this._context = serviceProvider.GetRequiredService<MeisterContext>();
        //-------------------------------------
        this._tax_service = new WageTaxService(_context);

        this._worker_service = new WorkerService(_context, this._web_host_service.Object);
        //-------------------------------------

    }



    //**********************************************************************************
    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    //**********************************************************************************
    [Test]
    public async Task WorkerService_Create()
    {
        

        Assert.DoesNotThrowAsync
            (
             async () =>
             {
                 await this._worker_service.Insert
                 (
                     new InsertWorkerViewModel()
                     {
                         Email = "email",
                         FName = "fname",
                         LName = "lname",
                         Phone = "phone",
                         Preview = this._upload_service.Object,
                         ID = 0
                     }
                 );
             }
            );

    }

    //**********************************************************************************
    [Test]
    public async Task TaxService_Exist()
    {
        await this._tax_service.Create
                     (
                         new WageTaxViewModel()
                         {
                             Name = "Test service 1"
                         }
                     );
        await this._tax_service.Create
                     (
                         new WageTaxViewModel()
                         {
                             Name = "Test service 2"
                         }
                     );
        await this._tax_service.Create
                     (
                         new WageTaxViewModel()
                         {
                             Name = "Test service 3"
                         }
                     );
        Assert.True(this._tax_service.Exists(1));

    }
    //**********************************************************************************
    [Test]
    public async Task TaxService_Create()
    {
        Assert.DoesNotThrowAsync
             (
              async () =>
              {
                  await this._tax_service.Create
                     (
                         new WageTaxViewModel()
                         {
                             Name = "Test service"
                         }
                     );
              }
             );


       
    }
    //**********************************************************************************
}
