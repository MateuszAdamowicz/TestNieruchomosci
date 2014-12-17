//angular.module('main')
//    .controller('FlatController', ['$scope', function ($scope) {
//    }]);

appRoot.controller('FlatController', function ($scope, $location, $resource) {

    var userResource = $resource('/api/offertsapi/getflats', {}, {});
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
            { field: 'Heating', displayName: 'Ogrzewanie', width: '50%' }
        ]
    };

    var init = function () {

    }

    init();
});