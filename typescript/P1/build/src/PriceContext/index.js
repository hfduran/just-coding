"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PriceContext = void 0;
class PriceContext {
    constructor(discount_strategy, tax_strategy) {
        this.discount_strategy = discount_strategy;
        this.tax_strategy = tax_strategy;
    }
    set_discount_strategy(discount_strategy) {
        this.discount_strategy = discount_strategy;
    }
    set_tax_strategy(tax_strategy) {
        this.tax_strategy = tax_strategy;
    }
    calculate_price(price) {
        const taxed_price = this.tax_strategy.apply_tax(price);
        const final_price = this.discount_strategy.apply_discount(taxed_price);
        return final_price;
    }
}
exports.PriceContext = PriceContext;
//# sourceMappingURL=index.js.map