import { Component, OnInit } from '@angular/core';
import { Client, CommandDto } from '../../api/api-client';
import { Router } from '@angular/router';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home-page',
  imports: [TableModule, CommonModule],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage implements OnInit {

constructor( private client: Client, private router: Router,) {}
commands: CommandDto[] = [];
    ngOnInit() {
       this.loadCommands();
   
  }

    loadCommands(): void {
    this.client.getCommands().subscribe({
      next: (data) => this.commands = data,
      error: (err) => console.error('Error loading comands', err)
    });
  }
}
