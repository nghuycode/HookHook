﻿namespace PFacebook
{
    public class FacebookRepository
    {
        static private MyFacebook myFacebook;
        public static MyFacebook MyFacebook
        {
            get {
                if (myFacebook == null)
                    myFacebook = new MyFacebook();
                return myFacebook;
            }
        }
    }
}