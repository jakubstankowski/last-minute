package com.standev.lastminute.holidayOffer;


import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class HolidayOffer {

    @Id
    private String url;
    private Integer minPrice;
    private Integer maxPrice;

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
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
