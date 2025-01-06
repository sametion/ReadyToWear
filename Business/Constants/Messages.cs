using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "product added";
        public static string ProductNameInvalid = " invalid message";
        public static string MaintenanceTime = "System is under maintenance";
        public static string ProductsListed = "Products have been listed";

        public static string ProductCountOfCategoryError="A category must contain up to 10 products .";

        public static string ProductUpdated ="Product has been updated";
        public static string ProductNameAlreadyExist="product Name already exist please change";
        public static string CategoryLimitExceded="new product cant be added because ofcategory limit exceeded";
        public static string AuthorizationDenied="You re not Authorized";
        public static string UserRegistered="";
        public static string UserNotFound="";
        public static string PasswordError="";
        public static string SuccessfulLogin="";
        public static string UserAlreadyExists="";
        public static string AccessTokenCreated="token has been created";
    }
}
