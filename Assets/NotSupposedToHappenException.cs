using System;

public class NotSupposedToHappenException : Exception
{
	public NotSupposedToHappenException() { }
	public NotSupposedToHappenException(string message) : base(message) { }
	public NotSupposedToHappenException(string message, Exception inner) : base(message, inner) { }

}
