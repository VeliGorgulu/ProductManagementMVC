var LandingPageController = function ($scope, $http, $rootScope) {
    
    $scope.models = {
        helloAngular: 'I work!'
    };
    $scope.navbarProperties = {
        isCollapsed: true
    };
    $scope.logout = function () {
        $http({

            method: 'POST',

            url: '/Account/LogOff',

        })
    }
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
LandingPageController.$inject = ['$scope', '$http', '$rootScope'];