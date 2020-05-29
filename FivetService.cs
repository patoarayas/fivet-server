using System.Threading;
using System.Threading.Tasks;
using Ice;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Fivet.ZeroIce;
using Fivet.ZeroIce.model;
namespace Fivet.Server
{
    internal class FivetService : IHostedService
    {
        /// <summary>
        ///  Logger
        /// </summary>
        private readonly ILogger<FivetService> _logger;

        /// <summary>
        /// Port
        /// </summary>
        private readonly int _port = 8080;

        /// <summary>
        /// Communicator
        /// </summary>
        private readonly Communicator _communicator;

        /// <summary>
        /// Sistema
        /// </summary>
        private readonly SistemaDisp_ _sistema;

        /// <summary>
        /// Contratos
        /// </summary>
        private readonly ContratosDisp_ _contratos;

        /// <summary>
        /// Fivet Service Constructor
        /// </summary>
        /// <param name="logger">Logger DI</param> 
        public FivetService(ILogger<FivetService> logger, SistemaDisp_ sistema, ContratosDisp_ contratos)
        {
            _logger = logger;
            _logger.LogDebug("Building Fivet Service");
            _contratos = contratos;
            _sistema = sistema;
            _communicator = buildCommunicator();

        }

        /// <summary>
        /// Start Async.false Triggered when the app start the service.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Starting Fivet Service");
            // Adapter
            var adapter = _communicator.createObjectAdapterWithEndpoints("Sistema","tcp -z -t 15000 -p "+ _port);

            // Register the communicator and activate
            adapter.add(_sistema,Util.stringToIdentity("Sistema"));
            adapter.add(_contratos,Util.stringToIdentity("Contratos"));
            adapter.activate();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the host shutdown the app.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping Fivet Service");
            _communicator.shutdown();
            _logger.LogInformation("Communicator stopped");
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// Communicator builder
        /// </summary>
        /// <returns>Communicator</returns>
        private Communicator buildCommunicator()
        {
            _logger.LogDebug("Initializing Communicator v{0} ({1})",Ice.Util.stringVersion(),Ice.Util.intVersion());

            // ZeroC properties
            Properties properties = Util.createProperties();
            InitializationData initializationData = new InitializationData();
            initializationData.properties = properties;

            return Ice.Util.initialize(initializationData);
        }
    }


}