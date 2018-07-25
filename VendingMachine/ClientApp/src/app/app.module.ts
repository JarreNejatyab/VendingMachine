import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { VendingService } from './services/vendingService.service';
import { PaymentService } from './services/paymentService.service';
import { AdminComponent} from './admin/admin.component';
import { VendingComponent } from './vending/vending.component';
import { AddCan } from "./addCan/addCan.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    AdminComponent,
    VendingComponent,
    AddCan
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule ,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: VendingComponent, pathMatch: 'full' },
      { path: 'admin', component: AdminComponent },
      { path: 'vending', component: VendingComponent },
      { path: 'addCan', component: AddCan },
    ])
  ],
  providers: [VendingService,PaymentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
