using AppRegistration.Contracts;
using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace AppRegistration.Core
{
    internal class AppRegistrationRequest : IAppRegistrationRequest
    {
        public AppRegistrationCreateRequest Create(ServiceBusReceivedMessage Message)
        {
            string[] missingPayloadValue = [];

            AppRegistrationCreateRequest? appRegistrationCreateRequestPayload = JsonSerializer.Deserialize<AppRegistrationCreateRequest>(Message.Body);

            if (appRegistrationCreateRequestPayload!.Workload is null)
            {
                throw new ArgumentException("App registration create payload did not contain 'Workload'");
            }

            if (appRegistrationCreateRequestPayload!.Workload.Description is null)
            {
                missingPayloadValue.Append<string>("Description").ToArray();
            }

            if (appRegistrationCreateRequestPayload!.Workload.Environment is null)
            {
                missingPayloadValue.Append<string>("Environment").ToArray();
            }

            if (appRegistrationCreateRequestPayload!.Workload.Permission is null)
            {
                missingPayloadValue.Append<string>("Permission").ToArray();
            }

            if (appRegistrationCreateRequestPayload!.Workload.Requester is null)
            {
                missingPayloadValue.Append<string>("Requester").ToArray();
            }

            if (appRegistrationCreateRequestPayload!.Workload.TicketNumber is null)
            {
                missingPayloadValue.Append<string>("TicketNumber").ToArray();
            }

            if (appRegistrationCreateRequestPayload!.Workload.ItsmEndpoint is null)
            {
                missingPayloadValue.Append<string>("ItsmEndpoint").ToArray();
            }

            if (appRegistrationCreateRequestPayload!.Workload.TechnicalOwner is null)
            {
                missingPayloadValue.Append<string>("TechnicalOwner").ToArray();
            }

            if (missingPayloadValue is not null)
            {
                throw new ArgumentException(string.Format("Payload values missing: {0}", string.Join(',', missingPayloadValue)));
            }

            return appRegistrationCreateRequestPayload;
        }
    }
}
