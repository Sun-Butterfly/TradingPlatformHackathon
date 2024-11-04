import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [],
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss'
})
export class RegisterPageComponent implements OnInit{

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
