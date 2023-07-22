import { DiscountStrategy } from '../DiscountStrategy';
import { TaxStrategy } from '../TaxStrategy';
export declare class PriceContext {
    private discount_strategy;
    private tax_strategy;
    constructor(discount_strategy: DiscountStrategy, tax_strategy: TaxStrategy);
    set_discount_strategy(discount_strategy: DiscountStrategy): void;
    set_tax_strategy(tax_strategy: TaxStrategy): void;
    calculate_price(price: number): number;
}
