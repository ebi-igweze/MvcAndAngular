var gallery;
(function (gallery) {
    var home;
    (function (home) {
        var photoGallery = (function () {
            function photoGallery(GalleryService, $routeParams, $scope) {
                this.galleryService = GalleryService;
                this.routeParams = $routeParams;
                this.galleries = [];
                this.getGalleries();
                this.currentGallery = {};
                this.currentPhoto = {};
                this.currentGalleryIndex = 0;
            }
            photoGallery.prototype.getGalleries = function () {
                var _this = this;
                var promise = this.galleryService.allGalleries();
                promise.then(function (data) { _this.galleries = data.data; _this.setAll(); });
            };
            photoGallery.prototype.setAll = function () {
                this.setGallery();
                this.setPhoto();
            };
            photoGallery.prototype.setGallery = function () {
                this.currentGalleryIndex = (this.routeParams.galleryId - 1) || 0;
                this.currentGallery = this.galleries[this.currentGalleryIndex];
            };
            photoGallery.prototype.setPhoto = function () {
                this.currentPhoto = this.currentGallery.GalleryPhotos[(this.routeParams.photoId - 1) || 0];
            };
            return photoGallery;
        })();
        homeApp.controller("GalleryCtrl", ['GalleryService', '$routeParams', photoGallery]);
    })(home = gallery.home || (gallery.home = {}));
})(gallery || (gallery = {}));
//# sourceMappingURL=Home.js.map