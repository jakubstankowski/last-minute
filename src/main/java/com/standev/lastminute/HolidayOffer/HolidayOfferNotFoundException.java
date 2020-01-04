package com.standev.lastminute.HolidayOffer;

public class HolidayOfferNotFoundException extends RuntimeException {
    public HolidayOfferNotFoundException(Integer id){
        super("Holiday Offer with id: " + id + " not found!");
    }
}
