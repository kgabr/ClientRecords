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


    public class XMLData
    {
        public User[] users;


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
                MessageBox.Show("Database not found!");
                //return (XMLData)
                //throw new Exception("No database found!");
                return null;
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


        private BusinessLogic()
        {
            Read();
        }

        public static readonly BusinessLogic DB = new BusinessLogic();


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
        
        public int GetRecordsCount()
        {
            int recordsCount=0;
            foreach (User temp in users)
            {
                recordsCount++;
            }
            return recordsCount;
        }

        //compares the specified date and the measurement dates, and returns data only from measurements newer than specified.
        public int GetRecordsCount(DateTime dateSpecified)
        {
            int recordsCount = 0;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                
                if (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0) 
                {
                    recordsCount++;    
                }
            }
            return recordsCount;
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

        public int GetRecordsCountBySexAndAge(String sex, int AgeFrom, int AgeUntil)
        {
            if (!(sex.Equals("F") || sex.Equals("M")))
            {
                return 0;
            }

            int recordsFound = 0;
            foreach (User user in users)
            {
                if ((user.Sex.Equals(sex)) && (user.Age >= AgeFrom) && (user.Age <= AgeUntil))
                {
                    recordsFound++;
                }
            }
            return recordsFound;
        }

        public int GetRecordsCountBySexAndAge(String sex, int AgeFrom, int AgeUntil, DateTime dateSpecified)
        {
            if (!(sex.Equals("F") || sex.Equals("M")))
            {
                return 0;
            }

            int recordsFound = 0;
            foreach (User user in users)
            {
                DateTime dateOfMeasurement = convertStringToDateTime(user.DateExp);
                if ((user.Sex.Equals(sex)) && (user.Age >= AgeFrom) && (user.Age <= AgeUntil) && (DateTime.Compare(dateSpecified, dateOfMeasurement) <= 0))
                {
                    recordsFound++;
                }
            }
            return recordsFound;
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


        
        public User GetLastRecordDatas()
        {
            User returnedUser = new User();
            int lastRecordID = 1;
            foreach(User u in users) {
                if (u.UserID > lastRecordID) {
                    lastRecordID = u.UserID;
                }
            }
            returnedUser = copyUserData(GetUser(lastRecordID), returnedUser);


            return returnedUser;
        }

        private User copyUserData(User sourceUser, User destinationUser)
        {
            destinationUser.UserID = sourceUser.UserID;
            destinationUser.Name = sourceUser.Name;
            destinationUser.Cnp = sourceUser.Cnp;
            destinationUser.Age = sourceUser.Age;
            destinationUser.Sex = sourceUser.Sex;
            destinationUser.Height = sourceUser.Height;
            destinationUser.Weight = sourceUser.Weight;
            destinationUser.Pregnant = sourceUser.Pregnant;
            destinationUser.DateExp = sourceUser.DateExp;
            return destinationUser;
        }
    }
}