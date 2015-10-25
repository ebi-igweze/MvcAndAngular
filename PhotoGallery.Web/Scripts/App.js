var accountApp = angular.module("AccountModule", []);
accountApp.factory("ValidatorFactory", function () {
    return new validation.validator();
});
var homeApp = angular.module("PhotoGalleryModule", ['ngRoute']);
homeApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/galleries', {
            templateUrl: '/Templates/galleries.html',
            controller: 'GalleryCtrl',
            controllerAs: 'ctrl'
        })
            .when('/galleries/gallery/:galleryId', {
            templateUrl: '/Templates/gallery.html',
            controller: 'GalleryCtrl',
            controllerAs: 'ctrl',
        })
            .when('/galleries/gallery/:galleryId/photo/:photoId', {
            templateUrl: '/Templates/photo.html',
            controller: 'GalleryCtrl',
            controllerAs: 'ctrl'
        })
            .otherwise('/galleries');
        $locationProvider.html5Mode(true);
    }]);
//# sourceMappingURL=App.js.map