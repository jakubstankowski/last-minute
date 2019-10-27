package last.minute.database;

import last.minute.model.Profile;

import java.util.HashMap;
import java.util.Map;

public class DatabaseClass {
    private static Map<String, Profile> profiles = new HashMap<>();


    public static Map<String, Profile> getProfiles() {
        return profiles;
    }


}
