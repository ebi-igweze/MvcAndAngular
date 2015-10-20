module photoGallery.account {
    class register {
        private registerModel = {}
        private http: any;
        private validator: validation.validator;
        private url: string;

        private similarPassword: boolean;

        constructor(ValidatorFactory: validation.validator, $http: any) {
            this.similarPassword = true;
            this.http = $http;
            this.validator = ValidatorFactory;
            this.url = "/account/register"
        }

        private emailInput(event): boolean {
            return this.validator.validateEmail(event);
        }

        private textInput(event): boolean {
            return this.validator.validateText(event);
        }

        private passwordInput(event): boolean {
            return this.validator.validateTextAndNumbers(event);
        }

        private registerAction(model: any, forminvalid: boolean): void {
            if (!forminvalid) {
               this.http.post(this.url,model);
            }
        }

        private checkPassword(pass1: string, pass2: string): void {
            if (pass1 === pass2) {
                this.similarPassword = true;
            } else {
                this.similarPassword = false;
            }

        }
    }

    class login {
        private validator: validation.validator;
        private http: any;
        private textRequired: boolean;
        private url: string;

        constructor(ValidatorFactory: validation.validator, $http: any) {
            this.http = $http;
            this.validator = ValidatorFactory;
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
        

        private emailInput(event: any): boolean {
            return this.validator.validateEmail(event);
        }

        private passwordInput(event: any): boolean {
            return this.validator.validateTextAndNumbers(event);
        }
    }
    accountApp.controller("LoginCtrl", ["ValidatorFactory", "$http", login])
        .controller("RegisterCtrl", ["ValidatorFactory", "$http", register])
}