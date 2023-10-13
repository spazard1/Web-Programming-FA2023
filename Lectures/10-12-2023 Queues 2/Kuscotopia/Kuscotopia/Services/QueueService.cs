using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Common;
using Common.Entities;
using Newtonsoft.Json;

namespace Kuscotopia.Services
{
    public class QueueService
    {
        private static BasicAWSCredentials credentials;
        private static AmazonSQSClient sqsClient;

        public QueueService()
        {
            credentials = new BasicAWSCredentials(Credentials.QueueKeyId, Credentials.QueueKey);
            sqsClient = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);
        }

        public async Task QueueWorkAsync(WorkEntity workEntity)
        {
            var sendMessageRequest = new SendMessageRequest()
            {
                QueueUrl = Credentials.QueueUrl,
                MessageBody = JsonConvert.SerializeObject(workEntity)
            };

            await sqsClient.SendMessageAsync(sendMessageRequest);
        }
    }
}
