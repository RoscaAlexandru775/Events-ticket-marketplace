import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { CartService } from 'src/app/services/cart.service';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public products : any = [];
  public grandTotal !: number;
  public numeOrganizator !: string;
  
  constructor(private cart: CartService, private http:HttpClient) { }
  

  ngOnInit(): void {
    this.cart.getProducts()
    .subscribe(res=>{
      console.log(res.cartItemList);
      this.products = res;
      this.grandTotal = this.cart.getTotalPrice();
    })
    
  }
  removeItem(item: any){
     this.cart.removeCartItem(item);
  }
  emptycart(){
     this.cart.removeAllCart();
  }
 
}
