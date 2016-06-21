
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Explore_App.Models;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.Diagnostics;

namespace Explore_App.Controllers
{
    public class ManageController : ApiController
    {
        [HttpGet]
        public Response<User_Details> Registration(string UserID,string UserName,string Email,string Password,string UserType)
        {
            // for retrieving the Userdetails from the modelservises
            ModelServices Details=new ModelServices();
            // for accessing the objct of modelservices in controller
            UserDetail obj=new UserDetail();
            //for accessing the objct of modelservices in controller
           User_Details list=new User_Details();
            //for generating the response
            Response<User_Details> res=new Response<User_Details>();
            try
            {
                //all the values entered by the user will get stored in userdetail table
                obj.UserID=UserID;
                obj.UserName=UserName;
                obj.Email=Email;
                obj.Password=Password;
                obj.UserType=Convert.ToInt32(UserType);
                //stores the value returned by the function User
                list=Details.User(obj);
                //generate the response
                if(list !=null)
                {
                    res.Passage(0,true,"Registration has been Successfull",list);
                }
                else
                {
                    res.Passage(1,false,"Registration Failed",null);
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return res;
        }
    [HttpGet]
        public Response<Updation_Info_Player> Update_Player(string UserID,string UserType,string Contact_No,DateTime DOB,string Gender,string Address,string CountryID,
                                    string CityID,string StateID,string SportID,string Position,string Experience,string SchoolName,string SchoolAddress,
                                   string Wingspan, string Height,string Weight,string Club,string Score,string GPA)
     {
        // for retrieving the update player info from modelservices
        ModelServices Update = new ModelServices();
        // for accessing the obj of modelservices in controller
        PlayerDetail obj = new PlayerDetail();
        // for accessing the objct of update_info_player in controller
        Updation_Info_Player updtobj = new Updation_Info_Player();
        // a response type objct for generating the response
            Response<Updation_Info_Player> res=new Response<Updation_Info_Player>();
        try
        {
            //all the values enetered by the user will get stored in the obect of player detail
            obj.UserID = UserID;
            obj.UserType =Convert.ToInt32( UserType);
            obj.Contact_No = Contact_No;
            obj.DOB = DOB;
            obj.Gender = Gender;
            obj.Address = Address;
            obj.CountryID = Convert.ToInt32(CountryID);
            obj.StateID = Convert.ToInt32(StateID);
            obj.CityID = Convert.ToInt32(CityID);
            obj.SportID = Convert.ToInt32(SportID);
            obj.Position = Position;
            obj.Experience = Experience;
            obj.SchoolName= SchoolName;
            obj.SchoolAddress = SchoolAddress;
            obj.Wingspan = Wingspan;
            obj.Height = Convert.ToInt32(Height);
            obj.Weight = Convert.ToInt32(Weight);
            obj.Club = Club;
            obj.Score = Convert.ToInt32(Score);
            obj.GPA = Convert.ToInt32(GPA);
            // retrieve the value return by the function of modelservices
            updtobj = Update.UpdatePlayer(obj);
            //generate the response
            if(updtobj!=null)
             {
                    res.Passage(0,true,"Your Profile has been updated",updtobj);
                }
                else
                {
                    res.Passage(1,false,"Updation Failed",null);
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return res;
        }
        [HttpGet]
        public Response<Updation_Info_Coach> Update_Coach(string UserID,string UserType,string Contact_No,DateTime DOB,string Gender,
                                                               string Address,string CountryID,string StateID,string CityID,string SportID,
                                                               string SchoolName,string SchoolAddress,string AssistantCoach,string SchoolDivision,
                                                               string SessionCost,string SessionHours,string Experience)
    {
            //for retrieving the value from the modelservices
        ModelServices Update = new ModelServices();
            //for accesing the CoachDetail obj in controller
        CoachDetail obj = new CoachDetail();
            //for accessing the updtcoach of modelservices in controller
        Updation_Info_Coach updtcoach = new Updation_Info_Coach();
            //for generating the response
            Response<Updation_Info_Coach> res=new Response<Updation_Info_Coach>();
        try
        {
            //obj will store all the values entered by the user
            obj.UserID = UserID;
            obj.UserType = Convert.ToInt32(UserType);
            obj.Contact_No = Contact_No;
            obj.DOB = DOB;
            obj.Gender = Gender;
            obj.Address = Address;
            obj.CountryID =Convert.ToInt16( CountryID);
            obj.StateID = Convert.ToInt32(StateID);
            obj.CityID =Convert.ToInt32( CityID);
            obj.SportID = Convert.ToInt32(SportID);
            obj.SchoolName = SchoolName;
            obj.SchoolAddress = SchoolAddress;
            obj.AssistantCoach = AssistantCoach;
            obj.SchoolDivision = SchoolDivision;
            obj.SessionCost = Convert.ToInt32(SessionCost);
            obj.SessionHours = Convert.ToInt32(SessionHours);
            obj.Experience = Experience;
            //store the value returned by the function UpdateCoach
            updtcoach = Update.UpdateCoach(obj);
            //generate the response
            if(updtcoach!=null)
            {
                res.Passage(0, true, "Your Profile has been Updated", updtcoach);
            }
            else
            {
                res.Passage(1, false, "Updation failed", null);
            }
        }
        catch(Exception e)
        {
            throw;
        }
        return res;
    }
        //For getting the usertype from UserDetails table
        [HttpGet]
        public Response<Log_Type> Usertype(string Email, string Password)
        {
            //For accessing the ModelServices function
            ModelServices usr = new ModelServices();
            //For accesssing the Log_Type class in controller
            Log_Type typ = new Log_Type();
            //For generating the response of Log_Type
            Response<Log_Type> res = new Response<Log_Type>();
            try
            {
                //store the value returned by LogType function of ModelServices
                typ = usr.LogType(Email, Password);
                //generate the response if typ is not null
                if (typ!=null)
                {
                    res.Passage(0, true, "Successfull", typ);
                }
                else
                {
                    res.Passage(1, false, "The password or email you entered is incorrect", typ);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return res;
        }
        //For changing the password
        [HttpGet]
        public Response<string> Change_Password(string UserID,string Password,string New_Password)
        {
            string str;
            //For accessing the ModelServices function
            ModelServices chngPass = new ModelServices();
            //For generating the string type response
            Response<string> res = new Response<string>();
            try
            {
                //str will store the value returned by function ChangePassword
                str = chngPass.ChangePassword(UserID, Password, New_Password);
                //generate the response if str is not null
                if(str!=null)
                {
                    res.Passage(0, true, "SUCCESSFULL", null);
                }
                else
                {
                    res.Passage(1, false, "Password is not changed", null);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return res;
        }
        //for emailing the password if user has been forgotten the password
        [HttpGet]
        public Response<string> Forgot_Pass(string UserID,string Email)
        {
            string str;
            //For accessing the ModelServices function
            ModelServices Forgot = new ModelServices();
            //For generating the string type response
            Response<string> res = new Response<string>();
            try
            {
                //str will store the value returned by the functionForgotPassword
                str = Forgot.ForgotPassword(UserID, Email);
                if(str!=null)
                {
                    res.Passage(0, true, "The Password has been sent To your Email ID", null);
                }
                else
                {
                    res.Passage(1, false, "Failed", null);
                }
            }
            catch(Exception e)
            {
                throw;
            }
            return res;
        }
        //For login of the coach if the usertype is 1
        [HttpGet]
        public Response<Log_In_Coach> LogIN_Coach(int UserType,string Email,string UserID)
        {
            //foraccessing the modelservices function
            ModelServices Login = new ModelServices();
            //for accessing the Log_In_Coach class 
            Log_In_Coach loginobj = new Log_In_Coach();
            //res object is made for generating the response of Log_In_Coach type
            Response<Log_In_Coach> res = new Response<Log_In_Coach>();
            try
            {
                //loginobj will store the value returned by the function LogCoach
                loginobj = Login.LogCoach(UserType,Email,UserID);
                if (loginobj != null)
                {
                    res.Passage(0, true, "Successfull", loginobj);
                }
                else
                {
                    res.Passage(1, false, "The password or email you entered is incorrect", loginobj);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return res;
        }
        //for the login of player if the usertype is 2
        [HttpGet]
        public Response<Log_In_Player> LogIN_Player(int UserType, string Email, string UserID)
        {
            //for accessong the modelsservices function
            ModelServices Login = new ModelServices();
            //For accessing the Log_in_Player class in controller
            Log_In_Player loginobj = new Log_In_Player();
            //for generating the Log_In_Coach type response
            Response<Log_In_Player> res = new Response<Log_In_Player>();
            try
            {
                //loginobj will store the value returned by LogPlayer
                loginobj = Login.LogPlayer(UserType, Email, UserID);
                if (loginobj != null)
                {
                    res.Passage(0, true, "Successfull", loginobj);
                }
                else
                {
                    res.Passage(1, false, "The password or email you entered is incorrect", loginobj);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return res;
        }
        //for saving the statistic of basketball player
       [HttpGet]
        public Response<string> Get_Stat_BasketBall(string UserID,int SportID,int P_YDS,int R_YDS,int Tot_TDs,int Tot_Sacks,int RU_YDs,
                                                int Tot_PTS,int Tot_Tcks,int Tot_YDs,int Tot_Ints)
       {
           string Temp=null;
           //for accessing theModelServicers function
           ModelServices StatBasket=new ModelServices();
           //Basketball Type obj for storing the values in table variables
           Basketball obj = new Basketball();
           //for generating the string type response
           Response<string> res = new Response<string>();
           try
           {
               //the values entered by the user will be stored in the variables of obj
               obj.UserID = UserID;
               obj.SportID = SportID;
               obj.P_YDS = P_YDS;
               obj.R_YDS = R_YDS;
               obj.Tot_TDs = Tot_TDs;
               obj.Tot_Sacks = Tot_Sacks;
               obj.RU_YDs = RU_YDs;
               obj.Tot_PTS = Tot_PTS;
               obj.Tot_Tcks = Tot_Tcks;
               obj.Tot_YDs = Tot_YDs;
               obj.Tot_Ints = Tot_Ints;
               //temp will store the value returned by the function StatBasketball 
               Temp = StatBasket.StatBasketball(obj);
               if(Temp!=null)
               {
                   res.Passage(0, true, "Successfull", Temp);
               }
               else
               {
                   res.Passage(1, false, "Failed", Temp);
               }
           }
           catch(Exception e)
           {
               throw;
           }
           return res;
       }
       [HttpGet]
       public Response<string> Get_Stat_FootBall(string UserID, int SportID, float PTS, float FG, float FT, float TP, float RBS,
                                               float AST, float STL, float BLK, float MIN)
       {
           string Temp = null;
           ModelServices StatFoot = new ModelServices();
           Football obj = new Football();
           Response<string> res = new Response<string>();
           try
           {
               obj.UserID = UserID;
               obj.SportID = SportID;
               obj.PTS = PTS;
               obj.FG = FG;
               obj.FT = FT;
               obj.TP = TP;
               obj.RBS = RBS;
               obj.AST = AST;
               obj.STL = STL;
               obj.BLK = BLK;
               obj.MIN = MIN;
               Temp = StatFoot.Football(obj);
               if (Temp != null)
               {
                   res.Passage(0, true, "Successfull", Temp);
               }
               else
               {
                   res.Passage(1, false, "Failed", Temp);
               }
           }
           catch (Exception e)
           {
               throw;
           }
           return res;
       }
        [HttpGet]
       public Response<Basketball> For_response_Basket(string UserID)
       {
           ModelServices respobj = new ModelServices();
           Basketball bsktbl = new Basketball();
           Response<Basketball> res = new Response<Basketball>();
           try
           {
               bsktbl = respobj.ResponseBasket(UserID);
               if(bsktbl!=null)
               {
                   res.Passage(0, true, "Successfull", bsktbl);
               }
               else
               {
                   res.Passage(1, false, "Failed", bsktbl);
               }
           }
           catch(Exception e)
           {
               throw;
           }
           return res;
       }
        [HttpGet]
        public Response<Football> For_response_Foot(string UserID)
        {
            ModelServices respobj = new ModelServices();
            Football footbl = new Football();
            Response<Football> res = new Response<Football>();
            try
            {
                footbl = respobj.ResponseFoot(UserID);
                if (footbl != null)
                {
                    res.Passage(0, true, "Successfull", footbl);
                }
                else
                {
                    res.Passage(1, false, "Failed", footbl);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return res;
        }
        //[HttpPost]
        //public Response<FileUploadModal> Upload_Image(string FileType, string UserID)
        //{
        //    Upload modal = new Upload();
        //    modal.FileType = FileType;
        //    modal.UserID = UserID;
        //    FileUploadModal result=new FileUploadModal();
        //    ImageDetail obj = new ImageDetail();
        //    Response<FileUploadModal> res = new Response<FileUploadModal>();
        //    string Fname=string.Empty;
        //    try
        //    {
        //         HttpContextWrapper objWrapper=GetHttpContext(this.Request);
        //        HttpFileCollectionBase collection=objWrapper.Request.Files;
        //        if(collection.Count>0)
        //        {
        //            foreach(string file in collection)
        //            {
        //                string Email=file.ToString();
        //                HttpPostedFileBase file1=collection.Get(file);
        //                if(file1.ContentType=="image/png"||file1.ContentType=="image/jpeg"||file1.ContentType=="image/*")
        //                {
        //                    result.UserID=Guid.NewGuid().ToString("n")+"jpg";
        //                    result.FileName=ConstantValues.imagePath+result.UserID;
        //                   Stream streamRequest=file1.InputStream;
        //                    Image img=System.Drawing.Image.FromStream(streamRequest);
        //                    img.Save(HttpContext.Current.Request.PhysicalApplicationPath +"UploadFiles\\"+ result.UserID, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                    obj.UserID = result.UserID;
        //                    obj.FileName = result.FileName;
        //                    using(ExploreDBEntities dbContext=new ExploreDBEntities())
        //                    {
        //                        dbContext.ImageDetails.Add(obj);
        //                        dbContext.SaveChanges();
        //                        ImageDetail temp=dbContext.ImageDetails.Where(i => i.FileName == result.FileName).FirstOrDefault();
        //                        if(temp!=null)
        //                        {
        //                           string status = "File has been uploaded";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    obj.ImageID = Convert.ToInt32(Guid.NewGuid());
        //                    result.UserID=Guid.NewGuid().ToString("n").Substring(0,5)+".pdf";
        //                    obj.FileType = Convert.ToInt32(FileType);
        //                    result.FileName=ConstantValues.imagePath+result.UserID;
        //                    obj.UserID = result.UserID;
        //                    obj.FileName = result.FileName;
                            
                           
        //                    file1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "UploadFiles\\" + result.FileName);
        //                    using(ExploreDBEntities dbContext=new ExploreDBEntities())
        //                    {
        //                        dbContext.ImageDetails.Add(obj);
        //                        dbContext.SaveChanges();
        //                        ImageDetail Temp = dbContext.ImageDetails.Where(i => i.FileName == result.FileName).FirstOrDefault();
        //                        if(Temp!=null)
        //                        {
        //                           string status = "File has been Uploaded";
        //                        }
        //                    }
        //                }
        //            }
        //            res.Passage(0, true, "file uploaded", result);
        //        }
        //        else
        //        {
        //            res.Passage(1, false, "No file found", result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    return res;
        //}
        
        //private HttpContextWrapper GetHttpContext(HttpRequestMessage request = null)
        //{
        //    request = request ?? Request;

        //    if (request.Properties.ContainsKey("MS_HttpContext"))
        //    {
        //        return ((HttpContextWrapper)request.Properties["MS_HttpContext"]);
        //    }
        //    else if (HttpContext.Current != null)
        //    {
        //        return new HttpContextWrapper(HttpContext.Current);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}

/*public Response<List<Play_Reg>> For_Player( string UserName, string Email, string Gender, string Sport, DateTime DOB, string Position, string Height, string PlayerWeight, string Wingspan, string Experience, string Address,string pass, string ContactNo,string City, string State, string Country,string Schoolname, string Club, string Act, string GradeAvg)
  {
      try
      {
          List<Play_Reg> Reg_obj = new List<Play_Reg>();
          Reg_obj = Mod.Regis_player( UserName,  Email, Gender,  Sport, DOB,  Position,  Height,  PlayerWeight, Wingspan,  Experience, Address, pass, ContactNo, City, State,  Country, Schoolname, Club, Act, GradeAvg);

          if (Reg_obj != null)
          {
              Play_obj.Passage(0, true, "Successfull", Reg_obj);
          }
          else
          {
              Play_obj.Passage(1, false, "USER ALREADY EXIST", Reg_obj);
          }
      }
      catch (Exception ex)
      {
          throw;
      }
      return Play_obj;
  }

  Response<List<Coach_Reg>> Coach_obj = new Response<List<Coach_Reg>>();
  [HttpGet]
  public Response<List<Coach_Reg>> For_Coach(string Username, string Email, string Gender, string Sport, string Coach_Type, string Contact,DateTime DOB, string Pass, string Address, string City, string State, string Country, string SchoolName, string SchoolAddrss, string DivisionSchool ,string Cost, string Experience)
  {
      try
      {
          List<Coach_Reg> Reg_obj = new List<Coach_Reg>();

          Reg_obj = Mod.Regis_Coach(Username, Email, Gender, Sport, Coach_Type, Contact,DOB, Pass, Address, City, State, Country, SchoolName, SchoolAddrss, DivisionSchool , Cost, Experience);

          if (Reg_obj != null)
          {
              Coach_obj.Passage(0, true, "Successfull", Reg_obj);
          }
          else
          {
              Coach_obj.Passage(1, false, "USER ALREADY EXIST", Reg_obj);
          }
      }
      catch (Exception ex)
      {
          throw;
      }

      return Coach_obj;
  }

  Response<Chng_password> New_Pass_obj = new Response<Chng_password>();        

  [HttpGet]
  public Response<Chng_password> For_Password(string Email, string Pass, string New_Pass)
  {
      try
      {
          Chng_password Reg_obj = new Chng_password();

          string str = Mod.Change_Pass(Email, Pass, New_Pass);
          Reg_obj.NewPassword = str;
          if (str != null)
          {
              New_Pass_obj.Passage(0, true, "New Password Is Saved", Reg_obj);
          }
          else
          {
              New_Pass_obj.Passage(1, false, "Password is Not Saved", Reg_obj);
          }
      }
      catch (Exception ex)
      {
          throw;
      }
      return New_Pass_obj;
  }

  Response<List<Just_Login>> Login_obj = new Response<List<Just_Login>>();
  [HttpGet]
  public Response<List<Just_Login>> For_Login( string Email, string Pass)
  {
      try
      {
          List<Just_Login> Reg_obj = new List<Just_Login>();

          Reg_obj = Mod._Login(Email, Pass);

          if (Reg_obj != null)
          {
              Login_obj.Passage(0, true, "SUCCESSFULL", Reg_obj);
          }
          else
          {
              Login_obj.Passage(1, false, "Email/Password is Wrong", Reg_obj);
          }
      }
      catch (Exception ex)
      {
          throw;
      }

      return Login_obj;
  }

  Response<ForMail> FM_obj = new Response<ForMail>();
  [HttpGet]
  public Response<ForMail> ForgetPass(string Email)
  {
      try
      {
          ForMail FM = new ForMail();
          string str = Mod.ForgetPass(Email);
          FM._Mail = str;
          if (str != null)
          {
              FM_obj.Passage(0, true, "Password Send To Your Email ID", FM);
          }
          else
          {
              FM_obj.Passage(1, false, "Something Went Wrong", FM);
          }
      }
      catch (Exception ex)
      {
          throw;
      }
      return FM_obj;
  }

  Response<List<_Country>> Countryobj = new Response<List<_Country>>();
 [HttpGet]
  public Response<List<_Country>> ForCountry(int id)
  {
      try
      {
          List<_Country> _CntryObj = new List<_Country>();
          _CntryObj = Mod._ForCountry(id);
          if (_CntryObj != null)
              {
                  Countryobj.Passage(0, true, "SUCCESSFULL", _CntryObj);
              }
              else
              {
                  Countryobj.Passage(1, false, "UNSUCCESSFULL", _CntryObj);
              }
      }
      catch (Exception ex)
      {
          throw;
      }
      return Countryobj;
  }
 Response<List<_State>> stateobj = new Response<List<_State>>();
 [HttpGet]
 public Response<List<_State>> ForState(int Countryid)
 {
     try
     {
         List<_State> _CntryObj = new List<_State>();
         _CntryObj = Mod._ForState(Countryid);
         if (_CntryObj != null)
         {
             stateobj.Passage(0, true, "SUCCESSFULL", _CntryObj);
         }
         else
         {
             stateobj.Passage(1, false, "UNSUCCESSFULL", _CntryObj);
         }
     }
     catch (Exception ex)
     {
         throw;
     }
     return stateobj;
 }

 Response<List<_City>> cityobj = new Response<List<_City>>();
 [HttpGet]
 public Response<List<_City>> Forcity(int stateid)
 {
     try
     {
         List<_City> _CntryObj = new List<_City>();
         _CntryObj = Mod._ForCity(stateid);
         if (_CntryObj != null)
         {
             cityobj.Passage(0, true, "SUCCESSFULL", _CntryObj);
         }
         else
         {
             cityobj.Passage(1, false, "UNSUCCESSFULL", _CntryObj);
         }
     }
     catch (Exception ex)
     {
         throw;
     }
     return cityobj;
 }


 http://localhost:23438/api/Manage/UploadFile
  [HttpPost]
  public Response<FileUploadModal> UploadFile()
  {
      Response<FileUploadModal> response = new Response<FileUploadModal>();
      FileUploadModal result = new FileUploadModal();
      string fileName = string.Empty;
      try
      {
          HttpContextWrapper objwrapper = GetHttpContext(this.Request);
          HttpFileCollectionBase collection = objwrapper.Request.Files;
          if (collection.Count > 0)
          {
              foreach (string file in collection)
              {
                  string Email = file.ToString();
                  HttpPostedFileBase file1 = collection.Get(file);
                  if (file1.ContentType == "image/jpeg" || file1.ContentType == "image/png" || file1.ContentType == "image/*")
                  {
                      result.name = Guid.NewGuid().ToString("n") + ".jpg";
                      result.path = ConstantValues.imagePath + result.name;
                      Stream requestStream = file1.InputStream;
                      Image img = System.Drawing.Image.FromStream(requestStream);
                      img.Save(HttpContext.Current.Request.PhysicalApplicationPath + "UploadFiles\\" + result.name, System.Drawing.Imaging.ImageFormat.Jpeg);
                      using (iOS_ExploreEntities1 dbContext = new iOS_ExploreEntities1())
                      {
                          Reg_Coach objct = dbContext.Reg_Coach.Where(i => i.Email == Email).FirstOrDefault();
                          if (objct != null)
                          {
                              objct.Image_path = result.path;
                              dbContext.SaveChanges();
                              result.path = dbContext.Reg_Coach.Where(i => i.Email == Email).Select(i => i.Image_path).FirstOrDefault().ToString();
                          }
                          else
                          {
                              Reg_Player obj = dbContext.Reg_Player.Where(i => i.Email == Email).FirstOrDefault();
                              if (obj != null)
                              {
                                  obj.Image_path = result.path;
                                  dbContext.SaveChanges();
                                  result.path = dbContext.Reg_Player.Where(i => i.Email == Email).Select(i => i.Image_path).FirstOrDefault().ToString();
                              }
                          }
                      }
                  }
                  if (file1.ContentType == "video/quicktime" || file1.ContentType == "video/mp4")
                  {
                      byte[] videofile = new byte[file1.ContentLength];
                      file1.InputStream.Read(videofile, 0, file1.ContentLength);
                      BinaryWriter Writer = null;
                      if (videofile.Length > 0)
                      {
                          result.name = Guid.NewGuid().ToString().Substring(0, 7) + ".MOV";
                          result.path = ConstantValues.imagePath + result.name;
                          if (file1.ContentType == "video/mp4")
                          {
                              result.name = Guid.NewGuid().ToString().Substring(0, 7) + ".mp4";
                              result.path = ConstantValues.imagePath + result.name;
                          }
                          Writer = new BinaryWriter(File.OpenWrite(HttpContext.Current.Request.PhysicalApplicationPath + "UploadFiles\\" + result.name));
                          Writer.Write(videofile);
                          Writer.Flush();
                          Writer.Close();
                          using (iOS_ExploreEntities dbContext = new iOS_ExploreEntities())
                          {
                              Reg_Coach objct = dbContext.Reg_Coach.Where(i => i.Email == Email).FirstOrDefault();
                              if (objct != null)
                              {
                                  objct.Image_path = result.path;
                                  dbContext.SaveChanges();
                                  result.path = dbContext.Reg_Coach.Where(i => i.Email == Email).Select(i => i.Image_path).FirstOrDefault().ToString();
                              }
                              else
                              {
                                  Reg_Player obj = dbContext.Reg_Player.Where(i => i.Email == Email).FirstOrDefault();
                                  if (obj != null)
                                  {
                                      obj.Image_path = result.path;
                                      dbContext.SaveChanges();
                                      result.path = dbContext.Reg_Player.Where(i => i.Email == Email).Select(i => i.Image_path).FirstOrDefault().ToString();
                                  }
                              }
                          }
                      }
                  }
                  else
                  {
                      result.name = Guid.NewGuid().ToString("n").Substring(0, 5) + ".pdf";
                      result.path = ConstantValues.imagePath + result.name;
                      file1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "UploadFiles\\" + result.name);
                      using (iOS_ExploreEntities1 dbContext = new iOS_ExploreEntities1())
                      {
                          Reg_Player obj = dbContext.Reg_Player.Where(i => i.Email == Email).FirstOrDefault();
                          if (obj != null)
                          {
                              obj.DocumntPath = result.path;
                              dbContext.SaveChanges();
                              result.path = dbContext.Reg_Player.Where(i => i.Email == Email).Select(i => i.DocumntPath).FirstOrDefault().ToString();
                          }
                      }
                  }
              }
              response.Passage(0, true, "file uploaded", result);
          }
          else
          {
              response.Passage(1, false, "No file found", result);
          }

      }
      catch (Exception ex)
      {
          throw;
      }

      return response;
  }

  private HttpContextWrapper GetHttpContext(HttpRequestMessage request = null)
  {
      request = request ?? Request;

      if (request.Properties.ContainsKey("MS_HttpContext"))
      {
          return ((HttpContextWrapper)request.Properties["MS_HttpContext"]);
      }
      else if (HttpContext.Current != null)
      {
          return new HttpContextWrapper(HttpContext.Current);
      }
      else
      {
          return null;
      }
  }*/


