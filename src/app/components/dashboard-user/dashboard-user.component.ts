import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { HttpClient } from '@angular/common/http';
import { CartService } from 'src/app/services/cart.service';


@Component({
  selector: 'app-dashboard-user',
  templateUrl: './dashboard-user.component.html',
  styleUrls: ['./dashboard-user.component.css']
})
export class DashboardUserComponent implements OnInit {
 
  eventData !: any;

  constructor( private http : HttpClient, private api: ApiService,private cart: CartService) { }


    ngOnInit(): void {
    
      this.getAllEvents();
      
    }
  
  
    addToCart(product : any){
      this.cart.addtoCart(product);
    }

    getAllEvents() {
      this.api.getEvents().subscribe(res=>{this.eventData = res;})
    }
    
}



