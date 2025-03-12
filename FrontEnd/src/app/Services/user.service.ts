import { Injectable } from '@angular/core';
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

  getMessage(): string {
    return this.user.Name;
  }
}
