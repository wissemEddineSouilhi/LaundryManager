// auth.service.ts
import { Injectable } from '@angular/core';
import { jwtDecode } from "jwt-decode";

interface JwtPayload {
  role: string;  
  unique_name: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  getToken(): string | null {
    return localStorage.getItem('accessToken'); 
  }

  setToken(token: string){
     localStorage.setItem('accessToken',token);
  }

  removeToken(){
     localStorage.removeItem('accessToken');
  }

  isUserAdmin():boolean{
    let role = this.getUserRole();
    switch(role) {
      case 'Admin':
        return true;
      default:
        return false;
    }
  }
  getUserRole():  string | null {
    const token = this.getToken();
    if (!token) {
      return null;
    }
    try {
      const decoded = jwtDecode<JwtPayload>(token);
      return decoded.role || null;
    } catch (error) {
      console.error('Invalid token:', error);
      return null;
    }
  }
}
