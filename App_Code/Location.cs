using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class Location
{
    private string locationId;
    private string locLat;
    private string locLong;

    public string LocationId
    {
        get { return locationId; }
        set { locationId = value; }
    }

    public string LocLat
    {
        get { return locLat; }
        set { locLat = value; }
    }

    public string LocLong
    {
        get { return locLong; }
        set { locLong = value; }
    }

	public Location()
	{
        locationId = "";
        locLat = "";
        locLong = "";
	}

    public Location(string LocationId, string LocLat, string LocLong)
    {
        locationId = LocationId;
        locLat = LocLat;
        locLong = LocLong;
    }
}