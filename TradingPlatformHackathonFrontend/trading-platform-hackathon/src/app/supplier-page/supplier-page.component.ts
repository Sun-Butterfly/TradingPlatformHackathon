import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {HttpService, PurchaseRequest} from '../../http.service';
import {NgForOf} from '@angular/common';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-supplier-page',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './supplier-page.component.html',
  styleUrl: './supplier-page.component.scss'
})
export class SupplierPageComponent implements OnInit{

  url: string = ''
  purchaseRequests: PurchaseRequest[] = [];
  activePurchaseRequest: number = -1;

  constructor(private router: Router, private http: HttpService,private tokenService: TokenService) {
  }
  goToHome() {
    this.router.navigate(['home'])
  }

  ngOnInit(): void {
    this.url = this.router.url;
    this.router.events.subscribe(() => {
      this.url = this.router.url
    });
    this.getAllPurchaseRequests();
  }

  setActivePurchaseRequest(i: number) {
    if (this.activePurchaseRequest === i) {
      this.activePurchaseRequest = -1;
    } else {
      this.activePurchaseRequest = i;
    }
  }

  goToCreatePurchaseResponse(i: number) {
    let purchaseRequest = this.purchaseRequests[i];

    if (this.tokenService.getToken() == null) {
      return alert("Войдите в систему, чтобы продолжить")
    }
    if (this.tokenService.getRole() !== "supplier") {
      alert("Вы не поставщик!")
      return;
    }
    this.router.navigate(['create-purchase-response'])
  }

  getAllPurchaseRequests(){
this.http.getAllPurchaseRequests().subscribe(purchaseRequests => {
  this.purchaseRequests = purchaseRequests;
})
  }
}
