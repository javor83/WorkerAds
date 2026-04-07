namespace WebApplication6;

using GCommon.Contracts;
using GCommon.Data;
using GCommon.Models;
using GCommon.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;



public class NUnitTestItem
{
    
    private IWageTaxService _tax_service = null;
    private IWorkerService _worker_service = null;
    //----------------------
    private MeisterContext _context = null;
    private Mock<IFormFile> _upload_service = null;
    private Mock<IWebHostEnvironment> _web_host_service;

    //**********************************************************************************
    [SetUp]
    public void SetUp()
    {

        var services = new ServiceCollection();
        services.AddDbContext<MeisterContext>
            (
            // Define a unique name for the in-memory database per test run
            options => options.UseInMemoryDatabase(Guid.NewGuid().ToString())
            );


        services.AddTransient<IWorkerService, WorkerService>();//DONE
        services.AddTransient<IWageTaxService, WageTaxService>();//DONE

        //-------------------------------------
        var serviceProvider = services.BuildServiceProvider();
        //-------------------------------------
        this._web_host_service = new Mock<IWebHostEnvironment>();

        // Setup the paths and environment name

        string wwwroot_folder = @"C:\Test\wwwroot";
        if (Directory.Exists(wwwroot_folder) == false)
        {
            Directory.CreateDirectory(wwwroot_folder);
        }


        string test_folder = Path.GetDirectoryName(wwwroot_folder);

        this._web_host_service.Setup(m => m.WebRootPath).Returns(wwwroot_folder);
        this._web_host_service.Setup(m => m.ContentRootPath).Returns(test_folder);
        this._web_host_service.Setup(m => m.EnvironmentName).Returns("Development");
        //-------------------------------------
        //благодаря ти Google Gemini :)
        string demo_image = "demo.jpg";
        byte[] demo_image_bytes = File.ReadAllBytes($"C:/Test/{demo_image}");



        var ms = new MemoryStream(demo_image_bytes);

        ms.Position = 0;

        this._upload_service = new Mock<IFormFile>();
        this._upload_service.Setup(f => f.Length).Returns(demo_image_bytes.Length);
        this._upload_service.Setup(f => f.FileName).Returns(demo_image);
        this._upload_service.Setup(f => f.ContentType).Returns("image/jpeg");
        this._upload_service.Setup(f => f.OpenReadStream()).Returns(ms);



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
    #region TEST SERVICE IWorkerService / WorkerService



    //**********************************************************************************
    [Test]
    public async Task WorkerService_Update()
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
                    ID = null
                }
            );

        UpdateWorkerViewModel demo = this._worker_service.Find(1);
        demo.Phone = "999-999";
        await this._worker_service.Update(demo);

        var list = this._worker_service.Read();
        Assert.That(list.First().Phone == "999-999","No null");
    }
    //**********************************************************************************
    [Test]
    public async Task WorkerService_Delete()
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
                    ID = null
                }
            );

        var x = await this._worker_service.Delete(1);
        Assert.That(x,"delete success");
    }

    //**********************************************************************************
    [Test]
    public async Task WorkerService_Find()
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
                      ID = null
                  }
              );



        var count = this._worker_service.Find(1);


        Assert.That(count!=null,"count is not null");
    }
    //**********************************************************************************

    [Test]
    public async Task WorkerService_Read()
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
                       ID = null
                   }
               );
       

        var list = this._worker_service.Read();
      
        bool count = list.Count() == 1;

        Assert.That(count,"count success");
    }

    //**********************************************************************************
    [Test]
    public async Task WorkerService_Insert()
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
        var list =  this._worker_service.Read();
        bool count = list.Count() == 1;

        Assert.That(count,"count success");

    }
    //**********************************************************************************
    #endregion

    #region TEST SERVICE IWageTaxService / WageTaxService

    

    [Test]
    public async Task TaskService_Update()
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
        IEnumerable<WageTaxViewModel> elements = this._tax_service.Read();

        await this._tax_service.Update
            (
                 new WageTaxViewModel()
                 {
                     Name = "UPDATED 3",
                     ID = 3
                 }
            );

        IEnumerable<WageTaxViewModel> UPDATED_elements = this._tax_service.Read();
        bool result = UPDATED_elements.Where(x => x.ID == 3).First().Name == "UPDATED 3";
        Assert.That(result,"update success");

    }
    //**********************************************************************************
    [Test]
    public async Task TaskService_Read()
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
        IEnumerable<WageTaxViewModel> elements = this._tax_service.Read();
        int old_count = elements.Count();

      

        Assert.That(old_count == 3, "read elements");

    }
    //**********************************************************************************
    [Test]
    public async Task TaskService_Delete()
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
        IEnumerable<WageTaxViewModel> elements = this._tax_service.Read();
        int old_count = elements.Count();

        await this._tax_service.Delete(1);

        IEnumerable<WageTaxViewModel> elements_del = this._tax_service.Read();
        int new_count = elements_del.Count();

        Assert.That(new_count == 2, "element deleted");

    }

    //**********************************************************************************

    [Test]
    public async Task TaskService_To_DTO_WageTax()
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

        WageTaxViewModel result = this._tax_service.To_DTO_WageTax(1);

        Assert.That(result!=null,"not null ok");
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
        Assert.That(this._tax_service.Exists(1),"exists !");

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

    #endregion

    
}
