package com.standev.lastminute.holidayoffer.service;
import com.standev.lastminute.holidayoffer.dao.HolidayOfferDAO;
import com.standev.lastminute.holidayoffer.jpa.HolidayOffer;
import com.standev.lastminute.holidaypreferences.dao.HolidayPreferencesDAO;
import com.standev.lastminute.user.dao.UserDAO;
import com.standev.lastminute.user.jpa.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;


@Service
public class HolidayOfferService {


    @Autowired
    HolidayOfferDAO holidayOfferDAO;
    HolidayPreferencesDAO holidayPreferencesDAO;
    UserDAO userDAO;

    public HolidayOffer createHolidayOffer(HolidayOffer holidayOffer, Integer id, Integer userId) {
            User user = userDAO.findById(userId).orElse(null);

        System.out.println("user finddddd"+ user.getFirstName() + user.getId());


        return holidayOfferDAO.save(holidayOffer);
    }

}



