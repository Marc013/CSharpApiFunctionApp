using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace My_AppRegistration
{
    public class HandleAppRegistrationRequest
    {
        private readonly ILogger<HandleAppRegistrationRequest> _logger;

        public HandleAppRegistrationRequest(ILogger<HandleAppRegistrationRequest> logger)
        {
            _logger = logger;
        }

        [Function(nameof(HandleAppRegistrationRequest))]
        public async Task Run(
            [ServiceBusTrigger("%appRegistrationTopicName%", "%appRegistrationSubscriptionName%", Connection = "ServiceBusConnection")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            //DEFAULT CODE:
            //_logger.LogInformation("Message ID: {id}", message.MessageId);
            //_logger.LogInformation("Message Body: {body}", message.Body);
            //_logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // // Complete the message
            //await messageActions.CompleteMessageAsync(message);

            // ToDo: Convert message to Json object and validate

            // ToDo: Log received message

            // ToDo: Assert request is allowed (no upper level tenant requests allowed

            // ToDo: Create client for retrieving Entra ID user

            // ToDo: Retrieve Entra ID user (UPN provided by message)

            // ToDo: Create client for creating Entra ID app registration (requires service principal and secret!)

            // ToDo: Create unique Entra ID app registration name

            // ToDo: Create Entra ID app registration (with secret)

            // ToDo: Assign Microsoft Graph API application role 'User.Read' to Entra ID app registration (with admin consent)

            // ToDo: Create Entra ID service principal (enterprise application - using tag)

            // ToDo: Update Entra ID service principal by assigning user with role 'Default Access'

            // ToDo: Create client for adding a secret to key vault

            // ToDo: Register Entra ID app registration secret in key vault and assign RBAC role 'Key Vault Secrets User' to the user

            // ToDo: Create message for ITSM (service bus queue) [in v2: email - external function]

            // ToDo: In case of exception perform any required cleanup action (e.g. remove app registration, key vault secret, etc.)
        }
    }
}
