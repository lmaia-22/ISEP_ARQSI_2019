import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OptionsComponent } from './components/mdf/options/options.component';
import { NavComponent } from './components/nav/nav.component';
import { OptionspComponent } from './components/mdp/optionsp/optionsp.component';
import { LoginComponent } from './components/layout/login/login.component';
import { OrderComponent } from './components/orders/order/order.component';
import { RegisterComponent } from './components/layout/register/register.component';
const routes: Routes = [

  { path: 'nav', component: NavComponent },
  { path: 'mdf', component: OptionsComponent },
  { path: 'mdp', component: OptionspComponent },
  { path: '', component: LoginComponent },
  { path: 'orders', component: OrderComponent }, 
  { path: 'register' , component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
