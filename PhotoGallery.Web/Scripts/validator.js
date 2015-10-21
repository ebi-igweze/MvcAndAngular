var validation;
(function (validation) {
    var keyboard = (function () {
        function keyboard() {
        }
        // numbers-> between 0 and 9
        keyboard.prototype.numbers = function (val) {
            var bools = (val > 47 && val < 58);
            return bools;
        };
        // letters-> a - z and A - Z
        keyboard.prototype.text = function (val) {
            return ((val > 64 && val < 90) || (val > 96 && val < 123));
        };
        // punctuations-> , . ' "
        keyboard.prototype.addressPunctuation = function (val) {
            switch (val) {
                case 46:
                case 44:
                case 39:
                case 34:
                    return true;
            }
            return false;
        };
        // punctuation-> @ _ - .
        keyboard.prototype.emailPunctuation = function (val) {
            switch (val) {
                case 95: // _
                case 64: // @
                case 46: // .
                case 45:
                    return true;
            }
            return false;
        };
        // special characters ! @ # $ % ^ & * ( ) + = ...more
        keyboard.prototype.specialCharacter = function (val) {
            if ((val > 34 && val < 39) || (val > 39 && val < 44) || (val > 57 && val < 65) || (val === 33 || val === 47 || val === 91 || val === 93 || val === 94 || val === 96) || (val > 122 && val < 127)) {
                return true;
            }
            return false;
        };
        return keyboard;
    })();
    validation.keyboard = keyboard;
    var validator = (function () {
        function validator() {
            this.keyBoard = new validation.keyboard();
        }
        // allows only text
        validator.prototype.validateText = function (event) {
            var value = event.which;
            return this.keyBoard.text(value);
        };
        // validates numbers with possible regular expression
        validator.prototype.validateNumber = function (event) {
            var value = event.which;
            return this.keyBoard.numbers(value);
        };
        // allow only text and numbers
        validator.prototype.validateTextAndNumbers = function (event) {
            var value = event.which;
            return (this.keyBoard.numbers(value) || this.keyBoard.text(value));
        };
        // allows only email input
        validator.prototype.validateEmail = function (event) {
            var value = event.which;
            return (this.validateTextAndNumbers(event) || this.keyBoard.emailPunctuation(value));
        };
        return validator;
    })();
    validation.validator = validator;
})(validation || (validation = {}));
//# sourceMappingURL=validator.js.map