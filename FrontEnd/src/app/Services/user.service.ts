import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { User } from '../Types';


@Injectable({
  providedIn: 'root'
})


export class UserService {
  user: User = {
    id: "1",
    Name: "Test",
    Password: "Password"
  }
  constructor() { }

  http = inject(HttpClient);

  getMessage(): string {
    return this.user.Name;
  }

  getUser() {
    return this.http.get<User>('https://localhost:7274/api/user');
  }
}
