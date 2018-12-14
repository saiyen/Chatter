import { Injectable } from '@angular/core';
import { Message } from '../../e2e/app/message';
import { HttpClient } from '../../node_modules/@angular/common/http';
import { BehaviorSubject } from '../../node_modules/rxjs';

@Injectable({
  providedIn: 'root'
})

export class MessageService {

  private _messages: BehaviorSubject<Message[]> = new BehaviorSubject<Message[]>([]);

  constructor(private http: HttpClient) { }

  getMessages() {
    return this._messages.asObservable();
  }

  loadMessages() {
    this.http.get<Message[]>('https://localhost:44359/api/message/GetMessagesForMainChat').subscribe(response => {
      this._messages.next(response);
    });
  }
}
