export declare abstract class TaxStrategy {
    protected abstract iss: number;
    protected abstract import_tax: number;
    apply_tax(price: number): number;
    return_tax(): number;
}
export declare class NationalTaxStrategy extends TaxStrategy {
    protected iss: number;
    protected import_tax: number;
}
export declare class InternationalTaxStrategy extends TaxStrategy {
    protected iss: number;
    protected import_tax: number;
}
