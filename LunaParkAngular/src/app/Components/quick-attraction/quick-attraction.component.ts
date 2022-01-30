import { Component, OnInit } from '@angular/core';
import { AttractionService } from 'src/app/Services/attraction.service';
import { Attraction } from 'src/app/Classes/attraction';



@Component({
  selector: 'app-quick-attraction',
  templateUrl: './quick-attraction.component.html',
  styleUrls: ['./quick-attraction.component.css']
})
export class QuickAttractionComponent implements OnInit {

  check:boolean=false;
  count:number=0;
  newRoute:Array<Attraction>=[];
  constructor(private AttractionSer:AttractionService) { }

  ngOnInit() {
    this.AttractionSer.GetAllAttraction().subscribe(myData=>{this.AttractionSer.Attractions=myData;},myErr=>alert(myErr.message));
  }
  
  Disable()
  {
    this.check=true;
  }
  
  GetQuickWayByRate()
  {
    
    this.AttractionSer.GetQuickWayByRate();
  }

  GetQuickWayByMaxAttraction()
  {}
}
