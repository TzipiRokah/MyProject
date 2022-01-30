import { Component, OnInit } from '@angular/core';
import { MessageService } from 'src/app/Services/message.service';


@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {

  constructor(private MessageSer:MessageService) { }

  ngOnInit() {
    this.MessageSer.GetAllMessages().subscribe(
      myData=>{this.MessageSer.MessageList=myData; 
        this.MessageSer.MessageList.reverse()},
      myErr=>alert(myErr.message))
  }

}
