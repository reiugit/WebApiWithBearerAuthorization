using Microsoft.AspNetCore.Authentication.BearerToken;

namespace WebApiWithBearerAuthorization;

public static class AuthConstants
{
    public const string AuthenticationScheme = BearerTokenDefaults.AuthenticationScheme;
    public const string AuthenticatedUserPolicy = "AuthenticatedUserPolicy";

}
