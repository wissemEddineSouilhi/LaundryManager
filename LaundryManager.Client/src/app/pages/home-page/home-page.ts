import { Component, OnInit } from '@angular/core';
import { Client, CommandDto } from '../../api/api-client';
import { Router } from '@angular/router';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { Tag } from 'primeng/tag'; 
import { Popover } from 'primeng/popover';
import { PopoverModule } from 'primeng/popover';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';


@Component({
  selector: 'app-home-page',
  imports: [TableModule, CommonModule,CardModule,Tag,PopoverModule,DialogModule,ButtonModule],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage implements OnInit {

constructor( private client: Client, private router: Router,) {}
commands: CommandDto[] = [];
    ngOnInit() {
       this.loadCommands();
   
  }

  dialogVisible: boolean = false;
  selectedCommand: CommandDto = new CommandDto();

    loadCommands(): void {
    this.client.getCommands().subscribe({
      next: (data) => this.commands = data,
      error: (err) => console.error('Error loading comands', err)
    });
  }


  getStatusSeverity(status: string): string {
    switch (status.toLowerCase()) {
      case 'approved':
        return 'success';
      case 'pending':
        return 'warning';
      case 'rejected':
        return 'danger';
      default:
        return 'info';
    }
  
  }




showDetails(command: CommandDto) {
  this.selectedCommand = command;
  this.dialogVisible = true;
}

}
