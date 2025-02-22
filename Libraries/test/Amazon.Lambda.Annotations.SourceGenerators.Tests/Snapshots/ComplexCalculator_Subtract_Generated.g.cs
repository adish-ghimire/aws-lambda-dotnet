// <auto-generated/>

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Amazon.Lambda.Core;

namespace TestServerlessApp
{
    public class ComplexCalculator_Subtract_Generated
    {
        private readonly ComplexCalculator complexCalculator;
        private readonly Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer serializer;

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public ComplexCalculator_Subtract_Generated()
        {
            SetExecutionEnvironment();
            complexCalculator = new ComplexCalculator();
            serializer = new Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer();
        }

        /// <summary>
        /// The generated Lambda function handler for <see cref="Subtract(System.Collections.Generic.IList<System.Collections.Generic.IList<int>>)"/>
        /// </summary>
        /// <param name="__request__">The API Gateway request object that will be processed by the Lambda function handler.</param>
        /// <param name="__context__">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
        /// <returns>Result of the Lambda function execution</returns>
        public Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse Subtract(Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest __request__, Amazon.Lambda.Core.ILambdaContext __context__)
        {
            var validationErrors = new List<string>();

            var complexNumbers = default(System.Collections.Generic.IList<System.Collections.Generic.IList<int>>);
            try
            {
                // convert string to stream
                var byteArray = Encoding.ASCII.GetBytes(__request__.Body);
                var stream = new MemoryStream(byteArray);
                complexNumbers = serializer.Deserialize<System.Collections.Generic.IList<System.Collections.Generic.IList<int>>>(stream);
            }
            catch (Exception e)
            {
                validationErrors.Add($"Value {__request__.Body} at 'body' failed to satisfy constraint: {e.Message}");
            }

            // return 400 Bad Request if there exists a validation error
            if (validationErrors.Any())
            {
                var errorResult = new Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse
                {
                    Body = @$"{{""message"": ""{validationErrors.Count} validation error(s) detected: {string.Join(",", validationErrors)}""}}",
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json"},
                        {"x-amzn-ErrorType", "ValidationException"}
                    },
                    StatusCode = 400
                };
                return errorResult;
            }

            var response = complexCalculator.Subtract(complexNumbers);
            var memoryStream = new MemoryStream();
            serializer.Serialize(response, memoryStream);
            memoryStream.Position = 0;

            // convert stream to string
            StreamReader reader = new StreamReader( memoryStream );
            var body = reader.ReadToEnd();

            return new Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse
            {
                Body = body,
                Headers = new Dictionary<string, string>
                {
                    {"Content-Type", "application/json"}
                },
                StatusCode = 200
            };
        }

        private static void SetExecutionEnvironment()
        {
            const string envName = "AWS_EXECUTION_ENV";

            var envValue = new StringBuilder();

            // If there is an existing execution environment variable add the annotations package as a suffix.
            if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(envName)))
            {
                envValue.Append($"{Environment.GetEnvironmentVariable(envName)}_");
            }

            envValue.Append("lib/amazon-lambda-annotations#1.5.0.0");

            Environment.SetEnvironmentVariable(envName, envValue.ToString());
        }
    }
}