using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    [HttpGet("weather")]
    [Authorize]
    public IActionResult GetWeather()
    {
        return Ok("Today's weather is sunny!");
    }

    [HttpGet("login")]
    public IActionResult Login(string username, string password)
    {
        // Validate user credentials (this is a simplified example)
        if (username == "test" && password == "password")
        {
            var tokenGenerator = new JwtTokenGenerator("YourSuperSecretKeyHere"); // Use a secure key
            var token = tokenGenerator.GenerateToken(username);
            return Ok(new { token });
        }

        return Unauthorized();
    }
}
