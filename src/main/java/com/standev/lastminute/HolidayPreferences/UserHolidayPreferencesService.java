package com.standev.lastminute.HolidayPreferences;

import com.standev.lastminute.User.User;
import com.standev.lastminute.User.UserDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class UserHolidayPreferencesService {

    @Autowired
    UserHolidayPreferencesDAO userHolidayPreferencesDAO;
    @Autowired
    UserDAO userDAO;


    public UserHolidayPreferences createUserHolidayPreferences(UserHolidayPreferences userHolidayPreferences, Integer userId) {
        User user = userDAO.findById(userId).orElse(null);

        userHolidayPreferences.setUser(user);
        return userHolidayPreferencesDAO.save(userHolidayPreferences);

    }

    public Iterable<UserHolidayPreferences> getUserHolidayPreferencesByUserId(Integer userId) {
        return userHolidayPreferencesDAO.findByUserId(userId);
    }
}
