import { Routes } from '@angular/router';
import { LoginPage } from './pages/login-page/login-page';

export const routes: Routes = [

  {
    path: 'home',
    loadComponent: () =>
      import('./pages/home-page/home-page').then(m => m.HomePage)
  },
    {
    path: 'login',
    loadComponent: () =>
      import('./pages/login-page/login-page').then(m => m.LoginPage)
  },
  {
    path: 'create-command',
    loadComponent: () =>
      import('./pages/create-command-page/create-command-page').then(m => m.CreateCommandPage)
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./pages/register-page/register-page').then(m => m.RegisterPage)
  },
   { path: '', redirectTo: 'home', pathMatch: 'full' }

];
