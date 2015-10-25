var photoGallery;
(function (photoGallery) {
    var account;
    (function (account) {
        var register = (function () {
            function register($http, $window, $location) {
                this.registerModel = {};
                this.invalidPassword = false;
                this.passwordNotMatch = false;
                this.http = $http;
                this.url = "/account/register";
                this.window = $window;
                this.window = $location;
            }
            register.prototype.registerAction = function (model, forminvalid) {
                var _this = this;
                if (!forminvalid) {
                    var promise = this.http.post(this.url, model);
                    promise.then(function (data) {
                        //this.window.location.href = "";
                        _this.location.path("/Account/Login");
                    });
                }
                // toast "ensure that all the fields are valid before submiting"
            };
            register.prototype.checkPassword = function (pass1, pass2) {
                if (pass1 === pass2) {
                    this.passwordNotMatch = false;
                }
                else {
                    this.passwordNotMatch = true;
                }
            };
            return register;
        })();
        var login = (function () {
            function login($http) {
                this.loginModel = {};
                this.http = $http;
                this.textRequired = false;
                this.url = "/account/login";
            }
            login.prototype.loginAction = function (model, forminvalid) {
                if (!forminvalid) {
                    this.http.post(this.url, model);
                    return;
                }
                this.textRequired = true;
            };
            return login;
        })();
        accountApp.controller("LoginCtrl", ["$http", login])
            .controller("RegisterCtrl", ["$http", register]);
    })(account = photoGallery.account || (photoGallery.account = {}));
})(photoGallery || (photoGallery = {}));
//# sourceMappingURL=Account.js.map