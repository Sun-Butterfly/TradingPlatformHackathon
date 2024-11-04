import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ErrorModel, HttpService} from '../../http.service';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent implements OnInit {

  url: string = ''
  logInFormGroup: FormGroup;

  constructor(private router: Router, private http: HttpService, private tokenService: TokenService) {
    this.logInFormGroup = new FormGroup({
      email: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required)
    })
  }

  goToHome() {
    this.router.navigate(['home'])
  }

  logIn() {
    if (this.logInFormGroup.invalid) {
      alert('Ошибка')
      return;
    }
    let request = this.logInFormGroup.value;
    this.http.logIn(request).subscribe({
        next: (logInResponse) => {
          this.tokenService.setToken(logInResponse.token);
          alert("Добро пожаловать!");
          this.router.navigate(['home']);
        },
        error: (error) => {
          alert(error.error.message)
          return;
        }
      }
    )
  }


  ngOnInit(): void {
    this.url = this.router.url;
    this.router.events.subscribe(x => {
      this.url = this.router.url
    });
  }
}
