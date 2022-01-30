import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rate } from '../Classes/rate';

@Injectable({
  providedIn: 'root'
})
export class RateService {

  RateList:Array<Rate>

  BASEURL="http://localhost:50610/LunaPark/Rate/"

  constructor(private http:HttpClient) { }

  GetAllRates():Observable<Array<Rate>>
  {
    return this.http.get<Array<Rate>>(this.BASEURL+"GetAll");
  }

  GetRatesByLevelId(AttractionId:number):Observable<Array<Rate>>
  {
    return this.http.get<Array<Rate>>(this.BASEURL+"GetRatesByLevelId/"+AttractionId);
  }

  AddRate(rate:Rate):Observable<Array<Rate>>
  {
    return this.http.post<Array<Rate>>(this.BASEURL+"AddRate",rate);
  }

}
