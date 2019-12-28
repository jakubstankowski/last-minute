package com.standev.lastminute.HolidayOffer;


import com.fasterxml.jackson.annotation.JsonBackReference;
import com.standev.lastminute.User.User;

import javax.persistence.*;

@Entity
public class HolidayOffer {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private String url;
    private Integer minPrice;
    private Integer maxPrice;



    @JsonBackReference
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name="user_id")
    private User user;


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
