var galleryService = (function () {
    
    function galleryService($http) {
        this.http = $http;
        this.galleries = [];
        this.url = "/home/galleries";
        this.allGalleries();
    }
    galleryService.prototype.allGalleries = function (){
        return this.http.get(this.url);
    }

    galleryService.prototype.getGalleries = function () { return this.galleries; }

    galleryService.prototype.getGalleryById = function (galleryId) { return this.galleries[galleryId]; }

    galleryService.prototype.getPhotoById = function (galleryId, photoId) {
        return this.galleries[galleryId].GalleryPhotos[photoId];
    }

    return galleryService;
})();
homeApp.service("GalleryService", ["$http", galleryService]);