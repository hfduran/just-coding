import {DiscountStrategy} from '../DiscountStrategy';
import {TaxStrategy} from '../TaxStrategy';

export class PriceContext {
  private discount_strategy: DiscountStrategy;
  private tax_strategy: TaxStrategy;

  constructor(discount_strategy: DiscountStrategy, tax_strategy: TaxStrategy) {
    this.discount_strategy = discount_strategy;
    this.tax_strategy = tax_strategy;
  }

  public set_discount_strategy(discount_strategy: DiscountStrategy) {
    this.discount_strategy = discount_strategy;
  }

  public set_tax_strategy(tax_strategy: TaxStrategy) {
    this.tax_strategy = tax_strategy;
  }

  public calculate_price(price: number) {
    const taxed_price = this.tax_strategy.apply_tax(price);
    const final_price = this.discount_strategy.apply_discount(taxed_price);
    return final_price;
  }
}
