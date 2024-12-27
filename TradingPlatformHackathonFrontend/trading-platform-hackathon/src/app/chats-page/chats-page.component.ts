import {Component, OnInit} from '@angular/core';
import {NgForOf, NgIf} from '@angular/common';
import {ChatInfo, HttpService} from '../../http.service';
import {Router} from '@angular/router';
import {TokenService} from '../../token.service';

@Component({
  selector: 'app-chats-page',
  standalone: true,
  imports: [
    NgForOf,
    NgIf
  ],
  templateUrl: './chats-page.component.html',
  styleUrl: './chats-page.component.scss'
})
export class ChatsPageComponent implements OnInit {
  chats: ChatInfo[] = [];
  activeChatIndex: number = -1;
  refreshingInterval: number = -1;

  constructor(private http: HttpService, private router: Router, private tokenService: TokenService) {
  }

  ngOnInit(): void {
    this.getChatsInfoByUserId()
    this.refreshingInterval = setInterval(() => {
      this.getChatsInfoByUserId()
    }, 5000);
  }

  goToChat(i: number) {
    this.router.navigate(['dialog']).then(() => {
      if (this.refreshingInterval != -1) {
        clearInterval(this.refreshingInterval)
      }
    });
  }

  setActiveChatIndex(i: number) {
    if (this.activeChatIndex === i) {
      this.activeChatIndex = -1;
    } else {
      this.activeChatIndex = i;
    }
  }

  getChatsInfoByUserId() {
    this.http.getChatsInfoByUserId().subscribe(chats => this.chats = chats)
  }
}
