export declare abstract class DiscountStrategy {
    protected abstract discount: number;
    apply_discount(price: number): number;
    return_discount(): number;
}
export declare class PoliStudentDiscountStrategy extends DiscountStrategy {
    discount: number;
}
export declare class AssociateStudentDiscountStrategy extends DiscountStrategy {
    discount: number;
}
export declare class USPStudentDiscountStrategy extends DiscountStrategy {
    discount: number;
}
export declare class StudentDiscountStrategy extends DiscountStrategy {
    discount: number;
}
export declare class DefaultDiscountStrategy extends DiscountStrategy {
    discount: number;
}
