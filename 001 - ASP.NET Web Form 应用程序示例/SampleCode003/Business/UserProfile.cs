using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace SampleCode003.Business
{
    public class UserProfile : ProfileBase
    {
        public string FirstName
        {
            get { return base["FirstName"] as string; }
            set { base["FirstName"] = value; }
        }

        public string LastName
        {
            get { return base["LastName"] as string; }
            set { base["LastName"] = value; }
        }

        public static UserProfile GetUserProfile(string username)
        {
            return Create(username) as UserProfile;
        }
    }
}