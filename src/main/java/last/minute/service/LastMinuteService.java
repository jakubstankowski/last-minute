package last.minute.service;

import last.minute.model.OffertURL;

public class LastMinuteService {
    private OffertURL offertURL = new OffertURL("htttp.itaka.pl");


    public String getOffertURL(){
        return this.offertURL.getOffertURL();
    }

    public String addOffertURL(String URL){
        this.offertURL.setOffertURL(URL);
        return URL;
    }
}

