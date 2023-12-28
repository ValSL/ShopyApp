using ShopyApp.Features.Authentication.Services.JwtTokenGenerator;

public class TestClass
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	public TestClass(IJwtTokenGenerator jwtTokenGenerator)
	{
		_jwtTokenGenerator = jwtTokenGenerator;
	}
}
