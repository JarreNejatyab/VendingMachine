using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Payment.Commands;
using VendingMachine.Payment.Queries;
using Ximo.Cqrs;
using Ximo.Cqrs.Decorators;
using Ximo.DependencyInjection;

namespace VendingMachine.Payment
{
    public static class ConfigureServices
    {
        public static void RegisterPaymentServices(this IServiceCollection services)
        {
            services.AddSingleton<IPaymentAccessLayer, PaymentAccessLayer>();

            //commands
            services.RegisterCommandHandler<CreditCardPayment, CreditCardPaymentHandler>();
            services.Decorate<ICommandHandler<CreditCardPayment>, LoggingCommandDecorator<CreditCardPayment>>();

            services.RegisterCommandHandler<CashPayment, CashPaymentHandler>();
            services.Decorate<ICommandHandler<CashPayment>, LoggingCommandDecorator<CashPayment>>();

            services.RegisterCommandHandler<ResetBalance, ResetBalanceHandler>();
            services.Decorate<ICommandHandler<ResetBalance>, LoggingCommandDecorator<ResetBalance>>();

            //queries
            services.RegisterQueryHandler<GetBalance, GetBalanceResponse, GetBalanceHandler>();
            services
                .Decorate
                <IQueryHandler<GetBalance, GetBalanceResponse>,
                    LoggingQueryDecorator<GetBalance, GetBalanceResponse>>();
        }
    }
}
