using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

using Workers.WrkNFe.Models;
using Workers.WrkNFe.Context;

namespace Workers.EDI
{
    internal class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger _logger;
        
        public ScopedProcessingService(ILogger<ScopedProcessingService> logger)
        {
            _logger = logger;        
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {               
            var host = Environment.GetEnvironmentVariable("QUEUEHOST");
            Console.WriteLine("Host do RabbitMQ" + host);
            ConnectionFactory factory = new ConnectionFactory() { HostName = host, Port = 5672, UserName="guest", Password = "guest" };        
            
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            
            while (!stoppingToken.IsCancellationRequested)
            
            {
                executionCount++;
                _logger.LogInformation("Service is working. Count: {Count}", executionCount);
        
                channel.QueueDeclare(queue: "NFeQueue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);        

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    
                    var body = ea.Body;                                
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    
                    Console.WriteLine("Received {0}", message);                                
                    var nfe = JsonSerializer.Deserialize<NFe>(message);
                                
                    using(var db = new NFeContext()){
                        //db.Database.EnsureCreated();
                        //db.NFes.Attach(nfe);
                        //db.Entry(nfe).State = EntityState.Modified;                                              
                        
                        var entity = db.NFes.FirstOrDefault(item => item.DocumentId == nfe.DocumentId);
                        if (entity != null)
                        {                        
                            entity.Status = nfe.Status;
                            entity.EntidadeId = nfe.EntidadeId;
                            entity.Ambiente = nfe.Ambiente;
                            entity.Modalidade = nfe.Modalidade;
                            entity.DataRecepcao = nfe.DataRecepcao;
                            entity.StatusDistribuicao = nfe.StatusDistribuicao;
                            entity.CorrelationId = nfe.CorrelationId;
                            entity.Xml = nfe.Xml;
                        }else{                      
                            db.NFes.Add(nfe);
                        }                    
                        db.SaveChanges();
                }               
                };
                channel.BasicConsume(queue: "NFeQueue",
                                    autoAck: true,
                                    consumer: consumer);
            
                await Task.Delay(3000, stoppingToken);
            
            }
        }
    }
}