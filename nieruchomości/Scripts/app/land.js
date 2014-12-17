//angular.module('main')
//    .controller('LandController', ['$scope', function ($scope) {
//    }]);

appRoot.controller('LandController', function ($scope, $location, $resource) {

    var userResource = $resource('/api/offertsapi/getlands', {}, {});
    $scope.usersList = [];

    userResource.query(function (data) {
        $scope.usersList = [];
        angular.forEach(data, function (userData) {
            $scope.usersList.push(userData);
        });
    });

    $scope.selectedOfferts = [];

    $scope.$watchCollection('selectedOfferts', function () {
        $scope.selectedOffert = angular.copy($scope.selectedOfferts[0]);
    });

    $scope.offertsGrid = {
        data: 'usersList',
        multiSelect: false,
        selectedItems: $scope.selectedOfferts,
        enableColumnResize: false,
        columnDefs: [
            { field: 'City', displayName: 'Miasto', width: '50%' },
            { field: 'Area', displayName: 'Powierzchnia', width: '50%' }
        ]
    };

    var init = function () {

    }

    init();
});