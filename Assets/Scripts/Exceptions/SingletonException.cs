namespace AgarMirror.Exceptions
{

	[System.Serializable]
	public class SingletonException : System.Exception
	{
		public SingletonException() { }
		public SingletonException(string message) : base(message) { }
		public SingletonException(string message, System.Exception inner) : base(message, inner) { }
		protected SingletonException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
