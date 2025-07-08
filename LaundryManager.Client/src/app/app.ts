import { Component,OnInit } from '@angular/core';
import { RouterOutlet,Router } from '@angular/router';
import { Menubar  } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import {CommonModule} from '@angular/common';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Menubar,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit{
  constructor(public router: Router) {}
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
                label: 'create Command',
                icon: 'pi pi-star',
                routerLink: ['/create-command']
            },
            {
                label: 'Contactez Nous',
                icon: 'pi pi-envelope'
            }
        ]

      }

  get hideLayout(): boolean {
    return this.router.url === '/login';
  }
}
