# mmoPortfolioProject

I am developing this project to demonstrate my abilities.
The project will be the backend of an mmo game.

I will develop the project with Onion Architecture to make it as controllable as possible.

The project is divided into 6 sub-projects.

1) Domain
  This sub-project will classically hold entities. We can say that it is the most central of architecture.
      
2) Application
  This sub-project was created to solve the dependency problem of the project together with the interfaces. In this way, the changes to be made in the projects will      be prevented from affecting other projects, both when making major changes such as the database provider, and as the place where the common structures to be used in      other layers are stored.
      
3) Persistence
  This project will keep the concrete forms of the service and repository interfaces that will be created by me in the application project. Basic business logic will     be executed here.

4) Infrastructure
  This project will be the project to which 3rd party services(SMS, E-Mail etc...) are connected.
  
5) Presentation / API
  This project will be a webapi project that will raise our backends and ensure connection.
  
6) Test
  This project will hold the test classes for the rest of the project. I used the XUnit library while testing.
      
      
      
