using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class AnnouncementsViewModel : BindableBase
    {
        private readonly PtsRequester _ptsRequester;
        private readonly TagsRequester _tagsRequester;
        private readonly MarksRequester _marksRequester;
        private readonly ModelsRequester _modelsRequester;
        private readonly ColorsRequester _colorsRequester;
        private readonly PricesRequester _pricesRequester;
        private readonly StatesRequester _statesRequester;
        private readonly VendorsRequester _vendorsRequester;
        private readonly RegionsRequester _regionsRequester;
        private readonly OptionsRequester _optionsRequester;
        private readonly SectionsRequester _sectionsRequester;
        private readonly StatusesRequester _statusesRequester;
        private readonly GearTypesRequester _gearTypesRequester;
        private readonly BodyTypesRequester _bodyTypesRequester;
        private readonly CurrenciesRequester _currenciesRequester;
        private readonly EngineTypesRequester _engineTypesRequester;
        private readonly GenerationsRequester _generationsRequester;
        private readonly SellerTypesRequester _sellerTypesRequester;
        private readonly TransmissionsRequester _transmissionsRequester;
        private readonly AnnouncementsRequester _announcementsRequester;
        private readonly BodyTypeGroupsRequester _bodyTypeGroupsRequester;
        private readonly AvailabilitiesRequester _availabilitiesRequester;
        private readonly SteeringWheelsRequester _steeringWheelsRequester;
        private readonly ConfigurationsRequester _configurationsRequester;
        private readonly TechnicalParametersRequester _technicalParametersRequester;
        private readonly AnnouncementAdditionalInformationRequester _announcementAdditionalInformationRequester;

        public Pagination Pagination { get; set; }

        public Pagination TagsPagination { get; set; }

        public Pagination MarksPagination { get; set; }

        public Pagination ModelsPagination { get; set; }

        public Pagination ColorsPagination { get; set; }

        public Pagination VendorsPagination { get; set; }

        public Pagination RegionsPagination { get; set; }

        public Pagination OptionsPagination { get; set; }

        public Pagination BodyTypesPagination { get; set; }

        public Pagination GenerationsPagination { get; set; }

        public Pagination AnnouncementsPagination { get; set; }

        public Pagination BodyTypeGroupsPagination { get; set; }

        public TagsFilters TagsFilters { get; set; }

        public MarksFilters MarksFilters { get; set; }

        public ModelsFilters ModelsFilters { get; set; }

        public ColorsFilters ColorsFilters { get; set; }

        public AnnouncementsFilters Filters { get; set; }

        public VendorsFilters VendorsFilters { get; set; }

        public RegionsFilters RegionsFilters { get; set; }

        public OptionsFilters OptionsFilters { get; set; }

        public BodyTypesFilters BodyTypesFilters { get; set; }

        public GenerationsFilters GenerationsFilters { get; set; }

        public BodyTypeGroupsFilters BodyTypeGroupsFilters { get; set; }

        public ObservableCollection<string> NamesGenerations { get; set; }

        public ObservableCollection<Entities.Tag> Tags { get; set; }

        public ObservableCollection<Entities.Mark> Marks { get; set; }

        public ObservableCollection<Entities.Model> Models { get; set; }

        public ObservableCollection<Entities.Color> Colors { get; set; }

        public ObservableCollection<Entities.Vendor> Vendors { get; set; }

        public ObservableCollection<Entities.Option> Options { get; set; }

        public ObservableCollection<Entities.Status> Statuses { get; set; }

        public ObservableCollection<Entities.Section> Sections { get; set; }

        public ObservableCollection<Entities.BodyType> BodyTypes { get; set; }

        public ObservableCollection<Entities.GearType> GearTypes { get; set; }

        public ObservableCollection<Entities.Currency> Currencies { get; set; }

        public ObservableCollection<Entities.EngineType> EngineTypes { get; set; }

        public ObservableCollection<Entities.Generation> Generations { get; set; }

        public ObservableCollection<Entities.SellerType> SellerTypes { get; set; }

        public ObservableCollection<Entities.RegionInformation> Regions { get; set; }

        public ObservableCollection<Entities.Announcement> Announcements { get; set; }

        public ObservableCollection<Entities.Transmission> Transmissions { get; set; }

        public ObservableCollection<Entities.Availability> Availabilities { get; set; }

        public ObservableCollection<Entities.SteeringWheel> SteeringWheels { get; set; }

        public ObservableCollection<Entities.BodyTypeGroup> BodyTypeGroups { get; set; }

        public ICommand BodyTypeGroupsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return BodyTypeGroupsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand GenerationsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return GenerationsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand BodyTypesScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return BodyTypesLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand RegionsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return RegionsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand OptionsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return OptionsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand VendorsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return VendorsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ColorsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return ColorsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ModelsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return ModelsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand MarksScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return MarksLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand TagsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return TagsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SelectedBodyTypeGroupsChanged => new AsyncCommand(() =>
        {
            return SearchBodyTypesAsync();
        });

        public ICommand SelectedCurrencyChanged => new AsyncCommand(() =>
        {
            return UpdateRangePriceAsync();
        });

        public ICommand SelectedModelsChanged => new AsyncCommand(() =>
        {
            return SearchGenerationsAsync();
        });

        public ICommand SelectedMarksChanged => new AsyncCommand(() =>
        {
            return SearchModelsAsync();
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesGenerationsAsync();
        });

        public ICommand Loaded => new AsyncCommand(() =>
        {
            return LoadedAsync();
        });

        public ICommand Search => new AsyncCommand(() =>
        {
            return SearchAsync();
        });

        public ICommand Reset => new AsyncCommand(() =>
        {
            return ResetAsync();
        });

        public ICommand Info => new AsyncCommand(() =>
        {
            return new Task(() => { });
        });

        public AnnouncementsViewModel()
        {
            _ptsRequester = new PtsRequester();
            _tagsRequester = new TagsRequester();
            _marksRequester = new MarksRequester();
            _modelsRequester = new ModelsRequester();
            _colorsRequester = new ColorsRequester();
            _pricesRequester = new PricesRequester();
            _statesRequester = new StatesRequester();
            _vendorsRequester = new VendorsRequester();
            _regionsRequester = new RegionsRequester();
            _optionsRequester = new OptionsRequester();
            _sectionsRequester = new SectionsRequester();
            _statusesRequester = new StatusesRequester();
            _gearTypesRequester = new GearTypesRequester();
            _bodyTypesRequester = new BodyTypesRequester();
            _currenciesRequester = new CurrenciesRequester();
            _engineTypesRequester = new EngineTypesRequester();
            _generationsRequester = new GenerationsRequester();
            _sellerTypesRequester = new SellerTypesRequester();
            _transmissionsRequester = new TransmissionsRequester();
            _announcementsRequester = new AnnouncementsRequester();
            _availabilitiesRequester = new AvailabilitiesRequester();
            _steeringWheelsRequester = new SteeringWheelsRequester();
            _bodyTypeGroupsRequester = new BodyTypeGroupsRequester();
            _configurationsRequester = new ConfigurationsRequester();
            _technicalParametersRequester = new TechnicalParametersRequester();
            _announcementAdditionalInformationRequester = new AnnouncementAdditionalInformationRequester();
        }

        private async Task LoadedAsync()
        {
            await ResetAsync();
        }

        private async Task ResetTagsPaginationAsync()
        {
            TagsPagination = new Pagination()
            {
                NumberPage = TagsFilters.NumberPage,
                ItemsPerPage = TagsFilters.ItemsPerPage,
                CountTotalItems = (await _tagsRequester.GetCountTagsAsync(TagsFilters))
            };
        }

        private async Task ResetMarksPaginationAsync()
        {
            MarksPagination = new Pagination()
            {
                NumberPage = MarksFilters.NumberPage,
                ItemsPerPage = MarksFilters.ItemsPerPage,
                CountTotalItems = (await _marksRequester.GetCountMarksAsync(MarksFilters))
            };
        }

        private async Task ResetModelsPaginationAsync()
        {
            ModelsPagination = new Pagination()
            {
                NumberPage = ModelsFilters.NumberPage,
                ItemsPerPage = ModelsFilters.ItemsPerPage,
                CountTotalItems = (await _modelsRequester.GetCountModelsOfMarksAsync(ModelsFilters))
            };
        }

        private async Task ResetColorsPaginationAsync()
        {
            ColorsPagination = new Pagination()
            {
                NumberPage = ColorsFilters.NumberPage,
                ItemsPerPage = ColorsFilters.ItemsPerPage,
                CountTotalItems = (await _colorsRequester.GetCountColorsAsync(ColorsFilters))
            };
        }

        private async Task ResetBodyTypesPaginationAsync()
        {
            BodyTypesPagination = new Pagination()
            {
                NumberPage = BodyTypesFilters.NumberPage,
                ItemsPerPage = BodyTypesFilters.ItemsPerPage,
                CountTotalItems = (await _bodyTypesRequester.GetCountBodyTypesOfBodyTypeGroupsAsync(BodyTypesFilters))
            };
        }

        private async Task ResetOptionsPaginationAsync()
        {
            OptionsPagination = new Pagination()
            {
                NumberPage = OptionsFilters.NumberPage,
                ItemsPerPage = OptionsFilters.ItemsPerPage,
                CountTotalItems = (await _optionsRequester.GetCountOptionsAsync(OptionsFilters))
            };
        }

        private async Task ResetVendorsPaginationAsync()
        {
            VendorsPagination = new Pagination()
            {
                NumberPage = VendorsFilters.NumberPage,
                ItemsPerPage = VendorsFilters.ItemsPerPage,
                CountTotalItems = (await _vendorsRequester.GetCountVendorsAsync(VendorsFilters))
            };
        }

        private async Task ResetRegionsPaginationAsync()
        {
            RegionsPagination = new Pagination()
            {
                NumberPage = RegionsFilters.NumberPage,
                ItemsPerPage = RegionsFilters.ItemsPerPage,
                CountTotalItems = (await _regionsRequester.GetCountRegionsAsync(RegionsFilters))
            };
        }

        private async Task ResetBodyTypeGroupsPaginationAsync()
        {
            BodyTypeGroupsPagination = new Pagination()
            {
                NumberPage = BodyTypeGroupsFilters.NumberPage,
                ItemsPerPage = BodyTypeGroupsFilters.ItemsPerPage,
                CountTotalItems = (await _bodyTypeGroupsRequester.GetCountBodyTypeGroupsAsync(BodyTypeGroupsFilters))
            };
        }

        private async Task ResetGenerationsPaginationAsync()
        {
            GenerationsPagination = new Pagination()
            {
                NumberPage = GenerationsFilters.NumberPage,
                ItemsPerPage = GenerationsFilters.ItemsPerPage,
                CountTotalItems = (await _generationsRequester.GetCountGenerationsByModelsIdsAsync(GenerationsFilters))
            };
        }

        private async Task ResetPaginationAsync()
        {
            Pagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _announcementsRequester.GetCountAnnouncementsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            TagsFilters = new TagsFilters();
            MarksFilters = new MarksFilters();
            ModelsFilters = new ModelsFilters();
            ColorsFilters = new ColorsFilters();
            VendorsFilters = new VendorsFilters();
            RegionsFilters = new RegionsFilters();
            OptionsFilters = new OptionsFilters();
            BodyTypesFilters = new BodyTypesFilters();
            GenerationsFilters = new GenerationsFilters();
            BodyTypeGroupsFilters = new BodyTypeGroupsFilters();

            Statuses = new ObservableCollection<Entities.Status>((await _statusesRequester.GetStatusesAsync()).ToList());
            Sections = new ObservableCollection<Entities.Section>((await _sectionsRequester.GetSectionsAsync()).ToList());
            GearTypes = new ObservableCollection<Entities.GearType>((await _gearTypesRequester.GetGearTypesAsync()).ToList());
            Currencies = new ObservableCollection<Entities.Currency>((await _currenciesRequester.GetCurrenciesAsync()).ToList());
            EngineTypes = new ObservableCollection<Entities.EngineType>((await _engineTypesRequester.GetEngineTypesAsync()).ToList());
            SellerTypes = new ObservableCollection<Entities.SellerType>((await _sellerTypesRequester.GetSellerTypesAsync()).ToList());
            Transmissions = new ObservableCollection<Entities.Transmission>((await _transmissionsRequester.GetTransmissionsAsync()).ToList());
            Availabilities = new ObservableCollection<Entities.Availability>((await _availabilitiesRequester.GetAvailabilitiesAsync()).ToList());
            SteeringWheels = new ObservableCollection<Entities.SteeringWheel>((await _steeringWheelsRequester.GetSteeringWheelsAsync()).ToList());

            var maxPower = await _technicalParametersRequester.GetMaxPowerAsync();
            var minPower = await _technicalParametersRequester.GetMinPowerAsync();

            Filters = new AnnouncementsFilters();

            Filters.RangePower.Min = minPower;
            Filters.RangePower.From = minPower;
            Filters.RangePower.Max = maxPower;
            Filters.RangePower.To = maxPower;

            //Filters.RangePower = new RangePower(maxPower, minPower);

            //var minPrice = await _pricesRequester.GetMinPriceAsync(Guid.Parse("04383F47-5639-4417-AD3B-2A9A0B5CC9F4"));
            //var maxPrice = await _pricesRequester.GetMaxPriceAsync(Guid.Parse("04383F47-5639-4417-AD3B-2A9A0B5CC9F4"));

            //var minPrice = await _pricesRequester.GetMinPriceAsync(Guid.Parse("2a43b864-bfc3-49ba-b54c-2ccf0bab0981"));
            //var maxPrice = await _pricesRequester.GetMaxPriceAsync(Guid.Parse("2a43b864-bfc3-49ba-b54c-2ccf0bab0981"));

            Filters.RangePrice.Min = 0;
            Filters.RangePrice.From = 0;
            Filters.RangePrice.Max = 300000000;
            Filters.RangePrice.To = 300000000;

            //Filters.RangePrice = new RangePrice(300000000, 0);

            var minMileage = await _statesRequester.GetMinMileageAsync();
            var maxMileage = await _statesRequester.GetMaxMileageAsync();

            Filters.RangeMileage.Min = minMileage;
            Filters.RangeMileage.From = minMileage;
            Filters.RangeMileage.Max = maxMileage;
            Filters.RangeMileage.To = maxMileage;

            var minPowerKvt = await _technicalParametersRequester.GetMinPowerKvtAsync();
            var maxPowerKvt = await _technicalParametersRequester.GetMaxPowerKvtAsync();

            Filters.RangePowerKvt.Min = minPowerKvt;
            Filters.RangePowerKvt.From = minPowerKvt;
            Filters.RangePowerKvt.Max = maxPowerKvt;
            Filters.RangePowerKvt.To = maxPowerKvt;

            var minFuelRate = await _technicalParametersRequester.GetMinFuelRateAsync();
            var maxFuelRate = await _technicalParametersRequester.GetMaxFuelRateAsync();

            Filters.RangeFuelRate.Min = minFuelRate;
            Filters.RangeFuelRate.From = minFuelRate;
            Filters.RangeFuelRate.Max = maxFuelRate;
            Filters.RangeFuelRate.To = maxFuelRate;

            var minCreatedAt = await _announcementAdditionalInformationRequester.GetMinCreatedAtAsync();
            var maxCreatedAt = await _announcementAdditionalInformationRequester.GetMaxCreatedAtAsync();

            Filters.RangeCreatedAt.Min = minCreatedAt;
            Filters.RangeCreatedAt.From = minCreatedAt;
            Filters.RangeCreatedAt.Max = maxCreatedAt;
            Filters.RangeCreatedAt.To = maxCreatedAt;

            var minDoorsCount = await _configurationsRequester.GetMinDoorsCountAsync();
            var maxDoorsCount = await _configurationsRequester.GetMaxDoorsCountAsync();

            Filters.RangeDoorsCount.Min = minDoorsCount;
            Filters.RangeDoorsCount.From = minDoorsCount;
            Filters.RangeDoorsCount.Max = maxDoorsCount;
            Filters.RangeDoorsCount.To = maxDoorsCount;

            var minOwnersNumber = await _ptsRequester.GetMinOwnersNumberAsync();
            var maxOwnersNumber = await _ptsRequester.GetMaxOwnersNumberAsync();

            Filters.RangeOwnersNumber.Min = minOwnersNumber;
            Filters.RangeOwnersNumber.From = minOwnersNumber;
            Filters.RangeOwnersNumber.Max = maxOwnersNumber;
            Filters.RangeOwnersNumber.To = maxOwnersNumber;

            var minAcceleration = await _technicalParametersRequester.GetMinAccelerationAsync();
            var maxAcceleration = await _technicalParametersRequester.GetMaxAccelerationAsync();

            Filters.RangeAcceleration.Min = minAcceleration;
            Filters.RangeAcceleration.From = minAcceleration;
            Filters.RangeAcceleration.Max = maxAcceleration;
            Filters.RangeAcceleration.To = maxAcceleration;

            var minDisplacement = await _technicalParametersRequester.GetMinDisplacementAsync();
            var maxDisplacement = await _technicalParametersRequester.GetMaxDisplacementAsync();

            Filters.RangeDisplacement.Min = minDisplacement;
            Filters.RangeDisplacement.From = minDisplacement;
            Filters.RangeDisplacement.Max = maxDisplacement;
            Filters.RangeDisplacement.To = maxDisplacement;

            var minClearanceMin = await _technicalParametersRequester.GetMinClearanceMinAsync();
            var maxClearanceMin = await _technicalParametersRequester.GetMaxClearanceMinAsync();

            Filters.RangeClearanceMin.Min = minClearanceMin;
            Filters.RangeClearanceMin.From = minClearanceMin;
            Filters.RangeClearanceMin.Max = maxClearanceMin;
            Filters.RangeClearanceMin.To = maxClearanceMin;

            var minTrunkVolumeMin = await _configurationsRequester.GetMinTrunkVolumeMinAsync();
            var maxTrunkVolumeMin = await _configurationsRequester.GetMaxTrunkVolumeMinAsync();

            Filters.RangeTrunkVolumeMin.Min = minTrunkVolumeMin;
            Filters.RangeTrunkVolumeMin.From = minTrunkVolumeMin;
            Filters.RangeTrunkVolumeMin.Max = maxTrunkVolumeMin;
            Filters.RangeTrunkVolumeMin.To = maxTrunkVolumeMin;

            var minTrunkVolumeMax = await _configurationsRequester.GetMinTrunkVolumeMaxAsync();
            var maxTrunkVolumeMax = await _configurationsRequester.GetMaxTrunkVolumeMaxAsync();

            Filters.RangeTrunkVolumeMax.Min = minTrunkVolumeMax;
            Filters.RangeTrunkVolumeMax.From = minTrunkVolumeMax;
            Filters.RangeTrunkVolumeMax.Max = maxTrunkVolumeMax;
            Filters.RangeTrunkVolumeMax.To = maxTrunkVolumeMax;

            Filters.RangeTrunkVolumeMax = new RangeTrunkVolume(maxTrunkVolumeMax, minTrunkVolumeMax);

            await ResetTagsPaginationAsync();
            await ResetMarksPaginationAsync();
            await ResetModelsPaginationAsync();
            await ResetColorsPaginationAsync();
            await ResetVendorsPaginationAsync();
            await ResetRegionsPaginationAsync();
            await ResetOptionsPaginationAsync();
            await ResetBodyTypesPaginationAsync();
            await ResetGenerationsPaginationAsync();
            await ResetBodyTypeGroupsPaginationAsync();

            await GetNamesGenerationsAsync();

            await SearchTagsAsync();
            await SearchMarksAsync();
            await SearchModelsAsync();
            await SearchColorsAsync();
            await SearchVendorsAsync();
            await SearchRegionsAsync();
            await SearchOptionsAsync();
            await SearchBodyTypesAsync();
            await SearchGenerationsAsync();
            await SearchBodyTypeGroupsAsync();

            await SearchAsync();
        }

        private async Task UpdateRangePriceAsync()
        {
            //MinPrice = await _pricesRequester.GetMinPriceAsync(Guid.Parse("2a43b864-bfc3-49ba-b54c-2ccf0bab0981"));
            //MaxPrice = await _pricesRequester.GetMaxPriceAsync(Guid.Parse("2a43b864-bfc3-49ba-b54c-2ccf0bab0981"));

            //Filters.RangePrice.From = MinPrice;
            //Filters.RangePrice.To = MaxPrice;
        }

        private async Task GetNamesGenerationsAsync()
        {
            NamesGenerations = new ObservableCollection<string>((await _generationsRequester
                .GetNamesGenerationsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Announcements = new ObservableCollection<Entities.Announcement>((await _announcementsRequester
                .GetAnnouncementsAsync(Filters)).ToList());
        }

        private async Task SearchTagsAsync()
        {
            TagsFilters.ResetForSearch();

            await ResetTagsPaginationAsync();

            Tags = new ObservableCollection<Entities.Tag>((await _tagsRequester
                .GetTagsAsync(TagsFilters)).ToList());
        }

        private async Task SearchMarksAsync()
        {
            MarksFilters.ResetForSearch();

            await ResetMarksPaginationAsync();

            Marks = new ObservableCollection<Entities.Mark>((await _marksRequester
                .GetMarksAsync(MarksFilters)).ToList());
        }

        private async Task SearchModelsAsync()
        {
            ModelsFilters.ResetForSearch();
            ModelsFilters.MarksIds = Filters.MarksIds;

            await ResetModelsPaginationAsync();

            Models = new ObservableCollection<Entities.Model>((await _modelsRequester
                .GetModelsOfMarksAsync(ModelsFilters)).ToList());
        }

        private async Task SearchColorsAsync()
        {
            ColorsFilters.ResetForSearch();

            await ResetColorsPaginationAsync();

            Colors = new ObservableCollection<Entities.Color>((await _colorsRequester
                .GetColorsAsync(ColorsFilters)).ToList());
        }

        private async Task SearchOptionsAsync()
        {
            OptionsFilters.ResetForSearch();

            await ResetOptionsPaginationAsync();

            Options = new ObservableCollection<Entities.Option>((await _optionsRequester
                .GetOptionsAsync(OptionsFilters)).ToList());
        }

        private async Task SearchBodyTypesAsync()
        {
            BodyTypesFilters.ResetForSearch();
            BodyTypesFilters.BodyTypeGroupsIds = Filters.BodyTypeGroupsIds;

            await ResetBodyTypesPaginationAsync();

            BodyTypes = new ObservableCollection<Entities.BodyType>((await _bodyTypesRequester
                .GetBodyTypesOfBodyTypeGroupsAsync(BodyTypesFilters)).ToList());
        }

        private async Task SearchVendorsAsync()
        {
            VendorsFilters.ResetForSearch();

            await ResetVendorsPaginationAsync();

            Vendors = new ObservableCollection<Entities.Vendor>((await _vendorsRequester
                .GetVendorsAsync(VendorsFilters)).ToList());
        }

        private async Task SearchRegionsAsync()
        {
            RegionsFilters.ResetForSearch();

            await ResetRegionsPaginationAsync();

            Regions = new ObservableCollection<Entities.RegionInformation>((await _regionsRequester
                .GetRegionsAsync(RegionsFilters)).ToList());
        }

        private async Task SearchGenerationsAsync()
        {
            GenerationsFilters.ResetForSearch();
            GenerationsFilters.ModelsIds = Filters.ModelsIds;

            await ResetGenerationsPaginationAsync();

            Generations = new ObservableCollection<Entities.Generation>((await _generationsRequester
                .GetGenerationsByModelsIdsAsync(GenerationsFilters)).ToList());
        }

        private async Task SearchBodyTypeGroupsAsync()
        {
            BodyTypeGroupsFilters.ResetForSearch();

            await ResetBodyTypeGroupsPaginationAsync();

            BodyTypeGroups = new ObservableCollection<Entities.BodyTypeGroup>((await _bodyTypeGroupsRequester
                .GetBodyTypeGroupsAsync(BodyTypeGroupsFilters)).ToList());
        }

        private async Task BodyTypeGroupsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (BodyTypeGroupsPagination.NumberPage < BodyTypeGroupsPagination.MaxNumberPage)
                {
                    BodyTypeGroupsFilters.NumberPage += 1;
                    BodyTypeGroupsPagination.NumberPage += 1;

                    var bodyTypeGroups = await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(BodyTypeGroupsFilters);

                    foreach (var bodyTypeGroup in bodyTypeGroups)
                    {
                        BodyTypeGroups.Add(bodyTypeGroup);
                    }
                }
            }
        }

        private async Task GenerationsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (GenerationsPagination.NumberPage < GenerationsPagination.MaxNumberPage)
                {
                    GenerationsFilters.NumberPage += 1;
                    GenerationsPagination.NumberPage += 1;

                    GenerationsFilters.ModelsIds = Filters.ModelsIds;

                    var generations = await _generationsRequester.GetGenerationsByModelsIdsAsync(GenerationsFilters);

                    foreach (var generation in generations)
                    {
                        Generations.Add(generation);
                    }
                }
            }
        }

        private async Task BodyTypesLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (BodyTypesPagination.NumberPage < BodyTypesPagination.MaxNumberPage)
                {
                    BodyTypesFilters.NumberPage += 1;
                    BodyTypesPagination.NumberPage += 1;

                    BodyTypesFilters.BodyTypeGroupsIds = Filters.BodyTypeGroupsIds;

                    var bodyTypes = await _bodyTypesRequester.GetBodyTypesOfBodyTypeGroupsAsync(BodyTypesFilters);

                    foreach (var bodyType in bodyTypes)
                    {
                        BodyTypes.Add(bodyType);
                    }
                }
            }
        }

        private async Task OptionsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (OptionsPagination.NumberPage < OptionsPagination.MaxNumberPage)
                {
                    OptionsFilters.NumberPage += 1;
                    OptionsPagination.NumberPage += 1;

                    var options = await _optionsRequester.GetOptionsAsync(OptionsFilters);

                    foreach (var option in options)
                    {
                        Options.Add(option);
                    }
                }
            }
        }

        private async Task RegionsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (RegionsPagination.NumberPage < RegionsPagination.MaxNumberPage)
                {
                    RegionsFilters.NumberPage += 1;
                    RegionsPagination.NumberPage += 1;

                    var regions = await _regionsRequester.GetRegionsAsync(RegionsFilters);

                    foreach (var region in regions)
                    {
                        Regions.Add(region);
                    }
                }
            }
        }

        private async Task VendorsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (VendorsPagination.NumberPage < VendorsPagination.MaxNumberPage)
                {
                    VendorsFilters.NumberPage += 1;
                    VendorsPagination.NumberPage += 1;

                    var vendors = await _vendorsRequester.GetVendorsAsync(VendorsFilters);

                    foreach (var vendor in vendors)
                    {
                        Vendors.Add(vendor);
                    }
                }
            }
        }

        private async Task ColorsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (ColorsPagination.NumberPage < ColorsPagination.MaxNumberPage)
                {
                    ColorsFilters.NumberPage += 1;
                    ColorsPagination.NumberPage += 1;

                    var colors = await _colorsRequester.GetColorsAsync(ColorsFilters);

                    foreach (var color in colors)
                    {
                        Colors.Add(color);
                    }
                }
            }
        }

        private async Task ModelsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (ModelsPagination.NumberPage < ModelsPagination.MaxNumberPage)
                {
                    ModelsFilters.NumberPage += 1;
                    ModelsPagination.NumberPage += 1;

                    ModelsFilters.MarksIds = Filters.MarksIds;

                    var models = await _modelsRequester.GetModelsOfMarksAsync(ModelsFilters);

                    foreach (var model in models)
                    {
                        Models.Add(model);
                    }
                }
            }
        }

        private async Task MarksLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (MarksPagination.NumberPage < MarksPagination.MaxNumberPage)
                {
                    MarksFilters.NumberPage += 1;
                    MarksPagination.NumberPage += 1;

                    var marks = await _marksRequester.GetMarksAsync(MarksFilters);

                    foreach (var mark in marks)
                    {
                        Marks.Add(mark);
                    }
                }
            }
        }

        private async Task TagsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (TagsPagination.NumberPage < TagsPagination.MaxNumberPage)
                {
                    TagsFilters.NumberPage += 1;
                    TagsPagination.NumberPage += 1;

                    var tags = await _tagsRequester.GetTagsAsync(TagsFilters);

                    foreach (var tag in tags)
                    {
                        Tags.Add(tag);
                    }
                }
            }
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var announcements = await _announcementsRequester.GetAnnouncementsAsync(Filters);

                    foreach (var announcement in announcements)
                    {
                        Announcements.Add(announcement);
                    }
                }
            }
        }
    }
}
