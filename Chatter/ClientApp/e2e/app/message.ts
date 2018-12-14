import { User } from "./user";
import { Deserializable } from "./deserializable";

export class Message implements Deserializable {
  id: number;
  content: string;
  sender: User;
    messages: any;

  deserialize(input: any): this {
    Object.assign(this, input);
    this.sender = new User().deserialize(input.sender);
    return this;
  }
}
