import { Component, OnInit } from '@angular/core';
import {ArticleTypeDto, Client, CreateCommandDto, CreateUserDto, LoginDto} from '../../api/api-client'
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators,FormsModule, ReactiveFormsModule, FormArray } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { FloatLabel } from 'primeng/floatlabel';
import {CommonModule} from '@angular/common';
import { Select } from 'primeng/select';
import { Observable, throwError as _observableThrow, of } from 'rxjs';
@Component({
  selector: 'app-create-command-page',
  imports: [FormsModule,ReactiveFormsModule,CardModule,InputTextModule,PasswordModule,ButtonModule,CommonModule,Select],
  templateUrl: './create-command-page.html',
  styleUrl: './create-command-page.css'
})


export class CreateCommandPage implements OnInit  {

  
commandForm!: FormGroup;
articleTypes: ArticleTypeDto[] = [];
  

  constructor(private fb: FormBuilder,  private client: Client, private router: Router,) {}
  
  ngOnInit(): void {
    this.initForm();
      this.loadArticleTypes();
  }


  initForm(): void {
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
      name: ['', Validators.required],
      description: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      articleTypeId: [null, Validators.required]
    });
    this.articles.push(articleGroup);
  }

  removeArticle(index: number): void {
    this.articles.removeAt(index);
  }

  loadArticleTypes(): void {
    this.client.getArticleTypes().subscribe({
      next: (data) => this.articleTypes = data,
      error: (err) => console.error('Error loading article types', err)
    });
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
        
        alert('command creation failed: ' + err.message)
      },
    });      
    }
  }

}
