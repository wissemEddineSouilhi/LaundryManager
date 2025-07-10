import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { CardModule } from 'primeng/card';
import {Client, LoginDto} from '../../api/api-client'
import { Router } from '@angular/router';
@Component({
  selector: 'app-login-page',
  imports: [
    CommonModule,
    FormsModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
    CardModule
  ],
  templateUrl: './login-page.html',
  styleUrl: './login-page.scss',
})
export class LoginPage {
  // constructor(private client : Client , private router: Router){}
  constructor(
    private client: Client,
    private router: Router,
  ) {}

  email = '';
  password = '';
  error = '';

  login() {
    console.log('Logging in:', this.email, this.password);
    const logindto = new LoginDto() ;    
    logindto.userName= this.email,
    logindto.password= this.password
  
    this.client.login(logindto).subscribe({
       next: (response) => {
        // Save token to localStorage/sessionStorage
        if(response.tokenJwt !== undefined){
          localStorage.setItem('accessToken', response.tokenJwt?.toString());
          // Navigate or update app state
        this.router.navigate(['']);
        }
        
        
      },
      error: (err) => {
        this.error = 'Invalid username or password';
        console.error('Login failed', err);
      },
    });
  }
}
