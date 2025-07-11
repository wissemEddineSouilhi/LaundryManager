import { Component, OnInit } from '@angular/core';
import { Client, CommandDto, RejectCommandDto, ValidateCommandDto } from '../../api/api-client';
import { Router,RouterModule } from '@angular/router';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { Tag } from 'primeng/tag'; 
import { PopoverModule } from 'primeng/popover';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { AuthService } from '../../services/auth-service';



@Component({
  selector: 'app-home-page',
  imports: [TableModule, CommonModule,CardModule,Tag,PopoverModule,DialogModule,ButtonModule],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage implements OnInit {

commands: CommandDto[] = [];
dialogVisible: boolean = false;
selectedCommand: CommandDto = new CommandDto();

constructor( private client: Client, 
  private router: Router,
  private authService: AuthService) {}


    
  ngOnInit() {
    this.loadCommands();
  }


    loadCommands(): void {
      if (!this.isUserAdmin()) {
        
        this.client.getCommands().subscribe({
            next: (data) => this.commands = data,
            error: (err) => console.error('Error loading comands', err)
        });
      } else {

        this.client.getAllCommandsForAdmin().subscribe({
            next: (data) => this.commands = data,
            error: (err) => console.error('Error loading comands', err)
        });
      }
    
  }



  getStatusSeverity(status: string): string {
  
    if (status===undefined) {
      return ""
    }
    switch (status.toLowerCase()) {
      case 'valid':
        return 'success';
      case 'pending':
        return 'contrast';
      case 'invalid':
        return 'danger';
      default:
        return 'info';
    }
  
  }

  showValidateButton(status: string){
      return this.isUserAdmin() && status.toLowerCase()!== "valid"
  }

  showRejectButton(status: string){
      return this.isUserAdmin() && status.toLowerCase()!== "invalid"
  }

  getSelectedComandSeverity(): string{
    return this.getStatusSeverity(this.selectedCommand!.statusName!)
  }




showDetails(command: CommandDto) {
  this.selectedCommand = command;
  this.dialogVisible = true;
}

goToCreatePage(): void {
  this.router.navigate(['/create-command']); // ← modifie l'URL selon ta route
}

isUserAdmin():boolean{
  return this.authService.isUserAdmin();
}

ValidateComand(id:string){
  if (this.isUserAdmin()) {
        let validateCommandDto: ValidateCommandDto = new ValidateCommandDto();
        validateCommandDto.commandId = id;
        
        this.client.validateCommand(validateCommandDto).subscribe({
           next: () => {
                this.loadCommands();
            },
            error: (err) => console.error('Error', err)
        });
      }
}

RejectComand(id:string){
if (this.isUserAdmin()) {
        let rejectCommandDto: RejectCommandDto = new RejectCommandDto();
        rejectCommandDto.commandId = id;
        
        this.client.rejectCommand(rejectCommandDto).subscribe({
           next: () => {
                this.loadCommands();
            },
            error: (err) => console.error('Error', err)
        });
      }
}
}
