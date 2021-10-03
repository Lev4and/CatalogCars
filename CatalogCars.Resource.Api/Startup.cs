using CatalogCars.Authorization.Common;
using CatalogCars.Model.Common;
using CatalogCars.Model.Database;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Availability;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyType;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyTypeGroup;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Category;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Color;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.ColorType;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Coordinate;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Currency;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.EngineType;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.GearType;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Mark;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Option;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Phone;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PhotoClass;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PriceSegment;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PtsType;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Region;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Section;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Seller;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SellerType;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Status;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SteeringWheel;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Tag;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Transmission;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Vendor;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.VinResolution;
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

            #region Сортировщики
            services.AddTransient<IAvailabilitiesSorter, DefaultAvailabilitiesSorter>();
            services.AddTransient<IAvailabilitiesSorter, ByAscendingNameAvailabilitiesSorter>();
            services.AddTransient<IAvailabilitiesSorter, ByDescendingNameAvailabilitiesSorter>();

            services.AddTransient<IBodyTypesSorter, DefaultBodyTypesSorter>();
            services.AddTransient<IBodyTypesSorter, ByAscendingNameBodyTypesSorter>();
            services.AddTransient<IBodyTypesSorter, ByDescendingNameBodyTypesSorter>();
            services.AddTransient<IBodyTypesSorter, ByAscendingAutoClassBodyTypesSorter>();
            services.AddTransient<IBodyTypesSorter, ByDescendingAutoClassBodyTypesSorter>();
            services.AddTransient<IBodyTypesSorter, ByAscendingBodyTypeGroupNameBodyTypesSorter>();
            services.AddTransient<IBodyTypesSorter, ByDescendingBodyTypeGroupNameBodyTypesSorter>();

            services.AddTransient<IBodyTypeGroupsSorter, DefaultBodyTypeGroupsSorter>();
            services.AddTransient<IBodyTypeGroupsSorter, ByAscendingNameBodyTypeGroupsSorter>();
            services.AddTransient<IBodyTypeGroupsSorter, ByDescendingNameBodyTypeGroupsSorter>();

            services.AddTransient<ICategoriesSorter, DefaultCategoriesSorter>();
            services.AddTransient<ICategoriesSorter, ByAscendingNameCategoriesSorter>();
            services.AddTransient<ICategoriesSorter, ByDescendingNameCategoriesSorter>();

            services.AddTransient<IColorsSorter, DefaultColorsSorter>();
            services.AddTransient<IColorsSorter, ByAscendingNameColorsSorter>();
            services.AddTransient<IColorsSorter, ByDescendingNameColorsSorter>();

            services.AddTransient<IColorTypesSorter, DefaultColorTypesSorter>();
            services.AddTransient<IColorTypesSorter, ByAscendingNameColorTypesSorter>();
            services.AddTransient<IColorTypesSorter, ByDescendingNameColorTypesSorter>();

            services.AddTransient<ICoordinatesSorter, DefaultCoordinatesSorter>();
            services.AddTransient<ICoordinatesSorter, ByAscendingNameCoordinatesSorter>();
            services.AddTransient<ICoordinatesSorter, ByDescendingNameCoordinatesSorter>();
            services.AddTransient<ICoordinatesSorter, ByAscendingRegionNameCoordinatesSorter>();
            services.AddTransient<ICoordinatesSorter, ByDescendingRegionNameCoordinatesSorter>();
            services.AddTransient<ICoordinatesSorter, ByAscendingLocationAddressCoordinatesSorter>();
            services.AddTransient<ICoordinatesSorter, ByDescendingLocationAddressCoordinatesSorter>();

            services.AddTransient<ICurrenciesSorter, DefaultCurrenciesSorter>();
            services.AddTransient<ICurrenciesSorter, ByAscendingNameCurrenciesSorter>();
            services.AddTransient<ICurrenciesSorter, ByDescendingNameCurrenciesSorter>();

            services.AddTransient<IEngineTypesSorter, DefaultEngineTypesSorter>();
            services.AddTransient<IEngineTypesSorter, ByAscendingNameEngineTypesSorter>();
            services.AddTransient<IEngineTypesSorter, ByDescendingNameEngineTypesSorter>();

            services.AddTransient<IGearTypesSorter, DefaultGearTypesSorter>();
            services.AddTransient<IGearTypesSorter, ByAscendingNameGearTypesSorter>();
            services.AddTransient<IGearTypesSorter, ByDescendingNameGearTypesSorter>();

            services.AddTransient<IGenerationsSorter, DefaultGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByAscendingNameGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByDescendingNameGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByAscendingMarkNameGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByAscendingYearFromGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByAscendingModelNameGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByDescendingMarkNameGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByDescendingYearFromGenerationsSorter>();
            services.AddTransient<IGenerationsSorter, ByDescendingModelNameGenerationsSorter>();

            services.AddTransient<ILocationsSorter, DefaultLocationsSorter>();
            services.AddTransient<ILocationsSorter, ByAscendingNameLocationsSorter>();
            services.AddTransient<ILocationsSorter, ByDescendingNameLocationsSorter>();
            services.AddTransient<ILocationsSorter, ByAscendingRegionNameLocationsSorter>();
            services.AddTransient<ILocationsSorter, ByDescendingRegionNameLocationsSorter>();

            services.AddTransient<IMarksSorter, DefaultMarksSorter>();
            services.AddTransient<IMarksSorter, ByAscendingNameMarksSorter>();
            services.AddTransient<IMarksSorter, ByDescendingNameMarksSorter>();

            services.AddTransient<IModelsSorter, DefaultModelsSorter>();
            services.AddTransient<IModelsSorter, ByAscendingNameModelsSorter>();
            services.AddTransient<IModelsSorter, ByDescendingNameModelsSorter>();
            services.AddTransient<IModelsSorter, ByAscendingMarkNameModelsSorter>();
            services.AddTransient<IModelsSorter, ByDescendingMarkNameModelsSorter>();

            services.AddTransient<IOptionsSorter, DefaultOptionsSorter>();
            services.AddTransient<IOptionsSorter, ByAscendingNameOptionsSorter>();
            services.AddTransient<IOptionsSorter, ByDescendingNameOptionsSorter>();

            services.AddTransient<IPhonesSorter, DefaultPhonesSorter>();
            services.AddTransient<IPhonesSorter, ByAscendingNamePhonesSorter>();
            services.AddTransient<IPhonesSorter, ByDescendingNamePhonesSorter>();

            services.AddTransient<IPhotoClassesSorter, DefaultPhotoClassesSorter>();
            services.AddTransient<IPhotoClassesSorter, ByAscendingNamePhotoClassesSorter>();
            services.AddTransient<IPhotoClassesSorter, ByDescendingNamePhotoClassesSorter>();

            services.AddTransient<IPriceSegmentsSorter, DefaultPriceSegmentsSorter>();
            services.AddTransient<IPriceSegmentsSorter, ByAscendingNamePriceSegmentsSorter>();
            services.AddTransient<IPriceSegmentsSorter, ByDescendingNamePriceSegmentsSorter>();

            services.AddTransient<IPtsTypesSorter, DefaultPtsTypesSorter>();
            services.AddTransient<IPtsTypesSorter, ByAscendingNamePtsTypesSorter>();
            services.AddTransient<IPtsTypesSorter, ByDescendingNamePtsTypesSorter>();

            services.AddTransient<IRegionsSorter, DefaultRegionsSorter>();
            services.AddTransient<IRegionsSorter, ByAscendingNameRegionsSorter>();
            services.AddTransient<IRegionsSorter, ByDescendingNameRegionsSorter>();

            services.AddTransient<ISalonsSorter, DefaultSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByAscendingNameSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByDescendingNameSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByAscendingRegionNameSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByDescendingRegionNameSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByAscendingLocationAddressSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByDescendingLocationAddressSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByAscendingRegistrationDateSalonsSorter>();
            services.AddTransient<ISalonsSorter, ByDescendingRegistrationDateSalonsSorter>();

            services.AddTransient<ISectionsSorter, DefaultSectionsSorter>();
            services.AddTransient<ISectionsSorter, ByAscendingNameSectionsSorter>();
            services.AddTransient<ISectionsSorter, ByDescendingNameSectionsSorter>();

            services.AddTransient<ISellersSorter, DefaultSellersSorter>();
            services.AddTransient<ISellersSorter, ByAscendingNameSellersSorter>();
            services.AddTransient<ISellersSorter, ByDescendingNameSellersSorter>();
            services.AddTransient<ISellersSorter, ByAscendingRegionNameSellersSorter>();
            services.AddTransient<ISellersSorter, ByDescendingRegionNameSellersSorter>();
            services.AddTransient<ISellersSorter, ByAscendingLocationAddressSellersSorter>();
            services.AddTransient<ISellersSorter, ByDescendingLocationAddressSellersSorter>();

            services.AddTransient<ISellerTypesSorter, DefaultSellerTypesSorter>();
            services.AddTransient<ISellerTypesSorter, ByAscendingNameSellerTypesSorter>();
            services.AddTransient<ISellerTypesSorter, ByDescendingNameSellerTypesSorter>();

            services.AddTransient<IStatusesSorter, DefaultStatusesSorter>();
            services.AddTransient<IStatusesSorter, ByAscendingNameStatusesSorter>();
            services.AddTransient<IStatusesSorter, ByDescendingNameStatusesSorter>();

            services.AddTransient<ISteeringWheelsSorter, DefaultSteeringWheelsSorter>();
            services.AddTransient<ISteeringWheelsSorter, ByAscendingNameSteeringWheelsSorter>();
            services.AddTransient<ISteeringWheelsSorter, ByDescendingNameSteeringWheelsSorter>();

            services.AddTransient<ITagsSorter, DefaultTagsSorter>();
            services.AddTransient<ITagsSorter, ByAscendingNameTagsSorter>();
            services.AddTransient<ITagsSorter, ByDescendingNameTagsSorter>();

            services.AddTransient<ITransmissionsSorter, DefaultTransmissionsSorter>();
            services.AddTransient<ITransmissionsSorter, ByAscendingNameTransmissionsSorter>();
            services.AddTransient<ITransmissionsSorter, ByDescendingNameTransmissionsSorter>();

            services.AddTransient<IVendorsSorter, DefaultVendorsSorter>();
            services.AddTransient<IVendorsSorter, ByAscendingNameVendorsSorter>();
            services.AddTransient<IVendorsSorter, ByDescendingNameVendorsSorter>();

            services.AddTransient<IVinResolutionsSorter, DefaultVinResolutionsSorter>();
            services.AddTransient<IVinResolutionsSorter, ByAscendingNameVinResolutionsSorter>();
            services.AddTransient<IVinResolutionsSorter, ByDescendingNameVinResolutionsSorter>();
            #endregion

            services.AddTransient<EntityFrameworkAbstract.IAvailabilitiesRepository, EntityFramework.EFAvailabilitiesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IBodyTypeGroupsRepository, EntityFramework.EFBodyTypeGroupsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IBodyTypesRepository, EntityFramework.EFBodyTypesRepository>();
            services.AddTransient<EntityFrameworkAbstract.ICategoriesRepository, EntityFramework.EFCategoriesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IColorsRepository, EntityFramework.EFColorsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IColorTypesRepository, EntityFramework.EFColorTypesRepository>();
            services.AddTransient<EntityFrameworkAbstract.ICoordinatesRepository, EntityFramework.EFCoordinatesRepository>();
            services.AddTransient<EntityFrameworkAbstract.ICurrenciesRepository, EntityFramework.EFCurrenciesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IEngineTypesRepository, EntityFramework.EFEngineTypesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IGearTypesRepository, EntityFramework.EFGearTypesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IGenerationsRepository, EntityFramework.EFGenerationsRepository>();
            services.AddTransient<EntityFrameworkAbstract.ILocationsRepository, EntityFramework.EFLocationsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IMarksRepository, EntityFramework.EFMarksRepository>();
            services.AddTransient<EntityFrameworkAbstract.IModelsRepository, EntityFramework.EFModelsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IOptionsRepository, EntityFramework.EFOptionsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IPhonesRepository, EntityFramework.EFPhonesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IPhotoClassesRepository, EntityFramework.EFPhotoClassesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IPriceSegmentsRepository, EntityFramework.EFPriceSegmentsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IPtsTypesRepository, EntityFramework.EFPtsTypesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IRegionsRepository, EntityFramework.EFRegionsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IRolesRepository, EntityFramework.EFRolesRepository>();
            services.AddTransient<EntityFrameworkAbstract.ISalonsRepository, EntityFramework.EFSalonsRepository>();
            services.AddTransient<EntityFrameworkAbstract.ISectionsRepository, EntityFramework.EFSectionsRepository>();
            services.AddTransient<EntityFrameworkAbstract.ISellersRepository, EntityFramework.EFSellersRepository>();
            services.AddTransient<EntityFrameworkAbstract.ISellerTypesRepository, EntityFramework.EFSellerTypesRepository>();
            services.AddTransient<EntityFrameworkAbstract.IStatusesRepository, EntityFramework.EFStatusesRepository>();
            services.AddTransient<EntityFrameworkAbstract.ISteeringWheelsRepository, EntityFramework.EFSteeringWheelsRepository>();
            services.AddTransient<EntityFrameworkAbstract.ITagsRepository, EntityFramework.EFTagsRepository>();
            services.AddTransient<EntityFrameworkAbstract.ITransmissionsRepository, EntityFramework.EFTransmissionsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IUsersRepository, EntityFramework.EFUsersRepository>();
            services.AddTransient<EntityFrameworkAbstract.IVinResolutionsRepository, EntityFramework.EFVinResolutionsRepository>();
            services.AddTransient<EntityFrameworkAbstract.IVendorsRepository, EntityFramework.EFVendorsRepository>();
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
