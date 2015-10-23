module gallery.home {
    
    class photoGallery {
        private galleries: Array<any>;
        private galleryService: any;
        private currentPhoto: any;
        private routeParams: any;
        private currentGallery: any;
        private currentGalleryIndex: any;
        constructor(GalleryService, $routeParams, $scope) {
            this.galleryService = GalleryService;
            this.routeParams = $routeParams
            this.galleries = [];
            this.getGalleries();
            this.currentGallery = {};
            this.currentPhoto = {};
            this.currentGalleryIndex = 0;
        }

        private getGalleries(): void {

            var promise = this.galleryService.allGalleries();
            promise.then( (data) => { this.galleries = data.data; this.setAll(); });
        }

        private setAll(): void {
            this.setGallery();
            this.setPhoto();
        }

        private setGallery(): void {
            this.currentGalleryIndex = (this.routeParams.galleryId - 1) || 0;
            this.currentGallery = this.galleries[this.currentGalleryIndex];
        }
        private setPhoto(): void {
            this.currentPhoto = this.currentGallery.GalleryPhotos[(this.routeParams.photoId - 1) || 0];
        }
    }
    homeApp.controller("GalleryCtrl", ['GalleryService','$routeParams', photoGallery]);
}