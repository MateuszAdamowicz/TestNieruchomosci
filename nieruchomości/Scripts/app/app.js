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

searcher.filter('uniqueRooms', function () {
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
                if (uniqueList[i][key] === "1") {
                    uniqueList[i].counter = uniqueList[i][key] + " pokój (" + unique[uniqueList[i][key]] + ")";
                }
                else if (uniqueList[i][key] === "2" || uniqueList[i][key] === "3" || uniqueList[i][key] === "4") {
                    uniqueList[i].counter = uniqueList[i][key] + " pokoje (" + unique[uniqueList[i][key]] + ")";
                }
                else{
                    uniqueList[i].counter = uniqueList[i][key] + " pokoi (" + unique[uniqueList[i][key]] + ")";
                }

            }
            return uniqueList;
        }
    };
});

searcher.filter('pricefilter', function () {
    return function (input, key) {
        var filtered = [];
        if (key) {
            if (typeof input !== "undefined") {
                for (var i = 0; i < input.length; i++) {
                    if (input[i].Price) {
                        var number = Number(input[i].Price.split('z')[0].replace(/ /g, ''));
                        if (key.max === null && key.min <= number) {
                            filtered.push(input[i]);
                        } else if (key.max > number && key.min <= number) {
                            filtered.push(input[i]);
                        }
                    }
                }

            }
        } else {
            filtered = input;
        }
        return filtered;
    };
});

searcher.filter('usableareafilter', function () {
    return function (input, key) {
        var filtered = [];
        if (key) {
            if (typeof input !== "undefined") {
                for (var i = 0; i < input.length; i++) {
                    if (input[i].UsableArea) {
                        var number = Number(input[i].UsableArea.split('m')[0]);
                        if (key.max === null && key.min <= number) {
                            filtered.push(input[i]);
                        } else if (key.max > number && key.min <= number) {
                            filtered.push(input[i]);
                        }
                    }
                }

            }
        } else {
            filtered = input;
        }
        return filtered;
    };
});

searcher.filter('areafilter', function () {
    return function (input, key) {
        var filtered = [];
        if (key) {
            if (typeof input !== "undefined") {

                for (var i = 0; i < input.length; i++) {
                    if(input[i].Area){
                        var number = Number(input[i].Area.split('m')[0]);
                        if (key.max === null && key.min <= number) {
                            filtered.push(input[i]);
                        } else if (key.max > number && key.min <= number) {
                            filtered.push(input[i]);
                        }
                    }
                }

            }
        } else {
            filtered = input;
        }
        return filtered;
    };
});

//searcher.filter('unique2', function () {
//    return function (input, key) {
//        if (typeof input !== "undefined") {
//            var unique = {};

//            var uniqueList = [
//{ name: 'Poniżej 100 000 zł', min: 0, max: 100000 },
//{ name: 'Od 100 000zł do 150 000zł', min: 100000, max: 200000 },
//{ name: 'Od 150 000zł do 200 000zł', min: 150000, max: 200000 },
//{ name: 'Od 200 000zł do 300 000zł', min: 200000, max: 300000 },
//{ name: 'Od 300 000zł do 400 000zł', min: 300000, max: 400000 },
//{ name: 'Od 400 000zł do 500 000zł', min: 400000, max: 500000 },
//{ name: 'Powyżej 500 000zł', min: 500000, max: null }
//            ];
//            for (var i = 0; i < input.length; i++) {
//                var number = Number(input[i][key].split('z')[0].replace(/ /g, ''));
//                if (number < 100000) {
//                    unique1 += 1;
//                }
//                else if (number >= 100000 && number < 150000) {
//                    unique2 += 1;
//                }
//                else if (number >= 150000 && number < 200000) {
//                    unique3 += 1;
//                }
//                else if (number >= 200000 && number < 300000) {
//                    unique4 += 1;
//                }
//                else if (number >= 300000 && number < 400000) {
//                    unique5 += 1;
//                }
//                else if (number >= 400000 && number < 500000) {
//                    unique6 += 1;
//                }
//                else if (number >= 500000) {
//                    unique7 += 1;
//                };
//            }

//            return uniqueList;
//        }
//    };
//});

