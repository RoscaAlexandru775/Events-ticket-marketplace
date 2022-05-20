import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginUrl : string = "http://localhost:3000/signupUsers";
  public loginForm !: FormGroup;
  public isAuthenticated : boolean = false;
  constructor(private router: Router,private http:HttpClient) { }
  
  
   
  login(email :any, password : any){
    this.http.get<any>(this.loginUrl)
    .subscribe(res=>{
      const user = res.find((a:any)=>{
        return a.email === email && a.password === password
      });
      if(user){
        alert("Login Success!!");
        this.isAuthenticated = true;
        if(user.rol === "Admin" || user.rol === "admin")
           this.router.navigate(['/dashboard-Admin']);
        else 
           this.router.navigate(['/dashboard-User']);
        
      }
      else {
        alert("user not found");
       
      }
    },err=>{
      alert("Something went wrong!!")
    })
  }

  logout() {
    this.isAuthenticated = false;
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  verifyisAuthenticated(): boolean {
    return this.isAuthenticated;
  }
}
