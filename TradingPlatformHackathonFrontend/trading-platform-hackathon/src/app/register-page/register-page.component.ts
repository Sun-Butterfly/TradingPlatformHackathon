import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {FormControl, FormGroup, ReactiveFormsModule} from '@angular/forms';
import {HttpService} from '../../http.service';

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss'
})
export class RegisterPageComponent implements OnInit {

  url: string = ''
  registerFormGroup: FormGroup;

  constructor(private router: Router, private http: HttpService) {
    this.registerFormGroup = new FormGroup({
      email: new FormControl(null, []),
      password: new FormControl(null, []),
      // confirmPassword: new FormControl(null, []),
      name: new FormControl(null, []),
      address: new FormControl(null, []),
      phoneNumber: new FormControl(null, []),
      roleId: new FormControl(null, []),
    })
  }

  register() {
    // if(this.registerFormGroup.value.password != this.registerFormGroup.value.confirmPassword){
    //   alert("Введенные пароли не совпадают!");
    //   return;
    // }
    let value = this.registerFormGroup.value;
    this.http.register(value).subscribe({
      next: () => {
      alert("Добро пожаловать!");
      this.router.navigate(['home']);
    },
      error: (error) => {
      alert(error.error.message)
      return;
    }})

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
