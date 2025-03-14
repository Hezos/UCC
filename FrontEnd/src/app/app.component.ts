import { Component, OnInit, inject } from '@angular/core';
import { Event, User } from './Types';
import { UserService } from './Services/user.service';
import { EventService } from './Services/event.service';
import { CheckboxRequiredValidator } from '@angular/forms';
import emailjs, { send } from '@emailjs/browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'UCC apply webapage';

  Alphabet: Array<string> = [
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l','m', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
  ];

  verificationNumber: number = 0;

  userService = inject(UserService);
  eventService = inject(EventService);

  ngOnInit(): void {
    this.displayUser = {
      id: "",
      Name: "",
      Password: "",
      JWT: "",
      Datacoder:1
    };
    this.userService.getUsers().subscribe({
      next: Users => {
        this.users = Users;
        console.log("Loaded users.");
        console.log(this.users);
      }
    });
    //Start decrypting here in the future
    //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/random
    //console.log(this.DataEncryption("password", Math.floor(Math.random() * this.Alphabet.length)));
    
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

  //2FA valid
  factorValid: boolean = false;

  //2FA
  authText: string = "";

  displayUser: User = {
    id: "",
    Name: "",
    Password: "",
    JWT: "",
    Datacoder:1
  }

  users: Array<User> = [];

  eventList: Array<Event> = [];


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
      JWT: "",
      Datacoder:1     
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

  handleAuthText(value: any): void {
    this.authText = value.value;
  }

  login(): void
  {
    for (var index in this.users) {
      if (this.DataDecryption(this.users[index].Datacoder, this.users[index].Password) == this.password &&
        this.users[index].Name == this.username) {
        //Login for now
        this.displayUser = this.users[index];
        this.displayUser.JWT = "";
        console.log(this.DataDecryption(this.users[index].Datacoder, this.users[index].Password));
      }
    }
    this.verificationNumber = Math.floor(Math.random() * 10);
    this.sendEmail(this.verificationNumber.toString());
  }

  //Submit button for 2FA:
  confirmLogin(): void {
    if (Number(this.authText) == this.verificationNumber) {
      this.revealEvents();
      this.displayUser.JWT = this.users.find(_ => _.id == this.displayUser.id)?.JWT || "1";
      console.log(this.displayUser.JWT);

      this.eventService.getByUser(this.displayUser.id, this.displayUser.JWT).subscribe({
        next: Events => {
          this.eventList = Events;
          console.log(this.eventList);
        }
      });
    }
    //End of login functionality

  }


  DataEncryption(original: String, shift: number): string
  {
    var result: String = '';
    //Need 2 points where is in the alphabet, and where the solution will be.
    var oPositions: Array<number> = [];
    for (let index in original)
    {
      for (let char in this.Alphabet)
      {
        if (original[index] == this.Alphabet[char])
        {
          oPositions.push(Number(char));
        }
      }      
    }

    //If the index points way beyond the length of the array start over the counting
    for (let index in oPositions)
    {
        if (oPositions[index] + shift - 1 < this.Alphabet.length)
        {
          result += this.Alphabet[oPositions[index] + shift];
        }
        else
        {
          result += this.Alphabet[oPositions[index] + shift - this.Alphabet.length];
        }
      
    }

    return result.toString();
  }

  DataDecryption(shift: number, Encoded:String): string
  {
    var result: String = '';
    var oPositions: Array<number> = [];
    for (let index in Encoded) {
      for (let char in this.Alphabet) {
        if (Encoded[index] == this.Alphabet[char]) {
          oPositions.push(Number(char));
        }
      }
    }

    //If the index points way beyond the length of the array start over the counting
    for (let index in oPositions) {
      //Maybe >= 0
      if (oPositions[index] - shift - 1 > 0) {
        result += this.Alphabet[oPositions[index] - shift];
      }
      else {
        result += this.Alphabet[oPositions[index] - shift + this.Alphabet.length];
      }

    }
    return result.toString();
  }

  //https://www.npmjs.com/package/@emailjs/browser
  //https://www.emailjs.com/docs/sdk/installation/
  async sendEmail(code: string): Promise<any> {
    emailjs.init("Jx0WTFsHz1RYtXBxb");
    let response = await emailjs.send("service_hmsq2km", "template_6bborgf", {
      name: "User",
      title: code,
      email: "nbence0620@gmail.com",
    });

    console.log(response);
  }

}
