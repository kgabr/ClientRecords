using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Web;


namespace Billing
{
    public class PersistentData
    {
        public static string LastReportDate { get; set; }
    }
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public double Cnp { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Pregnant { get; set; }
        public float TimeExp { get; set; }
        public string DateExp { get; set; }

    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }

    public class Article
    {
        public int ArticleID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Bill 
    {
        public int BillID { get; set; }
        public int CustomerID { get; set; }
        
        public long Number { get; set; }

        [XmlElementAttribute(DataType = "date")]
        public DateTime Date { get; set; }
    }

    public class BillLine
    {
        public int BillLineID { get; set; }
        public int BillID { get; set; }
        public decimal Quantity { get; set; }

        [XmlElementAttribute(DataType = "date")]
        public DateTime ExpireDate { get; set; }
        public decimal DiscountValue { get; set; }
        public int ArticleID { get; set; }


        public BillLine Copy()
        {
            return new BillLine() { 
                BillLineID = this.BillLineID,
                BillID = this.BillID,
                Quantity = this.Quantity,
                ExpireDate = this.ExpireDate,
                DiscountValue = this.DiscountValue,
                ArticleID = this.ArticleID
            };
        }
    }

    public class XMLData
    {
        public User[] users;
        public Customer[] customers;
        public Article[] articles;

        public Bill[] bills;
        public BillLine[] billLines;


        public long number;
        public string lastReportDate;

        static XmlSerializer serializer = new XmlSerializer(typeof(XMLData));

        public void Save(string filename)
        {
            XmlTextWriter writer = new XmlTextWriter(filename, Encoding.UTF8);
            try
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.IndentChar = ' ';
                serializer.Serialize(writer, this);
            }
            finally
            {
                writer.Dispose();
            }
        }

        static public XMLData Load(string filename)
        {
            XmlTextReader reader = new XmlTextReader(filename);
            try
            {
                return (XMLData)serializer.Deserialize(reader);
            }
            catch
            {
                MessageBox.Show("FUCK!! No database!");
                //return (XMLData)
                throw new Exception("No database found!");
            }
            finally
            {
                reader.Dispose();
            }
        }

    }

    

    class BusinessLogic
    {
        List<User> users = new List<User>();
        List<Customer> customers = new List<Customer>();
        List<Article> articles = new List<Article>();
        List<Bill> bills = new List<Bill>();
        List<BillLine> billLines = new List<BillLine>();
        PersistentData pData = new PersistentData();

        //pData.LastReportDate

        int nextUserID = 1;
        int nextCustomerID = 1;
        int nextArticleID = 1;
        int nextBillID = 1;
        int nextBillLineID = 1;
        long nextBillNumber = 1;
        

        //USER HANDLING
 
        public void InsertUser(User user)
        {
            user.UserID = nextUserID;
            nextUserID++;

            users.Add(user);
        }

        public void DeleteUser(int userID)
        {
            int index = findUserIndex(userID);

            if (index >= 0)
            {
                users.RemoveAt(index);
            }
        }

        public User[] GetUsers()
        {
            return users.ToArray();
        }

        public User GetUser(int userID)
        {
            int index = findUserIndex(userID);
            if (index >= 0)
            {
                return users[index];
            }
            return null;
        }

        private int findUserIndex(int userID)
        {
            return users.FindIndex(usr => usr.UserID == userID);
        }

        private int maxUserID()
        {
            int max = 0;
            foreach (User usr in users)
            {
                if (usr.UserID > max)
                {
                    max = usr.UserID;
                }
            }
            return max;
        }

        //CUSTOMER HANDLING

        public void InsertCustomer(Customer customer)
        {
            customer.CustomerID = nextCustomerID;
            nextCustomerID++;

            customers.Add(customer);
        }

        public void DeleteCustomer(int customerID)
        {
            int index = findCustomerIndex(customerID);

            foreach (Bill bill in bills)
            {
                if (bill.CustomerID == customerID)
                {

                    MessageBox.Show("Customer has bill referring to it");
                    return;
                    //th//row new InvalidOperationException("Customer has bills referring to it");
                }
            }


            if (index >= 0)
            {
                customers.RemoveAt(index);
            }
        }

