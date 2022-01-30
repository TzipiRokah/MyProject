import { Component, OnInit } from '@angular/core';
import { AttractionService } from 'src/app/Services/attraction.service';
import { Attraction } from 'src/app/Classes/attraction';
import { UserService } from 'src/app/Services/user.service';
import { QueuePerUserService } from 'src/app/Services/queue-per-user.service';
import { QueuesService } from 'src/app/Services/queues.service';
import { Queues } from 'src/app/Classes/queues';

@Component({
  selector: 'app-choose-attraction',
  templateUrl: './choose-attraction.component.html',
  styleUrls: ['./choose-attraction.component.css']
})
export class ChooseAttractionComponent implements OnInit {

  QueuesList:Array<Queues>=[];

  constructor(private AttractionSer:AttractionService, private UserSer:UserService,
    private QueuePerUserSer:QueuePerUserService, private QueuesSer:QueuesService) { }

  ngOnInit() {
    debugger
    this.UserSer.IfUserIsNull();
    this.QueuePerUserSer.GetByUserId(this.UserSer.u.UserId).subscribe(
      myData=>{this.QueuePerUserSer.QueuePerUserList=myData;
        let i:number
        for(i=0;i<this.QueuePerUserSer.QueuePerUserList.length;i++)
        {
          this.QueuesSer.GetById(this.QueuePerUserSer.QueuePerUserList[i].QueueId).subscribe(
            myData=>{this.QueuesSer.Queue=myData;
                    this.QueuesList.push(myData)},
            myErr=>alert(myErr.message))
        }},
      myErr=>alert(myErr.message))
    

  }

  AddToRoute(attraction:Attraction)
  {
    this.AttractionSer.Route.push(attraction);
  }

}
