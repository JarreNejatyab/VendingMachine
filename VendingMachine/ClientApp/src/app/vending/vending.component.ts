import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VendingService, CanItem } from '../services/vendingService.service';
import { PaymentService, Paymentbalance } from '../services/paymentService.service';
import { HttpModule } from '@angular/http';

@Component({
  selector: 'app-vending',
  templateUrl: './vending.component.html'
})
export class VendingComponent {

  public cashBalance: number;
  public creditCardBalance: number;
  public stock: CanItem[];

  constructor(private vendingService: VendingService, private paymentService: PaymentService) {

    this.vendingService = vendingService;

    this.refresh();
  }

  public refresh() {
    this.vendingService.getStock().subscribe(result => {
        this.stock = result;
      },
      error => console.error(error));
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
