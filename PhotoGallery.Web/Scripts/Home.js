var home;
(function (home) {
    var photo = (function () {
        function photo() {
        }
        return photo;
    })();
    var gallery = (function () {
        function gallery() {
        }
        return gallery;
    })();
    var photoGallery = (function () {
        function photoGallery($http) {
            this.http = $http;
            this.url = "/home/galleries";
            this.getPhotos();
            this.currentPhoto = this.galleries[0].galleryPhoto[0] || { photoName: '', photoType: '', photoPath: '', photoDiscription: '' };
            this.photoStyle = {};
        }
        photoGallery.prototype.getPhotos = function () {
            var _this = this;
            var p = this.http.get(this.url);
            p.then(function (data) { _this.galleries = data.data; });
        };
        photoGallery.prototype.setGallery = function (index) {
            this.currentGallery = this.galleries[index];
        };
        photoGallery.prototype.setPhoto = function (index) {
            this.currentPhoto = this.currentGallery.galleryPhotos[index];
            this.photoStyle = { background: 'url(' + this.currentPhoto.photoPath + ')' };
        };
        return photoGallery;
    })();
    homeApp.controller("GalleryCtrl", ['$http', photoGallery]);
})(home || (home = {}));
//# sourceMappingURL=Home.js.map