        public Customer[] GetCustomers()
        {
            return customers.ToArray();
        }

        public Customer GetCustomer(int customerID)
        {
            int index = findCustomerIndex(customerID);
            if (index >= 0)
            {
                return customers[index];
            }
            return null;
        }

        public string GetCustomerName(int customerID)
        {
            Customer cust = BusinessLogic.DB.GetCustomer(customerID);
            if (cust != null)
            {
                return cust.Name;
            }
            return "";
        }

        private int findCustomerIndex(int customerID)
        {
            return customers.FindIndex(cust => cust.CustomerID == customerID);
        }

        private int maxCustomerID()
        {
            int max = 0;
            foreach (Customer cust in customers)
            {
                if (cust.CustomerID > max)
                {
                    max = cust.CustomerID;
                }
            }
            return max;
        }

        //ARTICLE HANDLING

        public void InsertArticle(Article article)
        {
            article.ArticleID = nextArticleID;
            nextArticleID++;

            articles.Add(article);
        }

        public void DeleteArticle(int articleID)
        {
            int index = findArticleIndex(articleID);

            if (index >= 0)
            {
                articles.RemoveAt(index);
            }
        }

        public Article[] GetArticles()
        {
            return articles.ToArray();
        }

        public Article GetArticle(int articleID)
        {
            int index = findArticleIndex(articleID);
            if (index >= 0)
            {
                return articles[index];
            }
            return null;
        }

        private int findArticleIndex(int articleID)
        {
            return articles.FindIndex(art => art.ArticleID == articleID);
        }

        private int maxArticleID()
        {
            int max = 0;
            foreach (Article art in articles)
            {
                if (art.ArticleID > max)
                {
                    max = art.ArticleID;
                }
            }
            return max;
        }

        //BILL HANDLING

        public Bill[] GetBills()
        {
            return bills.ToArray();
        }

        public Bill GetBill(int billID)
        {
            int index = findBillIndex(billID);
            if (index >= 0)
            {
                return bills[index];
            }
            return null;
        }

        private int findBillIndex(int billID)
        {
            return bills.FindIndex(bill => bill.BillID == billID);
        }

        public void InsertBill(Bill bill)
        {
            bill.BillID = nextBillID;
            nextBillID++;
            if (bill.Number >= nextBillNumber)
            {
                nextBillNumber = bill.Number + 1;
            }
            bills.Add(bill);
        }

        public void DeleteBill(int billID)
        {
            int index = findBillIndex(billID);
            if (index > 0)
            {
                bills.RemoveAt(index);
            }
            for (int i = 0; i < billLines.Count; i++)
            {
                if (billLines[i].BillID == billID)
                {
                    billLines.RemoveAt(i);
                    i--;
                }
            }

       
        }

        public Decimal GetBillTotal(int billID)
        {
            return GetBillTotal(GetBillLines(billID));
        }

        public Decimal GetBillTotal(BillLine[] lines)
        {
            Decimal total = 0;
            foreach (BillLine line in lines)
            {
                Article art = GetArticle(line.ArticleID);
                total += art.Price * line.Quantity - line.DiscountValue;
            }
            return total;
        }

        public BillLine[] GetBillLines(int billID)
        {
            List<BillLine> lines = new List<BillLine>();
            foreach (BillLine line in billLines)
            {
                if (line.BillID == billID)
                {
                    lines.Add(line);
                }
            }
            return lines.ToArray();
        }

        public long NextBillNumber
        {
            get
            {
                return nextBillNumber;
            }
        }

        private int findBillLineIndex(int billLineID)
        {
            return billLines.FindIndex(line => line.BillLineID == billLineID);
        }

        public void InsertBillLine(BillLine line)
        {
            line.BillLineID = nextBillLineID;
            nextBillLineID++;
            billLines.Add(line);
        }

        public void UpdateBillLine(BillLine line)
        {
            int index = findBillLineIndex(line.BillLineID);
            billLines[index] = line;
        }

        public void DeleteBillLine(int billLineID)
        {
            int index = findBillLineIndex(billLineID);
            if (index > 0)
            {
                billLines.RemoveAt(index);
            }
        }

        //PERSISTENT DATA HANDLING
        public string GetLastReportDate()
        {
            string date = PersistentData.LastReportDate;
            return date;
        }


