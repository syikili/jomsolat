using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string username;
    public string email;

    public User()
    {
    }

    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
    }

    private void writeNewUser(string userId, string name, string email)
    {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);

       // mDatabaseRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

   

}

