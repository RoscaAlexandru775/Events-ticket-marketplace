import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
//import { AuthGuard } from './shared/auth.guard';
import { SignupComponent } from './components/singup/singup.component';
import { SingupAdminComponent } from './admin/singup-admin/singup-admin.component';
import { PaymentComponent } from './components/payment/payment.component';
import { DashboardAdminComponent } from './admin/dashboard-admin/dashboard-admin.component';
import { DashboardUserComponent } from './components/dashboard-user/dashboard-user.component';
import { CartComponent } from './components/cart/cart.component';
import { AuthGuard } from './components/guards/auth.guard';


const routes: Routes = [
  {path:'', redirectTo:'login',pathMatch:'full'},
  {path:'dashboard-Admin', canActivate: [AuthGuard], component:DashboardAdminComponent},
  {path:'dashboard-User', canActivate: [AuthGuard], component:DashboardUserComponent},
  {path:'login', component:LoginComponent},
  {path:'signup', component: SignupComponent},
  {path:'singupAdmin', canActivate: [AuthGuard], component: SingupAdminComponent},
  {path:'cart', canActivate: [AuthGuard], component: CartComponent},
  {path:'payment/:id', canActivate: [AuthGuard], component: PaymentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }