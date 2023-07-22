"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DefaultDiscountStrategy = exports.StudentDiscountStrategy = exports.USPStudentDiscountStrategy = exports.AssociateStudentDiscountStrategy = exports.PoliStudentDiscountStrategy = exports.DiscountStrategy = void 0;
class DiscountStrategy {
    apply_discount(price) {
        return price * (1 - this.discount);
    }
    return_discount() {
        return this.discount;
    }
}
exports.DiscountStrategy = DiscountStrategy;
class PoliStudentDiscountStrategy extends DiscountStrategy {
    constructor() {
        super(...arguments);
        this.discount = 0.7;
    }
}
exports.PoliStudentDiscountStrategy = PoliStudentDiscountStrategy;
class AssociateStudentDiscountStrategy extends DiscountStrategy {
    constructor() {
        super(...arguments);
        this.discount = 0.7;
    }
}
exports.AssociateStudentDiscountStrategy = AssociateStudentDiscountStrategy;
class USPStudentDiscountStrategy extends DiscountStrategy {
    constructor() {
        super(...arguments);
        this.discount = 0.6;
    }
}
exports.USPStudentDiscountStrategy = USPStudentDiscountStrategy;
class StudentDiscountStrategy extends DiscountStrategy {
    constructor() {
        super(...arguments);
        this.discount = 0.5;
    }
}
exports.StudentDiscountStrategy = StudentDiscountStrategy;
class DefaultDiscountStrategy extends DiscountStrategy {
    constructor() {
        super(...arguments);
        this.discount = 0.0;
    }
}
exports.DefaultDiscountStrategy = DefaultDiscountStrategy;
//# sourceMappingURL=index.js.map