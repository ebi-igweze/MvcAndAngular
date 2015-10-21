var photoGallery;
(function (photoGallery) {
    var account;
    (function (account) {
        var register = (function () {
            function register(ValidatorFactory, $http) {
                this.registerModel = {};
                this.similarPassword = true;
                this.http = $http;
                this.validator = ValidatorFactory;
                this.url = "/account/register";
            }
            register.prototype.emailInput = function (event) {
                return this.validator.validateEmail(event);
            };
            register.prototype.textInput = function (event) {
                return this.validator.validateText(event);
            };
            register.prototype.passwordInput = function (event) {
                return this.validator.validateTextAndNumbers(event);
            };
            register.prototype.registerAction = function (model, forminvalid) {
                if (!forminvalid) {
                    this.http.post(this.url, model);
                }
            };
            register.prototype.checkPassword = function (pass1, pass2) {
                if (pass1 === pass2) {
                    this.similarPassword = true;
                }
                else {
                    this.similarPassword = false;
                }
            };
            return register;
        })();
        var login = (function () {
            function login(ValidatorFactory, $http) {
                this.loginModel = {};
                this.http = $http;
                this.validator = ValidatorFactory;
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
            login.prototype.emailInput = function (event) {
                return this.validator.validateEmail(event);
            };
            login.prototype.passwordInput = function (event) {
                return this.validator.validateTextAndNumbers(event);
            };
            return login;
        })();
        accountApp.controller("LoginCtrl", ["ValidatorFactory", "$http", login])
            .controller("RegisterCtrl", ["ValidatorFactory", "$http", register]);
    })(account = photoGallery.account || (photoGallery.account = {}));
})(photoGallery || (photoGallery = {}));
//# sourceMappingURL=Account.js.map