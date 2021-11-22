using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EmailModels
{
    public class UserEmailOptions
    {
        public UserEmailOptions()
        {
            this.ToEmails = new List<string>();
            this.PlaceHolders = new List<KeyValuePair<string, string>>();
        }
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }
    }
}
