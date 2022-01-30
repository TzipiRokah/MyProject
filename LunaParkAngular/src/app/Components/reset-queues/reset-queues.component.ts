import { Component, OnInit } from '@angular/core';
import { AttractionService } from 'src/app/Services/attraction.service';
import { QueuesService } from 'src/app/Services/queues.service';

@Component({
  selector: 'app-reset-queues',
  templateUrl: './reset-queues.component.html',
  styleUrls: ['./reset-queues.component.css']
})
export class ResetQueuesComponent implements OnInit {

  IsReset:boolean=false;

  open:Date;
  
  close:Date;

  constructor(private AttractionSer:AttractionService,private QueuesSer:QueuesService) { }

  ngOnInit() {
    this.open=new Date();
    this.close=new Date();
  }

  ChangeClose(time:number)
  {
    this.AttractionSer.ClosingdHour=time;
  }

  FillHoursForDay(openHour:Date,closeHour:Date)
  {
    debugger
    this.QueuesSer.ResetQueues(openHour,closeHour).subscribe(myData=>{this.QueuesSer.QueuesList=myData;},myErr=>alert(myErr.message));
  }

  StartDay(openHour:Date,closeHour:Date)
  {
    debugger
    this.FillHoursForDay(openHour,closeHour)
  }

}
