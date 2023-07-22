import {
  DefaultDiscountStrategy,
  AssociateStudentDiscountStrategy,
  PoliStudentDiscountStrategy,
  StudentDiscountStrategy,
  USPStudentDiscountStrategy,
} from './DiscountStrategy';
import {PriceContext} from './PriceContext';

import {NationalTaxStrategy, InternationalTaxStrategy} from './TaxStrategy';

const price_context = new PriceContext(
  new DefaultDiscountStrategy(),
  new NationalTaxStrategy()
);

// Examples:

// #1
console.log(price_context.calculate_price(40.0));

// #2
price_context.set_discount_strategy(new PoliStudentDiscountStrategy());
price_context.set_tax_strategy(new InternationalTaxStrategy());
console.log(price_context.calculate_price(100.0));

// #3
price_context.set_discount_strategy(new USPStudentDiscountStrategy());
console.log(price_context.calculate_price(34.6));
