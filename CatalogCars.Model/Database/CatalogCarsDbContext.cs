using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database
{
    public class CatalogCarsDbContext : IdentityDbContext<ApplicationUser, ApplicatonRole, Guid>
    {
        private readonly SqlConnection _connection;
        private SqlDataAdapter _dataAdapter;

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<AnnouncementAdditionalInformation> AnnouncementAdditionalInformation { get; set; }

        public DbSet<AnnouncementDescription> AnnouncementDescriptions { get; set; }

        public DbSet<AnnouncementTag> AnnouncementTags { get; set; }

        public DbSet<Availability> Availabilities { get; set; }

        public DbSet<BodyType> BodyTypes { get; set; }

        public DbSet<BodyTypeGroup> BodyTypeGroups { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<ColorType> ColorTypes { get; set; }

        public DbSet<Complectation> Complectations { get; set; }

        public DbSet<ComplectationOption> ComplectationOptions { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<ConfigurationTag> ConfigurationTags { get; set; }

        public DbSet<Coordinate> Coordinates { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Documents> Documents { get; set; }

        public DbSet<EngineType> EngineTypes { get; set; }

        public DbSet<ExternalPanorama> ExternalPanoramas { get; set; }

        public DbSet<GearType> GearTypes { get; set; }

        public DbSet<Generation> Generations { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<MarkLogo> MarkLogos { get; set; }

        public DbSet<Entities.Model> Models { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<PhotoClass> PhotoClasses { get; set; }

        public DbSet<PictureJpeg> PicturesJpeg { get; set; }

        public DbSet<PictureJpegR16x9> PicturesJpegR16X9 { get; set; }

        public DbSet<PicturePng> PicturesPng { get; set; }

        public DbSet<PicturePngR16x9> PicturesPngR16X9 { get; set; }

        public DbSet<PictureWebp> PicturesWebp { get; set; }

        public DbSet<PictureWebpR16x9> PicturesWebpR16X9 { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<PriceSegment> PriceSegments { get; set; }

        public DbSet<Pts> Pts { get; set; }

        public DbSet<PtsType> PtsTypes { get; set; }

        public DbSet<RegionInformation> Regions { get; set; }

        public DbSet<Salon> Salons { get; set; }

        public DbSet<SalonPhone> SalonPhones { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<SellerPhone> SellerPhones { get; set; }

        public DbSet<SellerType> SellerTypes { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<StatePhoto> StatePhotos { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<SteeringWheel> SteeringWheels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<TechnicalParameters> TechnicalParameters { get; set; }

        public DbSet<Transmission> Transmissions { get; set; }

        public DbSet<VehicleInformation> VehicleInformation { get; set; }

        public DbSet<VehicleMainPhoto> VehicleMainPhotos { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorColor> VendorColors { get; set; }

        public DbSet<VendorColorPhoto> VendorColorPhotos { get; set; }

        public DbSet<VideoH264> VideosH264 { get; set; }

        public DbSet<VideoMp4R16x9> VideosMp4R16X9 { get; set; }

        public DbSet<VideoWebm> VideosWebm { get; set; }

        public DbSet<VideoWebmR16x9> VideosWebmR16X9 { get; set; }

        public DbSet<Vin> Vins { get; set; }

        public DbSet<VinResolution> VinResolutions { get; set; }

        public CatalogCarsDbContext(DbContextOptions<CatalogCarsDbContext> options) : base(options)
        {
            _connection = new SqlConnection(Database.GetConnectionString());
            _dataAdapter = new SqlDataAdapter();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESKTOP-9CDGA5B;Database=CatalogCars;User ID=sa;Password=sa;" +
                        "Trusted_Connection=True;", b => b.MigrationsAssembly("CatalogCars.Resource.Api"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicatonRole>().HasData(new ApplicatonRole
            {
                Id = Guid.Parse("B867520A-92DB-4658-BE39-84DA53A601C0"),
                Name = "Администратор",
                NormalizedName = "АДМИНИСТРАТОР"
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.Parse("21F7B496-C675-4E8A-A34C-FC5EC0762FDB"),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "andrey.levchenko.2001@gmail.com",
                NormalizedEmail = "ANDREY.LEVCHENKO.2001@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("B867520A-92DB-4658-BE39-84DA53A601C0"),
                UserId = Guid.Parse("21F7B496-C675-4E8A-A34C-FC5EC0762FDB")
            });

            builder.Entity<Announcement>()
                .HasOne(announcement => announcement.State)
                .WithOne(state => state.Announcement)
                .HasForeignKey<State>(state => state.AnnouncementId);

            builder.Entity<Announcement>()
                .HasOne(announcement => announcement.Price)
                .WithOne(price => price.Announcement)
                .HasForeignKey<Price>(price => price.AnnouncementId);

            builder.Entity<Announcement>()
                .HasOne(announcement => announcement.Documents)
                .WithOne(documents => documents.Announcement)
                .HasForeignKey<Documents>(documents => documents.AnnouncementId);

            builder.Entity<Announcement>()
                .HasOne(announcement => announcement.Vehicle)
                .WithOne(vehicle => vehicle.Announcement)
                .HasForeignKey<VehicleInformation>(vehicle => vehicle.AnnouncementId);

            builder.Entity<Announcement>()
                .HasOne(announcement => announcement.Description)
                .WithOne(description => description.Announcement)
                .HasForeignKey<AnnouncementDescription>(description => description.AnnouncementId);

            builder.Entity<Announcement>()
                .HasOne(announcement => announcement.AdditionalInformation)
                .WithOne(additionalInformation => additionalInformation.Announcement)
                .HasForeignKey<AnnouncementAdditionalInformation>(additionalInformation => additionalInformation.AnnouncementId);

            builder.Entity<Announcement>()
                .HasMany(announcement => announcement.Tags)
                .WithOne(tag => tag.Announcement)
                .HasForeignKey(tag => tag.AnnouncementId);

            builder.Entity<Availability>()
                .HasMany(availability => availability.Announcements)
                .WithOne(announcement => announcement.Availability)
                .HasForeignKey(announcement => announcement.AvailabilityId);

            builder.Entity<BodyType>()
                .HasMany(bodyType => bodyType.Configurations)
                .WithOne(configuration => configuration.BodyType)
                .HasForeignKey(configuration => configuration.BodyTypeId);

            builder.Entity<BodyTypeGroup>()
                .HasMany(bodyTypeGroup => bodyTypeGroup.BodyTypes)
                .WithOne(bodyType => bodyType.BodyTypeGroup)
                .HasForeignKey(bodyType => bodyType.BodyTypeGroupId);

            builder.Entity<Category>()
                .HasMany(category => category.Announcements)
                .WithOne(announcement => announcement.Category)
                .HasForeignKey(announcement => announcement.CategoryId);

            builder.Entity<Color>()
                .HasMany(color => color.Announcements)
                .WithOne(announcement => announcement.Color)
                .HasForeignKey(announcement => announcement.ColorId);

            builder.Entity<ColorType>()
                .HasMany(colorType => colorType.VendorColors)
                .WithOne(vendorColor => vendorColor.ColorType)
                .HasForeignKey(vendorColor => vendorColor.ColorTypeId);

            builder.Entity<Complectation>()
                .HasMany(complectation => complectation.VendorColors)
                .WithOne(vendorColor => vendorColor.Complectation)
                .HasForeignKey(vendorColor => vendorColor.ComplectationId);

            builder.Entity<Complectation>()
                .HasMany(complectation => complectation.Options)
                .WithOne(option => option.Complectation)
                .HasForeignKey(option => option.ComplectationId);

            builder.Entity<Configuration>()
                .HasOne(configuration => configuration.MainPhoto)
                .WithOne(mainPhoto => mainPhoto.Configuration)
                .HasForeignKey<VehicleMainPhoto>(mainPhoto => mainPhoto.ConfigurationId);

            builder.Entity<Configuration>()
                .HasMany(configuration => configuration.Tags)
                .WithOne(tag => tag.Configuration)
                .HasForeignKey(tag => tag.ConfigurationId);

            builder.Entity<Currency>()
                .HasMany(currency => currency.Prices)
                .WithOne(price => price.Currency)
                .HasForeignKey(price => price.CurrencyId);

            builder.Entity<Documents>()
                .HasOne(documents => documents.Pts)
                .WithOne(pts => pts.Documents)
                .HasForeignKey<Pts>(pts => pts.DocumentsId);

            builder.Entity<EngineType>()
                .HasMany(engineType => engineType.TechnicalParameters)
                .WithOne(technicalParameter => technicalParameter.EngineType)
                .HasForeignKey(technicalParameter => technicalParameter.EngineTypeId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.VideoH264)
                .WithOne(video => video.ExternalPanorama)
                .HasForeignKey<VideoH264>(video => video.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.VideoWebm)
                .WithOne(video => video.ExternalPanorama)
                .HasForeignKey<VideoWebm>(video => video.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.PicturePng)
                .WithOne(picture => picture.ExternalPanorama)
                .HasForeignKey<PicturePng>(picture => picture.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.PictureJpeg)
                .WithOne(picture => picture.ExternalPanorama)
                .HasForeignKey<PictureJpeg>(picture => picture.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.PictureWebp)
                .WithOne(picture => picture.ExternalPanorama)
                .HasForeignKey<PictureWebp>(picture => picture.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.VideoMp4R16x9)
                .WithOne(video => video.ExternalPanorama)
                .HasForeignKey<VideoMp4R16x9>(video => video.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.VideoWebmR16x9)
                .WithOne(video => video.ExternalPanorama)
                .HasForeignKey<VideoWebmR16x9>(video => video.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.PicturePngR16x9)
                .WithOne(picture => picture.ExternalPanorama)
                .HasForeignKey<PicturePngR16x9>(picture => picture.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.PictureJpegR16x9)
                .WithOne(picture => picture.ExternalPanorama)
                .HasForeignKey<PictureJpegR16x9>(picture => picture.ExternalPanoramaId);

            builder.Entity<ExternalPanorama>()
                .HasOne(externalPanorama => externalPanorama.PictureWebpR16x9)
                .WithOne(picture => picture.ExternalPanorama)
                .HasForeignKey<PictureWebpR16x9>(picture => picture.ExternalPanoramaId);

            builder.Entity<GearType>()
                .HasMany(gearType => gearType.TechnicalParameters)
                .WithOne(technicalParameter => technicalParameter.GearType)
                .HasForeignKey(technicalParameter => technicalParameter.GearTypeId);

            builder.Entity<Generation>()
                .HasMany(generation => generation.Vehicles)
                .WithOne(vehicle => vehicle.Generation)
                .HasForeignKey(vehicle => vehicle.GenerationId);

            builder.Entity<Location>()
                .HasOne(location => location.Coordinate)
                .WithOne(coordinate => coordinate.Location)
                .HasForeignKey<Coordinate>(coordinate => coordinate.LocationId);

            builder.Entity<Location>()
                .HasMany(location => location.Salons)
                .WithOne(salon => salon.Location)
                .HasForeignKey(salon => salon.LocationId);

            builder.Entity<Location>()
                .HasMany(location => location.Sellers)
                .WithOne(seller => seller.Location)
                .HasForeignKey(seller => seller.LocationId);

            builder.Entity<Mark>()
                .HasOne(mark => mark.Logo)
                .WithOne(logo => logo.Mark)
                .HasForeignKey<MarkLogo>(logo => logo.MarkId);

            builder.Entity<Mark>()
                .HasMany(mark => mark.Models)
                .WithOne(model => model.Mark)
                .HasForeignKey(model => model.MarkId);

            builder.Entity<Entities.Model>()
                .HasMany(model => model.Generations)
                .WithOne(generation => generation.Model)
                .HasForeignKey(generation => generation.ModelId);

            builder.Entity<Option>()
                .HasMany(option => option.Complectations)
                .WithOne(complectation => complectation.Option)
                .HasForeignKey(complectation => complectation.OptionId);

            builder.Entity<Phone>()
                .HasMany(phone => phone.Sellers)
                .WithOne(seller => seller.Phone)
                .HasForeignKey(seller => seller.PhoneId);

            builder.Entity<Phone>()
                .HasMany(phone => phone.Salons)
                .WithOne(salon => salon.Phone)
                .HasForeignKey(salon => salon.PhoneId);

            builder.Entity<PhotoClass>()
                .HasMany(photoClass => photoClass.States)
                .WithOne(state => state.Class)
                .HasForeignKey(state => state.ClassId);

            builder.Entity<PriceSegment>()
                .HasMany(priceSegment => priceSegment.Generations)
                .WithOne(generation => generation.PriceSegment)
                .HasForeignKey(generation => generation.PriceSegmentId);

            builder.Entity<Pts>()
                .HasOne(pts => pts.Vin)
                .WithOne(vin => vin.Pts)
                .HasForeignKey<Vin>(vin => vin.PtsId);

            builder.Entity<PtsType>()
                .HasMany(ptsType => ptsType.Pts)
                .WithOne(pts => pts.PtsType)
                .HasForeignKey(pts => pts.PtsTypeId);

            builder.Entity<RegionInformation>()
                .HasMany(region => region.Locations)
                .WithOne(location => location.Region)
                .HasForeignKey(location => location.RegionId);

            builder.Entity<Salon>()
                .HasMany(salon => salon.Phones)
                .WithOne(phone => phone.Salon)
                .HasForeignKey(phone => phone.SalonId);

            builder.Entity<Salon>()
                .HasMany(salon => salon.Announcements)
                .WithOne(announcement => announcement.Salon)
                .HasForeignKey(announcement => announcement.SalonId);

            builder.Entity<Section>()
                .HasMany(section => section.Announcements)
                .WithOne(announcement => announcement.Section)
                .HasForeignKey(announcement => announcement.SectionId);

            builder.Entity<Seller>()
                .HasMany(seller => seller.Phones)
                .WithOne(phone => phone.Seller)
                .HasForeignKey(phone => phone.SellerId);

            builder.Entity<Seller>()
                .HasMany(seller => seller.Announcements)
                .WithOne(announcement => announcement.Seller)
                .HasForeignKey(announcement => announcement.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SellerType>()
                .HasMany(sellerType => sellerType.Announcements)
                .WithOne(announcement => announcement.SellerType)
                .HasForeignKey(announcement => announcement.SellerTypeId);

            builder.Entity<State>()
                .HasOne(state => state.ExternalPanorama)
                .WithOne(externalPanorama => externalPanorama.State)
                .HasForeignKey<ExternalPanorama>(externalPanorama => externalPanorama.StateId);

            builder.Entity<State>()
                .HasMany(state => state.Photos)
                .WithOne(photo => photo.State)
                .HasForeignKey(photo => photo.StateId);

            builder.Entity<Status>()
                .HasMany(status => status.Announcements)
                .WithOne(announcement => announcement.Status)
                .HasForeignKey(announcement => announcement.StatusId);

            builder.Entity<SteeringWheel>()
                .HasMany(steeringWheel => steeringWheel.VehicleInformation)
                .WithOne(vehicle => vehicle.SteeringWheel)
                .HasForeignKey(vehicle => vehicle.SteeringWheelId);

            builder.Entity<Tag>()
                .HasMany(tag => tag.Announcements)
                .WithOne(announcement => announcement.Tag)
                .HasForeignKey(announcement => announcement.TagId);

            builder.Entity<Tag>()
                .HasMany(tag => tag.Configurations)
                .WithOne(configurations => configurations.Tag)
                .HasForeignKey(configurations => configurations.TagId);

            builder.Entity<Transmission>()
                .HasMany(transmission => transmission.TechnicalParameters)
                .WithOne(technicalParameters => technicalParameters.Transmission)
                .HasForeignKey(technicalParameters => technicalParameters.TransmissionId);

            builder.Entity<VehicleInformation>()
                .HasOne(vehicleInformation => vehicleInformation.TechnicalParameters)
                .WithOne(technicalParameters => technicalParameters.Vehicle)
                .HasForeignKey<TechnicalParameters>(technicalParameters => technicalParameters.VehicleId);

            builder.Entity<VehicleInformation>()
                .HasOne(vehicleInformation => vehicleInformation.Configuration)
                .WithOne(configuration => configuration.Vehicle)
                .HasForeignKey<Configuration>(configuration => configuration.VehicleId);

            builder.Entity<VehicleInformation>()
                .HasOne(vehicleInformation => vehicleInformation.Complectation)
                .WithOne(complectation => complectation.Vehicle)
                .HasForeignKey<Complectation>(complectation => complectation.VehicleId);

            builder.Entity<Vendor>()
                .HasMany(vendor => vendor.Vehicles)
                .WithOne(vendor => vendor.Vendor)
                .HasForeignKey(vendor => vendor.VendorId);

            builder.Entity<VendorColor>()
                .HasMany(vendorColor => vendorColor.Photos)
                .WithOne(photo => photo.VendorColor)
                .HasForeignKey(photo => photo.VendorColorId);

            builder.Entity<VinResolution>()
                .HasMany(vinResolution => vinResolution.Vins)
                .WithOne(vin => vin.Resolution)
                .HasForeignKey(vin => vin.ResolutionId);
        }

        public object ExecuteScalar(string query)
        {
            var id = new object();
            var sqlCommand = new SqlCommand();

            _connection.Open();

            sqlCommand.Connection = _connection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = query;

            id = sqlCommand.ExecuteScalar();

            _connection.Close();

            return id;
        }

        public void SaveEntity(object entity, EntityState state)
        {
            Entry(entity).State = state;
            SaveChanges();
        }

        public DataTable ExecuteQuery(string query, List<SqlParameter> sqlParameters)
        {
            var dataTable = new DataTable();
            var sqlCommand = new SqlCommand();

            _connection.Open();

            sqlCommand.Connection = _connection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = query;

            foreach (var sqlParameter in sqlParameters)
            {
                sqlCommand.Parameters.Add(sqlParameter);
            }

            dataTable.Load(sqlCommand.ExecuteReader());

            _connection.Close();

            return dataTable;
        }

        public DataTable ExecuteQuery(string query)
        {
            var result = new DataTable();

            _connection.Open();

            _dataAdapter = new SqlDataAdapter(query, _connection);
            _dataAdapter.Fill(result);

            _connection.Close();

            return result;
        }
    }
}
