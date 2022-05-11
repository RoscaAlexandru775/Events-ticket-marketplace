import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { pipe } from 'rxjs';
import {map} from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ApiService{

  private organizerUrl = 'http://localhost:3000/Organizatori';
  private locationUrl = 'http://localhost:3000/Location';
  private apiUrl = 'http://localhost:3000/EventModel/';

  constructor(private http:HttpClient) { }
 
  postOrganizer(data: any)
  {
    return this.http.post<any>(this.organizerUrl,data).pipe(map((res: any)=>{return res;}))
  }
  postLocation(data: any)
  {
    return this.http.post<any>(this.locationUrl,data).pipe(map((res: any)=>{return res;}))
  }
  
  postEvents(data: any){
    return this.http.post<any>(this.apiUrl,data).pipe(map((res:any)=>{return res;}))
  }

  getEvents() {
    return this.http.get<any>(this.apiUrl).pipe(map((res:any)=>{return res;}))
  }

  deleteEvents(id: number){
   return this.http.delete<any>(this.apiUrl+id).pipe(map((res:any)=>{return res;}))
  }

  updateEvents(data: any,id: number){
    return this.http.put<any>(this.apiUrl+id,data).pipe(map((res:any)=> {return res;}))
  }

  // signUp(userObj : any) {
  //   return this.http.post<any>("http://localhost:3229/Account/Register",userObj)
  // }
}