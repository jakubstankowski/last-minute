package com.standev.lastminute.User;


import com.fasterxml.jackson.annotation.JsonManagedReference;
import com.standev.lastminute.HolidayPreferences.UserHolidayPreferences;

import javax.persistence.*;
import java.util.Set;

@Entity
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private String firstName;
    private String lastName;
    private String email;

    public User() {
    }

    public User(Integer id, String firstName, String lastName, String email) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }

    @JsonManagedReference
    @OneToMany(
            mappedBy = "user",
            cascade = CascadeType.ALL)
    private Set<UserHolidayPreferences> userHolidayPreferences;

    public Set<UserHolidayPreferences> getUserHolidayPreferences() {
        return userHolidayPreferences;
    }
    public void setUserHolidayPreferences(Set<UserHolidayPreferences> userHolidayPreferences) {
        this.userHolidayPreferences = userHolidayPreferences;
    }


    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

}
