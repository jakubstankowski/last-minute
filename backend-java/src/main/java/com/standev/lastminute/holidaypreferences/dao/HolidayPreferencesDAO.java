package com.standev.lastminute.holidaypreferences.dao;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import org.springframework.data.jpa.repository.JpaRepository;

import javax.swing.text.html.Option;
import java.util.Optional;

public interface HolidayPreferencesDAO extends JpaRepository<HolidayPreferences, Integer> {
    Iterable<HolidayPreferences> findByUserId(Integer userId);
    Optional<HolidayPreferences> findByIdAndUserId(Integer id, Integer userId);



}
