namespace WebApplication6;

using GCommon.Data;
using GCommon.Services;
using Microsoft.EntityFrameworkCore;
using NUnit;
using NUnit.Framework;

public class NUnitTestItem
{
    private MeisterContext _context = null;
    //**********************************************************************************
    [SetUp]
    public void SetUp()
    {
        // Define a unique name for the in-memory database per test run
        var options = new DbContextOptionsBuilder<MeisterContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new MeisterContext(options);
    }
    //**********************************************************************************
    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
    //**********************************************************************************
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    //**********************************************************************************
}
