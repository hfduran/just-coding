export abstract class DiscountStrategy {
  protected abstract discount: number;
  apply_discount(price: number): number {
    return price * (1 - this.discount);
  }
  return_discount(): number {
    return this.discount;
  }
}

export class PoliStudentDiscountStrategy extends DiscountStrategy {
  discount = 0.7;
}

export class AssociateStudentDiscountStrategy extends DiscountStrategy {
  discount = 0.7;
}

export class USPStudentDiscountStrategy extends DiscountStrategy {
  discount = 0.6;
}

export class StudentDiscountStrategy extends DiscountStrategy {
  discount = 0.5;
}

export class DefaultDiscountStrategy extends DiscountStrategy {
  discount = 0.0;
}
