using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cursov
{
    class Proverbs 
    {       
        private List<Proverb> proverb=new List<Proverb>();       

        public List<Proverb> Search(string wordToFind,string nameOfFile)
        {
            string s = "";
            proverb = new List<Proverb>();
            foreach (string line in File.ReadAllLines("E:/Cursov/прислів'я/" + nameOfFile + ".txt", Encoding.Default))
            {
                if (line.ToLower().Contains(wordToFind) || line.Contains(wordToFind.ToLower()))
                {                   
                   proverb.Add(new Proverb(line,nameOfFile));
                   
                }               
            }
            if (s=="")
            {
                s = "На жаль, нічого не знайдено";
                proverb.Add(new Proverb(s,nameOfFile));       
            }
          
            return proverb;
        }
        public List<Proverb> CreateArray(string nameOfFile)
        {
            proverb = new List<Proverb>();
            foreach (string line in File.ReadAllLines("E:/Cursov/прислів'я/" + nameOfFile + ".txt", Encoding.Default))
            {               
                proverb.Add(new Proverb(line,nameOfFile));
            }
            return proverb;        
        }       
      
    }
}
