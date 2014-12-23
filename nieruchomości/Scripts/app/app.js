//var appRoot = angular.module('main', ['ngRoute', 'ngGrid', 'ngResource']);     //Define the main module

//appRoot
//    .config(['$routeProvider', function ($routeProvider) {
//        //Setup routes to load partial templates from server. TemplateUrl is the location for the server view (Razor .cshtml view)
//        $routeProvider
//            .when('/land', { templateUrl: '/home/land', controller: 'LandController' })
//            .when('/flat', { templateUrl: '/home/flat', controller: 'FlatController' })
//            .when('/house', { templateUrl: '/home/house', controller: 'HouseController' })
//            .otherwise({ redirectTo: '' });
//    }])
//    .controller('RootController', ['$scope', '$route', '$routeParams', '$location', function ($scope, $route, $routeParams, $location) {
//        $scope.$on('$routeChangeSuccess', function (e, current, previous) {
//            $scope.activeViewPath = $location.path();
//        });
//    }]);

var searcher = angular.module('searcher', ['ngResource', 'ngRoute', 'angularUtils.directives.dirPagination']);



searcher.config(function ($httpProvider) {
    $httpProvider.interceptors.push('myHttpInterceptor');

    var spinnerFunction = function spinnerFunction(data) {
        $("#spinner").show();
        return data;
    };

    $httpProvider.defaults.transformRequest.push(spinnerFunction);
    $httpProvider.defaults.timeout = 5000;
    //$routeProvider.when('/', { reloadOnSearch: false });
});


searcher.factory('myHttpInterceptor', function ($q) {
    return {
        'response':
            function (response) {
                $("#spinner").hide();
                return response || $q.when(response);
            },
        'responseError':
            function (response) {
                $("#spinner").hide();
                return $q.reject(response);
            }
    };
});

