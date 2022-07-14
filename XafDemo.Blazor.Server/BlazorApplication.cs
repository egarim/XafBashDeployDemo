﻿using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.ExpressApp.Xpo;
using XafDemo.Blazor.Server.Services;

namespace XafDemo.Blazor.Server {
    public partial class XafDemoBlazorApplication : BlazorApplication {
        public XafDemoBlazorApplication() {
            InitializeComponent();
        }
        protected override void OnSetupStarted() {
            base.OnSetupStarted();
            IConfiguration configuration = ServiceProvider.GetRequiredService<IConfiguration>();
            if(configuration.GetConnectionString("ConnectionString") != null) {
                ConnectionString = configuration.GetConnectionString("ConnectionString");
            }
           
           //HACK in memory connection string
           //ConnectionString=InMemoryDataStoreProvider.ConnectionString;
        }
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            IXpoDataStoreProvider dataStoreProvider = GetDataStoreProvider(args.ConnectionString, args.Connection);
            args.ObjectSpaceProviders.Add(new SecuredObjectSpaceProvider((ISelectDataSecurityProvider)Security, dataStoreProvider, true));
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }
        private IXpoDataStoreProvider GetDataStoreProvider(string connectionString, System.Data.IDbConnection connection) {
            XpoDataStoreProviderAccessor accessor = ServiceProvider.GetRequiredService<XpoDataStoreProviderAccessor>();
            lock(accessor) {
                if(accessor.DataStoreProvider == null) {
                    accessor.DataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(connectionString, connection, true);
                }
            }
            return accessor.DataStoreProvider;
        }
        private void XafDemoBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
            
             e.Updater.Update();
             e.Handled = true;
            // if(System.Diagnostics.Debugger.IsAttached) {
            //     e.Updater.Update();
            //     e.Handled = true;
            // }
            // else {
            //     string message = "The application cannot connect to the specified database, " +
            //         "because the database doesn't exist, its version is older " +
            //         "than that of the application or its schema does not match " +
            //         "the ORM data model structure. To avoid this error, use one " +
            //         "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            //     if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
            //         message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            //     }
            //     throw new InvalidOperationException(message);
            // }
        }
    }
}
