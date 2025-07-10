import { Component, OnInit } from '@angular/core';
import {Client, CreateCommandDto, CreateUserDto, LoginDto} from '../../api/api-client'
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators,FormsModule, ReactiveFormsModule, FormArray } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { FloatLabel } from 'primeng/floatlabel';
import {CommonModule} from '@angular/common';
import { Select } from 'primeng/select';

@Component({
  selector: 'app-create-command-page',
  imports: [FormsModule,ReactiveFormsModule,CardModule,InputTextModule,PasswordModule,ButtonModule,CommonModule,Select],
  templateUrl: './create-command-page.html',
  styleUrl: './create-command-page.css'
})


export class CreateCommandPage implements OnInit  {

  
commandForm!: FormGroup;
articleTypes: ArticleTypeDto[] = [
  { id: '6f9619ff-8b86-d011-b42d-00cf4fc964ff', name: 'Type A' },
  { id: '7f9619ff-8b86-d011-b42d-00cf4fc964ff', name: 'Type B' },
  { id: '8f9619ff-8b86-d011-b42d-00cf4fc964ff', name: 'Type C' },
];
  

  constructor(private fb: FormBuilder,  private client: Client, private router: Router,) {}
  
  ngOnInit(): void {
    this.commandForm = this.fb.group({
      reason: [''],
      comment: [''],
      articles: this.fb.array([]),
    });
  }


  get articles(): FormArray {
    return this.commandForm.get('articles') as FormArray;
  }

  addArticle(): void {
    const articleGroup = this.fb.group({
      articleName: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      articleTypeId: [null, Validators.required]
    });
    this.articles.push(articleGroup);
  }

  removeArticle(index: number): void {
    this.articles.removeAt(index);
  }

  submit(): void {
    if (this.commandForm.valid) {
      const formValues = this.commandForm.value;
      const newCommand = new CreateCommandDto(formValues);

      this.client.createCommand(newCommand).subscribe({
       next: (response) => {
        alert('command created successfully!')
        
      },
      error: (err) => {
        
        alert('cmand creation failed: ' + err.message)
      },
    });      
    }
  }

}
