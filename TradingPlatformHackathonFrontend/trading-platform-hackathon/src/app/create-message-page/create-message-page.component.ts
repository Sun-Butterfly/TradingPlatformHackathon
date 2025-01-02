import {Component} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {Router} from '@angular/router';
import {CreateChatDto, HttpService} from '../../http.service';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-create-message-page',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './create-message-page.component.html',
  styleUrl: './create-message-page.component.scss'
})
export class CreateMessagePageComponent {
  createMessageFormGroup: FormGroup;

  constructor(private router: Router, private http: HttpService, private tokenService: TokenService) {
    this.createMessageFormGroup = new FormGroup({
      companionId: new FormControl(null, []),
      text: new FormControl(null, [])
    })
  }

  createChat() {
    let value = this.createMessageFormGroup.value;
    this.http.createChat(value).subscribe(()=>{
      alert("Отправлено!");
      this.router.navigate(['chats']).then(()=>{})})
  }

  goToCancelCreate() {
    this.router.navigate(['chats']).then(()=>{})
  }
}
