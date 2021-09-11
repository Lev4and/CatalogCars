using CatalogCars.Model.Database;
using System;
using AutoRu = CatalogCars.Model.Converters.AutoRu;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Importers.HighPerformance
{
    public class AnnouncementImporter
    {
        private readonly HighPerformanceDataManager _dataManager;

        public AnnouncementImporter(HighPerformanceDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        private Guid SaveOrGetColor(string colorHex)
        {
            var color = new Entities.Color()
            {
                Value = colorHex
            };

            _dataManager.Colors.Save(ref color);

            return color.Id;
        }

        private Guid? SaveOrGetSalon(AutoRu.Salon salonAutoRu)
        {
            if (!string.IsNullOrEmpty(salonAutoRu.Name))
            {
                var salon = new Entities.Salon()
                {
                    LocationId = SaveOrGetLocation(salonAutoRu.Place),
                    IsOficial = salonAutoRu.IsOficial,
                    ActualStock = salonAutoRu.ActualStock,
                    LoyaltyProgram = salonAutoRu.LoyaltyProgram,
                    Code = salonAutoRu.Code,
                    Name = salonAutoRu.Name,
                    RegistrationDate = salonAutoRu.RegistrationDate
                };

                _dataManager.Salons.Save(ref salon);

                SaveSalonPhones(salonAutoRu.Phones, salon.Id);

                return salon.Id;
            }

            return null;
        }

        private Guid SaveOrGetLocation(AutoRu.Place locationAutoRu)
        {
            var location = new Entities.Location()
            {
                RegionId = SaveOrGetRegion(locationAutoRu.Region),
                Address = locationAutoRu.Address,
                GeobaseId = locationAutoRu.GeobaseId
            };

            if(locationAutoRu.Coordinate != null)
            {
                location.Coordinate = new Entities.Coordinate()
                {
                    Latitude = locationAutoRu.Coordinate.Latitude,
                    Longitude = locationAutoRu.Coordinate.Longitude
                };
            }

            _dataManager.Locations.Save(ref location);

            SaveCoordinate(locationAutoRu.Coordinate, location.Id);

            return location.Id;
        }

        private Guid? SaveOrGetRegion(AutoRu.Region regionAutoRu)
        {
            if(regionAutoRu != null)
            {
                var region = new Entities.RegionInformation()
                {
                    Name = regionAutoRu.Name,
                    Dative = regionAutoRu.Dative,
                    Genitive = regionAutoRu.Genitive,
                    StringId = regionAutoRu.StringId,
                    ParentIds = string.Join(", ", regionAutoRu.ParentIds),
                    Accusative = regionAutoRu.Accusative,
                    Preposition = regionAutoRu.Preposition,
                    Prepositional = regionAutoRu.Prepositional,
                    Latitude = regionAutoRu.Latitude,
                    Longitude = regionAutoRu.Longitude
                };

                _dataManager.Regions.Save(ref region);

                return region.Id;
            }

            return null;
        }

        private Guid SaveOrGetPhone(AutoRu.Phone phoneAutoRu)
        {
            var phone = new Entities.Phone()
            {
                Value = phoneAutoRu.Value
            };

            _dataManager.Phones.Save(ref phone);

            return phone.Id;
        }

        private Guid SaveOrGetSeller(AutoRu.Seller sellerAutoRu)
        {
            var seller = new Entities.Seller()
            {
                LocationId = SaveOrGetLocation(sellerAutoRu.Location),
                Name = sellerAutoRu.Name
            };

            _dataManager.Sellers.Save(ref seller);

            return seller.Id;
        }

        private Guid SaveOrGetStatus(string statusAutoRu)
        {
            var status = new Entities.Status()
            {
                Name = statusAutoRu,
                RuName = statusAutoRu
            };

            _dataManager.Statuses.Save(ref status);

            return status.Id;
        }

        private Guid SaveOrGetSection(string sectionAutoRu)
        {
            var section = new Entities.Section()
            {
                Name = sectionAutoRu,
                RuName = sectionAutoRu
            };

            _dataManager.Sections.Save(ref section);

            return section.Id;
        }

        private Guid SaveOrGetCategory(string categoryAutoRu)
        {
            var category = new Entities.Category()
            {
                Name = categoryAutoRu,
                RuName = categoryAutoRu
            };

            _dataManager.Categories.Save(ref category);

            return category.Id;
        }

        private Guid SaveOrGetSellerType(string sellerTypeAutoRu)
        {
            var sellerType = new Entities.SellerType()
            {
                Name = sellerTypeAutoRu,
                RuName = sellerTypeAutoRu
            };

            _dataManager.SellerTypes.Save(ref sellerType);

            return sellerType.Id;
        }

        private Guid SaveOrGetAvailability(string availabilityAutoRu)
        {
            var availability = new Entities.Availability()
            {
                Name = availabilityAutoRu,
                RuName = availabilityAutoRu
            };

            _dataManager.Availabilities.Save(ref availability);

            return availability.Id;
        }

        private Guid SaveOrGetCurrency(string currencyAutoRu)
        {
            var currency = new Entities.Currency()
            {
                Name = currencyAutoRu
            };

            _dataManager.Currencies.Save(ref currency);

            return currency.Id;
        }

        private Guid? SaveOrGetPtsType(string ptsTypeAutoRu)
        {
            if (!string.IsNullOrEmpty(ptsTypeAutoRu))
            {
                var ptsType = new Entities.PtsType()
                {
                    Name = ptsTypeAutoRu,
                    RuName = ptsTypeAutoRu
                };

                _dataManager.PtsTypes.Save(ref ptsType);

                return ptsType.Id;
            }

            return null;
        }

        private Guid? SaveOrGetVinResolution(string vinResolutionAutoRu)
        {
            if (!string.IsNullOrEmpty(vinResolutionAutoRu))
            {
                var vinResolution = new Entities.VinResolution()
                {
                    Name = vinResolutionAutoRu,
                    RuName = vinResolutionAutoRu
                };

                _dataManager.VinResolutions.Save(ref vinResolution);

                return vinResolution.Id;
            }

            return null;
        }

        private Guid SaveOrGetSteeringWheel(string steeringWheelAutoRu)
        {
            var steeringWheel = new Entities.SteeringWheel()
            {
                Name = steeringWheelAutoRu,
                RuName = steeringWheelAutoRu
            };

            _dataManager.SteeringWheels.Save(ref steeringWheel);

            return steeringWheel.Id;
        }

        private Guid SaveOrGetGeneration(AutoRu.Mark markAutoRu, AutoRu.Model modelAutoRu, AutoRu.Generation generationAutoRu)
        {
            var generation = new Entities.Generation()
            {
                ModelId = SaveOrGetModel(markAutoRu, modelAutoRu),
                PriceSegmentId = SaveOrGetPriceSegment(generationAutoRu?.PriceSegment),
                YearFrom = generationAutoRu?.YearFrom,
                Name = generationAutoRu?.Name,
                RuName = generationAutoRu?.RuName
            };

            _dataManager.Generations.Save(ref generation);

            return generation.Id;
        }

        private Guid SaveOrGetMark(AutoRu.Mark markAutoRu)
        {
            if (!_dataManager.Marks.Contains(markAutoRu.Name))
            {
                var mark = new Entities.Mark()
                {
                    Code = markAutoRu.Code,
                    Name = markAutoRu.Name,
                    RuName = markAutoRu.RuName
                };

                _dataManager.Marks.Save(ref mark);

                SaveMarkLogo(markAutoRu.Logo, mark.Id);

                return mark.Id;
            }

            return _dataManager.Marks.GetMarkId(markAutoRu.Name);
        }

        private Guid SaveOrGetModel(AutoRu.Mark markAutoRu, AutoRu.Model modelAutoRu)
        {
            var model = new Entities.Model()
            {
                MarkId = SaveOrGetMark(markAutoRu),
                Code = modelAutoRu.Code,
                Name = modelAutoRu.Name,
                RuName = modelAutoRu.RuName
            };

            _dataManager.Models.Save(ref model);

            return model.Id;
        }

        private Guid? SaveOrGetPriceSegment(string priceSegmentAutoRu)
        {
            if (!string.IsNullOrEmpty(priceSegmentAutoRu))
            {
                var priceSegment = new Entities.PriceSegment()
                {
                    Name = priceSegmentAutoRu,
                    RuName = priceSegmentAutoRu
                };

                _dataManager.PriceSegments.Save(ref priceSegment);

                return priceSegment.Id;
            }

            return null;
        }

        private Guid SaveOrGetVendor(string vendorAutoRu)
        {
            var vendor = new Entities.Vendor()
            {
                Name = vendorAutoRu,
                RuName = vendorAutoRu
            };

            _dataManager.Vendors.Save(ref vendor);

            return vendor.Id;
        }

        private Guid SaveOrGetGearType(string gearTypeAutoRu)
        {
            var gearType = new Entities.GearType()
            {
                Name = gearTypeAutoRu,
                RuName = gearTypeAutoRu
            };

            _dataManager.GearTypes.Save(ref gearType);

            return gearType.Id;
        }

        private Guid SaveOrGetEngineType(string engineTypeAutoRu)
        {
            var engineType = new Entities.EngineType()
            {
                Name = engineTypeAutoRu,
                RuName = engineTypeAutoRu
            };

            _dataManager.EngineTypes.Save(ref engineType);

            return engineType.Id;
        }

        private Guid SaveOrGetTransmission(string transmissionAutoRu)
        {
            var transmission = new Entities.Transmission()
            {
                Name = transmissionAutoRu,
                RuName = transmissionAutoRu
            };

            _dataManager.Transmissions.Save(ref transmission);

            return transmission.Id;
        }

        private Guid SaveOrGetBodyType(AutoRu.Configuration bodyTypeAutoRu)
        {
            var bodyType = new Entities.BodyType()
            {
                BodyTypeGroupId = SaveOrGetBodyTypeGroup(bodyTypeAutoRu),
                Name = bodyTypeAutoRu.BodyType,
                RuName = bodyTypeAutoRu.BodyType
            };

            _dataManager.BodyTypes.Save(ref bodyType);

            return bodyType.Id;
        }

        private Guid SaveOrGetBodyTypeGroup(AutoRu.Configuration bodyTypeGroupAutoRu)
        {
            var bodyTypeGroup = new Entities.BodyTypeGroup()
            {
                Name = bodyTypeGroupAutoRu.BodyTypeGroup,
                RuName = bodyTypeGroupAutoRu.BodyTypeGroup,
                AutoClass = bodyTypeGroupAutoRu.AutoClass
            };

            _dataManager.BodyTypeGroups.Save(ref bodyTypeGroup);

            return bodyTypeGroup.Id;
        }

        private Guid SaveOrGetTag(string tagAutoRu)
        {
            var tag = new Entities.Tag()
            {
                Name = tagAutoRu,
                RuName = tagAutoRu
            };

            _dataManager.Tags.Save(ref tag);

            return tag.Id;
        }

        private Guid SaveOrGetColorType(string colorTypeAutoRu)
        {
            var colorType = new Entities.ColorType()
            {
                Name = colorTypeAutoRu,
                RuName = colorTypeAutoRu
            };

            _dataManager.ColorTypes.Save(ref colorType);

            return colorType.Id;
        }

        private Guid SaveOrGetOption(string optionAutoRu)
        {
            var option = new Entities.Option()
            {
                Name = optionAutoRu,
                RuName = optionAutoRu
            };

            _dataManager.Options.Save(ref option);

            return option.Id;
        }

        private Guid? SaveOrGetPhotoClass(string photoClassAutoRu)
        {
            if (!string.IsNullOrEmpty(photoClassAutoRu))
            {
                var photoClass = new Entities.PhotoClass()
                {
                    Name = photoClassAutoRu,
                    RuName = photoClassAutoRu
                };

                _dataManager.PhotoClasses.Save(ref photoClass);

                return photoClass.Id;
            }

            return null;
        }

        private void SaveCoordinate(AutoRu.Coordinate coordinateAutoRu, Guid locationId)
        {
            var coordinate = new Entities.Coordinate()
            {
                LocationId = locationId,
                Latitude = coordinateAutoRu.Latitude,
                Longitude = coordinateAutoRu.Longitude
            };

            if(!_dataManager.Locations.Contains(coordinate.Latitude, coordinate.Longitude))
            {
                _dataManager.Coordinates.Save(ref coordinate);
            }
        }

        private void SaveSalonPhones(AutoRu.Phone[] phonesAutoRu, Guid salonId)
        {
            if(phonesAutoRu != null)
            {
                foreach (var phoneAutoRu in phonesAutoRu)
                {
                    var salonPhone = new Entities.SalonPhone()
                    {
                        SalonId = salonId,
                        PhoneId = SaveOrGetPhone(phoneAutoRu)
                    };

                    _dataManager.SalonPhones.Save(ref salonPhone);
                }
            }
        }

        private void SavePrice(AutoRu.Price priceAutoRu, Guid announcementId)
        {
            if(priceAutoRu != null)
            {
                var price = new Entities.Price()
                {
                    AnnouncementId = announcementId,
                    CurrencyId = SaveOrGetCurrency(priceAutoRu.Currency),
                    WithNds = priceAutoRu.WithNds,
                    Value = priceAutoRu.Value
                };

                _dataManager.Prices.Save(ref price);
            }
        }

        private void SaveDocuments(AutoRu.Documents documentsAutoRu, Guid announcementId)
        {
            if(documentsAutoRu != null)
            {
                var documents = new Entities.Documents()
                {
                    AnnouncementId = announcementId,
                    Warranty = documentsAutoRu.Warranty,
                    LicensePlate = documentsAutoRu.LicensePlate,
                    PurchaseDate = documentsAutoRu.GetFormattedPurchaseDate(),
                    WarrantyExpire = documentsAutoRu.GetFormattedWarrantyExpire()
                };

                _dataManager.Documents.Save(ref documents);

                SavePts(documentsAutoRu, documents.Id);
            }
        }

        private void SavePts(AutoRu.Documents ptsAutoRu, Guid documentsId)
        {
            if(ptsAutoRu != null)
            {
                var pts = new Entities.Pts()
                {
                    DocumentsId = documentsId,
                    PtsTypeId = SaveOrGetPtsType(ptsAutoRu.Pts),
                    IsOriginal = ptsAutoRu.PtsOriginal,
                    CustomCleared = ptsAutoRu.CustomCleared,
                    NotRegisteredInRussia = ptsAutoRu.NotRegisteredInRussia,
                    Year = ptsAutoRu.Year,
                    OwnersNumber = ptsAutoRu.OwnersNumber
                };

                _dataManager.Pts.Save(ref pts);

                SaveVin(ptsAutoRu, pts.Id);
            }
        }

        private void SaveVin(AutoRu.Documents vinAutoRu, Guid ptsId)
        {
            if(vinAutoRu != null)
            {
                var vin = new Entities.Vin()
                {
                    PtsId = ptsId,
                    ResolutionId = SaveOrGetVinResolution(vinAutoRu.VinResolution),
                    Value = vinAutoRu.Vin
                };

                _dataManager.Vins.Save(ref vin);
            }
        }

        private void SaveVehicleInformation(AutoRu.Vehicle vehicleAutoRu, Guid announcementId)
        {
            var vehicle = new Entities.VehicleInformation()
            {
                SteeringWheelId = SaveOrGetSteeringWheel(vehicleAutoRu.SteeringWheel),
                AnnouncementId = announcementId,
                GenerationId = SaveOrGetGeneration(vehicleAutoRu.Mark, vehicleAutoRu.Model, vehicleAutoRu.Generation),
                VendorId = SaveOrGetVendor(vehicleAutoRu.Vendor)
            };

            _dataManager.VehicleInformation.Save(ref vehicle);

            SaveConfiguration(vehicleAutoRu.Configuration, vehicle.Id);
            SaveComplectation(vehicleAutoRu.Complectation, vehicle.Id);
            SaveTechnicalParameters(vehicleAutoRu.TechnicalParameters, vehicle.Id);
        }

        private void SaveMarkLogo(AutoRu.MarkLogo markLogoAutoRu, Guid markId)
        {
            if(markLogoAutoRu != null)
            {
                var markLogo = new Entities.MarkLogo()
                {
                    MarkId = markId,
                    Name = markLogoAutoRu.Name,
                    RuName = markLogoAutoRu.Name,
                    Logo = markLogoAutoRu.Sizes.Logo,
                    BigLogo = markLogoAutoRu.Sizes.BigLogo,
                    BlackLogo = markLogoAutoRu.Sizes.BlackLogo
                };

                _dataManager.MarkLogos.Save(ref markLogo);
            }
        }

        private void SaveTechnicalParameters(AutoRu.TechnicalParameters technicalParametersAutoRu, Guid vehicleId)
        {
            if(technicalParametersAutoRu != null)
            {
                var technicalParameters = new Entities.TechnicalParameters()
                {
                    VehicleId = vehicleId,
                    GearTypeId = SaveOrGetGearType(technicalParametersAutoRu.GearType),
                    EngineTypeId = SaveOrGetEngineType(technicalParametersAutoRu.EngineType),
                    TransmissionId = SaveOrGetTransmission(technicalParametersAutoRu.Transmission),
                    Power = technicalParametersAutoRu.Power,
                    PowerKvt = technicalParametersAutoRu.PowerKvt,
                    Displacement = technicalParametersAutoRu.Displacement,
                    ClearanceMin = technicalParametersAutoRu.ClearanceMin,
                    FuelRate = technicalParametersAutoRu.FuelRate,
                    Acceleration = technicalParametersAutoRu.Acceleration,
                    Name = technicalParametersAutoRu.Name,
                    HumanName = technicalParametersAutoRu.HumanName,
                    Nameplate = technicalParametersAutoRu.Nameplate
                };

                _dataManager.TechnicalParameters.Save(ref technicalParameters);
            }
        }

        private void SaveConfiguration(AutoRu.Configuration configurationAutoRu, Guid vehicleId)
        {
            if(configurationAutoRu != null)
            {
                var configuration = new Entities.Configuration()
                {
                    VehicleId = vehicleId,
                    BodyTypeId = SaveOrGetBodyType(configurationAutoRu),
                    DoorsCount = (int)configurationAutoRu.DoorsCount,
                    TrunkVolumeMin = configurationAutoRu.TrunkVolumeMin,
                    TrunkVolumeMax = configurationAutoRu.TrunkVolumeMax
                };

                _dataManager.Configurations.Save(ref configuration);

                SaveVehicleMainPhoto(configurationAutoRu.MainPhoto, configuration.Id);
                SaveConfigurationTags(configurationAutoRu.Tags, configuration.Id);
            }
        }

        private void SaveVehicleMainPhoto(AutoRu.MainPhoto vehicleMainPhotoAutoRu, Guid configurationId)
        {
            if(vehicleMainPhotoAutoRu != null)
            {
                var vehicleMainPhoto = new Entities.VehicleMainPhoto()
                {
                    ConfigurationId = configurationId,
                    Original = vehicleMainPhotoAutoRu.Sizes.Original,
                    Cattouch = vehicleMainPhotoAutoRu.Sizes.Cattouch,
                    Wizardv3mr = vehicleMainPhotoAutoRu.Sizes.Wizardv3mr
                };

                _dataManager.VehicleMainPhotos.Save(ref vehicleMainPhoto);
            }
        }

        private void SaveConfigurationTags(string[] tagsAutoRu, Guid configurationId)
        {
            if(tagsAutoRu != null)
            {
                foreach (var tagAutoRu in tagsAutoRu)
                {
                    var configurationTag = new Entities.ConfigurationTag()
                    {
                        ConfigurationId = configurationId,
                        TagId = SaveOrGetTag(tagAutoRu)
                    };

                    _dataManager.ConfigurationTags.Save(ref configurationTag);
                }
            }
        }

        private void SaveComplectation(AutoRu.Complectation complectationAutoRu, Guid vehicleId)
        {
            if(complectationAutoRu.Id != "0")
            {
                var complectation = new Entities.Complectation()
                {
                    VehicleId = vehicleId,
                    Name = complectationAutoRu.Name,
                    RuName = complectationAutoRu.Name
                };

                _dataManager.Complectations.Save(ref complectation);

                SaveVendorColors(complectationAutoRu.VendorColors, complectation.Id);
                SaveComplectationOptions(complectationAutoRu.Options, complectation.Id);
            }
        }

        private void SaveVendorColors(AutoRu.VendorColors[] vendorColorsAutoRu, Guid complectationId)
        {
            if(vendorColorsAutoRu != null)
            {
                foreach (var vendorColorAutoRu in vendorColorsAutoRu)
                {
                    var vendorColors = new Entities.VendorColor()
                    {
                        ComplectationId = complectationId,
                        ColorTypeId = SaveOrGetColorType(vendorColorAutoRu.ColorType),
                        IsMainColor = vendorColorAutoRu.MainColor,
                        Name = vendorColorAutoRu.Name,
                        RuName = (!string.IsNullOrEmpty(vendorColorAutoRu.NameRu) ? vendorColorAutoRu.NameRu : vendorColorAutoRu.Name),
                        HexCode = vendorColorAutoRu.StockColor.HexCode,
                        HexCodes = (vendorColorAutoRu.HexCodes != null ? string.Join(", ", vendorColorAutoRu.HexCodes) : "")
                    };

                    _dataManager.VendorColors.Save(ref vendorColors);

                    SaveVendorColorPhotos(vendorColorAutoRu.Photos, vendorColors.Id);
                }
            }
        }

        private void SaveVendorColorPhotos(AutoRu.VendorColorPhoto[] vendorColorPhotosAutoRu, Guid vendorColorsId)
        {
            if(vendorColorPhotosAutoRu != null)
            {
                foreach (var vendorColorPhotoAutoRu in vendorColorPhotosAutoRu)
                {
                    var vendorColorPhoto = new Entities.VendorColorPhoto()
                    {
                        VendorColorId = vendorColorsId,
                        Name = vendorColorPhotoAutoRu.Name,
                        Full = vendorColorPhotoAutoRu.Sizes.Full,
                        Orig = vendorColorPhotoAutoRu.Sizes.Orig,
                        Small = vendorColorPhotoAutoRu.Sizes.Small,
                        Image = vendorColorPhotoAutoRu.Sizes.Image,
                        ThumbS = vendorColorPhotoAutoRu.Sizes.ThumbS,
                        ThumbM = vendorColorPhotoAutoRu.Sizes.ThumbM,
                        AutoMain = vendorColorPhotoAutoRu.Sizes.AutoMain,
                        ThumbS2x = vendorColorPhotoAutoRu.Sizes.ThumbS2x,
                        Cattouch = vendorColorPhotoAutoRu.Sizes.Cattouch,
                        Wizardv3 = vendorColorPhotoAutoRu.Sizes.Wizardv3,
                        IslandOff = vendorColorPhotoAutoRu.Sizes.IslandOff,
                        Wizardv3mr = vendorColorPhotoAutoRu.Sizes.Wizardv3mr,
                        Resolution92x69 = vendorColorPhotoAutoRu.Sizes.Resolution92x69,
                        Resolution120x90 = vendorColorPhotoAutoRu.Sizes.Resolution120x90,
                        Resolution320x240 = vendorColorPhotoAutoRu.Sizes.Resolution320x240,
                        Resolution456x342 = vendorColorPhotoAutoRu.Sizes.Resolution456x342,
                        Resolution832x624 = vendorColorPhotoAutoRu.Sizes.Resolution832x624,
                        Resolution1200x900 = vendorColorPhotoAutoRu.Sizes.Resolution1200x900,
                        Resolution1200x900n = vendorColorPhotoAutoRu.Sizes.Resolution1200x900n,
                    };

                    _dataManager.VendorColorPhotos.Save(ref vendorColorPhoto);
                }
            }
        }

        private void SaveComplectationOptions(string[] optionsAutoRu, Guid complectationId)
        {
            if(optionsAutoRu != null)
            {
                foreach (var optionAutoRu in optionsAutoRu)
                {
                    var complectationOption = new Entities.ComplectationOption()
                    {
                        ComplectationId = complectationId,
                        OptionId = SaveOrGetOption(optionAutoRu)
                    };

                    _dataManager.ComplectationOptions.Save(ref complectationOption);
                }
            }
        }

        private void SaveState(AutoRu.State stateAutoRu, Guid announcementId)
        {
            if(stateAutoRu != null)
            {
                var state = new Entities.State()
                {
                    AnnouncementId = announcementId,
                    IsBeaten = stateAutoRu.IsBeaten,
                    Mileage = stateAutoRu.Mileage
                };

                _dataManager.States.Save(ref state);

                if (stateAutoRu.ExternalPanorama != null)
                {
                    SaveExternalPanorama(stateAutoRu.ExternalPanorama, state.Id);
                }

                SaveStatePhotos(stateAutoRu.Photos, state.Id);
            }
        }

        private void SaveExternalPanorama(AutoRu.ExternalPanorama externalPanoramaAutoRu, Guid stateId)
        {
            if(externalPanoramaAutoRu != null)
            {
                var externalPanorama = new Entities.ExternalPanorama()
                {
                    StateId = stateId,
                    Preview = externalPanoramaAutoRu.Published.Preview,
                    QualityR4x3 = (double)externalPanoramaAutoRu.Published.QualityR4x3,
                    QualityR16x9 = (double)externalPanoramaAutoRu.Published.QualityR16x9,
                };

                _dataManager.ExternalPanoramas.Save(ref externalPanorama);

                SaveVideoH264(externalPanoramaAutoRu.Published.VideoH264, externalPanorama.Id);
                SaveVideoWebm(externalPanoramaAutoRu.Published.VideoWebm, externalPanorama.Id);
                SavePicturePng(externalPanoramaAutoRu.Published.PicturePng, externalPanorama.Id);
                SavePictureJpeg(externalPanoramaAutoRu.Published.PictureJpeg, externalPanorama.Id);
                SavePictureWebp(externalPanoramaAutoRu.Published.PictureWebp, externalPanorama.Id);
                SaveVideoMp4R16x9(externalPanoramaAutoRu.Published.VideoMp4R16x9, externalPanorama.Id);
                SaveVideoWebmR16x9(externalPanoramaAutoRu.Published.VideoWebmR16x9, externalPanorama.Id);
                SavePicturePngR16x9(externalPanoramaAutoRu.Published.PicturePngR16x9, externalPanorama.Id);
                SavePictureJpegR16x9(externalPanoramaAutoRu.Published.PictureJpegR16x9, externalPanorama.Id);
                SavePictureWebpR16x9(externalPanoramaAutoRu.Published.PictureWebpR16x9, externalPanorama.Id);
            }
        }

        private void SaveVideoH264(AutoRu.Video videoAutoRu, Guid externalPanoramaId)
        {
            if(videoAutoRu != null)
            {
                var video = new Entities.VideoH264()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullUrl = videoAutoRu.FullUrl,
                    LowResUrl = videoAutoRu.LowResUrl,
                    HighResUrl = videoAutoRu.HighResUrl,
                    PreviewUrl = videoAutoRu.PreviewUrl,
                };

                _dataManager.VideosH264.Save(ref video);
            }
        }

        private void SaveVideoWebm(AutoRu.Video videoAutoRu, Guid externalPanoramaId)
        {
            if(videoAutoRu != null)
            {
                var video = new Entities.VideoWebm()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullUrl = videoAutoRu.FullUrl,
                    LowResUrl = videoAutoRu.LowResUrl,
                    HighResUrl = videoAutoRu.HighResUrl,
                    PreviewUrl = videoAutoRu.PreviewUrl,
                };

                _dataManager.VideosWebm.Save(ref video);
            }
        }

        private void SavePicturePng(AutoRu.Picture pictureAutoRu, Guid externalPanoramaId)
        {
            if(pictureAutoRu != null)
            {
                var picture = new Entities.PicturePng()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullFirstFrame = pictureAutoRu.FullFirstFrame,
                    HighResFirstFrame = pictureAutoRu.HighResFirstFrame,
                    PreviewFirstFrame = pictureAutoRu.PreviewFirstFrame,
                };

                _dataManager.PicturesPng.Save(ref picture);
            }
        }

        private void SavePictureJpeg(AutoRu.Picture pictureAutoRu, Guid externalPanoramaId)
        {
            if(pictureAutoRu != null)
            {
                var picture = new Entities.PictureJpeg()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullFirstFrame = pictureAutoRu.FullFirstFrame,
                    HighResFirstFrame = pictureAutoRu.HighResFirstFrame,
                    PreviewFirstFrame = pictureAutoRu.PreviewFirstFrame,
                };

                _dataManager.PicturesJpeg.Save(ref picture);
            }
        }

        private void SavePictureWebp(AutoRu.Picture pictureAutoRu, Guid externalPanoramaId)
        {
            if(pictureAutoRu != null)
            {
                var picture = new Entities.PictureWebp()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullFirstFrame = pictureAutoRu.FullFirstFrame,
                    HighResFirstFrame = pictureAutoRu.HighResFirstFrame,
                    PreviewFirstFrame = pictureAutoRu.PreviewFirstFrame,
                };

                _dataManager.PicturesWebp.Save(ref picture);
            }
        }

        private void SaveVideoMp4R16x9(AutoRu.Video videoAutoRu, Guid externalPanoramaId)
        {
            if(videoAutoRu != null)
            {
                var video = new Entities.VideoMp4R16x9()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullUrl = videoAutoRu.FullUrl,
                    LowResUrl = videoAutoRu.LowResUrl,
                    HighResUrl = videoAutoRu.HighResUrl,
                    PreviewUrl = videoAutoRu.PreviewUrl,
                };

                _dataManager.VideosMp4R16X9.Save(ref video);
            }
        }

        private void SaveVideoWebmR16x9(AutoRu.Video videoAutoRu, Guid externalPanoramaId)
        {
            if(videoAutoRu != null)
            {
                var video = new Entities.VideoWebmR16x9()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullUrl = videoAutoRu.FullUrl,
                    LowResUrl = videoAutoRu.LowResUrl,
                    HighResUrl = videoAutoRu.HighResUrl,
                    PreviewUrl = videoAutoRu.PreviewUrl,
                };

                _dataManager.VideosWebmR16X9.Save(ref video);
            }
        }

        private void SavePicturePngR16x9(AutoRu.Picture pictureAutoRu, Guid externalPanoramaId)
        {
            if(pictureAutoRu != null)
            {
                var picture = new Entities.PicturePngR16x9()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullFirstFrame = pictureAutoRu.FullFirstFrame,
                    HighResFirstFrame = pictureAutoRu.HighResFirstFrame,
                    PreviewFirstFrame = pictureAutoRu.PreviewFirstFrame,
                };

                _dataManager.PicturesPngR16X9.Save(ref picture);
            }
        }

        private void SavePictureJpegR16x9(AutoRu.Picture pictureAutoRu, Guid externalPanoramaId)
        {
            if(pictureAutoRu != null)
            {
                var picture = new Entities.PictureJpegR16x9()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullFirstFrame = pictureAutoRu.FullFirstFrame,
                    HighResFirstFrame = pictureAutoRu.HighResFirstFrame,
                    PreviewFirstFrame = pictureAutoRu.PreviewFirstFrame,
                };

                _dataManager.PicturesJpegR16X9.Save(ref picture);
            }
        }

        private void SavePictureWebpR16x9(AutoRu.Picture pictureAutoRu, Guid externalPanoramaId)
        {
            if(pictureAutoRu != null)
            {
                var picture = new Entities.PictureWebpR16x9()
                {
                    ExternalPanoramaId = externalPanoramaId,
                    FullFirstFrame = pictureAutoRu.FullFirstFrame,
                    HighResFirstFrame = pictureAutoRu.HighResFirstFrame,
                    PreviewFirstFrame = pictureAutoRu.PreviewFirstFrame,
                };

                _dataManager.PicturesWebpR16X9.Save(ref picture);
            }
        }

        private void SaveStatePhotos(AutoRu.StatePhoto[] statePhotosAutoRu, Guid stateId)
        {
            if(statePhotosAutoRu != null)
            {
                foreach (var statePhotoAutoRu in statePhotosAutoRu)
                {
                    var statePhoto = new Entities.StatePhoto()
                    {
                        StateId = stateId,
                        ClassId = SaveOrGetPhotoClass(statePhotoAutoRu.PhotoClass),
                        Small = statePhotoAutoRu.Sizes.Small,
                        ThumbM = statePhotoAutoRu.Sizes.ThumbM,
                        Preview = statePhotoAutoRu.Preview,
                        Resolution320x240 = statePhotoAutoRu.Sizes.Resolution320x240,
                        Resolution456x342 = statePhotoAutoRu.Sizes.Resolution456x342,
                        Resolution456x342n = statePhotoAutoRu.Sizes.Resolution456x342n,
                        Resolution1200x900 = statePhotoAutoRu.Sizes.Resolution1200x900,
                        Resolution1200x900n = statePhotoAutoRu.Sizes.Resolution1200x900n
                    };

                    _dataManager.StatePhotos.Save(ref statePhoto);
                }
            }
        }

        private void SaveAnnouncementDescription(string descriptionAutoRu, Guid announcementId)
        {
            if (!string.IsNullOrEmpty(descriptionAutoRu))
            {
                var description = new Entities.AnnouncementDescription()
                {
                    AnnouncementId = announcementId,
                    Value = descriptionAutoRu
                };

                _dataManager.AnnouncementDescriptions.Save(ref description);
            }
        }

        private void SaveAnnouncementAdditionalInformation(AutoRu.AdditionalInfo additionalInfoAutoRu, Guid announcementId)
        {
            if(additionalInfoAutoRu != null)
            {
                var additionalInformation = new Entities.AnnouncementAdditionalInformation()
                {
                    AnnouncementId = announcementId,
                    CreatedAt = additionalInfoAutoRu.CreatedAt,
                    UpdatedAt = additionalInfoAutoRu.UpdatedAt
                };

                _dataManager.AnnouncementAdditionalInformation.Save(ref additionalInformation);
            }
        }

        private void SaveAnnouncementTags(string[] tagsAutoRu, Guid announcementId)
        {
            if(tagsAutoRu != null)
            {
                foreach (var tagAutoRu in tagsAutoRu)
                {
                    var announcementTag = new Entities.AnnouncementTag()
                    {
                        AnnouncementId = announcementId,
                        TagId = SaveOrGetTag(tagAutoRu)
                    };

                    _dataManager.AnnouncementTags.Save(ref announcementTag);
                }
            }
        }

        public Guid Import(AutoRu.Announcement announcementAutoRu)
        {
            var announcement = new Entities.Announcement()
            {
                ColorId = SaveOrGetColor(announcementAutoRu.ColorHex),
                SalonId = SaveOrGetSalon(announcementAutoRu.Salon),
                SellerId = SaveOrGetSeller(announcementAutoRu.Seller),
                StatusId = SaveOrGetStatus(announcementAutoRu.Status),
                SectionId = SaveOrGetSection(announcementAutoRu.Section),
                CategoryId = SaveOrGetCategory(announcementAutoRu.Category),
                SellerTypeId = SaveOrGetSellerType(announcementAutoRu.SellerType),
                AvailabilityId = SaveOrGetAvailability(announcementAutoRu.Availability),
                SaleId = announcementAutoRu.SaleId,
                Summary = announcementAutoRu.Summary
            };

            _dataManager.Announcements.Save(ref announcement);

            SaveState(announcementAutoRu.State, announcement.Id);
            SavePrice(announcementAutoRu.Price, announcement.Id);
            SaveDocuments(announcementAutoRu.Documents, announcement.Id);
            SaveVehicleInformation(announcementAutoRu.Vehicle, announcement.Id);
            SaveAnnouncementDescription(announcementAutoRu.Description, announcement.Id);
            SaveAnnouncementAdditionalInformation(announcementAutoRu.AdditionalInfo, announcement.Id);

            SaveAnnouncementTags(announcementAutoRu.Tags, announcement.Id);

            return announcement.Id;
        }
    }
}
