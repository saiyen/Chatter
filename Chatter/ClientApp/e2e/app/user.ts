import { Deserializable } from "./deserializable";

export class User implements Deserializable{
  id: number;
  firstName: string;

  deserialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
