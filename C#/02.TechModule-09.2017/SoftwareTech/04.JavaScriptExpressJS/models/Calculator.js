function Calculator(leftOperand, operator, rightOperand) {
    this.leftOperand = leftOperand;
    this.operator = operator;
    this.rightOperand = rightOperand;

    this.calculateResult = function () {
        let result = 0;

        switch (this.operator) {
            case '+':
                result = this.leftOperand + this.rightOperand;
                break;
            case '-':
                result = this.leftOperand - this.rightOperand;
                break;
            case '*':
                result = this.leftOperand * this.rightOperand;
                break;
            case '/':
                result = this.leftOperand / this.rightOperand;
                break;
            case '^':
                result = Math.pow(this.leftOperand, this.rightOperand);
                break;
            case 'pitagor':
                result = Math.sqrt(this.leftOperand * this.leftOperand + this.rightOperand * this.rightOperand);
                break;
        }

        return result;
    }
}

module.exports = Calculator;