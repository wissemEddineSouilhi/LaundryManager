import { Component,OnInit } from '@angular/core';
import { RouterOutlet,Router } from '@angular/router';
import { Menubar  } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import {CommonModule} from '@angular/common';
import{AuthService} from './services/auth-service'

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Menubar,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit{
  constructor(public router: Router ,private authService: AuthService) {}
  protected title = 'LaundryManager.Client';
 items: MenuItem[] | undefined;

    ngOnInit() {
        this.items = [
            {
                label: 'Aceuil',
                icon: 'pi pi-home',
                routerLink: ['/home']
            },
            {
                label: 'Deconnecter',
                icon: 'pi pi-sign-out',
                command: () => this.logout()
            }
        ]

      }

  get hideLayout(): boolean {

    const routes = ['/login', '/register']; 
    return routes.includes(this.router.url);
    
  }

  logout(){
    this.authService.removeToken();
     this.router.navigate(['/login']);
  }
}
