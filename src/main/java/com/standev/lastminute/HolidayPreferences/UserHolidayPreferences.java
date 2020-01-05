package com.standev.lastminute.HolidayPreferences;


import com.fasterxml.jackson.annotation.JsonBackReference;
import com.standev.lastminute.User.User;

import javax.persistence.*;

@Entity
public class UserHolidayPreferences {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;



    private String holidayWebPage;
    private Integer minPrice;
    private Integer maxPrice;

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
