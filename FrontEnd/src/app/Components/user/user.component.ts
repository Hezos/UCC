import { Component, OnInit, inject } from '@angular/core';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})

export class UserComponent implements OnInit {

  displayText: string = "";

  userService = inject(UserService);

  ngOnInit(): void {
    this.displayText = this.userService.getMessage()
    }

}
