appRoot.controller('HouseController', function ($scope, $location, $resource) {

    var userResource = $resource('/api/offertsapi/gethouses', {}, {});
    $scope.filterOptions = {
        filterText: ''
    };

    $scope.usersList = [];

    userResource.query(function (data) {
        $scope.usersList = [];
        angular.forEach(data, function (userData) {
            $scope.usersList.push(userData);
        });
    });

    $scope.selectedItem = $scope.usersList[0];

    $scope.selectedOfferts = [];

    $scope.$watchCollection('selectedOfferts', function () {
        $scope.selectedOffert = angular.copy($scope.selectedOfferts[0]);
    });

    $scope.offertsGrid = {
        data: 'usersList',
        multiSelect: false,
        selectedItems: $scope.selectedOfferts,
        enableColumnResize: false,
        filterOptions: $scope.filterOptions,
        columnDefs: [
            { field: 'City', displayName: 'Miasto', width: '50%' },
            { field: 'Heating', displayName: 'Ogrzewanie', width: '50%' }
        ]
    };

    $scope.filterCity = function (city) {
        var filterText = 'City:'+city;
        if ($scope.filterOptions.filterText === '') {
            $scope.filterOptions.filterText = filterText;
        }
        else if ($scope.filterOptions.filterText === filterText) {
            $scope.filterOptions.filterText = '';
        }
    };

    var init = function () {

    }

    init();
});