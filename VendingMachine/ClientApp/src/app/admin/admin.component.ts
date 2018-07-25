import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VendingService, CanItem } from '../services/vendingService.service';
import { PaymentService, Paymentbalance } from '../services/paymentService.service';
import { HttpModule } from '@angular/http';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html'
})
export class AdminComponent {

  public cashBalance: number;
  public creditCardBalance: number;
  public stock: CanItem[];
  public can: CanItem;

  constructor(private vendingService: VendingService, private paymentService: PaymentService) {

    this.vendingService = vendingService;

    this.refresh();
  }

  public reset() {
    this.paymentService.reset()
      .subscribe(resp => { this.refresh(); }
      , error => console.error(error));  
  }

  public refresh() {

    this.paymentService.getBalance().subscribe(result => {

      this.cashBalance = result.cashBalance;
      this.creditCardBalance = result.creditBalance;

      },
      error => console.error(error));

    this.vendingService.getStock().subscribe(result => {

      this.stock = result;

      },
      error => console.error(error));
  }

  public deleteStock(item: CanItem) {
    this.vendingService.deleteStock(item).subscribe(result => {
      this.refresh();
    }, error => console.error(error));
  }

  public buyCash(item: CanItem) {
    this.paymentService.buyCash(item).subscribe(result => {
      this.refresh();
    }, error => console.error(error));
  }

  public buyCredit(item: CanItem) {
    this.paymentService.buyCredit(item).subscribe(result => {
      this.refresh();
    }, error => console.error(error));
  }
}
