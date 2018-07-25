import { Injectable, Inject } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { CanItem } from './vendingService.service';

@Injectable()
export class PaymentService {

  myAppUrl: string = "";

  constructor(private _http: HttpClient) {
    //this.myAppUrl = baseUrl;
  }

  getBalance() {
    return this._http.get<number>(this.myAppUrl + 'api/Payment/GetPaymentBalance')
      .catch(this.errorHandler);
  }

  buyCash(item: CanItem) {
    return this._http.put<number>(this.myAppUrl + 'api/Payment/BuyWithCash',item)
      .catch(this.errorHandler);
  }

  buyCredit(item: CanItem) {
    return this._http.put<number>(this.myAppUrl + 'api/Payment/BuyWithCredit', item)
      .catch(this.errorHandler);
  }

  reset() {
    return this._http.post(this.myAppUrl + "api/Payment/Reset",null)
      .catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}

export interface Paymentbalance {
  cashBalance: string;
  creditBalance: number;
}
