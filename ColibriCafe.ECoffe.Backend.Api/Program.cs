using ColibriCafe.ECoffe.Backend.Api.Configurations;

WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .ConfigureMiddlewares()
    .Run();