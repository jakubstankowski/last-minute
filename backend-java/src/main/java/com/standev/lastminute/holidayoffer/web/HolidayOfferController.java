
package com.standev.lastminute.holidayoffer.web;

import com.standev.lastminute.holidayoffer.jpa.HolidayOffer;
import com.standev.lastminute.holidayoffer.service.HolidayOfferService;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import com.standev.lastminute.holidaypreferences.service.HolidayPreferencesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(value = "/api/users")
public class HolidayOfferController {

    /*@Autowired
    private HolidayPreferencesService holidayPreferencesService;


    @PostMapping("/{userId}/holiday-preferences")
    public HolidayPreferences createHolidayPreferences(@RequestBody HolidayPreferences holidayPreferences, @PathVariable("userId") Integer userId) {
        return holidayPreferencesService.createUserHolidayPreferences(holidayPreferences, userId);

    }*/

    @Autowired
    private HolidayOfferService holidayOfferService;

    @PostMapping("/{userId}/holiday-preferences/{id}/holiday-offer")
    public HolidayOffer createHolidayPreferences(@RequestBody HolidayOffer holidayOffer, @PathVariable("userId") Integer userId, @PathVariable("id") Integer id) {
        return holidayOfferService.createHolidayOffer(holidayOffer, id, userId);
    }

  /*  @GetMapping("/{userId}/holiday-preferences/{id}/holiday-offer")
    public Iterable<HolidayOffer> getHolidayPreferencesByUser(@PathVariable(value = "userId") Integer userId) {
        return holidayPreferencesService.getHolidayPreferencesByUserId(userId);

    }*/


}


