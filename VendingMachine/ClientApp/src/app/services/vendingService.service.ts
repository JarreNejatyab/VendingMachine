import { Injectable, Inject } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class VendingService {

  myAppUrl: string = "";

  constructor(private _http: HttpClient) {
    //this.myAppUrl = baseUrl;
  }

  getStock() {
    return this._http.get<CanItem>(this.myAppUrl + 'api/Vending/GetStock')
      .catch(this.errorHandler);
  }

  addStock(can) {
    return this._http.post(this.myAppUrl + "api/Vending/AddStock", can)
      .catch(this.errorHandler);
  }

  deleteStock(can) {
    return this._http.delete(this.myAppUrl + "api/Vending/DeleteStock/" + can.flavour)
      .catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}

export interface CanItem {
  flavour: string;
  quantity: number;
}
