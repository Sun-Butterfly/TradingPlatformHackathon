import {Component, OnInit} from '@angular/core';
import {NgForOf} from '@angular/common';
import {HttpService, PurchaseRequest, PurchaseRequestInWorkDto, PurchaseResponse} from '../../http.service';
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
  purchaseRequestsInWorkByBuyerId: PurchaseRequestInWorkDto[] = [];

  constructor(private http: HttpService, private router: Router, private tokenService: TokenService) {
  }

  ngOnInit(): void {
    let id = this.tokenService.getId();
    this.getPurchaseRequestsByBuyerId(id)
    this.getPurchaseResponsesByBuyerId(id)
    this.getPurchaseRequestsInWorkByBuyerId(id)
  }

  setActivePurchaseRequestIndex(i: number) {
    if (this.activePurchaseRequestIndex === i) {
      this.activePurchaseRequestIndex = -1;
    } else {
      this.activePurchaseRequestIndex = i;
    }
  }

  goToRedactPurchaseRequest(i: number) {
    this.router.navigate(['redact-purchase-request', this.purchaseRequestsByBuyerId[i].id.toString()])
  }

  goToDeletePurchaseRequest(i: number) {
    let purchaseRequestId = this.purchaseRequestsByBuyerId[i].id;
    let buyerId = this.tokenService.getId();
    this.http.deletePurchaseRequest(purchaseRequestId).subscribe(() => {
        this.getPurchaseRequestsByBuyerId(buyerId);
        this.getPurchaseResponsesByBuyerId(buyerId)
      }
    )
  }

  setActivePurchaseResponseIndex(i: number) {
    if (this.activePurchaseResponseIndex === i) {
      this.activePurchaseResponseIndex = -1;
    } else {
      this.activePurchaseResponseIndex = i;
    }
  }

  goToAcceptPurchaseResponse(i: number) {
    let purchaseResponseId = this.purchaseResponsesByBuyerId[i].id;
    let buyerId = this.tokenService.getId();
    this.http.acceptPurchaseResponse(purchaseResponseId).subscribe(() => {
      this.getPurchaseRequestsByBuyerId(buyerId);
      this.getPurchaseResponsesByBuyerId(buyerId);
      this.getPurchaseRequestsInWorkByBuyerId(buyerId);
    })
  }

  goToHome() {
    this.router.navigate(['home'])
  }

  getPurchaseRequestsByBuyerId(id: number) {
    this.http.getPurchaseRequestsByBuyerId(id).subscribe(purchaseRequestsByBuyerId =>
      this.purchaseRequestsByBuyerId = purchaseRequestsByBuyerId);
  }

  getPurchaseResponsesByBuyerId(id: number) {
    this.http.getPurchaseResponsesByBuyerId(id).subscribe(purchaseResponsesByBuyerId =>
      this.purchaseResponsesByBuyerId = purchaseResponsesByBuyerId)
  }

  getPurchaseRequestsInWorkByBuyerId(id: number) {
    this.http.getPurchaseRequestsInWorkByBuyerId(id).subscribe(purchaseRequestsInWorkByBuyerId =>
      this.purchaseRequestsInWorkByBuyerId = purchaseRequestsInWorkByBuyerId)
  }
}
