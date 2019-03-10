using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace SARHU
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey1 = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey1 = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue1;

        protected void Page_Init2(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey1];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue1 = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue1;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue1 = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue1;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey1)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue1
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad1;
        }

        protected void master_Page_PreLoad1(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }

        protected void Page_Load1(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut1(object sender, LoginCancelEventArgs e)
        {
        }
    }

}