import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms'
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { UserModel } from '../../models/UserModel';


@Component({
  selector: 'app-singup-admin',
  templateUrl: './singup-admin.component.html',
  styleUrls: ['./singup-admin.component.css']
})
export class SingupAdminComponent implements OnInit {

  public signUpForm !: FormGroup;
  //public signupObj = new UserModel();
 
  constructor(private fb :FormBuilder, private http : HttpClient,private router : Router,private api:ApiService) { }

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      userName:["", Validators.required],
      firstname:["",Validators.required],
      lastname:["",Validators.required],
      email:["",Validators.compose([Validators.required,Validators.email])],
      password:["",Validators.required],
      mobile:["",Validators.required],
      rol:["admin",Validators.required]
    })
  }

  signUp(){
     this.http.post<any>("http://localhost:3000/signupAdmin", this.signUpForm.value)
     .subscribe(res=>{
       alert("Signup Successfull");
       this.signUpForm.reset();
       this.router.navigate(['login'])
     },err=>{
       alert("Something went wrong");
     })
   }
 
}
