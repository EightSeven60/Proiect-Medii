using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Restaurant.Models;
namespace Restaurant.Helpers;
public class XMLHandling
{
	public XMLHandling()
	{

		public void readProdus()
        {
            XElement xelement XElement.Load("produs.xml");
            StringBuilder s;
            foreach(var element in xelement.Elements("produs"))
            {
              
               
            }
        }
		public void readMeniu()
        {

        }
		
	}
}
