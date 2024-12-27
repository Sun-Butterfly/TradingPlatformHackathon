import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {NgIf} from '@angular/common';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent implements OnInit {

  url: string = ''

  constructor(private router: Router, private tokenService: TokenService) {
  }

  goToRegister() {
    this.router.navigate(['register'])
  }

  goToLogin() {
    this.router.navigate(['login'])
  }

  goToBuyer() {
    this.router.navigate(['buyer'])
  }

  goToSupplier() {
    this.router.navigate(['supplier'])
  }

  goToLogout() {
    this.tokenService.logOut()
  }

  ngOnInit(): void {
    this.url = this.router.url;
    this.router.events.subscribe(x => {
      this.url = this.router.url
    });
  }

  isAuthorize() {
    return this.tokenService.isAuthorized();
  }

  goToPersonalAccount() {
    if (this.tokenService.getToken() === null) {
      return alert("Войдите в систему, чтобы продолжить")
    }
    if (this.tokenService.getRole() === "buyer") {
      this.router.navigate(['account_b'])
    }
    if (this.tokenService.getRole() === "supplier") {
      this.router.navigate(['account_s'])
    }
  }

  goToChats() {
    this.router.navigate(['chats'])
  }
}
