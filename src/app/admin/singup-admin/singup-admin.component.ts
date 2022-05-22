import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms'
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { UserModel } from '../../models/UserModel';


@Component({
  selector: 'app-singup-admin',
  templateUrl: './singup-admin.component.html',
  styleUrls: ['./singup-admin.component.css']
})
export class SingupAdminComponent implements OnInit {

  public signUpForm !: FormGroup;
  public signupObj = new UserModel();
 
  constructor(private fb :FormBuilder, private http : HttpClient,private router : Router,private auth:AuthService) { }

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      userName:["", Validators.required],
      firstname:["",Validators.required],
      lastname:["",Validators.required],
      email:["",Validators.compose([Validators.required,Validators.email])],
      password:["",Validators.required],
      mobile:["",Validators.required],
      rol:["Admin",Validators.required]
    })
  }

  signUp(){
    this.signupObj.UserName = this.signUpForm.value.userName;
    this.signupObj.FirstName = this.signUpForm.value.firstname;
    this.signupObj.LastName = this.signUpForm.value.lastname;
    this.signupObj.Email = this.signUpForm.value.email;
    this.signupObj.Mobile = this.signUpForm.value.mobile;
    this.signupObj.Password = this.signUpForm.value.password;
    this.signupObj.Role = this.signUpForm.value.rol;
    this.auth.register(this.signupObj)
    .subscribe(res=>{
      //alert(res.message);
      this.signUpForm.reset();
      this.router.navigate(['/dashboard-Admin'])
    })
  }
 
}
