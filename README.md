# CMPG323
CMPG323 Project 3
## Welcome to CMPG323 Project 3.
#### Introduction
Project 3 is a WebApp solution that has been built through Microsoft Visual Studios. The database for this project will be hosted on Azure. 

## Repository Pattern 

![repository-aggregate-database-table-relationships](https://user-images.githubusercontent.com/110536628/192739968-389ef981-959a-4bc3-b43c-1b0442cec459.png)


https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/infrastructure-persistence-layer-design/repository-aggregate-database-table-relationships.png

For this project, I have selected to implement Tier 2 repository pattern. Basically, the controllers are seperated into seperate repositories. This is because if a change needs to be made in a specific controller, it would be convenient to only make the change in that specific controller repository.
