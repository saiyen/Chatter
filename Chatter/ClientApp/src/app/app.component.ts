import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { MessageService } from './message.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private messageService: MessageService) {
  }

  ngOnInit() {
    this.messageService.loadMessages();
  }
}
