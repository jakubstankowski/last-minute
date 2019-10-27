package last.minute.resource;

import last.minute.service.LastMinuteService;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

@Path("last-minute")
public class LastMinuteResource {

    private LastMinuteService lastMinuteService = new LastMinuteService();

    @GET
    @Path("/offert-url")
    @Produces(MediaType.TEXT_PLAIN)
    public String getOffertURL() {
        return lastMinuteService.getOffertURL();
    }

    @POST
    @Path("/offert-url")
    public String addOffertURL(String URL) {
        return lastMinuteService.addOffertURL(URL);
    }





}
