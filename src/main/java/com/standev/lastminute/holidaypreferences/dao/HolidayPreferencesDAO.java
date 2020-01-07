package com.standev.lastminute.holidaypreferences.dao;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import org.springframework.data.jpa.repository.JpaRepository;

public interface HolidayPreferencesDAO extends JpaRepository<HolidayPreferences, Integer> {
    Iterable<HolidayPreferences> findByUserId(Integer userId);
}
