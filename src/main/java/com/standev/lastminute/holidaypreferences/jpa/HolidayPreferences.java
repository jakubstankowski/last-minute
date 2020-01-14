package com.standev.lastminute.holidaypreferences.jpa;


import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import com.standev.lastminute.holidayoffer.jpa.HolidayOffer;
import com.standev.lastminute.user.jpa.User;

import javax.persistence.*;
import java.util.Set;

@Entity
public class HolidayPreferences {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;



    private String holidayWebPage;
    private Integer minPrice;
    private Integer maxPrice;




    @JsonManagedReference
    @OneToMany(
            mappedBy = "holiday_preferences",
            cascade = CascadeType.ALL)
    private Set<HolidayOffer> holidayOffer;

    public Set<HolidayOffer> getHolidayOffer() {
        return holidayOffer;
    }

    public void setHolidayOffer(Set<HolidayOffer> holidayOffer) {
        this.holidayOffer = holidayOffer;
    }


    @JsonBackReference
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "user_id")
    private User user;


    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public String getHolidayWebPage() {
        return holidayWebPage;
    }

    public void setHolidayWebPage(String holidayWebPage) {
        this.holidayWebPage = holidayWebPage;
    }


    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getMinPrice() {
        return minPrice;
    }

    public void setMinPrice(Integer minPrice) {
        this.minPrice = minPrice;
    }

    public Integer getMaxPrice() {
        return maxPrice;
    }

    public void setMaxPrice(Integer maxPrice) {
        this.maxPrice = maxPrice;
    }


}
