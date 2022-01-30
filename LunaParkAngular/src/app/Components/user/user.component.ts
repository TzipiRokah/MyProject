import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/Services/user.service';
import { Router } from '@angular/router';
import { connect } from 'net';
import { User } from 'src/app/Classes/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  name:string
  
  password:string

  constructor(private UserSer:UserService,private router:Router) { }

  ngOnInit() {
  }

  WhichUserAccess(Access:number)
  {
    if(Access==1)
    {
    this.router.navigate(['/Manager']);
    this.UserSer.Manager=true;
    this.UserSer.Sadran=true;
    this.UserSer.Operator=true;
    }
    else
    if(Access==2)
    {
    this.router.navigate(['/Sadran']);
    this.UserSer.Sadran=true;
    }
    else
    if(Access==3)
    {
    this.router.navigate(['/Operator']);
    this.UserSer.Operator=true;
    }
    else
    this.router.navigate(['/']);
  }
  
  Connect()
  {
    this.UserSer.Manager=false
    this.UserSer.Sadran=false
    this.UserSer.Operator=false
    this.UserSer.GetUserByNameAndPassword(this.name,this.password).subscribe(
      myData=>{this.UserSer.u=myData;
      this.UserSer.CheckUser=true;
      this.WhichUserAccess(this.UserSer.u.UserAccessLevel);},
      myErr=>alert(myErr.message));
  }

  ErrUser()
  {
    alert("משתמש לא קיים, צור חשבון חדש");
  }
}
