mod pricer;
mod strategies;

use crate::{strategies::discount_strategy::{
    default_discount_strategy, poli_student_discount_strategy,
}, pricer::PriceContext};

fn main() {
    let price = 10.0;

    let pricer = PriceContext::new(default_discount_strategy);
    println!("{}", pricer.calculate_price(&price));

    let pricer = PriceContext::new(poli_student_discount_strategy);
    println!("{}", pricer.calculate_price(&price));
}
