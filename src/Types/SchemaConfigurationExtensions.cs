using System;
using System.Threading.Tasks;
using HotChocolate.Configuration;
using HotChocolate.Resolvers;

namespace HotChocolate
{
    public static class SchemaConfigurationExtensions
    {
        public static IBindResolverDelegate BindResolver(
            this ISchemaConfiguration schemaConfiguration,
            Func<IResolverContext, object> resolver)
        {
            return schemaConfiguration.BindResolver((ctx, ct) => resolver(ctx));
        }

        public static IBindResolverDelegate BindResolver(
            this ISchemaConfiguration schemaConfiguration,
            Func<object> resolver)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            return schemaConfiguration.BindResolver((ctx, ct) => resolver());
        }

        public static IBindResolverDelegate BindResolver(
            this ISchemaConfiguration schemaConfiguration,
            Func<IResolverContext, Task<object>> resolver)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            return schemaConfiguration.BindResolver((ctx, ct) => resolver(ctx));
        }

        public static IBindResolverDelegate BindResolver(
            this ISchemaConfiguration schemaConfiguration,
            Func<Task<object>> resolver)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }

            return schemaConfiguration.BindResolver((ctx, ct) => resolver());
        }

        public static IBindType<T> BindType<T>(
            this ISchemaFirstConfiguration configuration)
            where T : class
        {
            return configuration.BindType<T>(BindingBehavior.Implicit);
        }

        public static IBindResolver<TResolver> BindResolver<TResolver>(
            this ISchemaFirstConfiguration configuration)
            where TResolver : class
        {
            return configuration.BindResolver<TResolver>(BindingBehavior.Implicit);
        }
    }
}
