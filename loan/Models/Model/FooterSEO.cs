using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pan.Model
{
    public class FooterSEO
    {

        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _keys;

        public string Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }
        string _val;

        public string Val
        {
            get { return _val; }
            set { _val = value; }
        }
       
    }
}