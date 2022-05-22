import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public loginAPIUrl : string = "http://localhost:38967/api/Auth/Login";
  
  public loginForm !: FormGroup;
  
  constructor(private router: Router,private http:HttpClient) { }
  
  register(userObj:any){
    
    return this.http.post<any>("http://localhost:38967/api/Auth/Register",userObj);
  }
  login(userObj:any){
   
    return this.http.post<any>("http://localhost:38967/api/Auth/Login",userObj);
  }
 

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  verifyisAuthenticated(): boolean {
    if(localStorage.getItem('token'))
      return true;
    
    return false;
  }
  getRole()
  {
    let jwt = localStorage.getItem('token');
        
        if(jwt != null){
          let jwtData = jwt.split('.')[1];
          let decodedJwtJsonData = window.atob(jwtData)
          let decodedJwtData = JSON.parse(decodedJwtJsonData)
          return decodedJwtData.role;
        }
  }
  getUserId()
  {
    let jwt = localStorage.getItem('token');
        
        if(jwt != null){
          let jwtData = jwt.split('.')[1];
          let decodedJwtJsonData = window.atob(jwtData)
          let decodedJwtData = JSON.parse(decodedJwtJsonData)
          console.log(decodedJwtData)
          console.log(decodedJwtData.nameid)
          return decodedJwtData.nameid;
        }
  }
}
