pub type DiscountStrategy = fn(price: &f32) -> f32;

pub fn poli_student_discount_strategy(price: &f32) -> f32 {
    let discount = 0.7;
    return (1.0 - discount) * price;
}

pub fn associate_student_discount_strategy(price: &f32) -> f32 {
    let discount = 0.7;
    return (1.0 - discount) * price;
}

pub fn usp_student_discount_strategy(price: &f32) -> f32 {
    let discount = 0.6;
    return (1.0 - discount) * price;
}

pub fn student_discount_strategy(price: &f32) -> f32 {
    let discount = 0.5;
    return (1.0 - discount) * price;
}

pub fn default_discount_strategy(price: &f32) -> f32 {
    let discount = 0.0;
    return (1.0 - discount) * price;
}
