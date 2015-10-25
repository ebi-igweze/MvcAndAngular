module photoGallery.account {
    class register {
        private registerModel = {}
        private http: any;
        private url: string;
        private passwordNotMatch: boolean;
        private invalidPassword: boolean;
        private window: any;
        private location: angular.ILocationService;

        constructor($http: any, $window: any, $location: angular.ILocationService) {
            this.invalidPassword = false;
            this.passwordNotMatch = false;
            this.http = $http;
            this.url = "/account/register"
            this.window = $window;
            this.window = $location;
        }

       private registerAction(model: any, forminvalid: boolean): void {
            if (!forminvalid) {
                var promise = this.http.post(this.url,model);
                promise.then((data) => {
                    //this.window.location.href = "";
                    this.location.path("/Account/Login");
                });
           }
            // toast "ensure that all the fields are valid before submiting"
        }

        private checkPassword(pass1: string, pass2: string): void {
            if (pass1 === pass2) {
                this.passwordNotMatch = false;
            } else {
                this.passwordNotMatch = true;
            }
        }
    }

    class login {
        private http: any;
        private textRequired: boolean;
        private url: string;

        constructor($http: any) {
            this.http = $http;
            this.textRequired = false;
            this.url = "/account/login"
        }

        private loginModel = {};

        private loginAction(model: any, forminvalid: any): void {
            
            if (!forminvalid) {
                this.http.post(this.url, model);
                return;
            }
            this.textRequired = true;
        }
    }
    accountApp.controller("LoginCtrl", ["$http", login])
        .controller("RegisterCtrl", ["$http", register])
}