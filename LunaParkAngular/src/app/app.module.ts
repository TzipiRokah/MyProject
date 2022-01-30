import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { DataViewModule } from 'primeng/dataview';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { AboutComponent } from './Components/about/about.component';
import { TicketsComponent } from './Components/tickets/tickets.component';
import { QuickAttractionComponent } from './Components/quick-attraction/quick-attraction.component';
import { ChooseAttractionComponent } from './Components/choose-attraction/choose-attraction.component';
import { TicketBasketComponent } from './Components/ticket-basket/ticket-basket.component';
import { UserComponent } from './Components/user/user.component';
import { EntranceComponent } from './Components/entrance/entrance.component';
import { ManagerComponent } from './Components/manager/manager.component';
import { MapOpenComponent } from './Components/map-open/map-open.component';
import { SadranComponent } from './Components/sadran/sadran.component';
import { OperatorComponent } from './Components/operator/operator.component';
import { MainComponent } from './Components/main/main.component';
import { AttractionStatusViewComponent } from './Components/attraction-status-view/attraction-status-view.component';
import { RateComponent } from './Components/rate/rate.component';
import { RateManagerComponent } from './Components/rate-manager/rate-manager.component';
import { RegistryEmployeeComponent } from './Components/registry-employee/registry-employee.component';
import { ResetQueuesComponent } from './Components/reset-queues/reset-queues.component';
import { MessageComponent } from './Components/message/message.component';
import { PayComponent } from './Components/pay/pay.component';



let AppRoute:Routes=[
  {path:"", component:HomeComponent,
  children:[
    {path:"", component:MainComponent},
    {path:"About", component:AboutComponent},
    {path:"Tickets", component:TicketsComponent},
    {path:"TicketsBasket", component:TicketBasketComponent},
    {path:"Rate", component:RateComponent},
    {path:"Choose", component:ChooseAttractionComponent},
    {path:"Quick Attraction", component:QuickAttractionComponent},
    {path:"Login", component:UserComponent},
    {path:"Registry", component:EntranceComponent},
    {path:"Manager", component:ManagerComponent},
    {path:"Sadran", component:SadranComponent},
    {path:"Operator", component:OperatorComponent},
    {path:"Pay", component:PayComponent},
    {path:"Instructions", component:MapOpenComponent}]},
    {path:"**", redirectTo:"not-found" }
]

@NgModule({
  
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    TicketsComponent,
    QuickAttractionComponent,
    ChooseAttractionComponent,
    TicketBasketComponent,
    UserComponent,
    EntranceComponent,
    ManagerComponent,
    MapOpenComponent,
    SadranComponent,
    OperatorComponent,
    MainComponent,
    AttractionStatusViewComponent,
    RateComponent,
    RateManagerComponent,
    RegistryEmployeeComponent,
    ResetQueuesComponent,
    MessageComponent,
    PayComponent
  ],
  
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(AppRoute),
    DataViewModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  
  providers: [
  ],
 
  bootstrap: [AppComponent]
})
export class AppModule { }



