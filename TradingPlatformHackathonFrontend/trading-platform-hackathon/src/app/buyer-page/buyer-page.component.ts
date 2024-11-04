import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-buyer-page',
  standalone: true,
  imports: [],
  templateUrl: './buyer-page.component.html',
  styleUrl: './buyer-page.component.scss'
})
export class BuyerPageComponent implements OnInit{

  url: string = ''

  constructor(private router: Router) {
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
}
