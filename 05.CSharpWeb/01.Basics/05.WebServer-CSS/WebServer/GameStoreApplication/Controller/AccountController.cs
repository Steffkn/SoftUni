namespace HTTPServer.GameStoreApplication.Controller
{
    using System;
    using System.Linq;
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.GameStoreApplication.Extensions;
    using HTTPServer.GameStoreApplication.Models;
    using HTTPServer.GameStoreApplication.ViewModels;
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Http;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;
    using HTTPServer.Server.Infrastructure;
    using HTTPServer.Services;
    using HTTPServer.Services.Contracts;

    public class AccountController : BaseController
    {
        private IUserDataService userData;

        public AccountController(IHttpRequest req)
            : this(req, new UserDataService(new GameStoreContext()))
        {
        }

        public AccountController(IHttpRequest req, IUserDataService userData)
            : base(req)
        {
            this.userData = userData;
        }

        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\register");
        }

        public IHttpResponse Register(IHttpRequest req, RegisterViewModel model)
        {
            if (model != null)
            {
                var isValid = this.ValidateRegisterViewModel(model);
                if (!isValid)
                {
                    return this.FileViewResponse(@"account\register");
                }

                var passwordHash = PasswordUtilities.GenerateHash(model.Password);
                var user = this.userData.Create(model.Email, passwordHash, model.FullName);
                if (user != null)
                {
                    this.User = user;
                    req.Session.Add(SessionStore.CurrentUserKey, this.User);
                    req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
                }
            }

            return new RedirectResponse("/");
        }

        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req, LoginViewModel model)
        {
            if (model != null)
            {
                var isValid = this.ValidateLoginViewModel(model);
                if (!isValid)
                {
                    return this.FileViewResponse(@"account\login");
                }

                UserPrincipal user = this.userData.GetByEmail(model.Email);
                if (user != null)
                {
                    user.IsAuthenticated = true;
                    this.User = user;
                    req.Session.Add(SessionStore.CurrentUserKey, this.User);
                    if (!req.Session.Contains(ShoppingCart.SessionKey))
                    {
                        req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
                    }
                }
            }

            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Add(SessionStore.CurrentUserKey, new UserPrincipal() { IsAuthenticated = false });
            return new RedirectResponse("/");
        }

        private bool ValidateLoginViewModel(LoginViewModel model)
        {
            var userEmail = model.Email;
            if (string.IsNullOrEmpty(userEmail))
            {
                return false;
            }

            var userExistsByEmail = this.userData.ExistsByEmail(userEmail);

            if (!userExistsByEmail)
            {
                return false;
            }

            var isValidEmail = userEmail.Contains("@") && userEmail.Contains(".");

            if (!isValidEmail)
            {
                return false;
            }

            var userPassword = model.Password;
            if (string.IsNullOrEmpty(userPassword))
            {
                return false;
            }

            return true;
        }

        private bool ValidateRegisterViewModel(RegisterViewModel model)
        {
            var userEmail = model.Email;
            if (string.IsNullOrEmpty(userEmail))
            {
                return false;
            }

            var userExistsByEmail = this.userData.ExistsByEmail(userEmail);

            if (userExistsByEmail)
            {
                return false;
            }

            var isValidEmail = userEmail.Contains("@") && userEmail.Contains(".");

            if (!isValidEmail)
            {
                return false;
            }

            var userPassword = model.Password;
            var userConfirmPassword = model.ConfirmPassword;
            if (string.IsNullOrEmpty(userPassword) ||
                string.IsNullOrEmpty(userConfirmPassword) ||
                userPassword != userConfirmPassword)
            {
                return false;
            }

            var isValidPassword = userPassword.Any(ch => Char.IsNumber(ch)) &&
                userPassword.Any(ch => Char.IsLower(ch)) &&
                userPassword.Any(ch => Char.IsUpper(ch));

            if (!isValidPassword)
            {
                return false;
            }

            return true;
        }

        private void DisplayError(string errorMessage)
        {
            this.ViewData["error"] = errorMessage;
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "none";
        }
    }
}
