using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * Author: Christopher Dillon
 * Graded Unit - Open Computing Supplies
 * Date: 03/06/2015
 * */

public class User
{
    private string username;
    private string password;
    private string firstName;
    private string lastName;
    private string street;
    private string town;
    private string postcode;
    private string phoneNo;
    private string email;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    public string Town
    {
        get { return town; }
        set { town = value; }
    }

    public string Postcode
    {
        get { return postcode; }
        set { postcode = value; }
    }

    public string PhoneNo
    {
        get { return phoneNo; }
        set { phoneNo = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public User(string newUser, string newPass, string newFirstName, string newLastName, string newStreet, string newTown, string newPostcode, string newPhoneNo, string newEmail)
    {
        username = newUser;
        password = newPass;
        firstName = newFirstName;
        lastName = newLastName;
        street = newStreet;
        town = newTown;
        postcode = newPostcode;
        phoneNo = newPhoneNo;
        email = newEmail;

    }

    public User()
    {
        username = "";
        password = "";
        firstName = "";
        lastName = "";
        street = "";
        town = "";
        postcode = "";
        phoneNo = "";
        email = "";
    }

    /*
     * Used to update the details of a user
     * 
     * @param Username - The username of the user
     * @param fName - The first name of the user
     * @param lName - The last name of the user
     * @param Town - The town of the user
     * @param Postcode - The postcode of the user
     * @param PhoneNo - The phone number of the user
     * @param Email - the email of the user
     * */

    public void updateDetails(string Username, string fName, string lName, string Street, string Town, string Postcode, string PhoneNo, string Email)
    {
        if (Username != "")
        {
            username = Username;
        }
        if (fName != "")
        {
            firstName = fName;
        }
        if (lName != "")
        {
            lastName = lName;
        }
        if (Street != "")
        {
            street = Street;
        }
        if (Town != "")
        {
            town = Town;
        }
        if (Postcode != "")
        {
            postcode = Postcode;
        }
        if (PhoneNo != "")
        {
            phoneNo = PhoneNo;
        }
        if (Email != "")
        {
            email = Email;
        }
    }

    /*
     * Used to update the details of a user
     * 
     * @param fName - The first name of the user
     * @param lName - The last name of the user
     * @param Town - The town of the user
     * @param Postcode - The postcode of the user
     * @param PhoneNo - The phone number of the user
     * */

    public void updateDetails(string fName, string lName, string Street, string Town, string Postcode, string PhoneNo)
    {
        if (fName != "")
        {
            firstName = fName;
        }
        if (lName != "")
        {
            lastName = lName;
        }
        if (Street != "")
        {
            street = Street;
        }
        if (Town != "")
        {
            town = Town;
        }
        if (Postcode != "")
        {
            postcode = Postcode;
        }
        if (PhoneNo != "")
        {
            phoneNo = PhoneNo;
        }
    }
}