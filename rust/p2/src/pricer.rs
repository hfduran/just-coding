use crate::strategies::discount_strategy::DiscountStrategy;

pub struct PriceContext {
    discount_strategy: DiscountStrategy,
}

impl PriceContext {
    pub fn new(discount_strategy: DiscountStrategy) -> Self {
        Self { discount_strategy }
    }

    pub fn calculate_price(&self, price: &f32) -> f32 {
        (self.discount_strategy)(&price)
    }
}