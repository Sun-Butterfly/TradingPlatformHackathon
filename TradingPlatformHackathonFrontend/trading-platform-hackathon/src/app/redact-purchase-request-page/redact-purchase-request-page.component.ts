import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {ActivatedRoute, Router} from '@angular/router';
import {
  CreatePurchaseResponseDto,
  GetPurchaseRequestByIdDto,
  HttpService,
  RedactPurchaseRequestDto
} from '../../http.service';

@Component({
  selector: 'app-redact-purchase-request-page',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './redact-purchase-request-page.component.html',
  styleUrl: './redact-purchase-request-page.component.scss'
})
export class RedactPurchaseRequestPageComponent implements OnInit {
  activePurchaseRequestId: number = -1;
  redactPurchaseRequestFormGroup: FormGroup;
  purchaseRequestById: GetPurchaseRequestByIdDto = {cost: 0, productCount: 0, productName: ''};

  constructor(a: ActivatedRoute, private http: HttpService, private router: Router) {
    a.params.subscribe(x => this.activePurchaseRequestId = ~~x['id'])
    this.redactPurchaseRequestFormGroup = new FormGroup({
      productName: new FormControl(null, []),
      productCount: new FormControl(null, []),
      cost: new FormControl(null, []),
    })
  }

  ngOnInit(): void {

    this.http.getPurchaseRequestById(this.activePurchaseRequestId).subscribe(purchaseRequestById => {
      this.purchaseRequestById = purchaseRequestById;
      this.redactPurchaseRequestFormGroup.patchValue({...this.purchaseRequestById})
    })
  }

  redactPurchaseRequest() {
    let value = this.redactPurchaseRequestFormGroup.value;
    let request = {
      ...value,
      purchaseRequestId: this.activePurchaseRequestId
    } as RedactPurchaseRequestDto;
this.http.redactPurchaseRequestById(request).subscribe(()=>{
  alert("Готово!");
  this.router.navigate(['account_b'])
})
  }

  goToCancelRedact() {
this.router.navigate(['account_b'])
  }
}
