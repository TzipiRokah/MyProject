import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Classes/user';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  UserList:Array<User>;
  u:User;
  CheckUser:boolean;
  Manager:boolean=false
  Sadran:boolean=false
  Operator:boolean=false

  constructor(private http:HttpClient, private router:Router) { }

  BASEURL="http://localhost:50610/LunaPark/Users/"

  GetUserByNameAndPassword(name:string,password:string):Observable<User>
  {
    return this.http.get<User>(this.BASEURL+"GetUserByNameAndPassword/"+name+"/"+password);
  }

  AddUser(u:User):Observable<Array<User>>
  {
    return this.http.post<Array<User>>(this.BASEURL+"AddUser",u);
  }

  IfUserIsNull()
  {
    if(this.u==null)
    this.router.navigate(['/']);
  }
}
