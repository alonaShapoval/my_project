using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursov
{
    class Proverb {  
        private string text;
        private string topic;
        public Proverb(string text,string topic)
        {
            this.text = text;
            this.topic = topic;
        }
        public string Text
        {
            get { return text; }
           
        }
       
    }
}
