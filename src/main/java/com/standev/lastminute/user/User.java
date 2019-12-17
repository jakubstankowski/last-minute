package com.standev.lastminute.user;


import com.standev.lastminute.holidayOffer.HolidayOffer;

import javax.persistence.*;
import java.util.List;
import java.util.Set;

@Entity
public class User {

    @Id
    @GeneratedValue(strategy= GenerationType.AUTO)
    private Integer id;
    private String firstName;
    private String lastName;
    private String email;

    public User() {
    }

    public User(Integer id, String firstName, String lastName, String email){
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }



    @OneToMany(cascade=CascadeType.ALL)
    private List<HolidayOffer> holidayOffers;

    public List<HolidayOffer> getHolidayOffer() {
        return holidayOffers;
    }

    public void setHolidayOffer(List<HolidayOffer> holidayOffer) {
        this.holidayOffers = holidayOffer;
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
