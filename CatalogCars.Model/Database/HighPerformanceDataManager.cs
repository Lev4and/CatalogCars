using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;

namespace CatalogCars.Model.Database
{
    public class HighPerformanceDataManager
    {
        public IAnnouncementAdditionalInformationRepository AnnouncementAdditionalInformation { get; set; }

        public IAnnouncementDescriptionsRepository AnnouncementDescriptions { get; set; }

        public IAnnouncementsRepository Announcements { get; set; }

        public IAnnouncementTagsRepository AnnouncementTags { get; set; }

        public IAvailabilitiesRepository Availabilities { get; set; }

        public IBodyTypeGroupsRepository BodyTypeGroups { get; set; }

        public IBodyTypesRepository BodyTypes { get; set; }

        public ICategoriesRepository Categories { get; set; }

        public IColorsRepository Colors { get; set; }

        public IColorTypesRepository ColorTypes { get; set; }

        public IComplectationOptionsRepository ComplectationOptions { get; set; }

        public IComplectationsRepository Complectations { get; set; }

        public IConfigurationsRepository Configurations { get; set; }

        public IConfigurationTagsRepository ConfigurationTags { get; set; }

        public ICoordinatesRepository Coordinates { get; set; }

        public ICurrenciesRepository Currencies { get; set; }

        public IDocumentsRepository Documents { get; set; }

        public IEngineTypesRepository EngineTypes { get; set; }

        public IExternalPanoramasRepository ExternalPanoramas { get; set; }

        public IGearTypesRepository GearTypes { get; set; }

        public IGenerationsRepository Generations { get; set; }

        public ILocationsRepository Locations { get; set; }

        public IMarkLogosRepository MarkLogos { get; set; }

        public IMarksRepository Marks { get; set; }

        public IModelsRepository Models { get; set; }

        public IOptionsRepository Options { get; set; }

        public IPhonesRepository Phones { get; set; }

        public IPhotoClassesRepository PhotoClasses { get; set; }

        public IPicturesJpegR16X9Repository PicturesJpegR16X9 { get; set; }

        public IPicturesJpegRepository PicturesJpeg { get; set; }

        public IPicturesPngR16X9Repository PicturesPngR16X9 { get; set; }

        public IPicturesPngRepository PicturesPng { get; set; }

        public IPicturesWebpR16X9Repository PicturesWebpR16X9 { get; set; }

        public IPicturesWebpRepository PicturesWebp { get; set; }

        public IPriceSegmentsRepository PriceSegments { get; set; }

        public IPricesRepository Prices { get; set; }

        public IPtsRepository Pts { get; set; }

        public IPtsTypesRepository PtsTypes { get; set; }

        public IRegionsRepository Regions { get; set; }

        public ISalonPhonesRepository SalonPhones { get; set; }

        public ISalonsRepository Salons { get; set; }

        public ISectionsRepository Sections { get; set; }

        public ISellerPhonesRepository SellerPhones { get; set; }

        public ISellersRepository Sellers { get; set; }

        public ISellerTypesRepository SellerTypes { get; set; }

        public IStatePhotosRepository StatePhotos { get; set; }

        public IStatesRepository States { get; set; }

        public IStatusesRepository Statuses { get; set; }

        public ISteeringWheelsRepository SteeringWheels { get; set; }

        public ITagsRepository Tags { get; set; }

        public ITechnicalParametersRepository TechnicalParameters { get; set; }

        public ITransmissionsRepository Transmissions { get; set; }

        public IVehicleInformationRepository VehicleInformation { get; set; }

        public IVehicleMainPhotosRepository VehicleMainPhotos { get; set; }

        public IVendorColorPhotosRepository VendorColorPhotos { get; set; }

        public IVendorColorsRepository VendorColors { get; set; }

        public IVendorsRepository Vendors { get; set; }

        public IVideosH264Repository VideosH264 { get; set; }

        public IVideosMp4R16X9Repository VideosMp4R16X9 { get; set; }

        public IVideosWebmR16X9Repository VideosWebmR16X9 { get; set; }

        public IVideosWebmRepository VideosWebm { get; set; }

        public IVinResolutionsRepository VinResolutions { get; set; }

        public IVinsRepository Vins { get; set; }

