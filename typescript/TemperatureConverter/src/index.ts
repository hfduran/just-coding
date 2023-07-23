import converter_factory from './initialize';

// Exemplos

// #1
const converter1 = converter_factory.get_converter('Celsius_Fahrenheit');
console.log(converter1.convert(37));

// #2
const converter2 = converter_factory.get_converter('Celsius_Kelvin');
console.log(converter2.convert(20));

//#2
const converter3 = converter_factory.get_converter('Kelvin_Fahrenheit');
console.log(converter3.convert(300));
