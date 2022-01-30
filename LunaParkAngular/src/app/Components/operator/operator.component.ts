import { Component, OnInit } from '@angular/core';
import { Attraction } from 'src/app/Classes/attraction';
import { AttractionStatus } from 'src/app/Classes/attraction-status';
import { Message } from 'src/app/Classes/message';
import { Queues } from 'src/app/Classes/queues';
import { AttractionStatusService } from 'src/app/Services/attraction-status.service';
import { AttractionService } from 'src/app/Services/attraction.service';
import { MessageService } from 'src/app/Services/message.service';
import { QueuePerUserService } from 'src/app/Services/queue-per-user.service';
import { QueuesService } from 'src/app/Services/queues.service';
import { UserService } from 'src/app/Services/user.service';
import { UpdateMaxPeople } from 'src/TempClasses/update-max-people';

@Component({
  selector: 'app-operator',
  templateUrl: './operator.component.html',
  styleUrls: ['./operator.component.css']
})
export class OperatorComponent implements OnInit {

  selectedAtr: Attraction;

  displayDialog: boolean;

  TimeNow:Date;
  TimeDetails:Date;
  TimeLate:Date;

  Broken:boolean=true;
  Late:boolean=true;

  constructor(private AttractionSer: AttractionService, private QueuesSer:QueuesService, private MessageSer:MessageService,
    private UserSer:UserService, private QueuePerUserSer:QueuePerUserService, private AttractionStatusSer:AttractionStatusService) { }

  ngOnInit() {
    this.UserSer.IfUserIsNull();
  }

  
  SelectedAtr(event: Event, selectedAtr: Attraction) {
    this.selectedAtr = selectedAtr;
    this.displayDialog = true;
    event.preventDefault();
  }

onDialogHide() {
    this.selectedAtr = null;
}

Submit(Details:string,AttractionId:number)
{
  this.MessageSer.MessageCountMan+=1;
  let m:Message=new Message(1,this.TimeDetails,Details,null,AttractionId,this.UserSer.u.UserId,this.UserSer.u.UserAccessLevel);
  this.MessageSer.AddMessage(m).subscribe(myData=>{this.MessageSer.MessageList=myData;this.IsBroken();this.IsLate()},myErr=>alert(myErr.message))
}

BrokenSubmit(Details:string, AttractionId:number)
{
  this.Submit(Details,AttractionId);
  let u:UpdateMaxPeople=new UpdateMaxPeople(this.TimeDetails,AttractionId,null);
  this.QueuePerUserSer.MalfunctionQueues(u).subscribe(myData=>this.QueuePerUserSer.QueuePerUserList=myData,myErr=>alert(myErr.message));
  let a:AttractionStatus=new AttractionStatus(1,2,AttractionId,this.TimeDetails,this.UserSer.u.UserId);
  this.AttractionStatusSer.UpdateAtrractionStatus(a).subscribe(myData=>this.AttractionStatusSer.AttractionStatusList=myData, myErr=>alert(myErr.message));
}

LateSubmit(Details:string, AttractionId:number)
{
  debugger
  this.Submit(Details,AttractionId);
  let u:UpdateMaxPeople=new UpdateMaxPeople(this.TimeLate,AttractionId,null);
  this.QueuePerUserSer.DelayQueue(u).subscribe(myData=>{this.QueuePerUserSer.QueuePerUserList=myData;this.DelayMessageModal()},myErr=>alert(myErr.message));;
}

ChangeMaxPeople(a:Attraction,maxPeople:number)
{
  this.TimeNow=new Date()
  a.AttractionMaxPeople=maxPeople;
  this.QueuesSer.UpdateMaxPeople(this.TimeNow,a.AttractionId,a.AttractionMaxPeople).subscribe(
    myData=>{this.QueuesSer.QueuesList=myData;   
      this.AttractionSer.UpdateAttraction(a.AttractionId,a).subscribe(myData=>this.AttractionSer.Attractions=myData,myErr=>alert(myErr.message))
    },myErr=>alert(myErr.message))

}

IsBroken()
{
  this.Broken=!this.Broken;
  this.Late=true;
}

IsLate()
{
  this.Late=!this.Late;
  this.Broken=true;
}

DelayMessageModal()
{

}
}
