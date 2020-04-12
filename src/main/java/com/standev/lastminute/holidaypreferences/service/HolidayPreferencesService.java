package com.standev.lastminute.holidaypreferences.service;

import com.standev.lastminute.holidayoffer.jpa.HolidayOffer;
import com.standev.lastminute.holidayoffer.service.HolidayOfferService;
import com.standev.lastminute.holidaypreferences.dao.HolidayPreferencesDAO;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import com.standev.lastminute.user.jpa.User;
import com.standev.lastminute.user.dao.UserDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.util.Optional;


@Service
public class HolidayPreferencesService {

    @Autowired
    HolidayPreferencesDAO holidayPreferencesDAO;
    @Autowired
    UserDAO userDAO;

    @Autowired
    HolidayOfferService holidayOfferService;


    public HolidayPreferences createUserHolidayPreferences(HolidayPreferences holidayPreferences, Integer userId) {
        User user = userDAO.findById(userId).orElse(null);
        holidayPreferences.setUser(user);
        return holidayPreferencesDAO.save(holidayPreferences);

    }

    public Iterable<HolidayPreferences> getHolidayPreferencesByUserId(Integer userId) {
        return holidayPreferencesDAO.findByUserId(userId);
    }

    public Optional<HolidayPreferences> getHolidayPreference(Integer id, Integer userId) {
        return holidayPreferencesDAO.findByIdAndUserId(id, userId);
    }

    public void deleteHolidayPreference(Integer id, Integer userId) {

        //TODO bugs with delete the whole user object!
        holidayPreferencesDAO.findByIdAndUserId(id, userId)
                .map(course -> {
                    holidayPreferencesDAO.delete(course);
                    return ResponseEntity.ok().build();
                });
    }

    public HolidayPreferences updateHolidayPreference(Integer id, HolidayPreferences newHolidayPreference) {
        HolidayPreferences holidayPreferences = holidayPreferencesDAO.findById(id)
                .orElse(null);

        holidayPreferences.setHolidayWebPage(newHolidayPreference.getHolidayWebPage());
        holidayPreferences.setMinPrice(newHolidayPreference.getMinPrice());
        holidayPreferences.setMaxPrice(newHolidayPreference.getMaxPrice());

        return holidayPreferencesDAO.save(holidayPreferences);

    }

    /*public  void getHolidayOffers()
    {
        final String uri = "https://jsonplaceholder.typicode.com/todos/1";

        RestTemplate restTemplate = new RestTemplate();
        String result = restTemplate.getForObject(uri, String.class);

       *//* System.out.println(result);*//*
        HolidayOffer  holidayOffer = new HolidayOffer();
        holidayOffer.setUrl(result);

        holidayOfferService.createHolidayOffer(holidayOffer, 2,1);


    }*/
}

