"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const DiscountStrategy_1 = require("./DiscountStrategy");
const PriceContext_1 = require("./PriceContext");
const TaxStrategy_1 = require("./TaxStrategy");
const price_context = new PriceContext_1.PriceContext(new DiscountStrategy_1.DefaultDiscountStrategy(), new TaxStrategy_1.NationalTaxStrategy());
// Examples:
// #1
console.log(price_context.calculate_price(40.0));
// #2
price_context.set_discount_strategy(new DiscountStrategy_1.PoliStudentDiscountStrategy());
price_context.set_tax_strategy(new TaxStrategy_1.InternationalTaxStrategy());
console.log(price_context.calculate_price(100.0));
// #3
price_context.set_discount_strategy(new DiscountStrategy_1.USPStudentDiscountStrategy());
console.log(price_context.calculate_price(34.6));
//# sourceMappingURL=index.js.map