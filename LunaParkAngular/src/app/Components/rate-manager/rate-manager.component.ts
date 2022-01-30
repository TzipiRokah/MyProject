import { Component, OnInit } from '@angular/core';
import { AttractionService } from 'src/app/Services/attraction.service';
import { RateService } from 'src/app/Services/rate.service';

@Component({
  selector: 'app-rate-manager',
  templateUrl: './rate-manager.component.html',
  styleUrls: ['./rate-manager.component.css']
})
export class RateManagerComponent implements OnInit {


  RateManList:number[];

  OnClickView:boolean=false;

  constructor(private RateSer:RateService, private AttractionSer:AttractionService) { }

  ngOnInit() {
    
  }

  AllRates(AttractionId:number)
  {
    this.OnClickView=true;
    let i:number;
    this.RateManList=[0,0,0,0,0];
    this.RateSer.GetRatesByLevelId(AttractionId).subscribe(myData=>{this.RateSer.RateList=myData;

    for(i=0;i<this.RateSer.RateList.length;i++)
    {
      this.RateManList[this.RateSer.RateList[i].RateLevel-1]++;
    }
    },
    myErr=>alert(myErr.message))
  }
}
