var accountApp = angular.module("AccountModule", []);
accountApp.factory("ValidatorFactory", function () {
    return new validation.validator();
});
var homeApp = angular.module("PhotoGalleryModule", ['ngRoute']);
homeApp.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/galleries', {
            templateUrl: 'Templates/galleries.html',
            controller: 'GalleryCtrl',
            controllerAs: 'ctrl'
        })
            .when('/galleries/gallery', {
            templateUrl: 'Templates/gallery.html',
            controller: 'GalleryCtrl',
            controllerAs: 'ctrl',
        })
            .when('galleries/gallery', {
            templateUrl: 'Templates/photo.html',
            controller: 'GalleryCtrl',
            controllerAs: 'ctrl'
        })
            .otherwise('/galleries');
    }]);
//# sourceMappingURL=App.js.map