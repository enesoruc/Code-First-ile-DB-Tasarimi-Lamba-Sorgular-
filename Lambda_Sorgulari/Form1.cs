using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambda_Sorgulari
{
    public partial class Form1 : Form
    {
        NORTHWNDEntities db;
        public Form1()
        {
            InitializeComponent();
            db = new NORTHWNDEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Soru1();
            //Soru2();
            //Soru3();
            //Soru4();
            //Soru5();
            //Soru6();
            //Soru7();
            //Soru8();
            //Soru10();
        }

        private void Soru1()
        {
            var result = db.Products.Join(db.Order_Details,
                                            p=>p.ProductID,
                                            od=>od.ProductID,
                                            (p,od)=>new
                                            {
                                                Urun=p.ProductName,
                                                SiparisNo=od.OrderID,
                                                Tutar = (float)od.UnitPrice * od.Quantity * (1 - od.Discount)
                                            }).Join(db.Orders,
                                                    pod=>pod.SiparisNo,
                                                    o=>o.OrderID,
                                                    (pod,o)=>new
                                                    {
                                                        Urun=pod.Urun,
                                                        CalisanID=o.EmployeeID,
                                                        Tutar=pod.Tutar
                                                    }).Join(db.Employees,
                                                            podo=>podo.CalisanID,
                                                            e=>e.EmployeeID,
                                                            (podo,e)=>new
                                                            {
                                                                Urun=podo.Urun,
                                                                Tutar=podo.Tutar,
                                                                Calisan=e.FirstName+" "+e.LastName
                                                            }).GroupBy(a=>new {a.Calisan});
            foreach (var item in result)
            {
                listBox1.Items.Add(item.Key.Calisan+" "+item.Max(a=>a.Tutar));
            }
            //+item.Key.Urun + " "
        }

        private void Soru2()
        {
            var result = db.Orders.Join(db.Shippers,
                                        o=>o.ShipVia,
                                        s=>s.ShipperID,
                                        (o,s)=>new
                                        {
                                            Tedarikci=s.CompanyName,
                                            KargoUcreti=o.Freight
                                        }).GroupBy(a=>new {a.Tedarikci}).ToList();
            foreach (var item in result)
            {
                listBox1.Items.Add(item.Key.Tedarikci+" "+item.Sum(o=>o.KargoUcreti));
            }
        }

        private void Soru10()
        {
            var result = db.Orders.Select(a => new
            {
                Value = a.OrderID + " Nolu Sipariş "+SqlFunctions.DateDiff("DAY",a.OrderDate,a.ShippedDate)+" Günde teslim Edilmiş"
            }).ToList();
            foreach (var item in result)
            {
                listBox1.Items.Add(item.Value);
            }
        }

        private void Soru8()
        {
            var result = db.Orders.Where(o=>o.RequiredDate.Value<o.ShippedDate.Value).Select(a=>new {a.OrderID,gunFarki=SqlFunctions.DateDiff("DAY", a.RequiredDate,a.ShippedDate)}).ToList();
            foreach (var item in result)
            {
                listBox1.Items.Add(item.OrderID+" -Numaralı Sipariş "+item.gunFarki+" -Gün gecikmeli Teslim edilmiştir");
            }
        }

        private void Soru7()
        {
            var result = db.Orders.Join(db.Order_Details,
                                        o => o.OrderID,
                                        od => od.OrderID,
                                        (o, od) => new
                                        {
                                            Ulke = o.ShipCountry,
                                            Tutar = (float)od.UnitPrice * od.Quantity * (1 - od.Discount)
                                        }).GroupBy(x => new { x.Ulke}).ToList();

            foreach (var item in result)
            {
                listBox1.Items.Add(item.Key.Ulke + " " + item.Sum(a=>a.Tutar));
            }
        }

        private void Soru6()
        {

            //var enes = db.Orders.Join(db.Customers,
            //                            o=>o.CustomerID,
            //                            c=>c.CustomerID,
            //                            (o,c)=>new
            //                            {
            //                                SiparisNo=o.OrderID,
            //                                Musteri=c.CompanyName
            //                            }).Join(db.Order_Details,
            //                                    oc=>oc.SiparisNo,
            //                                    od=>od.OrderID,
            //                                    (oc,od)=>new
            //                                    {
            //                                        Musteri=oc.Musteri,
            //                                        Urun=db.Products.wh(db.Products)
            //                                    });
            //var result = (from p in db.Products
            //              join c in db.Categories on p.CategoryID equals c.CategoryID
            //              group p by new { c.CategoryName, c.CategoryID } into g
            //              select new
            //              {
            //                  Kategori = g.Key.CategoryName,
            //                  Urun = (from p in db.Products
            //                          where p.CategoryID == g.Key.CategoryID &&
            //                                p.UnitPrice == g.Max(x => x.UnitPrice)
            //                          select p.ProductName).FirstOrDefault(),
            //                  Fiyat = g.Max(x => x.UnitPrice)
            //              }).ToList();
        }

        private void Soru5()
        {
            var result = db.Customers.GroupJoin(db.Orders,
                                                c => c.CustomerID,
                                                o => o.CustomerID,
                                                (c, o) => new
                                                {
                                                    Musteri = c.CompanyName,
                                                    SiparisSayisi = o.Count()
                                                }
            ).OrderByDescending(o=>o.SiparisSayisi).Take(1);
            foreach (var item in result)
            {
                listBox1.Items.Add(item.Musteri+" Müşterisi -->"+item.SiparisSayisi+"Adet Sipariş Vermiş");
            }
        }

    private void Soru4()
        {
            var result = db.Products.GroupJoin(db.Order_Details,
                                            p => p.ProductID,
                                            od => od.ProductID,
                                            (p, od) => new
                                            {
                                                ürün = p.ProductName,
                                                UrunAdet = od.Count(),
                                                tedarikci = p.SupplierID
                                            }).Join(db.Suppliers,
                                                    pod => pod.tedarikci,
                                                    s => s.SupplierID,
                                                    (pod, s) => new {
                                                        Tedarikci = s.CompanyName,
                                                        ürün = pod.ürün,
                                                        UrunAdet = pod.UrunAdet 
                                                                    });

            dataGridView1.DataSource = result.ToList();
        }

        private void Soru3()
        {
            var result = db.Employees.Where(a=> a.Notes.Contains("toast"));
            dataGridView1.DataSource = result.ToList();
        }
    }
}
