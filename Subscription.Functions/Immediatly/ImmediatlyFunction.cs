using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;


[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Subscription.Functions.Immediatly;

public class ImmediatlyFunction
{
    public ImmediatlyFunction()
    {

    }


    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        foreach (var message in evnt.Records)
        {
            await ProcessMessageAsync(message, context);
        }
    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed message {message.Body}");
        await Task.CompletedTask;
    }
}