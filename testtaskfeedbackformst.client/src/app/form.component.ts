import { Component } from "@angular/core";
import { FormsModule, NgModel } from "@angular/forms";
import { Options } from "@angular/cli/src/command-builder/command-module";

class Message {
  name: string;
  phone: string;
  email: string;
  topic: string;
  message_text: string;
  constructor(name: string,
    phone: string,
    email: string,
    topic: string,
    message_text: string) {
    this.name = name;
    this.phone = phone;
    this.email = email;
    this.topic = topic;
    this.message_text = message_text;
  }
}
@Component({
  selector: "purchase-app",
  templateUrl: './app.component.html'
})
export class AppComponent {
  message: Message = new Message("", "", "", "", "");

  messageGet: Message = new Message("", "", "", "", "");

  topics: string[] = ["Другое", "Продажи"];

  checkString(str: string): boolean {
    return str != null && str.trim() != "";
  }
  checkMessage(message: Message): boolean {
    return this.checkString(message.name) && this.checkString(message.phone)
      && this.checkString(message.email) && this.checkString(message.topic)
      && this.checkString(message.message_text);
  }

  printMessage(message: Message): void {

    if (!this.checkMessage(message))
      return;
    this.messageGet = message;
  }
}
