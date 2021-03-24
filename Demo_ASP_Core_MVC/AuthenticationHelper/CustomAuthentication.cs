using Demo_ASP_Core_MVC.SessionHelper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.AuthenticationHelper
{
    public class AuthenticationSchemeConstants
    {
        public const string CustomAuthenticationScheme = "CustomAuthenticationScheme";
    }

    public class CustomAuthenticationSchemeOptions
            : AuthenticationSchemeOptions
    { }

    public class CustomAuthenticationHandler
        : AuthenticationHandler<CustomAuthenticationSchemeOptions>
    {
        public CustomAuthenticationHandler(
            IOptionsMonitor<CustomAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Validation customiser sur base de la session
            if(!Context.Session.IsLogged())
            {
                return Task.FromResult(AuthenticateResult.Fail("User not logged"));
            }

            // Recuperation des données pour le Ticket d'authentification
            Guid idMember = Context.Session.GetMember().Id;

            // Génération d'un claims pour créer un "AuthenticationTicket"
            var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, idMember.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, nameof(CustomAuthenticationHandler));

            // Génération du ticker sur base de l'identity et du schema
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(claimsIdentity), this.Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
