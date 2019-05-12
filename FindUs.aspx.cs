using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public partial class FindUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Shop myShop;

        //If no shop session exists, create one
        if (Session["myShop"] == null)
        {
            myShop = new Shop();
            Session.Add("myShop", myShop);
        }
        else
        {
            myShop = (Shop)Session["myShop"];
        }

        GLatLng mainLoc = new GLatLng(55.863000, -4.248957); //Sets the main location pointer
        GMap1.setCenter(mainLoc, 15);

        //Formats the pointer
        XPinLetter xpinLetter = new XPinLetter(PinShapes.pin, "O", Color.LightGreen, Color.Red, Color.Blue);
        GMap1.Add(new GMarker(mainLoc, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));

        //Loads all locations from the db and displays them individually
        foreach (KeyValuePair<string, Location> curLocation in myShop.ShopLocations)
        {
            PinIcon p = new PinIcon(PinIcons.home, System.Drawing.Color.Cyan);
            GMarker gm = new GMarker(new GLatLng(Convert.ToDouble(curLocation.Value.LocLat), Convert.ToDouble(curLocation.Value.LocLong)),
            new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));

            GInfoWindow win = new GInfoWindow(gm, "blah" + " <a href='" + "blah" + "'>Read more...</a>", false, GListener.Event.mouseover);
            GMap1.Add(win);
        }
    }
}