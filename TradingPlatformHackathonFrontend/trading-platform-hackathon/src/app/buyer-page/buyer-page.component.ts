import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-buyer-page',
  standalone: true,
  imports: [],
  templateUrl: './buyer-page.component.html',
  styleUrl: './buyer-page.component.scss'
})
export class BuyerPageComponent implements OnInit {

  url: string = ''

  constructor(private router: Router, private tokenService: TokenService) {
  }

  goToHome() {
    this.router.navigate(['home'])
  }

  ngOnInit(): void {
    this.url = this.router.url;
    this.router.events.subscribe(x => {
      this.url = this.router.url
    });
  }

  goToCreatePurchaseRequest() {
    if (this.tokenService.getToken() == null) {
      return alert("Войдите в систему, чтобы продолжить")
    }
    this.router.navigate(['create-purchase-request'])
  }
}
