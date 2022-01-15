using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Restaurant.Models;
using System.Text;
public class XMLHandling
{
    public static void incarcareXML()
    {
        MeniuDbContext mdb= new MeniuDbContext();
        bool flag1=(from p in mdb.Meniuri
                    where p.Id==1
                    select p.Nume).Count()>0;
        if(flag1==false)
        {
            readMeniu();
        }
        ProdusDbContext pdb= new ProdusDbContext();
        bool flag2=(from p in pdb.Produse
                    where p.Id==1
                    select p.Nume).Count()>0;
        if(flag2==false)
        {
            readProdus();
        }

      
    }
   
	public  void readProdus()
    {
        XElement xelement = XElement.Load("produs.xml");
       
           using(ProdusDbContext produse = new ProdusDbContext())
            {

                foreach (var element in xelement.Elements("produs"))
                {
                    ProdusModel p = new ProdusModel();
                p.Nume = element.Element("nume").Value;
                p.Gramaj = int.Parse(element.Element("masa").Value);
                p.Unitate_masura = element.Element("udm").Value;
                p.Cantitate = int.Parse(element.Element("cantitate").Value);
                produse.Produse.Add(p);
                produse.SaveChanges();
            }
        }
        
    }
   public void  readMeniu()
    {
      
        XElement xelement = XElement.Load("meniu.xml");

        using (MeniuDbContext meniuri = new MeniuDbContext())
        {

            foreach (var element in xelement.Elements("meniu"))
            {
                MeniuModel m = new MeniuModel();
                m.Nume = element.Element("nume").Value;
                 m.Pret = double.Parse(element.Element("pret").Value);
                m.Idproduse = element.Element("Idproduse").Value;
                meniuri.Meniuri.Add(m);
                meniuri.SaveChanges();
            }
        }

    }
}
