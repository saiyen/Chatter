import { Component, OnInit } from '@angular/core';
import { MessageService } from '../message.service';
import { Message } from '../../../e2e/app/message';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./css/style.css']
})
export class HomeComponent implements OnInit {
  private hubConnection: HubConnection;
  nick = '';
  message = '';
  messages: string[] = [];

  constructor(private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.nick = window.prompt('Your name:', 'John');

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44359/hubs/chat')
      .build();

    // Luister naar sendToAll event van de server
    this.hubConnection.on('sendToAll', (nick: string, receivedMessage: string) => {
      const text = `${nick}: ${receivedMessage}`;
      this.messages.push(text);
    });

    this.hubConnection.start();
  }

  public sendMessage(): void {
    this.hubConnection
      .invoke('sendToAll', this.nick, this.message)
      .catch(err => console.error(err));
  }
}