        //XML READ & WRITE

        public static readonly string XmlFileName = "businesslogic.xml";
        //public static readonly string XmlFileName = @"c:\test\businesslogic.xml";

        public void Write()
        {
            XMLData xmlData = new XMLData();
            xmlData.users = users.ToArray();
            xmlData.customers = customers.ToArray();
            xmlData.articles = articles.ToArray();
            xmlData.bills = bills.ToArray();
            xmlData.billLines = billLines.ToArray();
            xmlData.number = nextBillNumber;
            //xmlData.lastReportDate = GetLastReportDate().ToString();

            xmlData.Save(XmlFileName); 

        }

        public void WriteStatus()
        {
            string text1 = "Normal exit." + Environment.NewLine;
            string timestamp = GetTimestamp(DateTime.Now);
            File.WriteAllText("status.txt", text1 + timestamp);
        }

        public void CreateBackup()
        {
            XMLData xmlData = new XMLData();
            xmlData.users = users.ToArray();
            xmlData.customers = customers.ToArray();
            xmlData.articles = articles.ToArray();
            xmlData.bills = bills.ToArray();
            xmlData.billLines = billLines.ToArray();
            xmlData.number = nextBillNumber;
            //xmlData.lastReportDate = GetLastReportDate().ToString();
            string savePath = @"backup\" + GetTodaysDate(DateTime.Today) + "\\";
            System.IO.Directory.CreateDirectory(savePath);
            File.SetAttributes(savePath, FileAttributes.Normal);

            xmlData.Save(savePath + "businesslogic.xml");
        }

        

        public void Read()
        {
            if (!File.Exists(XmlFileName))
            {
                createStartupDatabase();
            }
            XMLData xmlData = XMLData.Load(XmlFileName);

            users = new List<User>();
            if (xmlData.users != null)
            {
                users.AddRange(xmlData.users);
            }
            nextUserID = maxUserID() + 1;

            customers = new List<Customer>();
            if (xmlData.customers != null)
            {
                customers.AddRange(xmlData.customers);
            }
            nextCustomerID = maxCustomerID() + 1;

            articles = new List<Article>();
            if (xmlData.articles != null)
            {
                articles.AddRange(xmlData.articles);
            }
            nextArticleID = maxArticleID() + 1;

            bills = new List<Bill>();
            if (xmlData.bills != null)
            {
                bills.AddRange(xmlData.bills);
            }
            maxBillID(out nextBillNumber, out nextBillID);
            nextBillNumber++;
            nextBillID++;

            billLines = new List<BillLine>();
            if (xmlData.billLines != null)
            {
                billLines.AddRange(xmlData.billLines);
            }
            nextBillLineID = maxBillLineID() + 1;

            pData = new PersistentData();
            if (xmlData.lastReportDate!=null)
            {
                //BusinessLogic.DB.pData = xmlData.lastReportDate;
            }

        }

        public void createStartupDatabase()
        {
            string line1 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            string line2 = "<XMLData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
            string line3 = "</XMLData>";
            string[] lines = { line1, line2, line3 };
            System.IO.File.WriteAllLines(XmlFileName, lines);
        }

        private int maxBillLineID()
        {
            int max = 0;
            foreach (BillLine line in billLines)
            {
                if (line.BillLineID > max)
                {
                    max = line.BillLineID;
                }
            }
            return max;
            
        }

        private void maxBillID(out long nextBillNumber, out int nextBillID)
        {
            nextBillNumber = 1;
            nextBillID = 1;
            foreach (Bill bill in bills)
            {
                if (bill.Number > nextBillNumber)
                {
                    nextBillNumber = bill.Number;
                }
                if (bill.BillID > nextBillID)
                {
                    nextBillID = bill.BillID;
                }
            }
            //return maxBillID;
        }

        private BusinessLogic()
        {
            Read();
        }

        public static readonly BusinessLogic DB = new BusinessLogic();


        public string GetArticleName(int articleID)
        {
            Article article = BusinessLogic.DB.GetArticle(articleID);
            if (article != null)
            {
                return article.Name;
            }
            return "";
        }

