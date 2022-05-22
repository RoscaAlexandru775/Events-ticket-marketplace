import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EventModel } from '../../models/EventModel';
import { ApiService } from '../../services/api.service';
import { HttpClient } from '@angular/common/http';
import { Organizator } from 'src/app/models/Organizator';
import { Location } from 'src/app/models/Location';

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.css']
})
export class DashboardAdminComponent implements OnInit {

  formEvent !: FormGroup;
  formOrganizer !: FormGroup;
  formLocation !: FormGroup;
  eventData !: any;
  eventObj : EventModel = new EventModel();
  organizerObj : Organizator = new Organizator();
  locationObj : Location = new Location();
  showAdd !: boolean;
  showUpdate !: boolean;
  @Input() receive !: string;
  @Input() mobileSpecification !: any;
  role:string =""

  constructor( private http : HttpClient, private api: ApiService,
    private formBuilder: FormBuilder) { }


    ngOnInit(): void {
      this.formEvent = this.formBuilder.group({
        Denumire: ['',Validators.required],
        ZiDesfasurare:  ['',Validators.required],
        Pret:  [ 0,Validators.required],
        NumarBilete:  [ 0,Validators.required],
        Categorie:  ['',Validators.required],
        OrganizatorId:  ['',Validators.required]
      })
      this.formOrganizer = this.formBuilder.group({
        fullname: ['',Validators.required],
        email:["",Validators.compose([Validators.required,Validators.email])],
        mobile:  ['',Validators.required]
        
      })
      this.formLocation = this.formBuilder.group({
        city: ['',Validators.required],
        province:['',Validators.required],
        zipcode:  [0 ,Validators.required],
        country:  ['',Validators.required],
        address:  ['',Validators.required],
        
      })
      this.getAllEvents();
      
    }
  
    clickAddLocation(){
      this.formLocation.reset();
    }

    postLocationDetails() {
      this.locationObj.city = this.formLocation.value.city;
      this.locationObj.province = this.formLocation.value.province;
      this.locationObj.zipcode = this.formLocation.value.zipcode;
      this.locationObj.country = this.formLocation.value.country;
      this.locationObj.address = this.formLocation.value.address;
      this.api.postLocation(this.locationObj)
       .subscribe(res => {
         console.log(res);
        //  let ref = document.getElementById('close');
        //  ref?.click();
         alert("location added successfully");
       });
       
   }
    clickAddOrganizer(){
      this.formOrganizer.reset();
    }

    postOrganizerDetails() {
      this.organizerObj.FullName = this.formOrganizer.value.fullname;
      this.organizerObj.Email = this.formOrganizer.value.email;
      this.organizerObj.Mobile = this.formOrganizer.value.mobile;
      this.api.postOrganizer(this.organizerObj)
       .subscribe(res => {
         console.log(res);
        //  let ref = document.getElementById('close');
        //  ref?.click();
         alert("organizer added successfully");
       });
       
   }

    clickAddEvent(){
      this.formEvent.reset();
      this.showAdd = true;
      this.showUpdate = false;
    }


    postEventDetails() {
       this.eventObj.Denumire = this.formEvent.value.Denumire;
       this.eventObj.ZiDesfasurare = this.formEvent.value.ZiDesfasurare;
       this.eventObj.Pret = this.formEvent.value.Pret;
       this.eventObj.NumarBilete = this.formEvent.value.NumarBilete;
       this.eventObj.Categorie = this.formEvent.value.Categorie;
       this.eventObj.OrganizatorId = this.formEvent.value.OrganizatorId;
       this.api.postEvents(this.eventObj)
        .subscribe(res => {
          console.log(res);
          // let ref = document.getElementById('close');
          // ref?.click();
          this.getAllEvents();
          alert("events added successfully");
        })

    }
    getAllEvents() {
      this.api.getEvents().subscribe(res=>{
        this.eventData = res;
      });
      
    }
   

    updateEventDetails(){
      this.eventObj.Denumire = this.formEvent.value.Denumire;
      this.eventObj.ZiDesfasurare = this.formEvent.value.ZiDesfasurare;
      this.eventObj.Pret = this.formEvent.value.Pret;
      this.eventObj.NumarBilete = this.formEvent.value.NumarBilete;
      this.eventObj.Categorie = this.formEvent.value.Categorie;
      this.eventObj.OrganizatorId = this.formEvent.value.OrganizatorId;
      this.api.updateEvents(this.eventObj,this.eventObj.id).subscribe(res=>{
        alert("update successfully");
        // let ref = document.getElementById('close');
        // ref?.click();
        this.getAllEvents();
      })

    }
   
   onEdit(row : any){
    this.eventObj.id = row.id;
    this.formEvent.controls['Denumire'].setValue(row.Denumire);
    this.formEvent.controls['ZiDesfasurare'].setValue(row.ZiDesfasurare);
    this.formEvent.controls['Pret'].setValue(row.Pret);
    this.formEvent.controls['NumarBilete'].setValue(row.NumarBilete);
    this.formEvent.controls['Categorie'].setValue(row.Categorie);
    this.formEvent.controls['OrganizatorId'].setValue(row.OrganizatorId);
    this.showUpdate = true;
    this.showAdd = false;
  }

  deleteEventDetail(row : any){
     this.api.deleteEvents(row.id)
     .subscribe(res=>{
       alert("Deleted Successfully");
       this.getAllEvents();
     })

     
   }

}


