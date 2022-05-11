import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  formpay !: FormGroup;
  price !: any

   constructor(private api: ApiService,
    private formBuilder: FormBuilder,private http : HttpClient,private route:ActivatedRoute, private router:Router) { }

  ngOnInit(): void {
    this.price = this.route.snapshot.paramMap.get('id')
    this.formpay = this.formBuilder.group({
      CreditPay: [this.price],
      FullName:  ['',Validators.required],
      CardNumber:  ['',Validators.required],
      CVV:  [ '',Validators.required],
      ExpireDate:  ['',Validators.required]
      
    })
  }
  onSubmit(){
    this.http.post<any>("http://localhost:3000/PaymentModel", this.formpay.value)
    .subscribe(res=>{
      alert("Payment Successfull");
      this.formpay.reset();
      this.router.navigate(['/dashboard-User']);
      this.formpay.reset();
  
    },err=>{
      alert("Something went wrong");
    })
  }

 
}
