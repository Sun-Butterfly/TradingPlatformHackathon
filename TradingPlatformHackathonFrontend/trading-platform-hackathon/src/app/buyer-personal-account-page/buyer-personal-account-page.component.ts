import {Component, OnInit} from '@angular/core';
import {NgForOf} from '@angular/common';
import {HttpService, PurchaseRequest, PurchaseResponse} from '../../http.service';
import {Router} from '@angular/router';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-buyer-personal-account-page',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './buyer-personal-account-page.component.html',
  styleUrl: './buyer-personal-account-page.component.scss'
})
export class BuyerPersonalAccountPageComponent implements OnInit {
  activePurchaseRequestIndex: number = -1;
  purchaseRequestsByBuyerId: PurchaseRequest[] = [];
  activePurchaseResponseIndex: number = -1;
  purchaseResponsesByBuyerId: PurchaseResponse[] = [];

  constructor(private http: HttpService, private router: Router, private tokenService: TokenService) {
  }

  ngOnInit(): void {
    let id = this.tokenService.getId();
    this.getPurchaseRequestsByBuyerId(id)
  }

  setActivePurchaseRequestIndex(i: number) {
    if (this.activePurchaseRequestIndex === i) {
      this.activePurchaseRequestIndex = -1;
    } else {
      this.activePurchaseRequestIndex = i;
    }
  }

  goToRedactPurchaseResponse(i: number) {

  }

  goToDeletePurchaseResponse(i: number) {

  }

  setActivePurchaseResponseIndex(i: number) {
    if (this.activePurchaseResponseIndex === i) {
      this.activePurchaseResponseIndex = -1;
    } else {
      this.activePurchaseResponseIndex = i;
    }
  }

  goToAcceptPurchaseResponse(i: number) {

  }

  goToHome() {
    this.router.navigate(['home'])
  }

  getPurchaseRequestsByBuyerId(id: number) {
    this.http.getPurchaseRequestsByBuyerId(id).subscribe(purchaseResponsesByBuyerId =>
      this.purchaseRequestsByBuyerId = purchaseResponsesByBuyerId);
  }
}
