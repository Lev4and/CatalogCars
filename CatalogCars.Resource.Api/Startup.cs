using CatalogCars.Authorization.Common;
using CatalogCars.Model.Common;
using CatalogCars.Model.Database;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CatalogCars.Resource.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<RoleManager<ApplicatonRole>>();
            services.AddTransient<UserManager<ApplicationUser>>();

            services.AddTransient<IRolesRepository, EFRolesRepository>();
            services.AddTransient<IUsersRepository, EFUsersRepository>();
            services.AddTransient<DefaultDataManager>();

            services.AddTransient<IAnnouncementAdditionalInformationRepository, AdoNetAnnouncementAdditionalInformationRepository>();
            services.AddTransient<IAnnouncementDescriptionsRepository, AdoNetAnnouncementDescriptionsRepository>();
            services.AddTransient<IAnnouncementsRepository, AdoNetAnnouncementsRepository>();
            services.AddTransient<IAnnouncementTagsRepository, AdoNetAnnouncementTagsRepository>();
            services.AddTransient<IAvailabilitiesRepository, AdoNetAvailabilitiesRepository>();
            services.AddTransient<IBodyTypeGroupsRepository, AdoNetBodyTypeGroupsRepository>();
            services.AddTransient<IBodyTypesRepository, AdoNetBodyTypesRepository>();
            services.AddTransient<ICategoriesRepository, AdoNetCategoriesRepository>();
            services.AddTransient<IColorsRepository, AdoNetColorsRepository>();
            services.AddTransient<IColorTypesRepository, AdoNetColorTypesRepository>();
            services.AddTransient<IComplectationOptionsRepository, AdoNetComplectationOptionsRepository>();
            services.AddTransient<IComplectationsRepository, AdoNetComplectationsRepository>();
            services.AddTransient<IConfigurationsRepository, AdoNetConfigurationsRepository>();
            services.AddTransient<IConfigurationTagsRepository, AdoNetConfigurationTagsRepository>();
            services.AddTransient<ICoordinatesRepository, AdoNetCoordinatesRepository>();
            services.AddTransient<ICurrenciesRepository, AdoNetCurrenciesRepository>();
            services.AddTransient<IDocumentsRepository, AdoNetDocumentsRepository>();
            services.AddTransient<IEngineTypesRepository, AdoNetEngineTypesRepository>();
            services.AddTransient<IExternalPanoramasRepository, AdoNetExternalPanoramasRepository>();
            services.AddTransient<IGearTypesRepository, AdoNetGearTypesRepository>();
            services.AddTransient<IGenerationsRepository, AdoNetGenerationsRepository>();
            services.AddTransient<ILocationsRepository, AdoNetLocationsRepository>();
            services.AddTransient<IMarkLogosRepository, AdoNetMarkLogosRepository>();
            services.AddTransient<IMarksRepository, AdoNetMarksRepository>();
            services.AddTransient<IModelsRepository, AdoNetModelsRepository>();
            services.AddTransient<IOptionsRepository, AdoNetOptionsRepository>();
            services.AddTransient<IPhonesRepository, AdoNetPhonesRepository>();
            services.AddTransient<IPhotoClassesRepository, AdoNetPhotoClassesRepository>();
            services.AddTransient<IPicturesJpegR16X9Repository, AdoNetPicturesJpegR16X9Repository>();
            services.AddTransient<IPicturesJpegRepository, AdoNetPicturesJpegRepository>();
            services.AddTransient<IPicturesPngR16X9Repository, AdoNetPicturesPngR16X9Repository>();
            services.AddTransient<IPicturesPngRepository, AdoNetPicturesPngRepository>();
            services.AddTransient<IPicturesWebpR16X9Repository, AdoNetPicturesWebpR16X9Repository>();
            services.AddTransient<IPicturesWebpRepository, AdoNetPicturesWebpRepository>();
            services.AddTransient<IPriceSegmentsRepository, AdoNetPriceSegmentsRepository>();
            services.AddTransient<IPricesRepository, AdoNetPricesRepository>();
            services.AddTransient<IPtsRepository, AdoNetPtsRepository>();
            services.AddTransient<IPtsTypesRepository, AdoNetPtsTypesRepository>();
            services.AddTransient<IRegionsRepository, AdoNetRegionsRepository>();
            services.AddTransient<ISalonPhonesRepository, AdoNetSalonPhonesRepository>();
            services.AddTransient<ISalonsRepository, AdoNetSalonsRepository>();
            services.AddTransient<ISectionsRepository, AdoNetSectionsRepository>();
            services.AddTransient<ISellersRepository, AdoNetSellersRepository>();
            services.AddTransient<ISellerTypesRepository, AdoNetSellerTypesRepository>();
            services.AddTransient<IStatesRepository, AdoNetStatesRepository>();
            services.AddTransient<IStatusesRepository, AdoNetStatusesRepository>();
            services.AddTransient<ISteeringWheelsRepository, AdoNetSteeringWheelsRepository>();
            services.AddTransient<ITagsRepository, AdoNetTagsRepository>();
            services.AddTransient<ITechnicalParametersRepository, AdoNetTechnicaParametersRepository>();
            services.AddTransient<ITransmissionsRepository, AdoNetTransmissionsRepository>();
            services.AddTransient<IVehicleInformationRepository, AdoNetVehicleInformationRepository>();
            services.AddTransient<IVehicleMainPhotosRepository, AdoNetVehicleMainPhotosRepository>();
            services.AddTransient<IVendorColorPhotosRepository, AdoNetVendorColorPhotosRepository>();
            services.AddTransient<IVendorColorsRepository, AdoNetVendorColorsRepository>();
            services.AddTransient<IVendorsRepository, AdoNetVendorsRepository>();
            services.AddTransient<IVideosH264Repository, AdoNetVideosH264Repository>();
            services.AddTransient<IVideosMp4R16X9Repository, AdoNetVideosMp4R16X9Repository>();
            services.AddTransient<IVideosWebmR16X9Repository, AdoNetVideosWebmR16X9Repository>();
            services.AddTransient<IVideosWebmRepository, AdoNetVideosWebmRepository>();
            services.AddTransient<IVinResolutionsRepository, AdoNetVinResolutionsRepository>();
            services.AddTransient<IVinsRepository, AdoNetVinsRepository>();
            services.AddTransient<HighPerformanceDataManager>();

            services.AddDbContext<CatalogCarsDbContext>((options) =>
            {
                options.UseSqlServer(DbConfig.ConnectionString);
            });

            services.AddIdentity<ApplicationUser, ApplicatonRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<CatalogCarsDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = AuthorizationOptions.Issuer,
                        ValidAudience = AuthorizationOptions.Audience,
                        IssuerSigningKey = AuthorizationOptions.GetSymmetricSecurityKey(),
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatalogCars.Resource.Api", Version = "v1" });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatalogCars.Resource.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
