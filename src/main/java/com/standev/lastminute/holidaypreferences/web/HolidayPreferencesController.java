package com.standev.lastminute.holidaypreferences.web;


import com.standev.lastminute.holidaypreferences.service.HolidayPreferencesService;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping(value = "/api/users")
public class HolidayPreferencesController {


    @Autowired
    private HolidayPreferencesService holidayPreferencesService;


    @PostMapping("/{userId}/holiday-preferences")
    public HolidayPreferences createHolidayPreferences(@RequestBody HolidayPreferences holidayPreferences, @PathVariable("userId") Integer userId) {
        return holidayPreferencesService.createUserHolidayPreferences(holidayPreferences, userId);

    }

    @GetMapping("/{userId}/holiday-preferences")
    public Iterable<HolidayPreferences> getHolidayPreferencesByUser(@PathVariable(value = "userId") Integer userId) {
        return holidayPreferencesService.getHolidayPreferencesByUserId(userId);

    }

    @GetMapping("/{userId}/holiday-preferences/{id}")
    public Optional<HolidayPreferences> getHolidayPreference(@PathVariable(value = "userId") Integer userId, @PathVariable(value = "id") Integer id) {
        return holidayPreferencesService.getHolidayPreference(id, userId);

    }

    @DeleteMapping("/{userId}/holiday-preferences/{id}")
    public void deleteHolidayPreference(@PathVariable("userId") Integer userId, @PathVariable("id") Integer id) {
        holidayPreferencesService.deleteHolidayPreference(id, userId);
    }

    @PutMapping("/{userId}/holiday-preferences/{id}")
    public HolidayPreferences updateHolidayPreference(@PathVariable("id") Integer id, @RequestBody HolidayPreferences newHolidayPreference){
       return  holidayPreferencesService.updateHolidayPreference(id, newHolidayPreference);
    }
}
