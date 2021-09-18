using CatalogCars.Authorization.Common;
using CatalogCars.Model.Common;
using CatalogCars.Model.Database;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Mark;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model;
using CatalogCars.Model.Importers.HighPerformance;
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
using AdoNet = CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet;
using AdoNetAbstract = CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using EntityFramework = CatalogCars.Model.Database.Repositories.Default.EntityFramework;
using EntityFrameworkAbstract = CatalogCars.Model.Database.Repositories.Default.Abstract;

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
            services.AddTransient<AnnouncementImporter>();

            services.AddTransient<RoleManager<ApplicatonRole>>();
            services.AddTransient<UserManager<ApplicationUser>>();

            services.AddTransient<IGenerationsSorter, DefaultGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByAscendingNameGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByDescendingNameGenerationsSorter>();

            services.AddTransient<IMarksSorter, DefaultMarksSorter>();
            services.AddTransient<IMarksSorter, ByAscendingNameMarksSorter>();
            services.AddTransient<IMarksSorter, ByDescendingNameMarksSorter>();

            services.AddTransient<IModelsSorter, DefaultModelsSorter>();
            services.AddTransient<IModelsSorter, ByAscendingNameModelsSorter>();
            services.AddTransient<IModelsSorter, ByDescendingNameModelsSorter>();

            services.AddTransient<EntityFrameworkAbstract.IGenerationsRepository, EntityFramework.EFGenerationsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IMarksRepository, EntityFramework.EFMarksRepository>();
            services.AddTransient<EntityFrameworkAbstract.IModelsRepository, EntityFramework.EFModelsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IPriceSegmentsRepository, EntityFramework.EFPriceSegmentsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IRolesRepository, EntityFramework.EFRolesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IUsersRepository, EntityFramework.EFUsersRepository>();
            services.AddTransient<DefaultDataManager>();

            services.AddTransient<AdoNetAbstract.IAnnouncementAdditionalInformationRepository, AdoNet.AdoNetAnnouncementAdditionalInformationRepository>();
            services.AddTransient<AdoNetAbstract.IAnnouncementDescriptionsRepository, AdoNet.AdoNetAnnouncementDescriptionsRepository>();
            services.AddTransient<AdoNetAbstract.IAnnouncementsRepository, AdoNet.AdoNetAnnouncementsRepository>();
            services.AddTransient<AdoNetAbstract.IAnnouncementTagsRepository, AdoNet.AdoNetAnnouncementTagsRepository>();
            services.AddTransient<AdoNetAbstract.IAvailabilitiesRepository, AdoNet.AdoNetAvailabilitiesRepository>();
            services.AddTransient<AdoNetAbstract.IBodyTypeGroupsRepository, AdoNet.AdoNetBodyTypeGroupsRepository>();
            services.AddTransient<AdoNetAbstract.IBodyTypesRepository, AdoNet.AdoNetBodyTypesRepository>();
            services.AddTransient<AdoNetAbstract.ICategoriesRepository, AdoNet.AdoNetCategoriesRepository>();
            services.AddTransient<AdoNetAbstract.IColorsRepository, AdoNet.AdoNetColorsRepository>();
            services.AddTransient<AdoNetAbstract.IColorTypesRepository, AdoNet.AdoNetColorTypesRepository>();
            services.AddTransient<AdoNetAbstract.IComplectationOptionsRepository, AdoNet.AdoNetComplectationOptionsRepository>();
            services.AddTransient<AdoNetAbstract.IComplectationsRepository, AdoNet.AdoNetComplectationsRepository>();
            services.AddTransient<AdoNetAbstract.IConfigurationsRepository, AdoNet.AdoNetConfigurationsRepository>();
            services.AddTransient<AdoNetAbstract.IConfigurationTagsRepository, AdoNet.AdoNetConfigurationTagsRepository>();
            services.AddTransient<AdoNetAbstract.ICoordinatesRepository, AdoNet.AdoNetCoordinatesRepository>();
            services.AddTransient<AdoNetAbstract.ICurrenciesRepository, AdoNet.AdoNetCurrenciesRepository>();
            services.AddTransient<AdoNetAbstract.IDocumentsRepository, AdoNet.AdoNetDocumentsRepository>();
            services.AddTransient<AdoNetAbstract.IEngineTypesRepository, AdoNet.AdoNetEngineTypesRepository>();
            services.AddTransient<AdoNetAbstract.IExternalPanoramasRepository, AdoNet.AdoNetExternalPanoramasRepository>();
            services.AddTransient<AdoNetAbstract.IGearTypesRepository, AdoNet.AdoNetGearTypesRepository>();
            services.AddTransient<AdoNetAbstract.IGenerationsRepository, AdoNet.AdoNetGenerationsRepository>();
            services.AddTransient<AdoNetAbstract.ILocationsRepository, AdoNet.AdoNetLocationsRepository>();
            services.AddTransient<AdoNetAbstract.IMarkLogosRepository, AdoNet.AdoNetMarkLogosRepository>();
            services.AddTransient<AdoNetAbstract.IMarksRepository, AdoNet.AdoNetMarksRepository>();
            services.AddTransient<AdoNetAbstract.IModelsRepository, AdoNet.AdoNetModelsRepository>();
            services.AddTransient<AdoNetAbstract.IOptionsRepository, AdoNet.AdoNetOptionsRepository>();
            services.AddTransient<AdoNetAbstract.IPhonesRepository, AdoNet.AdoNetPhonesRepository>();
            services.AddTransient<AdoNetAbstract.IPhotoClassesRepository, AdoNet.AdoNetPhotoClassesRepository>();
            services.AddTransient<AdoNetAbstract.IPicturesJpegR16X9Repository, AdoNet.AdoNetPicturesJpegR16X9Repository>();
            services.AddTransient<AdoNetAbstract.IPicturesJpegRepository, AdoNet.AdoNetPicturesJpegRepository>();
            services.AddTransient<AdoNetAbstract.IPicturesPngR16X9Repository, AdoNet.AdoNetPicturesPngR16X9Repository>();
            services.AddTransient<AdoNetAbstract.IPicturesPngRepository, AdoNet.AdoNetPicturesPngRepository>();
            services.AddTransient<AdoNetAbstract.IPicturesWebpR16X9Repository, AdoNet.AdoNetPicturesWebpR16X9Repository>();
            services.AddTransient<AdoNetAbstract.IPicturesWebpRepository, AdoNet.AdoNetPicturesWebpRepository>();
            services.AddTransient<AdoNetAbstract.IPriceSegmentsRepository, AdoNet.AdoNetPriceSegmentsRepository>();
            services.AddTransient<AdoNetAbstract.IPricesRepository, AdoNet.AdoNetPricesRepository>();
            services.AddTransient<AdoNetAbstract.IPtsRepository, AdoNet.AdoNetPtsRepository>();
            services.AddTransient<AdoNetAbstract.IPtsTypesRepository, AdoNet.AdoNetPtsTypesRepository>();
            services.AddTransient<AdoNetAbstract.IRegionsRepository, AdoNet.AdoNetRegionsRepository>();
            services.AddTransient<AdoNetAbstract.ISalonPhonesRepository, AdoNet.AdoNetSalonPhonesRepository>();
            services.AddTransient<AdoNetAbstract.ISalonsRepository, AdoNet.AdoNetSalonsRepository>();
            services.AddTransient<AdoNetAbstract.ISectionsRepository, AdoNet.AdoNetSectionsRepository>();
            services.AddTransient<AdoNetAbstract.ISellerPhonesRepository, AdoNet.AdoNetSellerPhonesRepository>();
            services.AddTransient<AdoNetAbstract.ISellersRepository, AdoNet.AdoNetSellersRepository>();
            services.AddTransient<AdoNetAbstract.ISellerTypesRepository, AdoNet.AdoNetSellerTypesRepository>();
            services.AddTransient<AdoNetAbstract.IStatePhotosRepository, AdoNet.AdoNetStatePhotosRepository>();
            services.AddTransient<AdoNetAbstract.IStatesRepository, AdoNet.AdoNetStatesRepository>();
            services.AddTransient<AdoNetAbstract.IStatusesRepository, AdoNet.AdoNetStatusesRepository>();
            services.AddTransient<AdoNetAbstract.ISteeringWheelsRepository, AdoNet.AdoNetSteeringWheelsRepository>();
            services.AddTransient<AdoNetAbstract.ITagsRepository, AdoNet.AdoNetTagsRepository>();
            services.AddTransient<AdoNetAbstract.ITechnicalParametersRepository, AdoNet.AdoNetTechnicaParametersRepository>();
            services.AddTransient<AdoNetAbstract.ITransmissionsRepository, AdoNet.AdoNetTransmissionsRepository>();
            services.AddTransient<AdoNetAbstract.IVehicleInformationRepository, AdoNet.AdoNetVehicleInformationRepository>();
            services.AddTransient<AdoNetAbstract.IVehicleMainPhotosRepository, AdoNet.AdoNetVehicleMainPhotosRepository>();
            services.AddTransient<AdoNetAbstract.IVendorColorPhotosRepository, AdoNet.AdoNetVendorColorPhotosRepository>();
            services.AddTransient<AdoNetAbstract.IVendorColorsRepository, AdoNet.AdoNetVendorColorsRepository>();
            services.AddTransient<AdoNetAbstract.IVendorsRepository, AdoNet.AdoNetVendorsRepository>();
            services.AddTransient<AdoNetAbstract.IVideosH264Repository, AdoNet.AdoNetVideosH264Repository>();
            services.AddTransient<AdoNetAbstract.IVideosMp4R16X9Repository, AdoNet.AdoNetVideosMp4R16X9Repository>();
            services.AddTransient<AdoNetAbstract.IVideosWebmR16X9Repository, AdoNet.AdoNetVideosWebmR16X9Repository>();
            services.AddTransient<AdoNetAbstract.IVideosWebmRepository, AdoNet.AdoNetVideosWebmRepository>();
            services.AddTransient<AdoNetAbstract.IVinResolutionsRepository, AdoNet.AdoNetVinResolutionsRepository>();
            services.AddTransient<AdoNetAbstract.IVinsRepository, AdoNet.AdoNetVinsRepository>();
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
                c.CustomSchemaIds(type => type.ToString());
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
