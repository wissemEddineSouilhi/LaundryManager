import { Component, OnInit } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, Validators,ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { CardModule } from 'primeng/card';
import {Client, LoginDto} from '../../api/api-client'
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-login-page',
  imports: [
    CommonModule,
    FormsModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
    CardModule,
    RouterModule,
    ReactiveFormsModule
  ],
  templateUrl: './login-page.html',
  styleUrl: './login-page.scss',
})
export class LoginPage implements OnInit {
  loginForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private client: Client,
    private router: Router,
  ) {}
  ngOnInit(): void {
     this.loginForm = this.fb.group({
      userName: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }


  login() {
    if (this.loginForm.valid) {
      const formValues = this.loginForm.value;
      const logindto = new LoginDto(formValues);
      this.client.login(logindto).subscribe({
       next: (response) => {

        if(response.tokenJwt !== undefined){
          localStorage.setItem('accessToken', response.tokenJwt?.toString());
    
        this.router.navigate(['']);
        }
        
        
      },
      error: (err) => {
        alert('Authentication failed: ' + err.message)
      },
    });
    }
  
    
  }
}
