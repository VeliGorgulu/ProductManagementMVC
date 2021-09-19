var ProductManagementMVCApp = angular.module('ProductManagementMVCApp', ['ngRoute', 'ui.bootstrap']);

ProductManagementMVCApp.controller('LandingPageController', LandingPageController);
ProductManagementMVCApp.controller('LoginController', LoginController);
ProductManagementMVCApp.controller('RegisterController', RegisterController);
ProductManagementMVCApp.controller('ProductController', RegisterController);

ProductManagementMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
ProductManagementMVCApp.factory('LoginFactory', LoginFactory);
ProductManagementMVCApp.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($routeProvider, $httpProvider/*, $locationprovider*/) {

    /*$locationprovider.hashprefix('').html5mode(true);*/

    $routeProvider.
        when('/product', {
            templateUrl: 'routes/product',
            controller: ProductController
        })
        .when('/login', {
            templateUrl: '/Account/Login',
            controller: LoginController
        })
        .when('/register', {
            templateUrl: '/Account/Register',
            controller: RegisterController
        })
        .otherwise({
            redirectTo: '/product',
            controller: ProductController
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'/*, '$locationProvider'*/];

ProductManagementMVCApp.config(configFunction);