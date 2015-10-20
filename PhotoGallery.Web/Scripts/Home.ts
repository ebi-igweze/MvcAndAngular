module home {
    class photo {
        public photoName: string;
        public photoType: string;
        public photoPath: string;
        public photoDiscription: string;
    }
    class gallery {
        public galleryName: string;
        public galleryPhoto: photo;
        public galleryDescription: string;
        public galleryPhotos: Array<photo>;
    }

    class photoGallery {
        private galleries: Array<gallery>;
        private http;
        private url;
        private currentGallery: gallery;
        private currentPhoto: photo;
        private photoStyle: any;
        constructor($http) {
            this.http = $http;
            this.url = "/home/galleries";
            this.getPhotos();
            this.currentPhoto = this.galleries[0].galleryPhoto[0] || { photoName: '', photoType: '', photoPath: '', photoDiscription: '' };
            this.photoStyle = {};
        }

        private getPhotos(): void {
            var p = this.http.get(this.url);
            p.then((data) => { this.galleries = data.data; });

        }

        private setGallery(index: number): void {
            this.currentGallery = this.galleries[index];
        }

        private setPhoto(index: number): void {
            this.currentPhoto = this.currentGallery.galleryPhotos[index];
            this.photoStyle = { background: 'url(' + this.currentPhoto.photoPath + ')' };
        }
        
    }
    homeApp.controller("GalleryCtrl", ['$http', photoGallery]);

}