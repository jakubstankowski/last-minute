import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../core/services/auth.service';

@Component({
  selector: 'app-profile-details',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.css']
})
export class ProfileDetailsComponent implements OnInit {

  fullName: string;
  email: string;
  alias: string;

  constructor(private authService: AuthenticationService) { }

  ngOnInit() {
    this.fullName = 'test';
    this.email = 'test';
  }

}
