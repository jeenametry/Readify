using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Readify.Service.Impl
{
	public class MyErrorHandler : IErrorHandler
	{
		public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
		{
			if (error is FaultException)
			{
				HandleAsFaultException(error as FaultException, version, ref fault);
				return;
			}
			var faultException = new FaultException(error.Message);

			MessageFault msgFault = faultException.CreateMessageFault();
			fault = Message.CreateMessage(version, msgFault, faultException.Action);
		}

		private void HandleAsFaultException(FaultException error, MessageVersion version, ref Message fault)
		{
			MessageFault msgFault = error.CreateMessageFault();
			fault = Message.CreateMessage(version, msgFault, error.Action);
		}

		public bool HandleError(Exception error)
		{
			return true;
		}
	}
}