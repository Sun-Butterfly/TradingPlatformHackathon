import {Routes} from '@angular/router';
import {HomePageComponent} from './home-page/home-page.component';
import {RegisterPageComponent} from './register-page/register-page.component';
import {LoginPageComponent} from './login-page/login-page.component';
import {BuyerPageComponent} from './buyer-page/buyer-page.component';
import {SupplierPageComponent} from './supplier-page/supplier-page.component';

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
    path: '**',
    redirectTo: 'home'
  }


];
