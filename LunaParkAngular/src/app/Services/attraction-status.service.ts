import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AttractionStatus } from '../Classes/attraction-status';

@Injectable({
  providedIn: 'root'
})
export class AttractionStatusService {

  BASEURL:string="http://localhost:50610/LunaPark/AttractionStatus/"

  AttractionStatusList:Array<AttractionStatus>

  constructor(private http:HttpClient) { }

  GetAllAttractionStatus():Observable<Array<AttractionStatus>>
  {
    return this.http.get<Array<AttractionStatus>>(this.BASEURL+"GetAll")
  }

  UpdateAtrractionStatus(a:AttractionStatus):Observable<Array<AttractionStatus>>
  {
    return this.http.put<Array<AttractionStatus>>(this.BASEURL+"UpdateAttractionStatus/"+a.AttractionStatusId,a)
  }
}
