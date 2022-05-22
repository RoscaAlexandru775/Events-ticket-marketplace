import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { PaymentModel } from '../../models/PaymentModel';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  formpay !: FormGroup;
  price !: any;
  payObj = new PaymentModel();

   constructor(private api: ApiService,
    private formBuilder: FormBuilder,private http : HttpClient,private route:ActivatedRoute, private router:Router, private auth:AuthService) { }

  ngOnInit(): void {
    this.price = this.route.snapshot.paramMap.get('id')
    this.formpay = this.formBuilder.group({
      CreditPay: [this.price],
      FullName:  ['',Validators.required],
      CardNumber:  ['',Validators.required],
      CVV:  [ '',Validators.required],
      ExpireDate:  ['',Validators.required],
      AcceptTerms : [false,Validators.requiredTrue]
      
    })
  }
  onSubmit(){

    
    this.payObj.CreditPay = this.formpay.value.CreditPay;
    this.payObj.FullName = this.formpay.value.FullName;
    this.payObj.CardNumber = this.formpay.value.CardNumber;
    this.payObj.CVV = this.formpay.value.CVV;
    this.payObj.ExpireDate = this.formpay.value.ExpireDate;
    this.payObj.UserId = this.auth.getUserId();
    console.log(this.payObj)
    this.api.pay(this.payObj)
    .subscribe(res=>{
      alert("Payment succes!");
      this.formpay.reset();
      this.router.navigate(['/dashboard-User'])
    })
  }
 
 
}
