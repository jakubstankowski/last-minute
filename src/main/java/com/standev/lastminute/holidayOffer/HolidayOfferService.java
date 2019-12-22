
package com.standev.lastminute.holidayOffer;

import com.standev.lastminute.user.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;


@Service
public class HolidayOfferService {

    @Autowired
    private HolidayOfferDao holidayOfferDao;

   /* public Iterable<HolidayOffer> getAllHolidayOffers(Integer userId) {
        return holidayOfferDao.findByUserId(userId);
    }*/

    public HolidayOffer getHolidayOffer(Integer id){
        return holidayOfferDao.findById(id).orElse(null);
    }

  /*  public void deleteHolidayOffer(Integer id) {
        holidayOfferDao.deleteById(id);
    }
*/

    public void createHolidayOffer(HolidayOffer offer) {

      /*  List<HolidayOffer> offers = new ArrayList<>();
        for( HolidayOffer offer1 : offer ) {
            payment.setOrder( order );
            payments.add(payment);
        }
        order.setPayments( payments );*/



        holidayOfferDao.save(offer);
    }

   /* public void updateHolidayOffer(Integer id, HolidayOffer newOffer) {
        holidayOfferDao.save(newOffer);
    }

*/
}


