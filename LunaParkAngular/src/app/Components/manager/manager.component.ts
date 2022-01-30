import { Component, OnInit } from '@angular/core';
import { MessageService } from 'src/app/Services/message.service';
import { UserService } from 'src/app/Services/user.service';


@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  IfMassageMan:boolean;

  constructor(private UserSer:UserService, private MessageSer:MessageService) { }

  OnClickViewList:boolean[]=[true,false,false,false,false]

  ngOnInit() {

    this.UserSer.IfUserIsNull();
    if(this.MessageSer.MessageCountMan>0)
    this.IfMassageMan=true;
  }

  OnClickView()
  {
    this.OnClickViewList=[false,false,false,false,false]
  }

  MassageManager()
  {
    this.MessageSer.MessageCountMan=0
    this.IfMassageMan=false;
  }


  
}
