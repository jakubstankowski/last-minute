package com.standev.lastminute.HolidayPreferences;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserHolidayPreferencesDAO extends JpaRepository<UserHolidayPreferences, Integer> {
    Iterable<UserHolidayPreferences> findByUserId(Integer userId);
}
