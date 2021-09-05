using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.IO;
using Utility.Json;
using Utility.Wpf;
using Utility.Wpf.Entries;
using Microsoft.Extensions.DependencyInjection;
using Abp.ObjectMapping;
using Shop.Wpf.ViewModel;
using Shop.Application.Services.Dtos;
using Shop.Application.Services;
using Utility.Wpf.Demo.ViewModels;

namespace Shop.Wpf
{
    public class ShopConfigManager
    {
        public static IObjectMapper objectMapper;
        public static void BindShopConfig()        {
                BindAuditInRoleConfig();
                BindBuyerFullReductionConfig();
                BindBuyerIntegralConfig();
                BindBuyerPrizeLogConfig();
                BindEmailConfig();
                BindEmailNotifyProductConfig();
                BindOrderDetailConfig();
                BindOrderConfig();
                BindOrderLogConfig();
                BindOrderPayConfig();
                BindProductMsgConfig();
                BindSellerCouponConfig();
                BindSellerCouponSettsingConfig();
                BindSellerIntegralSettingConfig();
                BindSellerPrizeConfig();
                BindSellerPrizeSettingConfig();
                BindSmsConfig();
                BindClassConfig();
                BindMenuConfig();
                BindStudentConfig();
        
}
        private static void BindAuditInRoleConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.AuditInRole"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    AuditInRoleViewModel AuditInRoleView = (AuditInRoleViewModel)it;
                    CreateAuditInRoleInput createAuditInRole= objectMapper.Map<CreateAuditInRoleInput>(AuditInRoleView);
                    AuditInRoleAppService AuditInRoleApp = StartManager.serviceProvider.GetService<AuditInRoleAppService>();
                    AuditInRoleApp.Insert(createAuditInRole);
                    return  1;
                },
                Modify = (it) =>
                {
                   AuditInRoleViewModel AuditInRoleView = (AuditInRoleViewModel)it;
                    UpdateAuditInRoleInput createAuditInRole = objectMapper.Map<UpdateAuditInRoleInput>(AuditInRoleView);
                    AuditInRoleAppService AuditInRoleApp = StartManager.serviceProvider.GetService<AuditInRoleAppService>();
                    AuditInRoleApp.Update(createAuditInRole);
                },
                Delete = (it) =>
                {
                    AuditInRoleViewModel AuditInRoleView = (AuditInRoleViewModel)it;
                    AuditInRoleAppService AuditInRoleApp = StartManager.serviceProvider.GetService<AuditInRoleAppService>();
                    AuditInRoleApp.Delete(AuditInRoleView.Id);
                },
                DeleteList = (it) =>
                {
                    AuditInRoleViewModel[] AuditInRoleViews = (AuditInRoleViewModel[])it;
                    List<long> ids = AuditInRoleViews.Select(it1 => it1.Id).ToList();
                    AuditInRoleAppService AuditInRoleApp = StartManager.serviceProvider.GetService<AuditInRoleAppService>();
                    AuditInRoleApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    AuditInRoleAppService AuditInRoleApp = StartManager.serviceProvider.GetService<AuditInRoleAppService>();
                    var data= AuditInRoleApp.Find( page, size);
                    var result= objectMapper.Map<List<AuditInRoleViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    AuditInRoleAppService AuditInRoleApp = StartManager.serviceProvider.GetService<AuditInRoleAppService>();
                    if (it == null)
                    {
                        AuditInRoleViewModel AuditInRoleView = (AuditInRoleViewModel)it;
                        QueryAuditInRoleInput queryAuditInRole = objectMapper.Map<QueryAuditInRoleInput>(AuditInRoleView);
                        var data= AuditInRoleApp.Find(queryAuditInRole,  page, size);
                        var result= objectMapper.Map<List<AuditInRoleViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= AuditInRoleApp.Find(new QueryAuditInRoleInput(), page, size);
                        var result= objectMapper.Map<List<AuditInRoleViewModel>>(data);
                        return result;
                   }
                },
            };        
}
      private static void BindBuyerFullReductionConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.BuyerFullReduction"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    BuyerFullReductionViewModel BuyerFullReductionView = (BuyerFullReductionViewModel)it;
                    CreateBuyerFullReductionInput createBuyerFullReduction= objectMapper.Map<CreateBuyerFullReductionInput>(BuyerFullReductionView);
                    BuyerFullReductionAppService BuyerFullReductionApp = StartManager.serviceProvider.GetService<BuyerFullReductionAppService>();
                    BuyerFullReductionApp.Insert(createBuyerFullReduction);
                    return  1;
                },
                Modify = (it) =>
                {
                   BuyerFullReductionViewModel BuyerFullReductionView = (BuyerFullReductionViewModel)it;
                    UpdateBuyerFullReductionInput createBuyerFullReduction = objectMapper.Map<UpdateBuyerFullReductionInput>(BuyerFullReductionView);
                    BuyerFullReductionAppService BuyerFullReductionApp = StartManager.serviceProvider.GetService<BuyerFullReductionAppService>();
                    BuyerFullReductionApp.Update(createBuyerFullReduction);
                },
                Delete = (it) =>
                {
                    BuyerFullReductionViewModel BuyerFullReductionView = (BuyerFullReductionViewModel)it;
                    BuyerFullReductionAppService BuyerFullReductionApp = StartManager.serviceProvider.GetService<BuyerFullReductionAppService>();
                    BuyerFullReductionApp.Delete(BuyerFullReductionView.Id);
                },
                DeleteList = (it) =>
                {
                    BuyerFullReductionViewModel[] BuyerFullReductionViews = (BuyerFullReductionViewModel[])it;
                    List<long> ids = BuyerFullReductionViews.Select(it1 => it1.Id).ToList();
                    BuyerFullReductionAppService BuyerFullReductionApp = StartManager.serviceProvider.GetService<BuyerFullReductionAppService>();
                    BuyerFullReductionApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    BuyerFullReductionAppService BuyerFullReductionApp = StartManager.serviceProvider.GetService<BuyerFullReductionAppService>();
                    var data= BuyerFullReductionApp.Find( page, size);
                    var result= objectMapper.Map<List<BuyerFullReductionViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    BuyerFullReductionAppService BuyerFullReductionApp = StartManager.serviceProvider.GetService<BuyerFullReductionAppService>();
                    if (it == null)
                    {
                        BuyerFullReductionViewModel BuyerFullReductionView = (BuyerFullReductionViewModel)it;
                        QueryBuyerFullReductionInput queryBuyerFullReduction = objectMapper.Map<QueryBuyerFullReductionInput>(BuyerFullReductionView);
                        var data= BuyerFullReductionApp.Find(queryBuyerFullReduction,  page, size);
                        var result= objectMapper.Map<List<BuyerFullReductionViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= BuyerFullReductionApp.Find(new QueryBuyerFullReductionInput(), page, size);
                        var result= objectMapper.Map<List<BuyerFullReductionViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindBuyerIntegralConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.BuyerIntegral"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    BuyerIntegralViewModel BuyerIntegralView = (BuyerIntegralViewModel)it;
                    CreateBuyerIntegralInput createBuyerIntegral= objectMapper.Map<CreateBuyerIntegralInput>(BuyerIntegralView);
                    BuyerIntegralAppService BuyerIntegralApp = StartManager.serviceProvider.GetService<BuyerIntegralAppService>();
                    BuyerIntegralApp.Insert(createBuyerIntegral);
                    return  1;
                },
                Modify = (it) =>
                {
                   BuyerIntegralViewModel BuyerIntegralView = (BuyerIntegralViewModel)it;
                    UpdateBuyerIntegralInput createBuyerIntegral = objectMapper.Map<UpdateBuyerIntegralInput>(BuyerIntegralView);
                    BuyerIntegralAppService BuyerIntegralApp = StartManager.serviceProvider.GetService<BuyerIntegralAppService>();
                    BuyerIntegralApp.Update(createBuyerIntegral);
                },
                Delete = (it) =>
                {
                    BuyerIntegralViewModel BuyerIntegralView = (BuyerIntegralViewModel)it;
                    BuyerIntegralAppService BuyerIntegralApp = StartManager.serviceProvider.GetService<BuyerIntegralAppService>();
                    BuyerIntegralApp.Delete(BuyerIntegralView.Id);
                },
                DeleteList = (it) =>
                {
                    BuyerIntegralViewModel[] BuyerIntegralViews = (BuyerIntegralViewModel[])it;
                    List<long> ids = BuyerIntegralViews.Select(it1 => it1.Id).ToList();
                    BuyerIntegralAppService BuyerIntegralApp = StartManager.serviceProvider.GetService<BuyerIntegralAppService>();
                    BuyerIntegralApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    BuyerIntegralAppService BuyerIntegralApp = StartManager.serviceProvider.GetService<BuyerIntegralAppService>();
                    var data= BuyerIntegralApp.Find( page, size);
                    var result= objectMapper.Map<List<BuyerIntegralViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    BuyerIntegralAppService BuyerIntegralApp = StartManager.serviceProvider.GetService<BuyerIntegralAppService>();
                    if (it == null)
                    {
                        BuyerIntegralViewModel BuyerIntegralView = (BuyerIntegralViewModel)it;
                        QueryBuyerIntegralInput queryBuyerIntegral = objectMapper.Map<QueryBuyerIntegralInput>(BuyerIntegralView);
                        var data= BuyerIntegralApp.Find(queryBuyerIntegral,  page, size);
                        var result= objectMapper.Map<List<BuyerIntegralViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= BuyerIntegralApp.Find(new QueryBuyerIntegralInput(), page, size);
                        var result= objectMapper.Map<List<BuyerIntegralViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindBuyerPrizeLogConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.BuyerPrizeLog"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    BuyerPrizeLogViewModel BuyerPrizeLogView = (BuyerPrizeLogViewModel)it;
                    CreateBuyerPrizeLogInput createBuyerPrizeLog= objectMapper.Map<CreateBuyerPrizeLogInput>(BuyerPrizeLogView);
                    BuyerPrizeLogAppService BuyerPrizeLogApp = StartManager.serviceProvider.GetService<BuyerPrizeLogAppService>();
                    BuyerPrizeLogApp.Insert(createBuyerPrizeLog);
                    return  1;
                },
                Modify = (it) =>
                {
                   BuyerPrizeLogViewModel BuyerPrizeLogView = (BuyerPrizeLogViewModel)it;
                    UpdateBuyerPrizeLogInput createBuyerPrizeLog = objectMapper.Map<UpdateBuyerPrizeLogInput>(BuyerPrizeLogView);
                    BuyerPrizeLogAppService BuyerPrizeLogApp = StartManager.serviceProvider.GetService<BuyerPrizeLogAppService>();
                    BuyerPrizeLogApp.Update(createBuyerPrizeLog);
                },
                Delete = (it) =>
                {
                    BuyerPrizeLogViewModel BuyerPrizeLogView = (BuyerPrizeLogViewModel)it;
                    BuyerPrizeLogAppService BuyerPrizeLogApp = StartManager.serviceProvider.GetService<BuyerPrizeLogAppService>();
                    BuyerPrizeLogApp.Delete(BuyerPrizeLogView.Id);
                },
                DeleteList = (it) =>
                {
                    BuyerPrizeLogViewModel[] BuyerPrizeLogViews = (BuyerPrizeLogViewModel[])it;
                    List<long> ids = BuyerPrizeLogViews.Select(it1 => it1.Id).ToList();
                    BuyerPrizeLogAppService BuyerPrizeLogApp = StartManager.serviceProvider.GetService<BuyerPrizeLogAppService>();
                    BuyerPrizeLogApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    BuyerPrizeLogAppService BuyerPrizeLogApp = StartManager.serviceProvider.GetService<BuyerPrizeLogAppService>();
                    var data= BuyerPrizeLogApp.Find( page, size);
                    var result= objectMapper.Map<List<BuyerPrizeLogViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    BuyerPrizeLogAppService BuyerPrizeLogApp = StartManager.serviceProvider.GetService<BuyerPrizeLogAppService>();
                    if (it == null)
                    {
                        BuyerPrizeLogViewModel BuyerPrizeLogView = (BuyerPrizeLogViewModel)it;
                        QueryBuyerPrizeLogInput queryBuyerPrizeLog = objectMapper.Map<QueryBuyerPrizeLogInput>(BuyerPrizeLogView);
                        var data= BuyerPrizeLogApp.Find(queryBuyerPrizeLog,  page, size);
                        var result= objectMapper.Map<List<BuyerPrizeLogViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= BuyerPrizeLogApp.Find(new QueryBuyerPrizeLogInput(), page, size);
                        var result= objectMapper.Map<List<BuyerPrizeLogViewModel>>(data);
                        return result;
                   }
                },
            };        
}
      private static void BindEmailConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.Email"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    EmailViewModel EmailView = (EmailViewModel)it;
                    CreateEmailInput createEmail= objectMapper.Map<CreateEmailInput>(EmailView);
                    EmailAppService EmailApp = StartManager.serviceProvider.GetService<EmailAppService>();
                    EmailApp.Insert(createEmail);
                    return  1;
                },
                Modify = (it) =>
                {
                   EmailViewModel EmailView = (EmailViewModel)it;
                    UpdateEmailInput createEmail = objectMapper.Map<UpdateEmailInput>(EmailView);
                    EmailAppService EmailApp = StartManager.serviceProvider.GetService<EmailAppService>();
                    EmailApp.Update(createEmail);
                },
                Delete = (it) =>
                {
                    EmailViewModel EmailView = (EmailViewModel)it;
                    EmailAppService EmailApp = StartManager.serviceProvider.GetService<EmailAppService>();
                    EmailApp.Delete(EmailView.Id);
                },
                DeleteList = (it) =>
                {
                    EmailViewModel[] EmailViews = (EmailViewModel[])it;
                    List<long> ids = EmailViews.Select(it1 => it1.Id).ToList();
                    EmailAppService EmailApp = StartManager.serviceProvider.GetService<EmailAppService>();
                    EmailApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    EmailAppService EmailApp = StartManager.serviceProvider.GetService<EmailAppService>();
                    var data= EmailApp.Find( page, size);
                    var result= objectMapper.Map<List<EmailViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    EmailAppService EmailApp = StartManager.serviceProvider.GetService<EmailAppService>();
                    if (it == null)
                    {
                        EmailViewModel EmailView = (EmailViewModel)it;
                        QueryEmailInput queryEmail = objectMapper.Map<QueryEmailInput>(EmailView);
                        var data= EmailApp.Find(queryEmail,  page, size);
                        var result= objectMapper.Map<List<EmailViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= EmailApp.Find(new QueryEmailInput(), page, size);
                        var result= objectMapper.Map<List<EmailViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindEmailNotifyProductConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.EmailNotifyProduct"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    EmailNotifyProductViewModel EmailNotifyProductView = (EmailNotifyProductViewModel)it;
                    CreateEmailNotifyProductInput createEmailNotifyProduct= objectMapper.Map<CreateEmailNotifyProductInput>(EmailNotifyProductView);
                    EmailNotifyProductAppService EmailNotifyProductApp = StartManager.serviceProvider.GetService<EmailNotifyProductAppService>();
                    EmailNotifyProductApp.Insert(createEmailNotifyProduct);
                    return  1;
                },
                Modify = (it) =>
                {
                   EmailNotifyProductViewModel EmailNotifyProductView = (EmailNotifyProductViewModel)it;
                    UpdateEmailNotifyProductInput createEmailNotifyProduct = objectMapper.Map<UpdateEmailNotifyProductInput>(EmailNotifyProductView);
                    EmailNotifyProductAppService EmailNotifyProductApp = StartManager.serviceProvider.GetService<EmailNotifyProductAppService>();
                    EmailNotifyProductApp.Update(createEmailNotifyProduct);
                },
                Delete = (it) =>
                {
                    EmailNotifyProductViewModel EmailNotifyProductView = (EmailNotifyProductViewModel)it;
                    EmailNotifyProductAppService EmailNotifyProductApp = StartManager.serviceProvider.GetService<EmailNotifyProductAppService>();
                    EmailNotifyProductApp.Delete(EmailNotifyProductView.Id);
                },
                DeleteList = (it) =>
                {
                    EmailNotifyProductViewModel[] EmailNotifyProductViews = (EmailNotifyProductViewModel[])it;
                    List<long> ids = EmailNotifyProductViews.Select(it1 => it1.Id).ToList();
                    EmailNotifyProductAppService EmailNotifyProductApp = StartManager.serviceProvider.GetService<EmailNotifyProductAppService>();
                    EmailNotifyProductApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    EmailNotifyProductAppService EmailNotifyProductApp = StartManager.serviceProvider.GetService<EmailNotifyProductAppService>();
                    var data= EmailNotifyProductApp.Find( page, size);
                    var result= objectMapper.Map<List<EmailNotifyProductViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    EmailNotifyProductAppService EmailNotifyProductApp = StartManager.serviceProvider.GetService<EmailNotifyProductAppService>();
                    if (it == null)
                    {
                        EmailNotifyProductViewModel EmailNotifyProductView = (EmailNotifyProductViewModel)it;
                        QueryEmailNotifyProductInput queryEmailNotifyProduct = objectMapper.Map<QueryEmailNotifyProductInput>(EmailNotifyProductView);
                        var data= EmailNotifyProductApp.Find(queryEmailNotifyProduct,  page, size);
                        var result= objectMapper.Map<List<EmailNotifyProductViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= EmailNotifyProductApp.Find(new QueryEmailNotifyProductInput(), page, size);
                        var result= objectMapper.Map<List<EmailNotifyProductViewModel>>(data);
                        return result;
                   }
                },
            };        
}
       private static void BindOrderDetailConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.OrderDetail"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    OrderDetailViewModel OrderDetailView = (OrderDetailViewModel)it;
                    CreateOrderDetailInput createOrderDetail= objectMapper.Map<CreateOrderDetailInput>(OrderDetailView);
                    OrderDetailAppService OrderDetailApp = StartManager.serviceProvider.GetService<OrderDetailAppService>();
                    OrderDetailApp.Insert(createOrderDetail);
                    return  1;
                },
                Modify = (it) =>
                {
                   OrderDetailViewModel OrderDetailView = (OrderDetailViewModel)it;
                    UpdateOrderDetailInput createOrderDetail = objectMapper.Map<UpdateOrderDetailInput>(OrderDetailView);
                    OrderDetailAppService OrderDetailApp = StartManager.serviceProvider.GetService<OrderDetailAppService>();
                    OrderDetailApp.Update(createOrderDetail);
                },
                Delete = (it) =>
                {
                    OrderDetailViewModel OrderDetailView = (OrderDetailViewModel)it;
                    OrderDetailAppService OrderDetailApp = StartManager.serviceProvider.GetService<OrderDetailAppService>();
                    OrderDetailApp.Delete(OrderDetailView.Id);
                },
                DeleteList = (it) =>
                {
                    OrderDetailViewModel[] OrderDetailViews = (OrderDetailViewModel[])it;
                    List<long> ids = OrderDetailViews.Select(it1 => it1.Id).ToList();
                    OrderDetailAppService OrderDetailApp = StartManager.serviceProvider.GetService<OrderDetailAppService>();
                    OrderDetailApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    OrderDetailAppService OrderDetailApp = StartManager.serviceProvider.GetService<OrderDetailAppService>();
                    var data= OrderDetailApp.Find( page, size);
                    var result= objectMapper.Map<List<OrderDetailViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    OrderDetailAppService OrderDetailApp = StartManager.serviceProvider.GetService<OrderDetailAppService>();
                    if (it == null)
                    {
                        OrderDetailViewModel OrderDetailView = (OrderDetailViewModel)it;
                        QueryOrderDetailInput queryOrderDetail = objectMapper.Map<QueryOrderDetailInput>(OrderDetailView);
                        var data= OrderDetailApp.Find(queryOrderDetail,  page, size);
                        var result= objectMapper.Map<List<OrderDetailViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= OrderDetailApp.Find(new QueryOrderDetailInput(), page, size);
                        var result= objectMapper.Map<List<OrderDetailViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindOrderConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.Order"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    OrderViewModel OrderView = (OrderViewModel)it;
                    CreateOrderInput createOrder= objectMapper.Map<CreateOrderInput>(OrderView);
                    OrderAppService OrderApp = StartManager.serviceProvider.GetService<OrderAppService>();
                    OrderApp.Insert(createOrder);
                    return  1;
                },
                Modify = (it) =>
                {
                   OrderViewModel OrderView = (OrderViewModel)it;
                    UpdateOrderInput createOrder = objectMapper.Map<UpdateOrderInput>(OrderView);
                    OrderAppService OrderApp = StartManager.serviceProvider.GetService<OrderAppService>();
                    OrderApp.Update(createOrder);
                },
                Delete = (it) =>
                {
                    OrderViewModel OrderView = (OrderViewModel)it;
                    OrderAppService OrderApp = StartManager.serviceProvider.GetService<OrderAppService>();
                    OrderApp.Delete(OrderView.Id);
                },
                DeleteList = (it) =>
                {
                    OrderViewModel[] OrderViews = (OrderViewModel[])it;
                    List<long> ids = OrderViews.Select(it1 => it1.Id).ToList();
                    OrderAppService OrderApp = StartManager.serviceProvider.GetService<OrderAppService>();
                    OrderApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    OrderAppService OrderApp = StartManager.serviceProvider.GetService<OrderAppService>();
                    var data= OrderApp.Find( page, size);
                    var result= objectMapper.Map<List<OrderViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    OrderAppService OrderApp = StartManager.serviceProvider.GetService<OrderAppService>();
                    if (it == null)
                    {
                        OrderViewModel OrderView = (OrderViewModel)it;
                        QueryOrderInput queryOrder = objectMapper.Map<QueryOrderInput>(OrderView);
                        var data= OrderApp.Find(queryOrder,  page, size);
                        var result= objectMapper.Map<List<OrderViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= OrderApp.Find(new QueryOrderInput(), page, size);
                        var result= objectMapper.Map<List<OrderViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindOrderLogConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.OrderLog"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    OrderLogViewModel OrderLogView = (OrderLogViewModel)it;
                    CreateOrderLogInput createOrderLog= objectMapper.Map<CreateOrderLogInput>(OrderLogView);
                    OrderLogAppService OrderLogApp = StartManager.serviceProvider.GetService<OrderLogAppService>();
                    OrderLogApp.Insert(createOrderLog);
                    return  1;
                },
                Modify = (it) =>
                {
                   OrderLogViewModel OrderLogView = (OrderLogViewModel)it;
                    UpdateOrderLogInput createOrderLog = objectMapper.Map<UpdateOrderLogInput>(OrderLogView);
                    OrderLogAppService OrderLogApp = StartManager.serviceProvider.GetService<OrderLogAppService>();
                    OrderLogApp.Update(createOrderLog);
                },
                Delete = (it) =>
                {
                    OrderLogViewModel OrderLogView = (OrderLogViewModel)it;
                    OrderLogAppService OrderLogApp = StartManager.serviceProvider.GetService<OrderLogAppService>();
                    OrderLogApp.Delete(OrderLogView.Id);
                },
                DeleteList = (it) =>
                {
                    OrderLogViewModel[] OrderLogViews = (OrderLogViewModel[])it;
                    List<long> ids = OrderLogViews.Select(it1 => it1.Id).ToList();
                    OrderLogAppService OrderLogApp = StartManager.serviceProvider.GetService<OrderLogAppService>();
                    OrderLogApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    OrderLogAppService OrderLogApp = StartManager.serviceProvider.GetService<OrderLogAppService>();
                    var data= OrderLogApp.Find( page, size);
                    var result= objectMapper.Map<List<OrderLogViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    OrderLogAppService OrderLogApp = StartManager.serviceProvider.GetService<OrderLogAppService>();
                    if (it == null)
                    {
                        OrderLogViewModel OrderLogView = (OrderLogViewModel)it;
                        QueryOrderLogInput queryOrderLog = objectMapper.Map<QueryOrderLogInput>(OrderLogView);
                        var data= OrderLogApp.Find(queryOrderLog,  page, size);
                        var result= objectMapper.Map<List<OrderLogViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= OrderLogApp.Find(new QueryOrderLogInput(), page, size);
                        var result= objectMapper.Map<List<OrderLogViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindOrderPayConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.OrderPay"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    OrderPayViewModel OrderPayView = (OrderPayViewModel)it;
                    CreateOrderPayInput createOrderPay= objectMapper.Map<CreateOrderPayInput>(OrderPayView);
                    OrderPayAppService OrderPayApp = StartManager.serviceProvider.GetService<OrderPayAppService>();
                    OrderPayApp.Insert(createOrderPay);
                    return  1;
                },
                Modify = (it) =>
                {
                   OrderPayViewModel OrderPayView = (OrderPayViewModel)it;
                    UpdateOrderPayInput createOrderPay = objectMapper.Map<UpdateOrderPayInput>(OrderPayView);
                    OrderPayAppService OrderPayApp = StartManager.serviceProvider.GetService<OrderPayAppService>();
                    OrderPayApp.Update(createOrderPay);
                },
                Delete = (it) =>
                {
                    OrderPayViewModel OrderPayView = (OrderPayViewModel)it;
                    OrderPayAppService OrderPayApp = StartManager.serviceProvider.GetService<OrderPayAppService>();
                    OrderPayApp.Delete(OrderPayView.Id);
                },
                DeleteList = (it) =>
                {
                    OrderPayViewModel[] OrderPayViews = (OrderPayViewModel[])it;
                    List<long> ids = OrderPayViews.Select(it1 => it1.Id).ToList();
                    OrderPayAppService OrderPayApp = StartManager.serviceProvider.GetService<OrderPayAppService>();
                    OrderPayApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    OrderPayAppService OrderPayApp = StartManager.serviceProvider.GetService<OrderPayAppService>();
                    var data= OrderPayApp.Find( page, size);
                    var result= objectMapper.Map<List<OrderPayViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    OrderPayAppService OrderPayApp = StartManager.serviceProvider.GetService<OrderPayAppService>();
                    if (it == null)
                    {
                        OrderPayViewModel OrderPayView = (OrderPayViewModel)it;
                        QueryOrderPayInput queryOrderPay = objectMapper.Map<QueryOrderPayInput>(OrderPayView);
                        var data= OrderPayApp.Find(queryOrderPay,  page, size);
                        var result= objectMapper.Map<List<OrderPayViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= OrderPayApp.Find(new QueryOrderPayInput(), page, size);
                        var result= objectMapper.Map<List<OrderPayViewModel>>(data);
                        return result;
                   }
                },
            };        
}
     private static void BindProductMsgConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.ProductMsg"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    ProductMsgViewModel ProductMsgView = (ProductMsgViewModel)it;
                    CreateProductMsgInput createProductMsg= objectMapper.Map<CreateProductMsgInput>(ProductMsgView);
                    ProductMsgAppService ProductMsgApp = StartManager.serviceProvider.GetService<ProductMsgAppService>();
                    ProductMsgApp.Insert(createProductMsg);
                    return  1;
                },
                Modify = (it) =>
                {
                   ProductMsgViewModel ProductMsgView = (ProductMsgViewModel)it;
                    UpdateProductMsgInput createProductMsg = objectMapper.Map<UpdateProductMsgInput>(ProductMsgView);
                    ProductMsgAppService ProductMsgApp = StartManager.serviceProvider.GetService<ProductMsgAppService>();
                    ProductMsgApp.Update(createProductMsg);
                },
                Delete = (it) =>
                {
                    ProductMsgViewModel ProductMsgView = (ProductMsgViewModel)it;
                    ProductMsgAppService ProductMsgApp = StartManager.serviceProvider.GetService<ProductMsgAppService>();
                    ProductMsgApp.Delete(ProductMsgView.Id);
                },
                DeleteList = (it) =>
                {
                    ProductMsgViewModel[] ProductMsgViews = (ProductMsgViewModel[])it;
                    List<long> ids = ProductMsgViews.Select(it1 => it1.Id).ToList();
                    ProductMsgAppService ProductMsgApp = StartManager.serviceProvider.GetService<ProductMsgAppService>();
                    ProductMsgApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    ProductMsgAppService ProductMsgApp = StartManager.serviceProvider.GetService<ProductMsgAppService>();
                    var data= ProductMsgApp.Find( page, size);
                    var result= objectMapper.Map<List<ProductMsgViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    ProductMsgAppService ProductMsgApp = StartManager.serviceProvider.GetService<ProductMsgAppService>();
                    if (it == null)
                    {
                        ProductMsgViewModel ProductMsgView = (ProductMsgViewModel)it;
                        QueryProductMsgInput queryProductMsg = objectMapper.Map<QueryProductMsgInput>(ProductMsgView);
                        var data= ProductMsgApp.Find(queryProductMsg,  page, size);
                        var result= objectMapper.Map<List<ProductMsgViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= ProductMsgApp.Find(new QueryProductMsgInput(), page, size);
                        var result= objectMapper.Map<List<ProductMsgViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindSellerCouponConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.SellerCoupon"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    SellerCouponViewModel SellerCouponView = (SellerCouponViewModel)it;
                    CreateSellerCouponInput createSellerCoupon= objectMapper.Map<CreateSellerCouponInput>(SellerCouponView);
                    SellerCouponAppService SellerCouponApp = StartManager.serviceProvider.GetService<SellerCouponAppService>();
                    SellerCouponApp.Insert(createSellerCoupon);
                    return  1;
                },
                Modify = (it) =>
                {
                   SellerCouponViewModel SellerCouponView = (SellerCouponViewModel)it;
                    UpdateSellerCouponInput createSellerCoupon = objectMapper.Map<UpdateSellerCouponInput>(SellerCouponView);
                    SellerCouponAppService SellerCouponApp = StartManager.serviceProvider.GetService<SellerCouponAppService>();
                    SellerCouponApp.Update(createSellerCoupon);
                },
                Delete = (it) =>
                {
                    SellerCouponViewModel SellerCouponView = (SellerCouponViewModel)it;
                    SellerCouponAppService SellerCouponApp = StartManager.serviceProvider.GetService<SellerCouponAppService>();
                    SellerCouponApp.Delete(SellerCouponView.Id);
                },
                DeleteList = (it) =>
                {
                    SellerCouponViewModel[] SellerCouponViews = (SellerCouponViewModel[])it;
                    List<long> ids = SellerCouponViews.Select(it1 => it1.Id).ToList();
                    SellerCouponAppService SellerCouponApp = StartManager.serviceProvider.GetService<SellerCouponAppService>();
                    SellerCouponApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    SellerCouponAppService SellerCouponApp = StartManager.serviceProvider.GetService<SellerCouponAppService>();
                    var data= SellerCouponApp.Find( page, size);
                    var result= objectMapper.Map<List<SellerCouponViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    SellerCouponAppService SellerCouponApp = StartManager.serviceProvider.GetService<SellerCouponAppService>();
                    if (it == null)
                    {
                        SellerCouponViewModel SellerCouponView = (SellerCouponViewModel)it;
                        QuerySellerCouponInput querySellerCoupon = objectMapper.Map<QuerySellerCouponInput>(SellerCouponView);
                        var data= SellerCouponApp.Find(querySellerCoupon,  page, size);
                        var result= objectMapper.Map<List<SellerCouponViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= SellerCouponApp.Find(new QuerySellerCouponInput(), page, size);
                        var result= objectMapper.Map<List<SellerCouponViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindSellerCouponSettsingConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.SellerCouponSettsing"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    SellerCouponSettsingViewModel SellerCouponSettsingView = (SellerCouponSettsingViewModel)it;
                    CreateSellerCouponSettsingInput createSellerCouponSettsing= objectMapper.Map<CreateSellerCouponSettsingInput>(SellerCouponSettsingView);
                    SellerCouponSettsingAppService SellerCouponSettsingApp = StartManager.serviceProvider.GetService<SellerCouponSettsingAppService>();
                    SellerCouponSettsingApp.Insert(createSellerCouponSettsing);
                    return  1;
                },
                Modify = (it) =>
                {
                   SellerCouponSettsingViewModel SellerCouponSettsingView = (SellerCouponSettsingViewModel)it;
                    UpdateSellerCouponSettsingInput createSellerCouponSettsing = objectMapper.Map<UpdateSellerCouponSettsingInput>(SellerCouponSettsingView);
                    SellerCouponSettsingAppService SellerCouponSettsingApp = StartManager.serviceProvider.GetService<SellerCouponSettsingAppService>();
                    SellerCouponSettsingApp.Update(createSellerCouponSettsing);
                },
                Delete = (it) =>
                {
                    SellerCouponSettsingViewModel SellerCouponSettsingView = (SellerCouponSettsingViewModel)it;
                    SellerCouponSettsingAppService SellerCouponSettsingApp = StartManager.serviceProvider.GetService<SellerCouponSettsingAppService>();
                    SellerCouponSettsingApp.Delete(SellerCouponSettsingView.Id);
                },
                DeleteList = (it) =>
                {
                    SellerCouponSettsingViewModel[] SellerCouponSettsingViews = (SellerCouponSettsingViewModel[])it;
                    List<long> ids = SellerCouponSettsingViews.Select(it1 => it1.Id).ToList();
                    SellerCouponSettsingAppService SellerCouponSettsingApp = StartManager.serviceProvider.GetService<SellerCouponSettsingAppService>();
                    SellerCouponSettsingApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    SellerCouponSettsingAppService SellerCouponSettsingApp = StartManager.serviceProvider.GetService<SellerCouponSettsingAppService>();
                    var data= SellerCouponSettsingApp.Find( page, size);
                    var result= objectMapper.Map<List<SellerCouponSettsingViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    SellerCouponSettsingAppService SellerCouponSettsingApp = StartManager.serviceProvider.GetService<SellerCouponSettsingAppService>();
                    if (it == null)
                    {
                        SellerCouponSettsingViewModel SellerCouponSettsingView = (SellerCouponSettsingViewModel)it;
                        QuerySellerCouponSettsingInput querySellerCouponSettsing = objectMapper.Map<QuerySellerCouponSettsingInput>(SellerCouponSettsingView);
                        var data= SellerCouponSettsingApp.Find(querySellerCouponSettsing,  page, size);
                        var result= objectMapper.Map<List<SellerCouponSettsingViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= SellerCouponSettsingApp.Find(new QuerySellerCouponSettsingInput(), page, size);
                        var result= objectMapper.Map<List<SellerCouponSettsingViewModel>>(data);
                        return result;
                   }
                },
            };        
}

        private static void BindSellerIntegralSettingConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.SellerIntegralSetting"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    SellerIntegralSettingViewModel SellerIntegralSettingView = (SellerIntegralSettingViewModel)it;
                    CreateSellerIntegralSettingInput createSellerIntegralSetting= objectMapper.Map<CreateSellerIntegralSettingInput>(SellerIntegralSettingView);
                    SellerIntegralSettingAppService SellerIntegralSettingApp = StartManager.serviceProvider.GetService<SellerIntegralSettingAppService>();
                    SellerIntegralSettingApp.Insert(createSellerIntegralSetting);
                    return  1;
                },
                Modify = (it) =>
                {
                   SellerIntegralSettingViewModel SellerIntegralSettingView = (SellerIntegralSettingViewModel)it;
                    UpdateSellerIntegralSettingInput createSellerIntegralSetting = objectMapper.Map<UpdateSellerIntegralSettingInput>(SellerIntegralSettingView);
                    SellerIntegralSettingAppService SellerIntegralSettingApp = StartManager.serviceProvider.GetService<SellerIntegralSettingAppService>();
                    SellerIntegralSettingApp.Update(createSellerIntegralSetting);
                },
                Delete = (it) =>
                {
                    SellerIntegralSettingViewModel SellerIntegralSettingView = (SellerIntegralSettingViewModel)it;
                    SellerIntegralSettingAppService SellerIntegralSettingApp = StartManager.serviceProvider.GetService<SellerIntegralSettingAppService>();
                    SellerIntegralSettingApp.Delete(SellerIntegralSettingView.Id);
                },
                DeleteList = (it) =>
                {
                    SellerIntegralSettingViewModel[] SellerIntegralSettingViews = (SellerIntegralSettingViewModel[])it;
                    List<long> ids = SellerIntegralSettingViews.Select(it1 => it1.Id).ToList();
                    SellerIntegralSettingAppService SellerIntegralSettingApp = StartManager.serviceProvider.GetService<SellerIntegralSettingAppService>();
                    SellerIntegralSettingApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    SellerIntegralSettingAppService SellerIntegralSettingApp = StartManager.serviceProvider.GetService<SellerIntegralSettingAppService>();
                    var data= SellerIntegralSettingApp.Find( page, size);
                    var result= objectMapper.Map<List<SellerIntegralSettingViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    SellerIntegralSettingAppService SellerIntegralSettingApp = StartManager.serviceProvider.GetService<SellerIntegralSettingAppService>();
                    if (it == null)
                    {
                        SellerIntegralSettingViewModel SellerIntegralSettingView = (SellerIntegralSettingViewModel)it;
                        QuerySellerIntegralSettingInput querySellerIntegralSetting = objectMapper.Map<QuerySellerIntegralSettingInput>(SellerIntegralSettingView);
                        var data= SellerIntegralSettingApp.Find(querySellerIntegralSetting,  page, size);
                        var result= objectMapper.Map<List<SellerIntegralSettingViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= SellerIntegralSettingApp.Find(new QuerySellerIntegralSettingInput(), page, size);
                        var result= objectMapper.Map<List<SellerIntegralSettingViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindSellerPrizeConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.SellerPrize"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    SellerPrizeViewModel SellerPrizeView = (SellerPrizeViewModel)it;
                    CreateSellerPrizeInput createSellerPrize= objectMapper.Map<CreateSellerPrizeInput>(SellerPrizeView);
                    SellerPrizeAppService SellerPrizeApp = StartManager.serviceProvider.GetService<SellerPrizeAppService>();
                    SellerPrizeApp.Insert(createSellerPrize);
                    return  1;
                },
                Modify = (it) =>
                {
                   SellerPrizeViewModel SellerPrizeView = (SellerPrizeViewModel)it;
                    UpdateSellerPrizeInput createSellerPrize = objectMapper.Map<UpdateSellerPrizeInput>(SellerPrizeView);
                    SellerPrizeAppService SellerPrizeApp = StartManager.serviceProvider.GetService<SellerPrizeAppService>();
                    SellerPrizeApp.Update(createSellerPrize);
                },
                Delete = (it) =>
                {
                    SellerPrizeViewModel SellerPrizeView = (SellerPrizeViewModel)it;
                    SellerPrizeAppService SellerPrizeApp = StartManager.serviceProvider.GetService<SellerPrizeAppService>();
                    SellerPrizeApp.Delete(SellerPrizeView.Id);
                },
                DeleteList = (it) =>
                {
                    SellerPrizeViewModel[] SellerPrizeViews = (SellerPrizeViewModel[])it;
                    List<long> ids = SellerPrizeViews.Select(it1 => it1.Id).ToList();
                    SellerPrizeAppService SellerPrizeApp = StartManager.serviceProvider.GetService<SellerPrizeAppService>();
                    SellerPrizeApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    SellerPrizeAppService SellerPrizeApp = StartManager.serviceProvider.GetService<SellerPrizeAppService>();
                    var data= SellerPrizeApp.Find( page, size);
                    var result= objectMapper.Map<List<SellerPrizeViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    SellerPrizeAppService SellerPrizeApp = StartManager.serviceProvider.GetService<SellerPrizeAppService>();
                    if (it == null)
                    {
                        SellerPrizeViewModel SellerPrizeView = (SellerPrizeViewModel)it;
                        QuerySellerPrizeInput querySellerPrize = objectMapper.Map<QuerySellerPrizeInput>(SellerPrizeView);
                        var data= SellerPrizeApp.Find(querySellerPrize,  page, size);
                        var result= objectMapper.Map<List<SellerPrizeViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= SellerPrizeApp.Find(new QuerySellerPrizeInput(), page, size);
                        var result= objectMapper.Map<List<SellerPrizeViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindSellerPrizeSettingConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.SellerPrizeSetting"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    SellerPrizeSettingViewModel SellerPrizeSettingView = (SellerPrizeSettingViewModel)it;
                    CreateSellerPrizeSettingInput createSellerPrizeSetting= objectMapper.Map<CreateSellerPrizeSettingInput>(SellerPrizeSettingView);
                    SellerPrizeSettingAppService SellerPrizeSettingApp = StartManager.serviceProvider.GetService<SellerPrizeSettingAppService>();
                    SellerPrizeSettingApp.Insert(createSellerPrizeSetting);
                    return  1;
                },
                Modify = (it) =>
                {
                   SellerPrizeSettingViewModel SellerPrizeSettingView = (SellerPrizeSettingViewModel)it;
                    UpdateSellerPrizeSettingInput createSellerPrizeSetting = objectMapper.Map<UpdateSellerPrizeSettingInput>(SellerPrizeSettingView);
                    SellerPrizeSettingAppService SellerPrizeSettingApp = StartManager.serviceProvider.GetService<SellerPrizeSettingAppService>();
                    SellerPrizeSettingApp.Update(createSellerPrizeSetting);
                },
                Delete = (it) =>
                {
                    SellerPrizeSettingViewModel SellerPrizeSettingView = (SellerPrizeSettingViewModel)it;
                    SellerPrizeSettingAppService SellerPrizeSettingApp = StartManager.serviceProvider.GetService<SellerPrizeSettingAppService>();
                    SellerPrizeSettingApp.Delete(SellerPrizeSettingView.Id);
                },
                DeleteList = (it) =>
                {
                    SellerPrizeSettingViewModel[] SellerPrizeSettingViews = (SellerPrizeSettingViewModel[])it;
                    List<long> ids = SellerPrizeSettingViews.Select(it1 => it1.Id).ToList();
                    SellerPrizeSettingAppService SellerPrizeSettingApp = StartManager.serviceProvider.GetService<SellerPrizeSettingAppService>();
                    SellerPrizeSettingApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    SellerPrizeSettingAppService SellerPrizeSettingApp = StartManager.serviceProvider.GetService<SellerPrizeSettingAppService>();
                    var data= SellerPrizeSettingApp.Find( page, size);
                    var result= objectMapper.Map<List<SellerPrizeSettingViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    SellerPrizeSettingAppService SellerPrizeSettingApp = StartManager.serviceProvider.GetService<SellerPrizeSettingAppService>();
                    if (it == null)
                    {
                        SellerPrizeSettingViewModel SellerPrizeSettingView = (SellerPrizeSettingViewModel)it;
                        QuerySellerPrizeSettingInput querySellerPrizeSetting = objectMapper.Map<QuerySellerPrizeSettingInput>(SellerPrizeSettingView);
                        var data= SellerPrizeSettingApp.Find(querySellerPrizeSetting,  page, size);
                        var result= objectMapper.Map<List<SellerPrizeSettingViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= SellerPrizeSettingApp.Find(new QuerySellerPrizeSettingInput(), page, size);
                        var result= objectMapper.Map<List<SellerPrizeSettingViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindSmsConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.Sms"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    SmsViewModel SmsView = (SmsViewModel)it;
                    CreateSmsInput createSms= objectMapper.Map<CreateSmsInput>(SmsView);
                    SmsAppService SmsApp = StartManager.serviceProvider.GetService<SmsAppService>();
                    SmsApp.Insert(createSms);
                    return  1;
                },
                Modify = (it) =>
                {
                   SmsViewModel SmsView = (SmsViewModel)it;
                    UpdateSmsInput createSms = objectMapper.Map<UpdateSmsInput>(SmsView);
                    SmsAppService SmsApp = StartManager.serviceProvider.GetService<SmsAppService>();
                    SmsApp.Update(createSms);
                },
                Delete = (it) =>
                {
                    SmsViewModel SmsView = (SmsViewModel)it;
                    SmsAppService SmsApp = StartManager.serviceProvider.GetService<SmsAppService>();
                    SmsApp.Delete(SmsView.Id);
                },
                DeleteList = (it) =>
                {
                    SmsViewModel[] SmsViews = (SmsViewModel[])it;
                    List<long> ids = SmsViews.Select(it1 => it1.Id).ToList();
                    SmsAppService SmsApp = StartManager.serviceProvider.GetService<SmsAppService>();
                    SmsApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    SmsAppService SmsApp = StartManager.serviceProvider.GetService<SmsAppService>();
                    var data= SmsApp.Find( page, size);
                    var result= objectMapper.Map<List<SmsViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    SmsAppService SmsApp = StartManager.serviceProvider.GetService<SmsAppService>();
                    if (it == null)
                    {
                        SmsViewModel SmsView = (SmsViewModel)it;
                        QuerySmsInput querySms = objectMapper.Map<QuerySmsInput>(SmsView);
                        var data= SmsApp.Find(querySms,  page, size);
                        var result= objectMapper.Map<List<SmsViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= SmsApp.Find(new QuerySmsInput(), page, size);
                        var result= objectMapper.Map<List<SmsViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindClassConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.Class"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    ClassViewModel ClassView = (ClassViewModel)it;
                    CreateClassInput createClass= objectMapper.Map<CreateClassInput>(ClassView);
                    ClassAppService ClassApp = StartManager.serviceProvider.GetService<ClassAppService>();
                    ClassApp.Insert(createClass);
                    return  1;
                },
                Modify = (it) =>
                {
                   ClassViewModel ClassView = (ClassViewModel)it;
                    UpdateClassInput createClass = objectMapper.Map<UpdateClassInput>(ClassView);
                    ClassAppService ClassApp = StartManager.serviceProvider.GetService<ClassAppService>();
                    ClassApp.Update(createClass);
                },
                Delete = (it) =>
                {
                    ClassViewModel ClassView = (ClassViewModel)it;
                    ClassAppService ClassApp = StartManager.serviceProvider.GetService<ClassAppService>();
                    ClassApp.Delete(ClassView.Id);
                },
                DeleteList = (it) =>
                {
                    ClassViewModel[] ClassViews = (ClassViewModel[])it;
                    List<long> ids = ClassViews.Select(it1 => it1.Id).ToList();
                    ClassAppService ClassApp = StartManager.serviceProvider.GetService<ClassAppService>();
                    ClassApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    ClassAppService ClassApp = StartManager.serviceProvider.GetService<ClassAppService>();
                    var data= ClassApp.Find( page, size);
                    var result= objectMapper.Map<List<ClassViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    ClassAppService ClassApp = StartManager.serviceProvider.GetService<ClassAppService>();
                    if (it == null)
                    {
                        ClassViewModel ClassView = (ClassViewModel)it;
                        QueryClassInput queryClass = objectMapper.Map<QueryClassInput>(ClassView);
                        var data= ClassApp.Find(queryClass,  page, size);
                        var result= objectMapper.Map<List<ClassViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= ClassApp.Find(new QueryClassInput(), page, size);
                        var result= objectMapper.Map<List<ClassViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindMenuConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.Menu"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    MenuViewModel MenuView = (MenuViewModel)it;
                    CreateMenuInput createMenu= objectMapper.Map<CreateMenuInput>(MenuView);
                    MenuAppService MenuApp = StartManager.serviceProvider.GetService<MenuAppService>();
                    MenuApp.Insert(createMenu);
                    return  1;
                },
                Modify = (it) =>
                {
                   MenuViewModel MenuView = (MenuViewModel)it;
                    UpdateMenuInput createMenu = objectMapper.Map<UpdateMenuInput>(MenuView);
                    MenuAppService MenuApp = StartManager.serviceProvider.GetService<MenuAppService>();
                    MenuApp.Update(createMenu);
                },
                Delete = (it) =>
                {
                    MenuViewModel MenuView = (MenuViewModel)it;
                    MenuAppService MenuApp = StartManager.serviceProvider.GetService<MenuAppService>();
                    MenuApp.Delete(MenuView.Id);
                },
                DeleteList = (it) =>
                {
                    MenuViewModel[] MenuViews = (MenuViewModel[])it;
                    List<long> ids = MenuViews.Select(it1 => it1.Id).ToList();
                    MenuAppService MenuApp = StartManager.serviceProvider.GetService<MenuAppService>();
                    MenuApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    MenuAppService MenuApp = StartManager.serviceProvider.GetService<MenuAppService>();
                    var data= MenuApp.Find( page, size);
                    var result= objectMapper.Map<List<MenuViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    MenuAppService MenuApp = StartManager.serviceProvider.GetService<MenuAppService>();
                    if (it == null)
                    {
                        MenuViewModel MenuView = (MenuViewModel)it;
                        QueryMenuInput queryMenu = objectMapper.Map<QueryMenuInput>(MenuView);
                        var data= MenuApp.Find(queryMenu,  page, size);
                        var result= objectMapper.Map<List<MenuViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= MenuApp.Find(new QueryMenuInput(), page, size);
                        var result= objectMapper.Map<List<MenuViewModel>>(data);
                        return result;
                   }
                },
            };        
}
        private static void BindStudentConfig()
        {
            CacheListModelManager.CacheFlagMethod["Config.Student"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    StudentViewModel StudentView = (StudentViewModel)it;
                    CreateStudentInput createStudent= objectMapper.Map<CreateStudentInput>(StudentView);
                    StudentAppService StudentApp = StartManager.serviceProvider.GetService<StudentAppService>();
                    StudentApp.Insert(createStudent);
                    return  1;
                },
                Modify = (it) =>
                {
                   StudentViewModel StudentView = (StudentViewModel)it;
                    UpdateStudentInput createStudent = objectMapper.Map<UpdateStudentInput>(StudentView);
                    StudentAppService StudentApp = StartManager.serviceProvider.GetService<StudentAppService>();
                    StudentApp.Update(createStudent);
                },
                Delete = (it) =>
                {
                    StudentViewModel StudentView = (StudentViewModel)it;
                    StudentAppService StudentApp = StartManager.serviceProvider.GetService<StudentAppService>();
                    StudentApp.Delete(StudentView.Id);
                },
                DeleteList = (it) =>
                {
                    StudentViewModel[] StudentViews = (StudentViewModel[])it;
                    List<long> ids = StudentViews.Select(it1 => it1.Id).ToList();
                    StudentAppService StudentApp = StartManager.serviceProvider.GetService<StudentAppService>();
                    StudentApp.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    StudentAppService StudentApp = StartManager.serviceProvider.GetService<StudentAppService>();
                    var data= StudentApp.Find( page, size);
                    var result= objectMapper.Map<List<StudentViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    StudentAppService StudentApp = StartManager.serviceProvider.GetService<StudentAppService>();
                    if (it == null)
                    {
                        StudentViewModel StudentView = (StudentViewModel)it;
                        QueryStudentInput queryStudent = objectMapper.Map<QueryStudentInput>(StudentView);
                        var data= StudentApp.Find(queryStudent,  page, size);
                        var result= objectMapper.Map<List<StudentViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= StudentApp.Find(new QueryStudentInput(), page, size);
                        var result= objectMapper.Map<List<StudentViewModel>>(data);
                        return result;
                   }
                },
            };        
}

  
    }
}