searcher.controller('SearcherController', function ($scope, $resource, $location) {

    $scope.$location = $location;
    $scope.properties = [
    { name: 'Domy', value: 'house' },
    { name: 'Mieszkania', value: 'flat' },
    { name: 'Działki', value: 'land' }
    ];

    $scope.prices = [
{ name: 'Poniżej 100 000 zł', min: 0, max: 100000 },
{ name: 'Od 100 000 zł do 150 000 zł', min: 100000, max: 150000 },
{ name: 'Od 150 000 zł do 200 000 zł', min: 150000, max: 200000 },
{ name: 'Od 200 000 zł do 300 000 zł', min: 200000, max: 300000 },
{ name: 'Od 300 000 zł do 400 000 zł', min: 300000, max: 400000 },
{ name: 'Od 400 000 zł do 500 000 zł', min: 400000, max: 500000 },
{ name: 'Powyżej 500 000 zł', min: 500000, max: null }
    ];

    $scope.usableareas = [
{ name: 'Poniżej 100 m2', min: 0, max: 100 },
{ name: 'Od 100 m2 do 2000 m2', min: 100, max: 150 },
{ name: 'Od 2000 m2 do 5000 m2', min: 150, max: 200 },
{ name: 'Od 5000 m2 do 10000 m2', min: 200, max: 250 },
{ name: 'Od 10000 m2 do 20000 m2', min: 250, max: 300 },
{ name: 'Powyżej 300 m2', min: 300, max: null }
    ];

    $scope.areas = [
{ name: 'Poniżej 1000 m2', min: 0, max: 1000 },
{ name: 'Od 1000 m2 do 2000 m2', min: 1000, max: 2000 },
{ name: 'Od 2000 m2 do 5000 m2', min: 2000, max: 5000 },
{ name: 'Od 5000 m2 do 10000 m2', min: 5000, max: 10000 },
{ name: 'Od 10000 m2 do 20000 m2', min: 10000, max: 20000 },
{ name: 'Powyżej 20000 m2', min: 20000, max: null }
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
        if (offert) {
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
            $location.search('usablearea', usablearea.name);
        } else if (usablearea === null) {
            $location.search('usablearea', null);
        }
    });
    $scope.$watch('$location.search().usablearea', function (usablearea) {
        for (var i = 0; i < $scope.usableareas.length; i++) {
            if ($scope.usableareas[i].name === usablearea) {
                $scope.myhouseUsableArea = $scope.usableareas[i];
            }
        }
    });

    //$scope.myhousePrice = null;
    $scope.$watch('myhousePrice', function (price) {
        if (price) {
            $location.search('price', price.name);
        } else if (price === null) {
            $location.search('price', null);
        }
    });
    $scope.$watch('$location.search().price', function (price) {
                for (var i = 0; i < $scope.prices.length; i++) {
            if ($scope.prices[i].name === price) {
                $scope.myhousePrice = $scope.prices[i];
            }
        }
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
            $location.search('area', area.name);
        } else if (area === null) {
            $location.search('area', null);
        }
    });

    $scope.$watch('$location.search().area', function (area) {
        for (var i = 0; i < $scope.areas.length; i++) {
            if ($scope.areas[i].name === area) {
                $scope.mylandArea = $scope.areas[i];
            }
        }
    });

    $scope.$watch('$location.search().price', function (price) {
        for (var i = 0; i < $scope.prices.length; i++) {
            if ($scope.prices[i].name === price) {
                $scope.mylandPrice = $scope.prices[i];
            }
        }
    });
    //$scope.mylandPrice = null;
    $scope.$watch('mylandPrice', function (price) {
        if (price) {
            $location.search('price', price.name);
        } else if (price === null) {
            $location.search('price', null);
        }
    });
    $scope.$watch('$location.search().price', function (price) {
        for (var i = 0; i < $scope.prices.length; i++) {
            if ($scope.prices[i].name === price) {
                $scope.mylandPrice = $scope.prices[i];
            }
        }
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
            $location.search('price', price.name);
        } else if (price === null) {
            $location.search('price', null);
        }
    });
    $scope.$watch('$location.search().price', function (price) {
        for (var i = 0; i < $scope.prices.length; i++) {
            if ($scope.prices[i].name === price) {
                $scope.myflatPrice = $scope.prices[i];
            }
        }
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
