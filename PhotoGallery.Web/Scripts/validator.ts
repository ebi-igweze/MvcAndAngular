module validation {

    export class keyboard {
        constructor() { }

        // numbers-> between 0 and 9
        public numbers(val: number): boolean {
            var bools = (val > 47 && val < 58);
            return bools;
        }
        // letters-> a - z and A - Z
        public text(val: number): boolean {
            return ((val > 64 && val < 90) || (val > 96 && val < 123));
        }
        // punctuations-> , . ' "
        public addressPunctuation(val: number): boolean {
            switch (val) {
                case 46:
                case 44:
                case 39:
                case 34:
                    return true;
            }
            return false;
        }
        // punctuation-> @ _ - .
        public emailPunctuation(val: number) {
            switch (val) {
                case 95: // _
                case 64: // @
                case 46: // .
                case 45: // -
                    return true;
            }
            return false;
        }
        // special characters ! @ # $ % ^ & * ( ) + = ...more
        public specialCharacter(val: number): boolean {
            if ((val > 34 && val < 39) || (val > 39 && val < 44) || (val > 57 && val < 65) || (val === 33 || val === 47 || val === 91 || val === 93 || val === 94 || val === 96) || (val > 122 && val < 127)) {
                return true
            }
            return false;
        }
    }


    export class validator {
        private keyBoard = new validation.keyboard();
		
        // allows only text
        validateText(event: any): boolean {
            var value = event.which;
            return this.keyBoard.text(value);
        }
        // validates numbers with possible regular expression
        validateNumber(event: any): boolean {
            var value = event.which;
            return this.keyBoard.numbers(value)
        }
        // allow only text and numbers
        validateTextAndNumbers(event: any): boolean {
            var value = event.which;
            return (this.keyBoard.numbers(value) || this.keyBoard.text(value));

        }	
        // allows only email input
        validateEmail(event: any): boolean {
            var value = event.which;
            return (this.validateTextAndNumbers(event) || this.keyBoard.emailPunctuation(value));
        }
    }
}