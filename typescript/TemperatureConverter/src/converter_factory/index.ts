import {Converter} from '../converters';

export class TemperatureConverterFactory {
  converters: {[name: string]: Converter};

  constructor() {
    this.converters = {};
  }

  register_converter(name: string, converter: Converter): void {
    this.converters[name] = converter;
  }

  get_converter(name: string): Converter {
    return this.converters[name].clone();
  }
}
