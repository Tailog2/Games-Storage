# Games Storage

<br/> This a test app made by using .NET Core 6
<br/> Where Used ASP.NET Core and Entity FrameWork

<br/> This web app represents an API with Clean Architecture with Repository pattern and thin controllers
<br/> App structure consists of three element contained in folders Core (Interactor), Persistent(Data) and Presentation (Controller)

<br/> Such implementation of Clean Architecture has few flaws
<br/> First, using Repository pattern with Unit Of Work elements and Entity FrameWork creates problems with processing complex data that requires use of multiple Join Tables
<br/> Second, In order to keep controllers thin was used AutoMapper and Services. This leeds to that Mapping and Dtos became responsibility of Core level and Presantaion level has to use Dtos directly from Core level.
<br/> Like all the problems there also can be solved, but it will lead to unnecessary complexity and loses in maintableity that could be as bad as low scalability
