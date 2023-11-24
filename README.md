# Checkout.Services

A Repository pattern is a design pattern that mediates data from and to the Domain and Data Access Layers (like Entity Framework Core).
Repositories are classes that hide the logics required to store or retreive data. 
The solution contains,
Checkout.Service.Model - domain and enitite object should be defined here
Checkout.Service.Interface - contains interfaces for repository, DTOs, Requests, Responses, etc
Checkout.Service.Repositories - contains the business logic, AppDBContext file that contains DBset, and OnMethodCreating method to seed or set the identities, defaults, etc., 
    DbExtensions, EFExtensions, IrelationalExtensions files can be created here for executing the sql queries and procs. QueryGenerators, QueryFilters classes can de desinged to generate the query for each controller.
Checkout.Services - Application layer that contains controllers, http requests, responses. It is the startup project of the application, program.cs has the webbuilder and services configuration and middleware pipeline.
Checkout.Services.utils - constants, enum, properties, etc., will be defined here. 
checkout.Services.Test - MSTest unit project added to test the Checkoutcontroller. Moq used to mock the repository and test the controller.



