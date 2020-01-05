/*
package com.standev.lastminute.HolidayOffer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(value = "/api/users")
public class HolidayOfferController {
    @Autowired
    private HolidayOfferService holidayOfferService;

    @GetMapping("/{userId}/holiday-offers")
    public Iterable<HolidayOffer> getHolidayOffersByUser(@PathVariable(value = "userId") Integer userId) {
        return holidayOfferService.getHolidayOffersByUserId(userId);

    }

    @GetMapping("/{userId}/holiday-offers/{id}")
    public HolidayOffer getHolidayOffer(@PathVariable("id") Integer id) {
        return holidayOfferService.getHolidayOffer(id);
    }

   */
/* @PostMapping("/{userId}/holiday-offers")
    public HolidayOffer createHolidayOffer(@RequestBody HolidayOffer holidayOffer, @PathVariable("userId") Integer userId) {
        return holidayOfferService.createHolidayOffer(holidayOffer, userId);
    }
*//*

    @PutMapping("/{userId}/holiday-offers")
    public HolidayOffer updateHolidayOffer(@RequestBody HolidayOffer newHolidayOffer, @PathVariable("userId") Integer userId) {
        return holidayOfferService.updateHolidayOffer(userId, newHolidayOffer);
    }


}
*/
