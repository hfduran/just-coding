import {TemperatureConverterFactory} from './converter_factory';
import {
  CFConverter,
  CKConverter,
  FCConverter,
  FKConverter,
  KCConverter,
  KFConverter,
} from './converters';

const converter_factory = new TemperatureConverterFactory();

converter_factory.register_converter('Celsius_Fahrenheit', new CFConverter());
converter_factory.register_converter('Celsius_Kelvin', new CKConverter());
converter_factory.register_converter('Fahrenheit_Celsius', new FCConverter());
converter_factory.register_converter('Fahrenheit_Kelvin', new FKConverter());
converter_factory.register_converter('Kelvin_Celsius', new KCConverter());
converter_factory.register_converter('Kelvin_Fahrenheit', new KFConverter());

export default converter_factory;
