using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Infrastructure
{
    public static class InfrastractureConstants
    {
        public static class ErrorMessages
        {
            public const string EmailExists = "EmailExists";
            public const string RegistrationFailed = "RegistrationFailed";
            public const string IncorrectCredentials = "Email/Password are incorrect";
            public const string EmailConfirmationFailed = "EmailConfirmationFailed";
            public const string UserNotFound = "UserNotFound";
            public const string ResetPasswordFailed = "ResetPasswordFailed";
            public const string RoleNotFound = "RoleNotFound";
            public const string AddingUserToRoleFailed = "AddingUserToRoleFailed";
            public const string RemovingFromRoleFailed = "RemovingFromRoleFailed";
            public const string RoleExists = "RoleExists";
        }
        public static class AppSettings
        {
            public const string StoragePath = "StoragePath";
        }
    }
}
