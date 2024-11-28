import {Component, Input} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {FormControl, FormGroup, ReactiveFormsModule} from '@angular/forms';
import {CreatePurchaseResponseDto, HttpService} from '../../http.service';

@Component({
  selector: 'app-create-purchase-response',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './create-purchase-response.component.html',
  styleUrl: './create-purchase-response.component.scss'
})
export class CreatePurchaseResponseComponent {

  activePurchaseRequestId: number = -1;
  createPurchaseResponseFormGroup: FormGroup;

  constructor(a: ActivatedRoute, private router: Router, private http: HttpService) {
    a.params.subscribe(x => this.activePurchaseRequestId = ~~x['id'])
    this.createPurchaseResponseFormGroup = new FormGroup({
      cost: new FormControl(null, []),
      comment: new FormControl(null, [])
    })
  }

  createPurchaseResponse() {
    let value = this.createPurchaseResponseFormGroup.value;
    let request = {
      ...value,
      purchaseRequestId: this.activePurchaseRequestId
    } as CreatePurchaseResponseDto;
    this.http.createPurchaseResponse(request).subscribe(()=>{
    alert("Готово!");
    this.router.navigate(['supplier'])
    }
    )
  }

  goToCancelCreate() {
    this.router.navigate(['supplier'])
  }
}
