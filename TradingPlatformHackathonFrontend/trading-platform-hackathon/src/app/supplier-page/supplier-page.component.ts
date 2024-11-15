import {Component, Input, OnInit, ViewChild} from '@angular/core';
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
  activePurchaseRequestIndex: number = -1;

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

  setActivePurchaseRequestIndex(i: number) {
    if (this.activePurchaseRequestIndex === i) {
      this.activePurchaseRequestIndex = -1;
    } else {
      this.activePurchaseRequestIndex = i;
    }
  }

  goToCreatePurchaseResponse(i: number) {

    if (this.tokenService.getToken() == null) {
      return alert("Войдите в систему, чтобы продолжить")
    }
    if (this.tokenService.getRole() !== "supplier") {
      alert("Вы не поставщик!")
      return;
    }
    this.router.navigate(['create-purchase-response', this.purchaseRequests[i].id.toString()])
  }

  getAllPurchaseRequests(){
this.http.getAllPurchaseRequests().subscribe(purchaseRequests => {
  this.purchaseRequests = purchaseRequests;
})
  }
}