        //EXPORT TO EXCEL 
        /*public void ExportIntoExcel(ListView lvExport, string Header, string FileName)
        {
            try
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".xls");
                System.Web.HttpContext.Current.Response.Charset = "";
                System.Web.HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter stringWrite = new StringWriter();
                stringWrite.Write(Header);
                stringWrite.WriteLine();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                HtmlForm frm = new HtmlForm();
                lvExport.Parent.Controls.Add(frm);
                frm.Controls.Add(lvExport);
                frm.RenderControl(htmlWrite);
                System.Web.HttpContext.Current.Response.Write(stringWrite.ToString());

            }
            catch (Exception ex)
            {
            }
            finally
            {
                System.Web.HttpContext.Current.Response.End();
            }
        }*/

        // TABLE DATA HANDLING METHODS
        
        public int GetUsersCount()
        {
            int userCount=0;
            foreach (User temp in users)
            {
                userCount++;
            }
            return userCount;
        }

        //compares the specified date and the measured date, and returns data only from measurements where the date of measurement is newer.
        public int GetUsersCount(DateTime dateSpecified)
        {
            int userCount = 0;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                
                if (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0) 
                {
                    userCount++;    
                }
            }
            return userCount;
        }

        public int GetUsersAgeYoung()
        {
            int youngUsers = 0;
            foreach (User temp in users)
            {
                if (temp.Age<=15)
                {
                    youngUsers++;
                }
            }
            return youngUsers;
        }

        public int GetUsersAgeYoung(DateTime dateSpecified)
        {
            int youngUsers = 0;
            foreach (User  user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                if (user.Age <= 15 && DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0)
                {
                    youngUsers++;
                }
            }
            return youngUsers;
        }

        public int GetUsersAgeMid()
        {
            int midUsers = 0;
            foreach (User temp in users)
            {
                if ((temp.Age > 15)&&(temp.Age<=40))
                {
                    midUsers++;
                }
            }
            return midUsers;
        }

