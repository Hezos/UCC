import { Component, OnInit, inject } from '@angular/core';
import { Event, User } from './Types';
import { UserService } from './Services/user.service';
import { EventService } from './Services/event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'UCC apply webapage';

  userService = inject(UserService);
  eventService = inject(EventService);

  ngOnInit(): void {
    this.displayUser = {
      id: "",
      Name: "",
      Password: "",
      jwt: ""
    };
    this.userService.getUsers().subscribe({
      next: Users => {
        this.users = Users;
        console.log("Loaded users.");
        console.log(this.users);
      }
    });
    //Start decrypting here in the future

  }

  resetPass: boolean = false;
  showEvents: boolean = false;

  //Visible user info
  username?: string = "";
  password?: string = "";

  //Password reset option:
  newpassword: string = "";
  newpasswordconfirm: string = "";

  //Event edit option:
  description: string = "";
  eventname: string = "";
  eventoccurrence: string = "";

  displayUser: User = {
    id: "",
    Name: "",
    Password: "",
    jwt:""
  }

  users: Array<User> = [];

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

  handleUserNameText(value: any): void {
    this.username = value.value;
  }

  handlePasswordText(value: any): void {
    this.password = value.value;
  }

  handleResetText(value: any): void {
    this.newpassword = value.value;
  }

  handleValidationText(value: any): void {
    this.newpasswordconfirm = value.value;
  }

  handleTitleText(value: any): void {
    this.eventname = value.value;
  }

  handleDateText(value: any): void {
    this.eventoccurrence = value.value.toString();
  }

  handleDescriptionText(value: any): void {
    this.description = value.value;
  }



  login(): void
  {
    /*
    this.userService.getUser().subscribe({
      next: user => {
        console.log(user);
        this.displayUser = user;
      }
    });
    */
    for (var index in this.users) {
      if (this.users[index].Password == this.password && this.users[index].Name == this.username) {
        //Login for now
        this.displayUser = this.users[index];
      }
      else {
        console.log("Didn't find any user.");
      }
    }
    this.revealEvents();
    console.log(this.displayUser);
  }
    
}
