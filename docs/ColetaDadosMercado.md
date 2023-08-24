ColetaDadosMercado
│   
└───src
│   │   
│   └───ColetaDadosMercado.Application
│   │   │   
│   │   └───Commands
│   │   │   │   CreateDataCollectionCommand.cs
│   │   │   │   GetDataCollectionQuery.cs
│   │   │   │   ...
│   │   │   
│   │   └───Interfaces
│   │   │   │   IDataCollectionService.cs
│   │   │   │   ...
│   │   │   
│   │   └───Mappers
│   │   │   │   DataCollectionProfile.cs
│   │   │   │   ...
│   │   │   
│   │   └───ViewModels
│   │   │   │   DataCollectionViewModel.cs
│   │   │   │   ...
│   │   │   
│   │   └───ColetaDadosMercado.Application.csproj
│   │         
│   └───ColetaDadosMercado.Domain
│   │   │   
│   │   └───Entities
│   │   │   │   DataCollection.cs
│   │   │   │   ...
│   │   │   
│   │   └───Interfaces
│   │   │   │   IDataCollectionRepository.cs
│   │   │   │   ...
│   │   │   
│   │   └───ColetaDadosMercado.Domain.csproj
│   │  
│   └───ColetaDadosMercado.Infrastructure
│   │   │   
│   │   └───Data
│   │   │   │   ApplicationDbContext.cs
│   │   │   │   DataCollectionRepository.cs
│   │   │   │   ...
│   │   │   
│   │   └───ColetaDadosMercado.Infrastructure.csproj
│   │  
│   └───ColetaDadosMercado.API
│       │   
│       └───Controllers
│       │   │   DataCollectionController.cs
│       │   │   ...
│       │   
│       └───Extensions
│       │   │   IServiceCollectionExtensions.cs
│       │   │   ...
│       │   
│       └───Startup.cs
│       │   
│       └───ColetaDadosMercado.API.csproj
│           
└───tests
    │   
    └───ColetaDadosMercado.Tests
        │   
        └───ColetaDadosMercado.Tests.csproj
        │   
        └───Integration
        │   │   DataCollectionControllerTests.cs
        │   │   ...
        │   
        └───Unit
            │   DataCollectionServiceTests.cs
            │   ...
