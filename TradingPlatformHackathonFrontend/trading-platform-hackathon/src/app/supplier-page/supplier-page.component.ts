import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-supplier-page',
  standalone: true,
  imports: [],
  templateUrl: './supplier-page.component.html',
  styleUrl: './supplier-page.component.scss'
})
export class SupplierPageComponent implements OnInit{

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
