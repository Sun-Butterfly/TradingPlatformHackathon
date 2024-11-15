import {Component, Input} from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-create-purchase-response',
  standalone: true,
  imports: [],
  templateUrl: './create-purchase-response.component.html',
  styleUrl: './create-purchase-response.component.scss'
})
export class CreatePurchaseResponseComponent {

  activePurchaseRequestId: number = -1;

  constructor(a: ActivatedRoute) {
    a.params.subscribe(x=>this.activePurchaseRequestId = ~~x['id'])
  }
}
