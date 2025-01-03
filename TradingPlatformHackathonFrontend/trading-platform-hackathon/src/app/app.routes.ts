import {Routes} from '@angular/router';
import {HomePageComponent} from './home-page/home-page.component';
import {RegisterPageComponent} from './register-page/register-page.component';
import {LoginPageComponent} from './login-page/login-page.component';
import {BuyerPageComponent} from './buyer-page/buyer-page.component';
import {SupplierPageComponent} from './supplier-page/supplier-page.component';
import {
  CreatePurchaseRequestPageComponent
} from './create-purchase-request-page/create-purchase-request-page.component';
import {CreatePurchaseResponseComponent} from './create-purchase-response/create-purchase-response.component';
import {BuyerPersonalAccountPageComponent} from './buyer-personal-account-page/buyer-personal-account-page.component';
import {
  SupplierPersonalAccountPageComponent
} from './supplier-personal-account-page/supplier-personal-account-page.component';
import {
  RedactPurchaseRequestPageComponent
} from './redact-purchase-request-page/redact-purchase-request-page.component';
import {ChatsPageComponent} from './chats-page/chats-page.component';
import {DialogPageComponent} from './dialog-page/dialog-page.component';
import {CreateMessagePageComponent} from './create-message-page/create-message-page.component';

export const routes: Routes = [
  {
    path: '',
    component: HomePageComponent
  },

  {
    path: 'home',
    component: HomePageComponent
  },
  {
    path: 'register',
    component: RegisterPageComponent
  },
  {
    path: 'login',
    component: LoginPageComponent
  },
  {
    path: 'buyer',
    component: BuyerPageComponent
  },
  {
    path: 'supplier',
    component: SupplierPageComponent
  },
  {
    path: 'create-purchase-request',
    component: CreatePurchaseRequestPageComponent
  },
  {
    path: 'create-purchase-response/:id',
    component: CreatePurchaseResponseComponent
  },
  {
    path: 'account_b',
    component: BuyerPersonalAccountPageComponent
  },
  {
    path: 'account_s',
    component: SupplierPersonalAccountPageComponent
  },
  {
    path: 'redact-purchase-request/:id',
    component: RedactPurchaseRequestPageComponent
  },
  {
    path: 'chats',
    component: ChatsPageComponent
  },
  {
    path: 'dialog/:id',
    component: DialogPageComponent
  },
  {
    path: 'create-message',
    component: CreateMessagePageComponent
  },
  {
    path: '**',
    redirectTo: 'home'
  }


];
