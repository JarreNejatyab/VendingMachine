using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Stock.Commands;
using VendingMachine.Stock.Queries;
using Ximo.Cqrs;
using Ximo.Cqrs.Decorators;
using Ximo.DependencyInjection;

namespace VendingMachine.Stock
{
    public static class ConfigureServices
    {
        public static void RegisterStockServices(this IServiceCollection services)
        {
            services.AddTransient<IVendingDataAccessLayer, VendingDataAccessLayer>();

            services.AddSingleton<IVendingStockContext, VendingStockContext>();

            //commands
            services.RegisterCommandHandler<AddStock, AddStockHandler>();
            services.Decorate<ICommandHandler<AddStock>, LoggingCommandDecorator<AddStock>>();

            services.RegisterCommandHandler<DeleteStock, DeleteStockHandler>();
            services.Decorate<ICommandHandler<DeleteStock>, LoggingCommandDecorator<DeleteStock>>();

            services.RegisterCommandHandler<EjectCan, EjectCanHandler>();
            services.Decorate<ICommandHandler<EjectCan>, LoggingCommandDecorator<EjectCan>>();

            //queries
            services.RegisterQueryHandler<GetAllStock, GetAllStockResponse, GetAllStockHandler>();
            services
                .Decorate
                <IQueryHandler<GetAllStock, GetAllStockResponse>,
                    LoggingQueryDecorator<GetAllStock, GetAllStockResponse>>();

            services.RegisterQueryHandler<GetPriceByFlavour, GetPriceByFlavourResponse, GetPriceByFlavourHandler>();
            services
                .Decorate
                <IQueryHandler<GetPriceByFlavour, GetPriceByFlavourResponse>,
                    LoggingQueryDecorator<GetPriceByFlavour, GetPriceByFlavourResponse>>();
        }
    }
}
