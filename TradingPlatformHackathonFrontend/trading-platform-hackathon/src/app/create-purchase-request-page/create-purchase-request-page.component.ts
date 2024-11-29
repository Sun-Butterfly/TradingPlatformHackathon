import { Component } from '@angular/core';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';
import {Router} from '@angular/router';
import {HttpService} from '../../http.service';

@Component({
  selector: 'app-create-purchase-request-page',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './create-purchase-request-page.component.html',
  styleUrl: './create-purchase-request-page.component.scss'
})
export class CreatePurchaseRequestPageComponent {
  createPurchaseRequestFormGroup: FormGroup;

  constructor(private router: Router, private http: HttpService) {
    this.createPurchaseRequestFormGroup = new FormGroup({
      productName: new FormControl(null,[]),
      productCount: new FormControl(null, []),
      cost: new FormControl(null, [])
    })
  }
  createPurchaseRequest() {
    let value = this.createPurchaseRequestFormGroup.value;
    this.http.createPurchaseRequest(value).subscribe(()=>{
      alert("Готово!");
      this.router.navigate(['buyer'])
    })
  }

  goToCancelCreate() {
    this.router.navigate(['buyer'])
  }
}
