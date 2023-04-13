namespace AgarMirror.Exceptions
{

	[System.Serializable]
	public class ServiceLocatorException : System.Exception
	{
		public ServiceLocatorException() { }
		public ServiceLocatorException(string message) : base(message) { }
		public ServiceLocatorException(string message, System.Exception inner) : base(message, inner) { }
		protected ServiceLocatorException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
