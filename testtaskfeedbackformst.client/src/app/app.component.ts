import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

class Message {
  name: string;
  phone: string;
  email: string;
  topic: string;
  messageText: string;
  constructor(name: string,
    phone: string,
    email: string,
    topic: string,
    messageText: string) {
    this.name = name;
    this.phone = phone;
    this.email = email;
    this.topic = topic;
    this.messageText = messageText;
  }
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  public message: Message = new Message("", "", "", "", "");

  public receivedMessage: Message = new Message("", "", "", "", "");
  done: boolean = false;
  public topics: string[] = [];
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getTopics();
  }

  checkString(str: string): boolean {
    return str != null && str.trim() != "";
  }
  checkMessage(message: Message): boolean {
    return this.checkString(message.name) && this.checkString(message.phone)
      && this.checkString(message.email) && this.checkString(message.topic)
      && this.checkString(message.messageText);
  }

  //printMessage(message: Message): void {

  //  if (!this.checkMessage(message))
  //    return;
  //  this.receivedMessage = message;
  //}
  postMessage(message: Message) {

    message.phone = '8' + message.phone;
    
    return this.http.post("https://localhost:7211/api/Message/CreateMessage", message).subscribe({
      next: (data: any) => {
        this.receivedMessage = new Message(data.name, data.phone,
          data.email, data.topic, data.messageText); this.done = true;
      },
      error: error => console.log(error)
    });

  }
  getTopics() {
    this.http.get<string[]>("api/DirectoryOfMessageTopic/Get").subscribe(
      (result) => {
        this.topics = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  
  title = 'testtaskfeedbackformst.client';
}


