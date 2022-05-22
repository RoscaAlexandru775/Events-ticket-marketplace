import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { pipe } from 'rxjs';
import {map} from 'rxjs/operators'


@Injectable({
  providedIn: 'root'
})
export class ApiService{

  // private organizerUrl = 'http://localhost:3000/Organizatori';
  // private locationUrl = 'http://localhost:3000/Location';
  // private apiUrl = 'http://localhost:3000/EventModel/';
  
  

  constructor(private http:HttpClient) { }
 
  postOrganizer(data: any)
  {
    
    console.log(data);
    return this.http.post<any>("http://localhost:38967/api/Organizers/AddOrganizer",data);//.pipe(map((res: any)=>{return res;}))
  }
  postLocation(data: any)
  {

    return this.http.post<any>("http://localhost:38967/api/Locations/AddLocation",data);//.pipe(map((res: any)=>{return res;}))
  }
  
  postEvents(data: any){
    return this.http.post<any>("http://localhost:38967/api/Event/AddEvent",data);//.pipe(map((res:any)=>{return res;}))
  }

  getEvents() {
    return this.http.get<any>("http://localhost:38967/api/Event/Get");//.pipe(map((res:any)=>{return res;}))
  }

  deleteEvents(id: number){
    
   return this.http.delete<any>("http://localhost:38967/api/Event/Delete/"+id).pipe(map((res:any)=>{return res;}))
  }

  updateEvents(data: any,id: number){
    return this.http.put<any>("http://localhost:38967/api/Event/Update/"+id,data,);//.pipe(map((res:any)=> {return res;}))
  }
  pay(data: any)
  {
    return this.http.post<any>("http://localhost:38967/api/Payments/AddPayment",data);
  }

}