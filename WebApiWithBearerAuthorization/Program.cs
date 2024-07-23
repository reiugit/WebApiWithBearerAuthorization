using System.Security.Claims;
using WebApiWithBearerAuthorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(AuthConstants.AuthenticationScheme)
    .AddBearerToken();

builder.Services
    .AddAuthorizationBuilder()
    .AddPolicy(AuthConstants.AuthenticatedUserPolicy,
        p => p.RequireAuthenticatedUser());

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("login", () =>
{
    return Results.SignIn(
    new ClaimsPrincipal(
    new ClaimsIdentity(
                [], AuthConstants.AuthenticationScheme)),
        authenticationScheme: AuthConstants.AuthenticationScheme);
});

app.MapGet("/check-authorization", () =>
{
    return Results.Ok("200 OK - You are authorized.");
}).RequireAuthorization(AuthConstants.AuthenticatedUserPolicy);

app.Run();
