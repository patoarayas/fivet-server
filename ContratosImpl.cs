using System.Threading.Tasks;
using Fivet.ZeroIce.model;
using Ice;
using IceInternal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Fivet.Dao;

namespace Fivet.ZeroIce
{
    /// <summary>
    /// Implementación Contratos de Fivet
    /// </summary>
    public class ContratosImpl : ContratosDisp_
    {
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// DB Context Provider 
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger dI</param>
        /// <param name="serviceScopeFactory">Scope DI</param>
        public ContratosImpl(ILogger<ContratosImpl> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _logger.LogDebug("Building ContratosImpl");
            _serviceScopeFactory = serviceScopeFactory;

            _logger.LogInformation("Creating DB");
            // Create DB
            using( var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                fc.Database.EnsureCreated();
                fc.SaveChanges();

            }
            _logger.LogDebug("Done");

        }
        public override Control crearControl(int numeroFicha, Control control, Current current = null)
        {
            throw new System.NotImplementedException();
        }

        public override Ficha crearFicha(Ficha ficha, Current current = null)
        {
            throw new System.NotImplementedException();
        }

        public override Persona crearPersona(Persona persona, Current current = null)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Task<OutputStream> iceDispatch(Incoming inS, Current current)
        {
            return base.iceDispatch(inS, current);
        }

        public override Task<OutputStream> ice_dispatch(Request request)
        {
            return base.ice_dispatch(request);
        }

        public override string ice_id(Current current = null)
        {
            return base.ice_id(current);
        }

        public override string[] ice_ids(Current current = null)
        {
            return base.ice_ids(current);
        }

        public override bool ice_isA(string s, Current current = null)
        {
            return base.ice_isA(s, current);
        }

        public override void ice_ping(Current current = null)
        {
            base.ice_ping(current);
        }

        public override Ficha obtenerFicha(int numeroFicha, Current current = null)
        {
            throw new System.NotImplementedException();
        }

        public override Persona obtenerPersonaPorRut(string rut, Current current = null)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}