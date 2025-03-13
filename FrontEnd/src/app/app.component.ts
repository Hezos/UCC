import { Component, inject } from '@angular/core';
import { Event, User } from './Types';
import { UserService } from './Services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'UCC apply webapage';

  userService = inject(UserService);

  resetPass: boolean = false;
  showEvents: boolean = false;

  displayUser: User = {
    id: "",
    Name: "",
    Password: "",
    jwt:""
  }

  eventList: Array<Event> = [
    {
        id: '2',
        Occurrence: '2025/03/14',
      Title: 'Test1',
      UserId:""
    },
    {
        id: '3',
        Occurrence: '2025/02/14',
      Title: 'Test2',
      UserId:""
    }
  ];


  resetPassword() {
    //Call the update on User
    this.resetPass = false;
    this.showEvents = false;
    alert("Your password was reset!");
  }

  showPassReset(): void {
    this.resetPass = true;
  }

  revealEvents(): void {
    //Check if user is not null here!
    this.showEvents = true;
  }

  logout(): void {
    this.displayUser = {
      id: "",
        Name: "",
      Password: "",
      jwt:""
    }
    this.showEvents = false;
  }

  login(): void
  {
    this.userService.getUser().subscribe({
      next: user => {
        console.log(user);
        this.displayUser = user;
      }
    });
    this.revealEvents();
    
  }
    
}
