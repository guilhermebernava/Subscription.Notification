using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

namespace Subscription.Functions.Scheduled;

public class ScheduledFunction
{
    public ScheduledFunction()
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