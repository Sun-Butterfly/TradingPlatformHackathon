import {Component, OnInit} from '@angular/core';
import {NgForOf} from "@angular/common";
import {HttpService, PurchaseResponse} from '../../http.service';
import {TokenService} from '../../token.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-supplier-personal-account-page',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './supplier-personal-account-page.component.html',
  styleUrl: './supplier-personal-account-page.component.scss'
})
export class SupplierPersonalAccountPageComponent implements OnInit {
  purchaseResponsesBySupplierId: PurchaseResponse[] = [];
  private activePurchaseResponseIndex: number = -1;

  constructor(private http: HttpService, private tokenService: TokenService, private router: Router) {
  }

  ngOnInit(): void {
    let id = this.tokenService.getId();
    this.getPurchaseResponsesBySupplierId(id);
  }

  setActivePurchaseResponseIndex(i: number) {
    if (this.activePurchaseResponseIndex === i) {
      this.activePurchaseResponseIndex = -1;
    } else {
      this.activePurchaseResponseIndex = i;
    }

  }

  getPurchaseResponsesBySupplierId(id: number) {
    this.http.getPurchaseResponsesBySupplierId(id).subscribe(purchaseResponsesBySupplierId =>
      this.purchaseResponsesBySupplierId = purchaseResponsesBySupplierId)
  }

  goToRedactPurchaseResponse(i: number) {

  }

  goToDeletePurchaseResponse(i: number) {

  }
}
