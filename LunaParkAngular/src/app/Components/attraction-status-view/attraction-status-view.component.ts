import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/Classes/status';
import { AttractionStatusService } from 'src/app/Services/attraction-status.service';
import { StatusService } from 'src/app/Services/status.service';

@Component({
  selector: 'app-attraction-status-view',
  templateUrl: './attraction-status-view.component.html',
  styleUrls: ['./attraction-status-view.component.css']
})
export class AttractionStatusViewComponent implements OnInit {

  constructor(private AttractionStatusSer:AttractionStatusService, private StatusSer:StatusService) { }

  ngOnInit() {
    this.AttractionStatusSer.GetAllAttractionStatus().subscribe(myData=>{this.AttractionStatusSer.AttractionStatusList=myData;},myErr=>alert(myErr.message))
    this.StatusSer.GetAllStatus().subscribe(myData=>{this.StatusSer.StatusList=myData;}, myErr=>alert(myErr.message))
  }

}
