using Azure.Messaging.ServiceBus;

namespace AppRegistration.Contracts
{
    public interface IAppRegistrationRequest
    {
        AppRegistrationCreateRequest Create(ServiceBusReceivedMessage Message);
    }
}
