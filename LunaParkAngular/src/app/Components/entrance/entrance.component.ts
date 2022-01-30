import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Classes/user';
import { UserService } from 'src/app/Services/user.service';
import { from } from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserNameValidator } from 'src/app/Validators/UserNameValidator';

@Component({
  selector: 'app-entrance',
  templateUrl: './entrance.component.html',
  styleUrls: ['./entrance.component.css']
})
export class EntranceComponent implements OnInit {

  check:boolean=false;

  newUser:User=new User();

  constructor(private UserSer:UserService) { }
  
  ngOnInit() {
    
  }

  Connect()
  {
    debugger
    this.UserSer.AddUser(this.newUser).subscribe(myData=>{this.UserSer.UserList=myData; this.check=true},myErr=>alert(myErr.message));
  }
}
