export abstract class TaxStrategy {
  protected abstract iss: number;
  protected abstract import_tax: number;

  apply_tax(price: number): number {
    return price * (1 + this.iss + this.import_tax);
  }

  return_tax(): number {
    return this.iss + this.import_tax;
  }
}

export class NationalTaxStrategy extends TaxStrategy {
  protected iss = 0.05;
  protected import_tax = 0.0;
}

export class InternationalTaxStrategy extends TaxStrategy {
  protected iss = 0.05;
  protected import_tax = 0.05;
}
