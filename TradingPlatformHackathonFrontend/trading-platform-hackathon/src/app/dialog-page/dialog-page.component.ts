import {Component, OnInit} from '@angular/core';
import {DatePipe, NgForOf} from '@angular/common';
import {CreateMessageDto, HttpService, Message} from '../../http.service';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {ActivatedRoute, Router} from '@angular/router';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-dialog-page',
  standalone: true,
  imports: [
    NgForOf,
    ReactiveFormsModule,
    DatePipe
  ],
  templateUrl: './dialog-page.component.html',
  styleUrl: './dialog-page.component.scss'
})
export class DialogPageComponent implements OnInit {
  messages: Message[] = [];
  companionId: number = -1;
  sendMessageFormGroup: FormGroup;
  refreshingInterval: number = -1;

  constructor(a: ActivatedRoute, private http: HttpService, private router: Router, private tokenService: TokenService) {
    a.params.subscribe(x => this.companionId = ~~x['id']);
    this.sendMessageFormGroup = new FormGroup({
      text: new FormControl(null, [])
    })
  }

  ngOnInit(): void {
    this.getMessagesByUserAndCompanionIds(this.companionId);
    this.refreshingInterval = setInterval(() => {
      this.getMessagesByUserAndCompanionIds(this.companionId)
    }, 5000);
  }

  isUserSender(i: number) {
    let userId = this.tokenService.getId();
    return this.messages[i].senderId == userId;
  }

  sendMessage() {
    let value = this.sendMessageFormGroup.value;
    let request = {
      ...value,
      companionId: this.companionId
    } as CreateMessageDto;
    this.http.createMessage(request).subscribe(() => {
      this.messages.push({
        senderId: this.tokenService.getId(),
        recipientId: this.companionId,
        sendingTime: new Date(),
        text: value.text,
        isMessageRead: false
      })
    })
  }

  getMessagesByUserAndCompanionIds(companionId: number) {
    this.http.getMessagesByUserAndCompanionIds(companionId).subscribe(messages => this.messages = messages)
  }


  goToChats() {
    this.router.navigate(['chats']).then(()=>{ clearInterval(this.refreshingInterval)})
  }
}
