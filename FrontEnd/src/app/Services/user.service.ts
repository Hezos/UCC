import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { User } from '../Types';


@Injectable({
  providedIn: 'root'
})

export class UserService {
  constructor() { }

  http = inject(HttpClient);
  
  getUser() {
    return this.http.get<User>('https://localhost:7239/api/user');
  }

  resetPassword(userid: string, user: User) {
    return this.http.put<User>(`https://localhost:7239/api/user/${userid}`, user);
  }

  getUsers() {
    return this.http.get<Array<User>>('https://localhost:7239/api/user/all');
  }




}
