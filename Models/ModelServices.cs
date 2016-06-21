using Explore_App;
using Explore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Explore_App.Models
{
    //User_Details class is made to get the values from the UserDetail table
    public class User_Details
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
    }
    //Updation_Info_Player class is made to get the values from the PlayerDetail table to generate the response
    public class Updation_Info_Player
    {
        public string UserID { get; set; }
        public string UserType { get; set; }
        public string Contact_No { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int SportID { get; set; }
        public string Position { get; set; }
        public string Experience { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string Wingspan { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Club { get; set; }
        public int Score { get; set; }
        public int GPA { get; set; }
        public string Password { get; set; }
    }
    //Updation_Info_Coach class is made to get the values from CoachDetail table to generate the response
    public class Updation_Info_Coach
    {
        public string UserID { get; set; }
        public int UserType { get; set; }
        public string Contact_No { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int SportID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string AssistantCoach{ get; set; }
        public string SchoolDivision { get; set; }
        public int SessionCost { get; set; }
        public int SessionHours { get; set; }
        public string Experience { get; set; }
    }
    public class Log_Type
    {
        public int UserType { get; set; }
        public string UserID { get; set; }
    }
    public class Log_In_Coach
    {
        public string UserID { get; set; }
        public int UserType { get; set; }
        public string Contact_No { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int SportID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string AssistantCoach { get; set; }
        public string SchoolDivision { get; set; }
        public int SessionCost { get; set; }
        public int SessionHours { get; set; }
        public string Experience { get; set; }
        public string Email { get; set; }
    }
    public class Log_In_Player
    {
        public string Email { get; set; }
        public string UserID { get; set; }
        public int UserType { get; set; }
        public string Contact_No { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int SportID { get; set; }
        public string Position { get; set; }
        public string Experience { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string Wingspan { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Club { get; set; }
        public int Score { get; set; }
        public int GPA { get; set; }
    }
     public class ConstantValues
     {
       public const string imagePath = "http://localhost:23438/UploadFiles/";
       //public const string imagePath = "http://exploreapp.azurewebsites.net/UploadFiles/";
     }
     public class FileUploadModal
     {
         public string UserID { get; set; }
         public string FileName { get; set; }
        // public string FileType { get; set; }
     }
    public class Upload
    {
        public string FileType { get; set; }
        public string UserID { get; set; }
    }
     //public class UpdateImage
     //{
     //    public string ImagenPath { get; set; }
     //}
    public class ModelServices
    {
        public User_Details User(UserDetail obj)
        {
            // list is made for storing the values selected by the linq query
           User_Details list = new User_Details();
            try
            {
                using (ExploreDBEntities dbContext = new ExploreDBEntities())
                {
                    // save the values stored in obj in UserDetail table in db
                    dbContext.UserDetails.Add(obj);
                    dbContext.SaveChanges();
                    //linq query for selecting the details which has to be send to the user as response
                    list = dbContext.UserDetails.Where(i => i.UserID == obj.UserID).Select(i => new User_Details()
                        {
                            UserID = i.UserID,
                            UserName = i.UserName,
                            Email = i.Email,
                            UserType = i.UserType
                        }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return list;
        }
        public Updation_Info_Player UpdatePlayer(PlayerDetail obj)
        {
            //for storing the values selected by the linq query
            Updation_Info_Player updtobj = new Updation_Info_Player();
            //for selecting the values from the playerdetails table
            PlayerDetail plyrdtls = new PlayerDetail();
            try
            {
                using (ExploreDBEntities dbContext = new ExploreDBEntities())
                {
                    //usrtyp will store the UserType of the person by checking the userid
                    int usrtyp = dbContext.UserDetails.Where(i => i.UserID == obj.UserID).Select(i => i.UserType).FirstOrDefault();
                    if (usrtyp == 2)
                    {
                        //as usrtyp is 2 therefore the values stored in the playerdetails object will be stored in the player details table
                        dbContext.PlayerDetails.Add(obj);
                        dbContext.SaveChanges();
                        //for selecting the password from the userdetails table for generating the response as password is not in the Updation_Info_Player class
                        updtobj.Password = dbContext.UserDetails.Where(i => i.UserID == obj.UserID).Select(i => i.Password).FirstOrDefault().ToString();

                        // object plyrdtls will store all the values selected by the linq query
                        plyrdtls = dbContext.PlayerDetails.Where(i => i.UserID == obj.UserID).FirstOrDefault();
                        updtobj.UserID = plyrdtls.UserID;
                        updtobj.UserType = plyrdtls.UserType.ToString();
                        updtobj.DOB = Convert.ToDateTime(plyrdtls.DOB);
                        updtobj.Contact_No = plyrdtls.Contact_No;
                        updtobj.Address = plyrdtls.Address;
                        updtobj.Gender = plyrdtls.Gender;
                        updtobj.CountryID = plyrdtls.CountryID;
                        updtobj.StateID = plyrdtls.StateID;
                        updtobj.CityID = plyrdtls.CityID;
                        updtobj.SportID = plyrdtls.SportID;
                        updtobj.Position = plyrdtls.Position;
                        updtobj.Experience = plyrdtls.Experience;
                        updtobj.Wingspan = plyrdtls.Wingspan;
                        updtobj.SchoolName = plyrdtls.SchoolName;
                        updtobj.SchoolAddress = plyrdtls.SchoolAddress;
                        updtobj.Height = Convert.ToInt32(plyrdtls.Height);
                        updtobj.Weight = Convert.ToInt32(plyrdtls.Weight);
                        updtobj.Club = plyrdtls.Club;
                        updtobj.Score = Convert.ToInt32(plyrdtls.Score);
                        updtobj.GPA = Convert.ToInt32(plyrdtls.GPA);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return updtobj;
        }
        public Updation_Info_Coach UpdateCoach(CoachDetail obj)
        {
            //for storing the values selected by the linq query 
            Updation_Info_Coach updtcoach = new Updation_Info_Coach();
            //for selecting the values from coachdetail table
           CoachDetail coachdtls = new CoachDetail();
            try
            {
                using(ExploreDBEntities dbContext=new ExploreDBEntities())
                {
                    //usrtyp will store the value of UserType
                    int usrtyp = dbContext.UserDetails.Where(i => i.UserID == obj.UserID).Select(i => i.UserType).FirstOrDefault();
                    if(usrtyp==1)
                    {
                        // when usrtyp is 1 then the values will be saves in the coachdetail table
                        dbContext.CoachDetails.Add(obj);
                        dbContext.SaveChanges();
                        //coachdtls will store the values of CoachDetail table
                        coachdtls=dbContext.CoachDetails.Where(i => i.UserID == obj.UserID).FirstOrDefault();
                          //  updtcoach will store all the values from coachdtls
                                updtcoach.UserID = coachdtls.UserID;
                                updtcoach.UserType=coachdtls.UserType;
                                updtcoach.Contact_No = coachdtls.Contact_No;
                                updtcoach.      DOB = Convert.ToDateTime(coachdtls.DOB);
                                updtcoach.  Gender = coachdtls .Gender;
                                updtcoach. Address = coachdtls.Address;
                                updtcoach. CountryID = coachdtls.CountryID;
                                updtcoach.StateID = coachdtls.StateID;
                                updtcoach.  CityID = coachdtls.CityID;
                                updtcoach. SportID = coachdtls.SportID;
                                updtcoach.  SchoolName = coachdtls.SchoolName;
                                updtcoach.SchoolAddress = coachdtls.SchoolAddress;
                                updtcoach. AssistantCoach = coachdtls.AssistantCoach;
                                updtcoach. SchoolDivision = coachdtls.SchoolDivision;
                                updtcoach. SessionCost = Convert.ToInt32(coachdtls.SessionCost);
                                updtcoach. SessionHours = Convert.ToInt32(coachdtls.SessionHours);
                                updtcoach.  Experience = coachdtls.Experience;
                    }
                }
            }
                catch(Exception e)
                  {
                    throw;
                
                  }
            return updtcoach;
        }
        public Log_Type LogType(string Email,string Password)
        {
            Log_Type typ = new Log_Type();
            try
            {
               using(ExploreDBEntities dbContext=new ExploreDBEntities())
               {
                   typ = dbContext.UserDetails.Where(i => i.Email == Email & i.Password == Password).Select(i => new Log_Type()
                   {
                       UserID = i.UserID,
                       UserType = i.UserType
                   }).FirstOrDefault();
               }
            }
            catch(Exception e)
            {
                throw e;
            }
            return typ;
        }
        public string ChangePassword(string UserID,string Password,string New_Password)
        {
            string Temp;
            try
            {
                using(ExploreDBEntities dbContext=new ExploreDBEntities())
                {
                    UserDetail obj=dbContext.UserDetails.Where(i=>i.UserID==UserID & i.Password==Password).FirstOrDefault();
                    if(obj==null)
                    {
                        Temp = ("UserID/Password is wrong.");
                    }
                    else
                    {
                        obj.Password = New_Password;
                        dbContext.SaveChanges();
                        Temp = dbContext.UserDetails.Where(i => i.UserID == UserID & i.Password == New_Password).Select(i => i.Password).FirstOrDefault();
                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return Temp;
        }
        public string ForgotPassword(string UserID,string Email)
        {
            string GetPass,Temp,UserName;
            try
            {
                using(ExploreDBEntities dbContext=new ExploreDBEntities())
                {
                    GetPass = dbContext.UserDetails.Where(i => i.UserID == UserID & i.Email == Email).Select(i => i.Password).FirstOrDefault();
                    UserName=dbContext.UserDetails.Where(i => i.UserID == UserID & i.Email == Email).Select(i => i.UserName).FirstOrDefault();
                    if(GetPass==null)
                    {
                        Temp = "The UserID/Email you entered is not registered";
                    }
                    else
                    {
                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress("info@intellirisecorp.com");
                            mail.To.Add(Email);
                            mail.Subject = "PASSWORD: EXPLORE APP";
                            mail.Body = "Hello " + UserName + "," + Environment.NewLine + Environment.NewLine + "Your Password is : " + GetPass;
                            using (SmtpClient smtp = new SmtpClient("smtpout.secureserver.net",80))
                            {
                                smtp.Credentials = new NetworkCredential("info@intellirisecorp.com", "Deepak@123");
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                                GetPass = "Please Check your Email For Password";
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return GetPass;
        }
        public Log_In_Coach LogCoach(int UserType,string Email,string UserID)
        {
            Log_In_Coach loginobj = new Log_In_Coach();
            CoachDetail coachdtls = new CoachDetail();
            try
            {
                using (ExploreDBEntities dbContext = new ExploreDBEntities())
                {
                    loginobj.Email = dbContext.UserDetails.Where(i => i.Email == Email&i.UserType == UserType&i.UserID==UserID).Select(i => i.Email).FirstOrDefault();
                    coachdtls=dbContext.CoachDetails.Where(i => i.UserType == UserType&i.UserID==UserID).FirstOrDefault();
                        loginobj.UserID = coachdtls.UserID;
                        loginobj.UserType = coachdtls.UserType;
                        loginobj.Contact_No = coachdtls.Contact_No;
                        loginobj.DOB = Convert.ToDateTime(coachdtls.DOB);
                        loginobj.Gender = coachdtls.Gender;
                        loginobj.Address = coachdtls.Address;
                        loginobj.CountryID = coachdtls.CountryID;
                        loginobj.StateID = coachdtls.StateID;
                        loginobj.CityID = coachdtls.CityID;
                        loginobj.SportID = coachdtls.SportID;
                        loginobj.SchoolName = coachdtls.SchoolName;
                        loginobj.SchoolAddress = coachdtls.SchoolAddress;
                        loginobj.AssistantCoach = coachdtls.AssistantCoach;
                        loginobj.SchoolDivision = coachdtls.SchoolDivision;
                        loginobj.SessionCost = Convert.ToInt32(coachdtls.SessionCost);
                        loginobj.SessionHours = Convert.ToInt32(coachdtls.SessionHours);
                        loginobj.Experience = coachdtls.Experience;
                }
            }

            catch (Exception e)
            {
                throw e;
            }
            return loginobj;
        }
        public Log_In_Player LogPlayer(int UserType, string Email, string UserID)
        {
            Log_In_Player loginobj = new Log_In_Player();
            PlayerDetail plyrdtls = new PlayerDetail();
            try
            {
                using (ExploreDBEntities dbContext = new ExploreDBEntities())
                {

                    loginobj.Email = dbContext.UserDetails.Where(i => i.Email == Email & i.UserType == UserType & i.UserID == UserID).Select(i => i.Email).FirstOrDefault();
                    plyrdtls = dbContext.PlayerDetails.Where(i => i.UserType == UserType & i.UserID == UserID).FirstOrDefault();
                    loginobj.UserID = plyrdtls.UserID;
                    loginobj.UserType = plyrdtls.UserType;
                    loginobj.Contact_No = plyrdtls.Contact_No;
                    loginobj.DOB = Convert.ToDateTime(plyrdtls.DOB);
                    loginobj.Gender = plyrdtls.Gender;
                    loginobj.Address = plyrdtls.Address;
                    loginobj.CountryID = plyrdtls.CountryID;
                    loginobj.StateID = plyrdtls.StateID;
                    loginobj.CityID = plyrdtls.CityID;
                    loginobj.SportID = plyrdtls.SportID;
                    loginobj.SchoolName = plyrdtls.SchoolName;
                    loginobj.SchoolAddress = plyrdtls.SchoolAddress;
                    loginobj.Position = plyrdtls.Position;
                    loginobj.Experience = plyrdtls.Experience;
                    loginobj.Wingspan = plyrdtls.Wingspan;
                    loginobj.Height = Convert.ToInt32(plyrdtls.Height);
                    loginobj.Weight = Convert.ToInt32(plyrdtls.Weight);
                    loginobj.Club = plyrdtls.Club;
                    loginobj.Score = Convert.ToInt32(plyrdtls.Score);
                    loginobj.GPA = Convert.ToInt32(plyrdtls.GPA);
                }
            }

            catch (Exception e)
            {
                throw e;
            }
            return loginobj;
        }
        public string StatBasketball(Basketball obj)
        {
            string Temp;
            try
            { 
                using(ExploreDBEntities dbContext=new ExploreDBEntities())
                {
                    dbContext.Basketballs.Add(obj);
                    dbContext.SaveChanges();
                    string str = dbContext.Basketballs.Where(i => i.UserID == obj.UserID).Select(i => i.UserID).First();
                    if(str==null)
                    {
                        Temp = "The data has not been saved";
                    }
                    else{
                        Temp = "The data has been saved successfully.";
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return Temp;
        }
        public string Football(Football obj)
        {
            string Temp;
            try
            {
                using (ExploreDBEntities dbContext = new ExploreDBEntities())
                {
                    dbContext.Footballs.Add(obj);
                    dbContext.SaveChanges();
                    string str = dbContext.Footballs.Where(i => i.UserID == obj.UserID).Select(i => i.UserID).First();
                    if (str == null)
                    {
                        Temp = "The data has not been saved";
                    }
                    else
                    {
                        Temp = "The data has been saved successfully.";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Temp;
        }
        public Football ResponseFoot(string UserID)
        {
            Football footbl = new Football();
            try
            {
                using (ExploreDBEntities dbContext = new ExploreDBEntities())
                {
                    footbl = dbContext.Footballs.Where(i => i.UserID == UserID).FirstOrDefault();
                }
            }

            catch (Exception e)
            {
                throw;
            }
            return footbl;
        }
        public Basketball ResponseBasket(string UserID)
        {
            Basketball bsktbl = new Basketball();
            try
            {
                using (ExploreDBEntities dbContext = new ExploreDBEntities())
                {
                    bsktbl = dbContext.Basketballs.Where(i => i.UserID == UserID).FirstOrDefault();
                }
            }

            catch (Exception e)
            {
                throw;
            }
            return bsktbl;
        }
    }
}
            
        //http://localhost:23438/api/Manage/For_Player?UserName=&Email=&Gender=&Sport=&DOB=&Position=&Height=&PlayerWeight=&Wingspan=&Experience=&Address=&pass=&ContactNo=&City=&State=&Country=&Schoolname=&Club=&Act=&GradeAvg=

/*public List<Play_Reg> Regis_player(string UserName, string Email, string Gender, string Sport, DateTime DOB, string Position, string Height, string PlayerWeight, string Wingspan, string Experience, string Address, string pass, string ContactNo, string City, string State, string Country, string Schoolname, string Club, string Act, string GradeAvg)
 {
     List<Play_Reg> Lst = new List<Play_Reg>();
     try
     {
         using (iOS_ExploreEntities1 dbContext = new iOS_ExploreEntities1())
         {
             Reg_Coach objct = dbContext.Reg_Coach.Where(i => i.Email == Email).FirstOrDefault();
             if (objct != null)
             {
                 Lst = new List<Play_Reg> { 
                     new Play_Reg{
                         UserType = "Coach", 
                         Information ="User Already Registered As Coach"
                     }};
             }
             else
             {
                 Reg_Player obj = dbContext.Reg_Player.Where(i => i.Email == Email).FirstOrDefault();
                 if (obj == null)
                 {
                     obj = new Reg_Player();
                     obj.Username = UserName;
                     obj.Email = Email;
                     obj.Gender = Gender;
                     obj.Sport = Sport;
                     obj.DOB = DOB;
                     obj.Position = Position;
                     obj.Height = Height;
                     obj.playWeight = PlayerWeight;
                     obj.Wingspan = Wingspan;
                     obj.Experience = Experience;
                     obj.Addrss = Address;
                     obj.Pass = pass;
                     obj.Phone = ContactNo;
                     obj.City = City;
                     obj.play_State = State;
                     obj.country = Country;
                     obj.SchoolName = Schoolname;
                     obj.Club = Club;
                     obj.ACT = Act;
                     obj.Grade_avg = GradeAvg;
                     dbContext.Reg_Player.Add(obj);
                     dbContext.SaveChanges();
                     Lst = dbContext.Reg_Player.Where(i => i.Email == Email & i.Pass == pass).Select(i => new Play_Reg()
                     {
                         UserType = "Player",
                         UserName = i.Username,
                         Email = i.Email,
                         Gender = i.Gender,
                         Sport = i.Sport,
                         DOB = i.DOB.Value,
                         Position = i.Position,
                         Height = i.Height,
                         PlayerWeight = i.playWeight,
                         Wingspan = i.Wingspan,
                         Experience = i.Experience,
                         Address = i.Addrss,
                         ContactNo = i.Phone,
                         City = i.City,
                         State = i.play_State,
                         country = i.country,
                         SchoolName = i.SchoolName,
                         Club = i.Club,
                         ACT = i.ACT,
                         AverageGrade = i.Grade_avg,
                         Imagepath = i.Image_path,
                         DocmPath = i.DocumntPath,
                     }).ToList();
                 }
                 else
                 {
                     Lst = new List<Play_Reg> { 
                     new Play_Reg{ 
                         Information ="User is Already registered"
                     }};
                 }
                    
             }
         }
     }
     catch (Exception ex)
     {
         throw;
     }
     return Lst;
 }

 //http://localhost:23438/api/Manage/For_Coach?Username=&Email=&Gender=&Sport=&Coach_Type=&Contact=&DOB=&Pass=&Address=&City=&State=&Country=&SchoolName=&SchoolAddrss=&DivisionSchool=&Cost=&Experience=
 public List<Coach_Reg> Regis_Coach(string Username, string Email, string Gender, string Sport, string Coach_Type, string Contact,DateTime DOB, string Pass, string Address, string City, string State, string Country, string SchoolName, string SchoolAddrss, string DivisionSchool, string Cost, string Experience)
 {
     List<Coach_Reg> Lst = new List<Coach_Reg>();
     try
     {
         using (iOS_ExploreEntities1 dbContext = new iOS_ExploreEntities1())
         {
              Reg_Player objct = dbContext.Reg_Player.Where(i => i.Email == Email).FirstOrDefault();
              if (objct != null)
              {
                  Lst = new List<Coach_Reg> { 
                     new Coach_Reg{
                         UserType = "Player", 
                         Information ="User Already Registered As Player"
                     }};
              }
              else
              {
                  Reg_Coach obj = dbContext.Reg_Coach.Where(i => i.Email == Email).FirstOrDefault();
                  if (obj == null)
                  {
                      obj = new Reg_Coach();
                      obj.Username = Username;
                      obj.Email = Email;
                      obj.Gender = Gender;
                      obj.Sport = Sport;
                      obj.DOB = DOB;
                      obj.CoachType = Coach_Type;
                      obj.Phone = Contact;
                      obj.Pass = Pass;
                      obj.Addrss = Address;
                      obj.City = City;
                      obj.play_State = State;
                      obj.country = Country;
                      obj.SchoolName = SchoolName;
                      obj.SchoolAddrss = SchoolAddrss;
                      obj.DivisionSchool = DivisionSchool;
                      obj.Cost = Cost;
                      obj.Experience = Experience;
                      obj.PlayrTrained = 0;
                      dbContext.Reg_Coach.Add(obj);
                      dbContext.SaveChanges();
                      Lst = dbContext.Reg_Coach.Where(i => i.Email == Email & i.Pass == Pass).Select(i => new Coach_Reg()
                      {
                          UserType = "Coach",
                          UserName = i.Username,
                          Email = i.Email,
                          Gender = i.Gender,
                          Sport = i.Sport,
                          DOB = i.DOB.Value,
                          CoachType = i.CoachType,
                          ContactNo = i.Phone,
                          Address = i.Addrss,
                          City = i.City,
                          State = i.play_State,
                          Country = i.country,
                          SchoolName = i.SchoolName,
                          SchoolAddress = i.SchoolAddrss,
                          DivisionSchool = i.DivisionSchool,
                          Cost = i.Cost,
                          Experience = i.Experience,
                          PlayerTrained = i.PlayrTrained.Value,
                          Imagepath = i.Image_path,
                      }).ToList();
                  }
                  else
                  {
                      Lst = new List<Coach_Reg> { 
                     new Coach_Reg{ 
                         Information ="User is Already registered"
                     }};
                  }
              }
         }
     }
     catch (Exception ex)
     {
         throw;
     }
     return Lst;
 }

 //http://localhost:23438/api/Manage/For_Password?Email=&Pass=&New_Pass=
 public string Change_Pass(string Email, string Pass, string New_Pass)
 {
     string Temp;
     try
     {
         using (iOS_ExploreEntities1 dbContext = new iOS_ExploreEntities1())
         {
             Reg_Player obj = dbContext.Reg_Player.Where(i => i.Email == Email & i.Pass == Pass).FirstOrDefault();
             if (obj == null)
             {
                 Reg_Coach objct = dbContext.Reg_Coach.Where(i => i.Email == Email & i.Pass == Pass).FirstOrDefault();
                 if (objct == null)
                 {
                     Temp = "Email/Password is Wrong";
                 }
                 else
                 {
                     objct.Pass = New_Pass;
                     dbContext.SaveChanges();
                     Temp = dbContext.Reg_Coach.Where(i => i.Pass == New_Pass & i.Email == Email).Select(i => i.Pass).FirstOrDefault().ToString();
                 }
             }
             else
             {
                 obj.Pass = New_Pass;
                 dbContext.SaveChanges();
                 Temp = dbContext.Reg_Player.Where(i => i.Pass == New_Pass & i.Email == Email).Select(i => i.Pass).FirstOrDefault().ToString();
             }
         }
     }
     catch (Exception ex)
     {
         throw;
     }
     return Temp;
 }


 //http://localhost:23438/api/Manage/For_Login?Email=&Pass=
 public List<Just_Login> _Login(string Email, string Pass)
 {
     List<Just_Login> Lst = new List<Just_Login>();
     try
     {
         using (iOS_ExploreEntities1 dbContext = new iOS_ExploreEntities1())
         {
                 Lst = dbContext.Reg_Coach.Where(i => i.Email == Email & i.Pass == Pass).Select(i => new Just_Login()
                 {
                     UserType = "** COACH **",
                     UserName = i.Username,
                     Email = i.Email,
                     Gender = i.Gender,
                     Sport = i.Sport,
                     DOB = i.DOB.Value,
                     CoachType = i.CoachType,
                     ContactNo = i.Phone,
                     Address = i.Addrss,
                     City = i.City,
                     State = i.play_State,
                     country = i.country,
                     SchoolName = i.SchoolName,
                     SchoolAddress = i.SchoolAddrss,
                     DivisionSchool = i.DivisionSchool,
                     Cost = i.Cost,
                     Experience = i.Experience,
                     PlayerTrained = i.PlayrTrained.Value,
                     Imagepath = i.Image_path,
                 }).ToList();
                    
             if(Lst == null)
             {
                 Lst = dbContext.Reg_Player.Where(i => i.Email == Email & i.Pass == Pass).Select(i => new Just_Login()
                 {
                     UserType = "** PLAYER **",
                     UserName = i.Username,
                     Email = i.Email,
                     Gender = i.Gender,
                     Sport = i.Sport,
                     DOB = i.DOB.Value,
                     Position = i.Position,
                     Height = i.Height,
                     PlayerWeight = i.playWeight,
                     Wingspan = i.Wingspan,
                     Experience = i.Experience,
                     Address = i.Addrss,
                     ContactNo = i.Phone,
                     City = i.City,
                     State = i.play_State,
                     country = i.country,
                     SchoolName = i.SchoolName,
                     Club = i.Club,
                     ACT = i.ACT,
                     AverageGrade = i.Grade_avg,
                     Imagepath = i.Image_path,
                     DocmPath = i.DocumntPath,
                 }).ToList();
             }
         }
     }
     catch (Exception ex)
     {
         throw;
     }

     return Lst;
 }

 //   http://localhost:23438/api/Manage/ForCountry?id=1
 public List<_Country> _ForCountry (int just)
 {
     List<_Country> Lst = new List<_Country>();
     try
     {
         using(iOS_ExploreEntities1 dbcontext = new iOS_ExploreEntities1())
         {
             Lst = dbcontext.countries.Select(i => new _Country()
                 {
                     Country_id = i.id,
                     CountryName = i.name,
                     SortName = i.sortname
                 }).ToList();
         }
     }
     catch (Exception ex)
     {
         throw;
     }

     return Lst;
 }
 //   http://localhost:23438/api/Manage/ForState?Countryid=
 public List<_State> _ForState(int countryid)
 {
     List<_State> Lst = new List<_State>();
     try
     {
         using (iOS_ExploreEntities1 dbcontext = new iOS_ExploreEntities1())
         {
             Lst = dbcontext.states.Where(i => i.country_id == countryid).Select(i => new _State()
             {
                 State_id = i.id,
                 StateName = i.name,
                 CountryId = i.country_id.Value
             }).ToList();
         }
     }
     catch (Exception ex)
     {
         throw;
     }

     return Lst;
 }

 //   http://localhost:23438/api/Manage/ForCity?stateid=
 public List<_City> _ForCity(int Stateid)
 {
     List<_City> Lst = new List<_City>();
     try
     {
         using (iOS_ExploreEntities1 dbcontext = new iOS_ExploreEntities1())
         {
             Lst = dbcontext.cities.Where(i => i.state_id== Stateid).Select(i => new _City()
             {
                 City_id = i.id,
                 CityName = i.name,
                StateId = i.state_id
             }).ToList();
         }
     }
     catch (Exception ex)
     {
         throw;
     }

     return Lst;
 }

 //http://localhost:23438/api/Manage/For_Login?Email=
 public string ForgetPass(string Email)
 {
     string Getpass = null;
     string Username = null;
     try
     {
         using (iOS_ExploreEntities1 dbContext = new iOS_ExploreEntities1())
         {
             Getpass = dbContext.Reg_Player.Where(i => i.Email == Email).Select(i => i.Pass).FirstOrDefault();
             Username = dbContext.Reg_Player.Where(i => i.Email == Email).Select(i => i.Username).FirstOrDefault();
             if (Getpass == null)
             {
                 Getpass = dbContext.Reg_Coach.Where(i => i.Email == Email).Select(i => i.Pass).FirstOrDefault();
                 Username = dbContext.Reg_Coach.Where(i => i.Email == Email).Select(i => i.Username).FirstOrDefault();
             }
             else if (Getpass == null)
             {
                 Getpass = "This Email Id Does Not Exist";
             }
             else
             {
                 using (MailMessage mail = new MailMessage())
                 {
                     mail.From = new MailAddress("intellirisecorp@yahoo.com");
                     mail.To.Add(Email);
                     mail.Subject = "PASSWORD: EXPLORE APP";
                     mail.Body = "Hello " + Username+"," + Environment.NewLine + Environment.NewLine + "Your Password is : " + Getpass;
                     using (SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587))
                     {
                         smtp.Credentials = new NetworkCredential("intellirisecorp@yahoo.com", "123@intellirise");
                         smtp.EnableSsl = true;
                         smtp.Send(mail);
                         Getpass = "Please Check your Email For Password";
                     }
                 }
             }
         }
     }
     catch (Exception ex)
     {
         Getpass = ex.ToString();
     }
     return Getpass;
 }*/

