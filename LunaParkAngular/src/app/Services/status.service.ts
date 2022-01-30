import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from '../Classes/status';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  BASEURL="http://localhost:50610/LunaPark/Status/"

  StatusList:Array<Status>
  constructor(private http:HttpClient) { }

  GetAllStatus():Observable<Array<Status>>
  {
    return this.http.get<Array<Status>>(this.BASEURL+"GetAll");
  }
}
