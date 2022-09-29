import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule, NgbActiveModal, NgbButtonsModule, NgbDropdownMenu } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { NavComponent } from './components/nav/nav.component';
import { OptionsComponent } from './components/mdf/options/options.component';
import { ProductsComponent } from './components/mdf/products/products.component';
import { FabricplanComponent } from './components/mdf/fabricplan/fabricplan.component';
import { OptionspComponent } from './components/mdp/optionsp/optionsp.component';
import { MachineComponent } from './components/mdp/machine/machine.component';
import { OperationComponent } from './components/mdp/operation/operation.component';
import { ProductlineComponent } from './components/mdp/productline/productline.component';
import { TypemachineComponent } from './components/mdp/typemachine/typemachine.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { OrderComponent } from './components/orders/order/order.component';
import { UserComponent } from './components/orders/user/user.component';
import { LoginComponent } from './components/layout/login/login.component';
import { RegisterComponent } from './components/layout/register/register.component';
import { Interceptor } from '../../src/app/services/orders/authentication/interceptor';
import { TopproductsComponent } from './components/orders/topproducts/topproducts.component';
import { TopproductsquantityComponent } from './components/orders/topproductsquantity/topproductsquantity.component';
import { QuickerproductsComponent } from './components/orders/quickerproducts/quickerproducts.component';
import { NeworderComponent } from './components/orders/neworder/neworder.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    OptionsComponent,
    ProductsComponent,
    FabricplanComponent,
    OptionsComponent,
    OptionspComponent,
    MachineComponent,
    OperationComponent,
    ProductlineComponent,
    TypemachineComponent,
    OrderComponent,
    UserComponent,
    LoginComponent,
    RegisterComponent,
    TopproductsComponent,
    TopproductsquantityComponent,
    QuickerproductsComponent,
    NeworderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    AngularFontAwesomeModule,
    NgbButtonsModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule
  ],
  providers: [ NgbActiveModal, NgbDropdownMenu,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: Interceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
  entryComponents: [NeworderComponent],
})
export class AppModule { }