        public HighPerformanceDataManager(IAnnouncementAdditionalInformationRepository announcementAdditionalInformation, 
            IAnnouncementDescriptionsRepository announcementDescriptions, IAnnouncementsRepository announcements, 
            IAnnouncementTagsRepository announcementTags, IAvailabilitiesRepository availabilities, 
            IBodyTypeGroupsRepository bodyTypeGroups, IBodyTypesRepository bodyTypes, ICategoriesRepository categories, 
            IColorsRepository colors, IColorTypesRepository colorTypes, IComplectationOptionsRepository complectationOptions, 
            IComplectationsRepository complectations, IConfigurationsRepository configurations, 
            IConfigurationTagsRepository configurationTags, ICoordinatesRepository coordinates, ICurrenciesRepository currencies, 
            IDocumentsRepository documents, IEngineTypesRepository engineTypes, IExternalPanoramasRepository externalPanoramas, 
            IGearTypesRepository gearTypes, IGenerationsRepository generations, ILocationsRepository locations, 
            IMarkLogosRepository markLogos, IMarksRepository marks, IModelsRepository models, IOptionsRepository options, 
            IPhonesRepository phones, IPhotoClassesRepository photoClasses, IPicturesJpegR16X9Repository picturesJpegR16X9, 
            IPicturesJpegRepository picturesJpeg, IPicturesPngR16X9Repository picturesPngR16X9, IPicturesPngRepository picturesPng, 
            IPicturesWebpR16X9Repository picturesWebpR16X9, IPicturesWebpRepository picturesWebp, 
            IPriceSegmentsRepository priceSegments, IPricesRepository prices, IPtsRepository pts, IPtsTypesRepository ptsTypes, 
            IRegionsRepository regions, ISalonPhonesRepository salonPhones, ISalonsRepository salons, ISectionsRepository sections, 
            ISellerPhonesRepository sellerPhones, ISellersRepository sellers, ISellerTypesRepository sellerTypes, IStatePhotosRepository statePhotos, IStatesRepository states, IStatusesRepository statuses, 
            ISteeringWheelsRepository steeringWheels, ITagsRepository tags, ITechnicalParametersRepository technicalParameters, 
            ITransmissionsRepository transmissions, IVehicleInformationRepository vehicleInformation, 
            IVehicleMainPhotosRepository vehicleMainPhotos, IVendorColorPhotosRepository vendorColorPhotos, 
            IVendorColorsRepository vendorColors, IVendorsRepository vendors, IVideosH264Repository videosH264, 
            IVideosMp4R16X9Repository videosMp4R16X9, IVideosWebmR16X9Repository videosWebmR16X9, IVideosWebmRepository videosWebm, 
            IVinResolutionsRepository vinResolutions, IVinsRepository vins)
        {
            AnnouncementAdditionalInformation = announcementAdditionalInformation;
            AnnouncementDescriptions = announcementDescriptions;
            Announcements = announcements;
            AnnouncementTags = announcementTags;
            Availabilities = availabilities;
            BodyTypeGroups = bodyTypeGroups;
            BodyTypes = bodyTypes;
            Categories = categories;
            Colors = colors;
            ColorTypes = colorTypes;
            ComplectationOptions = complectationOptions;
            Complectations = complectations;
            Configurations = configurations;
            ConfigurationTags = configurationTags;
            Coordinates = coordinates;
            Currencies = currencies;
            Documents = documents;
            EngineTypes = engineTypes;
            ExternalPanoramas = externalPanoramas;
            GearTypes = gearTypes;
            Generations = generations;
            Locations = locations;
            MarkLogos = markLogos;
            Marks = marks;
            Models = models;
            Options = options;
            Phones = phones;
            PhotoClasses = photoClasses;
            PicturesJpegR16X9 = picturesJpegR16X9;
            PicturesJpeg = picturesJpeg;
            PicturesPngR16X9 = picturesPngR16X9;
            PicturesPng = picturesPng;
            PicturesWebpR16X9 = picturesWebpR16X9;
            PicturesWebp = picturesWebp;
            PriceSegments = priceSegments;
            Prices = prices;
            Pts = pts;
            PtsTypes = ptsTypes;
            Regions = regions;
            SalonPhones = salonPhones;
            Salons = salons;
            Sections = sections;
            SellerPhones = sellerPhones;
            Sellers = sellers;
            SellerTypes = sellerTypes;
            StatePhotos = statePhotos;
            States = states;
            Statuses = statuses;
            SteeringWheels = steeringWheels;
            Tags = tags;
            TechnicalParameters = technicalParameters;
            Transmissions = transmissions;
            VehicleInformation = vehicleInformation;
            VehicleMainPhotos = vehicleMainPhotos;
            VendorColorPhotos = vendorColorPhotos;
            VendorColors = vendorColors;
            Vendors = vendors;
            VideosH264 = videosH264;
            VideosMp4R16X9 = videosMp4R16X9;
            VideosWebmR16X9 = videosWebmR16X9;
            VideosWebm = videosWebm;
            VinResolutions = vinResolutions;
            Vins = vins;
        }
    }
}
