Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Linq
Imports System.ServiceModel.Web

Public Class WCFDataServiceSesesvc
    ' TODO: replace [[class name]] with your data class name
    Inherits EntityFrameworkDataService(Of AutobusesSeseEntities)

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        ' TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
        ' Examples:
        config.SetEntitySetAccessRule("*", EntitySetRights.AllRead)
        ' config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All)
        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3
    End Sub

End Class
