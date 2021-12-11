function ownKeys(object, enumerableOnly) { var keys = Object.keys(object); if (Object.getOwnPropertySymbols) { var symbols = Object.getOwnPropertySymbols(object); if (enumerableOnly) { symbols = symbols.filter(function (sym) { return Object.getOwnPropertyDescriptor(object, sym).enumerable; }); } keys.push.apply(keys, symbols); } return keys; }

function _objectSpread(target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i] != null ? arguments[i] : {}; if (i % 2) { ownKeys(Object(source), true).forEach(function (key) { _defineProperty(target, key, source[key]); }); } else if (Object.getOwnPropertyDescriptors) { Object.defineProperties(target, Object.getOwnPropertyDescriptors(source)); } else { ownKeys(Object(source)).forEach(function (key) { Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key)); }); } } return target; }

function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

/**
 * Finder | Directory & Listings Bootstrap Template
 * Copyright 2021 Createx Studio
 * Theme core scripts
 * 
 * @author Createx Studio
 * @version 1.1.0
 */
(function () {
  'use strict';
  /**
   * Toggling password visibility in password input
  */

  var passwordVisibilityToggle = function () {
    var elements = document.querySelectorAll('.password-toggle');

    var _loop = function _loop(i) {
      var passInput = elements[i].querySelector('.form-control'),
          passToggle = elements[i].querySelector('.password-toggle-btn');
      passToggle.addEventListener('click', function (e) {
        if (e.target.type !== 'checkbox') return;

        if (e.target.checked) {
          passInput.type = 'text';
        } else {
          passInput.type = 'password';
        }
      }, false);
    };

    for (var i = 0; i < elements.length; i++) {
      _loop(i);
    }
  }();
  /**
   * Input fields formatter
   * @requires https://github.com/nosir/cleave.js
  */


  var inputFormatter = function () {
    var input = document.querySelectorAll('[data-format]');
    if (input.length === 0) return;

    for (var i = 0; i < input.length; i++) {
      var inputFormat = input[i].dataset.format,
          blocks = input[i].dataset.blocks,
          delimiter = input[i].dataset.delimiter;
      blocks = blocks !== undefined ? blocks.split(' ').map(Number) : '';
      delimiter = delimiter !== undefined ? delimiter : ' ';

      switch (inputFormat) {
        case 'card':
          var card = new Cleave(input[i], {
            creditCard: true
          });
          break;

        case 'cvc':
          var cvc = new Cleave(input[i], {
            numeral: true,
            numeralIntegerScale: 3
          });
          break;

        case 'date':
          var date = new Cleave(input[i], {
            date: true,
            datePattern: ['m', 'y']
          });
          break;

        case 'date-long':
          var dateLong = new Cleave(input[i], {
            date: true,
            delimiter: '-',
            datePattern: ['Y', 'm', 'd']
          });
          break;

        case 'time':
          var time = new Cleave(input[i], {
            time: true,
            datePattern: ['h', 'm']
          });
          break;

        case 'custom':
          var custom = new Cleave(input[i], {
            delimiter: delimiter,
            blocks: blocks
          });
          break;

        default:
          console.error('Sorry, your format ' + inputFormat + ' is not available. You can add it to the theme object method - inputFormatter in src/js/theme.js or choose one from the list of available formats: card, cvc, date, date-long, time or custom.');
      }
    }
  }();
  /**
   * Form validation
  */


  var formValidation = function () {
    var selector = 'needs-validation';
    window.addEventListener('load', function () {
      // Fetch all the forms we want to apply custom Bootstrap validation styles to
      var forms = document.getElementsByClassName(selector); // Loop over them and prevent submission

      var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (e) {
          if (form.checkValidity() === false) {
            e.preventDefault();
            e.stopPropagation();
          }

          form.classList.add('was-validated');
        }, false);
      });
    }, false);
  }();
  /**
   * Add shadow effect to fixed to top navigation bar
  */


  var stickyNavbar = function () {
    var navbar = document.querySelector('.navbar.fixed-top');
    if (navbar == null) return;
    var navbarClass = navbar.classList,
        scrollOffset = 20;
    window.addEventListener('scroll', function (e) {
      if (e.currentTarget.pageYOffset > scrollOffset) {
        navbar.classList.add('navbar-stuck');
      } else {
        navbar.classList.remove('navbar-stuck');
      }
    });
  }();
  /**
   * Anchor smooth scrolling
   * @requires https://github.com/cferdinandi/smooth-scroll/
  */


  var smoothScroll = function () {
    var selector = '[data-scroll]',
        fixedHeader = '[data-scroll-header]',
        scroll = new SmoothScroll(selector, {
      speed: 800,
      speedAsDuration: true,
      offset: function offset(anchor, toggle) {
        return toggle.dataset.scrollOffset || 40;
      },
      header: fixedHeader,
      updateURL: false
    });
  }();
  /**
   * Animate scroll to top button in/off view
  */


  var scrollTopButton = function () {
    var element = document.querySelector('.btn-scroll-top'),
        scrollOffset = 600;
    if (element == null) return;
    var offsetFromTop = parseInt(scrollOffset, 10);
    window.addEventListener('scroll', function (e) {
      if (e.currentTarget.pageYOffset > offsetFromTop) {
        element.classList.add('show');
      } else {
        element.classList.remove('show');
      }
    });
  }();
  /**
   * Tooltip
   * @requires https://getbootstrap.com
   * @requires https://popper.js.org/
  */


  var tooltip = function () {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
      return new bootstrap.Tooltip(tooltipTriggerEl, {
        trigger: 'hover'
      });
    });
  }();
  /**
   * Popover
   * @requires https://getbootstrap.com
   * @requires https://popper.js.org/
  */


  var popover = function () {
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
      return new bootstrap.Popover(popoverTriggerEl);
    });
  }();
  /**
   * Toast
   * @requires https://getbootstrap.com
  */


  var toast = function () {
    var toastElList = [].slice.call(document.querySelectorAll('.toast'));
    var toastList = toastElList.map(function (toastEl) {
      return new bootstrap.Toast(toastEl);
    });
  }();
  /**
   * Range slider
   * @requires https://github.com/leongersen/noUiSlider
  */


  var rangeSlider = function () {
    var rangeSliderWidget = document.querySelectorAll('.range-slider');

    var _loop2 = function _loop2(i) {
      var rangeSlider = rangeSliderWidget[i].querySelector('.range-slider-ui'),
          valueMinInput = rangeSliderWidget[i].querySelector('.range-slider-value-min'),
          valueMaxInput = rangeSliderWidget[i].querySelector('.range-slider-value-max');
      var options = {
        dataStartMin: parseFloat(rangeSliderWidget[i].dataset.startMin, 10),
        dataStartMax: parseFloat(rangeSliderWidget[i].dataset.startMax, 10),
        dataMin: parseFloat(rangeSliderWidget[i].dataset.min, 10),
        dataMax: parseFloat(rangeSliderWidget[i].dataset.max, 10),
        dataStep: parseFloat(rangeSliderWidget[i].dataset.step, 10)
      };
      var start = options.dataStartMax ? [options.dataStartMin, options.dataStartMax] : [options.dataStartMin],
      connect = options.dataStartMax ? true : 'lower';
      noUiSlider.create(rangeSlider, {
        start: start,
        connect: connect,
        step: options.dataStep,
        tooltips: true,
        range: {
          'min': options.dataMin,
          'max': options.dataMax
        },
        format: {
          to: function to(value) {
            return value;
          },
          from: function from(value) {
            return value;
          }
        }
      });
      rangeSlider.noUiSlider.on('update', function (values, handle) {
        var value = values[handle];

        if (handle) {
          if (valueMaxInput) {
            valueMaxInput.value = value;
          }
        } else {
          if (valueMinInput) {
            valueMinInput.value = value;
          }
        }
      });

      if (valueMinInput) {
        valueMinInput.addEventListener('change', function () {
          rangeSlider.noUiSlider.set([this.value, null]);
        });
      }

      if (valueMaxInput) {
        valueMaxInput.addEventListener('change', function () {
          rangeSlider.noUiSlider.set([null, this.value]);
        });
      }
    };

    for (var i = 0; i < rangeSliderWidget.length; i++) {
      _loop2(i);
    }
  }();
  /**
   * Force dropdown to work as select box
  */


  var dropdownSelect = function () {
    var dropdownSelectList = document.querySelectorAll('[data-bs-toggle="select"]');

    var _loop3 = function _loop3(i) {
      var dropdownItems = dropdownSelectList[i].querySelectorAll('.dropdown-item'),
          dropdownToggleLabel = dropdownSelectList[i].querySelector('.dropdown-toggle-label'),
          hiddenInput = dropdownSelectList[i].querySelector('input[type="hidden"]');

      for (var n = 0; n < dropdownItems.length; n++) {
        dropdownItems[n].addEventListener('click', function (e) {
          e.preventDefault();
          var dropdownLabel = this.querySelector('.dropdown-item-label').innerText;
          dropdownToggleLabel.innerText = dropdownLabel;

          if (hiddenInput !== null) {
            hiddenInput.value = dropdownLabel;
          }
        });
      }
    };

    for (var i = 0; i < dropdownSelectList.length; i++) {
      _loop3(i);
    }
  }();
  /**
   * Content carousel with extensive options to control behaviour and appearance
   * @requires https://github.com/ganlanyuan/tiny-slider
  */


  var carousel = function () {
    // forEach function
    var forEach = function forEach(array, callback, scope) {
      for (var i = 0; i < array.length; i++) {
        callback.call(scope, i, array[i]); // passes back stuff we need
      }
    }; // Carousel initialisation


    var carousels = document.querySelectorAll('.tns-carousel-wrapper .tns-carousel-inner');
    forEach(carousels, function (index, value) {
      var controlsText;

      if (value.dataset.carouselOptions != undefined && JSON.parse(value.dataset.carouselOptions).axis === 'vertical') {
        controlsText = ['<i class="fi-chevron-up"></i>', '<i class="fi-chevron-down"></i>'];
      } else {
        controlsText = ['<i class="fi-chevron-left"></i>', '<i class="fi-chevron-right"></i>'];
      }

      var defaults = {
        container: value,
        controlsText: controlsText,
        navPosition: 'bottom',
        mouseDrag: true,
        speed: 500,
        autoplayHoverPause: true,
        autoplayButtonOutput: false
      };
      var userOptions;
      if (value.dataset.carouselOptions != undefined) userOptions = JSON.parse(value.dataset.carouselOptions);
      var options = Object.assign({}, defaults, userOptions);
      var carousel = tns(options);
      var carouselWrapper = value.closest('.tns-carousel-wrapper'),
          carouselItems = carouselWrapper.querySelectorAll('.tns-item'),
          carouselInfo = carousel.getInfo(),
          carouselCurrentSlide = carouselWrapper.querySelector('.tns-current-slide'),
          carouselTotalSlides = carouselWrapper.querySelector('.tns-total-slides'); // Center slide

      if (carouselWrapper.classList.contains('tns-center')) {
        var indexCurrentInitial = carouselInfo.index;
        carouselInfo.slideItems[indexCurrentInitial].classList.add('active');
        carousel.events.on('indexChanged', function () {
          var info = carousel.getInfo(),
              indexPrev = info.indexCached,
              indexCurrent = info.index;
          info.slideItems[indexPrev].classList.remove('active');
          info.slideItems[indexCurrent].classList.add('active');
        });
      } // Slides count


      if (carouselWrapper.querySelector('.tns-slides-count') === null) return;
      carouselCurrentSlide.innerHTML = carouselInfo.displayIndex;
      carouselTotalSlides.innerHTML = carouselInfo.slideCount;
      carousel.events.on('indexChanged', function () {
        var info = carousel.getInfo();
        carouselCurrentSlide.innerHTML = info.displayIndex;
      });
    });
  }();
  /**
   * Gallery like styled lightbox component for presenting various types of media
   * @requires https://github.com/sachinchoolur/lightgallery.js
  */


  var gallery = function () {
    var gallery = document.querySelectorAll('.gallery');

    if (gallery.length) {
      for (var i = 0; i < gallery.length; i++) {
        var thumbnails = gallery[i].dataset.thumbnails ? true : false;
        lightGallery(gallery[i], {
          selector: '.gallery-item',
          download: false,
          thumbnail: thumbnails,
          videojs: true,
          youtubePlayerParams: {
            modestbranding: 1,
            showinfo: 0,
            rel: 0
          },
          vimeoPlayerParams: {
            byline: 0,
            portrait: 0,
            color: 'fd5631'
          }
        });
      }
    }
  }();
  /**
   * Lightbox component for presenting various types of media
   * @requires https://github.com/sachinchoolur/lightgallery.js
  */


  var lightbox = function () {
    var lightboxToogle = document.querySelectorAll('[data-bs-toggle="lightbox"]');

    if (lightboxToogle.length) {
      for (var i = 0; i < lightboxToogle.length; i++) {
        lightGallery(lightboxToogle[i], {
          selector: 'this',
          download: false,
          videojs: true,
          youtubePlayerParams: {
            modestbranding: 1,
            showinfo: 0,
            rel: 0
          },
          vimeoPlayerParams: {
            byline: 0,
            portrait: 0,
            color: 'fd5631'
          }
        });
      }
    }
  }();
  /**
   * Date / time picker
   * @requires https://github.com/flatpickr/flatpickr
   */


  var datePicker = function () {
    var picker = document.querySelectorAll('.date-picker');
    if (picker.length === 0) return;

    for (var i = 0; i < picker.length; i++) {
      var defaults = {
        disableMobile: 'true'
      };
      var userOptions = void 0;
      if (picker[i].dataset.datepickerOptions != undefined) userOptions = JSON.parse(picker[i].dataset.datepickerOptions);
      var linkedInput = picker[i].classList.contains('date-range') ? {
        "plugins": [new rangePlugin({
          input: picker[i].dataset.linkedInput
        })]
      } : '{}';

      var options = _objectSpread(_objectSpread(_objectSpread({}, defaults), linkedInput), userOptions);

      flatpickr(picker[i], options);
    }
  }();
  /**
   * Ajaxify MailChimp subscription form
  */


  var subscriptionForm = function () {
    var form = document.querySelectorAll('.subscription-form');
    if (form === null) return;

    var _loop4 = function _loop4(i) {
      var button = form[i].querySelector('button[type="submit"]'),
          buttonText = button.innerHTML,
          input = form[i].querySelector('.form-control'),
          antispam = form[i].querySelector('.subscription-form-antispam'),
          status = form[i].querySelector('.subscription-status');
      form[i].addEventListener('submit', function (e) {
        if (e) e.preventDefault();
        if (antispam.value !== '') return;
        register(this, button, input, buttonText, status);
      });
    };

    for (var i = 0; i < form.length; i++) {
      _loop4(i);
    }

    var register = function register(form, button, input, buttonText, status) {
      button.innerHTML = 'Sending...'; // Get url for MailChimp

      var url = form.action.replace('/post?', '/post-json?'); // Add form data to object

      var data = '&' + input.name + '=' + encodeURIComponent(input.value); // Create and add post script to the DOM

      var script = document.createElement('script');
      script.src = url + '&c=callback' + data;
      document.body.appendChild(script); // Callback function

      var callback = 'callback';

      window[callback] = function (response) {
        // Remove post script from the DOM
        delete window[callback];
        document.body.removeChild(script); // Change button text back to initial

        button.innerHTML = buttonText; // Display content and apply styling to response message conditionally

        if (response.result == 'success') {
          input.classList.remove('is-invalid');
          input.classList.add('is-valid');
          status.classList.remove('status-error');
          status.classList.add('status-success');
          status.innerHTML = response.msg;
          setTimeout(function () {
            input.classList.remove('is-valid');
            status.innerHTML = '';
            status.classList.remove('status-success');
          }, 6000);
        } else {
          input.classList.remove('is-valid');
          input.classList.add('is-invalid');
          status.classList.remove('status-success');
          status.classList.add('status-error');
          status.innerHTML = response.msg.substring(4);
          setTimeout(function () {
            input.classList.remove('is-invalid');
            status.innerHTML = '';
            status.classList.remove('status-error');
          }, 6000);
        }
      };
    };
  }();
  /**
   * Interactive map
   * @requires https://github.com/Leaflet/Leaflet
  */


  var interactiveMap = function () {
    var mapList = document.querySelectorAll('.interactive-map');
    if (mapList.length === 0) return;

    var _loop5 = function _loop5(i) {
      var mapOptions = mapList[i].dataset.mapOptions,
          mapOptionsExternal = mapList[i].dataset.mapOptionsJson,
          map = void 0; // Map options: Inline JSON data

      if (mapOptions && mapOptions !== '') {
        var mapOptionsObj = JSON.parse(mapOptions),
            mapLayer = mapOptionsObj.mapLayer || 'https://api.maptiler.com/maps/voyager/{z}/{x}/{y}.png?key=5vRQzd34MMsINEyeKPIs',
            mapCoordinates = mapOptionsObj.coordinates ? mapOptionsObj.coordinates : [0, 0],
            mapZoom = mapOptionsObj.zoom || 1,
            scrollWheelZoom = mapOptionsObj.scrollWheelZoom === false ? false : true,
            markers = mapOptionsObj.markers; // Map setup

        map = L.map(mapList[i], {
          scrollWheelZoom: scrollWheelZoom
        }).setView(mapCoordinates, mapZoom); // Tile layer

        L.tileLayer(mapLayer, {
          tileSize: 512,
          zoomOffset: -1,
          minZoom: 1,
          attribution: "<a href=\"https://www.maptiler.com/copyright/\" target=\"_blank\">&copy; MapTiler</a> <a href=\"https://www.openstreetmap.org/copyright\" target=\"_blank\">&copy; OpenStreetMap contributors</a>",
          crossOrigin: true
        }).addTo(map); // Markers

        if (markers) {
          for (n = 0; n < markers.length; n++) {
            var iconUrl = markers[n].iconUrl,
                iconClass = markers[n].className,
                markerIcon = L.icon({
              iconUrl: iconUrl || '../img/map/marker-icon.png',
              iconSize: [25, 39],
              iconAnchor: [12, 39],
              shadowUrl: '../img/map/marker-shadow.png',
              shadowSize: [41, 41],
              shadowAnchor: [13, 41],
              popupAnchor: [1, -28],
              className: iconClass
            }),
                popup = markers[n].popup;
            var marker = L.marker(markers[n].coordinates, {
              icon: markerIcon
            }).addTo(map);

            if (popup) {
              marker.bindPopup(popup);
            }
          }
        } // Map options: External JSON file

      } else if (mapOptionsExternal && mapOptionsExternal !== '') {
        fetch(mapOptionsExternal).then(function (response) {
          return response.json();
        }).then(function (data) {
          var mapLayer = data.mapLayer || 'https://api.maptiler.com/maps/voyager/{z}/{x}/{y}.png?key=5vRQzd34MMsINEyeKPIs',
              mapCoordinates = data.coordinates ? data.coordinates : [0, 0],
              mapZoom = data.zoom || 1,
              scrollWheelZoom = data.scrollWheelZoom === false ? false : true,
              markers = data.markers; // Map setup

          map = L.map(mapList[i], {
            scrollWheelZoom: scrollWheelZoom
          }).setView(mapCoordinates, mapZoom); // Tile layer

          L.tileLayer(mapLayer, {
            tileSize: 512,
            zoomOffset: -1,
            minZoom: 1,
            attribution: "<a href=\"https://www.maptiler.com/copyright/\" target=\"_blank\">&copy; MapTiler</a> <a href=\"https://www.openstreetmap.org/copyright\" target=\"_blank\">&copy; OpenStreetMap contributors</a>",
            crossOrigin: true
          }).addTo(map); // Markers

          if (markers) {
            for (var n = 0; n < markers.length; n++) {
              var _iconUrl = markers[n].iconUrl,
                  _iconClass = markers[n].className,
                  _markerIcon = L.icon({
                iconUrl: _iconUrl || '../img/map/marker-icon.png',
                iconSize: [25, 39],
                iconAnchor: [12, 39],
                shadowUrl: '../img/map/marker-shadow.png',
                shadowSize: [41, 41],
                shadowAnchor: [13, 41],
                popupAnchor: [1, -28],
                className: _iconClass
              }),
                  _popup = markers[n].popup;

              var _marker = L.marker(markers[n].coordinates, {
                icon: _markerIcon
              }).addTo(map);

              if (_popup) {
                _marker.bindPopup(_popup);
              }
            }
          }
        }); // Map option: No options provided
      } else {
        map = L.map(mapList[i]).setView([0, 0], 1);
        L.tileLayer('https://api.maptiler.com/maps/voyager/{z}/{x}/{y}.png?key=5vRQzd34MMsINEyeKPIs', {
          tileSize: 512,
          zoomOffset: -1,
          minZoom: 1,
          attribution: "<a href=\"https://www.maptiler.com/copyright/\" target=\"_blank\">&copy; MapTiler</a> <a href=\"https://www.openstreetmap.org/copyright\" target=\"_blank\">&copy; OpenStreetMap contributors</a>",
          crossOrigin: true
        }).addTo(map);
      }
    };

    for (var i = 0; i < mapList.length; i++) {
      var n;

      _loop5(i);
    }
  }();
  /**
   * Mouse move parallax effect
   * @requires https://github.com/wagerfield/parallax
  */


  var parallax = function () {
    var element = document.querySelectorAll('.parallax');

    for (var i = 0; i < element.length; i++) {
      var parallaxInstance = new Parallax(element[i]);
    }
  }();
  /**
   * File uploader
   * @requires https://github.com/pqina/filepond
  */


  var fileUploader = function () {
    var fileInput = document.querySelectorAll('.file-uploader');
    if (fileInput.length === 0) return;

    if (typeof FilePondPluginFileValidateType !== 'undefined') {
      FilePond.registerPlugin(FilePondPluginFileValidateType);
    }

    if (typeof FilePondPluginFileValidateSize !== 'undefined') {
      FilePond.registerPlugin(FilePondPluginFileValidateSize);
    }

    if (typeof FilePondPluginImagePreview !== 'undefined') {
      FilePond.registerPlugin(FilePondPluginImagePreview);
    }

    if (typeof FilePondPluginImageCrop !== 'undefined') {
      FilePond.registerPlugin(FilePondPluginImageCrop);
    }

    if (typeof FilePondPluginImageResize !== 'undefined') {
      FilePond.registerPlugin(FilePondPluginImageResize);
    }

    if (typeof FilePondPluginImageTransform !== 'undefined') {
      FilePond.registerPlugin(FilePondPluginImageTransform);
    }

    for (var i = 0; i < fileInput.length; i++) {
      FilePond.create(fileInput[i]);
    }
  }();
  /**
   * Bind input value with target element text
  */


  var bindedInputValue = function () {
    var bindedInput = document.querySelectorAll('[data-bs-binded-element]');
    if (bindedInput.length === 0) return;

    var _loop6 = function _loop6(i) {
      var bindedElement = document.querySelector(bindedInput[i].dataset.bsBindedElement),
          unsetValue = bindedInput[i].dataset.bsUnsetValue;

      if (bindedInput[i].tagName === 'SELECT') {
        bindedInput[i].addEventListener('change', function (e) {
          bindedElement.innerText = e.target.value;
        });
      } else if (bindedInput[i].classList.contains('date-picker')) {
        bindedInput[i].addEventListener('change', function (e) {
          if (e.target.value !== '') {
            bindedElement.innerText = e.target.value;
          } else {
            bindedElement.innerText = unsetValue;
          }
        });
      } else {
        bindedInput[i].addEventListener('keyup', function (e) {
          if (e.target.value !== '') {
            bindedElement.innerText = e.target.value;
          } else {
            bindedElement.innerText = unsetValue;
          }
        });
      }
    };

    for (var i = 0; i < bindedInput.length; i++) {
      _loop6(i);
    }
  }();
  /**
   * Master checkbox that checkes / unchecks all target checkboxes at once
  */


  var masterCheckbox = function () {
    var masterCheckbox = document.querySelectorAll('[data-master-checkbox-for]');
    if (masterCheckbox.length === 0) return;

    for (var i = 0; i < masterCheckbox.length; i++) {
      masterCheckbox[i].addEventListener('change', function () {
        var targetWrapper = document.querySelector(this.dataset.masterCheckboxFor),
            targetCheckboxes = targetWrapper.querySelectorAll('input[type="checkbox"]');

        if (this.checked) {
          for (var n = 0; n < targetCheckboxes.length; n++) {
            targetCheckboxes[n].checked = true;

            if (targetCheckboxes[n].dataset.checkboxToggleClass) {
              document.querySelector(targetCheckboxes[n].dataset.bsTarget).classList.add(targetCheckboxes[n].dataset.checkboxToggleClass);
            }
          }
        } else {
          for (var m = 0; m < targetCheckboxes.length; m++) {
            targetCheckboxes[m].checked = false;

            if (targetCheckboxes[m].dataset.checkboxToggleClass) {
              document.querySelector(targetCheckboxes[m].dataset.bsTarget).classList.remove(targetCheckboxes[m].dataset.checkboxToggleClass);
            }
          }
        }
      });
    }
  }();
  /**
   * Toggle CSS class passed via data attribute
  */


  var toggleClass = function () {
    var toggler = document.querySelectorAll('[data-bs-toggle-class]');

    for (var i = 0; i < toggler.length; i++) {
      toggler[i].addEventListener('click', function (e) {
        e.preventDefault();
        var targetEl = document.querySelector(e.currentTarget.dataset.bsTarget),
            toggleClass = e.currentTarget.dataset.bsToggleClass;
        targetEl.classList.toggle(toggleClass);
      });
    }
  }();
})();