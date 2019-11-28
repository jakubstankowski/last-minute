package com.standev.lastminute.model;

public class Offer {
    private String id;
    private String url;
    private int maxPrice;
    private int minPrice;

    public Offer(String id, String url, int maxPrice, int minPrice) {
        this.id = id;
        this.url = url;
        this.maxPrice = maxPrice;
        this.minPrice = minPrice;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public int getMaxPrice() {
        return maxPrice;
    }

    public void setMaxPrice(int maxPrice) {
        this.maxPrice = maxPrice;
    }

    public int getMinPrice() {
        return minPrice;
    }

    public void setMinPrice(int minPrice) {
        this.minPrice = minPrice;
    }
}