        public int GetUsersAgeMid(DateTime dateSpecified)
        {
            int midUsers = 0;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                if ((user.Age > 15) && (user.Age <= 40) && (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0))
                {
                    midUsers++;
                }
            }
            return midUsers;
        }

        public int GetUsersAgeOld()
        {
            int oldUsers = 0;
            foreach (User temp in users)
            {
                if (temp.Age > 40)
                {
                    oldUsers++;
                }
            }
            return oldUsers;
        }

        public int GetUsersAgeOld(DateTime dateSpecified)
        {
            int oldUsers = 0;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                if ((user.Age > 40) && (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0))
                {
                    oldUsers++;
                }
            }
            return oldUsers;
        }

        public int GetSexM()
        {
            int mUsers = 0;
            foreach (User temp in users)
            {
                if (temp.Sex == "M")
                {
                    mUsers++;
                }
            }
            return mUsers;
        }

        public int GetSexM(DateTime dateSpecified)
        {
            int mUsers = 0;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                if ((user.Sex == "M") && (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0))
                {
                    mUsers++;
                }
            }
            return mUsers;
        }

        public int GetSexF()
        {
            int fUsers = 0;
            foreach (User temp in users)
            {
                if (temp.Sex == "F")
                {
                    fUsers++;
                }
            }
            return fUsers;
        }

        public int GetSexF(DateTime dateSpecified)
        {
            int fUsers = 0;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                if ((user.Sex == "F") && (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0))
                {
                    fUsers++;
                }
            }
            return fUsers;
        }

        public float GetDosage()
        {
            float avgDosage = 1;
            int i = 1;
            foreach (User temp in users)
            {
                avgDosage += temp.TimeExp;
                i++;
            }
            avgDosage = avgDosage / i;
            return avgDosage;
        }

        public float GetDosage(DateTime dateSpecified)
        {
            float avgDosage = 1;
            int i = 1;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                if (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0)
                {
                    avgDosage += user.TimeExp;
                    i++;
                }
            }
            avgDosage = avgDosage / i;
            return avgDosage;
        }
        
        public bool VerifyCnp(string CNP)
        {
            if (CNP.Length!=13)
            {
                return false;
            }
            bool isValid = false;
            string teststring = "279146358279";
            double total = 0;
          
            for (int i = 0; i < 12; i++)
            {
                total += (int)Char.GetNumericValue(CNP[i])*(int)Char.GetNumericValue(teststring[i]);
            }
            int lastDigit = (int)Char.GetNumericValue(CNP[12]);
        
            if (total % 11 == 10)
            {
                if (lastDigit == 1)
                {
                    isValid = true;
                }
            }
            else
                if (lastDigit == total % 11)
                    {
                        isValid =  true;
                    }
            return isValid;
       }

        public bool doesUserExist( string CNP)
        {
            foreach (User usr in users)
            {
                if (String.Equals(usr.Cnp.ToString(), CNP))
                {
                    //MessageBox.Show("MATCH");
                    return true;
                }
            }
            return false;
        }

        public User getExistingUserData(string CNP)
        {
            User tempuser = new User();
            
            foreach (User usr in users)
                if (String.Equals(usr.Cnp.ToString(), CNP))
                {
                    tempuser.Name = usr.Name;
                    tempuser.Age = calculateAge(usr.Cnp.ToString());
                    tempuser.Sex = determineSex(usr.Cnp.ToString());
                    return tempuser;
                }

            return null;
        }

        public string findUserIfPresent(string CNP)
        {
            foreach (User usr in users)
            {
                if (String.Equals(usr.Cnp.ToString(), CNP))
                {
                    MessageBox.Show("MATCH");
                    return usr.Cnp.ToString();
                }
            }
                return CNP;
        }
       
        public int calculateAge(string cnp)
        {
            DateTime thisDay = DateTime.Today;
            int year, month, day;

            year = Convert.ToInt32(cnp.Substring(1,2))+1900;
            if ((Convert.ToInt32(cnp.Substring(0, 1)) == 5) || (Convert.ToInt32(cnp.Substring(0, 1)) == 6))
            {
                year = Convert.ToInt32(cnp.Substring(1, 2)) + 2000;
            }
            month = Convert.ToInt32(cnp.Substring(3, 2));
            day = Convert.ToInt32(cnp.Substring(5, 2));

            DateTime cnpDay = new DateTime(year, month, day);
            TimeSpan age = thisDay.Subtract(cnpDay);
            return Convert.ToInt32(Math.Floor(age.TotalDays / 365));
        }

        public string determineSex(string cnp)
        {
            string sex;
            if ((Int32.Parse(cnp.Substring(0,1))==1) || (Int32.Parse(cnp.Substring(0,1))==5))
            {
                sex = "M";
                return sex;
            }
            if ((Int32.Parse(cnp.Substring(0, 1)) == 2) || (Int32.Parse(cnp.Substring(0, 1)) == 6))
            {
                sex = "F";
                return sex;
            }
            return null;
        }

        public bool isInputNumeric(KeyEventArgs input)
            {
                bool result = false;
                if ((input.KeyCode == Keys.D1)||
                    (input.KeyCode == Keys.D2) ||
                    (input.KeyCode == Keys.D3) ||
                    (input.KeyCode == Keys.D4) ||
                    (input.KeyCode == Keys.D5) ||
                    (input.KeyCode == Keys.D6) ||
                    (input.KeyCode == Keys.D7) ||
                    (input.KeyCode == Keys.D8)||
                    (input.KeyCode == Keys.D9)||
                    (input.KeyCode == Keys.D0)||
                    (input.KeyCode == Keys.Delete)||
                    (input.KeyCode == Keys.Back)
                    )
                {
                    result = true;
                }
                return result;
            }

        //converts string with the format dd-mm-yyyy to DateTime
        private DateTime convertStringToDateTime(String date)
        {
            date = date.Replace("-", "/");
            IFormatProvider culture = new System.Globalization.CultureInfo("ro-RO", true);
            DateTime dt = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            return dt;
        }

        private string GetTimestamp(DateTime value)
        {
            return value.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private string GetTodaysDate(DateTime value)
        {
            return value.ToString("dd-MM-yyyy");
        }


        
        public User GetLastRecord()
        {   
            int lastRecordID = 1;
            foreach(User u in users) {
                if (u.UserID > lastRecordID) {
                    lastRecordID = u.UserID;
                }
            }
            return GetUser(lastRecordID);
        }
    }
}