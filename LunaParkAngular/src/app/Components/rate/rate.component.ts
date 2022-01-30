import { Component, OnInit } from '@angular/core';
import { ListenOptions } from 'net';
import { Rate } from 'src/app/Classes/rate';
import { AttractionService } from 'src/app/Services/attraction.service';
import { RateService } from 'src/app/Services/rate.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html',
  styleUrls: ['./rate.component.css']
})
export class RateComponent implements OnInit {

  starList: boolean[] = [true,true,true,true,true]; 
  check:boolean=false;
  constructor(private AttractionSer: AttractionService, private RateSer:RateService, private UserSer:UserService) { }

  ngOnInit() {
    this.UserSer.IfUserIsNull();
  }

  rating:number;
  
  AddRating(AttractionId:number)
  {
    debugger
    if(this.rating!=null)
    {
    let rate:Rate=new Rate(1,AttractionId,this.UserSer.u.UserId,new Date(),this.rating);
    this.RateSer.AddRate(rate).subscribe(myData=>this.RateSer.RateList=myData,myErr=>alert(myErr.message))
    }
  }

  setStar(data:any,AttractionId:number){
      this.rating=data+1;                               
      for(var i=0;i<=4;i++){  
        if(i<=data){  
          this.starList[i]=false;  
        }  
        else{  
          this.starList[i]=true;  
        }  
     } 
 }  

}
