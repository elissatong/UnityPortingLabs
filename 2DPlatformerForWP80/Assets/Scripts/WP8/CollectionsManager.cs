using UnityEngine;
using System.Collections.Specialized;
public class CollectionsManager : MonoBehaviour {

    public class UserProfile
    {   
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email = "";
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password = "";
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public UserProfile()
        {

        }

        public UserProfile(string n, string e, string p)
        {
            this.name = n;
            this.email = e;
            this.password = p;
        }
    }
    // Use this for initialization
    void Start () {

        UserProfile user = new UserProfile("MyName", "myname@company.com", "password");
        OrderedDictionary orderedBook = new OrderedDictionary();
        orderedBook.Add(user.Name, user);
        if (orderedBook.Contains("MyName"))
        {
            Debug.Log("Found key");
        }
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
