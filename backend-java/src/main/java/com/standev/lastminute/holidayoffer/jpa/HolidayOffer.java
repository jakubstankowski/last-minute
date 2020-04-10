package com.standev.lastminute.holidayoffer.jpa;
import com.fasterxml.jackson.annotation.JsonBackReference;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;



import javax.persistence.*;


@Entity
public class HolidayOffer {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private String url;


    @JsonBackReference
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "holidayPreferencesId")
    private HolidayPreferences holidayPreferences;

    public HolidayPreferences getHolidayPreferences() {
        return holidayPreferences;
    }

    public void setHolidayPreferences(HolidayPreferences holidayPreferences) {
        this.holidayPreferences = holidayPreferences;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }
}
