import offerts.GetOfferts;

import java.util.HashMap;
import java.util.Map;

public class Main {


    public static void main(String[] args) {
        GetOfferts getOfferts = new GetOfferts();
        String url = "https://jsonplaceholder.typicode.com/todos/1";

        Map<String, Object> jsonMap = new HashMap<>();

        // comment for testint youtrack 123123
        System.out.println("JSON: "+ getOfferts.jsonGetRequest(url));
    }

}