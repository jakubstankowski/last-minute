package offerts;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Scanner;

public class GetOfferts {
    // https://www.itaka.pl/sipl-v2/data/filters?view=offerList&language=pl&package-type=wczasy&adults=2&date-from=2019-08-29&promo=lastMinute&order=priceAsc&total-price=0&page=1&transport=bus%2Cflight&filters=text%2CpackageType%2CdepartureRegion%2CdestinationRegion%2CdateFrom%2CdateTo%2Cduration%2CadultsNumber%2CchildrenAge%2Cprice%2CcategoryTypes%2Cpromotions%2Cfood%2Cstandard%2Cfacilities%2Cgrade%2Ctransport%2CtripActivities%2CtripDifficultyLevels%2CbeachDistance%2CdepartureDate&userId=2c8ace2338757741529dd1906696e92b&currency=PLN

    private static String streamToString(InputStream inputStream) {
        String text = new Scanner(inputStream, "UTF-8").useDelimiter("\\Z").next();
        return text;
    }


    public String jsonGetRequest(String urlQueryString) {
        String json = null;
        try {
            URL url = new URL(urlQueryString);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setDoOutput(true);
            connection.setInstanceFollowRedirects(false);
            connection.setRequestMethod("GET");
            connection.setRequestProperty("Content-Type", "application/json");
            connection.setRequestProperty("charset", "utf-8");
            connection.connect();
            InputStream inStream = connection.getInputStream();
            json = streamToString(inStream); // input stream to string
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        return json;
    }
}
