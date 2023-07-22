"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.InternationalTaxStrategy = exports.NationalTaxStrategy = exports.TaxStrategy = void 0;
class TaxStrategy {
    apply_tax(price) {
        return price * (1 + this.iss + this.import_tax);
    }
    return_tax() {
        return this.iss + this.import_tax;
    }
}
exports.TaxStrategy = TaxStrategy;
class NationalTaxStrategy extends TaxStrategy {
    constructor() {
        super(...arguments);
        this.iss = 0.05;
        this.import_tax = 0.0;
    }
}
exports.NationalTaxStrategy = NationalTaxStrategy;
class InternationalTaxStrategy extends TaxStrategy {
    constructor() {
        super(...arguments);
        this.iss = 0.05;
        this.import_tax = 0.05;
    }
}
exports.InternationalTaxStrategy = InternationalTaxStrategy;
//# sourceMappingURL=index.js.map