searcher.filter('unique', function () {
    return function (input, key) {
        if (typeof input !== "undefined") {
            var unique = {};
            var uniqueList = [];
            for (var i = 0; i < input.length; i++) {
                if (typeof unique[input[i][key]] == "undefined") {
                    unique[input[i][key]] = 1;
                    uniqueList.push(input[i]);
                } else {
                    unique[input[i][key]] += 1;
                };
            }
            for (var i = 0; i < uniqueList.length; i++) {
                uniqueList[i].counter = uniqueList[i][key] + " (" + unique[uniqueList[i][key]] + ")";
            }
            return uniqueList;
        }
    };
});
searcher.controller('SearcherController', function ($scope, $resource, $location) {

    $scope.$location = $location;
    $scope.properties = [
    { name: 'Domy', value: 'house' },
    { name: 'Mieszkania', value: 'flat' },
    { name: 'Działki', value: 'land' }
    ];

    //$scope.myProperty = null;
    $scope.$watch('$location.search().property', function (property) {
        $scope.myProperty = property;
    });

    //$scope.myoffertTypeHouse = null;
    $scope.$watch('myoffertTypeHouse', function (offert) {
        if (offert) {
            $location.search('offert', offert);
        } else if (offert === null) {
            $location.search('offert', null);
        }
    });
    $scope.$watch('$location.search().offert', function (offert) {
        $scope.myoffertTypeHouse = offert;
    });

    //$scope.myoffertTypeFlat = null;
    $scope.$watch('myoffertTypeFlat', function (offert) {
        if (offert || offert === false) {
            $location.search('offert', offert);
        } else if (offert === null) {
            $location.search('offert', null);
        }
    });
    $scope.$watch('$location.search().offert', function (offert) {
        $scope.myoffertTypeFlat = offert;
    });


    $scope.boolToStr = function (arg) { return arg ? 'Wynajem' : 'Sprzedaż' };

    $scope.$watch('myProperty', function (myProperty) {

        if (myProperty === 'flat') {
            $location.search('property', myProperty);
            $resource('/api/offertsapi/getflats', {}, {}).query().$promise.then(function (data) {
                $scope.flatList = data;
            });
        }
        else if (myProperty === 'land') {
            $location.search('property', myProperty);
            $resource('/api/offertsapi/getlands', {}, {}).query().$promise.then(function (data) {
                $scope.landList = data;
            });
        }
        else if (myProperty === 'house') {
            $location.search('property', myProperty);
            $resource('/api/offertsapi/gethouses', {}, {}).query().$promise.then(function (data) {
                $scope.houseList = data;
            });
        }
        else {
            $location.search('offert', null);
        }
    });

    // $scope.myhouseCity = null;
    $scope.$watch('myhouseCity', function (city) {
        if (city) {
            $location.search('city', city);
        } else if (city === null) {
            $location.search('city', null);
        }
    });
    $scope.$watch('$location.search().city', function (city) {
        $scope.myhouseCity = city;
    });

    //$scope.myhouseUsableArea = null;
    $scope.$watch('myhouseUsableArea', function (usablearea) {
        if (usablearea) {
            $location.search('usablearea', usablearea);
        } else if (usablearea === null) {
            $location.search('usablearea', null);
        }
    });
    $scope.$watch('$location.search().usablearea', function (usablearea) {
        $scope.myhouseUsableArea = usablearea;
    });

    //$scope.myhousePrice = null;
    $scope.$watch('myhousePrice', function (price) {
        if (price) {
            $location.search('price', price);
        } else if (price === null) {
            $location.search('price', null);
        }
    });
    $scope.$watch('$location.search().price', function (price) {
        $scope.myhousePrice = price;
    });

    //$scope.mylandCity = null;
    $scope.$watch('mylandCity', function (city) {
        if (city) {
            $location.search('city', city);
        } else if (city === null) {
            $location.search('city', null);
        }
    });
    $scope.$watch('$location.search().city', function (city) {
        $scope.mylandCity = city;
    });

    //$scope.mylandArea = null;
    $scope.$watch('mylandArea', function (area) {
        if (area) {
            $location.search('area', area);
        } else if (area === null) {
            $location.search('area', null);
        }
    });
    $scope.$watch('$location.search().area', function (area) {
        $scope.mylandArea = area;
    });

    //$scope.mylandPrice = null;
    $scope.$watch('mylandPrice', function (price) {
        if (price) {
            $location.search('price', price);
        } else if (price === null) {
            $location.search('price', null);
        }
    });
    $scope.$watch('$location.search().price', function (price) {
        $scope.mylandPrice = price;
    });

    //$scope.myflatCity = null;
    $scope.$watch('myflatCity', function (city) {
        if (city) {
            $location.search('city', city);
        } else if (city === null) {
            $location.search('city', null);
        }
    });
    $scope.$watch('$location.search().city', function (city) {
        $scope.myflatCity = city;
    });

    //$scope.myflatRoom = null;
    $scope.$watch('myflatRoom', function (room) {
        if (room) {
            $location.search('room', room);
        } else if (room === null) {
            $location.search('room', null);
        }
    });
    $scope.$watch('$location.search().room', function (room) {
        $scope.myflatRoom = room;
    });

    // $scope.myflatPrice = null;
    $scope.$watch('myflatPrice', function (price) {
        if (price) {
            $location.search('price', price);
        } else if (price === null) {
            $location.search('price', null);
        }
    });
    $scope.$watch('$location.search().price', function (price) {
        $scope.myflatPrice = price;
    });

    $scope.mySortFunction = function (item) {
        if ($scope.mySort) {
            if ($scope.mySort.value === 'Price') {
                return Number(item[$scope.mySort.value].split('z')[0].replace(/ /g, ''));
            } else {
                return item[$scope.mySort.value];
            }
        }
    };

    $scope.sorting = [
        { name: 'Po cenie-rosnąco', value: 'Price', reverse: false },
        { name: 'Po cenie-malejąco', value: 'Price', reverse: true },
        { name: 'Po dacie-rosnąco', value: 'CreatedAt', reverse: false },
        { name: 'Po dacie-malejąco', value: 'CreatedAt', reverse: true }
    ];

    //$scope.mySort = null;
    $scope.$watch('mySort', function (sort) {
        if (sort) {
            $location.search('sort', sort.name);
        } else if (sort === null) {
            $location.search('sort', null);
        }
    });
    $scope.$watch('$location.search().sort', function (sort) {
        for (var i = 0; i < $scope.sorting.length; i++) {
            if ($scope.sorting[i].name === sort) {
                $scope.mySort = $scope.sorting[i];
            } 
        }
    });


    $scope.clearFilters = function (myProperty) {

        if (myProperty === 'flat') {
            $scope.myoffertTypeFlat = null;
            $scope.myflatCity = null;
            $scope.myflatRoom = null;
            $scope.myflatPrice = null;
            $scope.mySort = null;
        }
        else if (myProperty === 'land') {
            $scope.mylandCity = null;
            $scope.mylandArea = null;
            $scope.mylandPrice = null;
            $scope.mySort = null;
        }
        else if (myProperty === 'house') {
            $scope.myoffertTypeHouse = null;
            $scope.myhouseCity = null;
            $scope.myhouseUsableArea = null;
            $scope.myhousePrice = null;
            $scope.mySort = null;
        }
    };
    $scope.clearFiltersAll = function () {
        $scope.clearFilters('flat');
        $scope.clearFilters('house');
        $scope.clearFilters('land');
        //$location.search('room', null);
        //$location.search('price', null);
        //$location.search('area', null);
        //$location.search('city', null);
        //$location.search('usablearea', null);
    };
    $scope.currentPage = 1;
    $scope.pageSize = 5;

});


searcher.controller("NewestController", function ($scope, $resource) {
    $scope.NewestAdverts = [];
    var newestResource = $resource('/api/offertsapi/getnewest', {}, { timeout: { params: 5000 } });
    newestResource.query(function (data) {
        $scope.NewestAdverts = data;
    });
});
