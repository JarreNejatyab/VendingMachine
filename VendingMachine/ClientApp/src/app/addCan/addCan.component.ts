import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl, FormsModule  } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { VendingComponent } from '../vending/vending.component';
import { VendingService, CanItem } from '../services/vendingService.service';

@Component({
  templateUrl: './addCan.component.html'
})

export class AddCan implements OnInit {
  canForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private avRoute: ActivatedRoute,
    private vendingService: VendingService, private router: Router) {

    this.canForm = this.formBuilder.group({
      flavour: ['', [Validators.required]],
      price: ['', [Validators.required]],
      quantity: ['', [Validators.required]],
    });
  }

  ngOnInit() {
  }

  save() {

    if (!this.canForm.valid) {
      return;
    }

    this.vendingService.addStock(this.canForm.value)
      .subscribe((data) => {
          this.router.navigate(['/admin']);
        },
        error => {});
  }

  cancel() {
    this.router.navigate(['/admin']);
  }

  get flavour() { return this.canForm.get('flavour'); }
  get price() { return this.canForm.get('price'); }
  get quantity() { return this.canForm.get('quantity'); }
}  
