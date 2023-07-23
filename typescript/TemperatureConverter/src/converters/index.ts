export interface Converter {
  convert(value: number): number;
  clone(): Converter;
}

export class CFConverter implements Converter {
  convert(value: number): number {
    return (value * 9) / 5 + 32;
  }
  clone(): Converter {
    return new CFConverter();
  }
}

export class CKConverter implements Converter {
  convert(value: number): number {
    return value + 273.15;
  }
  clone(): Converter {
    return new CKConverter();
  }
}

export class FCConverter implements Converter {
  convert(value: number): number {
    return ((value - 32) * 5) / 9;
  }
  clone(): Converter {
    return new FCConverter();
  }
}

export class FKConverter implements Converter {
  convert(value: number): number {
    return ((value - 32) * 5) / 9 + 273.15;
  }
  clone(): Converter {
    return new FKConverter();
  }
}

export class KCConverter implements Converter {
  convert(value: number): number {
    return value - 273.15;
  }
  clone(): Converter {
    return new KCConverter();
  }
}

export class KFConverter implements Converter {
  convert(value: number): number {
    return ((value - 273.15) * 9) / 5 + 32;
  }
  clone(): Converter {
    return new KFConverter();
  }
}
