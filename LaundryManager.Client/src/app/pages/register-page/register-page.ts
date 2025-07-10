import { Component, OnInit } from '@angular/core';
import {Client, CreateUserDto, LoginDto} from '../../api/api-client'
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators,FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { FloatLabel } from 'primeng/floatlabel';

@Component({
  selector: 'app-register-page',
  imports: [FormsModule,ReactiveFormsModule,CardModule,InputTextModule,PasswordModule,ButtonModule],
  templateUrl: './register-page.html',
  styleUrl: './register-page.css'
})
export class RegisterPage implements OnInit {

  registerForm!: FormGroup;

  constructor(private fb: FormBuilder,  private client: Client, private router: Router) {}
  
  
  ngOnInit(): void {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', Validators.required]
    });
  }

   onSubmit() {
    if (this.registerForm.valid) {
      const formValues = this.registerForm.value;
      const newUser = new CreateUserDto(formValues);

      this.client.register(newUser).subscribe({
       next: (response) => {
        alert('User registered successfully!')
        
      },
      error: (err) => {
        
        alert('Registration failed: ' + err.message)
      },
    });      
    }
  }

}
