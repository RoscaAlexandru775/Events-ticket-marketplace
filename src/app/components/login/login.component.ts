import { HttpClient } from '@angular/common/http';
import { Component, OnInit, } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms'
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/UserModel';
import { AuthService } from 'src/app/services/auth.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm !: FormGroup;
  public loginObj = new UserModel();
  constructor(private fb :FormBuilder, private http : HttpClient,private router : Router, private auth: AuthService) { }


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email:['',Validators.compose([Validators.required,Validators.email])],
      password:['',Validators.required]
    });
   localStorage.clear();
  }
  login(){

  this.loginObj.Email = this.loginForm.value.email;
  this.loginObj.Password = this.loginForm.value.password;
  this.auth.login(this.loginObj)
  .subscribe(res=>{
    alert("Login Success!");
   
    let jwt = res.accessToken

    let jwtData = jwt.split('.')[1]
    let decodedJwtJsonData = window.atob(jwtData)
    let decodedJwtData = JSON.parse(decodedJwtJsonData)

    console.log(decodedJwtData.role)
    console.log(jwt)
    if(decodedJwtData.role === "Admin" || decodedJwtData.role === "admin")
           this.router.navigate(['/dashboard-Admin']);
        else 
           this.router.navigate(['/dashboard-User']);
  
    localStorage.setItem('token',res.accessToken);
    //localStorage.setItem('role',decodedJwtData.role);
  },err=>{
    alert("soomething went wrong v2")
  })
   }

}