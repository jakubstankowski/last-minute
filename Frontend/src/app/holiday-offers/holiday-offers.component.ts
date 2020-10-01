import {Component, OnInit} from '@angular/core';
import {Offers} from './offers';
import {HolidayOffersService} from './holiday-offers.service';

@Component({
  selector: 'app-holiday-offers',
  templateUrl: './holiday-offers.component.html',
  styleUrls: ['./holiday-offers.component.scss']
})
export class HolidayOffersComponent implements OnInit {
  offers: Offers[];

  constructor(private holidayOffersService: HolidayOffersService) {
  }

  ngOnInit(): void {
    this.getOffers();
  }

  getOffers(): void {
    this.holidayOffersService.getOffers()
      .subscribe(offers => this.offers = offers);
  }

}
