using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System.Reflection;

namespace TestingApi.NHibernate.Helpers
{
    // Thread-safe singleton without using locks
    internal class NHibernateHelper
    {
        private ISessionFactory _factory;
        private static readonly NHibernateHelper _instance = new NHibernateHelper();

        public static NHibernateHelper Instance => _instance;

        static NHibernateHelper()
        { }

        private NHibernateHelper()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();

            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);

            _factory = cfg.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return _factory.OpenSession();
        }
    }
}
