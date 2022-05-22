import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {



  public cartItemList : any =[]
  public productList = new BehaviorSubject<any>([]);
  
  constructor(private http:HttpClient) { }

    getProducts(){
    return this.productList.asObservable();
  }

  addtoCart(product : any){
    this.cartItemList.push(product);
    this.productList.next(this.cartItemList);
    this.getTotalPrice();
    
  }

  getTotalPrice() : number{
    let grandTotal = 0;
    this.cartItemList.map((a:any)=>{
      grandTotal += a.pret;
      
    })
    return grandTotal;
  }

  removeCartItem(product: any){
    var ok=0;
    this.cartItemList.map((a:any, index:any)=>{
      if(product.id=== a.id && ok == 0){
        this.cartItemList.splice(index,1);
        ok = 1; 
      }

    })
    this.productList.next(this.cartItemList);
    
  }
  removeAllCart(){
    this.cartItemList = []
    this.productList.next(this.cartItemList);
  }
}
