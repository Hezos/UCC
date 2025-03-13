import { Component, OnInit, inject } from '@angular/core';
import { UserService } from '../../Services/user.service';
import { User } from '../../Types';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})

export class UserComponent implements OnInit {

  displayUser: User = {
      id: "",
      Name: "",
      Password: "",
      jwt: ''
  }

  userService = inject(UserService);

  ngOnInit(): void {
    
     this.userService.getUser().subscribe({
       next: user => {
         console.log(user);
         this.displayUser = user;
      }
    });
    
    }

}
