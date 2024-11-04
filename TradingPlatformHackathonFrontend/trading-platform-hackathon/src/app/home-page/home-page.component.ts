import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent implements OnInit {

  url: string = ''

  constructor(private router: Router) {
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

  ngOnInit(): void {
    this.url = this.router.url;
    this.router.events.subscribe(x => {
      this.url = this.router.url
    });
  }
}
