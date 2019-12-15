package com.standev.lastminute.holidayOffer;


import com.standev.lastminute.user.User;

import javax.persistence.*;

@Entity
public class HolidayOffer {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private String url;
    private Integer minPrice;
    private Integer maxPrice;


    @ManyToOne
    private User user;

    public HolidayOffer() {
    }


    public HolidayOffer(Integer id, String url, Integer minPrice, Integer maxPrice) {
        this.id = id;
        this.url = url;
        this.minPrice = minPrice;
        this.maxPrice = maxPrice;
        this.user = new User(id, "", "", "");
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getUrl() {
        return this.url;
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
