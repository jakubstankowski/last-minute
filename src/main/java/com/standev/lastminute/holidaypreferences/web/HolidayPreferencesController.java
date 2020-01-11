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

  /*  @DeleteMapping("/instructors/{instructorId}/courses/{courseId}")
    public ResponseEntity << ? > deleteCourse(@PathVariable(value = "instructorId") Long instructorId,
                                              @PathVariable(value = "courseId") Long courseId) throws ResourceNotFoundException {
        return courseRepository.findByIdAndInstructorId(courseId, instructorId).map(course - > {
                courseRepository.delete(course);
        return ResponseEntity.ok().build();
        }).orElseThrow(() - > new ResourceNotFoundException(
                "Course not found with id " + courseId + " and instructorId " + instructorId));
    }*/

  /*  @DeleteMapping("/instructors/{instructorId}/courses/{courseId}")
    public ResponseEntity << ? > deleteCourse(@PathVariable(value = "instructorId") Long instructorId,
                                              @PathVariable(value = "courseId") Long courseId) throws ResourceNotFoundException {
        return courseRepository.findByIdAndInstructorId(courseId, instructorId).map(course - > {
                courseRepository.delete(course);
        return ResponseEntity.ok().build();
        }).orElseThrow(() - > new ResourceNotFoundException(
                "Course not found with id " + courseId + " and instructorId " + instructorId));
    }*/


   /* @DeleteMapping("/api/users/{id}")
    public void deleteUser(@PathVariable("id") Integer id)  {
        userService.deleteUser(id);
    }
*/

   /* @GetMapping()
    public Iterable<User> getAllUsers() {
        return userService.getAllUsers();
    }*/

   /* @GetMapping("/{id}")
    public User getUser(@PathVariable("id") Integer id)  {
        return userService.getUser(id);
    }
*/
  /*  @PostMapping()
    public User createUser(@RequestBody User user) {
        return userService.createUser(user);
    }*/

    /*@DeleteMapping("/{id}")
    public void deleteUser(@PathVariable("id") Integer id)  {
        userService.deleteUser(id);
    }

    @PutMapping("/{id}")
    public User updateUser(@RequestBody User newUser, @PathVariable("id") Integer id) {
        return userService.updateUser(id, newUser);
    }
    */
}
