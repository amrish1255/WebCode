using web.HttpClients;
using web.Interface.Repository;
using web.Interface.Service;
using web.Repository;
using web.Service;




namespace webCode.Extensions
{
    public static class ServiceConfigExtension
    {
        public static void addDapperContext(this IServiceCollection services)
        {
            services.AddSingleton<IDapperContext, DapperContext>();
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            //services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddScoped<IMemberRepository, MemberRepository>();
            //services.AddScoped<IBackOfficeRepository, BackOfficeRepository>();
            //services.AddScoped<IBackOfficeAccountRepository, BackOfficeAccountRepository>();
            //services.AddScoped<IHomeRepository, HomeRepository>();
            //         services.AddScoped<IBackOfficeECommerceRepository, BackOfficeECommerceRepository>();


        }
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            //services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IUserClaimService, UserClaimService>();
            //services.AddScoped<IUploadImage, UploadImage>();
            //         services.AddScoped<IFileHelper, FileHelper>();
            //         services.AddScoped<IMemberService, MemberService>();
            //services.AddScoped<IBackOfficeService, BackOfficeService>();
            //services.AddScoped<IBackOfficeAccountService, BackOfficeAccountService>();
            //         services.AddScoped<IHttpClientHelper, HttpClientHelper>();
            //         services.AddScoped<ICyrusApiRepository, CyrusApiRepository>();
            //         services.AddScoped<IHomeService, HomeService>();
            //         services.AddScoped<IBackOfficeECommerceService, BackOfficeECommerceService>();
            //         services.AddScoped<ICategoryService, CategoryService>();
            //         services.AddScoped<IAesEncryptionService, AesEncryptionService>();
            //         services.AddScoped<ICartService, CartService>();
                  services.AddHttpContextAccessor();

        }
    }
}