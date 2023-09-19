graph TD

    subgraph Data Collection
        direction LR
        Browl.Client -->|Log| Browl.Service.MonitoringLogging
        Browl.Client -->|Data| Browl.Service.MarketDataCollector
        Browl.Service.MarketDataCollector -->|Log| Browl.Service.MonitoringLogging
        Browl.Service.MarketDataCollector -->|Data| Browl.Service.DataNormalization
        Browl.Service.DataNormalization -->|Log| Browl.Service.MonitoringLogging
    end

    subgraph Analysis  
        direction LR              
        Browl.Client -->|Log| Browl.Service.MonitoringLogging
        Browl.Client -->|Data| Browl.Service.MarketAnalysis
        Browl.Service.MarketAnalysis -->|Log| Browl.Service.MonitoringLogging
        Browl.Service.MarketAnalysis -->|Data| Browl.Service.PriceForecasting
        Browl.Service.PriceForecasting -->|Log| Browl.Service.MonitoringLogging
    end

    subgraph Execution
        direction LR
        Browl.Client -->|Log| Browl.Service.MonitoringLogging
        Browl.Client -->|Data| Browl.Service.Trading
        Browl.Service.Trading -->|Log| Browl.Service.MonitoringLogging
        Browl.Service.Trading -->|Orders| Browl.Service.OrderManagement
        Browl.Service.OrderManagement -->|Log| Browl.Service.MonitoringLogging
        Browl.Service.OrderManagement -->|Connection| Browl.Service.BrokerConnection
        Browl.Service.BrokerConnection -->|Log| Browl.Service.MonitoringLogging
        Browl.Service.BrokerConnection -->|Trading| Browl.Service.RiskManagement
        Browl.Service.RiskManagement -->|Log| Browl.Service.MonitoringLogging
        Browl.Service.RiskManagement -->|Risk| Browl.Service.PriceForecasting
        Browl.Service.PriceForecasting -->|Log| Browl.Service.MonitoringLogging
        Browl.Service.RiskManagement -->|Orders| Browl.Service.OrderManagement
    end
    
    subgraph Persistence
        direction LR
        Reference:Orders 
        Reference:Profits
        Reference:Balance
        Reference:Logs
    end

    subgraph Support
        direction TB
        Browl.Client
        Browl.Service.AuthSecurity
        Browl.Service.MonitoringLogging
    end  

    Browl.Service.AuthSecurity -->|Auth| Browl.Client 
    Browl.Service.MonitoringLogging -->|Log| Reference:Logs

    Browl.Client -->|Log| Reference:Logs
    Browl.Client -->|Data| Browl.Service.MarketDataCollector
    Browl.Client -->|Data| Browl.Service.MarketAnalysis
    Browl.Client -->|Data| Browl.Service.Trading
    Browl.Client -->|Log| Browl.Service.MonitoringLogging

    classDef default fill:#a4732c,stroke:#4a4b4d;
    classDef external fill:#a4732c,stroke:#a4732c;
    classDef Browl.Client fill:#ffffff,stroke:#4a4b4d;
    classDef Browl.Client font-size:16px;
